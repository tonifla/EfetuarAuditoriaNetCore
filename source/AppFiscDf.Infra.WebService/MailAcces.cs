using AppFiscDf.Application.Model.RequestResponse;
using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppFiscDf.Infra.WebService
{
    public class MailAccess
    {
        private readonly string mailServer, login, password;
        private readonly int port;
        private readonly bool ssl;

        public MailAccess(string mailServer, int port, bool ssl, string login, string password)
        {
            this.mailServer = mailServer;
            this.port = port;
            this.ssl = ssl;
            this.login = login;
            this.password = password;
        }

        internal void MoveMsgtofolder(IList<IMessageSummary> lstmsg, IMailFolder folderOrigem, IMailFolder folderdestino)
        {
            foreach (IMessageSummary msg in lstmsg)
            {
                folderOrigem.MoveTo(msg.UniqueId, folderdestino);
            }
        }

        public IList<EmailResponse> GetAllMailsUndeliverable(string InpectionDocumentId)
        {
            var messages = new List<EmailResponse>();
            using var client = new ImapClient();
            client.Connect(mailServer, port, ssl);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(login, password);
            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadWrite);
            var now = DateTime.Now;

            IList<IMessageSummary> allMessage = null;
            if (client.Inbox.Count > 0)
            {
                allMessage = client.Inbox.Fetch(0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.Envelope | MessageSummaryItems.Id)
                .Where(x => (x.Envelope.Subject.Contains("Undeliverable") || x.Envelope.Subject.Contains("Não é possível entregar"))
                       && (x.Date.Year == now.Year && x.Date.Month == now.Month && x.Date.Day == now.Day))
                    .OrderByDescending(o => o.Date).ToList();
            }

            if (allMessage != null)
            {
                foreach (var msg in allMessage)
                {
                    var message = inbox.GetMessage(msg.UniqueId);
                    if (message.HtmlBody.Contains(InpectionDocumentId))
                    {
                        var recipients = new List<ContactResponse>();

                        var emails = ExtractEmails(message.HtmlBody);
                        var Emaildevolvido = string.Empty;
                        if (emails.Count > 0)
                        {
                            Emaildevolvido = emails[0];
                            recipients.Add(new ContactResponse() { Email = Emaildevolvido });
                        }

                        messages.Add(new EmailResponse()
                        {
                            //message.HtmlBody

                            Message = new MensagemResponse() { Content = "Email Devolvido " + Emaildevolvido, Subject = "App Fisc DF Erro no envio de email " + msg.Envelope.Subject, Typemessage = Typemessage.HTML },
                            Recipients = recipients,
                            Sender = new SenderResponse() { InspectionDocumentId = Convert.ToInt32(InpectionDocumentId), Email = Emaildevolvido, Name = "Email devolvido" },
                        });
                    }
                }
            }
            if (messages.Count > 0)
            {
                var folderProblemaSinc = client.GetFolder(client.PersonalNamespaces[0]).GetSubfolders(false).Where(x => x.FullName == "Problemas de Sincronização").SingleOrDefault();
                MoveMsgtofolder(allMessage, client.Inbox, folderProblemaSinc);
            }

            client.Disconnect(true);
            return messages;
        }

        public static List<string> ExtractEmails(string textToScrape)
        {
            Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
            Match match;
            List<string> results = new List<string>();
            for (match = reg.Match(textToScrape); match.Success; match = match.NextMatch())
            {
                if (!(results.Contains(match.Value)))
                    results.Add(match.Value);
            }
            return results;
        }
    }
}
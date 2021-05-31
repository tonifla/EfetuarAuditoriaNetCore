using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppFiscDf.Application.Model.RequestResponse
{
    public class EmailResponse
    {
        public EmailResponse()
        {
            Recipients = new List<ContactResponse>();
            AttachmentResponse = new List<AttachmentResponse>();
            Message = new MensagemResponse();
        }

        [JsonPropertyName("recipients")]
        public List<ContactResponse> Recipients { get; set; }

        [JsonPropertyName("message")]
        public MensagemResponse Message { get; set; }

        public SenderResponse Sender { get; set; }

        public List<AttachmentResponse> AttachmentResponse { get; set; }
    }

    public class SenderResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int InspectionDocumentId { get; set; }
    }

    public class ContactResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class MensagemResponse
    {
        public string Subject { get; set; }
        public string Content { get; set; }

        [JsonPropertyName("Typemessage")]
        public Typemessage Typemessage { get; set; }
    }

    public class AttachmentResponse
    {
        public string FileBase64 { get; set; }
        public string NameBase64 { get; set; }
    }

    public enum Typemessage
    {
        TEMPLATECUSTOMIZADO,
        TEMPLATEPREDEFINIDO,
        HTML,
        TEXTO,
    }
}
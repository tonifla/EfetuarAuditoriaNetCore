using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.Services.UnitTests
{
    public class EmailSgaServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IEmailSgaService _service;

        public EmailSgaServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new EmailSgaService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "SendEmail")]
        public void GetSendEmailReturn_Sucess()
        {
            _testOutput.WriteLine("Teste Envio de Email do SGA");

            EmailResponse emailteste = new EmailResponse();
            emailteste.Recipients.Add(new ContactResponse() { Email = "teste@anp.gov.br", Name = "teste nome" });
            emailteste.AttachmentResponse.Add(new AttachmentResponse() { NameBase64 = "anexo de teste", FileBase64 = "/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEB" });

            string html = @"<html><bold>TESTE CONTEUDO NEGRITO</bold></html>";

            emailteste.Message = new MensagemResponse()
            {
                Subject = "Teste Assunto",
                Content = html,
                Typemessage = Typemessage.TEXTO
            };

            emailteste.Sender = new SenderResponse()
            {
                Name = "Name1",
                Email = "Email1",
                InspectionDocumentId = 1
            };

            var expected = Task.FromResult("SUCESSO");
            _mockUoW
                .Setup(x => x.EmailSga.SendEmailSmtp(emailteste))
                .Returns(expected);

            var result = _service.SendEmail(emailteste);
            _testOutput.WriteLine(result.ToString());
            Assert.NotNull(result);
            Assert.Equal("SUCESSO", result.Result.ToString());
        }

        [Fact]
        [Trait("TDD Services", "SendEmail")]
        public void GetSendEmailReturn_Fail()
        {
            _testOutput.WriteLine("Teste Envio de Email do SGA");
            EmailResponse emailteste = new EmailResponse();
            emailteste.Recipients.Add(new ContactResponse() { Email = "teste@anp.gov.br", Name = "teste nome" });
            emailteste.AttachmentResponse.Add(new AttachmentResponse() { NameBase64 = "anexo de teste", FileBase64 = "/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEB" });

            string html = @"<html><bold>TESTE CONTEUDO NEGRITO</bold></html>";
            emailteste.Message = new MensagemResponse()
            {
                Subject = "Teste Assunto",
                Content = html,
                Typemessage = Typemessage.TEXTO
            };
            var expected = Task.FromResult("FALHA");
            _mockUoW
                .Setup(x => x.EmailSga.SendEmailSmtp(emailteste))
                .Returns(expected);
            var result = _service.SendEmail(emailteste);
            _testOutput.WriteLine(result.ToString());
            Assert.NotNull(result);
            Assert.Equal("FALHA", result.Result.ToString());
        }

        [Fact]
        [Trait("TDD Services", "SendEmail")]
        public void VerifyEmailErroReturn_Sucess()
        {
            _testOutput.WriteLine("Verifica Envio de Email do SGA");

            var expected = true;

            _mockUoW
                .Setup(x => x.EmailSga.VerifyEmailErro(1));

            var result = _service.VerifyEmailErro(1) != null;

            _testOutput.WriteLine(result.ToString());

            Assert.True(result);
            Assert.Equal(result, expected);
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }
    }
}
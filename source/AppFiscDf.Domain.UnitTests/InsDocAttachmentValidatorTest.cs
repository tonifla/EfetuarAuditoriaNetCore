using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocAttachmentValidatorTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocAttachmentValidatorTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_PostWithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Post);
            var insDocAttachment = new InsDocAttachment();
            var expected = false;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_PostWithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Post);
            var insDocAttachment = new InsDocAttachment
            {
                InsDocAttachmentId = 1,
                InspectionDocumentId = 1,
                Name = "Name1.jpg",
                AttachmentFile = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE")
            };

            var expected = true;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.True(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_PostIdWithTextEmpty_False()
        {
            _testOutput.WriteLine("Código do documento de fiscalização não foi informado.");

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Post);
            var insDocAttachment = new InsDocAttachment
            {
                InsDocAttachmentId = -1,
                InspectionDocumentId = 1,
                Name = "Name1",
                AttachmentFile = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE")
            };

            var expected = false;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_PostNameWithTextEmpty_False()
        {
            _testOutput.WriteLine("Nome do anexo está vazio ou nulo.");

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Post);
            var insDocAttachment = new InsDocAttachment
            {
                InsDocAttachmentId = 1,
                InspectionDocumentId = 1,
                Name = "",
                AttachmentFile = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE")
            };

            var expected = false;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_PostNameWithExtensionInvalid_False()
        {
            _testOutput.WriteLine("Anexo está extensão inválida.");

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Post);
            var insDocAttachment = new InsDocAttachment
            {
                InsDocAttachmentId = 1,
                InspectionDocumentId = 1,
                Name = "Name1.xxx",
                AttachmentFile = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE")
            };

            var expected = false;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_PostAttachmentFileWithTextEmpty_False()
        {
            _testOutput.WriteLine("Arquivo (em base64) do anexo está vazio ou nulo.");

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Post);
            var insDocAttachment = new InsDocAttachment
            {
                InsDocAttachmentId = 1,
                InspectionDocumentId = 1,
                Name = "Name1",
                AttachmentFile = Encoding.ASCII.GetBytes("")
            };
            var expected = false;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_DeleteWithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocAttachmentValidator = new InsDocAttachmentDeleteValidator(HttpMethods.Delete);
            var insDocAttachment = new InsDocAttachment();
            var expected = false;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_DeleteWithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Delete);
            var insDocAttachment = new InsDocAttachment
            {
                InspectionDocumentId = 1,
                InsDocAttachmentId = 1
            };

            var expected = true;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.True(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_DeleteIdWithTextEmpty_False()
        {
            _testOutput.WriteLine("Código do documento de fiscalização não foi informado.");

            var insDocValidator = new InsDocAttachmentDeleteValidator(HttpMethods.Delete);
            var insDocAttachment = new InsDocAttachment
            {
                InspectionDocumentId = -1,
                InsDocAttachmentId = 1
            };

            var expected = false;

            var result = insDocValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InsDocAttachment")]
        public void InsDocAttachmentValidator_DeleteAttachmentIdWithTextEmpty_False()
        {
            _testOutput.WriteLine("Código do anexo não foi informado.");

            var insDocAttachmentValidator = new InsDocAttachmentDeleteValidator(HttpMethods.Delete);
            var insDocAttachment = new InsDocAttachment
            {
                InspectionDocumentId = 1,
                InsDocAttachmentId = -1
            };

            var expected = false;

            var result = insDocAttachmentValidator.Validate(insDocAttachment);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}
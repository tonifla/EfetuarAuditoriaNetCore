using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using FizzWare.NBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.Services.UnitTests
{
    public class InsDocAttachmentServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IInsDocAttachmentService _service;

        public InsDocAttachmentServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new InsDocAttachmentService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "InsDocAttachment")]
        public void GetListByActivityAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os anexos por documento de fiscalização.");

            var insDocAttachment = Builder<InsDocAttachment>
                .CreateNew()
                .With(p => p.InsDocAttachmentId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.AttachmentFile = null)
                .With(p => p.AttachmentDate = DateTime.Now)
                .Build();

            var inspectionDocumentId = insDocAttachment.InspectionDocumentId;

            _mockUoW
                .Setup(x => x.InsDocAttachmentRepository.GetListByInsDocAttachmentAsync(inspectionDocumentId));

            var result = _service.ListByInsDocAttachmentAsync(inspectionDocumentId).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(insDocAttachment);
            Assert.NotNull(result);
            Assert.IsType<List<InsDocAttachmentRequestResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "InsDocAttachment")]
        public void GetFindByInsDocAttachmentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Localizar o anexo por código do documento de fiscalização e código do anexo.");

            var insDocAttachment = Builder<InsDocAttachment>
                .CreateNew()
                .With(p => p.InsDocAttachmentId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.AttachmentFile = null)
                .With(p => p.AttachmentDate = DateTime.Now)
                .Build();

            var inspectionDocumentId = insDocAttachment.InspectionDocumentId;
            var insDocAttachmentId = insDocAttachment.InsDocAttachmentId;

            _mockUoW
                .Setup(x => x.InsDocAttachmentRepository.GetFindByInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId));

            var result = _service.FindByInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(insDocAttachment);
            Assert.NotNull(result);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Services", "InsDocAttachment")]
        public void GetFindFileByInsDocAttachmentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Download do anexo do documento de fiscalização.");

            var insDocAttachment = Builder<InsDocAttachment>
                .CreateNew()
                .With(p => p.InsDocAttachmentId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.AttachmentFile = null)
                .With(p => p.AttachmentDate = DateTime.Now)
                .Build();

            var inspectionDocumentFinished = insDocAttachment.Name;

            _mockUoW
                .Setup(x => x.InsDocAttachmentRepository.GetFindByInsDocAttachmentAsync(inspectionDocumentFinished));

            var result = _service.FindByInsDocAttachmentAsync(inspectionDocumentFinished);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(insDocAttachment);
            Assert.NotNull(result);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Services", "InsDocAttachment")]
        public void InsertInsDocAttachmentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Inserir/Salvar o anexo.");

            var request = Builder<InsDocAttachmentRequestResponse>
                .CreateNew()
                .With(p => p.InsDocAttachmentId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.AttachmentFile = null)
                .Build();

            var insDocAttachment = InsDocAttachmentMapper.ConvertRequestToObject(request);

            _mockUoW
                .Setup(x => x.InsDocAttachmentRepository.AddAsync(insDocAttachment))
                .Verifiable();

            _service.InsertInsDocAttachmentAsync(request);

            Assert.NotNull(request);
            Assert.NotNull(insDocAttachment);
            Assert.IsType<InsDocAttachmentRequestResponse>(request);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
        }

        [Fact]
        [Trait("TDD Services", "InsDocAttachment")]
        public void DeleteInsDocAttachmentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Excluir o anexo.");

            var insDocAttachment = Builder<InsDocAttachment>
            .CreateNew()
            .With(p => p.InsDocAttachmentId = 1)
            .With(p => p.InspectionDocumentId = 1)
            .With(p => p.Name = "Name1")
            .With(p => p.AttachmentFile = null)
            .With(p => p.AttachmentDate = DateTime.Now)
            .Build();

            var inspectionDocumentId = insDocAttachment.InspectionDocumentId;
            var insDocAttachmentId = insDocAttachment.InsDocAttachmentId;

            var response = InsDocAttachmentMapper.ConvertObjectToResponse(insDocAttachment);

            _mockUoW
                .Setup(x => x.InsDocAttachmentRepository.RemoveAsync(insDocAttachment))
                .Verifiable();

            _service.DeleteInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);

            Assert.NotNull(response);
            Assert.NotNull(insDocAttachment);
            Assert.IsType<InsDocAttachmentRequestResponse>(response);
            Assert.IsType<InsDocAttachment>(insDocAttachment);
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
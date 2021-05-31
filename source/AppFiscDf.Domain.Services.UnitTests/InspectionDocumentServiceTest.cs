using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Services.Mappers;
using FizzWare.NBuilder;
using Moq;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.Services.UnitTests
{
    public class InspectionDocumentServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IInspectionDocumentService _service;

        public InspectionDocumentServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new InspectionDocumentService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void GetListByInspectionDocumentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os documentos de fiscalização por qualquer campo do filtro.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var finished = inspectionDocument.Finished;
            var inspectionAgentId = inspectionDocument.InsDocInspectionAgentList.ElementAt(0).InspectionAgentId;
            var startDate = DateTime.Now;
            var endDate = DateTime.Now;
            var sequentialCode = inspectionDocument.SequentialCode;
            var cpfCnpj = inspectionDocument.InsDocEconomicAgent.CpfCnpj;
            var companyName = inspectionDocument.InsDocEconomicAgent.CompanyName;

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.GetListByInspectionDocumentAsync(finished, inspectionAgentId, startDate, endDate, sequentialCode, cpfCnpj, companyName));

            var result = _service.ListByInspectionDocumentAsync(finished, inspectionAgentId, startDate, endDate, sequentialCode, cpfCnpj, companyName);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionDocument);
            Assert.NotNull(result);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void GetListByInspectionDocumentInspectionAgentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os documentos de fiscalização por agente de fiscalização.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = inspectionDocument.InsDocInspectionAgentList.ElementAt(0).InspectionAgentId;
            var finished = inspectionDocument.Finished;

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.GetListByInspectionDocumentAsync(inspectionAgentId, finished));

            var result = _service.ListByInspectionDocumentAsync(inspectionAgentId, finished);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionDocument);
            Assert.NotNull(result);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void GetListByInspectionDocumentPanelAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os documentos de fiscalização por qualquer campo do filtro pelo Painel.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var typeInspectionDocument = 0;
            var inspectionAgentId = inspectionDocument.InsDocInspectionAgentList.ElementAt(0).InspectionAgentId;
            var startDate = DateTime.Now;
            var endDate = DateTime.Now;
            var sequentialCode = inspectionDocument.SequentialCode;
            var economicAgentCpfCnpj = inspectionDocument.InsDocEconomicAgent.CpfCnpj;
            var economicAgentCompanyName = inspectionDocument.InsDocEconomicAgent.CompanyName;
            var nrUfId = inspectionDocument.Uf.NrUfId;
            var ufAcronym = inspectionDocument.Uf.UfAcronym;
            var orderServiceYear = inspectionDocument.InsDocServiceOrder.Year ?? 0;
            var orderServiceNumber = inspectionDocument.InsDocServiceOrder.Number ?? 0;
            var page = 1;

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.GetListByInspectionDocumentAsync(typeInspectionDocument, inspectionAgentId, startDate, endDate, sequentialCode, economicAgentCpfCnpj, economicAgentCompanyName, nrUfId, ufAcronym, orderServiceYear, orderServiceNumber, page));

            var result = _service.ListByInspectionDocumentAsync(typeInspectionDocument, inspectionAgentId, startDate, endDate, sequentialCode, economicAgentCpfCnpj, economicAgentCompanyName, nrUfId, ufAcronym, orderServiceYear, orderServiceNumber, page);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionDocument);
            Assert.NotNull(result);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InsDocAttachment")]
        public void GetFindByInspectionDocumentExistAsync_Returns_Success()
        {
            _testOutput.WriteLine("Localizar se o documento de fiscalização existe.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionDocumentId = inspectionDocument.InspectionDocumentId;

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.GetFindByInspectionDocumentAsync(inspectionDocumentId));

            var result = _service.FindByInspectionDocumentAsync(inspectionDocumentId);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionDocument);
            Assert.NotNull(result);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void GetFindByInspectionDocumentFinishedAsync_Returns_Success()
        {
            _testOutput.WriteLine("Localizar o documento de fiscalização finalizado.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = inspectionDocument.InsDocInspectionAgentList.ElementAt(0).InspectionAgentId;
            var sequentialCode = inspectionDocument.SequentialCode;
            var finished = true;

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.GetFindByInspectionDocumentAsync(inspectionAgentId, sequentialCode, finished));

            var result = _service.FindByInspectionDocumentAsync(inspectionAgentId, sequentialCode, finished);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionDocument);
            Assert.NotNull(result);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void GetFindByInspectionDocumentInEditionAsync_Returns_Success()
        {
            _testOutput.WriteLine("Localizar o documento de fiscalização em edição.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = inspectionDocument.InsDocInspectionAgentList.ElementAt(0).InspectionAgentId;
            var sequentialCode = inspectionDocument.SequentialCode;
            var finished = false;

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.GetFindByInspectionDocumentAsync(inspectionAgentId, sequentialCode, finished));

            var result = _service.FindByInspectionDocumentAsync(inspectionAgentId, sequentialCode, finished);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionDocument);
            Assert.NotNull(result);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void InsertInspectionDocumentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Inserir/Salvar o documento de fiscalização.");

            var request = Builder<InspectionDocumentRequestResponse>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.OrderServiceId = 1)
                .With(p => p.RepresentativeId = 1)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.InsDocSerializedRequestResponses = Builder<InsDocSerializedRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocServiceOrderRequestResponses = Builder<InsDocServiceOrderRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgentRequestResponses = Builder<InsDocEconomicAgentRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocRepresentativeRequestResponses = Builder<InsDocRepresentativeRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentRequestResponses = Builder<InsDocInspectionAgentRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessRequestResponses = Builder<InsDocWitnessRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationRequestResponses = Builder<InsDocTypificationRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentRequestResponses = Builder<InsDocAttachmentRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionDocument = InspectionDocumentMapper.ConvertRequestToObject(request);

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.AddAsync(inspectionDocument))
                .Verifiable();

            _service.InsertInspectionDocumentAsync(request);

            Assert.NotNull(request);
            Assert.NotNull(inspectionDocument);
            Assert.IsType<InspectionDocumentRequestResponse>(request);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void UpdateInspectionDocumentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Atualizar/Salvar o documento de fiscalização.");

            var request = Builder<InspectionDocumentRequestResponse>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.OrderServiceId = 1)
                .With(p => p.RepresentativeId = 1)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.InsDocSerializedRequestResponses = Builder<InsDocSerializedRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocServiceOrderRequestResponses = Builder<InsDocServiceOrderRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgentRequestResponses = Builder<InsDocEconomicAgentRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocRepresentativeRequestResponses = Builder<InsDocRepresentativeRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentRequestResponses = Builder<InsDocInspectionAgentRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessRequestResponses = Builder<InsDocWitnessRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationRequestResponses = Builder<InsDocTypificationRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentRequestResponses = Builder<InsDocAttachmentRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionDocument = InspectionDocumentMapper.ConvertRequestToObject(request);
            var inspectionDocumentId = request.InspectionDocumentId;

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.UpdateAsync(inspectionDocument, inspectionDocumentId))
                .Verifiable();

            _service.UpdateInspectionDocumentAsync(request);

            Assert.NotNull(request);
            Assert.NotNull(inspectionDocument);
            Assert.IsType<InspectionDocumentRequestResponse>(request);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void DeleteInspectionDocumentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Excluir o documento de fiscalização por sequencial.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = inspectionDocument.InsDocInspectionAgentList.ElementAt(0).InspectionAgentId;
            var inspectionDocumentId = inspectionDocument.InspectionDocumentId;

            var response = InspectionDocumentMapper.ConvertObjectToResponse(inspectionDocument);

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.RemoveAsync(inspectionDocument))
                .Verifiable();

            _service.DeleteInspectionDocumentAsync(inspectionAgentId, inspectionDocumentId);

            Assert.NotNull(response);
            Assert.NotNull(inspectionDocument);
            Assert.IsType<InspectionDocumentRequestResponse>(response);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Services", "InspectionDocument")]
        public void DeleteInspectionDocumentAsyncInCascate_Returns_Success()
        {
            _testOutput.WriteLine("Excluir o documento de fiscalização por sequencial.");

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.DocumentNumber = "DocumentNumber1")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "Latitude1")
                .With(p => p.Longitude = "Longitude1")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Sequential = Builder<Sequential>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .With(p => p.InsDocSerialized = Builder<InsDocSerialized>.CreateNew().Build())
                .With(p => p.InsDocServiceOrder = Builder<InsDocServiceOrder>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgent = Builder<InsDocEconomicAgent>.CreateNew().Build())
                .With(p => p.InsDocRepresentative = Builder<InsDocRepresentative>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocWitnessList = Builder<InsDocWitness>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocAttachmentList = Builder<InsDocAttachment>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocEmailList = Builder<InsDocEmail>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgent = 1;
            var response = InspectionDocumentMapper.ConvertObjectToResponse(inspectionDocument);

            _mockUoW
                .Setup(x => x.InspectionDocumentRepository.RemoveAsync(inspectionDocument))
                .Verifiable();

            _service.DeleteInspectionDocumentAsync(inspectionAgent, inspectionDocument.InspectionDocumentId);

            Assert.NotNull(response);
            Assert.NotNull(inspectionDocument);
            Assert.IsType<InspectionDocumentRequestResponse>(response);
            Assert.IsType<InspectionDocument>(inspectionDocument);
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
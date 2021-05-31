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
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.Services.UnitTests
{
    public class SequentialServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly ISequentialService _service;

        public SequentialServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new SequentialService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "Sequential")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os sequenciais.");

            var sequential = Builder<Sequential>
                .CreateListOfSize(5)
                .All()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.InspectionAgent = Builder<InspectionAgent>.CreateNew().Build())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = Task.FromResult((IEnumerable<Sequential>)sequential);

            _mockUoW
                .Setup(x => x.SequentialRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(sequential);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<SequentialRequestResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "Sequential")]
        public void GetListBySequentialAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os sequenciais por agente de fiscalização.");

            var sequential = Builder<Sequential>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.InspectionAgent = Builder<InspectionAgent>.CreateNew().Build())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = sequential.InspectionAgentId;

            _mockUoW
                .Setup(x => x.SequentialRepository.GetListBySequentialAsync(inspectionAgentId));

            var result = _service.ListBySequentialAsync(inspectionAgentId).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(sequential);
            Assert.NotNull(result);
            Assert.IsType<List<SequentialRequestResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "Sequential")]
        public void GetFindBySequentialAsync_Returns_Success()
        {
            _testOutput.WriteLine("Localizar o próximo sequencial do agente de fiscalização.");

            var sequential = Builder<Sequential>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.InspectionAgent = Builder<InspectionAgent>.CreateNew().Build())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = sequential.InspectionAgentId;

            _mockUoW
                .Setup(x => x.SequentialRepository.GetFindBySequentialAsync(inspectionAgentId));

            var result = _service.FindBySequentialAsync(inspectionAgentId);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(sequential);
            Assert.NotNull(result);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Services", "Sequential")]
        public void GetFindBySequentialInspectionAgentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Localizar o próximo sequencial do agente de fiscalização.");

            var sequential = Builder<Sequential>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.InspectionAgent = Builder<InspectionAgent>.CreateNew().Build())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = sequential.InspectionAgentId;
            var sequentialCode = sequential.SequentialCode;

            _mockUoW
                .Setup(x => x.SequentialRepository.GetFindBySequentialInspectionAgentAsync(inspectionAgentId, sequentialCode));

            var result = _service.FindBySequentialInspectionAgentAsync(inspectionAgentId, sequentialCode);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(sequential);
            Assert.NotNull(result);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Services", "Sequential")]
        public void PostSequentialAsync_Returns_Success()
        {
            _testOutput.WriteLine("Inserir o(s) sequencial(ais).");

            var sequential = Builder<Sequential>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.InspectionAgent = Builder<InspectionAgent>.CreateNew().Build())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = sequential.InspectionAgentId;
            var sequentialCode = sequential.SequentialCode;

            var response = SequentialMapper.ConvertObjectToResponse(sequential);

            _mockUoW
                .Setup(x => x.SequentialRepository.AddAsync(sequential))
                .Verifiable();

            _service.InsertSequentialAsync(inspectionAgentId, sequentialCode);

            Assert.NotNull(response);
            Assert.NotNull(sequential);
            Assert.IsType<SequentialRequestResponse>(response);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Services", "Sequential")]
        public void DeleteSequentialAsync_Returns_Success()
        {
            _testOutput.WriteLine("Excluir o(s) sequencial(ais).");

            var sequential = Builder<Sequential>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.SequentialCode = 1)
                .With(p => p.InspectionAgent = Builder<InspectionAgent>.CreateNew().Build())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var inspectionAgentId = sequential.InspectionAgentId;
            var sequentialCode = sequential.SequentialCode;

            var response = SequentialMapper.ConvertObjectToResponse(sequential);

            _mockUoW
                .Setup(x => x.SequentialRepository.RemoveAsync(sequential))
                .Verifiable();

            _service.DeleteSequentialAsync(inspectionAgentId, sequentialCode);

            Assert.NotNull(response);
            Assert.NotNull(sequential);
            Assert.IsType<SequentialRequestResponse>(response);
            Assert.IsType<Sequential>(sequential);
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
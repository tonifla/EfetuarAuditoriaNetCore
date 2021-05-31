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
    public class InspectionAgentServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IInspectionAgentService _service;

        public InspectionAgentServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new InspectionAgentService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "InspectionAgent")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os agentes de fiscalização.");

            var inspectionAgent = Builder<InspectionAgent>
                .CreateListOfSize(5)
                .All()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.Employment = "Employment1")
                .With(p => p.OrganOfOrigin = "Organ1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Registry = "Registry1")
                .With(p => p.SignatureImage = null)
                .With(p => p.SignatureDate = DateTime.Now)
                .With(p => p.Login = "Login1")
                .With(p => p.Email = "Email1")
                .With(p => p.Cpf = "11111111111")
                .With(p => p.Status = true)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.SequentialList = Builder<Sequential>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = Task.FromResult((IEnumerable<InspectionAgent>)inspectionAgent);

            _mockUoW
                .Setup(x => x.InspectionAgentRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionAgent);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<InspectionAgentResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "InspectionAgent")]
        public void GetListByInspectionAgentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os agentes de fiscalização por nome ou matrícula.");

            var inspectionAgent = Builder<InspectionAgent>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.Employment = "Employment1")
                .With(p => p.OrganOfOrigin = "Organ1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Registry = "Registry1")
                .With(p => p.SignatureImage = null)
                .With(p => p.SignatureDate = DateTime.Now)
                .With(p => p.Login = "Login1")
                .With(p => p.Email = "Email1")
                .With(p => p.Cpf = "11111111111")
                .With(p => p.Status = true)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.SequentialList = Builder<Sequential>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var name = inspectionAgent.Name;
            var registry = inspectionAgent.Registry;

            _mockUoW
                .Setup(x => x.InspectionAgentRepository.GetListByInspectionAgentAsync(name, registry));

            var result = _service.ListByInspectionAgentAsync(name, registry).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionAgent);
            Assert.NotNull(result);
            Assert.IsType<List<InspectionAgentResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "InspectionAgent")]
        public void GetListByInspectionAgentNrUfOrInspectionAgentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os agentes de fiscalização por núcleo ou agente de fiscalização.");

            var inspectionAgent = Builder<InspectionAgent>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.Employment = "Employment1")
                .With(p => p.OrganOfOrigin = "Organ1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Registry = "Registry1")
                .With(p => p.SignatureImage = null)
                .With(p => p.SignatureDate = DateTime.Now)
                .With(p => p.Login = "Login1")
                .With(p => p.Email = "Email1")
                .With(p => p.Cpf = "11111111111")
                .With(p => p.Status = true)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.SequentialList = Builder<Sequential>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var tipoNrUfOrInspectionAgent = true;
            var nrUfId = inspectionAgent.NrUfId;
            var inspectionAgentId = inspectionAgent.InspectionAgentId;
            var page = 1;

            _mockUoW
                .Setup(x => x.InspectionAgentRepository.GetListByInspectionAgentAsync(tipoNrUfOrInspectionAgent, nrUfId, inspectionAgentId, page));

            var result = _service.ListByInspectionAgentAsync(tipoNrUfOrInspectionAgent, nrUfId, inspectionAgentId, page).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionAgent);
            Assert.NotNull(result);
            Assert.IsType<List<InspectionAgentResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "InspectionAgent")]
        public void GetFindByInspectionAgentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Localizar o agente de fiscalização por email.");

            var inspectionAgent = Builder<InspectionAgent>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.Employment = "Employment1")
                .With(p => p.OrganOfOrigin = "Organ1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Registry = "Registry1")
                .With(p => p.SignatureImage = null)
                .With(p => p.SignatureDate = DateTime.Now)
                .With(p => p.Login = "Login1")
                .With(p => p.Email = "Email1")
                .With(p => p.Cpf = "11111111111")
                .With(p => p.Status = true)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.SequentialList = Builder<Sequential>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var login = inspectionAgent.Login;
            var cpf = inspectionAgent.Cpf;

            _mockUoW
                .Setup(x => x.InspectionAgentRepository.GetFindByInspectionAgentAsync(login, cpf));

            var result = _service.FindByInspectionAgentAsync(login, cpf);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(inspectionAgent);
            Assert.NotNull(result);
            Assert.IsType<InspectionAgent>(inspectionAgent);
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
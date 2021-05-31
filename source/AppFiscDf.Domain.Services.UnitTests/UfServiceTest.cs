using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
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
    public class UfServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IUfService _service;

        public UfServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new UfService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "Uf")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar as atividades.");

            var uf = Builder<Uf>
                .CreateListOfSize(5)
                .All()
                .With(p => p.UfAcronym = "UfAcronym1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.UfReference = 1)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgentList = Builder<InsDocEconomicAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = Task.FromResult((IEnumerable<Uf>)uf);

            _mockUoW
                .Setup(x => x.UfRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(uf);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<UfResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "Uf")]
        public void GetListByUfAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar as atividades por nome.");

            var uf = Builder<Uf>
                .CreateNew()
                .With(p => p.UfAcronym = "UfAcronym1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.UfReference = 1)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgentList = Builder<InsDocEconomicAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var ufAcronym = uf.UfAcronym;
            var name = uf.Name;

            _mockUoW
                .Setup(x => x.UfRepository.GetListByUfAsync(ufAcronym, name));

            var result = _service.ListByUfAsync(ufAcronym, name).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(uf);
            Assert.NotNull(result);
            Assert.IsType<List<UfResponse>>(result.ToList());
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
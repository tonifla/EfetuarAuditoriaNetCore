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
    public class EconomicAgentReducedServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IEconomicAgentReducedService _service;

        public EconomicAgentReducedServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new EconomicAgentReducedService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "EconomicAgentReduced")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os agentes econômicos (lista reduzida).");

            var economicAgentReduced = Builder<EconomicAgentReduced>
                .CreateListOfSize(5)
                .All()
                .With(p => p.EconomicAgentReducedId = "EconomicAgentId1")
                .With(p => p.InstallationCnpj = "InstallationCnpj1")
                .With(p => p.Company = "Company1")
                .With(p => p.District = "District1")
                .With(p => p.UfAcronym = "UfAcronym1")
                .Build();

            var expected = Task.FromResult((IEnumerable<EconomicAgentReduced>)economicAgentReduced);

            _mockUoW
                .Setup(x => x.EconomicAgentReducedRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(economicAgentReduced);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<EconomicAgentReducedResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "EconomicAgentReduced")]
        public void GetListByEconomicAgentReducedAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os agentes econômicos (lista reduzida) por CNPJ ou razão social.");

            var economicAgentReduced = Builder<EconomicAgentReduced>
                .CreateNew()
                .With(p => p.EconomicAgentReducedId = "EconomicAgentId1")
                .With(p => p.InstallationCnpj = "InstallationCnpj1")
                .With(p => p.Company = "Company1")
                .With(p => p.District = "District1")
                .With(p => p.UfAcronym = "UfAcronym1")
                .Build();

            var installationCnpj = economicAgentReduced.InstallationCnpj;
            var company = economicAgentReduced.Company;

            _mockUoW
                .Setup(x => x.EconomicAgentReducedRepository.GetListByEconomicAgentReducedAsync(installationCnpj, company));

            var result = _service.ListByEconomicAgentReducedAsync(installationCnpj, company).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(economicAgentReduced);
            Assert.NotNull(result);
            Assert.IsType<List<EconomicAgentReducedResponse>>(result.ToList());
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
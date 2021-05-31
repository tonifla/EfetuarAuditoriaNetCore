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
    public class EconomicAgentServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IEconomicAgentService _service;

        public EconomicAgentServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new EconomicAgentService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "EconomicAgent")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os agentes econômicos.");

            var economicAgent = Builder<EconomicAgent>
                .CreateListOfSize(5)
                .All()
                .With(p => p.EconomicAgentId = "EconomicAgentId1")
                .With(p => p.InstallationCnpj = "InstallationCnpj1")
                .With(p => p.Company = "Company1")
                .With(p => p.ZipCode = "ZipCode1")
                .With(p => p.Title = "Title1")
                .With(p => p.Address = "Address1")
                .With(p => p.Number = "Number1")
                .With(p => p.Complement = "Complement1")
                .With(p => p.Neighborhood = "Neighborhood1")
                .With(p => p.District = "District1")
                .With(p => p.State = "State1")
                .With(p => p.AuthorizationNumber = "AuthorizationNumber1")
                .With(p => p.PublicationDate = "PublicationDate1")
                .With(p => p.Status = "Status1")
                .With(p => p.InstallationType = "InstallationType1")
                .With(p => p.InstallationIdentification = "InstallationIdentification1")
                .With(p => p.ReducedCompany = "ReducedCompany1")
                .With(p => p.AdministratorCnpj = "AdministratorCnpj1")
                .With(p => p.EffectiveStartDate = "EffectiveStartDate1")
                .With(p => p.EffectiveEndDate = "EffectiveEndDate1")
                .With(p => p.UfAcronym = "UfAcronym1")
                .Build();

            var expected = Task.FromResult((IEnumerable<EconomicAgent>)economicAgent);

            _mockUoW
                .Setup(x => x.EconomicAgentRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(economicAgent);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<EconomicAgentResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "EconomicAgent")]
        public void GetListByEconomicAgentAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os agentes econômicos por CNPJ ou razão social.");

            var economicAgent = Builder<EconomicAgent>
                .CreateNew()
                .With(p => p.EconomicAgentId = "EconomicAgentId1")
                .With(p => p.InstallationCnpj = "InstallationCnpj1")
                .With(p => p.Company = "Company1")
                .With(p => p.ZipCode = "ZipCode1")
                .With(p => p.Title = "Title1")
                .With(p => p.Address = "Address1")
                .With(p => p.Number = "Number1")
                .With(p => p.Complement = "Complement1")
                .With(p => p.Neighborhood = "Neighborhood1")
                .With(p => p.District = "District1")
                .With(p => p.State = "State1")
                .With(p => p.AuthorizationNumber = "AuthorizationNumber1")
                .With(p => p.PublicationDate = "PublicationDate1")
                .With(p => p.Status = "Status1")
                .With(p => p.InstallationType = "InstallationType1")
                .With(p => p.InstallationIdentification = "InstallationIdentification1")
                .With(p => p.ReducedCompany = "ReducedCompany1")
                .With(p => p.AdministratorCnpj = "AdministratorCnpj1")
                .With(p => p.EffectiveStartDate = "EffectiveStartDate1")
                .With(p => p.EffectiveEndDate = "EffectiveEndDate1")
                .With(p => p.UfAcronym = "UfAcronym1")
                .Build();

            var installationCnpj = economicAgent.InstallationCnpj;
            var company = economicAgent.Company;

            _mockUoW
                .Setup(x => x.EconomicAgentRepository.GetListByEconomicAgentAsync(installationCnpj, company));

            var result = _service.ListByEconomicAgentAsync(installationCnpj, company).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(economicAgent);
            Assert.NotNull(result);
            Assert.IsType<List<EconomicAgentResponse>>(result.ToList());
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
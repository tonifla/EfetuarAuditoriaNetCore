using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class EconomicAgentTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public EconomicAgentTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "EconomicAgent")]
        public void EconomicAgentResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var economicAgent = Builder<EconomicAgentResponse>
                        .CreateNew()
                        .With(p => p.EconomicAgentId = "1")
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
                        .With(p => p.AuthorizationNumber = null)
                        .With(p => p.PublicationDate = null)
                        .With(p => p.Status = "Status1")
                        .With(p => p.InstallationType = null)
                        .With(p => p.InstallationIdentification = "InstallationIdentification1")
                        .With(p => p.ReducedCompany = "ReducedCompany1")
                        .With(p => p.AdministratorCnpj = "AdministratorCnpj1")
                        .With(p => p.EffectiveStartDate = "EffectiveStartDate1")
                        .With(p => p.EffectiveEndDate = "EffectiveEndDate1")
                        .With(p => p.UfAcronym = "UfAcronym1")
                        .Build();

            var expected = true;

            var result = economicAgent.EconomicAgentId == "1";

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<EconomicAgentResponse>(economicAgent);
        }

        [Fact]
        [Trait("TDD Domain", "EconomicAgent")]
        public void EconomicAgentResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var economicAgent = new EconomicAgentResponse();
            var expected = false;

            var result = economicAgent.EconomicAgentId == "1";
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<EconomicAgentResponse>(economicAgent);
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
using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class EconomicAgentReducedTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public EconomicAgentReducedTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "EconomicAgentReduced")]
        public void EconomicAgentReducedResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var economicAgentReduced = Builder<EconomicAgentReducedResponse>
                        .CreateNew()
                        .With(p => p.EconomicAgentReducedId = "1")
                        .With(p => p.InstallationCnpj = "11111111111")
                        .With(p => p.Company = "Company1")
                        .With(p => p.District = "District1")
                        .With(p => p.UfAcronym = "XX")
                        .Build();

            var expected = true;

            var result = economicAgentReduced.EconomicAgentReducedId == "1";

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<EconomicAgentReducedResponse>(economicAgentReduced);
        }

        [Fact]
        [Trait("TDD Domain", "EconomicAgentReduced")]
        public void EconomicAgentReducedResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var economicAgentReduced = new EconomicAgentReducedResponse();
            var expected = false;

            var result = economicAgentReduced.EconomicAgentReducedId == "1";
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<EconomicAgentReducedResponse>(economicAgentReduced);
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
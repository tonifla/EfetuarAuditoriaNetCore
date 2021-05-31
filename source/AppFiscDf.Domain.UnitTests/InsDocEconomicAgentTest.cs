using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Validators;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocEconomicAgentTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocEconomicAgentTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocEconomicAgent")]
        public void InsDocEconomicAgentResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocEconomicAgent = Builder<InsDocEconomicAgentRequestResponse>
                        .CreateNew()
                            .With(p => p.InspectionDocumentId = 1)
                            .With(p => p.UfReference = 1)
                            .With(p => p.ActivityId = 1)
                            .With(p => p.AuthorizationNumber = "AuthorizationNumber1")
                            .With(p => p.CpfCnpj = "11111111111")
                            .With(p => p.InspectedUnit = "InspectedUnit1")
                            .With(p => p.CompanyName = "CompanyName1")
                            .With(p => p.Name = "Name1")
                            .With(p => p.Address = "Address1")
                            .With(p => p.Neighborhood = "Neighborhood1")
                            .With(p => p.ZipCode = "ZipCode1")
                            .With(p => p.City = "City1")
                            .With(p => p.AddressComplement = "AddressComplement1")
                            .With(p => p.Block = "Block1")
                            .With(p => p.CellPhone = "CellPhone1")
                            .With(p => p.Phone = "Phone1")
                            .With(p => p.Email = "Email")
                            .With(p => p.PublicationDf = DateTime.Now)
                        .Build();

            var expected = true;

            var result = insDocEconomicAgent.InspectionDocumentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocEconomicAgentRequestResponse>(insDocEconomicAgent);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocEconomicAgent")]
        public void InsDocEconomicAgentResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocEconomicAgent = new InsDocEconomicAgentRequestResponse();
            var expected = false;

            var result = insDocEconomicAgent.InspectionDocumentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocEconomicAgentRequestResponse>(insDocEconomicAgent);
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
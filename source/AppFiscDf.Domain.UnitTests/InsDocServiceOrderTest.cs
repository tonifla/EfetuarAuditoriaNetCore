using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocServiceOrderTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocServiceOrderTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocServiceOrder")]
        public void InsDocServiceOrderResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocServiceOrder = Builder<InsDocServiceOrderRequestResponse>
                        .CreateNew()
                        .With(p => p.InspectionDocumentId = 1)
                        .With(p => p.Number = 1)
                        .With(p => p.Year = 1234)
                        .With(p => p.NrUfId = 1)
                        .With(p => p.Type = true)
                        .Build();

            var expected = true;

            var result = insDocServiceOrder.InspectionDocumentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocServiceOrderRequestResponse>(insDocServiceOrder);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocServiceOrder")]
        public void InsDocServiceOrderResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocServiceOrder = new InsDocServiceOrderRequestResponse();
            var expected = false;

            var result = insDocServiceOrder.InspectionDocumentId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocServiceOrderRequestResponse>(insDocServiceOrder);
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
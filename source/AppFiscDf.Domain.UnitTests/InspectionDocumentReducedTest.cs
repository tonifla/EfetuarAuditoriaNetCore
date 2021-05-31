using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InspectionDocumentReducedTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InspectionDocumentReducedTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InspectionDocumentReduced")]
        public void InspectionDocumentReducedResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inspectionDocumentReduced = Builder<InspectionDocumentReducedResponse>
                    .CreateNew()
                    .With(p => p.InspectionDocumentId = 1)
                    .With(p => p.SequentialCode = 123456)
                    .With(p => p.UpdateDate = DateTime.Now)
                    .Build();

            var expected = true;

            var result = inspectionDocumentReduced.InspectionDocumentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InspectionDocumentReducedResponse>(inspectionDocumentReduced);
        }

        [Fact]
        [Trait("TDD Domain", "InspectionDocumentReduced")]
        public void InspectionDocumentReducedResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var inspectionDocumentReduced = new InspectionDocumentReducedResponse();
            var expected = false;

            var result = inspectionDocumentReduced.InspectionDocumentId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InspectionDocumentReducedResponse>(inspectionDocumentReduced);
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
using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocInspectionAgentTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocInspectionAgentTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocInspectionAgent")]
        public void InsDocInspectionAgentResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocInspectionAgent = Builder<InsDocInspectionAgentRequestResponse>
                        .CreateNew()
                        .With(p => p.InspectionAgentId = 1)
                        .With(p => p.InspectionDocumentId = 1)
                        .With(p => p.Sort = 1)
                        .Build();

            var expected = true;

            var result = insDocInspectionAgent.InspectionAgentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocInspectionAgentRequestResponse>(insDocInspectionAgent);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocInspectionAgent")]
        public void InsDocInspectionAgentResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocInspectionAgent = new InsDocInspectionAgentRequestResponse();
            var expected = false;

            var result = insDocInspectionAgent.InspectionAgentId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocInspectionAgentRequestResponse>(insDocInspectionAgent);
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
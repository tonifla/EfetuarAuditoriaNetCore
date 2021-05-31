using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class SequentialTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public SequentialTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "Sequential")]
        public void SequentialRequestResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var sequential = Builder<SequentialRequestResponse>
                    .CreateNew()
                    .With(p => p.InspectionAgentId = 1)
                    .With(p => p.SequentialCode = 123456)
                    .Build();

            var expected = true;

            var result = sequential.InspectionAgentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<SequentialRequestResponse>(sequential);
        }

        [Fact]
        [Trait("TDD Domain", "Sequential")]
        public void SequentialRequestResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var sequential = new SequentialRequestResponse();
            var expected = false;

            var result = sequential.InspectionAgentId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<SequentialRequestResponse>(sequential);
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
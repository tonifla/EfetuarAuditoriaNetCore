using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InconsistenciesTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InconsistenciesTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "Inconsistencies")]
        public void InconsistenciesResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inconsistencies = Builder<Inconsistencies>
                        .CreateNew()
                        .With(p => p.Field = "Field1")
                        .With(p => p.Description = "Description1")
                        .Build();

            var expected = true;

            var result = inconsistencies.Field != null;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<Inconsistencies>(inconsistencies);
        }

        [Fact]
        [Trait("TDD Domain", "Inconsistencies")]
        public void InconsistenciesResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var inconsistencies = new Inconsistencies();
            var expected = false;

            var result = inconsistencies.Field != null;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<Inconsistencies>(inconsistencies);
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
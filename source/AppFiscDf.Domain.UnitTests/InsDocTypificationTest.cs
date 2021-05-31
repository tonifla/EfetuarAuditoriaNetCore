using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocTypificationTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocTypificationTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocTypification")]
        public void InsDocTypificationResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocTypification = Builder<InsDocTypificationRequestResponse>
                        .CreateNew()
                        .With(p => p.InsDocTypificationId = 1)
                        .With(p => p.TypificationId = 1)
                        .With(p => p.InspectionDocumentId = 1)
                        .With(p => p.JsonOutput = "JsonOutput1")
                        .With(p => p.FreeText = false)
                        .Build();

            var expected = true;

            var result = insDocTypification.InsDocTypificationId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocTypificationRequestResponse>(insDocTypification);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocTypification")]
        public void InsDocTypificationResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocTypification = new InsDocTypificationRequestResponse();
            var expected = false;

            var result = insDocTypification.InsDocTypificationId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocTypificationRequestResponse>(insDocTypification);
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
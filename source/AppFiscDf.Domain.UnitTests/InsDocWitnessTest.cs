using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocWitnessTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocWitnessTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocWitness")]
        public void InsDocWitnessResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocWitness = Builder<InsDocWitnessRequestResponse>
                        .CreateNew()
                        .With(p => p.InsDocWitnessId = 1)
                        .With(p => p.Name = "Name1")
                        .With(p => p.Document = "Document1")
                        .With(p => p.Employment = "Employment1")
                        .With(p => p.SignatureDate = DateTime.Now)
                        .With(p => p.SignatureImage = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE"))
                        .Build();

            var expected = true;

            var result = insDocWitness.InsDocWitnessId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocWitnessRequestResponse>(insDocWitness);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocWitness")]
        public void InsDocWitnessResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocWitness = new InsDocWitnessRequestResponse();
            var expected = false;

            var result = insDocWitness.InsDocWitnessId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocWitnessRequestResponse>(insDocWitness);
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
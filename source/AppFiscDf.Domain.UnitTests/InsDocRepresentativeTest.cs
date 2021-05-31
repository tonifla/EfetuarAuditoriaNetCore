using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocRepresentativeTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocRepresentativeTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocRepresentative")]
        public void InsDocRepresentativeResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocRepresentative = Builder<InsDocRepresentativeRequestResponse>
                        .CreateNew()
                        .With(p => p.InspectionDocumentId = 1)
                        .With(p => p.Name = "Name1")
                        .With(p => p.Document = "Document1")
                        .With(p => p.Employment = "Employment1")
                        .With(p => p.SignatureDate = DateTime.Now)
                        .With(p => p.SignatureImage = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE"))
                        .Build();

            var expected = true;

            var result = insDocRepresentative.InspectionDocumentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocRepresentativeRequestResponse>(insDocRepresentative);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocRepresentative")]
        public void InsDocRepresentativeResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocRepresentative = new InsDocRepresentativeRequestResponse();
            var expected = false;

            var result = insDocRepresentative.InspectionDocumentId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocRepresentativeRequestResponse>(insDocRepresentative);
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
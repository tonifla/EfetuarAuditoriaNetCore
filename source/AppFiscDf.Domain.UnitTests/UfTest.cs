using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class UfTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public UfTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "Uf")]
        public void Uf_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var uf = new Uf();
            var expected = false;

            var result = uf.UfAcronym == "XX";
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<Uf>(uf);
        }

        [Fact]
        [Trait("TDD Domain", "Uf")]
        public void Uf_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var uf = Builder<Uf>
                .CreateNew()
                .With(p => p.UfAcronym = "XX")
                .With(p => p.NrUfId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.UfReference = 1)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgentList = Builder<InsDocEconomicAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = uf.UfAcronym == "XX";

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<Uf>(uf);
        }

        [Fact]
        [Trait("TDD Domain", "Uf")]
        public void UfResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var uf = Builder<UfResponse>
                        .CreateNew()
                        .With(p => p.UfAcronym = "XX")
                        .With(p => p.NrUfId = 1)
                        .With(p => p.Name = "Name1")
                        .With(p => p.UfReference = 1)
                        .Build();

            var expected = true;

            var result = uf.UfAcronym == "XX";

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<UfResponse>(uf);
        }

        [Fact]
        [Trait("TDD Domain", "Uf")]
        public void UfResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var uf = new UfResponse();
            var expected = false;

            var result = uf.UfAcronym == "XX";
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<UfResponse>(uf);
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
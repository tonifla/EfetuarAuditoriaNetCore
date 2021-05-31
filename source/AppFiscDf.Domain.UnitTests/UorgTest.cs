using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class UorgTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public UorgTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "Uorg")]
        public void Uorg_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var uorg = new Uorg();
            var expected = false;

            var result = uorg.UorgId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<Uorg>(uorg);
        }

        [Fact]
        [Trait("TDD Domain", "Uorg")]
        public void Uorg_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var uorg = Builder<Uorg>
                .CreateNew()
                .With(p => p.UorgId = 1)
                .With(p => p.Acronym = "Acronym1")
                .With(p => p.Name = "Name1")
                .With(p => p.InspectionProcedureList = Builder<InspectionProcedure>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = uorg.UorgId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<Uorg>(uorg);
        }

        [Fact]
        [Trait("TDD Domain", "Uorg")]
        public void UorgResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var uorg = Builder<UorgResponse>
                    .CreateNew()
                    .With(p => p.UorgId = 1)
                    .With(p => p.Acronym = "XX")
                    .With(p => p.Name = "Name1")
                    .With(p => p.InspectionProcedureList = Builder<InspectionProcedureResponse>.CreateListOfSize(2).All().Build().ToList())
                    .Build();

            var expected = true;

            var result = uorg.UorgId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<UorgResponse>(uorg);
        }

        [Fact]
        [Trait("TDD Domain", "Uorg")]
        public void UorgResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var uorg = new UorgResponse();
            var expected = false;

            var result = uorg.UorgId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<UorgResponse>(uorg);
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
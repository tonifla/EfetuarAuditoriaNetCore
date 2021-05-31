using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class JudgmentSectorTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public JudgmentSectorTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "JudgmentSector")]
        public void JudgmentSector_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var judgmentSector = new JudgmentSector();
            var expected = false;

            var result = judgmentSector.JudgmentSectorId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<JudgmentSector>(judgmentSector);
        }

        [Fact]
        [Trait("TDD Domain", "JudgmentSector")]
        public void JudgmentSector_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var judgmentSector = Builder<JudgmentSector>
                .CreateNew()
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Acronym = "Acronym1")
                .With(p => p.Name = "Name1")
                .With(p => p.Address = "Address1")
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = judgmentSector.JudgmentSectorId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<JudgmentSector>(judgmentSector);
        }

        [Fact]
        [Trait("TDD Domain", "JudgmentSector")]
        public void JudgmentSectorResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var judgmentSector = Builder<JudgmentSectorRequestResponse>
                        .CreateNew()
                        .With(p => p.JudgmentSectorId = 1)
                        .With(p => p.Acronym = "XX")
                        .With(p => p.Name = "Name1")
                        .With(p => p.Address = "Address1")
                        .Build();

            var expected = true;

            var result = judgmentSector.JudgmentSectorId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<JudgmentSectorRequestResponse>(judgmentSector);
        }

        [Fact]
        [Trait("TDD Domain", "JudgmentSector")]
        public void JudgmentSectorResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var judgmentSector = new JudgmentSectorRequestResponse();
            var expected = false;

            var result = judgmentSector.JudgmentSectorId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<JudgmentSectorRequestResponse>(judgmentSector);
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
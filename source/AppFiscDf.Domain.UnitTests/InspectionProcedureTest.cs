using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InspectionProcedureTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InspectionProcedureTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InspectionProcedure")]
        public void InspectionProcedure_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var inspectionProcedure = new InspectionProcedure();
            var expected = false;

            var result = inspectionProcedure.InspectionProcedureId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InspectionProcedure>(inspectionProcedure);
        }

        [Fact]
        [Trait("TDD Domain", "InspectionProcedure")]
        public void InspectionProcedure_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inspectionProcedure = Builder<InspectionProcedure>
                .CreateNew()
                .With(p => p.InspectionProcedureId = 1)
                .With(p => p.UorgId = 1)
                .With(p => p.Text = "Text1")
                .With(p => p.Sort = 1)
                .With(p => p.Uorg = Builder<Uorg>.CreateNew().Build())
                .With(p => p.TypificationList = Builder<Typification>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = inspectionProcedure.InspectionProcedureId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InspectionProcedure>(inspectionProcedure);
        }

        [Fact]
        [Trait("TDD Domain", "InspectionProcedure")]
        public void InspectionProcedureResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inspectionProcedure = Builder<InspectionProcedureResponse>
                        .CreateNew()
                        .With(p => p.InspectionProcedureId = 1)
                        .With(p => p.UorgId = 1)
                        .With(p => p.Text = "Text1")
                        .With(p => p.Sort = 1)
                        .With(p => p.TypificationList = Builder<TypificationResponse>.CreateListOfSize(2).All().Build().ToList())
                        .Build();

            var expected = true;

            var result = inspectionProcedure.InspectionProcedureId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InspectionProcedureResponse>(inspectionProcedure);
        }

        [Fact]
        [Trait("TDD Domain", "InspectionProcedure")]
        public void InspectionProcedureResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var inspectionProcedure = new InspectionProcedureResponse();
            var expected = false;

            var result = inspectionProcedure.InspectionProcedureId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InspectionProcedureResponse>(inspectionProcedure);
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
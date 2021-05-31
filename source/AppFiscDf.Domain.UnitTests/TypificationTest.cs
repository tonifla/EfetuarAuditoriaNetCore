using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class TypificationTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public TypificationTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "Typification")]
        public void Typification_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var typification = new Typification();
            var expected = false;

            var result = typification.TypificationId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<Typification>(typification);
        }

        [Fact]
        [Trait("TDD Domain", "Typification")]
        public void Typification_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var typification = Builder<Typification>
                .CreateNew()
                .With(p => p.TypificationId = 1)
                .With(p => p.ActivityId = 1)
                .With(p => p.InspectionProcedureId = 1)
                .With(p => p.Title = "Title1")
                .With(p => p.Model = "Model1")
                .With(p => p.JsonInput = "JsonInput1")
                .With(p => p.HTMLInput = "HTMLInput1")
                .With(p => p.Activity = Builder<Activity>.CreateNew().Build())
                .With(p => p.InspectionProcedure = Builder<InspectionProcedure>.CreateNew().Build())
                .With(p => p.InsDocTypificationList = Builder<InsDocTypification>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = typification.TypificationId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<Typification>(typification);
        }

        [Fact]
        [Trait("TDD Domain", "Typification")]
        public void TypificationResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var typification = Builder<TypificationResponse>
                        .CreateNew()
                        .With(p => p.TypificationId = 1)
                        .With(p => p.ActivityId = 1)
                        .With(p => p.InspectionProcedureId = 1)
                        .With(p => p.Title = "Title1")
                        .With(p => p.Model = "Model1")
                        .With(p => p.JsonInput = "JsonInput1")
                        .With(p => p.HTMLInput = "HTMLInput1")
                        .With(p => p.Activity = Builder<ActivityResponse>.CreateNew().Build())
                        .With(p => p.InspectionProcedure = Builder<InspectionProcedureResponse>.CreateNew().Build())
                        .With(p => p.InsDocTypificationList = Builder<InsDocTypificationRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                        .Build();

            var expected = true;

            var result = typification.TypificationId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<TypificationResponse>(typification);
        }

        [Fact]
        [Trait("TDD Domain", "Typification")]
        public void TypificationResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var typification = new TypificationResponse();
            var expected = false;

            var result = typification.TypificationId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<TypificationResponse>(typification);
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
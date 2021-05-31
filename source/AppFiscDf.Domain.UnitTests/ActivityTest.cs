using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class ActivityTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public ActivityTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "Activity")]
        public void Activity_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var activity = new Activity();
            var expected = false;

            var result = activity.ActivityId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<Activity>(activity);
        }

        [Fact]
        [Trait("TDD Domain", "Activity")]
        public void Activity_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var activity = Builder<Activity>
                .CreateNew()
                .With(p => p.ActivityId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.InsDocEconomicAgentList = Builder<InsDocEconomicAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.TypificationList = Builder<Typification>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = activity.ActivityId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<Activity>(activity);
        }

        [Fact]
        [Trait("TDD Domain", "Activity")]
        public void ActivityResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var activity = Builder<ActivityResponse>
                    .CreateNew()
                    .With(p => p.ActivityId = 1)
                    .With(p => p.Name = "Name1")
                    .Build();

            var expected = true;

            var result = activity.ActivityId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<ActivityResponse>(activity);
        }

        [Fact]
        [Trait("TDD Domain", "Activity")]
        public void ActivityResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var activity = new ActivityResponse();
            var expected = false;

            var result = activity.ActivityId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<ActivityResponse>(activity);
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
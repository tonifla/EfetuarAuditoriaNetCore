using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using FizzWare.NBuilder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.Services.UnitTests
{
    public class ActivityServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IActivityService _service;

        public ActivityServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new ActivityService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "Activity")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar as atividades.");

            var activity = Builder<Activity>
                .CreateListOfSize(5)
                .All()
                .With(p => p.ActivityId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.InsDocEconomicAgentList = Builder<InsDocEconomicAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.TypificationList = Builder<Typification>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = Task.FromResult((IEnumerable<Activity>)activity);

            _mockUoW
                .Setup(x => x.ActivityRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(activity);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<ActivityResponse>>(result.ToList());
        }

        [Fact]
        [Trait("TDD Services", "Activity")]
        public void GetListByActivityAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar as atividades por nome.");

            var activity = Builder<Activity>
                .CreateNew()
                .With(p => p.ActivityId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.InsDocEconomicAgentList = Builder<InsDocEconomicAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.TypificationList = Builder<Typification>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var name = activity.Name;

            _mockUoW
                .Setup(x => x.ActivityRepository.GetListByActivityAsync(name));

            var result = _service.ListByActivityAsync(name).Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(activity);
            Assert.NotNull(result);
            Assert.IsType<List<ActivityResponse>>(result.ToList());
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }
    }
}
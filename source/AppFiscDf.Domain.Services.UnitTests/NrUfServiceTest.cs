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
    public class NrUfServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly INrUfService _service;

        public NrUfServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new NrUfService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "NrUf")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os núcleos regionais.");

            var nrUf = Builder<NrUf>
                .CreateListOfSize(5)
                .All()
                .With(p => p.NrUfId = 1)
                .With(p => p.Acronym = "Acronym1")
                .With(p => p.Name = "Name1")
                .With(p => p.Responsible = "Responsible1")
                .With(p => p.SubstituteResponsible = "SubstituteResponsible1")
                .With(p => p.Address = "Address1")
                .With(p => p.PlanningEmail = "PlanningEmail1")
                .With(p => p.ResultEmail = "ResultEmail1")
                .With(p => p.InspectionAgentList = Builder<InspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.UfList = Builder<Uf>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = Task.FromResult((IEnumerable<NrUf>)nrUf);

            _mockUoW
                .Setup(x => x.NrUfRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(nrUf);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<NrUfResponse>>(result.ToList());
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
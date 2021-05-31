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
    public class JudgmentSectorServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IJudgmentSectorService _service;

        public JudgmentSectorServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new JudgmentSectorService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "JudgmentSector")]
        public void GetListAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar os setores de julgamento de processo de inspeção.");

            var judgmentSector = Builder<JudgmentSector>
                .CreateListOfSize(5)
                .All()
                .With(p => p.JudgmentSectorId = 1)
                .With(p => p.Acronym = "Acronym1")
                .With(p => p.Name = "Name1")
                .With(p => p.Address = "Address1")
                .With(p => p.InspectionDocumentList = Builder<InspectionDocument>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = Task.FromResult((IEnumerable<JudgmentSector>)judgmentSector);

            _mockUoW
                .Setup(x => x.JudgmentSectorRepository.GetListAsync())
                .Returns(expected);

            var result = _service.ListAsync().Result;

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(judgmentSector);
            Assert.NotNull(result);
            Assert.Equal(expected.Result.Count().ToString(), result.Count().ToString());
            Assert.IsType<List<JudgmentSectorRequestResponse>>(result.ToList());
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
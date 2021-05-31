using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using FizzWare.NBuilder;
using Moq;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.Services.UnitTests
{
    public class UorgServiceTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private readonly Mock<IUnitOfWork> _mockUoW;
        private readonly IUorgService _service;

        public UorgServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _mockUoW = new Mock<IUnitOfWork>();
            _service = new UorgService(_mockUoW.Object);
        }

        [Fact]
        [Trait("TDD Services", "Uorg")]
        public void GetFindByUorgAsync_Returns_Success()
        {
            _testOutput.WriteLine("Listar a Uorg por sigla.");

            var uorg = Builder<Uorg>
                .CreateNew()
                .With(p => p.UorgId = 1)
                .With(p => p.Acronym = "Acronym1")
                .With(p => p.Name = "Name1")
                .With(p => p.InspectionProcedureList = Builder<InspectionProcedure>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var acronym = uorg.Acronym;

            _mockUoW
                .Setup(x => x.UorgRepository.GetFindByUorgAsync(acronym));

            var result = _service.FindByUorgAsync(acronym);

            _testOutput.WriteLine(result.ToString());

            Assert.NotNull(uorg);
            Assert.NotNull(result);
            Assert.IsType<Uorg>(uorg);
        }

        [Fact]
        [Trait("TDD Services", "Uorg")]
        public void GetFindByUorgAsync_Returns_False()
        {
            _testOutput.WriteLine("Não listar a Uorg por sigla.");

            Uorg uorg = null;
            var acronym = "";

            _mockUoW
                .Setup(x => x.UorgRepository.GetFindByUorgAsync(acronym));

            var result = _service.FindByUorgAsync(acronym);

            _testOutput.WriteLine(result.ToString());

            Assert.Null(uorg);
            Assert.Empty(acronym);
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
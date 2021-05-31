using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class NrUfTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public NrUfTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "NrUf")]
        public void NrUf_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var nrUf = new NrUf();
            var expected = false;

            var result = nrUf.NrUfId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<NrUf>(nrUf);
        }

        [Fact]
        [Trait("TDD Domain", "NrUf")]
        public void NrUf_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var nrUf = Builder<NrUf>
                .CreateNew()
                .With(p => p.NrUfId = 1)
                .With(p => p.Acronym = "Acronym1")
                .With(p => p.Name = "Name1")
                .With(p => p.Responsible = "Responsible1")
                .With(p => p.SubstituteResponsible = "SubstituteResponsible1")
                .With(p => p.Address = "Address1")
                .With(p => p.PlanningEmail = "PlanningEmail1")
                .With(p => p.ResultEmail = "ResultEmail1")
                .With(p => p.InspectionAgentList = Builder<InspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.InsDocServiceOrderList = Builder<InsDocServiceOrder>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.UfList = Builder<Uf>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = nrUf.NrUfId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<NrUf>(nrUf);
        }

        [Fact]
        [Trait("TDD Domain", "NrUf")]
        public void NrUfResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var nrUf = Builder<NrUfResponse>
                        .CreateNew()
                        .With(p => p.NrUfId = 1)
                        .With(p => p.Acronym = "XX")
                        .With(p => p.Name = "Name1")
                        .With(p => p.Responsible = "Responsible1")
                        .With(p => p.SubstituteResponsible = "SubstituteResponsible1")
                        .With(p => p.Address = "Address1")
                        .With(p => p.PlanningEmail = "PlanningEmail1")
                        .With(p => p.ResultEmail = "ResultEmail1")
                        .With(p => p.UfResponses = Builder<UfResponse>.CreateListOfSize(2).All().Build().ToList())
                        .Build();

            var expected = true;

            var result = nrUf.NrUfId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<NrUfResponse>(nrUf);
        }

        [Fact]
        [Trait("TDD Domain", "NrUf")]
        public void NrUfResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var nrUf = new NrUfResponse();
            var expected = false;

            var result = nrUf.NrUfId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<NrUfResponse>(nrUf);
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
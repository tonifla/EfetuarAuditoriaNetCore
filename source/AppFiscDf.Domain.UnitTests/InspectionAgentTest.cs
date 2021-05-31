using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InspectionAgentTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InspectionAgentTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InspectionAgent")]
        public void InspectionAgent_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var inspectionAgent = new InspectionAgent();
            var expected = false;

            var result = inspectionAgent.InspectionAgentId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InspectionAgent>(inspectionAgent);
        }

        [Fact]
        [Trait("TDD Domain", "InspectionAgent")]
        public void InspectionAgent_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inspectionAgent = Builder<InspectionAgent>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.Employment = "Employment1")
                .With(p => p.OrganOfOrigin = "OrganOfOrigin1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Registry = "Registry1")
                .With(p => p.SignatureImage = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE"))
                .With(p => p.SignatureDate = DateTime.Now)
                .With(p => p.Login = "Login1")
                .With(p => p.Email = "Email1")
                .With(p => p.Cpf = "Cpf1")
                .With(p => p.Status = true)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentList = Builder<InsDocInspectionAgent>.CreateListOfSize(2).All().Build().ToList())
                .With(p => p.SequentialList = Builder<Sequential>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = inspectionAgent.InspectionAgentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InspectionAgent>(inspectionAgent);
        }

        [Fact]
        [Trait("TDD Domain", "InspectionAgent")]
        public void InspectionAgentResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inspectionAgent = Builder<InspectionAgentResponse>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.Name = "Name1")
                .With(p => p.Employment = "Employment1")
                .With(p => p.Organ = "OrganOfOrigin1")
                .With(p => p.NrUfId = 1)
                .With(p => p.Registry = "Registry1")
                .With(p => p.SignatureImage = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE"))
                .With(p => p.SignatureDate = DateTime.Now)
                .With(p => p.Login = "Login1")
                .With(p => p.Email = "Email1")
                .With(p => p.Cpf = "Cpf1")
                .With(p => p.Status = true)
                .With(p => p.SequentialRequestResponses = Builder<SequentialRequestResponse>.CreateListOfSize(2).All().Build().ToList())
                .Build();

            var expected = true;

            var result = inspectionAgent.InspectionAgentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InspectionAgentResponse>(inspectionAgent);
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
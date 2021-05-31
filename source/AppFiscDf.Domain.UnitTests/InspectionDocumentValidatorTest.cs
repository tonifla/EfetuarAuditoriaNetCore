using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Validators;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InspectionDocumentValidatorTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InspectionDocumentValidatorTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain Validator", "InspectionDocument")]
        public void InspectionDocumentValidator_PostWithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var inspectionDocumentValidator = new InspectionDocumentPostValidator(HttpMethods.Post);
            var inspectionDocument = Builder<InspectionDocumentRequestResponse>
                .CreateNew()
                .With(p => p.InsDocSerializedRequestResponses = Builder<InsDocSerializedRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocServiceOrderRequestResponses = Builder<InsDocServiceOrderRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgentRequestResponses = Builder<InsDocEconomicAgentRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocRepresentativeRequestResponses = Builder<InsDocRepresentativeRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentRequestResponses = Builder<InsDocInspectionAgentRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .With(p => p.InsDocWitnessRequestResponses = Builder<InsDocWitnessRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .With(p => p.InsDocTypificationRequestResponses = Builder<InsDocTypificationRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .With(p => p.InsDocAttachmentRequestResponses = Builder<InsDocAttachmentRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .Build();
            var expected = false;

            inspectionDocument.InsDocAttachmentRequestResponses.ElementAt(0).AttachmentFile = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABA");

            var result = inspectionDocumentValidator.Validate(inspectionDocument);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InspectionDocumentRequestResponse>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InspectionDocument")]
        public void InspectionDocumentValidator_PostWithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inspectionDocumentValidator = new InspectionDocumentPostValidator(HttpMethods.Post);
            var inspectionDocument = Builder<InspectionDocumentRequestResponse>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 123456)
                .With(p => p.DocumentNumber = "1890002051900001")
                .With(p => p.Latitude = "3565636.656")
                .With(p => p.Longitude = "234234.4546")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = DateTime.Now)
                .With(p => p.InsDocSerializedRequestResponses = Builder<InsDocSerializedRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocServiceOrderRequestResponses = Builder<InsDocServiceOrderRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocEconomicAgentRequestResponses = Builder<InsDocEconomicAgentRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocRepresentativeRequestResponses = Builder<InsDocRepresentativeRequestResponse>.CreateNew().Build())
                .With(p => p.InsDocInspectionAgentRequestResponses = Builder<InsDocInspectionAgentRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .With(p => p.InsDocWitnessRequestResponses = Builder<InsDocWitnessRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .With(p => p.InsDocTypificationRequestResponses = Builder<InsDocTypificationRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .With(p => p.InsDocAttachmentRequestResponses = Builder<InsDocAttachmentRequestResponse>.CreateListOfSize(1).All().Build().ToList())
                .Build();

            inspectionDocument.InsDocEconomicAgentRequestResponses.UfReference = 1;
            inspectionDocument.InsDocEconomicAgentRequestResponses.CpfCnpj = "27993968000193";
            inspectionDocument.InsDocEconomicAgentRequestResponses.Email = "a@a.com";
            inspectionDocument.InsDocRepresentativeRequestResponses.SignatureImage = Encoding.ASCII.GetBytes("iVBORw0KGgoAAAANSUhEUgAAAA");
            inspectionDocument.InsDocWitnessRequestResponses.ElementAt(0).SignatureImage = Encoding.ASCII.GetBytes("iVBORw0KGgoAAAANSUhEUgAAAA");
            inspectionDocument.InsDocAttachmentRequestResponses.ElementAt(0).Name = "zzzzz.jpg";
            inspectionDocument.InsDocAttachmentRequestResponses.ElementAt(0).AttachmentFile = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABA");

            var expected = true;

            var result = inspectionDocumentValidator.Validate(inspectionDocument);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.True(result.IsValid);
            Assert.IsType<InspectionDocumentRequestResponse>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InspectionDocument")]
        public void InspectionDocumentValidator_DeleteWithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var inspectionDocumentValidator = new InspectionDocumentDeleteValidator(HttpMethods.Delete);
            var inspectionDocument = new InspectionDocument();
            var expected = false;

            var result = inspectionDocumentValidator.Validate(inspectionDocument);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<InspectionDocument>(inspectionDocument);
        }

        [Fact]
        [Trait("TDD Domain Validator", "InspectionDocument")]
        public void InspectionDocumentValidator_DeleteWithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var inspectionDocumentValidator = new InspectionDocumentDeleteValidator(HttpMethods.Delete);

            var inspectionDocument = Builder<InspectionDocument>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.SequentialCode = 123456)
                .With(p => p.DocumentNumber = "1890002051900001")
                .With(p => p.Finished = true)
                .With(p => p.Latitude = "3565636.656")
                .With(p => p.Longitude = "234234.4546")
                .With(p => p.StartDate = DateTime.Now)
                .With(p => p.UpdateDate = DateTime.Now)
                .With(p => p.EndDate = null)
                .With(p => p.JudgmentSectorId = 1)
                .Build();

            var insDocSerialized = Builder<InsDocSerialized>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.JsonString = "zzzzz")
                .Build();

            inspectionDocument.InsDocSerialized = insDocSerialized;

            var insDocServiceOrder = Builder<InsDocServiceOrder>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Number = 1)
                .With(p => p.Year = 2021)
                .With(p => p.NrUfId = 1)
                .With(p => p.Type = true)
                .With(p => p.NrUf = Builder<NrUf>.CreateNew().Build())
                .Build();

            inspectionDocument.InsDocServiceOrder = insDocServiceOrder;

            var insDocEconomicAgent = Builder<InsDocEconomicAgent>
                .CreateNew()
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.UfReference = 1)
                .With(p => p.ActivityId = 10)
                .With(p => p.AuthorizationNumber = "1111111111")
                .With(p => p.CpfCnpj = "27993968000193")
                .With(p => p.InspectedUnit = "1")
                .With(p => p.CompanyName = "CompanyName1")
                .With(p => p.Name = "Name1")
                .With(p => p.Address = "Address1")
                .With(p => p.Neighborhood = "Neighborhood1")
                .With(p => p.ZipCode = "ZipCode1")
                .With(p => p.City = "City1")
                .With(p => p.AddressComplement = "AddressComplement1")
                .With(p => p.Block = "Block1")
                .With(p => p.CellPhone = "999999999")
                .With(p => p.Phone = "22222222")
                .With(p => p.Email = "eireli@gmail.com")
                .With(p => p.PublicationDf = DateTime.Now)
                .With(p => p.Activity = Builder<Activity>.CreateNew().Build())
                .With(p => p.Uf = Builder<Uf>.CreateNew().Build())
                .Build();

            inspectionDocument.InsDocEconomicAgent = insDocEconomicAgent;

            var insDocRepresentative = Builder<InsDocRepresentative>
                    .CreateNew()
                    .With(p => p.InspectionDocumentId = 1)
                    .With(p => p.Name = "zzzzz")
                    .With(p => p.Document = "123123123123")
                    .With(p => p.Employment = "zzzzz")
                    .With(p => p.SignatureDate = DateTime.Now)
                    .With(p => p.SignatureImage = Encoding.ASCII.GetBytes("iVBORw0KGgoAAAANSUhEUgAAAA"))
                    .Build();

            inspectionDocument.InsDocRepresentative = insDocRepresentative;

            var insDocInspectionAgent = Builder<InsDocInspectionAgent>
                .CreateNew()
                .With(p => p.InspectionAgentId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Sort = 1)
                .With(p => p.InspectionAgent = Builder<InspectionAgent>.CreateNew().Build())
                .With(p => p.InspectionDocument = Builder<InspectionDocument>.CreateNew().Build())
                .Build();

            inspectionDocument.InsDocInspectionAgentList.Add(insDocInspectionAgent);

            var insDocWitness = Builder<InsDocWitness>
                .CreateNew()
                .With(p => p.InsDocWitnessId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Name = "zzzzz")
                .With(p => p.Document = "123123123123")
                .With(p => p.Employment = "zzzzz")
                .With(p => p.SignatureDate = DateTime.Now)
                .With(p => p.SignatureImage = Encoding.ASCII.GetBytes("iVBORw0KGgoAAAANSUhEUgAAAA"))
                .Build();

            inspectionDocument.InsDocWitnessList.Add(insDocWitness);

            var insDocTypification = Builder<InsDocTypification>
                .CreateNew()
                .With(p => p.InsDocTypificationId = 1)
                .With(p => p.TypificationId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.JsonOutput = "zzzzz")
                .With(p => p.FreeText = false)
                .With(p => p.Typification = Builder<Typification>.CreateNew().Build())
                .Build();

            inspectionDocument.InsDocTypificationList.Add(insDocTypification);

            var insDocAttachment = Builder<InsDocAttachment>
                .CreateNew()
                .With(p => p.InsDocAttachmentId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Name = "zzzzz.jpg")
                .With(p => p.AttachmentFile = Encoding.ASCII.GetBytes("/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQE"))
                .With(p => p.AttachmentDate = DateTime.Now)
                .Build();

            inspectionDocument.InsDocAttachmentList.Add(insDocAttachment);

            var expected = true;

            var result = inspectionDocumentValidator.Validate(inspectionDocument);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.True(result.IsValid);
            Assert.IsType<InspectionDocument>(inspectionDocument);
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
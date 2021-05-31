﻿using AppFiscDf.Application.Model.RequestResponse;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocSerializedTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocSerializedTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocSerialized")]
        public void InsDocSerializedResponse_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocSerialized = Builder<InsDocSerializedRequestResponse>
                    .CreateNew()
                    .With(p => p.InspectionDocumentId = 1)
                    .With(p => p.JsonString = "JsonString1")
                    .Build();

            var expected = true;

            var result = insDocSerialized.InspectionDocumentId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocSerializedRequestResponse>(insDocSerialized);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocSerialized")]
        public void InsDocSerializedResponse_WithData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocSerialized = new InsDocSerializedRequestResponse();
            var expected = false;

            var result = insDocSerialized.InspectionDocumentId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocSerializedRequestResponse>(insDocSerialized);
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
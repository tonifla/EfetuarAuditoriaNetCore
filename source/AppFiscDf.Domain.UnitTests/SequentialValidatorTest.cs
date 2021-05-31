using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Validators;
using Microsoft.AspNetCore.Http;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class SequentialValidatorTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public SequentialValidatorTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_PostWithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var sequentialValidator = new SequentialPostValidator(HttpMethods.Post);
            var sequential = new Sequential();
            var expected = false;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_PostWithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var sequentialValidator = new SequentialPostValidator(HttpMethods.Post);
            var sequential = new Sequential
            {
                InspectionAgentId = 1,
                SequentialCode = 123456
            };

            var expected = true;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.True(result.IsValid);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_PostInspectionAgentIdWithTextEmpty_False()
        {
            _testOutput.WriteLine("Código do agente de fiscalização não foi informado.");

            var sequentialValidator = new SequentialPostValidator(HttpMethods.Post);
            var sequential = new Sequential();

            var expected = false;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_PostSequentialCodeWithTextEmpty_False()
        {
            _testOutput.WriteLine("Sequencial não foi informado.");

            var sequentialValidator = new SequentialPostValidator(HttpMethods.Post);
            var sequential = new Sequential();
            var expected = false;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_DeleteWithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var sequentialValidator = new SequentialDeleteValidator(HttpMethods.Delete);
            var sequential = new Sequential();
            var expected = false;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_DeleteWithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var sequentialValidator = new SequentialDeleteValidator(HttpMethods.Delete);
            var sequential = new Sequential
            {
                InspectionAgentId = 1,
                SequentialCode = 123456
            };

            var expected = true;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.True(result.IsValid);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_DeleteInspectionAgentIdWithTextEmpty_False()
        {
            _testOutput.WriteLine("Código do agente de fiscalização não foi informado.");

            var sequentialValidator = new SequentialDeleteValidator(HttpMethods.Delete);
            var sequential = new Sequential();

            var expected = false;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<Sequential>(sequential);
        }

        [Fact]
        [Trait("TDD Domain Validator", "Sequential")]
        public void SequentialValidator_DeleteSequentialCodeWithTextEmpty_False()
        {
            _testOutput.WriteLine("Sequencial não foi informado.");

            var sequentialValidator = new SequentialDeleteValidator(HttpMethods.Delete);
            var sequential = new Sequential();
            var expected = false;

            var result = sequentialValidator.Validate(sequential);
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result.IsValid);
            Assert.False(result.IsValid);
            Assert.IsType<Sequential>(sequential);
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
using AppFiscDf.Domain.Entities;
using FizzWare.NBuilder;
using System;
using Xunit;
using Xunit.Abstractions;

namespace AppFiscDf.Domain.UnitTests
{
    public class InsDocEmailTest : IDisposable
    {
        private readonly ITestOutputHelper _testOutput;
        private bool _disposed = false;

        public InsDocEmailTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        [Trait("TDD Domain", "InsDocEmail")]
        public void InsDocEmail_WithoutData_False()
        {
            _testOutput.WriteLine("Não são todos os dados que estão preenchidos.");

            var insDocEmail = new InsDocEmail();
            var expected = false;

            var result = insDocEmail.InsDocEmailId == 1;
            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.False(result);
            Assert.IsType<InsDocEmail>(insDocEmail);
        }

        [Fact]
        [Trait("TDD Domain", "InsDocEmail")]
        public void InsDocEmail_WithData_True()
        {
            _testOutput.WriteLine("Todos os dados estão preenchidos.");

            var insDocEmail = Builder<InsDocEmail>
                .CreateNew()
                .With(p => p.InsDocEmailId = 1)
                .With(p => p.InspectionDocumentId = 1)
                .With(p => p.Sender = "Sender1")
                .With(p => p.Recipients = "Recipients1")
                .With(p => p.Subject = "Subject1")
                .With(p => p.Content = "Content1")
                .With(p => p.TypeMessage = ResponseType.SUCESSO)
                .Build();

            var expected = true;

            var result = insDocEmail.InsDocEmailId == 1;

            _testOutput.WriteLine(result.ToString());

            Assert.Equal(expected, result);
            Assert.True(result);
            Assert.IsType<InsDocEmail>(insDocEmail);
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
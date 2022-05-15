using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Cancellation.Implementations;

namespace Tests
{
    [TestClass]
    public class CancellationManagerTests
    {
        private CancellationManager sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
            isError = false;
        }

        [TestMethod]
        public void TokenDoesntThrow()
        {
            try
            {
                var output = sut.Token;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CancelDoesntThrow()
        {
            try
            {
                sut.Cancel();
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CancelIsCancellationRequestedTrue()
        {
            var token = sut.Token;
            sut.Cancel();
            var result = token.IsCancellationRequested;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CancelIsCancellationRequestedFalseAfterCancel()
        {
            sut.Cancel();
            var token = sut.Token;
            Assert.IsFalse(token.IsCancellationRequested);
        }
    }
}

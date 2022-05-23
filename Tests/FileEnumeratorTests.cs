using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WigeDev.Copier.Implementations;

namespace Tests
{
    [TestClass]
    public class FileEnumeratorTests
    {
        private FileEnumerator sut;
        private bool isError;
        private FakeCancellationManager cancellationManager;
        private FakeSettingsManager settingsManager;

        [TestInitialize]
        public void Initialize()
        {
            sut = new(settingsManager);
            isError = false;
            cancellationManager = new();
        }

        [TestMethod]
        public void EnumerateDoesntThrow()
        {
            try
            {
                var output = sut.Enumerate("", cancellationManager);
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public async Task EnumerateReturnsFileList()
        {
            var result = await sut.Enumerate(@"C:\ProgramData\Microsoft\Windows\Start Menu", cancellationManager);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public async Task EnumerateChecksForCancellation()
        {
            var output = await sut.Enumerate(@"C:\ProgramData\Microsoft\Windows\Start Menu", cancellationManager);
            var result = cancellationManager.WasTokenAccessed;
            Assert.IsTrue(result);
        }
    }
}

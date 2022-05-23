using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using WigeDev.Copier.Implementations;

namespace Tests
{
    [TestClass]
    public class SourceFileTests
    {
        private FileInfo? fi;
        private SourceFile? sut;
        private bool isError;
        private FakeCancellationManager? cancellationManager;
        private FakeCopyStrategy copyStrategy;
        private FakeSettingsManager settingsManager;

        [TestInitialize]
        public void Initialize()
        {
            settingsManager = new();
            copyStrategy = new();
            settingsManager.CopyStrategy = copyStrategy;
            fi = new(@"C:\Windows\System32\cmd.exe");
            sut = new(fi, settingsManager);
            isError = false;
            cancellationManager = new();

            // reset test folder
            var di = new DirectoryInfo(@"C:\Test");
            if (di.Exists) di.Delete(true);
        }

        [TestMethod]
        public void NameDoesntThrow()
        {
            try
            {
                var output = sut?.Name;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void NameReturnsFullPath()
        {
            var result = sut?.Name;
            Assert.AreEqual(fi?.FullName, result);
        }

        [TestMethod]
        public async Task CopyToDoesntThrow()
        {
            try
            {
                await sut.CopyTo(@"C:\Test\cmd.exe", cancellationManager);
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public async Task CopyToCreatesDirectory()
        {
            await sut.CopyTo(@"C:\Test\cmd.exe", cancellationManager);
            var result = (new DirectoryInfo(@"C:\Test")).Exists;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyToCreatesSubdirectories()
        {
            await sut.CopyTo(@"C:\Test\Subfolder 1\cmd.exe", cancellationManager);
            var result = (new DirectoryInfo(@"C:\Test\Subfolder 1")).Exists;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyToCallsCopyStrategyCopyFile()
        {
            await sut.CopyTo(@"C:\Test\cmd.exe", cancellationManager);
            var result = copyStrategy.WasCopyFileCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyToDoesntThrowOnAccessError()
        {
            try
            {
                await sut.CopyTo(@"C:\Windows\System32\TestDirectory\cmd.exe", cancellationManager);
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }
    }
}

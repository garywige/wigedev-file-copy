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

        [TestInitialize]
        public void Initialize()
        {
            fi = new(@"C:\Windows\System32\cmd.exe");
            sut = new(fi);
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
        public async Task CopyToNewFileHasSameLength()
        {
            await sut.CopyTo(@"C:\Test\cmd.exe", cancellationManager);
            var destFi = new FileInfo(@"C:\Test\cmd.exe");
            Assert.AreEqual(fi.Length, destFi.Length);
        }

        [TestMethod]
        public async Task CopyToThrowsExceptionWhenCancelled()
        { 

            bool isCancelled = false;
            sut = new SourceFile(new FileInfo(@"C:\Windows\System32\MRT.exe"));

            try
            {
                var task = sut.CopyTo(@"C:\Test\cmd.exe", cancellationManager);
                cancellationManager.Cancel();
                await task;
            }
            catch
            {
                isCancelled = true;
            }

            Assert.IsTrue(isCancelled);
        }
    }
}

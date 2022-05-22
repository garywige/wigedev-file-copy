using WigeDev.Copier.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.IO;
using System;

namespace Tests
{
    [TestClass]
    public class AllCopyStrategyTests
    {
        private readonly byte testByte = 0xFF;
        private AllCopyStrategy sut;
        private bool isError;
        private FileInfo source;
        private FileInfo dest;
        private FakeCancellationManager cancellationManager;
        private FakeOutput output;

        [TestInitialize]
        public void Initialize()
        {
            output = new();
            source = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "source.txt"));
            var fs = source.Create();
            fs.WriteByte(testByte);
            fs.Close();

            dest = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "dest.txt"));
            if (dest.Exists)
                dest.Delete();

            cancellationManager = new FakeCancellationManager();

            sut = new(output);
            isError = false;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if(source.Exists)
                source.Delete();
            if(dest.Exists)
                dest.Delete();
        }

        [TestMethod]
        public async Task CopyFileDoesntThrow()
        {
            try
            {
                await sut.CopyFile(source, dest, cancellationManager.Token);
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public async Task CopyFileCopiesDataToDestFile()
        {
            await sut.CopyFile(source, dest, cancellationManager.Token);

            var fs = dest.OpenRead();
            var result = fs.ReadByte();
            fs.Close();

            Assert.AreEqual(testByte, result);
        }

        [TestMethod]
        public async Task CopyFileReplacesNewerFile()
        {
            var fs = dest.Create();
            fs.Close();

            await sut.CopyFile(source, dest, cancellationManager.Token);

            fs = dest.OpenRead();
            var result = fs.ReadByte();
            fs.Close();

            Assert.AreEqual(testByte, result);
        }

        [TestMethod]
        public async Task CopyFileCancelation()
        {
            var token = cancellationManager.Token;
            cancellationManager.Cancel();

            try
            {
                await sut.CopyFile(source, dest, token);
            }
            catch(OperationCanceledException)
            {
                isError = true;
            }

            Assert.IsTrue(isError);
        }

        [TestMethod]
        public async Task CopyFileWritesToOutputOnAccessError()
        {
            dest = new FileInfo(@"C:\Windows\System32\dest.txt");
            await sut.CopyFile(source, dest, cancellationManager.Token);
            var result = output.WasWriteCalled;
            Assert.IsTrue(result);
        }
    }
}

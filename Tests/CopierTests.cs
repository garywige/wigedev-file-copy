using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WigeDev.Copier.Implementations;

namespace Tests
{
    [TestClass]
    public class CopierTests
    {
        private Copier sut;
        private bool isError;
        private FakeFileEnumerator enumerator;
        private FakeTextField source;
        private FakeTextField dest;
        private FakeSourceFile sourceFile;
        private FakeOutput output;
        private FakePathConstructor pathConstructor;
        private FakeCancellationManager cancellationManager;
        private FakeJobStatus jobStatus;

        [TestInitialize]
        public void Initialize()
        {
            jobStatus = new();
            cancellationManager = new();
            pathConstructor = new FakePathConstructor();
            output = new FakeOutput();
            sourceFile = new();
            enumerator = new(sourceFile);
            source = new FakeTextField();
            dest = new FakeTextField();
            sut = new(enumerator, source, dest, output, pathConstructor, cancellationManager, jobStatus);
            isError = false;
        }

        [TestMethod]
        public async Task CopyDoesntThrow()
        {
            try
            {
                await sut.Copy();
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public async Task CopyCallsEnumerate()
        {
            await sut.Copy();
            var result = enumerator.WasEnumerateCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyCallsCopyToOnFiles()
        {
            await sut.Copy();
            var result = sourceFile.WasCopyToCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyCallsOutputWrite()
        {
            await sut.Copy();
            var result = output.WasWriteCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyCallsPathConstructorConstruct()
        {
            await sut.Copy();
            var result = pathConstructor.WasConstructCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CancelCallsCancel()
        {
            sut.Cancel();
            var result = cancellationManager.WasCancelCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task CopyClearsOutputList()
        {
            await sut.Copy();
            await sut.Copy();
            var result = output.Output.Count;
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public async Task CopyDoesntThrowOnCancel()
        {
            sut.Cancel();

            try
            {
                await sut.Copy();
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public async Task CopySetsTotalFiles()
        {
            bool isChanged = false;
            jobStatus.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "TotalFiles")
                    isChanged = true;
            };

            await sut.Copy();

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public async Task CopySetsFilesCopied()
        {
            bool isChanged = false;
            jobStatus.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FilesCopied")
                    isChanged = true;
            };

            await sut.Copy();

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public async Task CopyResetsFilesCopiedOnCancellation()
        {
            jobStatus.FilesCopied = 1;
            sut.Cancel();
            await sut.Copy();
            var result = jobStatus.FilesCopied;
            Assert.AreEqual(0, result);
        }
    }
}

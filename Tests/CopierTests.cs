using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WigeDev.Copier.Implementations;
using WigeDev.Cancellation.Interfaces;

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

        [TestInitialize]
        public void Initialize()
        {
            cancellationManager = new();
            pathConstructor = new FakePathConstructor();
            output = new FakeOutput();
            sourceFile = new();
            enumerator = new(sourceFile);
            source = new FakeTextField();
            dest = new FakeTextField();
            sut = new(enumerator, source, dest, output, pathConstructor, cancellationManager);
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
    }
}

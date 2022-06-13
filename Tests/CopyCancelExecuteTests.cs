using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Execute.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyCancelExecuteTests
    {
        private CopyCancelExecute sut;
        private bool isError;
        private FakeCopier copier;

        [TestInitialize]
        public void Initialize()
        {
            copier = new FakeCopier();
            sut = new(copier, new FakeJobStatus());
            isError = false;
        }

        [TestMethod]
        public void ExecuteDoesntThrow()
        {
            try
            {
                sut.Execute();
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ExecuteCallsICopierCopy()
        {
            sut.Execute();
            Assert.IsTrue(copier.WasCopyCalled);
        }

        [TestMethod]
        public void ExecuteCallsCancelWhenCalledTwice()
        {
            copier.CopyDelay = true;

            sut.Execute();
            sut.Execute();
            Assert.IsTrue(copier.WasCancelCalled);
        }
    }
}

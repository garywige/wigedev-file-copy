using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Execute.Implementations;

namespace Tests
{
    [TestClass]
    public class StartBatchExecuteTests
    {
        private StartBatchExecute sut;
        private FakeJobStatus jobStatus;
        private FakeCopier copier;

        [TestInitialize]
        public void Initialize()
        {
            jobStatus = new();
            copier = new();
            sut = new(jobStatus, copier);
        }

        [TestMethod]
        public void ExecuteJobStatusIsCopyingChanged()
        {
            bool isChanged = false;
            jobStatus.PropertyChanged += (s, e) => isChanged = true;

            sut.Execute();

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void ExecuteJobStatusIsCopyingFalseWhenTrue()
        {
            jobStatus.IsCopying = true;

            sut.Execute();

            var result = jobStatus.IsCopying;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExecuteJobStatusIsCopyingFalseWhenFalse()
        {
            jobStatus.IsCopying = false;
            sut.Execute();

            var result = jobStatus.IsCopying;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExecuteCallsCopierCopy()
        {
            sut.Execute();

            var result = copier.WasCopyCalled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteNoCallCopierCopyWhenCopying()
        {
            jobStatus.IsCopying = true;

            sut.Execute();

            var result = copier.WasCopyCalled;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExecuteCallsCopierCancelWhenCopying()
        {
            jobStatus.IsCopying = true;

            sut.Execute();

            var result = copier.WasCancelCalled;
            Assert.IsTrue(result);
        }
    }
}

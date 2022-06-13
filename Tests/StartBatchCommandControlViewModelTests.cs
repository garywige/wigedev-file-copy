using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class StartBatchCommandControlViewModelTests
    {
        private StartBatchCommandControlViewModel sut;
        private FakeJobStatus jobStatus;

        [TestInitialize]
        public void Initialize()
        {
            jobStatus = new();
            sut = new(jobStatus, new FakeCommand());
        }

        [TestMethod]
        public void ButtonContentReturnsStartBatch()
        {
            var result = sut.ButtonContent;
            Assert.AreEqual("Start Batch", result);
        }

        [TestMethod]
        public void ButtonContentReturnsCancelBatchWhenCopying()
        {
            jobStatus.IsCopying = true;
            var result = sut.ButtonContent;
            Assert.AreEqual("Cancel Batch", result);
        }

        [TestMethod]
        public void ButtonContentPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) => isChanged = true;

            jobStatus.IsCopying = true;

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void CommandIsNotNull()
        {
            var result = sut.Command;
            Assert.IsNotNull(result);
        }
    }
}

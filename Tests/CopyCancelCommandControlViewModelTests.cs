using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyCancelCommandControlViewModelTests
    {
        private CopyCancelCommandControlViewModel sut;
        private bool isError;
        private FakeJobStatus jobStatus;
        private FakeCommand copyCancelCommand;

        [TestInitialize]
        public void Initialize()
        {
            jobStatus = new();
            copyCancelCommand = new();
            sut = new(jobStatus, copyCancelCommand);
            isError = false;
        }

        [TestMethod]
        public void ButtonContentDoesntThrow()
        {
            try
            {
                var output = sut.ButtonContent;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ButtonContentDefaultCopy()
        {
            var result = sut.ButtonContent;
            Assert.AreEqual("Copy", result);
        }

        [TestMethod]
        public void ButtonContentCancelWhenCopying()
        {
            jobStatus.IsCopying = true;
            var result = sut.ButtonContent;
            Assert.AreEqual("Cancel", result);
        }

        [TestMethod]
        public void ButtonContentPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "ButtonContent")
                    isChanged = true;
            };
            jobStatus.IsCopying = true;
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void CommandDoesntThrow()
        {
            try
            {
                var output = sut.Command;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CommandNotNull()
        {
            var result = sut.Command;
            Assert.IsNotNull(result);
        }
    }
}

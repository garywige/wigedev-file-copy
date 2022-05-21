using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class CommandControlViewModelTests
    {
        private CommandControlViewModel sut;
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
        public void CopyCancelButtonContentDoesntThrow()
        {
            try
            {
                var output = sut.CopyCancelButtonContent;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CopyCancelButtonContentDefaultCopy()
        {
            var result = sut.CopyCancelButtonContent;
            Assert.AreEqual("Copy", result);
        }

        [TestMethod]
        public void CopyCancelButtonContentCancelWhenCopying()
        {
            jobStatus.IsCopying = true;
            var result = sut.CopyCancelButtonContent;
            Assert.AreEqual("Cancel", result);
        }

        [TestMethod]
        public void CopyCancelButtonContentPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "CopyCancelButtonContent")
                    isChanged = true;
            };
            jobStatus.IsCopying = true;
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void CopyCancelCommandDoesntThrow()
        {
            try
            {
                var output = sut.CopyCancelCommand;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CopyCancelCommandNotNull()
        {
            var result = sut.CopyCancelCommand;
            Assert.IsNotNull(result);
        }
    }
}

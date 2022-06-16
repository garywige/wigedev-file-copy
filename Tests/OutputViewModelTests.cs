using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class OutputViewModelTests
    {
        private OutputViewModel sut;
        private bool isError;
        private FakeJobStatus jobStatus;

        [TestInitialize]
        public void Initialize()
        {
            jobStatus = new();
            sut = new(new FakeOutput(), jobStatus);
            isError = false;
        }

        [TestMethod]
        public void OutputGetDoesntThrow()
        {
            try
            {
                var output = sut.Output;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void OutputGetNotNull()
        {
            var result = sut.Output;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProgressDoesntThrow()
        {
            try
            {
                var output = sut.Progress;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ProgressValueBasedOnJobStatus()
        {
            jobStatus.TotalFiles = 1000;
            jobStatus.FilesCopied = 500;
            var result = sut.Progress;
            Assert.AreEqual(50.0, result);
        }

        [TestMethod]
        public void ProgressPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Progress")
                    isChanged = true;
            };

            jobStatus.TotalFiles = 100;
            jobStatus.FilesCopied = 50;

            Assert.IsTrue(isChanged);
        }
    }
}

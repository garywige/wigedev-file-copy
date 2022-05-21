using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class BrowseCommandTests
    {
        private BrowseCommand sut;
        private bool isError;
        private FakeFolderBrowserDialog browserDialog;

        [TestInitialize]
        public void Initialize()
        {
            browserDialog = new();
            sut = new(browserDialog);
            isError = false;
        }

        [TestMethod]
        public void FolderPathDoesntThrow()
        {
            try
            {
                var output = sut.FolderPath;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CanExecuteReturnsTrue()
        {
            var result = sut.CanExecute(null);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteChangesFolderPath()
        {
            sut.Execute(null);
            var result = sut.FolderPath;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void FolderPathPropertyChangedEvent()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                isChanged = true;
            };

            sut.Execute(null);
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void ExecuteCallsShowDialog()
        {
            sut.Execute(null);
            var result = browserDialog.WasShowDialogCalled;
            Assert.IsTrue(result);
        }
    }
}

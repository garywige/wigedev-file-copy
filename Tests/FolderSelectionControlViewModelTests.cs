using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class FolderSelectionControlViewModelTests
    {
        private FolderSelectionControlViewModel sut;
        private bool isError;
        private string labelContent = "test";
        private FakeTextField textField;
        private FakeJobStatus jobStatus;
        private FakeBrowseCommand browseCommand;

        [TestInitialize]
        public void Initialize()
        {
            browseCommand = new();
            textField = new();
            jobStatus = new();
            sut = new(labelContent, textField, jobStatus, browseCommand);
            isError = false;
        }

        [TestMethod]
        public void LabelContentDoesntThrow()
        {
            try
            {
                var output = sut.LabelContent;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void LabelContentReturnsConstructorValue()
        {
            var result = sut.LabelContent;
            Assert.AreEqual(labelContent, result);
        }

        [TestMethod]
        public void TextFieldDoesntThrow()
        {
            try
            {
                var output = sut.TextField;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }
        
        [TestMethod]
        public void TextFieldIsNotNull()
        {
            var result = sut.TextField;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IsEnabledDoesntThrow()
        {
            try
            {
                var output = sut.IsEnabled;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void IsEnabledTrueByDefault()
        {
            var result = sut.IsEnabled;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEnabledFalseWhenCopying()
        {
            jobStatus.IsCopying = true;
            var result = sut.IsEnabled;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BrowseCommandDoesntThrow()
        {
            try
            {
                var output = sut.BrowseCommand;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void BrowseCommandIsNotNull()
        {
            var result = sut.BrowseCommand;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TextFieldTextEqualsBrowseCommandFolderPath()
        {
            browseCommand.FolderPath = "test";
            var result = sut.TextField.Text;
            Assert.AreEqual("test", result);
        }
    }
}

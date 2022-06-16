using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class FolderBrowserDialogAdapterTests
    {
        private FolderBrowserDialogAdapter sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
            isError = false;
        }

        [TestMethod]
        public void SelectedPathDoesntThrow()
        {
            try
            {
                var output = sut.SelectedPath;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }
    }
}

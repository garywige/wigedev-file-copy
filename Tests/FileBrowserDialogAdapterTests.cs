using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class FileBrowserDialogAdapterTests
    {
        private SaveFileDialogAdapter sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new("", "");
        }

        [TestMethod]
        public void SelectedPathEmptyStringDefault()
        {
            var result = sut.SelectedPath;
            Assert.AreEqual("", result);
        }
    }
}

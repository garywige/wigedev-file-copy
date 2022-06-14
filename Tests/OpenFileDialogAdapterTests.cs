using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class OpenFileDialogAdapterTests
    {
        private OpenFileDialogAdapter sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new("", "");
        }

        [TestMethod]
        public void SelectedPathReturnsEmptyStringDefault()
        {
            var result = sut.SelectedPath;
            Assert.AreEqual(string.Empty, result);
        }
    }
}

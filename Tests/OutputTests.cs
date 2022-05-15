using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Output.Implementations;

namespace Tests
{
    [TestClass]
    public class OutputTests
    {
        private Output sut;
        private bool isError;
        FakeViewModel viewModel;

        [TestInitialize]
        public void Initialize()
        {
            viewModel = new();
            sut = new(viewModel);
            isError = false;
        }

        [TestMethod]
        public void WriteDoesntThrow()
        {
            try
            {
                sut.Write("");
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void WriteIncrementsViewModelOutputCount()
        {
            sut.Write("");
            var result = viewModel.Output.Count;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WriteAddsMessageToViewModelOutput()
        {
            sut.Write("test");
            var result = viewModel.Output[0];
            Assert.AreEqual("test", result);
        }
    }
}

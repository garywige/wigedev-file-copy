using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.View.Implementations;

namespace Tests
{
    [TestClass]
    public class OutputWindowAdapterTests
    {
        private OutputWindowAdapter sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
            isError = false;
        }

        [TestMethod]
        public void OutputDefaultNull()
        {
            var result = sut.Output;
            Assert.IsNull(result);
        }
    }
}

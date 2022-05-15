using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WigeDev.Output.Implementations;

namespace Tests
{
    [TestClass]
    public class OutputTests
    {
        private Output sut;
        private bool isError;
        private List<string> output;

        [TestInitialize]
        public void Initialize()
        {
            output = new();
            sut = new(output);
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
        public void WriteIncrementsOutputListCount()
        {
            sut.Write("");
            var result = output.Count;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WriteAddsMessageToViewModelOutput()
        {
            sut.Write("test");
            var result = output[0];
            Assert.AreEqual("test", result);
        }
    }
}

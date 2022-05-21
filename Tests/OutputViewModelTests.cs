using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class OutputViewModelTests
    {
        private OutputViewModel sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new(new FakeOutput());
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
    }
}

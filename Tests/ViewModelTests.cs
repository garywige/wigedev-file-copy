using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ViewModelTests
    {
        private ViewModel sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new(new FakeTextField(), new FakeTextField(), new FakeCommand(), new FakeOutput(), (s, e) => { });
            isError = false;
        }

        [TestMethod]
        public void SourceGetDoesntThrow()
        {
            try
            {
                var result = sut.Source;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void SourceGetNotNull()
        {
            var result = sut.Source;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DestinationGetDoesntThrow()
        {
            try
            {
                var output = sut.Destination;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void DestinationGetNotNull()
        {
            var result = sut.Destination;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CopyCancelCommandGetDoesntThrow()
        {
            try
            {
                var output = sut.CopyCancelCommand;
            }
            catch
            {
                isError= true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void CopyCancelCommandGetNotNull()
        {
            var result = sut.CopyCancelCommand;
            Assert.IsNotNull(result);
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

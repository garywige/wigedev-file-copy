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
        private FakeJobStatus jobStatus;

        [TestInitialize]
        public void Initialize()
        {
            jobStatus = new FakeJobStatus();
            sut = new(new FakeTextField(), new FakeTextField(), new FakeCommand(), new FakeOutput(), (s, e) => { }, jobStatus);
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

        [TestMethod]
        public void CopyCancelButtonContentReturnsCopyWhenIsNotCopying()
        {
            var result = sut.CopyCancelButtonContent;
            Assert.AreEqual("Copy", result);
        }

        [TestMethod]
        public void CopyCancelButtonContentReturnsCancelWhenCopying()
        {
            jobStatus.IsCopying = true;
            var result = sut.CopyCancelButtonContent;
            Assert.AreEqual("Cancel", result);
        }

        [TestMethod]
        public void CopyCancelButtonContentRaisesPropertyChangedOnJobStatusChange()
        {
            bool propertyChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                if(e.PropertyName == "CopyCancelButtonContent")
                    propertyChanged = true;
            };

            jobStatus.IsCopying = true;
            Assert.IsTrue(propertyChanged);
        }
    }
}

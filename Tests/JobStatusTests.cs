using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class JobStatusTests
    {
        private JobStatus sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
            isError = false;
        }

        [TestMethod]
        public void IsCopyingGetInitiallyReturnsFalse()
        {
            var result = sut.IsCopying;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCopyingGetReturnsTrueWhenSetTrue()
        {
            sut.IsCopying = true;
            var result = sut.IsCopying;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCopyingSetCallsPropertyChanged()
        {
            bool propertyChanged = false;
            sut.PropertyChanged += (s, e) => propertyChanged = true;
            sut.IsCopying = true;
            Assert.IsTrue(propertyChanged);
        }

        [TestMethod]
        public void IsCopyingSetSpecifiesPropertyName()
        {
            bool isCopyingChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                isCopyingChanged = e.PropertyName == "IsCopying";
            };
            sut.IsCopying = true;
            Assert.IsTrue(isCopyingChanged);
        }

        [TestMethod]
        public void FilesCopiedDefaultZero()
        {
            var result = sut.FilesCopied;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FilesCopiedGetEqualsSet()
        {
            sut.FilesCopied = 1;
            var result = sut.FilesCopied;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FilesCopiedPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FilesCopied")
                    isChanged = true;
            };

            sut.FilesCopied = 1;
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void TotalFilesDefaultZero()
        {
            var result = sut.TotalFiles;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TotalFilesGetEqualsSet()
        {
            sut.TotalFiles = 1;
            var result = sut.TotalFiles;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TotalFilesPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "TotalFiles")
                    isChanged = true;
            };

            sut.TotalFiles = 1;

            Assert.IsTrue(isChanged);
        }
    }
}

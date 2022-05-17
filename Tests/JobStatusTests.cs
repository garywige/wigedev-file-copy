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
    }
}

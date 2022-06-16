using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.ObjectModel;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class NotifyListEnumeratorTests
    {
        private NotifyListEnumerator<int> sut;
        private bool isError;
        private FakeNotifyList<int> list;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
            isError = false;
            list = new(new ObservableCollection<int>());
        }

        [TestMethod]
        public void ListSetDoesntThrow()
        {
            try
            {
                sut.List = list;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ListGetReturnsSetValue()
        {
            sut.List = list;
            var result = sut.List;
            Assert.AreEqual(list, result);
        }

        [TestMethod]
        public void CurrentReturnsDefaultValue()
        {
            var result = sut.Current;
            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void CurrentReturnsFirstElementAfterMoveNext()
        {
            sut.List = list;
            sut.List.Add(1337);
            sut.MoveNext();

            var result = sut.Current;

            Assert.AreEqual(1337, result);
        }

        [TestMethod]
        public void MoveNextReturnsTrueIfWithinRange()
        {
            sut.List = list;
            sut.List.Add(0);

            var result = sut.MoveNext();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MoveNextReturnsFalseIfNotWithinRange()
        {
            sut.List = list;

            var result = sut.MoveNext();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CurrentReturnsDefaultValueIfOutOfRange()
        {
            sut.List = list;
            sut.MoveNext();

            var result = sut.Current;

            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void ResetSetsIndexToDefault()
        {
            sut.List = list;
            sut.List.Add(1337);
            sut.MoveNext();

            sut.Reset();

            var result = sut.Current;
            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void IEnumeratorCurrentIsNotNull()
        {
            var enumerator = sut as IEnumerator;

            var result = enumerator.Current;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DisposeDoesntThrow()
        {
            try
            {
                sut.Dispose();
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }
    }
}

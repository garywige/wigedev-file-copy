using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class NotifyListTests
    {
        private NotifyList<int> sut;

        [TestInitialize]
        public void Initialize()
        {
            sut = new();
        }

        [TestMethod]
        public void IsReadOnlyReturnsFalse()
        {
            var result = sut.IsReadOnly;
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CountReturnsZeroByDefault()
        {
            var result = sut.Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountReturnsOneAfterAdd()
        {
            sut.Add(0);
            var result = sut.Count;
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void IndexerReturnsValueAfterAdd()
        {
            sut.Add(1337);
            var result = sut[0];
            Assert.AreEqual(1337, result);
        }

        [TestMethod]
        public void GetReturnsSetValue()
        {
            sut.Add(1337);
            sut[0] = 1338;
            var result = sut[0];
            Assert.AreEqual(1338, result);
        }

        [TestMethod]
        public void AddTriggersCollectionChanged()
        {
            bool isChanged = false;
            sut.CollectionChanged += (s, e) =>
            {
                isChanged = true;
            };
            sut.Add(0);
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void IndexerSetcollectionChanged()
        {
            sut.Add(0);
            bool isChanged = false;
            sut.CollectionChanged += (s, e) =>
            {
                isChanged |= true;
            };
            sut[0] = 1;
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void ClearSetsCountToZero()
        {
            sut.Add(0);
            sut.Clear();
            var result = sut.Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ClearCollectionChanged()
        {
            bool isChanged = false;
            sut.CollectionChanged += (s, e) =>
            {
                isChanged = true;
            };
            sut.Clear();
            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void ContainsFalseIfNotFound()
        {
            var result = sut.Contains(0);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsTrueIfFound()
        {
            sut.Add(0);
            var result = sut.Contains(0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CopyToCopies()
        {
            for (int i = 1; i < 11; i++)
                sut.Add(i);
            var arr = new int[11];
            arr[0] = 0;

            sut.CopyTo(arr, 1);

            bool isEqual = true;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i)
                    isEqual = false;
            }

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void GetEnumeratorReturnsEnumerator()
        {
            var result = sut.GetEnumerator();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexOfReturnsIndex()
        {
            for (int i = 0; i < 10; i++)
                sut.Add(i);

            var result = sut.IndexOf(5);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void InsertInsertsItem()
        {
            sut.Add(0);
            sut.Add(2);
            sut.Insert(1, 1);

            bool isEqual = true;
            for (int i = 0; i < 3; i++)
            {
                if (sut[i] != i)
                    isEqual = false;
            }

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void RemoveRemovesElement()
        {
            sut.Add(0);
            sut.Add(1);
            sut.Remove(1);

            Assert.IsTrue(sut.Count == 1 && sut[0] == 0);
        }

        [TestMethod]
        public void InsertCollectionChanged()
        {
            bool isChanged = false;
            sut.Add(0);
            sut.CollectionChanged += (s, e) =>
            {
                isChanged = true;
            };

            sut.Insert(0, 0);

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void RemoveCollectionChanged()
        {
            bool isChanged = false;
            sut.Add(0);
            sut.CollectionChanged += (s, e) => isChanged = true;

            sut.Remove(0);

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void RemoveAtRemovesItem()
        {
            sut.Add(0);

            sut.RemoveAt(0);

            Assert.AreEqual(0, sut.Count);
        }

        [TestMethod]
        public void RemoveAtCollectionChanged()
        {
            bool isChanged = false;
            sut.Add(0);
            sut.CollectionChanged += (s, e) => isChanged = true;

            sut.RemoveAt(0);

            Assert.IsTrue(isChanged);
        }

        [TestMethod]
        public void IEnumerableGetEnumeratorIsNotNull()
        {
            var enumerable = sut as IEnumerable;
            var result = enumerable.GetEnumerator();
            Assert.IsNotNull(result);
        }
    }
}

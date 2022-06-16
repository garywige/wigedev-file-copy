using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WigeDev.ViewModel.Implementations;

namespace Tests
{
    [TestClass]
    public class OverwriteSelectControlViewModelTests
    {
        private OverwriteSelectControlViewModel<object> sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            List<object> itemsSource = new();
            itemsSource.Add(new object());
            sut = new("test", itemsSource);
            isError = false;
        }

        [TestMethod]
        public void LabelContentDoesntThrow()
        {
            try
            {
                var output = sut.LabelContent;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void LabelContentEqualsContsructorValue()
        {
            var result = sut.LabelContent;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void ItemsSourceDoesntThrow()
        {
            try
            {
                var output = sut.ItemsSource;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ItemsSourceIsNotNull()
        {
            var result = sut.ItemsSource;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SelectedItemGetDoesntThrow()
        {
            try
            {
                var output = sut.SelectedItem;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void SelectedItemsGetEqualsSet()
        {
            var testObject = new object();
            sut.SelectedItem = testObject;
            var result = sut.SelectedItem;
            Assert.AreEqual(testObject, result);
        }

        [TestMethod]
        public void SelectedItemPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "SelectedItem")
                    isChanged = true;
            };

            sut.SelectedItem = new object();
            Assert.IsTrue(isChanged);
        }
    }
}

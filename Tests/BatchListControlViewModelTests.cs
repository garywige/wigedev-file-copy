using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Implementations;
using System.Collections.ObjectModel;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class BatchListControlViewModelTests
    {
        private BatchListControlViewModel sut;
        private bool isError;

        [TestInitialize]
        public void Initialize()
        {
            sut = new(new FakeNotifyList<ICopyJobControlViewModel>(new ObservableCollection<ICopyJobControlViewModel>()));
            isError = false;
        }

        [TestMethod]
        public void ItemsDoesntThrow()
        {
            try
            {
                var output = sut.Items;
            }
            catch
            {
                isError = true;
            }

            Assert.IsFalse(isError);
        }

        [TestMethod]
        public void ItemsPropertyChanged()
        {
            bool isChanged = false;
            sut.PropertyChanged += (s, e) =>
            {
                isChanged = true;
            };

            sut.Items?.Add(null);

            Assert.IsTrue(isChanged);
        }
    }
}

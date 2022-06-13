using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    public class BatchListCVMInitializerTests : InitializerTestsBase<IBatchListControlViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new BatchListCVMInitializer(new FakeNotifyList<ICopyJobControlViewModel>(new ObservableCollection<ICopyJobControlViewModel>()));
        }
    }
}

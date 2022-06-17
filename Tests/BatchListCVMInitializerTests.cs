using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class LoadCVMInitializerTests : InitializerTestsBase<ICommandControlViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new LoadCVMInitializer(
                new FakeJobStatus(),
                new FakeFolderBrowserDialog(),
                null,
                new FakeNotifyList<ICopyJobControlViewModel>(new ObservableCollection<ICopyJobControlViewModel>()));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;
using System.Collections.ObjectModel;

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

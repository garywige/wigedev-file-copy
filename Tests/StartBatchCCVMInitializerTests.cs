using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class StartBatchCCVMInitializerTests : InitializerTestsBase<ICommandControlViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new StartBatchCCVMInitializer(
                new FakeJobStatus(),
                new FakeCancellationManager(),
                new FakeNotifyList<ICopyJobControlViewModel>(new ObservableCollection<ICopyJobControlViewModel>()),
                new FakeFileEnumerator(new FakeSourceFile()),
                new FakePathConstructor());
        }
    }
}

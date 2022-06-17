using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class SaveCVMInitializerTests : InitializerTestsBase<ICommandControlViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new SaveCVMInitializer(
                new FakeJobStatus(),
                new FakeNotifyList<ICopyJobControlViewModel>(
                    new ObservableCollection<ICopyJobControlViewModel>()
                    ),
                null,
                null
                );
        }
    }
}

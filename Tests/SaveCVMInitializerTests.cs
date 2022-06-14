using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;
using System.Collections.ObjectModel;

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

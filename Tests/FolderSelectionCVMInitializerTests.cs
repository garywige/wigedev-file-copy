using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class FolderSelectionCVMInitializerTests : InitializerTestsBase<IFolderSelectionControlViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new FolderSelectionCVMInitializer("test", new FakeTextField(), new FakeJobStatus());
        }
    }
}

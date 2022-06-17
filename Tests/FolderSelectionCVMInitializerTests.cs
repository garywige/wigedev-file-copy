using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

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

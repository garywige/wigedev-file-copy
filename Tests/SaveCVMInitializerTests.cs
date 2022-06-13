using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            sut = new SaveCVMInitializer();
        }
    }
}

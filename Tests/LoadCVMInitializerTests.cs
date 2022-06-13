using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class LoadCVMInitializerTests : InitializerTestsBase<ICommandControlViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new LoadCVMInitializer();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Copier.Interfaces;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class OverwriteVMInitializerTests : InitializerTestsBase<ISelectControlViewModel<ICopyStrategy>>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new OverwriteVMInitializer(new FakeOutput());
        }
    }
}

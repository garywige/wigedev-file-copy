using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Copier.Interfaces;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

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

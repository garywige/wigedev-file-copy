using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class OutputVMInitializerTests : InitializerTestsBase<IOutputViewModel>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new OutputVMInitializer(new FakeOutput(), new FakeJobStatus());
        }
    }
}

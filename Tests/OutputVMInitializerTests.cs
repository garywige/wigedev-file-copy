using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Init.Implementations;

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

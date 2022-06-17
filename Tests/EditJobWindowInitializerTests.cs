using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.View.Interfaces;

namespace Tests
{
    [TestClass]
    public class EditJobWindowInitializerTests : InitializerTestsBase<IWindowAdapter>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new EditJobWindowInitializer(new FakeEditJobWindowFactory());
        }
    }
}

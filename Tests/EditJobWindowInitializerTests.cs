using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.View.Interfaces;
using WigeDev.View.Implementations;
using WigeDev.Init.Implementations;

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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using WigeDev.Validation.Interfaces;

namespace Tests
{
    [TestClass]
    public class ValidatorInitializerTests : InitializerTestsBase<IValidator>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new ValidatorInitializer(
                new FakeTextField(),
                new FakeTextField());
        }
    }
}

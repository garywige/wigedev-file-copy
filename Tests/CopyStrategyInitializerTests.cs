using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WigeDev.Copier.Interfaces;
using WigeDev.Init.Implementations;

namespace Tests
{
    [TestClass]
    public class CopyStrategyInitializerTests : InitializerTestsBase<IList<ICopyStrategy>>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new CopyStrategyInitializer(new FakeOutput());
        }
    }
}

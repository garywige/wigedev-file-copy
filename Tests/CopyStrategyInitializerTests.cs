using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using System.Collections.Generic;
using WigeDev.Copier.Interfaces;

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

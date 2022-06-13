using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using System.Collections.Generic;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class TextFieldInitializerTests : InitializerTestsBase<IDictionary<string, ITextField>>
    {
        [TestInitialize]
        public override void Initialize()
        {
            sut = new TextFieldInitializer();
        }
    }
}

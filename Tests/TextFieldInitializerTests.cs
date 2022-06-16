using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WigeDev.Init.Implementations;
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

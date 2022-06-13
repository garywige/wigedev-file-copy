using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Settings.Interfaces;
using WigeDev.Init.Implementations;
using WigeDev.Copier.Interfaces;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class SettingsManagerInitializerTests : InitializerTestsBase<ISettingsManager>
    {
        [TestInitialize]
        public override void Initialize()
        {
            var list = new List<ICopyStrategy>();
            list.Add(new FakeCopyStrategy());
            sut = new SettingsManagerInitializer(new FakeSelectControlViewModel<ICopyStrategy>(list));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WigeDev.Init.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    [TestClass]
    public class AddJobAddCommandExecuteInitializerTests : InitializerTestsBase<Action>
    {
        [TestInitialize]
        public override void Initialize()
        {
            var textField = new FakeTextField();
            sut = new AddJobAddCommandExecuteInitializer(new FakeValidator(), null, textField, textField, new List<ICopyJobControlViewModel>(),
                new FakeJobStatus(), job => () => { });
        }
    }
}

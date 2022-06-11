using Microsoft.VisualStudio.TestTools.UnitTesting;
using WigeDev.Init.Implementations;
using System.Collections.Generic;
using WigeDev.ViewModel.Interfaces;
using System;

namespace Tests
{
    [TestClass]
    public class AddJobAddCommandExecuteInitializerTests : InitializerTestsBase<Action>
    {
        [TestInitialize]
        public override void Initialize()
        {
            var textField = new FakeTextField();
            sut = new AddJobAddCommandExecuteInitializer(new FakeValidator(), null, textField, textField, new List<ICopyJobControlViewModel>());
        }
    }
}

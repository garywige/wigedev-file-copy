using System.Collections.Generic;
using System.ComponentModel;
using WigeDev.Output.Interfaces;

namespace Tests
{
    public class FakeOutput : IOutput
    {
        public FakeOutput()
        {
            WasWriteCalled = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Write(string message)
        {
            WasWriteCalled = true;
        }

        public bool WasWriteCalled { get; private set; }

        public IList<string> Output => throw new System.NotImplementedException();
    }
}

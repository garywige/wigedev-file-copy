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
            Output = new List<string>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Write(string message)
        {
            WasWriteCalled = true;
            Output.Add(message);
        }

        public bool WasWriteCalled { get; private set; }

        public IList<string> Output { get; private set; }
    }
}

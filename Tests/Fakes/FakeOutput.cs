using WigeDev.Output.Interfaces;

namespace Tests
{
    public class FakeOutput : IOutput
    {
        public FakeOutput()
        {
            WasWriteCalled = false;
        }

        public void Write(string message)
        {
            WasWriteCalled = true;
        }

        public bool WasWriteCalled { get; private set; }
    }
}

using WigeDev.Execute.Interfaces;

namespace Tests
{
    public class FakeExecute : IExecute
    {
        public FakeExecute()
        {
            WasCalled = false;
        }

        public bool WasCalled { get; private set; }
        public void Execute()
        {
            WasCalled = true;
        }
    }
}

using WigeDev.View.Interfaces;

namespace Tests
{
    public class FakeOutputWindowFactory : IWindowFactory<FakeOutputWindowAdapter>
    {
        public FakeOutputWindowAdapter CreateWindow()
        {
            WasCreateWindowCalled = true;
            var window = new FakeOutputWindowAdapter();
            window.ShowDialogCalled += (s, e) => WasShowDialogCalled = true;
            return window;
        }

        public bool WasCreateWindowCalled { get; private set; } = false;
        public bool WasShowDialogCalled { get; private set; } = false;
    }
}

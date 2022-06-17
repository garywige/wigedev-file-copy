using WigeDev.View.Interfaces;

namespace Tests
{
    public class FakeWindowFactory : IWindowFactory<IOutputWindowAdapter>
    {
        public bool WasCreateWindowCalled { get; set; } = false;
        public bool WasShowDialogCalled { get; set; } = false;

        public IOutputWindowAdapter CreateWindow()
        {
            WasCreateWindowCalled = true;
            var window = new FakeOutputWindowAdapter();
            window.ShowDialogCalled += (s, e) =>
            {
                WasShowDialogCalled = true;
            };

            return window;
        }
    }
}

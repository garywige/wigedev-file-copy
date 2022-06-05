using WigeDev.View.Interfaces;

namespace Tests
{
    public class FakeWindowFactory : IWindowFactory<FakeWindowAdapter>
    {
        public bool WasCreateWindowCalled { get; set; } = false;
        public bool WasShowDialogCalled { get; set; } = false;

        public FakeWindowAdapter CreateWindow()
        { 
            WasCreateWindowCalled = true;
            var window = new FakeWindowAdapter();
            window.ShowDialogCalled += (s, e) =>
            {
                WasShowDialogCalled = true;
            };

            return window;
        }
    }
}

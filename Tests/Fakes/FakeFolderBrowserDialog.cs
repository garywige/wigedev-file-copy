using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeFolderBrowserDialog : IBrowserDialogAdapter
    {
        public FakeFolderBrowserDialog()
        {
            WasShowDialogCalled = false;
        }

        public string SelectedPath => "test";

        public bool ShowDialog()
        {
            WasShowDialogCalled = true;
            return true;
        }

        public bool WasShowDialogCalled { get; private set; }
    }
}

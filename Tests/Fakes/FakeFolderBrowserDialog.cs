using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeFolderBrowserDialog : IFolderBrowserDialogAdapter
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

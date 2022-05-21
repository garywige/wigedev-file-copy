namespace WigeDev.ViewModel.Interfaces
{
    public interface IFolderBrowserDialogAdapter
    {
        public string SelectedPath { get; }
        public bool ShowDialog();
    }
}

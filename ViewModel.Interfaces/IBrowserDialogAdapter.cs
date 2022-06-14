namespace WigeDev.ViewModel.Interfaces
{
    public interface IBrowserDialogAdapter
    {
        public string SelectedPath { get; }
        public bool ShowDialog();
    }
}

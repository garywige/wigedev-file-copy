using WigeDev.ViewModel.Interfaces;
using System.Windows.Forms;

namespace WigeDev.ViewModel.Implementations
{
    public class FolderBrowserDialogAdapter : IFolderBrowserDialogAdapter
    {
        public FolderBrowserDialogAdapter()
        {
            SelectedPath = String.Empty;
        }

        public string SelectedPath { get; private set; }

        public bool ShowDialog()
        {
            FolderBrowserDialog dialog = new();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = dialog.SelectedPath;
                return true;
            }

            return false;
        }
    }
}

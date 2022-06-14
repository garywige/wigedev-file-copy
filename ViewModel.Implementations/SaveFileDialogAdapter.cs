using WigeDev.ViewModel.Interfaces;
using System.Windows.Forms;

namespace WigeDev.ViewModel.Implementations
{
    public class SaveFileDialogAdapter : IBrowserDialogAdapter
    {
        public string SelectedPath { get; private set; } = "";

        public bool ShowDialog()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "WCF File (*.wcf)|*.wfc";
            dialog.Title = "Save Batch";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = dialog.FileName;
                return true;
            }
            return false;
        }
    }
}

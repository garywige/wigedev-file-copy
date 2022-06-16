using System.Windows.Forms;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class SaveFileDialogAdapter : IBrowserDialogAdapter
    {
        protected readonly string filter;
        protected readonly string title;

        public SaveFileDialogAdapter(string filter, string title)
        {
            this.filter = filter;
            this.title = title;
        }

        public string SelectedPath { get; private set; } = "";

        public bool ShowDialog()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = filter;
            dialog.Title = title;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = dialog.FileName;
                return true;
            }
            return false;
        }
    }
}

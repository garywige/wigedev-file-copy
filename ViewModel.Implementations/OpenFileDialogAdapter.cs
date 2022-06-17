using System.Windows.Forms;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class OpenFileDialogAdapter : IBrowserDialogAdapter
    {
        protected readonly string filter;
        protected readonly string title;

        public OpenFileDialogAdapter(string filter, string title)
        {
            this.filter = filter;
            this.title = title;
        }

        public string SelectedPath { get; protected set; } = string.Empty;

        public bool ShowDialog()
        {
            var dialog = new OpenFileDialog();
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

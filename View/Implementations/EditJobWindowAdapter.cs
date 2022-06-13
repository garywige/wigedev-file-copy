using WigeDev.View.Interfaces;
using WigeDev.View.Windows;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.View.Implementations
{
    public class EditJobWindowAdapter : IWindowAdapter
    {
        protected IFolderSelectionControlViewModel source;
        protected IFolderSelectionControlViewModel dest;
        protected ICommandControlViewModel saveCCVM;
        protected ICommandControlViewModel cancelCCVM;

        public EditJobWindowAdapter(
            IFolderSelectionControlViewModel source,
            IFolderSelectionControlViewModel dest,
            ICommandControlViewModel saveCCVM,
            ICommandControlViewModel cancelCCVM)
        {
            this.source = source;
            this.dest = dest;
            this.saveCCVM = saveCCVM;
            this.cancelCCVM = cancelCCVM;
        }

        public void Show() => ShowDialog();
        public bool? ShowDialog()
        {
            var window = new AddJobWindow(source, dest, saveCCVM, cancelCCVM);
            (cancelCCVM.Command as SetExecuteCommand).SetExecute(() => window.Close());
            (saveCCVM.Command as SetExecuteCommand).SetExecute(() =>
            {
                window.DialogResult = true;
                window.Close();
            });

            return window.ShowEditDialog();
        }
    }
}

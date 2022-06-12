using WigeDev.View.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View.Implementations
{
    public class EditJobWindowFactory : IWindowFactory<EditJobWindowAdapter>
    {
        protected IFolderSelectionControlViewModel source;
        protected IFolderSelectionControlViewModel dest;
        protected ICommandControlViewModel saveCCVM;
        protected ICommandControlViewModel cancelCCVM;

        public EditJobWindowFactory(
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

        public EditJobWindowAdapter CreateWindow() => new EditJobWindowAdapter(source, dest, saveCCVM, cancelCCVM);
    }
}

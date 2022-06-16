using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class FolderSelectionCVMInitializer : IInitializer<IFolderSelectionControlViewModel>
    {
        protected string labelContent;
        protected ITextField textField;
        protected IJobStatus jobStatus;

        public FolderSelectionCVMInitializer(
            string labelContent,
            ITextField textField,
            IJobStatus jobStatus)
        {
            this.labelContent = labelContent;
            this.textField = textField;
            this.jobStatus = jobStatus;
        }

        public IFolderSelectionControlViewModel Initialize() => new FolderSelectionControlViewModel(labelContent, textField, jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter()));
    }
}

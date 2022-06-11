using WigeDev.Init.Interfaces;
using System.Windows;
using WigeDev.View.Windows;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;
using System.Windows.Input;

namespace WigeDev.Init.Implementations
{
    public class AddJobWindowInitializer : IInitializer<Window>
    {
        protected IDictionary<string, ITextField> textFields;
        protected IJobStatus jobStatus;
        protected ICommand addCommand;
        protected ICommand cancelCommand;

        public AddJobWindowInitializer(IDictionary<string, ITextField> textFields, IJobStatus jobStatus, ICommand addCommand, ICommand cancelCommand)
        {
            this.textFields = textFields;
            this.jobStatus = jobStatus;
            this.addCommand = addCommand;
            this.cancelCommand = cancelCommand;
        }

        public Window Initialize() => new AddJobWindow(
            new FolderSelectionCVMInitializer("Source", textFields["source"], jobStatus).Initialize(),
            new FolderSelectionCVMInitializer("Destination", textFields["destination"], jobStatus).Initialize(),
            new CommandControlViewModel("Add", addCommand),
            new CommandControlViewModel("Cancel", cancelCommand));
    }
}

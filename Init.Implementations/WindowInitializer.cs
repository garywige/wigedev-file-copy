using WigeDev.Init.Interfaces;
using System.Windows;
using WigeDev.View.Windows;
using WigeDev.View.Implementations;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.Validation.Interfaces;
using WigeDev.Cancellation.Implementations;
using WigeDev.Copier.Implementations;
using WigeDev.FileSystem.Implementations;

namespace WigeDev.Init.Implementations
{
    public class WindowInitializer : IInitializer<Window>
    {
        protected IDictionary<string, ITextField> textFields;
        protected IValidator validator;
        protected IJobStatus jobStatus;
        protected INotifyList<ICopyJobControlViewModel> jobList;

        public Window Initialize()
        {
            textFields = new TextFieldInitializer().Initialize();
            validator = new ValidatorInitializer(textFields["source"], textFields["destination"]).Initialize();
            var output = new OutputInitializer().Initialize();
            jobStatus = new JobStatusInitializer().Initialize();
            var overwriteVM = new OverwriteVMInitializer(output).Initialize();
            var settingsManager = new SettingsManagerInitializer(overwriteVM).Initialize();
            jobList = new BatchJobListInitializer().Initialize();
            var cancellationManager = new CancellationManager();
            var fileEnumerator = new FileEnumerator(settingsManager);
            var pathConstructor = new PathConstructor();

            string filter = "WCF File (*.wcf)|*.wfc";

            // Main Window
            return new MainWindow(
                new FolderSelectionCVMInitializer("Source", textFields["source"], jobStatus).Initialize(),
                new FolderSelectionCVMInitializer("Destination", textFields["destination"], jobStatus).Initialize(),
                new CopyCancelCCVMInitializer(jobStatus, new CopyCancelCommandInitializer(
                    validator, 
                    textFields["source"], 
                    textFields["destination"], 
                    output, 
                    jobStatus,
                    cancellationManager,
                    fileEnumerator,
                    pathConstructor).Initialize()).Initialize(),
                new OutputVMInitializer(output, jobStatus).Initialize(),
                overwriteVM,
                new StartBatchCCVMInitializer(jobStatus, cancellationManager, jobList, fileEnumerator, pathConstructor).Initialize(),
                new AddJobCCVMInitializer(addJobShowDialog, jobList, jobStatus).Initialize(),
                new BatchListCVMInitializer(jobList).Initialize(),
                new SaveCVMInitializer(jobStatus, jobList, new SaveFileDialogAdapter(filter, "Save Batch"), new JobListFileSaver()).Initialize(),
                new LoadCVMInitializer(
                    jobStatus, 
                    new OpenFileDialogAdapter(
                        filter, 
                        "Load Batch"), 
                    new JobListFileLoader(
                        new CopyJobCVMFactory(null, null)), 
                    jobList).Initialize());
        }

        protected bool? addJobShowDialog(object? output)
        {
            var addCommand = new AddJobAddCommandInitializer(textFields["source"], textFields["destination"], validator).Initialize();
            var cancelCommand = new AddJobCancelCommandInitializer().Initialize();
            var window = new AddJobWindowInitializer(textFields, jobStatus, addCommand, cancelCommand).Initialize();
            addCommand.SetExecute(new AddJobAddCommandExecuteInitializer(validator, window, textFields["source"], textFields["destination"], jobList, 
                new EditJobWindowFactory(
                    new FolderSelectionControlViewModel("Source", textFields["source"], jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter())),
                    new FolderSelectionControlViewModel("Destination", textFields["destination"], jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter())), 
                    new CommandControlViewModel("Save", new SetExecuteCommand(new Command(() => validator.IsValid, () => { }))), 
                    new CommandControlViewModel("Cancel", new SetExecuteCommand(new Command(() => true, () => { })))
                    ), jobStatus).Initialize());
            cancelCommand.SetExecute(() => window.Close());
            return window.ShowDialog() == true;
        }
    }
}

using System.Windows;
using WigeDev.Cancellation.Implementations;
using WigeDev.Copier.Implementations;
using WigeDev.FileSystem.Implementations;
using WigeDev.Init.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.View.Implementations;
using WigeDev.View.Windows;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

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

            textFields["source"].PropertyChanged += (s, e) => editCommandChanged?.Invoke(this, new EventArgs());
            textFields["destination"].PropertyChanged += (s, e) => editCommandChanged?.Invoke(this, new EventArgs());
            jobStatus.PropertyChanged += (s, e) => editCommandChanged?.Invoke(this, new EventArgs());
            jobStatus.PropertyChanged += (s, e) => deleteCommandChanged?.Invoke(this, new EventArgs());

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
                new AddJobCCVMInitializer(addJobShowDialog, () => { }, jobList, jobStatus).Initialize(),
                new BatchListCVMInitializer(jobList).Initialize(),
                new SaveCVMInitializer(jobStatus, jobList, new SaveFileDialogAdapter(filter, "Save Batch"), new JobListFileSaver()).Initialize(),
                new LoadCVMInitializer(
                    jobStatus,
                    new OpenFileDialogAdapter(
                        filter,
                        "Load Batch"),
                    new JobListFileLoader(
                        new CopyJobCVMFactory(
                            new EditCommandFactory(
                                () => !jobStatus.IsCopying,
                                () => { },
                                ref editCommandChanged), 
                            new DeleteCommandFactory(
                                () => !jobStatus.IsCopying,
                                () => { },
                                ref deleteCommandChanged))),
                        jobList,
                        editCommandExecute).Initialize());
        }

        protected bool? addJobShowDialog(object? output)
        {
            var addCommand = new AddJobAddCommandInitializer(textFields["source"], textFields["destination"], validator).Initialize();
            var cancelCommand = new AddJobCancelCommandInitializer().Initialize();
            var window = new AddJobWindowInitializer(textFields, jobStatus, addCommand, cancelCommand).Initialize();
            addCommand.SetExecute(addCommandExecute(window));
            cancelCommand.SetExecute(() => window.Close());
            return window.ShowDialog() == true;
        }

        protected Action addCommandExecute(Window window)
        {
            return new AddJobAddCommandExecuteInitializer(validator, window, textFields["source"], textFields["destination"], jobList,
                jobStatus, editCommandExecute).Initialize();
        }

        protected EditJobWindowFactory createEditJobWindowFactory()
        {
            return new EditJobWindowFactory(
                    new FolderSelectionControlViewModel("Source", textFields["source"], jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter())),
                    new FolderSelectionControlViewModel("Destination", textFields["destination"], jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter())),
                    new CommandControlViewModel("Save", new SetExecuteCommand(new Command(() => validator.IsValid, () => { }))),
                    new CommandControlViewModel("Cancel", new SetExecuteCommand(new Command(() => true, () => { })))
                    );
        }

        protected Action editCommandExecute(ICopyJobControlViewModel copyJob) =>
            () =>
            {
                // Set fields to match job params
                textFields["source"].Text = copyJob.Source;
                textFields["destination"].Text = copyJob.Destination;

                var window = new EditJobWindowInitializer(createEditJobWindowFactory()).Initialize();
                if (window.ShowDialog() == true)
                {
                    copyJob.Source = textFields["source"].Text;
                    copyJob.Destination = textFields["destination"].Text;
                }
            };

        protected EventHandler editCommandChanged;
        protected EventHandler deleteCommandChanged;
    }
}

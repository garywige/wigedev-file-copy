using WigeDev.Init.Interfaces;
using System.Windows;
using WigeDev.View.Windows;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Validation.Interfaces;

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

            // Main Window
            return new MainWindow(
                new FolderSelectionCVMInitializer("Source", textFields["source"], jobStatus).Initialize(),
                new FolderSelectionCVMInitializer("Destination", textFields["destination"], jobStatus).Initialize(),
                new CopyCancelCCVMInitializer(jobStatus, new CopyCancelCommandInitializer(validator, settingsManager, textFields["source"], textFields["destination"], output, jobStatus).Initialize()).Initialize(),
                new OutputVMInitializer(output, jobStatus).Initialize(),
                overwriteVM,
                null, // TODO
                new AddJobCCVMInitializer(addJobShowDialog, jobList).Initialize(),
                new BatchListCVMInitializer(jobList).Initialize());
        }

        protected bool? addJobShowDialog(object? output)
        {
            var addCommand = new AddJobAddCommandInitializer(textFields["source"], textFields["destination"], validator).Initialize();
            var cancelCommand = new AddJobCancelCommandInitializer().Initialize();
            var window = new AddJobWindowInitializer(textFields, jobStatus, addCommand, cancelCommand).Initialize();
            addCommand.SetExecute(new AddJobAddCommandExecuteInitializer(validator, window, textFields["source"], textFields["destination"], jobList).Initialize());
            cancelCommand.SetExecute(() => window.Close());
            return window.ShowDialog() == true;
        }
    }
}

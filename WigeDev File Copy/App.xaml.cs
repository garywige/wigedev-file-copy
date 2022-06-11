using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WigeDev.Copier.Interfaces;
using WigeDev.Init.Implementations;
using WigeDev.Output.Interfaces;
using WigeDev.Settings.Interfaces;
using WigeDev.Validation.Interfaces;
using WigeDev.View.Windows;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev_File_Copy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App : Application
    {
        private Window window;
        private IJobStatus jobStatus;
        private IDictionary<string, ITextField> textFields;
        private IValidator validator;
        private IOutput output;
        private ISelectControlViewModel<ICopyStrategy> overwriteVM;
        private ISettingsManager settingsManager;
        private INotifyList<ICopyJobControlViewModel> jobList;

        public App()
        {
            window = initializeWindow();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            window.Show();
        }

        private Window initializeWindow()
        {
            textFields = new TextFieldInitializer().Initialize();
            validator = new ValidatorInitializer(textFields["source"], textFields["destination"]).Initialize();
            output = new OutputInitializer().Initialize();
            jobStatus = new JobStatusInitializer().Initialize();
            initOverwriteVM();
            settingsManager = new SettingsManagerInitializer(overwriteVM).Initialize();
            jobList = new BatchJobListInitializer().Initialize();

            // Main Window
            return new MainWindow(
                new FolderSelectionCVMInitializer("Source", textFields["source"], jobStatus).Initialize(),
                new FolderSelectionCVMInitializer("Destination", textFields["destination"], jobStatus).Initialize(),
                new CopyCancelCCVMInitializer(jobStatus, new CopyCancelCommandInitializer(validator, settingsManager, textFields["source"], textFields["destination"], output, jobStatus).Initialize()).Initialize(),
                initOutputVM(),
                overwriteVM,
                null, // TODO
                new AddJobCCVMInitializer(addJobShowDialog, jobList).Initialize(),
                new BatchListCVMInitializer(jobList).Initialize());
        }
        
        private bool? addJobShowDialog(object? output)
        {
            var addCommand = new AddJobAddCommandInitializer(textFields["source"], textFields["destination"], validator).Initialize();
            var cancelCommand = new AddJobCancelCommandInitializer().Initialize();
            var window = new AddJobWindowInitializer(textFields, jobStatus, addCommand, cancelCommand).Initialize();
            addCommand.SetExecute(new AddJobAddCommandExecuteInitializer(validator, window, textFields["source"], textFields["destination"], jobList).Initialize());
            cancelCommand.SetExecute(addJobCancelCommandExecute(window));
            return window.ShowDialog() == true;
        }

        private Action addJobCancelCommandExecute(Window window) => () => window.Close();
        private IOutputViewModel initOutputVM() => new OutputViewModel(output, jobStatus);
        private void initOverwriteVM() => overwriteVM = new OverwriteSelectControlViewModel<ICopyStrategy>("Overwrite Mode", (new CopyStrategyInitializer(output)).Initialize());

    }
}

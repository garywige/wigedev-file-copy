﻿using System;
using System.Windows;
using System.Windows.Input;
using WigeDev.Cancellation.Implementations;
using WigeDev.Copier.Implementations;
using WigeDev.Copier.Interfaces;
using WigeDev.Execute.Implementations;
using WigeDev.Init.Implementations;
using WigeDev.Output.Implementations;
using WigeDev.Output.Interfaces;
using WigeDev.Settings.Implementations;
using WigeDev.Settings.Interfaces;
using WigeDev.Validation.Implementations;
using WigeDev.Validation.Interfaces;
using WigeDev.View.Implementations;
using WigeDev.View.Windows;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;
using System.Collections.Generic;

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
            initOutput();
            initJobStatus();
            initOverwriteVM();
            initSettingsManager();
            initBatchJobList();

            // Main Window
            return new MainWindow(
                initFolderSelectionControlVM("Source", textFields["source"]),
                initFolderSelectionControlVM("Destination", textFields["destination"]),
                initCopyCancelCommandControlVM(new CopyCancelCommandInitializer(validator, settingsManager, textFields["source"], textFields["destination"], output, jobStatus).Initialize()),
                initOutputVM(),
                overwriteVM,
                initStartBatchCCVM(),
                initAddJobCCVM(),
                initBatchListCVM());
        }

        private ICommandControlViewModel initStartBatchCCVM()
        {
            // TODO
            return null;
        }
        
        private bool? addJobShowDialog(object? output)
        {
            var addCommand = new AddJobAddCommandInitializer(textFields["source"], textFields["destination"], validator).Initialize();
            var cancelCommand = initAddJobCancelCommand();
            var window = initAddJobWindow(addCommand, cancelCommand);
            addCommand.SetExecute(new AddJobAddCommandExecuteInitializer(validator, window, textFields["source"], textFields["destination"], jobList).Initialize());
            cancelCommand.SetExecute(addJobCancelCommandExecute(window));
            return window.ShowDialog() == true;
        }

        private void initOutput()
        {
            var outputList = new NotifyList<string>(new NotifyListEnumerator<string>());
            output = new BasicOutput(outputList);
        }

        private void initJobStatus() => jobStatus = new JobStatus();
        private void initSettingsManager() => settingsManager = new SettingsManager(overwriteVM);
        private void initBatchJobList() => jobList = new NotifyList<ICopyJobControlViewModel>(new NotifyListEnumerator<ICopyJobControlViewModel>());
        private IBatchListControlViewModel initBatchListCVM() => new BatchListControlViewModel(jobList);
        private Action addJobCancelCommandExecute(Window window) => () => window.Close();
        private Window initAddJobWindow(ICommand addCommand, ICommand cancelCommand) => new AddJobWindow(initFolderSelectionControlVM("Source", textFields["source"]), initFolderSelectionControlVM("Destination", textFields["destination"]),new CommandControlViewModel("Add", addCommand),new CommandControlViewModel("Cancel", cancelCommand));
        private SetExecuteCommand initAddJobCancelCommand() => new SetExecuteCommand(new Command(() => true, () => { }));
        private IFolderSelectionControlViewModel initFolderSelectionControlVM(string labelContent, ITextField textField) =>
            new FolderSelectionControlViewModel(labelContent, textField, jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter()));
        private ICommandControlViewModel initCopyCancelCommandControlVM(ICommand command) => new CopyCancelCommandControlViewModel(jobStatus, command);
        private IOutputViewModel initOutputVM() => new OutputViewModel(output, jobStatus);
        private void initOverwriteVM() => overwriteVM = new OverwriteSelectControlViewModel<ICopyStrategy>("Overwrite Mode", (new CopyStrategyInitializer(output)).Initialize());

        private ICommandControlViewModel initAddJobCCVM() =>
            new CommandControlViewModel("Add Job", new Command(() => true, () => (new AddJobExecute(new OutputWindowFactory(
                o => { },
                addJobShowDialog),
                jobList)).Execute()));

    }
}

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

namespace WigeDev_File_Copy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App : Application
    {
        private Window window;
        private IJobStatus jobStatus;
        private ITextField sourceTF;
        private ITextField destTF;
        private FormValidator formValidator;
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
            initTextFields();
            initValidators();
            initOutput();
            initJobStatus();
            initOverwriteVM();
            initSettingsManager();
            initBatchJobList();

            // Main Window
            return new MainWindow(
                initFolderSelectionControlVM("Source", sourceTF),
                initFolderSelectionControlVM("Destination", destTF),
                initCopyCancelCommandControlVM(new CopyCancelCommandInitializer(formValidator, settingsManager, sourceTF, destTF, output, jobStatus).Initialize()),
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
            var addCommand = new AddJobAddCommandInitializer(sourceTF, destTF, formValidator).Initialize();
            var cancelCommand = initAddJobCancelCommand();
            var window = initAddJobWindow(addCommand, cancelCommand);
            addCommand.SetExecute(new AddJobAddCommandExecuteInitializer(formValidator, window, sourceTF, destTF, jobList).Initialize());
            cancelCommand.SetExecute(addJobCancelCommandExecute(window));
            return window.ShowDialog() == true;
        }

        private void initTextFields()
        {
            sourceTF = new TextField();
            destTF = new TextField();
        }

        private void initValidators()
        {
            var validators = new IValidator[2];
            validators[0] = new PathValidator(sourceTF);
            validators[1] = new PathValidator(destTF);
            formValidator = new(validators);
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
        private Window initAddJobWindow(ICommand addCommand, ICommand cancelCommand) => new AddJobWindow(initFolderSelectionControlVM("Source", sourceTF), initFolderSelectionControlVM("Destination", destTF),new CommandControlViewModel("Add", addCommand),new CommandControlViewModel("Cancel", cancelCommand));
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

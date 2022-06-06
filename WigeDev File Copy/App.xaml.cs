using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WigeDev.Cancellation.Implementations;
using WigeDev.Copier.Implementations;
using WigeDev.Copier.Interfaces;
using WigeDev.Execute.Implementations;
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
        private IValidator[] validators;
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
                initCopyCancelCommandControlVM(initCopyCancelCommand()),
                initOutputVM(),
                overwriteVM,
                initStartBatchCCVM(),
                initAddJobCCVM(),
                initBatchListCVM());
        }

        private IFolderSelectionControlViewModel initFolderSelectionControlVM(string labelContent, ITextField textField)
        {
            return new FolderSelectionControlViewModel(labelContent, textField, jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter()));
        }

        private ICommandControlViewModel initCopyCancelCommandControlVM(ICommand command)
        {
            return new CopyCancelCommandControlViewModel(jobStatus, command);
        }

        private IOutputViewModel initOutputVM()
        {
            return new OutputViewModel(output, jobStatus);
        }

        private void initOverwriteVM()
        {

            ObservableCollection<ICopyStrategy> copyStrategies = new();
            copyStrategies.Add(new AllCopyStrategy(output));
            copyStrategies.Add(new NoneCopyStrategy(output));
            copyStrategies.Add(new OldCopyStrategy(output));
            overwriteVM = new OverwriteSelectControlViewModel<ICopyStrategy>("Overwrite Mode", copyStrategies);
        }

        private ICommandControlViewModel initStartBatchCCVM()
        {
            return null;
        }

        private ICommandControlViewModel initAddJobCCVM()
        {
            var addJobExecute = new AddJobExecute(new OutputWindowFactory(
                o => { },
                addJobShowDialog),
                jobList);
            return new CommandControlViewModel("Add Job", new Command(() => true, () => addJobExecute.Execute()));
        }

        private bool? addJobShowDialog(object? output)
        {
            EventHandler? textChanged = null;
            sourceTF.PropertyChanged += (s, e) => textChanged?.Invoke(this, e);
            destTF.PropertyChanged += (s, e) => textChanged?.Invoke(this, e);

            var addCommand = new SetExecuteCommand(new CECCommand(new Command(
                            () => validators.Where(v => !v.IsValid).Count() == 0,
                            () => { }
                            ), ref textChanged));

            var cancelCommand = new SetExecuteCommand(new Command(
                () => true,
                () => { }));

            var window = new AddJobWindow(
                        initFolderSelectionControlVM("Source", sourceTF),
                        initFolderSelectionControlVM("Destination", destTF),
                        new CommandControlViewModel("Add", addCommand),
                        new CommandControlViewModel("Cancel", cancelCommand));

            addCommand.SetExecute(() =>
            {
                window.Close();
                var copyJobVM = new CopyJobControlViewModel(sourceTF.Text, destTF.Text, null, null);
                jobList.Add(copyJobVM);
            });

            cancelCommand.SetExecute(() =>
            {
                window.Close();
            });

            if (window.ShowDialog() == true)
            {
                return true;
            }
            return false;
        }

        private IBatchListControlViewModel initBatchListCVM()
        {
            return new BatchListControlViewModel(jobList);
        }

        private void initBatchJobList()
        {
            jobList = new NotifyList<ICopyJobControlViewModel>(new NotifyListEnumerator<ICopyJobControlViewModel>());
        }

        private ICommand initCopyCancelCommand()
        {
            var copyCancelCommand = new CopyCancelCommand(
                new FormValidator(validators),
                new CopyCancelExecute(
                    new Copier(
                    new FileEnumerator(settingsManager),
                    sourceTF,
                    destTF,
                    output,
                    new PathConstructor(),
                    new CancellationManager(),
                    jobStatus),
                    jobStatus));

            sourceTF.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();
            destTF.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();

            return copyCancelCommand;
        }

        private void initTextFields()
        {
            sourceTF = new TextField();
            destTF = new TextField();
        }

        private void initValidators()
        {
            validators = new IValidator[2];
            validators[0] = new PathValidator(sourceTF);
            validators[1] = new PathValidator(destTF);
        }

        private void initOutput()
        {
            var outputList = new NotifyList<string>(new NotifyListEnumerator<string>());
            output = new BasicOutput(outputList);
        }

        private void initJobStatus()
        {
            jobStatus = new JobStatus();
        }

        private void initSettingsManager()
        {
            settingsManager = new SettingsManager(overwriteVM);
        }
    }
}

using System.Collections.ObjectModel;
using System.Windows;
using WigeDev.Cancellation.Implementations;
using WigeDev.Copier.Implementations;
using WigeDev.Copier.Interfaces;
using WigeDev.Execute.Implementations;
using WigeDev.Output.Implementations;
using WigeDev.Settings.Implementations;
using WigeDev.Validation.Implementations;
using WigeDev.Validation.Interfaces;
using WigeDev.View;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev_File_Copy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App : Application
    {
        private MainWindow window;

        public App()
        {
            // TextFields
            var source = new TextField();
            var dest = new TextField();

            // Validators
            var validators = new IValidator[2];
            validators[0] = new PathValidator(source);
            validators[1] = new PathValidator(dest);

            // Output
            var outputList = new NotifyList<string>(new NotifyListEnumerator<string>());
            var output = new BasicOutput(outputList);
            var jobStatus = new JobStatus();

            // SettingsManager
            ObservableCollection<ICopyStrategy> copyStrategies = new();
            copyStrategies.Add(new AllCopyStrategy(output));
            copyStrategies.Add(new NoneCopyStrategy(output));
            copyStrategies.Add(new OldCopyStrategy(output));
            var overwriteVM = new OverwriteSelectControlViewModel<ICopyStrategy>("Overwrite Mode", copyStrategies);
            var settingsManager = new SettingsManager(overwriteVM);

            // Command
            var copyCancelCommand = new CopyCancelCommand(
                new FormValidator(validators),
                new CopyCancelExecute(
                    new Copier(
                    new FileEnumerator(settingsManager),
                    source,
                    dest,
                    output,
                    new PathConstructor(),
                    new CancellationManager(),
                    jobStatus), 
                    jobStatus));

            source.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();
            dest.PropertyChanged += (s, e) => copyCancelCommand.TestCanExecute();

            // Main Window
            window = new MainWindow(
                new FolderSelectionControlViewModel("Source", source, jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter())),
                new FolderSelectionControlViewModel("Destination", dest, jobStatus, new BrowseCommand(new FolderBrowserDialogAdapter())),
                new CopyCancelCommandControlViewModel(jobStatus, copyCancelCommand),
                new OutputViewModel(output, jobStatus),
                overwriteVM,
                null,
                new CommandControlViewModel("Add Job", new Command(() => true, null)),
                new BatchListControlViewModel(new NotifyList<ICopyJobControlViewModel>(new NotifyListEnumerator<ICopyJobControlViewModel>())));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            window.Show();
        }
    }
}

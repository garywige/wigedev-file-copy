﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WigeDev.Cancellation.Implementations;
using WigeDev.Copier.Implementations;
using WigeDev.Output.Implementations;
using WigeDev.Validation.Implementations;
using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.View;
using WigeDev.Settings.Implementations;
using WigeDev.Copier.Interfaces;

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
            var validators = new List<IValidator>();
            validators.Add(new PathValidator(source));
            validators.Add(new PathValidator(dest));

            // Output
            var outputList = new ObservableCollection<string>();
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
                new CommandControlViewModel(jobStatus, copyCancelCommand),
                new OutputViewModel(output, jobStatus),
                overwriteVM,
                null,
                null,
                null);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            window.Show();
        }
    }
}

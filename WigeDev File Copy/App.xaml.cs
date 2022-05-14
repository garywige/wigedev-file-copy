using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using WigeDev.Model.Implementations;
using WigeDev.Validation.Implementations;
using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Implementations;

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
            var source = new TextField();
            var dest = new TextField();
            var validators = new List<IValidator>();
            validators.Add(new PathValidator(source));
            validators.Add(new PathValidator(dest));

            var copyCancelCommand = new CopyCancelCommand(
                new FormValidator(validators),
                new CopyCancelExecute(null));

            var propertyChanged = new PropertyChangedEventHandler((s, e) => copyCancelCommand.TestCanExecute());

            window = new MainWindow(new ViewModel(
                source, 
                dest, 
                copyCancelCommand, 
                new List<string>(),
                propertyChanged
                ));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            window.Show();
        }
    }
}

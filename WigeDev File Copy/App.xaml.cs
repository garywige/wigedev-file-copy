using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using WigeDev.Model.Implementations;
using WigeDev.ViewModel.Implementations;
using WigeDev.Validation.Implementations;
using WigeDev.Validation.Interfaces;

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
                null);

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

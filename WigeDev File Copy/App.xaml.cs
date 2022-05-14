using System.Collections.Generic;
using System.Windows;
using WigeDev.Model.Implementations;
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
            window = new MainWindow(new ViewModel(
                new TextField(), 
                new TextField(), 
                null, 
                new List<string>()
                ));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            window.Show();
        }
    }
}

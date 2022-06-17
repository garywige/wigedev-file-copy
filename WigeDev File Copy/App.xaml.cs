using System.Windows;
using WigeDev.Init.Implementations;

namespace WigeDev_File_Copy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public sealed partial class App : Application
    {
        private Window? window;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            window = new WindowInitializer().Initialize();
            window.Show();
        }

    }
}

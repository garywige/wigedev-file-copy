using System.Windows;
using System.Windows.Controls;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev_File_Copy
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private IViewModel viewModel;

        public MainWindow(IViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.DataContext = this.viewModel;
        }

        private void ListBox_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            var listBox = sender as ListBox;
            if(listBox != null)
            {
                if(!listBox.Items.MoveCurrentToLast())
                    listBox.ScrollIntoView(listBox.Items.CurrentItem);
            }
        }
    }
}

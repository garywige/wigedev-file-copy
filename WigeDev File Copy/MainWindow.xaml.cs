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

            this.viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Output")
                    outputScrollToBottom();
            };
            
        }

        private void outputScrollToBottom()
        { 
            outputListBox.Items.MoveCurrentToLast();
            outputListBox.ScrollIntoView(outputListBox.Items.CurrentItem);
        }
    }
}

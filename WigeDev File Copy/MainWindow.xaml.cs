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
        public MainWindow(IViewModel viewModel, IFolderSelectionControlViewModel sourceViewModel, IFolderSelectionControlViewModel destViewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            sourceSelection.DataContext = sourceViewModel;
            destinationSelection.DataContext = destViewModel;

            viewModel.PropertyChanged += (s, e) =>
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

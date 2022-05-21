using System.Windows.Controls;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.View
{
    /// <summary>
    /// Interaction logic for OutputControl.xaml
    /// </summary>
    public partial class OutputControl : UserControl
    {
        public OutputControl()
        {
            InitializeComponent();
        }

        public void SetViewModel(IOutputViewModel viewModel)
        {
            DataContext = viewModel;
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

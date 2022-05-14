using System.Windows;
using System.Collections.Generic;

namespace WigeDev_File_Copy
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void outputScrollToBottom()
        {
            outputListBox.Items.MoveCurrentToLast();
            outputListBox.ScrollIntoView(outputListBox.Items.CurrentItem);
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // TODO: validation
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: copy or cancel
        }
    }
}

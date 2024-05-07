using Microsoft.Win32;
using System.Windows;


namespace finance
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new();
            this.DataContext = mainViewModel;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        // Get the file path
        //        string filePath = openFileDialog.FileName;

        //        // Set the file path to ViewModel property
        //        ((MainViewModel)this.DataContext).FilePath = filePath;

        //        // Limit the length of the displayed file path
        //        const int maxLength = 20; // Maximum length of the displayed file path
        //        if (filePath.Length > maxLength)
        //        {
        //            // Truncate the file path
        //            string truncatedPath = "..." + filePath.Substring(filePath.Length - maxLength);
        //            ((MainViewModel)this.DataContext).FilePath = truncatedPath;
        //        }

        //        // Make the TextBlock visible to display the file path
        //       // FilePathTextBlock.Visibility = Visibility.Visible;
        //    }
        //}

    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using finance.viewmodel;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;

namespace finance
{
    public partial class MainViewModel : BaseViewModel
    {

        [ObservableProperty]
        public string? filePath;

        [ObservableProperty]
        public string? selectedOption;

        private string? option;
        // Icommand to iniate File path search
        public ICommand GetFilePathCommand { get; }

        // Icommmand to submit select file
        public ICommand SubmitFileCommand { get; }

        public MainViewModel() {

            GetFilePathCommand = new RelayCommand(param => GetFilePath());
            SubmitFileCommand = new RelayCommand(param => SubmitFile());
        }
        

        
        private void GetFilePath()
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
            }
        }
        // Submit trigger for file
        private void SubmitFile()
        {
            if (SelectedOption != null)
            {
                option = ExtractDataAfterColon(SelectedOption);
            }
            if (option != null)
            {
                if(option == "UPS" && FilePath is not null)
                {
                    var _invoice = ExcelProcessor.ProcessUpsExcel(FilePath);
                }
            }
        }

        // Method to extract the string from the ComboBoxItem
        private static string? ExtractDataAfterColon(string text)
        {
            int index = text.IndexOf(":");
            if (index != -1)
            {
                // Adding 1 to skip the colon itself
                return text.Substring(index + 1).Trim();
            }
            else
            {
                return null;
            }
        }
    }
}

      
    

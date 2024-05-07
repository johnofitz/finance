using ClosedXML.Excel; // Import ClosedXML namespace
using System.Text.RegularExpressions;

namespace finance
{
    public partial class ExcelProcessor
    {
        public static List<UpsInvoice> ProcessUpsExcel(string filePath)
        {
            List<UpsInvoice> dataList = new();
            // Load Excel file using ClosedXML
            using (XLWorkbook workbook = new(filePath))
            {
                // Assuming its the first worksheet
                IXLWorksheet worksheet = workbook.Worksheet(1);

                // Determine the column index for each required column with ups
                // if UPS ever changes these will need to be altered
                int columnIndexF5 = 5;
                int columnIndexF6 = 6;
                int columnIndexF12 = 12;
                int columnIndexF16 = 16;
                int columnIndexF19 = 19;
                int columnIndexF53 = 53;

                // Get the count of used rows
                int rowCount = worksheet.RowsUsed().Count(); 
                // Excel is not 0th index 
                for (int row = 1; row <= rowCount; row++) 
                {
                    string jobNumberCell = worksheet.Cell(row, columnIndexF16).Value.ToString();

                    // Check if the job number cell contains a number
                    if (MyRegex().IsMatch(jobNumberCell))
                    {
                        // Extract only the numeric part of the job number
                        int jobNumber = int.Parse(MyRegex().Match(jobNumberCell).Value);

                        // Create UpsInvoice object and populate its properties
                        UpsInvoice invoice = new()
                        {
                            InvoiceDownLoadDate = worksheet.Cell(row, columnIndexF5).Value.ToString(),
                            InvoiceNumber = worksheet.Cell(row, columnIndexF6).Value.ToString(),
                            DeliveryDate = worksheet.Cell(row, columnIndexF12).Value.ToString(),
                            JobNumber = jobNumber,
                            Parcels = worksheet.Cell(row, columnIndexF19).Value.ToString(),
                            BaseRate = worksheet.Cell(row, columnIndexF53).Value.ToString()
                        };
                        dataList.Add(invoice);
                    }
                }
            }
            return dataList;
        }

        [GeneratedRegex(@"\d+")]
        private static partial Regex MyRegex();
 
    }
}

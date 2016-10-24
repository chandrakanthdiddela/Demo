using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class excelsample
    {
      // Given a document name, a worksheet name, the name of the first cell in the contiguous range, 
// the name of the last cell in the contiguous range, and the name of the results cell, 
// calculates the sum of the cells in the contiguous range and inserts the result into the results cell.
// Note: All cells in the contiguous range must contain numbers.
private static void CalculateSumOfCellRange(string docName, string worksheetName, string firstCellName, string lastCellName, string resultCell)
{
    // Open the document for editing.
    using (SpreadsheetDocument document = SpreadsheetDocument.Open(docName, true))
    {
        IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == worksheetName);
        if (sheets.Count() == 0)
        {
            // The specified worksheet does not exist.
            return; 
        }

        WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheets.First().Id);
        Worksheet worksheet = worksheetPart.Worksheet;

        // Get the row number and column name for the first and last cells in the range.
        uint firstRowNum = GetRowIndex(firstCellName);
        uint lastRowNum = GetRowIndex(lastCellName);
        string firstColumn = GetColumnName(firstCellName);
        string lastColumn = GetColumnName(lastCellName);

        double sum = 0;

        // Iterate through the cells within the range and add their values to the sum.
        foreach (Row row in worksheet.Descendants<Row>().Where(r => r.RowIndex.Value >= firstRowNum && r.RowIndex.Value <= lastRowNum))
        {
            foreach (Cell cell in row)
            {
                string columnName = GetColumnName(cell.CellReference.Value);
                if (CompareColumn(columnName, firstColumn) >= 0 && CompareColumn(columnName, lastColumn) <= 0)
                {
                    sum += double.Parse(cell.CellValue.Text);
                }
            }
        }

        // Get the SharedStringTablePart and add the result to it.
        // If the SharedStringPart does not exist, create a new one.
        SharedStringTablePart shareStringPart;
        if (document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
        {
            shareStringPart = document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
        }
        else
        {
            shareStringPart = document.WorkbookPart.AddNewPart<SharedStringTablePart>();
        }

        // Insert the result into the SharedStringTablePart.
        int index = InsertSharedStringItem("Result:" + sum, shareStringPart);

        Cell result = InsertCellInWorksheet(GetColumnName(resultCell), GetRowIndex(resultCell), worksheetPart);

        // Set the value of the cell.
        result.CellValue = new CellValue(index.ToString());
        result.DataType = new EnumValue<CellValues>(CellValues.SharedString);

        worksheetPart.Worksheet.Save();
    }
}
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

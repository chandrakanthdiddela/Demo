using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace SampleExcelReadApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Application lobjExcelApp = new Application();
            Workbooks lobjwork = lobjExcelApp.Workbooks;
         Workbook lobjWorkbook=         lobjExcelApp.Workbooks.Open(@"D:\Book1", Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing);

   Sheets lobjsheets = lobjWorkbook.Worksheets;
   IEnumerator lobjenumerator = lobjWorkbook.Worksheets.GetEnumerator();
            int workbooksheetcount = lobjWorkbook.Worksheets.Count;
            for (int i = 1; i < workbooksheetcount - 1; i++)
            {
                Worksheet sheet = (Worksheet)lobjWorkbook.Sheets[i];

                Range lobjExcelsheetrange = sheet.UsedRange;
                object[,] valueArray = (object[,])lobjExcelsheetrange.get_Value(
        XlRangeValueDataType.xlRangeValueDefault);

            }
            //
	// Clean up.
	//
            lobjWorkbook.Close(false, @"D:\Book1", null);
    Marshal.ReleaseComObject(lobjWorkbook);

    Console.ReadKey();
    }
    catch
    {
	//
	// Deal with exceptions.
	//
    }

           

        }
    }
}

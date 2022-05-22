// See https://aka.ms/new-console-template for more information

using Syncfusion.XlsIO;
using System;

namespace ArtWorkPromotion.Seed
{
    class Program
    {
        public static void Main()
        {
            string path = "seed data art promotion.xlsx";
            //Creates a new instance for ExcelEngine
            ExcelEngine excelEngine = new ExcelEngine();

            //Loads or open an existing workbook through Open method of IWorkbooks
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(path);
        }

    }

}



using ArtWorkPromotion.PCL.Helpers;
using ArtWorkPromotion.PCL.Models;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArtWorkPromotion.Seed
{
    class Program
    {
        private static List<ArtWork> ArtWorks = new List<ArtWork>();
        public static void Main()
        {
            LoadArtWorksFromExcel();
           

            foreach (var art in ArtWorks)
            {

            }

        }

        private static void LoadArtWorksFromExcel()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "SeedData/seed data art promotion.xlsx");
            var stream = new FileStream(path, FileMode.Open);

            //Creates a new instance for ExcelEngine
            ExcelEngine excelEngine = new ExcelEngine();

            //Loads or open an existing workbook through Open method of IWorkbooks
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(stream);

            //Access the first worksheet
            IWorksheet worksheet = workbook.Worksheets[0];

            //Access the used range of the Excel file
            IRange usedRange = worksheet.UsedRange;
            int lastRow = usedRange.LastRow;
            int lastColumn = usedRange.LastColumn;

            //Iterate the cells in the used range and print the display text
            for (int row = 2; row <= lastRow; row++)
            {
                var artWork = new ArtWork
                {
                    Id=null,
                    Name = worksheet[row, 1].DisplayText,
                    Description = worksheet[row, 2].DisplayText,
                    Location = worksheet[row, 3].DisplayText,
                    Price = double.Parse(worksheet[row, 4].DisplayText),
                    Category = (Category)Enum.Parse(typeof(Category), worksheet[row, 5].DisplayText)
                };

                ArtWorks.Add(artWork);
            }

        }
    }

}



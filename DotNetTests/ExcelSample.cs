namespace DotNetTests
{
    using System;
    using System.IO;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;

    public class ExcelSample
    {
        public void CreateNewBook(string path, string sheetName)
        {
            try
            {
                IWorkbook book = new XSSFWorkbook();
                book.CreateSheet(sheetName);

                // ブックを保存
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

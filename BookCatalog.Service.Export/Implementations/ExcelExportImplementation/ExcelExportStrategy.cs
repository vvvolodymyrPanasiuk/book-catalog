using BookCatalog.Domain.Entities.BookAggregate;
using OfficeOpenXml;

namespace BookCatalog.Service.Export.Implementations.ExcelExportImplementation
{
    public class ExcelExportStrategy : IExportStrategy
    {
        public byte[] Export(IEnumerable<Book> books)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Books");

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Title";
                worksheet.Cells[1, 3].Value = "Publication Date";
                worksheet.Cells[1, 4].Value = "Description";
                worksheet.Cells[1, 5].Value = "Page Count";

                var row = 2;
                foreach (var book in books)
                {
                    worksheet.Cells[row, 1].Value = book.Id;
                    worksheet.Cells[row, 2].Value = book.Title;
                    worksheet.Cells[row, 3].Value = book.PublicationDate;
                    worksheet.Cells[row, 4].Value = book.Description;
                    worksheet.Cells[row, 5].Value = book.PageCount;
                    row++;
                }

                var stream = new MemoryStream(package.GetAsByteArray());
                return stream.ToArray();
            }
        }
    }
}

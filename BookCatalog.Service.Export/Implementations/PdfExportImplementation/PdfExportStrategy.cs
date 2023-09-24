using BookCatalog.Domain.Entities.BookAggregate;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;

namespace BookCatalog.Service.Export.Implementations.PdfExportImplementation
{
    public class PdfExportStrategy : IExportStrategy
    {
        public byte[] Export(IEnumerable<Book> books)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                PdfPTable table = new PdfPTable(5);
                table.AddCell("Id");
                table.AddCell("Title");
                table.AddCell("Publication Date");
                table.AddCell("Description");
                table.AddCell("Page Count");

                foreach (var book in books)
                {
                    table.AddCell(book.Id.ToString());
                    table.AddCell(book.Title);
                    table.AddCell(book.PublicationDate.ToString("yyyy-MM-dd"));
                    table.AddCell(book.Description);
                    table.AddCell(book.PageCount.ToString());
                }

                document.Add(table);
                document.Close();

                return ms.ToArray();
            }
        }
    }
}
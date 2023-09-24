using BookCatalog.Domain.Entities.BookAggregate;

namespace BookCatalog.Service.Export
{
    /// <summary>
    /// Represents an interface for exporting data to a specific format.
    /// </summary>
    public interface IExportStrategy
    {
        /// <summary>
        /// Exports a collection of books to a specific format and returns the exported data as a byte array.
        /// </summary>
        /// <param name="books">The collection of books to export.</param>
        /// <returns>The exported data as a byte array.</returns>
        byte[] Export(IEnumerable<Book> books);
    }
}

using BookCatalog.Domain.Entities.BookAggregate;

namespace BookCatalog.Domain.Repositories.BookRepository
{
    /// <summary>
    /// Represents a repository for managing books.
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// Gets all books by title.
        /// </summary>
        /// <param name="title">The title to search books.</param>
        /// <returns>A list of book`s entities.</returns>
        Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title);

        /// <summary>
        /// Gets sorted books by title.
        /// </summary>
        /// <param name="sorterFilterBy">The filter to sorting books.</param>
        /// <param name="ascending">The ascending sorting.</param>
        /// <returns>A list of sorted book`s entities.</returns>
        Task<IEnumerable<Book>> SortBooksAsync(string sorterFilterBy, bool ascending);

        /// <summary>
        /// Gets filtered books by сustom date.
        /// </summary>
        /// <param name="startDate">The start data of publication.</param>
        /// <param name="endDate">The end data of publication.</param>
        /// <returns>A list of filtered book`s entities.</returns>
        Task<IEnumerable<Book>> FilterBooksByCustomDatePublicationAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Gets filtered books by this month.
        /// </summary>
        /// <returns>A list of filtered book`s entities.</returns>
        Task<IEnumerable<Book>> FilterBooksByThisMonthPublicationAsync();

        /// <summary>
        /// Gets filtered books by this year.
        /// </summary>
        /// <returns>A list of filtered book`s entities.</returns>
        Task<IEnumerable<Book>> FilterBooksByThisYearPublicationAsync();

        /// <summary>
        /// Gets the count of books by publication year.
        /// </summary>
        /// <returns>A dictionary with the publication year as the key and the count of books as the value.</returns>
        Task<Dictionary<int, int>> GetBooksCountByPublicationYearAsync();
    }
}

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
    }
}

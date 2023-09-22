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
        /// <returns>A list of book`s entities.</returns>
        Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title);
    }
}

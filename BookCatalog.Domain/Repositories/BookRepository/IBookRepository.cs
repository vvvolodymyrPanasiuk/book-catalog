using BookCatalog.Domain.Entities.BookAggregate;

namespace BookCatalog.Domain.Repositories.BookRepository
{
    /// <summary>
    /// Represents a repository for managing books.
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title);
    }
}

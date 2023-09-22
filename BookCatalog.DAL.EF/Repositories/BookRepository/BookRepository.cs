using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Domain.Repositories.BookRepository;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.DAL.EF.Repositories.BookRepository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookCatalogDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return await GetAll().Take(5).ToListAsync();
            }

            return await _dbSet
                .Where(book => book.Title.Contains(title))
                .ToListAsync();
        }
    }
}

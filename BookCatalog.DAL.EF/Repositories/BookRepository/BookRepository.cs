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

        public async Task<IEnumerable<Book>> SortBooksAsync(string sortBy, bool ascending)
        {
            var query = _dbSet.AsQueryable();

            switch (sortBy.ToLower())
            {
                case "title":
                    query = ascending ? query.OrderBy(b => b.Title) : query.OrderByDescending(b => b.Title);
                    break;
                case "publicationdate":
                    query = ascending ? query.OrderBy(b => b.PublicationDate) : query.OrderByDescending(b => b.PublicationDate);
                    break;
                case "pagecount":
                    query = ascending ? query.OrderBy(b => b.PageCount) : query.OrderByDescending(b => b.PageCount);
                    break;
                default:
                    break;
            }

            return await query.ToListAsync();
        }
    }
}

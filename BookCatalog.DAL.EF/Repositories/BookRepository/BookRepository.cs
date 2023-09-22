using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Domain.Repositories.BookRepository;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.DAL.EF.Repositories.BookRepository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookCatalogDbContext context) : base(context) {}


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

        public async Task<IEnumerable<Book>> FilterBooksByCustomDatePublicationAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(book => book.PublicationDate >= startDate && book.PublicationDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> FilterBooksByThisMonthPublicationAsync()
        {
            DateTime currentDate = DateTime.Now;
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            return await FilterBooksByCustomDatePublicationAsync(firstDayOfMonth, lastDayOfMonth);
        }

        public async Task<IEnumerable<Book>> FilterBooksByThisYearPublicationAsync()
        {
            DateTime currentDate = DateTime.Now;
            DateTime firstDayOfYear = new DateTime(currentDate.Year, 1, 1);
            DateTime lastDayOfYear = new DateTime(currentDate.Year, 12, 31);

            return await FilterBooksByCustomDatePublicationAsync(firstDayOfYear, lastDayOfYear);
        }
    }
}

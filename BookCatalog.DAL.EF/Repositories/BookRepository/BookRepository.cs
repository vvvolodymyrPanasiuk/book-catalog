using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Domain.Repositories.BookRepository;

namespace BookCatalog.DAL.EF.Repositories.BookRepository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookCatalogDbContext context) : base(context)
        {
        }
    }
}

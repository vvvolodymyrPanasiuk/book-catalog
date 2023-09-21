using BookCatalog.Domain.Entities.BookAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookCatalog.DAL.EF
{
    public class BookCatalogDbContext : DbContext
    {
        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
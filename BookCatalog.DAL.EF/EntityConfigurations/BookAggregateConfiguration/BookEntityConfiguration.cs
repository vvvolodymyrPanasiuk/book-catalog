using BookCatalog.Domain.Entities.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalog.DAL.EF.EntityConfigurations.BookAggregateConfiguration
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.PublicationDate)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.PageCount)
                .IsRequired();


            builder.HasIndex(b => b.Title);
            builder.HasIndex(b => b.PublicationDate);
            builder.HasIndex(b => b.PageCount);

            builder.HasData(SeedData());
        }

        private IEnumerable<Book> SeedData()
        {
            var books = new List<Book>();
            var today = DateTime.Today;

            for (int i = 0; i < 50; i++)
            {
                var book = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = $"Book {i}",
                    PublicationDate = today.AddDays(-i),
                    Description = $"Description for Book {i}",
                    PageCount = i * 10
                };

                if (i % 5 == 0)
                {
                    book.PublicationDate = today.AddDays(-i * 2);
                    book.PageCount = i * 1;
                }

                books.Add(book);
            }

            return books;
        }
    }
}

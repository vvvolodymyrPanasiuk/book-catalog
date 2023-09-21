namespace BookCatalog.Domain.Entities.BookAggregate
{
    /// <summary>
    /// Represents a book entity.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the publication date of the book.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the description of the book.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of pages in the book.
        /// </summary>
        public int PageCount { get; set; }
    }
}

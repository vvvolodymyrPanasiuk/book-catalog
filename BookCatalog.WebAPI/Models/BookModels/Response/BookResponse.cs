using System;

namespace BookCatalog.WebAPI.Models.BookModels.Response
{
    /// <summary>
    /// Response object for retrieving book information.
    /// </summary>
    public class BookResponse
    {
        /// <summary>
        /// The unique identifier of the book.
        /// </summary>
        /// <remarks>
        /// Unique identifier assigned to each book.
        /// </remarks>
        /// <example>
        /// "c5d7f92f-8b32-4bf9-8710-ef634cb4f5d7"
        /// </example>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the book.
        /// </summary>
        /// <remarks>
        /// The title of the book.
        /// </remarks>
        /// <example>
        /// "The Great Gatsby"
        /// </example>
        public string Title { get; set; }

        /// <summary>
        /// The publication date of the book.
        /// </summary>
        /// <remarks>
        /// The date when the book was published.
        /// </remarks>
        /// <example>
        /// "2023-09-21"
        /// </example>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// The description of the book.
        /// </summary>
        /// <remarks>
        /// A brief description of the book.
        /// </remarks>
        /// <example>
        /// "A classic novel by F. Scott Fitzgerald."
        /// </example>
        public string Description { get; set; }

        /// <summary>
        /// The page count of the book.
        /// </summary>
        /// <remarks>
        /// The number of pages in the book.
        /// </remarks>
        /// <example>
        /// 256
        /// </example>
        public int PageCount { get; set; }


        public BookResponse(
            Guid id, 
            string title, 
            DateTime publicationDate, 
            string description, 
            int pageCount)
        {
            Id = id;
            Title = title;
            PublicationDate = publicationDate;
            Description = description;
            PageCount = pageCount;
        }
    }
}

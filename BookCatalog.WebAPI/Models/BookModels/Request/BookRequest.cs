using System.ComponentModel.DataAnnotations;
using System;

namespace BookCatalog.WebAPI.Models.BookModels.Request
{
    /// <summary>
    /// Request object for creating or updating a book.
    /// </summary>
    public class BookRequest
    {
        /// <summary>
        /// The title of the book.
        /// </summary>
        /// <remarks>
        /// The title must not exceed 150 characters.
        /// </remarks>
        /// <example>
        /// The Great Gatsby
        /// </example>
        [Required(ErrorMessage = "The 'Title' field is required.")]
        [MaxLength(150, ErrorMessage = "The title cannot exceed 150 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// The publication date of the book.
        /// </summary>
        /// <remarks>
        /// The date must be in a valid date format.
        /// </remarks>
        /// <example>
        /// 2023-09-21
        /// </example>
        [Required(ErrorMessage = "The 'Publication Date' field is required.")]
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// The description of the book.
        /// </summary>
        /// <remarks>
        /// The description is a required field.
        /// </remarks>
        /// <example>
        /// A classic novel by F. Scott Fitzgerald.
        /// </example>
        [Required(ErrorMessage = "The 'Description' field is required.")]
        public string Description { get; set; }

        /// <summary>
        /// The page count of the book.
        /// </summary>
        /// <remarks>
        /// The page count must be a positive integer.
        /// </remarks>
        /// <example>
        /// 256
        /// </example>
        [Required(ErrorMessage = "The 'Page Count' field is required.")]
        public int PageCount { get; set; }
    }
}

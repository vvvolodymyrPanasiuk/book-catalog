using System.ComponentModel.DataAnnotations;
using System;

namespace BookCatalog.WebAPI.Models.BookModels.Request
{
    public class BookRequest
    {
        [Required(ErrorMessage = "The 'Title' field is required.")]
        [MaxLength(150, ErrorMessage = "The title cannot exceed 150 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The 'Publication Date' field is required.")]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "The 'Description' field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The 'Page Count' field is required.")]
        public int PageCount { get; set; }
    }
}

using System;

namespace BookCatalog.WebAPI.Models.BookModels.Response
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
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

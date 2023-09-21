using AutoMapper;
using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.WebAPI.Models.BookModels.Request;
using BookCatalog.WebAPI.Models.BookModels.Response;

namespace BookCatalog.WebAPI.Models.BookModels
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<BookRequest, Book>();
        }
    }
}

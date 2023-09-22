using AutoMapper;
using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Domain.Repositories.BookRepository;
using BookCatalog.WebAPI.Models.BookModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCatalog.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SortingController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public SortingController(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Sorts books by the specified field.
        /// </summary>
        /// <param name="field">The field to sort by (e.g., "title", "publicationDate", "pageCount").</param>
        /// <param name="ascending">True for ascending order, false for descending order.</param>
        /// <returns>Returns a sorted list of books.</returns>
        /// <response code="200">Returns status 200 (OK) with a sorted list of books.</response>
        /// <response code="400">If the field parameter is invalid.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SortBooks([FromQuery] string field, [FromQuery] bool ascending = true)
        {
            if(field != "title" || field != "publicationdate" || field != "pagecount")
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var books = await _bookRepository.SortBooksAsync(field, ascending);

            var bookResponses = _mapper.Map<IEnumerable<BookResponse>>(books);

            return StatusCode(StatusCodes.Status200OK, bookResponses);
        }
    }
}

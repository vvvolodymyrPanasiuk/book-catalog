using AutoMapper;
using BookCatalog.Domain.Repositories.BookRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookCatalog.WebAPI.Models.BookModels.Response;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace BookCatalog.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public SearchController(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Searches for books by title.
        /// </summary>
        /// <param name="query">The search query string.</param>
        /// <returns>Returns status 200 (OK) with a list of books matching the search query or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) with a list of books matching the search query.</response>
        /// <response code="404">If no books match the search query.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet("title")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchBooksByTitle([FromQuery] string query)
        {
            var books = await _bookRepository.SearchBooksByTitleAsync(query);

            if (books == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var bookResponses = _mapper.Map<IEnumerable<BookResponse>>(books);

            return StatusCode(StatusCodes.Status200OK, bookResponses);
        }

    }
}

using BookCatalog.Domain.Repositories.BookRepository;
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
    public class BookChartController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookChartController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Gets the count of books by publication year.
        /// </summary>
        /// <returns>Returns status 200 (OK) with data or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) with data.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<int, int>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet("books-count-by-year")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBooksCountByPublicationYear()
        {
            var booksCountByYear = await _bookRepository.GetBooksCountByPublicationYearAsync();
            return StatusCode(StatusCodes.Status200OK, booksCountByYear);
        }
    }
}

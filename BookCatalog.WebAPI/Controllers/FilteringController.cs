using AutoMapper;
using BookCatalog.Domain.Repositories.BookRepository;
using BookCatalog.WebAPI.Models.BookModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BookCatalog.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FilteringController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public FilteringController(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Filters books by a custom date range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>Returns status 200 (OK) with a list of books matching the date range or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) with a list of books matching the date range.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet("custom-date")]
        [AllowAnonymous]
        public async Task<IActionResult> FilterBooksByCustomDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var books = await _bookRepository.FilterBooksByCustomDatePublicationAsync(startDate, endDate);

            var bookResponses = _mapper.Map<IEnumerable<BookResponse>>(books);

            return StatusCode(StatusCodes.Status200OK, bookResponses);
        }


        /// <summary>
        /// Filters books for this month.
        /// </summary>
        /// <returns>Returns status 200 (OK) with a list of books published this month or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) with a list of books published this month.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet("this-month")]
        [AllowAnonymous]
        public async Task<IActionResult> FilterBooksByThisMonth()
        {
            var books = await _bookRepository.FilterBooksByThisMonthPublicationAsync();

            var bookResponses = _mapper.Map<IEnumerable<BookResponse>>(books);

            return StatusCode(StatusCodes.Status200OK, bookResponses);
        }


        /// <summary>
        /// Filters books for this year.
        /// </summary>
        /// <returns>Returns status 200 (OK) with a list of books published this year or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) with a list of books published this year.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet("this-year")]
        [AllowAnonymous]
        public async Task<IActionResult> FilterBooksByThisYear()
        {
            var books = await _bookRepository.FilterBooksByThisYearPublicationAsync();

            var bookResponses = _mapper.Map<IEnumerable<BookResponse>>(books);

            return StatusCode(StatusCodes.Status200OK, bookResponses);
        }
    }
}

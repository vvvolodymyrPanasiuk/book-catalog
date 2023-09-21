using AutoMapper;
using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Domain.Repositories.BookRepository;
using BookCatalog.WebAPI.Models.BookModels.Request;
using BookCatalog.WebAPI.Models.BookModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCatalog.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BooksController> _logger;

        public BooksController(
            IBookRepository bookRepository,
            IMapper mapper,
            ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }


        #region GET

        /// <summary>
        /// Retrieves a list of all books.
        /// </summary>
        /// <returns>Returns status 200 (OK) with a list of books or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) with a list of books.</response>
        /// <response code="401">If the user is not authorized to perform this action.</response>
        /// <response code="404">If no books were found.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookRepository.GetAllAsync();
                if (books == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var bookResponses = _mapper.Map<IEnumerable<BookResponse>>(books);

                return StatusCode(StatusCodes.Status200OK, bookResponses);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <returns>Returns status 200 (OK) with the book details or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) with the book details.</response>
        /// <response code="401">If the user is not authorized to perform this action.</response>
        /// <response code="404">If the book with the specified ID was not found.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var bookResponse = _mapper.Map<BookResponse>(book);

                return StatusCode(StatusCodes.Status200OK, bookResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }   
        }

        #endregion


        #region POST

        /// <summary>
        /// Adds a new book to the catalog.
        /// </summary>
        /// <param name="bookRequest">The request object containing book details.</param>
        /// <returns>Returns status 201 (Created) if the book was added successfully or an error message.</returns>
        /// <response code="201">Returns status 201 (Created) if the book was added successfully.</response>
        /// <response code="400">If the request model is invalid.</response>
        /// <response code="401">If the user is not authorized to perform this action.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> AddBook([FromBody] BookRequest bookRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var book = _mapper.Map<Book>(bookRequest);

                    await _bookRepository.AddAsync(book);
                    return StatusCode(StatusCodes.Status201Created);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        #endregion


        #region PUT

        /// <summary>
        /// Updates an existing book in the catalog.
        /// </summary>
        /// <param name="id">The unique identifier of the book to update.</param>
        /// <param name="bookRequest">The request object containing updated book details.</param>
        /// <returns>Returns status 200 (OK) if the book was updated successfully or an error message.</returns>
        /// <response code="200">Returns status 200 (OK) if the book was updated successfully.</response>
        /// <response code="400">If the request model is invalid.</response>
        /// <response code="401">If the user is not authorized to perform this action.</response>
        /// <response code="404">If the book with the specified ID was not found.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookRequest bookRequest)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBook = await _bookRepository.GetByIdAsync(id);
                    if (existingBook == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound);
                    }

                    _mapper.Map(bookRequest, existingBook);

                    await _bookRepository.UpdateAsync(existingBook);
                    return StatusCode(StatusCodes.Status201Created);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        #endregion


        #region DELETE

        /// <summary>
        /// Deletes a book from the catalog.
        /// </summary>
        /// <param name="id">The unique identifier of the book to delete.</param>
        /// <returns>Returns status 204 (No Content) if the book was deleted successfully or an error message.</returns>
        /// <response code="204">Returns status 204 (No Content) if the book was deleted successfully.</response>
        /// <response code="401">If the user is not authorized to perform this action.</response>
        /// <response code="404">If the book with the specified ID was not found.</response>
        /// <response code="500">If an error occurred during the operation.</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                await _bookRepository.DeleteAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        #endregion
    }
}

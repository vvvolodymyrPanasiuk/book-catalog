using AutoMapper;
using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Domain.Repositories.BookRepository;
using BookCatalog.WebAPI.Models.BookModels.Request;
using BookCatalog.WebAPI.Models.BookModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("books")]
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

        [HttpGet("books/{id}")]
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

        [HttpPost("book")]
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

        [HttpPut("books/{id}")]
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

        [HttpDelete("books/{id}")]
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

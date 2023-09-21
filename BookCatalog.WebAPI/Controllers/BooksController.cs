using AutoMapper;
using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Domain.Repositories.BookRepository;
using BookCatalog.WebAPI.Models.BookModels.Request;
using BookCatalog.WebAPI.Models.BookModels.Response;
using Microsoft.AspNetCore.Mvc;
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

        public BooksController(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        #region GET

        [HttpGet("books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            if (books == null)
            {
                return NotFound();
            }

            var bookResponses = _mapper.Map<IEnumerable<BookResponse>>(books);

            return Ok(bookResponses);
        }

        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookResponse = _mapper.Map<BookResponse>(book);

            return Ok(bookResponse);
        }

        #endregion


        #region POST

        [HttpPost("book")]
        public async Task<IActionResult> AddBook([FromBody] BookRequest bookRequest)
        {
            if (bookRequest == null)
            {
                return BadRequest();
            }

            var book = _mapper.Map<Book>(bookRequest);

            await _bookRepository.AddAsync(book);
            return Ok();
        }

        #endregion


        #region PUT

        [HttpPut("books/{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookRequest bookRequest)
        {
            if (bookRequest == null || id == Guid.Empty)
            {
                return BadRequest();
            }

            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _mapper.Map(bookRequest, existingBook);

            await _bookRepository.UpdateAsync(existingBook);
            return Ok();
        }

        #endregion


        #region DELETE

        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteAsync(id);
            return NoContent();
        }

        #endregion
    }
}

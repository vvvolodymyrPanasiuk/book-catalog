using BookCatalog.Domain.Entities.BookAggregate;
using BookCatalog.Service.Export;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookCatalog.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BookExportController : ControllerBase
    {
        private readonly IExportStrategyFactory _exportStrategyFactory;

        public BookExportController(IExportStrategyFactory exportStrategyFactory)
        {
            _exportStrategyFactory = exportStrategyFactory;
        }


        /// <summary>
        /// Exports a collection of books to Excel format and returns the exported data as a file.
        /// </summary>
        /// <param name="books">The collection of books to export.</param>
        /// <returns>Returns the exported data as an Excel file or an error message.</returns>
        /// <response code="200">Returns the exported data as an Excel file.</response>
        /// <response code="400">If the request model is invalid or there is no data to export.</response>
        /// <response code="500">If an error occurred during the export operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpPost("export-to-excel")]
        [AllowAnonymous]
        public IActionResult ExportToExcel([FromBody] IEnumerable<Book> books)
        {
            if(books == null || books.Count() <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No data to export.");
            }

            var _exportStrategy = _exportStrategyFactory.Create(ExportStrategyType.Excel);
            byte[] excelData = _exportStrategy.Export(books);
            
            if (excelData != null && excelData.Length > 0)
            {
                return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "books.xlsx");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No data to export.");
            }
        }


        /// <summary>
        /// Exports a collection of books to PDF format and returns the exported data as a file.
        /// </summary>
        /// <param name="books">The collection of books to export.</param>
        /// <returns>Returns the exported data as a PDF file or an error message.</returns>
        /// <response code="200">Returns the exported data as a PDF file.</response>
        /// <response code="400">If the request model is invalid or there is no data to export.</response>
        /// <response code="500">If an error occurred during the export operation.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [HttpPost("export-to-pdf")]
        [AllowAnonymous]
        public IActionResult ExportToPdf([FromBody] IEnumerable<Book> books)
        {
            if (books == null || books.Count() <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No data to export.");
            }

            var _exportStrategy = _exportStrategyFactory.Create(ExportStrategyType.Pdf);
            byte[] pdfData = _exportStrategy.Export(books);

            if (pdfData != null && pdfData.Length > 0)
            {
                return File(pdfData, "application/pdf", "books.pdf");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No data to export.");
            }
        }
    }
}

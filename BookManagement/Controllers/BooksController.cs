using BookManagement.DTO;
using BookManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookManagementRepository _bookManagement;
        public BooksController(IBookManagementRepository bookManagement)
        {
            _bookManagement = bookManagement;
        }

        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromBody] BookDto model)
        {
            var addBookResponse = _bookManagement.AddBook(model);

            return Ok(addBookResponse);
        }

        [HttpDelete("delete-book")]
        public async Task<IActionResult> DeleteBook([FromQuery] int bookId)
        {
            var deleteBookResponse = _bookManagement.DeleteBook(bookId);

            return Ok(deleteBookResponse);
        }

        [HttpGet("books")]
        public async Task<IActionResult> Books()
        {
            var getBooksResponse = _bookManagement.GetBooks();

            return Ok(getBooksResponse);
        }
    }
}

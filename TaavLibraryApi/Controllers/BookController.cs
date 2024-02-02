using Microsoft.AspNetCore.Mvc;
using TaavLibraryApi.Db;
using TaavLibraryApi.Services.BookServices;
using TaavLibraryApi.Services.BookServices.Dto;

namespace TaavLibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookServices _bookServices;
        public BookController(LibraryDbContext dbContext)
        {
            _bookServices = new BookServices(dbContext);
        }

        [HttpPost("add")]
        public int AddBook([FromBody] AddBookDto dto)
        {
            return _bookServices.AddBook(dto);
        }
        [HttpPatch("update/{id}")]
        public void UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto dto)
        {
            _bookServices.UpdateBook(id, dto);
        }
        [HttpDelete("delete/{id}")]
        public void DeleteBook([FromRoute] int id)
        {
            _bookServices.DeleteBook(id);
        }
        [HttpGet("get-books")]
        public List<GetBooksDto> GetBooks()
        {
            return _bookServices.GetBooks();
        }
        [HttpGet("find-book")]
        public List<FindBooksDto> FindBooks([FromQuery] string? name)
        {
            return _bookServices.FindBooks(name);
        }
    }
}

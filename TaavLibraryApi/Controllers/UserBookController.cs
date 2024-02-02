using Microsoft.AspNetCore.Mvc;
using TaavLibraryApi.Db;
using TaavLibraryApi.Services.UserBookServices;
using TaavLibraryApi.Services.UserBookServices.Dto;

namespace TaavLibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserBookController : ControllerBase
    {
        private readonly LibraryDbContext _db;
        private readonly UserBookServicesRepository _userBookServices;
        public UserBookController(LibraryDbContext db)
        {
            _db = db;
            _userBookServices = new UserBookServicesRepository(_db);
        }
        [HttpGet("get-user-rented-books/{userId}")]
        public GetUserRentedBooksDto GetUserRentedBooks([FromRoute] int userId)
        {
            return _userBookServices.GetUserRentedBooks(userId);
        }
        [HttpPost("rent-book")]
        public void RentBook([FromBody] RentBookDto dto)
        {
            _userBookServices.RentBook(dto.userId, dto.bookId);
        }
    }
}

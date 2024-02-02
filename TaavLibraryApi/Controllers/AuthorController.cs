using Microsoft.AspNetCore.Mvc;
using TaavLibraryApi.Db;
using TaavLibraryApi.Services.AuthorServices;
using TaavLibraryApi.Services.AuthorServices.Dto;

namespace TaavLibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorServicesRepository _authorServices;
        private readonly LibraryDbContext _db;
        public AuthorController(LibraryDbContext db)
        {
            _db = db;
            _authorServices = new AuthorServicesRepository(_db);
        }
        [HttpPost("add-author")]
        public int AddAuthor([FromBody] AddAuthorDto dto)
        {
            return _authorServices.AddAuthor(dto);
        }
    }
}

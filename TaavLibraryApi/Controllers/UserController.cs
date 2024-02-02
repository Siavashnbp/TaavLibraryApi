using Microsoft.AspNetCore.Mvc;
using TaavLibraryApi.Db;
using TaavLibraryApi.Services.UserServices;
using TaavLibraryApi.Services.UserServices.Dto;

namespace TaavLibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly LibraryDbContext _db;
        private readonly UserServicesRepository _userServices;
        public UserController(LibraryDbContext db)
        {
            _db = db;
            _userServices = new UserServicesRepository(_db);
        }
        [HttpPost("add-user")]
        public int AddUser([FromBody] AddUserDto dto)
        {
            return _userServices.AddUser(dto);
        }
        [HttpGet("get-user/{id}")]
        public GetUserDto GetUser([FromRoute] int id)
        {
            return _userServices.FindUserById(id);
        }

    }
}

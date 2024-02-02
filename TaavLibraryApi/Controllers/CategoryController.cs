using Microsoft.AspNetCore.Mvc;
using TaavLibraryApi.Db;
using TaavLibraryApi.Services.CategoryServices;
using TaavLibraryApi.Services.CategoryServices.CategoryDto;

namespace TaavLibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly LibraryDbContext _db;
        private readonly CategoryServicesRepository _categoryServices;
        public CategoryController(LibraryDbContext db)
        {
            _db = db;
            _categoryServices = new CategoryServicesRepository(_db);
        }
        [HttpPost]
        public int AddCategory([FromBody] AddCategoryDto dto)
        {
            return _categoryServices.AddCategory(dto);
        }
    }
}

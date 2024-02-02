using TaavLibraryApi.Db;
using TaavLibraryApi.Entities;
using TaavLibraryApi.Services.CategoryServices.CategoryDto;

namespace TaavLibraryApi.Services.CategoryServices
{
    public class CategoryServicesRepository
    {
        private readonly LibraryDbContext _db;
        public CategoryServicesRepository(LibraryDbContext db)
        {
            _db = db;
        }
        public Category? FindCatgeoryByName(string categoryName)
        {
            return _db.Set<Category>().FirstOrDefault(_ => _.Name == categoryName);
        }
        public int AddCategory(AddCategoryDto dto)
        {
            var authorsExists = _db.Set<Category>().Any(_ => _.Name.ToLower() == dto.Name.ToLower());
            if (authorsExists)
            {
                throw new InvalidOperationException("Author already exists");
            }
            var tracker = _db.Set<Category>().Add(new Category
            {
                Name = dto.Name,
            });
            _db.SaveChanges();
            return tracker.Entity.Id;
        }
    }
}

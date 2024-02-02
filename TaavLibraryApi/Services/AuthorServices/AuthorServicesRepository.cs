using TaavLibraryApi.Db;
using TaavLibraryApi.Entities;
using TaavLibraryApi.Services.AuthorServices.Dto;

namespace TaavLibraryApi.Services.AuthorServices
{
    public class AuthorServicesRepository
    {
        private readonly LibraryDbContext _db;
        public AuthorServicesRepository(LibraryDbContext db)
        {
            _db = db;
        }
        public Author? FindAuthorByName(string authorName)
        {
            return _db.Set<Author>().FirstOrDefault(_ => _.FullName == authorName);
        }
        public int AddAuthor(AddAuthorDto dto)
        {
            var authorsExists = _db.Set<Author>().Any(_ => _.FullName.ToLower() == dto.FullName.ToLower());
            if (authorsExists)
            {
                throw new InvalidOperationException("Author already exists");
            }
            var tracker = _db.Set<Author>().Add(new Author
            {
                FullName = dto.FullName,
            });
            _db.SaveChanges();
            return tracker.Entity.Id;
        }
    }
}

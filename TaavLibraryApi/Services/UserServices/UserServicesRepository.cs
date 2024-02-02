using TaavLibraryApi.Db;
using TaavLibraryApi.Entities;
using TaavLibraryApi.Services.UserServices.Dto;

namespace TaavLibraryApi.Services.UserServices
{
    public class UserServicesRepository
    {
        private readonly LibraryDbContext _db;
        public UserServicesRepository(LibraryDbContext db)
        {
            _db = db;
        }
        public int AddUser(AddUserDto dto)
        {
            var tracker = _db.Set<User>().Add(new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            });
            _db.SaveChanges();
            return tracker.Entity.Id;
        }
        public GetUserDto FindUserById(int id)
        {
            var user = _db.Set<User>().Find(id);
            if (user == null)
            {
                throw new InvalidOperationException("User was not found");
            }
            return new GetUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
    }
}

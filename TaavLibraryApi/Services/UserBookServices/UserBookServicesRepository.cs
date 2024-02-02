using Microsoft.EntityFrameworkCore;
using TaavLibraryApi.Db;
using TaavLibraryApi.Entities;
using TaavLibraryApi.Services.UserBookServices.Dto;
using TaavLibraryApi.Services.UserServices;

namespace TaavLibraryApi.Services.UserBookServices
{
    public class UserBookServicesRepository
    {
        private readonly LibraryDbContext _db;
        public UserBookServicesRepository(LibraryDbContext db)
        {
            _db = db;
        }
        public GetUserRentedBooksDto GetUserRentedBooks(int userId)
        {
            var userServices = new UserServicesRepository(_db);
            var user = userServices.FindUserById(userId);
            var books = _db.Set<UserBook>().Include(_ => _.Book)
                .Where(_ => _.UserId == userId);
            return new GetUserRentedBooksDto
            {
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                Books = books.Select(_ => new RentedBookDto
                {
                    BookId = _.Id,
                    Name = _.Book.Name,
                    RentStatus = _.RentStatus,
                    RentTime = _.RentTime,
                    ReturnTime = _.ReturnTime,
                }).ToList()
            };
        }
        public void RentBook(int userId, int bookId)
        {
            var user = _db.Set<User>().Find(userId);
            if (user is null)
            {
                throw new InvalidOperationException("User id is not valid");
            }
            var numberOfInRentBooks = _db.Set<UserBook>()
                .Where(_ => _.UserId == user.Id && _.RentStatus == RentStatus.Rent).Count();
            if (numberOfInRentBooks > 4)
            {
                throw new InvalidOperationException("User currently has rented more than 4 books");
            }
            var book = _db.Set<Book>().Find(bookId);
            if (book is null)
            {
                throw new InvalidOperationException("Book id is not valid");
            }
            var isBookAvailable = _db.Set<UserBook>()
                .Where(_ => _.BookId == bookId && _.RentStatus == RentStatus.Rent).Count() < book.Count;
            if (!isBookAvailable)
            {
                throw new InvalidOperationException("This book is not availavle");
            }
            _db.Set<UserBook>().Add(new UserBook
            {
                Book = book,
                User = user,
                RentStatus = RentStatus.Rent,
                RentTime = DateTime.Now,
                ReturnTime = null
            });
            _db.SaveChanges();
        }

    }
}


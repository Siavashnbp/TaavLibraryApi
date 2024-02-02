using TaavLibraryApi.Db;
using TaavLibraryApi.Entities;
using TaavLibraryApi.Services.BookServices.Dto;

namespace TaavLibraryApi.Services.BookServices
{
    public class BookServices
    {
        private readonly LibraryDbContext _db;
        public BookServices(LibraryDbContext db)
        {
            _db = db;
        }
        public int AddBook(AddBookDto dto)
        {
            var track = _db.Set<Book>().Add(new Book
            {
                Name = dto.Name,
                Author = dto.Author,
                Category = dto.Category,
                PublishDate = dto.PublishDate,
            });
            _db.SaveChanges();
            return track.Entity.Id;
        }
        public void UpdateBook(int id, UpdateBookDto dto)
        {
            var book = _db.Set<Book>().Find(id);
            if (book is null)
            {
                throw new InvalidOperationException("Id was not found");
            }
            book.Name = dto.Name;
            book.Author = dto.Author;
            book.Category = dto.Category;
            book.PublishDate = dto.PublishDate;
            _db.Set<Book>().Update(book);
            _db.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = _db.Set<Book>().Find(id);
            if (book is null)
            {
                throw new InvalidOperationException("Id was not found");
            }
            _db.Set<Book>().Remove(book);
            _db.SaveChanges();
        }
        public List<GetBooksDto> GetBooks()
        {
            return _db.Set<Book>().Select(_ => new GetBooksDto
            {
                Author = _.Author,
                Category = _.Category,
                PublishDate = _.PublishDate,
                Id = _.Id,
                Name = _.Name,
            }).ToList();
        }
        public List<FindBooksDto> FindBooks(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return _db.Set<Book>().Select(_ => new FindBooksDto
                {
                    Author = _.Author,
                    Category = _.Category,
                    PublishDate = _.PublishDate,
                    Id = _.Id,
                    Name = _.Name,
                }).ToList();
            }
            return _db.Set<Book>().Where(_ => _.Name.Contains(name)).Select(_ => new FindBooksDto
            {
                Author = _.Author,
                Category = _.Category,
                PublishDate = _.PublishDate,
                Id = _.Id,
                Name = _.Name,
            }).ToList();
        }
    }
}

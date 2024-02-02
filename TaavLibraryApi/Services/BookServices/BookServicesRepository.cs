using Microsoft.EntityFrameworkCore;
using TaavLibraryApi.Db;
using TaavLibraryApi.Entities;
using TaavLibraryApi.Services.AuthorServices;
using TaavLibraryApi.Services.BookServices.Dto;
using TaavLibraryApi.Services.CategoryServices;

namespace TaavLibraryApi.Services.BookServices
{
    public class BookServicesRepository
    {
        private readonly LibraryDbContext _db;
        public BookServicesRepository(LibraryDbContext db)
        {
            _db = db;
        }
        public int AddBook(AddBookDto dto)
        {
            var authorServices = new AuthorServicesRepository(_db);
            var author = authorServices.FindAuthorByName(dto.Author);
            if (author is null)
            {
                throw new InvalidOperationException("Author could not be found");
            }
            var categoryServices = new CategoryServicesRepository(_db);
            var category = categoryServices.FindCatgeoryByName(dto.Category);
            if (category is null)
            {
                throw new InvalidOperationException("Category couldnot be found");
            }
            var track = _db.Set<Book>().Add(new Book
            {
                Name = dto.Name,
                Author = author,
                Category = category,
                PublishDate = dto.PublishDate,
                Count = dto.Count
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
            var authorServices = new AuthorServicesRepository(_db);
            var author = authorServices.FindAuthorByName(dto.Author);
            if (author is null)
            {
                throw new InvalidOperationException("Author could not be found");
            }
            var categoryServices = new CategoryServicesRepository(_db);
            var category = categoryServices.FindCatgeoryByName(dto.Category);
            if (category is null)
            {
                throw new InvalidOperationException("Category couldnot be found");
            }
            book.Name = dto.Name;
            book.Author = author;
            book.Category = category;
            book.PublishDate = dto.PublishDate;
            book.Count = dto.Count;
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
            return _db.Set<Book>().Include(_ => _.Author).Include(_ => _.Category)
                .Select(_ => new GetBooksDto
                {
                    Author = _.Author.FullName,
                    Category = _.Category.Name,
                    PublishDate = _.PublishDate,
                    Id = _.Id,
                    Name = _.Name,
                }).ToList();
        }
        public List<FindBooksDto>? FindBooks(string? bookName, string? authorName, string? categoryName)
        {
            var foundBooks = new List<FindBooksDto>();
            if (!string.IsNullOrWhiteSpace(bookName))
            {
                foundBooks = _db.Set<Book>().Include(_ => _.Author).Include(_ => _.Category)
                    .Where(_ => _.Name.ToLower().Contains(bookName!.ToLower()))
                    .Select(_ => new FindBooksDto
                    {
                        Author = _.Author.FullName,
                        Category = _.Category.Name,
                        PublishDate = _.PublishDate,
                        Id = _.Id,
                        Name = _.Name,
                        Count = _.Count,
                    }).ToList();
            }
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                foundBooks = foundBooks?.Where(_ => _.Category.ToLower().Contains(categoryName!.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(authorName))
            {
                foundBooks = foundBooks?.Where(_ => _.Author.ToLower().Contains(authorName!.ToLower())).ToList();
            }
            if (foundBooks is not null)
            {
                foreach (var book in foundBooks)
                {
                    var rentCount = _db.Set<UserBook>()
                .Where(_ => _.BookId == book.Id && _.RentStatus == RentStatus.Rent).Count();
                    book.RentCount = rentCount;
                }
            }
            return foundBooks;
        }
        public FindBooksDto FindBookById(int id)
        {
            var book = _db.Set<Book>().Include(_ => _.Author).Include(_ => _.Category)
                .FirstOrDefault(_ => _.Id == id);
            if (book is null)
            {
                throw new InvalidOperationException("Book was not found");
            }
            var rentCount = _db.Set<UserBook>()
                .Where(_ => _.BookId == book.Id && _.RentStatus == RentStatus.Rent).Count();
            return new FindBooksDto
            {
                Name = book.Name,
                Id = book.Id,
                PublishDate = book.PublishDate,
                Count = book.Count,
                Author = book.Author.FullName,
                Category = book.Category.Name,
                RentCount = rentCount
            };
        }
    }
}

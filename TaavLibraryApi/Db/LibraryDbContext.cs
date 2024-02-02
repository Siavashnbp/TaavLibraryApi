using Microsoft.EntityFrameworkCore;
using TaavLibraryApi.Entities;

namespace TaavLibraryApi.Db
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {

        }
    }
}

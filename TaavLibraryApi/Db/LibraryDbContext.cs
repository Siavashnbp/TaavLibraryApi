﻿using Microsoft.EntityFrameworkCore;
using TaavLibraryApi.Entities;

namespace TaavLibraryApi.Db
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {

        }
    }
}
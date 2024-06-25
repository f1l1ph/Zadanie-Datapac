using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Context;

public class LibraryContextRead(DbContextOptions<LibraryContextRead> options) : DbContext(options)
{
    public DbSet<BookEntity> Books { get; set; }

}


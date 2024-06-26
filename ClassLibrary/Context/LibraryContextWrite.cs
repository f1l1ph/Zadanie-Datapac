using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Context;

public class LibraryContextWrite(DbContextOptions<LibraryContextWrite> options) : DbContext(options)
{
    public DbSet<BookEntity> Books { get; set; }

    public DbSet<BorrowOrderEntity> Orders { get; set; }
}
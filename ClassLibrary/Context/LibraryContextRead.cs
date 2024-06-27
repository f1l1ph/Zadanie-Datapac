using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Context;

public class LibraryContextRead(DbContextOptions<LibraryContextRead> options) : DbContext(options)
{
    public DbSet<BookEntity> Books { get; set; }

    public DbSet<BorrowOrderEntity> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEntity>()
            .HasMany(e => e.BorrowOrders)
            .WithOne(e => e.Book)
            .HasForeignKey(e => e.BookId)
            .HasPrincipalKey(e => e.Id)
            .IsRequired();
    }

}


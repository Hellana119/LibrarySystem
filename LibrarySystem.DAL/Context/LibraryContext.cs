using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Context;

public class LibraryContext :  IdentityDbContext<User>
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().ToTable("Users");
    }
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Section> Sections => Set<Section>();


}

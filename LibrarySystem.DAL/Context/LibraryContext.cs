using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
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

        //#region Seeding
        //base.OnModelCreating(builder);
        //var _Authors = JsonSerializer.Deserialize<List<Author>>("""[{"Id":1,"Name":"Ahmed", "Bio": "hiiii"},{"Id":2,"Name":"Lolo", "Bio": "Author"},{"Id":3,"Name":"Baby \u0026 Baby","Bio": "hello"}]""") ?? new();
        //var _Books = JsonSerializer.Deserialize<List<Book>>("""[{"Id":1,"Title":"Freddie","AuthorId":4},{"Id":2,"Title":"Jamie","AuthorId":4},{"Id":3,"Title":"Geoffrey","AuthorId":4}]""") ?? new();
        //builder.Entity<Author>().HasData(_Authors);
        //builder.Entity<Book>().HasData(_Books);

        //#endregion
    }
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Section> Sections => Set<Section>();


}

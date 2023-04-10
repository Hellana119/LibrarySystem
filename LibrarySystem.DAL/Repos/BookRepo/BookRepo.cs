using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Repos.BookRepo;

public class BookRepo : GenericRepo<Book>, IBookRepo
{
    private readonly LibraryContext _context;

    public BookRepo(LibraryContext context) : base(context)
    {
        _context = context;
    }
}

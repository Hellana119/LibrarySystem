using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Models.Identity;
using LibrarySystem.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Repos.IdentityRepo;

public class UserRepo : GenericRepo<User>, IUserRepo
{
    private readonly LibraryContext _context;

    public UserRepo(LibraryContext context) : base(context)
    {
        _context = context;
    }

    public User GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }
}

using LibrarySystem.DAL.Models.Identity;
using LibrarySystem.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Repos.IdentityRepo;

public interface IUserRepo: IGenericRepo<User>
{
    public User GetUserByEmail(string email);
}

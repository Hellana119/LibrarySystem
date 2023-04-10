using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Repos.BookRepo;

public interface IBookRepo: IGenericRepo<Book>
{
}

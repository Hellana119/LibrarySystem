using LibrarySystem.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Models;

public class Review
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime TimeCreated = DateTime.Now;

    public int UserId { get; set; }
    public User? User { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; }
}

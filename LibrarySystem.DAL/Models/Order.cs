using LibrarySystem.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Models;

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime TimeCreated { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();


}

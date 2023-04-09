using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Models.Identity;

public class User: IdentityUser
{
    public string DisplayName { get; set; } = string.Empty;
    public Gender gender { get; set; }
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
public enum Gender
{
    Male, Female
}

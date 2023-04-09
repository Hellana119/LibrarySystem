using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Models;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Author> Authors { get; set; } = new HashSet<Author>();
    public ICollection<Section> Sections { get; set; } = new HashSet<Section>();



}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public string Bio { get; set; }= string.Empty;
    public int Rating { get; set; }

    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    public ICollection<Publisher> Publishers { get; set; } = new HashSet<Publisher>();
    public ICollection<Section> Sections { get; set; } = new HashSet<Section>();

}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Dtos;

public class BookAddDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int AvailableNumer { get; set; }
    public IFormFile Image { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public int? AuthorID { get; set; }


}

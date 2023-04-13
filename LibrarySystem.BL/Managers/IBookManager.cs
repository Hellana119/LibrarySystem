using LibrarySystem.BL.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Managers;

public interface IBookManager
{
    List<BookReadDto> GetAll();
    BookReadDto? GetById(int id);
    Task Add(BookAddDto book);
}

using LibrarySystem.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Managers;

public interface IBookManager
{
    List<BookReadDto> GetAll();
    void Add(BookAddDto book);
}

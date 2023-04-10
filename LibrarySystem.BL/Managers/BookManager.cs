using LibrarySystem.BL.Dtos;
using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Repos.BookRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BL.Managers;

public class BookManager : IBookManager
{
    private readonly IBookRepo _bookRepo;

    public BookManager(IBookRepo bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public List<BookReadDto> GetAll()
    {
        List<Book> BookFromDB = _bookRepo.GetAll();
        return BookFromDB
            .Select(B => new BookReadDto
            {
                Id= B.Id,
                Title= B.Title,
                Description= B.Description,
                Rating= B.Rating,
                Photo = B.Photo,
                Price = B.Price,
                Discount = B.Discount,
            }).ToList();
    }

    public void Add(BookAddDto bookDto)
    {
        var Book = new Book
        {
            Title = bookDto.Title,
            Description = bookDto.Description,
            Rating = bookDto.Rating,
            Photo = bookDto.Photo,
            Price = bookDto.Price,
            Discount = bookDto.Discount,
            AuthorID = (int)bookDto.AuthorID,
        };
        _bookRepo.Add(Book);
        _bookRepo.SaveChanges();
    }

}

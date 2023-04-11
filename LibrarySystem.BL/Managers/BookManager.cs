using LibrarySystem.BL.Dtos;
using LibrarySystem.DAL.Models;
using LibrarySystem.DAL.Repos.BookRepo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibrarySystem.BL.Managers;

public class BookManager : IBookManager
{
    private readonly IBookRepo _bookRepo;
    private readonly IWebHostEnvironment _env;
    public BookManager(IBookRepo bookRepo, IWebHostEnvironment env)
    {
        _bookRepo = bookRepo;
        _env = env;
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
                ImagePath = B.ImagePath,
            }).ToList();
    }

    public async Task Add([FromForm]BookAddDto bookDto)
    {
        var imagePath = Path.Combine(_env.WebRootPath, "images", bookDto.Image.FileName);
        //var imagePath = $"~/images/{Guid.NewGuid()}{Path.GetExtension(bookDto.ImagePath)}";

        var stream = new FileStream(imagePath, FileMode.Append);
        bookDto.Image.CopyTo(stream);
        

  
        var Book = new Book
        {
            Title = bookDto.Title,
            Description = bookDto.Description,
            Rating = bookDto.Rating,
            ImagePath = imagePath,
            Price = bookDto.Price,
            Discount = bookDto.Discount,
            AuthorID = (int)bookDto.AuthorID,
        };
       await _bookRepo.Add(Book);
        _bookRepo.SaveChanges();
    }

}

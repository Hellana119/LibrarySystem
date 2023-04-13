using LibrarySystem.BL.Dtos;
using LibrarySystem.BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        public BooksController(IBookManager bookManager)
        {
            _bookManager = bookManager;

        }

        [HttpGet]
        public ActionResult<List<BookReadDto>> GetAll()
        {
            return _bookManager.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<BookReadDto> GetById(int id)
        {
            var Book = _bookManager.GetById(id);
            return Book;
        }


        [HttpPost]
        public async Task<ActionResult> Add([FromForm]BookAddDto bookDto)
        {
           await _bookManager.Add(bookDto);
            return Ok(bookDto);
        }
    }
}

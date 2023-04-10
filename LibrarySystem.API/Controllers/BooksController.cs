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

        [HttpPost]
        public ActionResult Add(BookAddDto bookDto)
        {
            _bookManager.Add(bookDto);
            return NoContent();
        }
    }
}

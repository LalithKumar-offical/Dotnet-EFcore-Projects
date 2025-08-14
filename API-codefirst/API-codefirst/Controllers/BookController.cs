using API_codefirst.Models;
using API_codefirst.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookservice;
        public BookController(BookService bookservice)
        {
            _bookservice = bookservice;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookservice.Getallbook();
        }
    }
}

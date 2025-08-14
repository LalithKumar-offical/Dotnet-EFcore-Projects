using API_codefirst.Models;
using API_codefirst.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API_codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _autherservice;
        public AuthorController(AuthorService authorservice)
        {
            _autherservice = authorservice;
        }
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _autherservice.Getallauthor();
        }

    }
   
}

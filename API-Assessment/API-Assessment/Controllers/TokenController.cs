using API_Assessment.Data;
using API_Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Assessment.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TokenController : ControllerBase
    {
        private readonly CodeContextData _con;
        private readonly ITokenGenerate _tokenService;
        public TokenController(CodeContextData con, ITokenGenerate tokenService)
        {
            _con = con;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserClass userData)
        {
            if (userData != null && !string.IsNullOrEmpty(userData.UserEmail) &&
            !string.IsNullOrEmpty(userData.UserPassword))
            {
                var user = await GetUser(userData.UserEmail, userData.UserPassword);
                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user);
                    return Ok(new { token });

                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Invalid request data");
            }
        }
        private async Task<UserClass> GetUser(string email, string password)
        {
            return await _con.DbUser.FirstOrDefaultAsync(u => u.UserEmail == email &&
            u.UserPassword == password) ?? new API_Assessment.Models.UserClass();
        }
    }
}
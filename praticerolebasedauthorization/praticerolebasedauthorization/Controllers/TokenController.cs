
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using praticerolebasedauthorization.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly CodeContext _con;
        private readonly IConfiguration _configuration;

        public TokenController(CodeContext con, IConfiguration configuration)
        {
            _con = con;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User userData)
        {
            if (userData != null &&
                !string.IsNullOrEmpty(userData.userEmail) &&
                !string.IsNullOrEmpty(userData.userPassword))
            {
                var user = await GetUser(userData.userEmail, userData.userPassword, userData.userRole);
                if (user != null)
                {
                    var token = GenerateToken(user);
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

        // ✅ check user in database
        private async Task<User?> GetUser(string email, string password, string role)
        {
            return await _con.DbUsers.FirstOrDefaultAsync(u =>
                u.userEmail == email &&
                u.userPassword == password &&
                u.userRole == role);
        }

        // ✅ generate JWT token directly here
        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.userName!),
                new Claim(ClaimTypes.Role, user.userRole!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

using LibrarySystem.BL.Dtos;
using LibrarySystem.DAL.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public UsersController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        #region Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                
            };
            var userCreationresult = await _userManager.CreateAsync(user, registerDto.Password);
            if (!userCreationresult.Succeeded)
            {
                return BadRequest(userCreationresult.Errors);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, "User"),

            };

            await _userManager.AddClaimsAsync(user, claims);

            return Ok(user);
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto cradentials)
        {
            User? user = await _userManager.FindByNameAsync(cradentials.UserName);
            if (user is null)
            {
                return BadRequest(new { Message = "User Not Found" });
            }
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, cradentials.Password);
            if (!isPasswordCorrect)
            {
                return Unauthorized();
            }
            var claims = await _userManager.GetClaimsAsync(user);
            DateTime exp = DateTime.Now.AddMinutes(20);

            var token = GenerateToken(claims, exp);

            return new TokenDto(token);
        }
        #endregion

        #region GenerateToken
        private string GenerateToken(IList<Claim> claimsList, DateTime exp)
        {
            var SecretKeyString = _configuration.GetValue<string>("SecretKey");
            var SecretKeyInBytes = Encoding.ASCII.GetBytes(SecretKeyString);
            var SecurityKey = new SymmetricSecurityKey(SecretKeyInBytes);

            var signingCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                claims: claimsList,
                expires: exp,
                signingCredentials: signingCredentials);
            // convert token to string
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);
            return tokenString;
        }
        #endregion
    }
}

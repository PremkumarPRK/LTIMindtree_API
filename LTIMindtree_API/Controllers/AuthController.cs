using LTIMindtree_API.Models;
using LTIMindtree_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LTIMindtree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Username
            };
            var result = await userManager.CreateAsync(identityUser, registerUser.Password);
            if (result.Succeeded)
            {
                if(registerUser.roles.Any() && registerUser.roles != null)
                {
                    result = await userManager.AddToRolesAsync(identityUser, registerUser.roles);
                }
                if(result.Succeeded)
                {
                    return Ok("User was created successfully.");
                }
            }
            return BadRequest("Something went wrong. Please contact admin.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var user = await userManager.FindByEmailAsync(login.Username);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var token = tokenRepository.CreateToken(user, roles.ToList());
                        if (token != null)
                        {
                            return Ok(new Token { JwtToken = token });
                        }
                    }
                }
            }
            return BadRequest("Username or Password is incorrect");
        }
    }
}

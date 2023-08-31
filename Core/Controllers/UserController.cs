using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreAuthentication.Interface;
using CoreAuthentication.Models;
using CoreAuthentication.Repository;
using CoreAuthentication.Data;
using Microsoft.AspNetCore.Identity;

namespace CoreAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser iUserRepository;
        private readonly UserManager<IdentityUser> userManager;

        public UserController(IUser iUserRepository, UserManager<IdentityUser> userManager)
        {
            this.iUserRepository = iUserRepository;
            this.userManager = userManager;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] SignUp signUpDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = signUpDto.Email,
                Email = signUpDto.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, signUpDto.Password);

            if (identityResult.Succeeded)
            {
                //Add roles to User
                if (signUpDto.Roles != null && signUpDto.Roles.Any())
                {
                    await userManager.AddToRolesAsync(identityUser, signUpDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Plese Logion.");
                    }
                }
            }

            return BadRequest("Something went wrong.");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] SignIn signInDto)
        {
            var user = await userManager.FindByEmailAsync(signInDto.Email);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, signInDto.Password);

                if (checkPasswordResult)
                {
                    //Create a token
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = iUserRepository.GetJWTToken(user, roles.ToList());

                        return Ok(jwtToken);
                    }
                }
            }

            return BadRequest("Something went wrong.");
        }
    }
}

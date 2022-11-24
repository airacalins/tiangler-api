using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tiangler.Api.Controllers.Dtos;
using Tiangler.Api.Services;
using Tiangler.Core.Domains.ApplicationUsers;

namespace Tiangler.Api.Controllers.Authentications
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthenticationsController(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized();


            return new UserDto
            {
                Username = user.Email,
                Photo = string.Empty,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new ApplicationUser { UserName = registerDto.Email, Email = registerDto.Email };
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            //await _userManager.AddToRoleAsync(user, "ADMIN");
            return StatusCode(201);
        }

        [Authorize]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return new UserDto
            {
                Id = user.Id,
                Username = user.Email,
                Photo =  string.Empty,
                Token = await _tokenService.GenerateToken(user),
                Roles = await _userManager.GetRolesAsync(user)
            };
        }

    }
}

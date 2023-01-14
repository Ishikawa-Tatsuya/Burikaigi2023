using Burikaigi.Server.Data;
using Burikaigi.Server.Models;
using Burikaigi.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Burikaigi.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM? loginDto)
        {
            if (loginDto == null) throw new Exception();

            await InitialzieAdmin();

            var user = await _userManager.FindByNameAsync(loginDto.Id);
            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties { IsPersistent = loginDto.IsPersistent });

                return new JsonResult("");
            }

            return BadRequest("failed login");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return new JsonResult("");
        }

        async Task InitialzieAdmin()
        {
            //ユーザーがいなかったら管理者の登録
            if (await _context.Users.AnyAsync()) return;

            await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin",
                EmailConfirmed = true,
            }, "Abcdefg123##");
        }
    }
}
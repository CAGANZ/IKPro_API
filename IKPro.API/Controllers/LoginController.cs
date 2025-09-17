using IKPro.Application.DTOs.Login;
using IKPro.Application.Services.LoginServis;
using IKPro.Application.Services.TokenServis;
using IKPro.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase

    {
        private readonly ITokenServis _tokenServis;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILoginServis _loginServis;
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(ITokenServis tokenServis, SignInManager<AppUser> signInManager, ILoginServis loginServis, IConfiguration config, UserManager<AppUser> userManager)
        {
            _tokenServis = tokenServis;
            _signInManager = signInManager;
            _loginServis = loginServis;
            _config = config;
            _userManager = userManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login_Dto loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Email veya þifre eksik.");
            }

            var user = await _loginServis.LoginAsync(loginDto);

            if (user == null)
            {
                return Unauthorized("Geçersiz kullanýcý.");
            }

            var uyeVarmi = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!uyeVarmi)
            {
                return Unauthorized("Geçersiz kullanýcý adý veya þifre.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var role = userRoles.FirstOrDefault(); 

            //if (string.IsNullOrEmpty(role))
            //{
            //    return Unauthorized("Kullanýcý rolü belirlenemedi.");
            //}

            
            var token = _tokenServis.GenerateToken(user.Email, role, user.Id,user);
            return Ok(token);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { success = true, message = "Logout basarili" });

        }

        
        [HttpGet]
        [Route("sifremiUnuttum")]
        public async Task<IActionResult> SifreSifirla(string email)
        {
            await _loginServis.SifreSifirlaAsync(email);
            return Ok(new { success = true, message = "Þifre Sýfýrlandý." });
        }
    }
}


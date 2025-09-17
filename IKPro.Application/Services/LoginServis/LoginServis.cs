using AutoMapper;
using IKPro.Application.DTOs.Login;
using IKPro.Application.Services.MailServis;
using IKPro.Application.Services.PersonelServis;
using IKPro.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace IKPro.Application.Services.LoginServis
{

    public class LoginServis : ILoginServis
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IPersonelServis _personelServis;
        private readonly IEmailGondericiServis _emailGondericiServis;

        public LoginServis(UserManager<AppUser> userManager, IMapper mapper, IPersonelServis personelServis, IEmailGondericiServis emailGondericiServis)
        {
            _userManager = userManager;
            _mapper = mapper;
            _personelServis = personelServis;
            _emailGondericiServis = emailGondericiServis;
        }

        public async Task<AppUser> LoginAsync(Login_Dto uye)
        {
           
            bool uyeVarmi = false;
            LoginResult_Dto result = new LoginResult_Dto();
            result.UserID = -1;
            AppUser arananUye = null;
            arananUye = await _userManager.FindByNameAsync(uye.Email);
            if (arananUye == null)
                arananUye = await _userManager.FindByEmailAsync(uye.Email);

            if (arananUye != null)
                uyeVarmi = await _userManager.CheckPasswordAsync(arananUye, uye.Password);

            if (uyeVarmi)
            {
                result.UserID = arananUye.Id;
                result.IsAdmin = await _userManager.IsInRoleAsync(arananUye, "Admin");
            }
            return arananUye;
        }

        public Task LogoutAsync()
        {
            return Task.CompletedTask;
        }

        public async Task SifreSifirlaAsync(string email)
        {
            var kullanici = await _userManager.FindByEmailAsync(email);
            if (kullanici == null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı.");
            }
            var eskiSifre = kullanici.PasswordHash;
            var verifyUserToken = await _userManager.GeneratePasswordResetTokenAsync(kullanici);
            var yeniSifre = _emailGondericiServis.GenerateRandomPassword();
            var subject = "Personel Şifreniz Sıfırlandı.";
            var body = $"{kullanici.Email}<br>Yeni Şifreniz: {yeniSifre}";
            var result= await _userManager.ResetPasswordAsync(kullanici, verifyUserToken, yeniSifre);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Şifre sıfırlama işlemi başarısız.");
            }
            await _userManager.ChangePasswordAsync(kullanici,eskiSifre,yeniSifre);
            await _emailGondericiServis.EmailGonderAsync(email, subject, body);
        }
    }
}

using IKPro.Application.DTOs.Login;
using IKPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.Services.LoginServis
{
    public interface ILoginServis
    {
        Task<AppUser> LoginAsync(Login_Dto uye);
        Task LogoutAsync();
        Task SifreSifirlaAsync(string email);
    }
}

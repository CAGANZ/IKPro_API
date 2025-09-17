using IKPro.Domain.Models;

namespace IKPro.Application.Services.TokenServis
{
    public interface ITokenServis
    {
        string GenerateToken(string email, string role, int id,AppUser user);
    }
}

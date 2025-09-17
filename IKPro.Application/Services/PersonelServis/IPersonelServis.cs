using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace IKPro.Application.Services.PersonelServis
{
    public interface IPersonelServis
    {
        public Task<IdentityResult> PersonelEkleAsync(PersonelEkle_Dto personel);
        public Task<bool> PersonelGuncelleAsync(PersonelGuncelle_Dto personel);
        public Task<Personel_Dto> PersonelDetayGetirAsync(int id);
        public Task<IEnumerable<Personel_Dto>> TumPersonelleriListeleAsync(int sirketId);
    }
}

using IKPro.Application.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace IKPro.Application.Services.SirketYoneticiServis
{
    public interface ISirketYoneticiServis
    {
        public Task<IdentityResult> SirketYoneticiEkleAsync(SirketYoneticiEkle_Dto sirketYoneticiDto);
        public Task<bool> SirketYoneticiGuncelleAsync(SirketYoneticiGuncelle_Dto sirketYonetici);
        //public Task<bool> SirketSilAsync(int id); 
        public Task<IEnumerable<SirketYonetici_Dto>> TumSirketYoneticileriniListeleAsync();
        public Task<SirketYonetici_Dto> SirketYoneticiDetayGetirAsync(int id); 
        //bu normalde vm e bağlanıyo
    }
}

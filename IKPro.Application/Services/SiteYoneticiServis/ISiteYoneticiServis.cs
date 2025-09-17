using IKPro.Application.DTOs.User;

namespace IKPro.Application.Services.SiteYoneticiServis
{
    public interface ISiteYoneticiServis
    {
        public Task<bool> SiteYoneticiGuncelleAsync(SiteYoneticiGuncelle_Dto siteYonetici);
        //public Task<bool> SiteYoneticiSilAsync(int id);
        public Task<SiteYonetici_Dto> SiteYoneticiDetayGetirAsync(int id);
    }
}

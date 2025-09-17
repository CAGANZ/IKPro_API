using AutoMapper;
using IKPro.Application.DTOs.User;
using IKPro.Domain.Models;
using IKPro.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IKPro.Application.Services.SiteYoneticiServis
{
    public class SiteYoneticiServis : ISiteYoneticiServis
    {
        private readonly IMapper mapper;
        private readonly IKProDbContext context;
        private readonly UserManager<AppUser> userManager;

        public SiteYoneticiServis(IMapper mapper, IKProDbContext context, UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<SiteYonetici_Dto> SiteYoneticiDetayGetirAsync(int id)
        {
            AppUser yonetici = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var isAdmin = await userManager.IsInRoleAsync(yonetici, "Admin");
            if (yonetici == null)
            {
                return null;
            }
            if (!isAdmin)
            {
                return null;
            }
            SiteYonetici_Dto yoneticiDetay = new SiteYonetici_Dto();
            mapper.Map(yonetici, yoneticiDetay);
            return yoneticiDetay;
        }

        public async Task<bool> SiteYoneticiGuncelleAsync(SiteYoneticiGuncelle_Dto siteYonetici)
        {
            var user = await userManager.FindByIdAsync(siteYonetici.Id.ToString());
            var isAdmin = await userManager.IsInRoleAsync(user, "Admin");
            if (user == null)
            {
                return false;
            }
            if (!isAdmin)
            {
                return false;
            }
            user.Fotograf = siteYonetici.Fotograf;
            user.Adres = siteYonetici.Adres;
            user.PhoneNumber = siteYonetici.PhoneNumber;
            var result = await userManager.UpdateAsync(user);
            return result.Succeeded;
        }

    }
}

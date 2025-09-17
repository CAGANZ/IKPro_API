using AutoMapper;
using IKPro.Application.DTOs.User;
using IKPro.Application.Services.MailServis;
using IKPro.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace IKPro.Application.Services.SirketYoneticiServis
{
    public class SirketYoneticiServis : ISirketYoneticiServis
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IEmailGondericiServis emailGonderici;

        public SirketYoneticiServis(IMapper mapper, UserManager<AppUser> userManager, IEmailGondericiServis emailGonderici)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.emailGonderici = emailGonderici;
        }

        public async Task<SirketYonetici_Dto> SirketYoneticiDetayGetirAsync(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var isYonetici = await userManager.IsInRoleAsync(user, "SirketYonetici");
            if (user == null)
            {
                return null;
            }
            if (!isYonetici)
            {
                return null;
            }
            var yoneticiDto = mapper.Map<SirketYonetici_Dto>(user);
            return yoneticiDto;
        }

        public async Task<IdentityResult> SirketYoneticiEkleAsync(SirketYoneticiEkle_Dto sirketYoneticiDto)
        {
            var uyeVarMi = await userManager.FindByEmailAsync(sirketYoneticiDto.Email);
            if (uyeVarMi is not null)
                return IdentityResult.Failed();
            else
            {
                AppUser user = new AppUser();
                mapper.Map(sirketYoneticiDto, user);
                user.UserName = sirketYoneticiDto.Adi;
                var sifre = emailGonderici.GenerateRandomPassword();
                var result = await userManager.CreateAsync(user, sifre);
                user.UserName += $"-{user.Id}";
                await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "SirketYonetici");
                    await emailGonderici.EmailGonderAsync(user.Email, "Şirket Yönetici Hesap Bilgileri", $"Hoş geldiniz!<br>Mailiniz: {user.Email}<br>Şifreniz: {sifre}");
                }

                return result;
            }
        }

        public async Task<bool> SirketYoneticiGuncelleAsync(SirketYoneticiGuncelle_Dto sirketYonetici)
        {
            var user = await userManager.FindByIdAsync(sirketYonetici.Id.ToString());
            if (user == null)
            {
                return false;
            }
            user.Fotograf = sirketYonetici.Fotograf;
            user.Adres = sirketYonetici.Adres;
            user.PhoneNumber = sirketYonetici.PhoneNumber;
            var result = await userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<IEnumerable<SirketYonetici_Dto>> TumSirketYoneticileriniListeleAsync()
        {
            List<SirketYonetici_Dto> tumSirketYoneticileri = new List<SirketYonetici_Dto>();
            var gelenYoneticiler = await userManager.GetUsersInRoleAsync("SirketYonetici");
            mapper.Map(gelenYoneticiler, tumSirketYoneticileri);
            return tumSirketYoneticileri;
        }
    }
}

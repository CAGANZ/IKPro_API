using AutoMapper;
using IKPro.Application.DTOs.User;
using IKPro.Application.Services.MailServis;
using IKPro.Domain.Models;
using Microsoft.AspNetCore.Identity;


namespace IKPro.Application.Services.PersonelServis
{
    public class PersonelServis : IPersonelServis
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IEmailGondericiServis emailGonderici;

        public PersonelServis(IMapper mapper, UserManager<AppUser> userManager, IEmailGondericiServis emailGonderici)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.emailGonderici = emailGonderici;
        }

        public async Task<Personel_Dto> PersonelDetayGetirAsync(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var isPersonel = await userManager.IsInRoleAsync(user, "Personel");
            if (user == null)
            {
                return null;
            }
            if (!isPersonel)
            {
                return null;
            }
            var personel = mapper.Map<Personel_Dto>(user);
            return personel;
        }

        public async Task<IdentityResult> PersonelEkleAsync(PersonelEkle_Dto personel)
        {
            var uyeVarMi = await userManager.FindByEmailAsync(personel.Email);
            if (uyeVarMi is not null)
                return IdentityResult.Failed();
            else
            {
                AppUser user = new AppUser();
                mapper.Map(personel, user);
                user.UserName = personel.Email;
                user.Email = personel.Email;
                user.NormalizedEmail = personel.Email.ToUpperInvariant();
                user.NormalizedUserName = personel.Email.ToUpperInvariant();
                var sifre = emailGonderici.GenerateRandomPassword();
                var result = await userManager.CreateAsync(user, sifre);
                user.UserName += $"-{user.Id}";
                await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Personel");
                    await emailGonderici.EmailGonderAsync(user.Email, "Personel Hesap Bilgileri", $"Hoş geldiniz!<br>Mailiniz: {user.Email}<br>Şifreniz: {sifre}");
                }

                return result;
            }
        }

        public async Task<bool> PersonelGuncelleAsync(PersonelGuncelle_Dto personel)
        {
            var user = await userManager.FindByIdAsync(personel.Id.ToString());
            if (user == null)
            {
                return false;
            }
            user.Fotograf = personel.Fotograf;
            user.Adres = personel.Adres;
            user.PhoneNumber = personel.PhoneNumber;
            var result = await userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<IEnumerable<Personel_Dto>> TumPersonelleriListeleAsync(int sirketId)
        {
            List<Personel_Dto> tumPersoneller = new List<Personel_Dto>();

            var gelenPersoneller = await userManager.GetUsersInRoleAsync("Personel");

            var filtrelenmisPersoneller = gelenPersoneller.Where(user => user.SirketID == sirketId).ToList();

            mapper.Map(filtrelenmisPersoneller, tumPersoneller);

            return tumPersoneller;
        }


    }
}

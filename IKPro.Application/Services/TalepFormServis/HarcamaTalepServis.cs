using AutoMapper;
using IKPro.Application.DTOs.TalepForm;
using IKPro.Application.Services.PersonelServis;
using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;

namespace IKPro.Application.Services.TalepFormServis
{
    public class HarcamaTalepServis : IHarcamaTalepServis
    {
        private readonly IMapper mapper;
        private readonly IHarcamaTalepRepository harcamaTalepRepository;
        private readonly IPersonelServis _personelServis;

        public HarcamaTalepServis(IMapper mapper, IHarcamaTalepRepository harcamaTalepRepository, IPersonelServis personelServis)
        {
            this.mapper = mapper;
            this.harcamaTalepRepository = harcamaTalepRepository;
            _personelServis = personelServis;
        }

        public async Task<int> HarcamaTalepEkleAsync(HarcamaTalepEkle_Dto harcama)
        {
            HarcamaTalep yeniHarcama = new HarcamaTalep();
            mapper.Map(harcama, yeniHarcama);
            int talepID = await harcamaTalepRepository.EkleAsync(yeniHarcama);
            return talepID;
        }

        public async Task<bool> HarcamaTalepGuncelleAsync(TalepGuncelle_Dto harcama)
        {
            var harcamaDb = await harcamaTalepRepository.BulAsync(harcama.Id);
            if (harcamaDb == null)
            {
                return false;
            }
            harcamaDb.OnayDurumu = harcama.OnayDurumu;
            var result = await harcamaTalepRepository.GuncelleAsync(harcamaDb);
            return true;
        }

        public async Task<IEnumerable<HarcamaTalep_Dto>> HarcamaTalepleriListeleAsync(int sirketId)
        {
            List<HarcamaTalep_Dto> tumHarcamalar = new List<HarcamaTalep_Dto>();

            var gelenHarcamalar = await harcamaTalepRepository.ListeAsync();

            var ayniSirkettekiler = await _personelServis.TumPersonelleriListeleAsync(sirketId);

            var ortakKullanicilar = gelenHarcamalar
                .Where(izin => ayniSirkettekiler
                    .Any(personel => personel.Id == izin.AppUserId))
                .ToList();
            
            mapper.Map(ortakKullanicilar, tumHarcamalar);
            return tumHarcamalar;
        }
    }
}

using AutoMapper;
using IKPro.Application.DTOs.Sirket;
using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Data;

namespace IKPro.Application.Services.SirketServis
{
    public class SirketServis : ISirketServis
    {
        private readonly IMapper mapper;
        private readonly ISirketRepository sirketRepository;
        private readonly IKProDbContext context;

        public SirketServis(IMapper mapper, ISirketRepository sirketRepository, IKProDbContext context)
        {
            this.mapper = mapper;
            this.sirketRepository = sirketRepository;
            this.context = context;
        }

        public async Task<Sirket_Dto> SirketDetayGetirAsync(int id)
        {
            Sirket_Dto detay = new Sirket_Dto();
            Sirket sirket = context.Sirketler.Where(x=>x.SirketID==id).FirstOrDefault();
            mapper.Map(sirket, detay); 
            return detay;
        }        

        public async Task<int> SirketEkleAsync(SirketEkle_Dto sirket)
        {
            Sirket yeniSirket = new Sirket();
            mapper.Map(sirket, yeniSirket);
            int sirketID = await sirketRepository.EkleAsync(yeniSirket);
            return sirketID;
        }

        public async Task<bool> SirketGuncelleAsync(Sirket_Dto sirket)
        {
            Sirket guncelSirket = new Sirket();
            mapper.Map(sirket, guncelSirket);
            return await sirketRepository.GuncelleAsync(guncelSirket);
        }

        public async Task<bool> SirketSilAsync(int id)
        {
            Sirket sirket = new Sirket();
            sirket = await sirketRepository.BulAsync(id);
            sirket.Aktif = false;
            return await sirketRepository.GuncelleAsync(sirket);
        }

        public async Task<IEnumerable<Sirket_Dto>> TumSirketleriListeleAsync()
        {
            List<Sirket_Dto> tumSirketler = new List<Sirket_Dto>();
            var gelenSirketler = await sirketRepository.ListeAsync();
            mapper.Map(gelenSirketler, tumSirketler);
            return tumSirketler;
        }
    }
}

using AutoMapper;
using IKPro.Application.DTOs.Paket;
using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;

namespace IKPro.Application.Services.PaketServis
{
    public class PaketServis : IPaketServis
    {
        private readonly IMapper mapper;
        private readonly IPaketRepository paketRepository;

        public PaketServis(IMapper mapper, IPaketRepository paketRepository)
        {
            this.mapper = mapper;
            this.paketRepository = paketRepository;
        }

        public async Task<int> PaketEkleAsync(PaketEkle_Dto paket)
        {
            Paket yeniPaket = new Paket();
            mapper.Map(paket, yeniPaket);
            int paketID = await paketRepository.EkleAsync(yeniPaket);
            return paketID;
        }

        public async Task<IEnumerable<Paket_Dto>> TumPaketleriListeleAsync()
        {
            List<Paket_Dto> tumPaketler = new List<Paket_Dto>();
            var gelenUrunler = await paketRepository.ListeAsync();
            mapper.Map(gelenUrunler, tumPaketler);
            return tumPaketler;
        }
    }
}

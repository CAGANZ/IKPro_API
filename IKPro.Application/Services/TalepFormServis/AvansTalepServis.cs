using AutoMapper;
using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.TalepForm;
using IKPro.Application.Services.PersonelServis;
using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Repositories.Concretes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.Services.TalepFormServis
{
    public class AvansTalepServis : IAvansTalepServis
    {
        private readonly IMapper mapper;
        private readonly IAvansTalepRepository avansTalepRepository;
        private readonly IPersonelServis _personelServis;

        public AvansTalepServis(IMapper mapper, IAvansTalepRepository avansTalepRepository, IPersonelServis personelServis)
        {
            this.mapper = mapper;
            this.avansTalepRepository = avansTalepRepository;
            _personelServis = personelServis;
        }

        public async Task<int> AvansTalepEkleAsync(AvansTalepEkle_Dto avans)
        {
            AvansTalep yeniAvans = new AvansTalep();
            mapper.Map(avans, yeniAvans);
            var result = await avansTalepRepository.AvansMiktarAsync(avans.AppUserId, avans.Tutar);
            if (!result)
            {
                return -1;
            }
            int talepID = await avansTalepRepository.EkleAsync(yeniAvans);
            return talepID;
        }

        public async Task<bool> AvansTalepGuncelleAsync(TalepGuncelle_Dto avans)
        {
            var avansDb = await avansTalepRepository.BulAsync(avans.Id);
            if (avansDb == null)
            {
                return false;
            }
            avansDb.OnayDurumu = avans.OnayDurumu;
            var result = await avansTalepRepository.GuncelleAsync(avansDb);
            return true;
        }

        public async Task<IEnumerable<AvansTalep_Dto>> AvansTalepleriListeleAsync(int sirketId)
        {
            List<AvansTalep_Dto> tumAvanslar = new List<AvansTalep_Dto>();
            var gelenAvanslar = await avansTalepRepository.ListeAsync();
            var ayniSirkettekiler = await _personelServis.TumPersonelleriListeleAsync(sirketId);
            var ortakKullanicilar = gelenAvanslar
                .Where(izin => ayniSirkettekiler
                    .Any(personel => personel.Id == izin.AppUserId))
                .ToList();
            mapper.Map(ortakKullanicilar, tumAvanslar);
            return tumAvanslar;

        }
    }
}

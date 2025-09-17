using AutoMapper;
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
    public class IzinTalepServis : IIzinTalepServis
    {
        private readonly IMapper mapper;
        private readonly IIzinTalepRepository izinTalepRepository;
        private readonly IPersonelServis _personelServis;

        public IzinTalepServis(IMapper mapper, IIzinTalepRepository izinTalepRepository, IPersonelServis personelServis)
        {
            this.mapper = mapper;
            this.izinTalepRepository = izinTalepRepository;
            _personelServis = personelServis;
        }

        public async Task<int> IzinTalepEkleAsync(IzinTalepEkle_Dto izin)
        {
            IzinTalep yeniIzin = new IzinTalep();
            mapper.Map(izin, yeniIzin);
            int talepID = await izinTalepRepository.EkleAsync(yeniIzin);
            return talepID;
        }

        public async Task<bool> IzinTalepGuncelleAsync(TalepGuncelle_Dto izin)
        {
            var izinDb = await izinTalepRepository.BulAsync(izin.Id);
            if (izinDb == null)
            {
                return false;
            }
            izinDb.OnayDurumu = izin.OnayDurumu;
            var result = await izinTalepRepository.GuncelleAsync(izinDb);
            return true;
        }

        public async Task<IEnumerable<IzinTalep_Dto>> IzinTalepleriListeleAsync(int sirketId)
        {
            List<IzinTalep_Dto> tumIzinler = new List<IzinTalep_Dto>();
           
            var gelenIzinler = await izinTalepRepository.ListeAsync();
           
            var ayniSirkettekiler = await _personelServis.TumPersonelleriListeleAsync(sirketId);
           
            var ortakKullanicilar = gelenIzinler
                .Where(izin => ayniSirkettekiler
                    .Any(personel => personel.Id == izin.AppUserId))
                .ToList();

            mapper.Map(ortakKullanicilar, tumIzinler);

            return tumIzinler;
        }
    }
}

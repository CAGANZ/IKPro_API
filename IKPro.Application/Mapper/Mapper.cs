
using AutoMapper;
using IKPro.Application.DTOs.Login;
using IKPro.Application.DTOs.Paket;
using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.TalepForm;
using IKPro.Application.DTOs.User;
using IKPro.Domain.Models;

namespace IKPro.Application.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() 
        {
            // Paket
            CreateMap<Paket, Paket_Dto>().ReverseMap();
            CreateMap<Paket, PaketEkle_Dto>().ReverseMap();

            //AppUser - şirket yönetici
            CreateMap<AppUser, SirketYonetici_Dto>().ReverseMap();
            CreateMap<AppUser, SirketYoneticiEkle_Dto>().ReverseMap();
            CreateMap<AppUser, SirketYoneticiGuncelle_Dto>().ReverseMap();
            
            CreateMap<AppUser, SiteYonetici_Dto>().ReverseMap();
            CreateMap<AppUser, SiteYoneticiEkle_Dto>().ReverseMap();
            CreateMap<AppUser, SiteYoneticiGuncelle_Dto>().ReverseMap();
            
            CreateMap<AppUser, Personel_Dto>().ReverseMap();
            CreateMap<AppUser, PersonelEkle_Dto>().ReverseMap();
            CreateMap<AppUser, PersonelGuncelle_Dto>().ReverseMap();
            
            CreateMap<AppUser, Login_Dto>().ReverseMap();
            CreateMap<AppUser, UyeKayit_Dto>().ReverseMap();

            //şirket
            CreateMap<Sirket, Sirket_Dto>().ReverseMap();
            CreateMap<Sirket, SirketEkle_Dto>().ReverseMap();

            //Talep map
            CreateMap<HarcamaTalep, HarcamaTalepEkle_Dto>().ReverseMap();
            CreateMap<HarcamaTalep, HarcamaTalep_Dto>().ReverseMap();
            CreateMap<IzinTalep, IzinTalepEkle_Dto>().ReverseMap();
            CreateMap<IzinTalep, IzinTalep_Dto>().ReverseMap();
            CreateMap<AvansTalep, AvansTalepEkle_Dto>().ReverseMap();
            CreateMap<AvansTalep, AvansTalep_Dto>().ReverseMap();
            CreateMap<HarcamaTalep, TalepGuncelle_Dto>().ReverseMap();
            CreateMap<IzinTalep, TalepGuncelle_Dto>().ReverseMap();
            CreateMap<AvansTalep, TalepGuncelle_Dto>().ReverseMap();

            // readonly mapler için reversemap olmasada olur***
        }
    }
}

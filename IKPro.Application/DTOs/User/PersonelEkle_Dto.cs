using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.DTOs.User
{
    public class PersonelEkle_Dto
    {
        public string? Fotograf { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string? IkinciAdi { get; set; }
        public string? IkinciSoyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string TcNo { get; set; }
        public DateTime IseGirisTarih { get; set; }
        public DateTime? IstenCikisTarihi { get; set; }
        public bool Aktif { get; set; }
        public string Meslek { get; set; }
        public string Departman { get; set; }
        public int SirketID { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Maas { get; set; }
    }
}

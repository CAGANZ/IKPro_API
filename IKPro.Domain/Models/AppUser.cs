using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace IKPro.Domain.Models
{
    public class AppUser :IdentityUser<int>
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string? IkinciAdi { get; set; }
        public string? IkinciSoyadi { get; set; }
        public string? Fotograf { get; set; }
        public string TcNo { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime IseGirisTarih { get; set; }
        public DateTime? IstenCikisTarihi { get; set; }
        public bool Aktif { get; set; }
        public string? Meslek { get; set; }
        public string Departman { get; set; } 
        public string Adres { get; set; }
        public decimal? Maas { get; set; }

        //navprop
        public int? SirketID { get; set; }
        [ForeignKey("SirketID")]
        public Sirket? Sirket { get; set; }
        public ICollection<IzinTalep> izinTalepleri { get; set; }
        public ICollection<HarcamaTalep> harcamaTalepleri { get; set; }
        public ICollection<AvansTalep> avansTalepleri { get; set; }
    }
}

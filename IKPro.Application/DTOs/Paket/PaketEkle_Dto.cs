using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.DTOs.Paket
{
    public class PaketEkle_Dto
    {
        public string PaketAdi { get; set; }
        public int PaketSuresi { get; set; }
        public DateTime YayinlanmaTarihi { get; set; }
        public DateTime YayindanKaldirilmaTarihi { get; set; }
        public decimal Fiyat { get; set; }
        public bool Aktif { get; set; }
        public int KullaniciSayisi { get; set; }
        public string ParaBirimi { get; set; }

    }
}

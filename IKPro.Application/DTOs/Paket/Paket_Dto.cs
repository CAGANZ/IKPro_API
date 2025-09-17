namespace IKPro.Application.DTOs.Paket
{
    public class Paket_Dto
    {
        // Product owner listeleme için hangi alanları istiyorsa ona göre doldurulacak...
        public int PaketID { get; set; }
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

namespace IKPro.Domain.Models
{
    public class Paket
    {
        public int PaketID { get; set; }
        public string PaketAdi { get; set; }
        public int PaketSuresi { get; set; }
        public DateTime YayinlanmaTarihi { get; set; }
        public DateTime YayindanKaldirilmaTarihi { get; set; }
        public decimal Fiyat { get; set; }
        public bool Aktif { get; set; }
        public int KullaniciSayisi { get; set; }
        public string ParaBirimi { get; set; }

        //nav. prop   
        public ICollection<Sirket>? Sirketler { get; set; }
    }
}

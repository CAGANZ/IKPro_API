namespace IKPro.Domain.Models
{
    public class Sirket
    {
        public int SirketID { get; set; }
        public string Ad { get; set; }
        public string Unvan { get; set; }
        public string MersisNo { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string Logo { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public int CalisanSayisi { get; set; }
        public short KurulusYili { get; set; }
        public DateTime SozlesmeBaslangic { get; set; }
        public DateTime SozlesmeBitis { get; set; }
        public bool Aktif { get; set; } = true;

        //navprop
        public int PaketID { get; set; }
        public Paket? Paket { get; set; }
        public ICollection<AppUser>? Users { get; set; }
    }
}

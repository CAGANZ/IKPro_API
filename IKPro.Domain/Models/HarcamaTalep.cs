using IKPro.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Domain.Models
{
    public class HarcamaTalep
    {
        public int Id { get; set; }
        public string HarcamaTuru { get; set; }
        public string ParaBirimi { get; set; }
        public OnayDurumu OnayDurumu { get; set; }
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public DateTime? CevaplanmaTarihi { get; set; }
        public string DosyaEkleme { get; set; }
        public decimal Tutar { get; set; }

        //np
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}

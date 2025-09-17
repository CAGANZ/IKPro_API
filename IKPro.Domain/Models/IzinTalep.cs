using IKPro.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Domain.Models
{
    public class IzinTalep
    {
        public int Id { get; set; }
        public string IzinTuru { get; set; } // buna bi şey açabiliriz ama gerekte yok
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public  short GunSayisi { get; set; }
        public DateTime? CevaplanmaTarihi { get; set; }
        public OnayDurumu OnayDurumu { get; set; }

        //np
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}

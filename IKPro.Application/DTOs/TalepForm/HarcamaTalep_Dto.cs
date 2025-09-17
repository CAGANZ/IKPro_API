using IKPro.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.DTOs.TalepForm
{
    public class HarcamaTalep_Dto
    {
        public int Id { get; set; }
        public string HarcamaTuru { get; set; }
        public string ParaBirimi { get; set; }
        public OnayDurumu OnayDurumu { get; set; }
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public DateTime? CevaplanmaTarihi { get; set; }
        public string DosyaEkleme { get; set; }
        public decimal Tutar { get; set; }


        public int AppUserId { get; set; }
    }
}

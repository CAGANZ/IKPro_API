using IKPro.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.DTOs.TalepForm
{
    public class AvansTalepEkle_Dto
    {
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public OnayDurumu OnayDurumu { get; set; }
        public DateTime? CevaplanmaTarihi { get; set; }
        public decimal Tutar { get; set; }
        public string ParaBirimi { get; set; }
        public string Aciklama { get; set; }
        public string AvansTuru { get; set; }
        public int AppUserId { get; set; }
    }
}

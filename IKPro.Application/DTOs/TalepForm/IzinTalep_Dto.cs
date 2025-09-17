using IKPro.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.DTOs.TalepForm
{
    public class IzinTalep_Dto
    {
        public int Id { get; set; }
        public string IzinTuru { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public DateTime TalepTarihi { get; set; } = DateTime.Now;
        public short GunSayisi { get; set; }
        public DateTime? CevaplanmaTarihi { get; set; }
        public OnayDurumu OnayDurumu { get; set; }


        public int AppUserId { get; set; }
    }
}

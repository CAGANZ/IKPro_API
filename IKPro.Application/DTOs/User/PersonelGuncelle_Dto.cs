using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.DTOs.User
{
    public class PersonelGuncelle_Dto
    {
        public int Id { get; set; }
        public string? Fotograf { get; set; }
        public string Adres { get; set; }
        public string PhoneNumber { get; set; }
    }
}

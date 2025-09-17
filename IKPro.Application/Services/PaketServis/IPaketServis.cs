using IKPro.Application.DTOs.Paket;
using IKPro.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.Services.PaketServis
{
    public interface IPaketServis
    {
        public Task<int> PaketEkleAsync(PaketEkle_Dto paket);
        public Task<IEnumerable<Paket_Dto>> TumPaketleriListeleAsync();        

        // bu sayfaya dön bak tüm silinenler okey mi diye 
    }
}

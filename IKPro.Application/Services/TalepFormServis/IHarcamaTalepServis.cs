using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.TalepForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.Services.TalepFormServis
{
    public interface IHarcamaTalepServis
    {
        public Task<int> HarcamaTalepEkleAsync(HarcamaTalepEkle_Dto harcama);
        public Task<IEnumerable<HarcamaTalep_Dto>> HarcamaTalepleriListeleAsync(int sirketId);
        public Task<bool> HarcamaTalepGuncelleAsync(TalepGuncelle_Dto harcama);
    }
}

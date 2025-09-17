using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.TalepForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.Services.TalepFormServis
{
    public interface IIzinTalepServis
    {
        public Task<int> IzinTalepEkleAsync(IzinTalepEkle_Dto izin);
        public Task<IEnumerable<IzinTalep_Dto>> IzinTalepleriListeleAsync(int sirketId);
        public Task<bool> IzinTalepGuncelleAsync(TalepGuncelle_Dto izin);
    }
}

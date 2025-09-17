using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.TalepForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Application.Services.TalepFormServis
{
    public interface IAvansTalepServis
    {
        public Task<int> AvansTalepEkleAsync(AvansTalepEkle_Dto avans);
        public Task<IEnumerable<AvansTalep_Dto>> AvansTalepleriListeleAsync(int sirketId);
        public Task<bool> AvansTalepGuncelleAsync(TalepGuncelle_Dto avans);
    }
}

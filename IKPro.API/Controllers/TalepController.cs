using IKPro.Application.DTOs.Sirket;
using IKPro.Application.DTOs.TalepForm;
using IKPro.Application.DTOs.User;
using IKPro.Application.Services.TalepFormServis;
using IKPro.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IKPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TalepController : ControllerBase
    {
        private readonly IIzinTalepServis _izinTalepServis;
        private readonly IAvansTalepServis _avansTalepServis;
        private readonly IHarcamaTalepServis _harcamaTalepServis;

        public TalepController(IIzinTalepServis izinTalepServis, IAvansTalepServis avansTalepServis, IHarcamaTalepServis harcamaTalepServis)
        {
            _izinTalepServis = izinTalepServis;
            _avansTalepServis = avansTalepServis;
            _harcamaTalepServis = harcamaTalepServis;
        }

                
        [HttpPost("avansTalepEkle")]
        //[Authorize(Roles = "Personel")]
        public async Task<ActionResult<int>> AvansTalepEkle(AvansTalepEkle_Dto avans)
        {
            var result = await _avansTalepServis.AvansTalepEkleAsync(avans);
            if (result>0)
                return Ok(result);
            else
                return BadRequest("Talep Başarısız.");
        }
        

        [HttpGet("avansTalepListele/{sirketId}")]
        public async Task<ActionResult<IEnumerable<AvansTalep_Dto>>> TumAvanslar(int sirketId)
        {
            var result = await _avansTalepServis.AvansTalepleriListeleAsync(sirketId);
            return Ok(result);
        }
        

        [HttpPut("avansTalepGuncelle")]
        public async Task<ActionResult> AvansTalepGuncelle(TalepGuncelle_Dto avans)
        {
            var result = await _avansTalepServis.AvansTalepGuncelleAsync(avans);
            if (result)
            return Ok(result);
            else
                return BadRequest("Talep Başarısız.");
        }

        
        [HttpPost("harcamaTalepEkle")]
        //[Authorize(Roles = "Personel")]
        public async Task<ActionResult<int>> HarcamaTalepEkle(HarcamaTalepEkle_Dto harcama)
        {
            var result = await _harcamaTalepServis.HarcamaTalepEkleAsync(harcama);
            if (result > 0)
                return Ok(result);
            else
                return BadRequest("Talep Başarısız.");
        }
       

        [HttpGet("harcamaTalepListele/{sirketId}")]
        public async Task<ActionResult<IEnumerable<HarcamaTalep_Dto>>> TumHarcamalar(int sirketId)
        {
            var result = await _harcamaTalepServis.HarcamaTalepleriListeleAsync(sirketId);
            return Ok(result);
        }
        

        [HttpPut("harcamaTalepGuncelle")]
        public async Task<ActionResult> HarcamaTalepGuncelle(TalepGuncelle_Dto harcama)
        {
            var result = await _harcamaTalepServis.HarcamaTalepGuncelleAsync(harcama);
            if (result)
                return Ok(result);
            else
                return BadRequest("Talep Başarısız.");
        }

        

        [HttpPost("izinTalepEkle")]
        //[Authorize(Roles = "Personel")]
        public async Task<ActionResult<int>> IzinTalepEkle(IzinTalepEkle_Dto izin)
        {
            var result = await _izinTalepServis.IzinTalepEkleAsync(izin);
            if (result > 0)
                return Ok(result);
            else
                return BadRequest("Talep Başarısız.");
        }
       

        [HttpGet("izinTalepListele/{sirketId}")]
        public async Task<ActionResult<IEnumerable<IzinTalep_Dto>>> TumIzinler(int sirketId)
        {
            var result = await _izinTalepServis.IzinTalepleriListeleAsync(sirketId);
            return Ok(result);
        }
       

        [HttpPut("izinTalepGuncelle")]
        public async Task<ActionResult> IzinTalepGuncelle(TalepGuncelle_Dto izin)
        {
            var result = await _izinTalepServis.IzinTalepGuncelleAsync(izin);
            if (result)
                return Ok(result);
            else
                return BadRequest("Talep Başarısız.");
        }


    }
}

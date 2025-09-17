using IKPro.Application.DTOs.User;
using IKPro.Application.Services.PersonelServis;
using IKPro.Application.Services.SirketYoneticiServis;
using IKPro.Application.Services.SiteYoneticiServis;
using Microsoft.AspNetCore.Mvc;

namespace IKPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly ISiteYoneticiServis _siteYoneticiServis;
        private readonly ISirketYoneticiServis _sirketYoneticiServis;
        private readonly IPersonelServis _personelServis;

        public UserController(ISiteYoneticiServis siteYoneticiServis, ISirketYoneticiServis sirketYoneticiServis, IPersonelServis personelServis)
        {
            _siteYoneticiServis = siteYoneticiServis;
            _sirketYoneticiServis = sirketYoneticiServis;
            _personelServis = personelServis;
        }


       
        [HttpGet("siteyonetici/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<SiteYonetici_Dto>> SiteYoneticiDetayGetir(int id)
        {
            var result = await _siteYoneticiServis.SiteYoneticiDetayGetirAsync(id);
            if (result == null)
                return NotFound(new { message = "Site yöneticisi bulunamadı!" });
            return Ok(result);
        }
       

        [HttpPut("siteyonetici")]
        //[Authorize(Roles = "SiteYonetici")]
        public async Task<ActionResult<bool>> SiteYoneticisiGuncelle(SiteYoneticiGuncelle_Dto siteYoneticiDto)
        {
            var result = await _siteYoneticiServis.SiteYoneticiGuncelleAsync(siteYoneticiDto);
            if (result)
                return Ok(result);
            return BadRequest("Güncelleme başarısız");
        }



        
        [HttpGet("sirketyonetici/{id}")]
        //[Authorize(Roles = "SirketYonetici")]
        public async Task<ActionResult<SirketYonetici_Dto>> YoneticiDetayGetir(int id)
        {
            var result = await _sirketYoneticiServis.SirketYoneticiDetayGetirAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        

        [HttpGet("sirketyoneticilistesi")]
        //[Authorize(Roles = "SirketYonetici")]
        public async Task<ActionResult<SirketYonetici_Dto>> SirketYoneticiListele()
        {
            var result = await _sirketYoneticiServis.TumSirketYoneticileriniListeleAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        

        [HttpPost("sirketyoneticiekle")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> SirketYoneticisiEkleAsync(SirketYoneticiEkle_Dto sirketYoneticiDto)
        {   
            var result = await _sirketYoneticiServis.SirketYoneticiEkleAsync(sirketYoneticiDto);
            if (result.Succeeded)
                return Ok(result);
            else
                return BadRequest(result.Errors);
        }
        

        [HttpPut("sirketyoneticiguncelle")]
        //[Authorize(Roles = "SirketYonetici")]
        public async Task<ActionResult<bool>> SirketYoneticisiGuncelle(SirketYoneticiGuncelle_Dto sirketYoneticiDto)
        {
            var result = await _sirketYoneticiServis.SirketYoneticiGuncelleAsync(sirketYoneticiDto);
            if (result)
                return Ok(result);
            return BadRequest("Güncelleme başarısız");
        }


                
        [HttpGet("personelDetayGetir/{id}")]
        //[Authorize(Roles = "Personel")]
        public async Task<ActionResult<Personel_Dto>> PersonelDetayGetir(int id)
        {
            var result = await _personelServis.PersonelDetayGetirAsync(id);
            if (result == null)
                return NotFound(new { message = "Personel bulunamadı!" });
            return Ok(result);
        }
       

        [HttpPost("personelEkle")]
        //[Authorize(Roles = "SirketYonetici")]
        public async Task<ActionResult<int>> PersonelEkle(PersonelEkle_Dto personelDto)
        {

            var result = await _personelServis.PersonelEkleAsync(personelDto);
            if (result.Succeeded)
                return Ok(result);
            else
                return BadRequest(result.Errors);
        }
        

        [HttpPut("personelGuncelle")]
        //[Authorize(Roles = "Personel")]
        public async Task<ActionResult<bool>> PersonelGuncelle(PersonelGuncelle_Dto personelDto)
        {
            var result = await _personelServis.PersonelGuncelleAsync(personelDto);
            if (result)
                return Ok(result);
            return BadRequest("Güncelleme başarısız");
        }
        

        [HttpGet("personelgetir/{sirketId}")]
        //[Authorize(Roles = "SirketYonetici")]
        public async Task<ActionResult<Personel_Dto>> PersonelListele(int sirketId)
        {
            var result = await _personelServis.TumPersonelleriListeleAsync(sirketId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}

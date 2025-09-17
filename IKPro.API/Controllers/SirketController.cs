using IKPro.Application.DTOs.Sirket;
using IKPro.Application.Services.SirketServis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IKPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SirketController : ControllerBase
    {
        private readonly ISirketServis _sirketServis;

        public SirketController(ISirketServis sirketServis)
        {
            _sirketServis = sirketServis;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sirket_Dto>>> TumSirketler()
        {
            var result = await _sirketServis.TumSirketleriListeleAsync();
            return Ok(result);
        }

       
        [HttpPost("sirketekle")]
        public async Task<ActionResult<int>> SirketEkle(SirketEkle_Dto sirketDto)
        {
            try
            {
                var result = await _sirketServis.SirketEkleAsync(sirketDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message} - {ex.StackTrace}");
                return StatusCode(500, "Sunucu tarafında bir hata oluştu.");
            }
        }

    }
}

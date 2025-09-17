using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Infrastructure.Repositories.Concretes
{
    public class AvansTalepRepository : BaseRepository<AvansTalep>, IAvansTalepRepository
    {
        private readonly IKProDbContext _context;
        public AvansTalepRepository(IKProDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AvansMiktarAsync(int personelId, decimal avansTutar)
        {
            var personel = await _context.Users.Where(x => x.Id == personelId)
                .FirstOrDefaultAsync();
            if (personel == null) 
            {
                throw new Exception("Personel bulunamadı.");
            }
            decimal? maksAvans = personel.Maas * 3;
            if(avansTutar > maksAvans)
            {
                return false;
            }
            return true;
        }
    }
}

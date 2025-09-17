using IKPro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Domain.Repositories.Abstract
{
    public interface IAvansTalepRepository : IBaseRepository<AvansTalep>
    {
        Task<bool> AvansMiktarAsync(int personelId, decimal avansTutar);
    }
}

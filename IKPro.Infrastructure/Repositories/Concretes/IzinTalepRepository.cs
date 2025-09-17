using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKPro.Infrastructure.Repositories.Concretes
{
    public class IzinTalepRepository : BaseRepository<IzinTalep>, IIzinTalepRepository
    {
        public IzinTalepRepository(IKProDbContext context) : base(context)
        {
        }
    }
}

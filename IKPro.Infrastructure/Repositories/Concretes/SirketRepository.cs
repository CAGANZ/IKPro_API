using IKPro.Domain.Models;
using IKPro.Domain.Repositories.Abstract;
using IKPro.Infrastructure.Data;

namespace IKPro.Infrastructure.Repositories.Concretes
{
    public class SirketRepository : BaseRepository<Sirket>, ISirketRepository
    {
        public SirketRepository(IKProDbContext context) : base(context)
        {
        }
    }
}

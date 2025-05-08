using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using SelfiesAWookies.Core.Framework;


namespace SelfieAWookie.Core.Selfies.Infrastructures.Repositories
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        private SelfieContext context = null;
        public IUnitOfWork UnitOfWork => this.context;

        public DefaultSelfieRepository(SelfieContext context )
        {
            this.context = context;
        }

        public ICollection<Selfie> GetAll(int? wookieId)
        {
            var query = context.Selfies.Include(item => item.Wookie).AsQueryable();

            if(wookieId > 0)
            {
                query = query.Where(item => item.WookieId == wookieId);
            }
            return query.ToList();
        }

        public Selfie AddOne(Selfie item)
        {
            return this.context.Selfies.Add(item).Entity;
        }

        public Picture AddOne(string url)
        {
            return this.context.Pictures.Add(new Picture()
            {
                Url = url
            }).Entity; 
        }
    }
}

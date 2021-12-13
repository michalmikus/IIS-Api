using Microsoft.EntityFrameworkCore;
using TransportIS.DAL;
using TransportIS.DAL.Entities;

namespace TransportIS.BL.Repository
{
    public class ConnectionRepository : Repository<ConnectionEntity>
    {
        public ConnectionRepository(Func<TransportISDbContext> contextProvider) : base(contextProvider)
        {
        }

        public override IQueryable<ConnectionEntity> AddIncludes(DbSet<ConnectionEntity> dbSet)
        {
            return dbSet.Include(c => c.Stops);
        }
    }
}



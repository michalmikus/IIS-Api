using Microsoft.EntityFrameworkCore;
using TransportIS.DAL;

namespace TransportIS.BL.Repository
{
    public class CarrierRepository : Repository<CarrierEntity>
    {
        public CarrierRepository(Func<TransportISDbContext> contextProvider) : base(contextProvider)
        {
        }

        public override IQueryable<CarrierEntity> AddIncludes(DbSet<CarrierEntity> dbSet)
        {
            return dbSet.Include(c => c.Connections).Include(c => c.Emploees).Include(c => c.Vehicles);
        }
    }
}



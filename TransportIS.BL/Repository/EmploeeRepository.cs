using TransportIS.DAL;
using TransportIS.DAL.Entities;

namespace TransportIS.BL.Repository
{
    public class EmploeeRepository : Repository<EmploeeEntity>
    {
        public EmploeeRepository(Func<TransportISDbContext> contextProvider) : base(contextProvider)
        {
        }
    }
}



using TransportIS.DAL;

namespace TransportIS.BL.Repository
{
    public class VehicleRepository : Repository<VehicleEntity>
    {
        public VehicleRepository(Func<TransportISDbContext> contextProvider) : base(contextProvider)
        {
        }
    }
}



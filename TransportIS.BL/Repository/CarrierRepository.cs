using TransportIS.DAL;

namespace TransportIS.BL.Repository
{
    public class CarrierRepository : Repository<CarrierEntity>
    {
        public CarrierRepository(Func<TransportISDbContext> contextProvider) : base(contextProvider)
        {
        }
    }
}



using Microsoft.EntityFrameworkCore;

namespace TransportIS.DAL.Database
{
    public class DbContextInMemoryFactory
    {
        private readonly string _databaseName;
        public DbContextInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }

        public TransportISDbContext CreateDbContex()
        {
            var context = new DbContextOptionsBuilder<TransportISDbContext>();
            context.UseInMemoryDatabase(_databaseName);
            return new TransportISDbContext(context.Options);
        }
    }
}

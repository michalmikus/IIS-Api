using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities;

namespace TransportIS.DAL.Database
{
    public class SeedDatabase
    {
        private readonly TransportISDbContext dbContext;
        private readonly UserManager<UserEntity> userManager;

        public SeedDatabase(TransportISDbContext dbContext, UserManager<UserEntity> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task SeedData()
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}

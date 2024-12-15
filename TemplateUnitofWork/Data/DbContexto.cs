using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TemplateUnitofWork.Repository;

namespace TemplateUnitofWork.Data
{
   
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        // DbSets
        public DbSet<YourEntity> YourEntities { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();
            optionsBuilder.UseSqlServer("DESKTOP-99RGCMA\\SQLEXPRESS;Initial Catalog=Sample;User ID=sa;Password=123;TrustServerCertificate=True");

            return new SampleDbContext(optionsBuilder.Options);
        }
    }
}

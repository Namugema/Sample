using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class SampleDbContext: DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        { 

        }
        public DbSet<Project> Projects { get; set; }
    }

}

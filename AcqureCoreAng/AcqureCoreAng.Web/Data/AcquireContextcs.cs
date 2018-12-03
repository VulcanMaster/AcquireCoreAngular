using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcqureCoreAng.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcqureCoreAng.Web.Data
{
    public class AcquireContext : DbContext    {
        public AcquireContext(DbContextOptions<AcquireContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

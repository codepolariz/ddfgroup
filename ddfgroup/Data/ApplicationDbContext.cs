using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ddfgroup.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Cars>()
            //.HasOne(p => p.CarsModel)
            //.WithMany(b => b.Cars)
            //.HasForeignKey(p => p.CarsModelId);
            base.OnModelCreating(builder);
        }

        public DbSet<PageContents> PageInfo { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Feedback>  Feedback { get; set; }
        public DbSet<Brands>  Brands { get; set; }

        public DbSet<CarsModel> CarsModel { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<CarStatus> CarStatus { get; set; }
        public DbSet<Currency> Currencies { get; set; }


    }
}

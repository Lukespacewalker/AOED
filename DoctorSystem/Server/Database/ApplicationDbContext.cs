using DoctorSystem.Shared.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DoctorSystem.Server.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ApplicationUser>().HasOne<Doctor>().WithOne();

            base.OnModelCreating(builder);
        }

        //private static string _connectionString;
        //private readonly IConfiguration configuration;
        // Uncomment Enable DB Migration for dotnet ef and Package Manager Console
        //public AOEDDbContext() { }

        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //    _connectionString = this.configuration.GetConnectionString("DoctorSystemDatabase");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString ?? @"Server=(localdb)\mssqllocaldb;Database=AOED;Integrated Security=True;MultipleActiveResultSets=True");
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

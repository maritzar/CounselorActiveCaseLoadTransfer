using Counselor_Active_CaseLoad_Transfer.Models;
using Microsoft.EntityFrameworkCore;


namespace Counselor_Active_CaseLoad_Transfer.Data
{
    public class AdvocateUsersDbContext: DbContext
    {
        public AdvocateUsersDbContext(DbContextOptions<AdvocateUsersDbContext> options)
            : base(options)
        {
        }
        public DbSet<AspNetProfile> AspNetProfiles { get; set; } = null!;

        public DbSet<AspnetMembership> AspnetMemberships { get; set; }
        public DbSet<VwProfileProperties> VwProfileProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<AspNetProfile>().ToTable("aspnet_Profile", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<AspnetMembership>().ToTable("aspnet_Membership", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<VwProfileProperties>().ToView("vw_ProfileProperties").HasNoKey();
        }
    }
}

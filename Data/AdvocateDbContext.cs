using Counselor_Active_CaseLoad_Transfer.Models;
using Microsoft.EntityFrameworkCore;

namespace Counselor_Active_CaseLoad_Transfer.Data
{
    public class AdvocateDbContext : DbContext
    {
        public AdvocateDbContext(DbContextOptions<AdvocateDbContext> options) : base(options) { }

        public DbSet<CaseProgram> CasePrograms { get; set; }
        public DbSet<CaseProgramStatus> CaseProgramStatuses { get; set; }
        public DbSet<CaseProgramStatusType> CaseProgramStatusTypes { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientLanguage> ClientLanguages { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramType>().ToTable("Program");
            modelBuilder.Entity<CaseProgram>().ToTable("CaseProgram");
            modelBuilder.Entity<CaseProgramStatus>().ToTable("CaseProgramStatus");
            modelBuilder.Entity<CaseProgramStatusType>().ToTable("CaseProgramStatusType");
            modelBuilder.Entity<Case>().ToTable("Case");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<ClientLanguage>().ToTable("ClientLanguage");
         
        }
    }
}

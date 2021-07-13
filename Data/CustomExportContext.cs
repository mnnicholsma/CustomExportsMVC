using Microsoft.EntityFrameworkCore;
using System;

namespace CustomExports.Data
{
    public class CustomExportContext : DbContext
    {
        public CustomExportContext(DbContextOptions<CustomExportContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ExportConfig> ExportConfigs { get; set; }
        public DbSet<AppLog> AppLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(100)
                .IsRequired();
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(c => c.Client)
                    .WithMany(a => a.Accounts)
                    .HasForeignKey("ClientId")
                   .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Id).ValueGeneratedNever();

            });

            modelBuilder.Entity<ExportConfig>(entity =>
            {
                entity.HasOne(c => c.Client)
                    .WithMany(e => e.ExportConfigs)
                    .HasForeignKey("ClientId")
                   .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Delimiter).HasMaxLength(1);

            });


            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, ClientId = 1, AccountNumber = "5000", Balance = 100.12, FacilityId = 1, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-01"), PatientId = 200 },
                new Account { Id = 2, ClientId = 2, AccountNumber = "5001", Balance = 566.22, FacilityId = 1, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-02"), PatientId = 200 },
                new Account { Id = 3, ClientId = 2, AccountNumber = "5002", Balance = 1921.00, FacilityId = 1, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-03"), PatientId = 200 },
                new Account { Id = 4, ClientId = 1, AccountNumber = "5003", Balance = 50.44, FacilityId = 2, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-04"), PatientId = 201 },
                new Account { Id = 5, ClientId = 1, AccountNumber = "5004", Balance = 100.00, FacilityId = 2, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-05"), PatientId = 201 },
                new Account { Id = 6, ClientId = 2, AccountNumber = "5005", Balance = 875.22, FacilityId = 2, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-06"), PatientId = 202 },
                new Account { Id = 7, ClientId = 2, AccountNumber = "5006", Balance = 44.33, FacilityId = 5, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-07"), PatientId = 202 },
                new Account { Id = 8, ClientId = 2, AccountNumber = "5007", Balance = 10.95, FacilityId = 5, AdmitDate = DateTime.Parse("2005-09-01"), DischargeDate = DateTime.Parse("2005-09-08"), PatientId = 202 }
                );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, ExportFormatId=1, Name = "General Hospital" },
                new Client { Id = 2, ExportFormatId=2, Name = "Veteran Hospital" }
                );

            modelBuilder.Entity<ExportConfig>().HasData(
                new ExportConfig { Id = 1, ClientId = 1, Delimiter="|", ExportType = "Pipe Delimited Format" },
                new ExportConfig { Id = 2, ClientId = 2, Delimiter=",", ExportType = "Comma Delimited Format" }
                );

        }

    }


}


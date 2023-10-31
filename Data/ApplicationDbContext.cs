using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Interfaces;
using System.Collections.Generic;
using T4Challenge.Models;
using System.Threading.Tasks;

namespace T4Challenge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IPersistedGrantDbContext
    {
        public DbSet<FormSubmission> FormSubmissions { get; set; }
        public DbSet<FieldDefinition> FieldDefinitions { get; set; }
        public DbSet<DynamicField> DynamicFields { get; set; }

        // IPersistedGrantDbContext properties
        public DbSet<IdentityServer4.EntityFramework.Entities.PersistedGrant> PersistedGrants { get; set; }
        public DbSet<IdentityServer4.EntityFramework.Entities.DeviceFlowCodes> DeviceFlowCodes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Other configurations...

            // Configure the FormSubmission entity
            modelBuilder.Entity<FormSubmission>(entity =>
            {
                // Other configurations...

                // Configure the DynamicFields property as JSON in the database
                entity.HasMany(e => e.DynamicFields)
                    .WithOne(e => e.FormSubmission)
                    .HasForeignKey(e => e.FormSubmissionId);
         
        });

            // Add configuration for DeviceFlowCodes
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.DeviceFlowCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode); // Assuming UserCode is the primary key, adjust accordingly

                // Additional configuration if needed
            });

            // Add configuration for PersistedGrant
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key); // Assuming Key is the primary key, adjust accordingly

                // Additional configuration if needed
            });
        }
    }
}

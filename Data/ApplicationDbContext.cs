using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamAlpha.Models;

namespace TeamAlpha.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectContractor>()
                .HasKey(pc => new { pc.ProjectId, pc.ContractorId });

            modelBuilder.Entity<ProjectContractor>()
                .HasOne(pc => pc.Project)
                .WithMany(p => p.ProjectContractors)
                .HasForeignKey(pc => pc.ProjectId);

            modelBuilder.Entity<ProjectContractor>()
                .HasOne(pc => pc.Contractor)
                .WithMany(c => c.ProjectContractors)
                .HasForeignKey(pc => pc.ContractorId);

            modelBuilder.Entity<ProjectVendor>()
        .HasKey(pv => new { pv.ProjectId, pv.VendorId });

            modelBuilder.Entity<ProjectVendor>()
                .HasOne(pv => pv.Project)
                .WithMany(p => p.ProjectVendors)
                .HasForeignKey(pv => pv.ProjectId);

            modelBuilder.Entity<ProjectVendor>()
                .HasOne(pv => pv.Vendor)
                .WithMany(v => v.ProjectVendors)
                .HasForeignKey(pv => pv.VendorId);
        }
        public DbSet<TeamAlpha.Models.Contractor> Contractor { get; set; } = default!;
        public DbSet<TeamAlpha.Models.Customer> Customer { get; set; } = default!;
        public DbSet<TeamAlpha.Models.Inquiry> Inquiry { get; set; } = default!;
        public DbSet<TeamAlpha.Models.Phase> Phase { get; set; } = default!;
        public DbSet<TeamAlpha.Models.Project> Project { get; set; } = default!;
        public DbSet<TeamAlpha.Models.Vendor> Vendor { get; set; } = default!;

    }
}

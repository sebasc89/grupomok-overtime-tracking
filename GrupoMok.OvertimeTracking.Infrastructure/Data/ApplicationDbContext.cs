using GrupoMok.OvertimeTracking.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrupoMok.OvertimeTracking.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OvertimeRequest> OvertimeRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure and Map Entities

            base.OnModelCreating(modelBuilder);

            // Configure primary keys
            modelBuilder.Entity<Area>()
            .HasKey(a => a.AreaId);

            modelBuilder.Entity<Area>()
            .HasIndex(a => a.Name);

            modelBuilder.Entity<Position>()
                .HasKey(p => p.PositionId);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<OvertimeRequest>()
            .HasKey(o => o.RequestId);

            modelBuilder.Entity<OvertimeRequest>()
             .Property(o => o.OvertimeHours)
             .HasPrecision(18, 2);

            modelBuilder.Entity<ApprovalStatus>()
            .HasKey(a => a.StatusId);

            // Configure relationships 
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Area)
            .WithMany()
            .HasForeignKey(e => e.AreaId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<OvertimeRequest>()
           .HasOne(o => o.Employee)
           .WithMany()
           .HasForeignKey(o => o.EmployeeId);

            modelBuilder.Entity<OvertimeRequest>()
                .HasOne(o => o.ApprovalStatus)
                .WithMany()
                .HasForeignKey(o => o.ApprovalStatusId);
        }
    }
}

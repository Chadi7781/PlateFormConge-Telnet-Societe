using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities.Context
{
    public class TelnetContext : DbContext
    {
        public TelnetContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeContextConfiguration());
            modelBuilder.ApplyConfiguration(new CongeContextConfiguration());
            modelBuilder.ApplyConfiguration(new SortieContextConfiguration());
            modelBuilder.ApplyConfiguration(new TeamContextConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEmployeeContextConfiguration());

            modelBuilder.Entity<TeamEmployee>().HasKey(sc => new { sc.EmployeeId, sc.TeamId });

            //Configure One to Many Relation between Employee and TeamEmployee
            modelBuilder.Entity<TeamEmployee>()
                .HasOne<Employee>(c => c.Employee)
                .WithMany(u => u.TeamEmployees)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configure One to Many Relation between Team and TeamEMployee
            modelBuilder.Entity<TeamEmployee>()
                .HasOne<Team>(c => c.Team)
                .WithMany(u => u.TeamEmployees)
                .HasForeignKey(c => c.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
               
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Conge> Conges { get; set; }
        public DbSet<Sortie> Sorties { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamEmployee> TeamEmployees { get; set; }
    }
    
    
}

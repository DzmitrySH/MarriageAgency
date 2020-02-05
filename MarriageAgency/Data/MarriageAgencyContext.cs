using MarriageAgency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Data
{
    public class MarriageAgencyContext : DbContext
    {
        public MarriageAgencyContext(DbContextOptions<MarriageAgencyContext> options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Nationalitie> Nationalities { get; set; }
        public DbSet<ZodiacSign> ZodiacSigns { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

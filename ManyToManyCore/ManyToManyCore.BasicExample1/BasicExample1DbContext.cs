using System;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyCore.BasicExample1
{
    public class BasicExample1DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("myConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name);
                entity.HasMany(e => e.PersonToJob);
                entity.Ignore(e => e.Jobs);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Descripcion);
            });

            modelBuilder.ManyToMany<Job, Person, Guid, int>();
        }
    }
}

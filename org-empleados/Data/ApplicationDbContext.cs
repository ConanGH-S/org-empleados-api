﻿using Microsoft.EntityFrameworkCore;
using org_empleados.Models;

namespace org_empleados.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.FkIdRole);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.FkIdRole);
        }
    }
}
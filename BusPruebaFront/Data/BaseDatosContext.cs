using BusPruebaFront.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusPruebaFront.Data
{
    public partial class BaseDatosContext : DbContext
    {
        public BaseDatosContext()
        {

        }
        public BaseDatosContext(DbContextOptions<BaseDatosContext> options) : base(options)
        {

        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("Clientes", "dbo");
            });
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.ToTable("Productos", "dbo");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

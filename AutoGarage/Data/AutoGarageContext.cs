namespace AutoGarage.Data
{
    using AutoGarage.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class AutoGarageContext : DbContext
    {
        public AutoGarageContext(DbContextOptions<AutoGarageContext> options) : base(options)
        {

        }
        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<AutomoveisModel> Automoveis { get; set; }
        public DbSet<ServicosModel> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientesModel>()
                .HasMany(c => c.Automoveis)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<AutomoveisModel>()
                .HasMany(a => a.Servicos)
                .WithOne(s => s.Automovel)
                .HasForeignKey(s => s.AutomovelId);
        }
    }
}

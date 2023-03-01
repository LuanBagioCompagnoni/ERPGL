using ERPGL.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace ERPGL.Context
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //Cria a tabela no formato indicado entre <>, o framework se responsabiliza por criar os formatos referentes conforme a entidade
        //Logo após os <> indicamos o nome da tabela
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=CrudHub;User Id=postgres;Password=admin;");
        }

    }
}

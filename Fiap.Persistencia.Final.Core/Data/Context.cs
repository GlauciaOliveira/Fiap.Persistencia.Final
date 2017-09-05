using Fiap.Persistencia.Final.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Persistencia.Final.Core.Data
{
    public partial class Context : DbContext
    {
        public Context() : base(new DbContextOptionsBuilder<Context>()
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DbPersistence;
                            Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {

        }

        public DbSet<Versao> Versao { get; set; }
        public DbSet<Eventos> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Versao>().ToTable("TBVersao");
            modelBuilder.Entity<Eventos>().ToTable("TBEventos");
        
        }
    }
}

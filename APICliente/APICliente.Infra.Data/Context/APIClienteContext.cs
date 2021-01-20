using APICliente.Dominio.Entidades;
using APICliente.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.Data.Context
{
    public class APIClienteContext : DbContext
    {
        public APIClienteContext(DbContextOptions<APIClienteContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereço> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Your custom configs here
            new ClienteConfig(builder.Entity<Cliente>());
            new EnderecoConfig(builder.Entity<Endereço>());
            
        }
    }
}

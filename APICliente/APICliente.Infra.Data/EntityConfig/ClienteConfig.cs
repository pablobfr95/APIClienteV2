using APICliente.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.Data.EntityConfig
{
    public class ClienteConfig 
    {
        public ClienteConfig(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nome).HasMaxLength(30).IsRequired();

            builder.Property(c => c.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(c => c.DataNascimento).IsRequired();
        }
    }
}

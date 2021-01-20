using APICliente.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace APICliente.Infra.Data.EntityConfig
{
    public class EnderecoConfig
    {
        public EnderecoConfig(EntityTypeBuilder<Endereço> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Logradouro).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Bairro).HasMaxLength(40).IsRequired();

            builder.Property(e => e.Cidade).HasMaxLength(40).IsRequired();

            builder.Property(e => e.Estado).HasMaxLength(40).IsRequired();

            builder.HasOne(e => e.Cliente).WithMany().HasForeignKey(e => e.ClienteId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

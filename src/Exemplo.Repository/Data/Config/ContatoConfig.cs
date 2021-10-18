using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Exemplo.Domain.Entities;

namespace Exemplo.Infrastructure.Data.Config
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.DataNascimento).HasColumnType("datetime");
            builder.Property(p => p.Sexo);
            builder.Property(p => p.Idade);
            builder.Property(p => p.IsAtivo);
            builder.Property(e => e.CreatedAt).HasColumnType("datetime");
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");
        }
    }
}

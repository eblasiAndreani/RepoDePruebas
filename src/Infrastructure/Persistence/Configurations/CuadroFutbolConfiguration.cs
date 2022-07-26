using CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Infrastructure.Persistence.Configurations
{
    public class CuadroFutbolConfiguration : IEntityTypeConfiguration<CuadroFutbol>
    {
        public void Configure(EntityTypeBuilder<CuadroFutbol> builder)
        {
            builder.ToTable("CuadroFutbol");

            builder.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);
        }

    }
}

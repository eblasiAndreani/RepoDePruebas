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
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");

            builder.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false);

            builder.HasOne(d => d.IdCuadroNavigation)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCuadro)
                .HasConstraintName("fk_Per_Cua");
        }

    }
}

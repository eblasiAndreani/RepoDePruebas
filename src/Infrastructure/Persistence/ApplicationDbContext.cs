using CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CrudTest.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) {}
    public virtual DbSet<CuadroFutbol> CuadroFutbols { get; set; }
    public virtual DbSet<Persona> Personas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

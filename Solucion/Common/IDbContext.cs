using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public interface IDbContext : IDisposable
    {
        DatabaseFacade Database { get; }

        DbSet<Cliente> Cliente { get; set; }
        DbSet<Cuenta> Cuenta { get; set; }
        DbSet<Movimiento> Movimiento { get; set; }
        DbSet<Persona> Persona { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}

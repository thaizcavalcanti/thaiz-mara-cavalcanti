using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exemplo.Domain.Entities;

namespace Exemplo.Repository.Data.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Contato> Contato { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            AddCreatedAt();
            AddUpdatedAt();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddCreatedAt() =>
            ChangeTracker.Entries().Where(p => p.Entity is Entity && p.State.Equals(EntityState.Added)).ToList()
                .ForEach(p => ((Entity)p.Entity).CreatedAt = DateTime.UtcNow);

        private void AddUpdatedAt() =>
            ChangeTracker.Entries().Where(p => p.Entity is Entity && p.State.Equals(EntityState.Modified)).ToList()
                .ForEach(p => ((Entity)p.Entity).UpdatedAt = DateTime.UtcNow);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
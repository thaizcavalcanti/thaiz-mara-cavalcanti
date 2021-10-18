using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exemplo.Domain.Entities;
using Exemplo.Repository.Data.Contexts;

namespace Exemplo.Repository.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(Context context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity) =>
            DbSet.Remove(entity);

        public async Task<bool> Exists(int id) =>
            await DbSet.AsNoTracking().AnyAsync(x => Equals(x.Id, id));

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            var entityEntry = await DbSet.AddAsync(entity);
            Context.SaveChanges();

            return entityEntry.Entity;
        }

        public IQueryable<TEntity> AsQueryable() => DbSet;

        public async Task<TEntity> GetById(int id) =>
            await DbSet.FindAsync(new object[] { id });

        public async Task Update(TEntity entity)
        {
            if (await Exists(entity.Id) == false)
                return;

            DbSet.Update(entity);
        }

        public async Task Commit() => await Context.SaveChangesAsync(true);
    }
}

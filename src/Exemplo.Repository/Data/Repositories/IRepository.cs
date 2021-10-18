using System.Linq;
using System.Threading.Tasks;
using Exemplo.Domain.Entities;

namespace Exemplo.Repository.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Delete(TEntity entity);
        Task<bool> Exists(int id);
        Task<TEntity> Insert(TEntity entity);
        IQueryable<TEntity> AsQueryable();
        Task<TEntity> GetById(int id);
        Task Update(TEntity entity);
        Task Commit();
    }
}
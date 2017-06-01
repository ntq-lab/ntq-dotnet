using System;
using System.Linq;
using System.Threading.Tasks;

namespace Interface.DAL
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllNonDelete();
        Task<TEntity> GetAsync(int id);
        TEntity Get(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        void DeleteByCondition(Func<TEntity, bool> expression);
    }
}

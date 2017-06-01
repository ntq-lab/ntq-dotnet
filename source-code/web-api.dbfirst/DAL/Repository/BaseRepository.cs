using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Interface.DAL;

namespace DAL.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {

        protected readonly IContext _context;

        protected readonly IDALOption _option;

        public BaseRepository(IContext context, IDALOption option)
        {
            _context = context;
            _option = option;
        }
        public virtual TEntity Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
            return entity;
        }

        public virtual void DeleteByCondition(Func<TEntity, bool> expression)
        {
            foreach (var entity in _context.Set<TEntity>().Where(expression))
            {
                Delete(entity);
            }
        }

        public virtual TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAllNonDelete()
        {
            return _context.Set<TEntity>().Where(m => !m.IsDeleted);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;

            entity.UpdatedAt = entity.CreatedAt = DateTime.Now;
            entity.UpdatedBy = entity.CreatedBy = _option.CurrentUserId;
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = _option.CurrentUserId;
            return entity;
        }
    }
}

using System.Linq;

namespace Interface.DAL
{
    public interface IUserRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        IQueryable<TEntity> CustomQuery();
    }
}

using System;
using System.Linq;
using Interface.DAL;

namespace DAL.Repository
{
    public class UserRepository<TEntity> : BaseRepository<TEntity>, IUserRepository<TEntity>
        where TEntity : class, IEntity
    {
        public UserRepository(IContext context, IDALOption option)
            : base(context, option)
        {
        }

        public IQueryable<TEntity> CustomQuery()
        {
            throw new NotImplementedException();
        }
    }
}

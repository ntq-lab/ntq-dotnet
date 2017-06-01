//using System.Threading.Tasks;
//
//namespace Interface.DAL
//{
//    public interface IUnitOfWork<TEntity, in TId>
//        where TId : struct
//        where TEntity : class, IEntity<TId>
//    {
//        IUserRepository<User<TId>, TId> UserRepository { get; }
//
//
//
//        int Commit();
//
//        Task<int> CommitAsync();
//    }
//}

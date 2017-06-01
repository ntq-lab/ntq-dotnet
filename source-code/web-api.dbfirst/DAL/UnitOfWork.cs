using System.Threading.Tasks;
using EFDBFirst;
using Interface.DAL;
using Microsoft.Practices.Unity;

namespace DAL
{
    public class UnitOfWork
    {
        private readonly IContext _context;
        private readonly IDALOption _option;
        public UnitOfWork(IDALOption option, IContext context)
        {
            _context = context;
            _option = option;
        }

        [Dependency]
        public IUserRepository<User> UserRepository { get; internal set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

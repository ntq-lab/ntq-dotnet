using Interface.DAL;

namespace WebApi
{
    public class DALOption : IDALOption
    {
        public DALOption(int? currentUserId)
        {
            CurrentUserId = currentUserId;
        }

        public int? CurrentUserId { get; }
    }
}
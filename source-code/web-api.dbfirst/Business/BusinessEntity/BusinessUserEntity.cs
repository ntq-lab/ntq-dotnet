using System.Collections.Generic;
using Business.Entity;
using Business.ModelConversions;
using DAL;
using EFDBFirst;

namespace Business.BusinessEntity
{
    public class BusinessUserEntity
    {
        private readonly UnitOfWork _unitOfWork;
        public BusinessUserEntity(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            IEnumerable<User> users = _unitOfWork.UserRepository.GetAll();

            return users.ConvertToEntities();
        }

        public UserEntity GetById(int id)
        {
            User user = _unitOfWork.UserRepository.Get(id);

            return user.ConvertToEntity();
        }

        public UserEntity UpdateEntity(UserEntity userEntity)
        {
            _unitOfWork.UserRepository.Update(userEntity.ConvertToModel());
            _unitOfWork.Commit();

            return userEntity;
        }

        public UserEntity CreateUser(UserEntity userEntity)
        {
            User user = userEntity.ConvertToModel();

            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Commit();

            return user.ConvertToEntity();
        }
    }
}

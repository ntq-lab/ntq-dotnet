using System.Collections.Generic;
using System.Linq;
using Business.Entity;
using Business.ValueObject;
using EFDBFirst;

namespace Business.ModelConversions
{
    public static class UserConversion
    {
        public static UserEntity ConvertToEntity(this User user)
        {
            return new UserEntity()
            {
                Id = user.Id,
                Name = new NameObject()
                {
                    FirstName = user.DisplayName,
                },
                IsDeleted = user.IsDeleted,
                CreatedBy = user.CreatedBy,
                UpdatedBy = user.UpdatedBy,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public static IEnumerable<UserEntity> ConvertToEntities(this IEnumerable<User> users)
        {
            return users.Select(user => new UserEntity()
            {
                Id = user.Id,
                Name = new NameObject()
                {
                    FirstName = user.DisplayName,
                },
                IsDeleted = user.IsDeleted,
                CreatedBy = user.CreatedBy,
                UpdatedBy = user.UpdatedBy,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            });
        }

        public static User ConvertToModel(this UserEntity userEntity)
        {
            return new User()
            {
                Id = userEntity.Id,
                DisplayName = userEntity.Name.GetFullName(),
                CreatedAt = userEntity.CreatedAt,
                CreatedBy = userEntity.CreatedBy,
                UpdatedAt = userEntity.UpdatedAt,
                UpdatedBy = userEntity.UpdatedBy,
                IsDeleted = userEntity.IsDeleted
            };
        }

        public static IEnumerable<User> ConvertToModels(this IEnumerable<UserEntity> userEntities)
        {
            return userEntities.Select(userEntity => new User()
            {
                Id = userEntity.Id,
                DisplayName = userEntity.Name.FirstName,
                CreatedAt = userEntity.CreatedAt,
                CreatedBy = userEntity.CreatedBy,
                UpdatedAt = userEntity.UpdatedAt,
                UpdatedBy = userEntity.UpdatedBy,
                IsDeleted = userEntity.IsDeleted
            });
        }
    }
}

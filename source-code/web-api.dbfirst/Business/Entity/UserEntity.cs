using System;
using Business.ValueObject;
using Interface;

namespace Business.Entity
{
    public class UserEntity : EntityBase<int>, IValidator
    {
        public NameObject Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public bool Validate()
        {
            // TODO: validate with other field
            return Name.Validate();
        }
    }
}

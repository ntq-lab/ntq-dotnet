using System;

namespace Interface.DAL
{
    public interface IEntity

    {
        int Id { get; set; }

        bool IsDeleted { get; set; }

        DateTime CreatedAt { get; set; }
        int? CreatedBy { get; set; }

        DateTime UpdatedAt { get; set; }
        int? UpdatedBy { get; set; }
    }
}

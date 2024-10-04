
using Microsoft.AspNetCore.Identity;

namespace Domain.Bases.Entities
{
    public abstract class BaseEntity : IdentityUser
    {
        public override string Id {  get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

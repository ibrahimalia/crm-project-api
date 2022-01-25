using System.Collections.Generic;

#nullable disable

namespace Meta.IntroApp
{
    public partial class MobOurTeam
    {
        public MobOurTeam()
        {
            MobStaffServiceAssigns = new HashSet<MobStaffServiceAssign>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int? BranchId { get; set; }
        public string MerchantId { get; set; }
        public int? IsActive { get; set; }
        public string Images { get; set; }

        public virtual MobBranch Branch { get; set; }
        public virtual MobMerchant Merchant { get; set; }
        public virtual ICollection<MobStaffServiceAssign> MobStaffServiceAssigns { get; set; }
    }
}
#nullable disable

namespace Meta.IntroApp
{
    public partial class MobStaffServiceAssign
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public int? SubServiceId { get; set; }

        public virtual MobOurTeam Staff { get; set; }
        public virtual MobSubService SubService { get; set; }
    }
}
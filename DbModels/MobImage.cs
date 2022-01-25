#nullable disable

namespace Meta.IntroApp
{
    public partial class MobImage
    {
        public int ImagesId { get; set; }
        public string Title { get; set; }
        public int? IsFeatured { get; set; }
        public string DataBase64 { get; set; }
        public int? AboutUsId { get; set; }
        public int? BranchesId { get; set; }
        public int? ContactUsId { get; set; }
        public int? EmployeeId { get; set; }
        public int? NewsId { get; set; }
        public int? ProjectId { get; set; }
        public int? ServiceId { get; set; }
        public int? SubServiceId { get; set; }
        public int? IsCover { get; set; }

        public virtual MobBranch Branches { get; set; }
        public virtual MobNews News { get; set; }
        public virtual MobProject Project { get; set; }
        public virtual MobService Service { get; set; }
        public virtual MobSubService SubService { get; set; }
    }
}
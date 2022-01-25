namespace Meta.IntroApp.DTOs.branch
{
    public class AddBranchDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? IsMain { get; set; }
        public int? IsActive { get; set; }
    }
}
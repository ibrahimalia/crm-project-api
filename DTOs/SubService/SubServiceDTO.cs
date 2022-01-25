using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.SubService
{
    public class SubServiceDTO
    {
     
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; } 
        public int? IsFeatured { get; set; }
        public int? IsActive { get; set; }
        public int ServiceID { get; set; }

        public IEnumerable<string> Images { get; set; }
    }

    public class UpdateSubServiceDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        //public string Icon { get; set; }
        //public string Color { get; set; }
        public int? IsFeatured { get; set; }
        public int? IsActive { get; set; }
        public string ServiceTitle { get; set; }
        public IEnumerable<string> Images { get; set; }
    }

  




}
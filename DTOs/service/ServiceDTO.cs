using Meta.IntroApp.DTOs.SubService;

using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.service
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string ServiceImage { get; set; }

    }
}
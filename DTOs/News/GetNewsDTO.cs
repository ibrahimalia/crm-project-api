using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.News
{
    public class GetNewsDTO
    {
        public int? ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string PublishingDate { get; set; }
        public int? IsPublished { get; set; }

        public IEnumerable<string> Images { get; set; }
        public int? IsActive { get; set; }
    }
}
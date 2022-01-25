using System;
using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.News
{
    public class AddEditNewsDTO
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime? PublishingDate { get; set; }
        public int? IsPublished { get; set; }

        public List<string> Images { get; set; }
        public int? IsActive { get; set; }
    }
}
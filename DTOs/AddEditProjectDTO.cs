using System;
using System.Collections.Generic;

namespace Meta.IntroApp.DTOs
{
    public class AddEditProjectDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Period { get; set; }
        public int? IsActive { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
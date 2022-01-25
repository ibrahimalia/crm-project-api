using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.aboutUs
{
    public class GetAboutUsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs
{
    public class GetAttachementDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int? TaskId { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
    }
}

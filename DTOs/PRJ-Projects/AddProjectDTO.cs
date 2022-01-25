using Meta.IntroApp.DTOs.PRJ_ProjectFollower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_Projects
{
    public class AddProjectDTO
    {
        public int? ParentProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }    
        public int ProjectStatusId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Logo { get; set; }       
        public int ProjectCategoryId { get; set; }
        public int? IsArchive { get; set; }
        public ProjectAttachementDTO Attachement { get; set; }
        public string Label { get; set; }


    }
    public class ProjectAttachementDTO 
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        //public int? TaskId { get; set; }
    
    }
}

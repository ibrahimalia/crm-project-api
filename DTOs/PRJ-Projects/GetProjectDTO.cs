using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.DTOs.PRJ_ProjectFollower;
using Meta.IntroApp.DTOs.PRJ_Tasks;

namespace Meta.IntroApp.DTOs.PRJ_Projects
{
    public class GetProjectDTO
    {
        public int Id { get; set; }
       // public int? ParentProjectID { get; set; }
        //public int? PRJProjectId { get; set; }
        public string ProjectName { get; set; }
        //public string Description { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectCategory { get; set; }
        public string CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public string Logo { get; set; }
        //public int ProjectCategoryId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public int SubProjectsCount { get; set; }
        
        public  int?  NumberLateDay { get; set; }
        public List<GetProjectFollowerInfoDTO> Followers { get; set; }
        


    }
    public class GetProjectDetailesInfo 
    {
        public int Id { get; set; }
        public string ParentProject { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public string Description { get; set; }
        public string ProjectStatus { get; set; }
        public string CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Logo { get; set; }
        public string ProjectCategory { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public int SubProjectsCount { get; set; }
        public int SubTasksCount { get; set; }
        public string  TaskFinish { get; set; }
       
        public List<GetProjectFollowerInfoDTO>? Followers { get; set; }
        public List<GetTasksDTO>? Tasks { get; set; }
        public List<GetAttachementDTO> Attachements { get; set; }
    }
    public class GetTreeViewOfProjectsDTO 
    {
        public int ProjectId { get; set; }      
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public string CustomerName { get; set; }
        public string ProjectCategory { get; set; }
        public List<SubProjectsDTO> SubProjects { get; set; }
    }
    public class GetProjecTreetDTO 
    {
        public int ProjectId { get; set; }      
        public string ProjectName { get; set; }
        public List<SubTreeProjectsDTO> SubProjects { get; set; }
    }
    public class SubTreeProjectsDTO
    {
        
        public int? SubProjectId { get; set; }
        public string ProjectName { get; set; }
      

    }
    public class SubProjectsDTO
    {
        
        public int? SubProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public string CustomerName { get; set; }
        public string ProjectCategory { get; set; }

    }



}

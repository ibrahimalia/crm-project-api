using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_TaskFollowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_Tasks
{
    public class GetTaskDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ParentTask { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DuetDate { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        public string TaskStatus { get; set; }
        public string ProjectRole { get; set; }
        public string Owner { get; set; }
        public int IsMajor { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public List<GetTaskFollowersInfoDTO> TaskFollowers { get; set; }
        public List<GetSubTasksDTO> SubTasks { get; set; }
        public List<GetAttachementDTO> Attachements { get; set; }
        public int SubTasksCount { get; set; }

    }

    public class GetTasksDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        //public string ParentTask { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DuetDate { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        public string TaskStatus { get; set; }
        public string ProjectRole { get; set; }
        public string Owner { get; set; }
        public int IsMajor { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? IsArchive { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public  int SubTasksCount { get; set; }
        public List<GetTaskFollowersInfoDTO> TaskFollowers { get; set; }
        //public List<GetSubTasksDTO> SubTasks { get; set; }
        //public List<GetAttachementDTO> Attachements { get; set; }
        //public int SubTasksCount { get; set; }

    }

    public class GetSubTasksDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DuetDate { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        public string TaskStatus { get; set; }   
        public List<GetTaskFollowersInfoDTO> TaskFollowers { get; set; }
        


   

    }

    public class TaskDropDownsDTO 
    {
        public List<string> TaskStatus { get; set; }
        public List<string> TaskOwners { get; set; }
        public List<string> ProjectRoles { get; set; }
        public List<string> Projects { get; set; }
    }
}

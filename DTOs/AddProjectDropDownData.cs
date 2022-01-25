using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.DTOs.PRJ_Projects;
using Microsoft.AspNetCore.Authorization;

namespace Meta.IntroApp.DTOs
{
    public class AddProjectDropDownData
    {
        public IList<AddProjectDropDownDataDTO> ParentProjects { get; set; }
        public List<string> Categories { get; set; }
        public List<string> States { get; set; }
       
    }
    public class AddProjectDropDownDataDTO
    {
       public string Name { get; set; }
       public int Id { get; set; }
       
    } 
    public class ParentProjectDropDownData 
    {
        public List<string> ParentProjects { get; set; }
    } 
    public class CaregoryDropDownData
    {
        public List<string> Categories { get; set; }
    }  
    public class StatusDropDownData
    {
        public List<string> States { get; set; }
    }
}

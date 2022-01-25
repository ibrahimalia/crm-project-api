using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.PRJ_ProjectFollower
{
    public class ADDProjectFollowerDTO
    {
        public int ProjectId { get; set; }
        public int ContactsId { get; set; }
        public int ProjectRoleId { get; set; }
        public int ProjectLevelId { get; set; }
        public string Notes { get; set; }
        public int? IsArchive { get; set; }
 
    }
}

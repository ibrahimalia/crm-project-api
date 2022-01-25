using Meta.IntroApp.DTOs.PRJ_ProjectRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Role.admin
{
  public  interface IAdminProjectRole
    {
        Task<List<GetProjectRolesDTO>> GetProjectRoles();

        Task AddProjectCRole(int admin , ADDProjectRoleDTO model);

        Task UpdateProjectRole(int admin,  int id, ADDProjectRoleDTO model);

        Task DeleteProjectRole(int id);
    }
}

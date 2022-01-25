using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Attachement.admin
{
    public interface IAdminProjectAttachements
    {
        Task<List<GetAttachementDTO>> GetProjectAttachements(int projectId);
        Task<List<GetAttachementDTO>> GetTaskAttachements(int TaskId);
  
        Task ArchiveAttachement(int AttachementId);
        //Task ArchiveTaskAttachements(ICollection<PRJAttachements> attachements);
        Task ArchiveProjectAttachements(ICollection<PRJAttachements> attachements);

    }
}

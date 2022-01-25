using Meta.IntroApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_Attachement.admin
{
    public class AdminProjectAttachementsService : BaseService, IAdminProjectAttachements
    {
        public AdminProjectAttachementsService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {

        }

        public async Task ArchiveAttachement(int AttachementId)
        {
            var toBeArchived = await AppDbContext.PRJAttachements.Where(x =>x.MobMerchantMerchantId == CurrentMerchantId && x.Id == AttachementId)
                                                           .FirstOrDefaultAsync();
            toBeArchived.IsArchive = 1;
            AppDbContext.PRJAttachements.Update(toBeArchived);
            await AppDbContext.SaveChangesAsync(); 
        }

        public async Task ArchiveProjectAttachements(ICollection<DbModels.PRJAttachements> attachements)
        {
            if (attachements.Count != 0)
            {
                foreach (var item in attachements)
                {
                    item.IsArchive = 1;
                }
                AppDbContext.PRJAttachements.UpdateRange(attachements);
                await AppDbContext.SaveChangesAsync();
            }
        }

        //public async Task ArchiveTaskAttachements(ICollection<DbModels.PRJAttachements> attachements)
        //{
        //    if (attachements.Count != 0)
        //    {
        //        foreach (var item in attachements)
        //        {
        //            item.IsArchive = 1;
        //        }
        //        AppDbContext.PRJAttachements.UpdateRange(attachements);
        //        await AppDbContext.SaveChangesAsync();
        //    }
        //}

        public async Task<List<GetAttachementDTO>> GetProjectAttachements(int projectId)
        {
            var files =await AppDbContext.PRJAttachements.Where(x => x.MobMerchantMerchantId == CurrentMerchantId
                                                       && x.ProjectId == projectId && x.IsArchive ==0).ToListAsync();

            return files?.ConvertAll(file => new GetAttachementDTO
            {
                Id = file.Id,
                ProjectId = file.ProjectId,
                TaskId = file.TaskId,
                Path = file.Path,
                Title = file.Title,
                ContentType = file.ContentType
                
            }).ToList();
        }

        public async Task<List<GetAttachementDTO>> GetTaskAttachements(int taskId)
        {
            var files = await AppDbContext.PRJAttachements.Where(x => x.MobMerchantMerchantId == CurrentMerchantId
                                                        && x.TaskId == taskId && x.IsArchive ==0).ToListAsync();

            return files?.ConvertAll(file => new GetAttachementDTO
            {
                Id = file.Id,
                ProjectId = file.ProjectId,
                TaskId = file.TaskId,
                Path = file.Path,
                Title = file.Title,
                ContentType = file.ContentType
            }).ToList();
        }
    }
}

using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_TaskStatusDTO;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_TaskStatus
{
    public class AdminTaskStatusService : BaseService, IAdminTaskStatus
    {
        private readonly IWebHostEnvironment _env;
        public AdminTaskStatusService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddTaskStatus(int adminId, AddTaskStatusDTO model)
        {
           
            var newTaskStatus = new PRJTaskStatus
            {
                Value = model.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = adminId,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = model.IsArchive,
                ArchiveDate = null,
                MobMerchantMerchantId = CurrentMerchantId
            };
            if (model.IsArchive == 1)
            {
                newTaskStatus.ArchiveDate = DateTime.Now;
            }
            await AppDbContext.PRJTaskStatus.AddAsync(newTaskStatus);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteTaskStatus(int id)
        {
            var toBeDeleted = await AppDbContext.PRJTaskStatus.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {
                AppDbContext.PRJTaskStatus.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }
            
        }

        public async Task<List<GetTaskStatusDTO>> GetTaskStatus()
        {

            var taskStatus = await (from state in AppDbContext.PRJTaskStatus
                                   .Include(x => x.CreatedByAccount)
                                   .Include(c => c.UpdatedByAccount)
                                    where state.MobMerchantMerchantId == CurrentMerchantId && state.IsArchive == 0

                                    select new GetTaskStatusDTO
                                    {
                                        Id = state.Id,
                                        Value = state.Value,
                                        CreatedOn = state.CreatedOn,
                                        CreatedBy = state.CreatedByAccount.FirstName+" "+ state.CreatedByAccount.LastName,
                                        UpdatedOn = state.UpdatedOn,
                                        UpdatedBy = state.UpdatedByAccount.FirstName+" "+ state.UpdatedByAccount.LastName,
                                        IsArchive = state.IsArchive,
                                        ArchiveDate = state.ArchiveDate
                                    }).ToListAsync();
            return taskStatus;
        }

        public async Task UpdateTaskStatus(int adminId, int id, AddTaskStatusDTO model)
        {
           
            var toBeUpdated = await AppDbContext.PRJTaskStatus
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.Value = model.Value;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = adminId;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = model.IsArchive;
            if (model.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJTaskStatus.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}

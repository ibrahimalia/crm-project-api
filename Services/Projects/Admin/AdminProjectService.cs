//using Meta.IntroApp.Models;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Helpers;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminProjectService : BaseService, IAdminProjectService
    {
        public AdminProjectService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
        }

        public async Task AddProject(AddEditProjectDTO project)
        {
            var dbProject = new MobProject
            {
                MerchantId = CurrentMerchantId,
                BranchId = CurrentBranchId,
                Description = project.Description,
                EndDate = project.EndDate,
                IsActive = project.IsActive,
                Period = project.Period,
                StartDate = project.StartDate,
                Title = project.Title,
                SubTitle = project.SubTitle,
                ClientName = project.ClientName,
                Images =  JsonConvert.SerializeObject(project.Images)
            };

            await AppDbContext.Projects.AddAsync(dbProject);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var toBeDeleted = await AppDbContext.Projects.Where(x => x.MerchantId == CurrentMerchantId && (!CurrentBranchId.HasValue || x.BranchId == CurrentBranchId) && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.UnExpectedError);

            AppDbContext.Projects.Remove(toBeDeleted);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<ProjectDTO> GetProjectDetailes(int? id)
        {
            var project = await AppDbContext.Projects
                                    .Where(x => x.MerchantId == CurrentMerchantId && (!CurrentBranchId.HasValue || x.BranchId == CurrentBranchId) && x.Id == id)
                                    .FirstOrDefaultAsync();

            if (project == null)
            {
                return null;
            }

            return new ProjectDTO
            {
                Id = project.Id,
                Title = project.Title,
                SubTitle = project.SubTitle,
                Period = project.Period,
                IsActive = project.IsActive,
                Description = project.Description,
                StartDate = project.StartDate.Value.ToString("yyyy-MM-dd"),
                EndDate = project.EndDate.Value.ToString("yyyy-MM-dd"),
                Images = JsonConvert.DeserializeObject<List<string>>(project.Images ?? "[]").Select(c => c.WrapContentUrl()),
                ClientName = project.ClientName
            };
        }

        public async Task<List<ProjectDTO>> GetProjects(PaginationFilterDTO filter)
        {
            var projects = await AppDbContext.Projects
                                               .Where(x => x.MerchantId == CurrentMerchantId && (!CurrentBranchId.HasValue || x.BranchId == CurrentBranchId))
                                              .Skip(filter.ElementsToBeEscaped)
                                              .Take(filter.RequestedPageLength)
                                              .ToListAsync();

            return projects?.ConvertAll(project => new ProjectDTO
            {
                Id = project.Id,
                Title = project.Title,
                SubTitle = project.SubTitle,
                Period = project.Period,
                IsActive = project.IsActive,
                Description = project.Description,
                StartDate = project.StartDate.Value.ToString("yyyy-MM-dd"),
                EndDate = project.EndDate.Value.ToString("yyyy-MM-dd"),
                Images = JsonConvert.DeserializeObject<List<string>>(project.Images?? "[]").Select(c => c.WrapContentUrl()),
                 ClientName = project.ClientName
            });
        }

        public async Task UpdateProject(int id, AddEditProjectDTO project)
        {
            var toBeUpdated = await AppDbContext.Projects
                             .Where(x => x.MerchantId == CurrentMerchantId && (!CurrentBranchId.HasValue || x.BranchId == CurrentBranchId) && x.Id == id)
                             .FirstOrDefaultAsync();

            toBeUpdated.Title = project.Title;
            toBeUpdated.SubTitle = project.SubTitle;
            toBeUpdated.Description = project.Description;
            toBeUpdated.StartDate = project.StartDate;
            toBeUpdated.EndDate = project.EndDate;
            toBeUpdated.Period = project.Period;
            toBeUpdated.IsActive = project.IsActive;
            toBeUpdated.Images = JsonConvert.SerializeObject(project.Images);
            toBeUpdated.ClientName = project.ClientName;

            AppDbContext.Projects.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
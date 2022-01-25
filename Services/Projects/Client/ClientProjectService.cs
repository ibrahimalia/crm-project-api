//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class ClientProjectService : BaseService, IClientProjectService
    {
        public ClientProjectService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
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
                StartDate = project.StartDate.GetDate(),
                EndDate = project.EndDate.GetDate(),
                Images = JsonConvert.DeserializeObject<List<string>>(project.Images?? "[]").Select(c => c.WrapContentUrl()),
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
                StartDate = project.StartDate.GetDate(),
                EndDate = project.EndDate.GetDate(),
                Images = JsonConvert.DeserializeObject<List<string>>(project.Images?? "[]").Select(c => c.WrapContentUrl()),
                ClientName = project.ClientName
            });
        }
    }
}
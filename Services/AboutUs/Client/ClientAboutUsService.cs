//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.aboutUs;
using Meta.IntroApp.DTOs.employee;
using Meta.IntroApp.Extensions;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class ClientAboutUsService : BaseService, IClientAboutUsService
    {
        public ClientAboutUsService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<GetAboutUsDTO> GetAboutUs()
        {
            MobAbout aboutUs = await AppDbContext.Abouts.FirstOrDefaultAsync(x => x.MerchantId == CurrentMerchantId);
            if (aboutUs == null)
                return null;

            return new GetAboutUsDTO
            {
                Id = aboutUs.AboutUsId,
                Title = aboutUs.Title,
                Address = aboutUs.Address,
                Description = aboutUs.Description,
                Images = JsonConvert.DeserializeObject<List<string>>(aboutUs.Images ?? "[]").Select(x => x.WrapContentUrl())
            };
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var employees = await AppDbContext.OurTeams.Where(x => x.MerchantId == CurrentMerchantId
                                                          && (!CurrentBranchId.HasValue || x.BranchId == CurrentBranchId))
                                                          .ToListAsync();
            if (employees == null)
                return null;
            return employees.ConvertAll(emp => new EmployeeDTO
            {
                Id = emp.EmployeeId,
                FullName = emp.FullName,
                Position = emp.Position,
                Images = JsonConvert.DeserializeObject<List<string>>(emp.Images ?? "[]")?.Select(i => i.WrapContentUrl())
            });
        }

        public async Task<List<GalleryImageDTO>> GetHomePageImages()
        {
            var subGallery = await AppDbContext.Galleries.Where(x => x.MerchantId == CurrentMerchantId && x.IsFeatured == 1)
                                            .ToListAsync();

            return subGallery?.ConvertAll(sub => new GalleryImageDTO
            {               
       
                URL = sub.Url?.WrapContentUrl(),           
               IsFeatured = sub.IsFeatured
            });
        }
    }
}
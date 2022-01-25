using Meta.IntroApp.DTOs.service;
using Meta.IntroApp.DTOs.SubService;
using Meta.IntroApp.Extensions;

//using Meta.IntroApp.Models;
using Meta.IntroApp.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class ClientServicesService : BaseService, IClientServicesService
    {
        public ClientServicesService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<ServiceDTO>> GetServices()
        {
            var services = await AppDbContext.Services
                                    .Where(p => p.MerchantId == CurrentMerchantId).ToListAsync();
            return services.ConvertAll(service => new ServiceDTO
            {
                Id = service.ServicesId,
                Title = service.Title,
                Description = service.Description,
                IsActive = service.IsActive,
                ServiceImage = JsonConvert.DeserializeObject<string>(service.Image??"" ).WrapContentUrl()
            });
    
        }

        public async Task<ServiceDTO> GetService(int? id)
        {
            var dbSeervice = await AppDbContext.Services.Where(p => p.MerchantId == CurrentMerchantId && p.IsActive == true && p.ServicesId == id).FirstOrDefaultAsync();
            if (dbSeervice == null)
                return null;

            return new ServiceDTO
            {
                Id = dbSeervice.ServicesId,
                Title = dbSeervice.Title,
                Description = dbSeervice.Description,
                IsActive = dbSeervice.IsActive,
                ServiceImage = JsonConvert.DeserializeObject<string>(dbSeervice.Image??"").WrapContentUrl()
            };
        }
    }
}
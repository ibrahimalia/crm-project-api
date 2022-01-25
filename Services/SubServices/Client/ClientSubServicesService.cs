using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.DTOs.SubService;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.Extensions;

namespace Meta.IntroApp.Services
{
    public class ClientSubServicesService : BaseService, IClientSubServicesService
    {
        public ClientSubServicesService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<List<UpdateSubServiceDTO>> GetAllSubServices()
        {
            var AllSubServices = await AppDbContext.SubServices.Where(x => x.Service.MerchantId == CurrentMerchantId).ToListAsync();

            //var AllSubServices1 =  (from sub in AppDbContext.SubServices
            //                        join service in AppDbContext.Services
            //                             on sub.SubServicesId equals service.ServicesId
            //                             where service.MerchantId == CurrentMerchantId
            //                             select new List<int>
            //                             {
            //                                 sub.SubServicesId
            //                             }
            //                            ).ToList();

            var result = AllSubServices.ConvertAll( c => new UpdateSubServiceDTO
            {
                Id = c.SubServicesId,
                Title = c.Title,
                SubTitle = c.SubTitle,
                Description = c.Description,
                IsActive = c.IsActive,
                IsFeatured = c.IsFeatured,
                Images = JsonConvert.DeserializeObject<List<string>>(c.Images ?? "[]").Select(x => x.WrapContentUrl()),
                ServiceTitle = AppDbContext.Services.Where(x => x.ServicesId == c.ServiceId).Select(x => x.Title)
                                                           .FirstOrDefault()


            });
            return result;
        }

        public async Task<UpdateSubServiceDTO> GetSubService(int? id)
        {
            var SubService = await AppDbContext.SubServices.Where(p =>
                                                                    p.Service.MerchantId == CurrentMerchantId
                                                                    &&
                                                                    (!CurrentBranchId.HasValue || p.Service.BranchId == CurrentBranchId)
                                                                    &&
                                                                    p.SubServicesId == id)
                                                .FirstOrDefaultAsync();
         

            if (SubService == null)
                throw new ApplicationException(AppExceptions.SubServiceNotFound);

            return new UpdateSubServiceDTO
            { Id = id.Value,
                IsFeatured = SubService.IsFeatured,
                IsActive = SubService.IsActive,
                //Icon = SubService.Icon,
                Title = SubService.Title,
                SubTitle = SubService.SubTitle,
                Description = SubService.Description,
                //Color = SubService.Color,
                Images = JsonConvert.DeserializeObject<List<string>>(SubService.Images ?? "[]").Select(x => x.WrapContentUrl()),
                ServiceTitle = await AppDbContext.Services.Where(x => x.ServicesId == SubService.ServiceId).Select(c => c.Title)
                                                           .FirstOrDefaultAsync()
            };
        }

        public async Task<List<UpdateSubServiceDTO>> GetSubServices(int serviceId)
        {
            var mobSubServices = await AppDbContext.SubServices
                                                   .Where(p => p.Service.MerchantId == CurrentMerchantId
                                                            &&
                                                            p.ServiceId == serviceId
                                                            &&
                                                            p.IsActive == 1
                                                          )
                                                   .ToListAsync();
            var serviceTitle = await AppDbContext.Services.Where(x => x.MerchantId == CurrentMerchantId
                                                                  && x.ServicesId == serviceId)
                                                                  .Select(y =>y.Title)
                                                                  .FirstOrDefaultAsync();
            return mobSubServices?.ConvertAll(subService => new UpdateSubServiceDTO
            {
                Id = subService.SubServicesId,
                //Color = subService.Color,
                Description = subService.Description,
                //Icon = subService.Icon,
                IsFeatured = subService.IsFeatured,
                Title = subService.Title,
                SubTitle =subService.SubTitle,
                IsActive = subService.IsActive,
                Images = JsonConvert.DeserializeObject<List<string>>(subService.Images ?? "[]").Select(x => x.WrapContentUrl()),
                ServiceTitle = serviceTitle
            });
        }
    }
}
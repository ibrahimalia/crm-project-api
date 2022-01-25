using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.service;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Localizations.AppExceptions;
//using Meta.IntroApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminServicesService : BaseService, IAdminServicesService
    {
        public AdminServicesService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task AddServiceAsync(AddServiceDTO dtoModel)
        {
            var serviceImage = dtoModel.ServiceImage.RemoveContentUrl() ?? "";//remove content url

            var dbModel = new MobService
            {
                Title = dtoModel.Title,
                Description = dtoModel.Description,
                IsActive = dtoModel.IsActive,
                BranchId = CurrentBranchId,
                MerchantId = CurrentMerchantId,
                Image = JsonConvert.SerializeObject(serviceImage)

            };

            await AppDbContext.Services.AddAsync(dbModel);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var toBeDeleted = await AppDbContext.Services
                                            .FirstOrDefaultAsync(p => p.ServicesId == id && p.BranchId == CurrentBranchId && p.MerchantId == CurrentMerchantId);

            if (toBeDeleted == null)
                throw new ApplicationException(AppExceptions.ServiceNotFound);
            //check if this Service has SubServices
            var mobSubServices = await AppDbContext.SubServices
                                                   .Where(p => p.Service.MerchantId == CurrentMerchantId
                                                            &&
                                                            p.ServiceId == id                                                           
                                                          )
                                                   .ToListAsync();
            if (mobSubServices.Count != 0)
            {
                throw new ApplicationException(AppExceptions.CategoryNotEmpty);
            }

            AppDbContext.Services.Remove(toBeDeleted);
            await AppDbContext.SaveChangesAsync();


            //Delete old images
            if (!string.IsNullOrEmpty(toBeDeleted.Image))
            {
                var fullImagePath = toBeDeleted.Image?.WrapPhysicalPath();
                if (File.Exists(fullImagePath))
                    File.Delete(fullImagePath);
            }
        }

        public async Task<IEnumerable<ServiceDTO>> List()
        {
            var services = await AppDbContext.Services
                                    .Where(p => p.MerchantId == CurrentMerchantId).ToListAsync();
            return services.ConvertAll(service => new ServiceDTO
            {
                Id = service.ServicesId,
                Title = service.Title,
                Description = service.Description,
                IsActive = service.IsActive,
                ServiceImage = JsonConvert.DeserializeObject<string>(service.Image??"").WrapContentUrl()
            });
        }

        public async Task<ServiceDTO> Details(int? id)
        {
            var dbSeervice = await AppDbContext.Services.Where(p => p.MerchantId == CurrentMerchantId && p.ServicesId == id).FirstOrDefaultAsync();
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

        public async Task UpdateService(int serviceID ,EditServiceDTO dtoModel)
        {
            var toBeUpdated = await AppDbContext.Services.FirstOrDefaultAsync(p => p.MerchantId == CurrentMerchantId && p.BranchId == CurrentBranchId && p.ServicesId == serviceID);
            if (toBeUpdated == null)
                throw new ApplicationException(AppExceptions.ServiceNotFound);

            toBeUpdated.Title = dtoModel.Title;
            toBeUpdated.Description = dtoModel.Description;
            toBeUpdated.IsActive = dtoModel.IsActive;
            var oldImage = toBeUpdated.Image;
             var image= dtoModel.ServiceImage.RemoveContentUrl() ?? "";
            toBeUpdated.Image = JsonConvert.SerializeObject(image);

            //edit the  returned object with new changes
            AppDbContext.Services.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();

            //Delete old images
            if (!string.IsNullOrEmpty(oldImage))
            {
                var fullImagePath = oldImage?.WrapPhysicalPath();
                if (File.Exists(fullImagePath))
                    File.Delete(fullImagePath);
            }
        }
    }
}
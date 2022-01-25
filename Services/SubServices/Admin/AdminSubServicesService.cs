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
using System.IO;

namespace Meta.IntroApp.Services.Admin
{
    public class AdminSubServicesService : BaseService, IAdminSubServicesService
    {
        public AdminSubServicesService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task AddSubServiceAsync(int serviceId, SubServiceDTO dtoModel)
        {
            dtoModel.Images = dtoModel.Images?.Select(i => i.RemoveContentUrl()).ToList() ?? new List<string>();//remove content url

            var subService = new MobSubService
            {
                //Color = Subservice.Color,
                Description = dtoModel.Description,
                //Icon = Subservice.Icon,
                IsActive = dtoModel.IsActive,
                IsFeatured = dtoModel.IsFeatured,
                Title = dtoModel.Title,
                SubTitle = dtoModel.SubTitle,
                ServiceId = serviceId,
                Images = JsonConvert.SerializeObject(dtoModel.Images)
            };

            await AppDbContext.SubServices.AddAsync(subService);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteSubServiceAsync(int id)
        {
            var checkExsistInRequest = await AppDbContext.MobRequests.FirstOrDefaultAsync(p =>
                                                                                p.MerchantId == CurrentMerchantId                                                                            
                                                                                &&
                                                                                p.subServiceId == id);
            if (checkExsistInRequest != null)
            {
                throw new ApplicationException(AppExceptions.SubServiceIsUsedInRequests);
            }
            var toBeDeleted = await AppDbContext.SubServices.FirstOrDefaultAsync(p =>
                                                                                p.Service.MerchantId == CurrentMerchantId
                                                                                &&
                                                                                (!CurrentBranchId.HasValue || p.Service.BranchId == CurrentBranchId)
                                                                                &&
                                                                                p.SubServicesId == id);

            if (toBeDeleted == null)
                throw new ApplicationException(AppExceptions.SubServiceNotFound);

            //commit the changes on database
            AppDbContext.SubServices.Remove(toBeDeleted);
            await AppDbContext.SaveChangesAsync();

            //Delete old images
            var oldImaegs = JsonConvert.DeserializeObject<List<string>>(toBeDeleted.Images ?? "[]");
            foreach (var image in oldImaegs)
            {
                var fullImagePath = image?.WrapPhysicalPath();
                if (File.Exists(fullImagePath))
                    File.Delete(fullImagePath);
            }
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
            {
                Id = id.Value,
                IsFeatured = SubService.IsFeatured,
                IsActive = SubService.IsActive,
                //Icon = SubService.Icon,
                Title = SubService.Title,
                SubTitle = SubService.SubTitle,
                Description = SubService.Description,
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
                                                          )
                                                   .ToListAsync();
            var serviceTitle = await AppDbContext.Services.Where(x => x.MerchantId == CurrentMerchantId
                                                                && x.ServicesId == serviceId)
                                                                .Select(y => y.Title)
                                                                .FirstOrDefaultAsync();
            return mobSubServices?.ConvertAll(subService => new UpdateSubServiceDTO
            {
                Id = subService.SubServicesId,
                //Color = subService.Color,
                Description = subService.Description,
                //Icon = subService.Icon,
                IsFeatured = subService.IsFeatured,
                Title = subService.Title,
                SubTitle = subService.SubTitle,
                IsActive = subService.IsActive,
                Images = JsonConvert.DeserializeObject<List<string>>(subService.Images ?? "[]").Select(x => x.WrapContentUrl()),
                ServiceTitle = serviceTitle
            });
        }

        public async Task UpdateSubService(UpdateSubServiceDTO dtoModel)
        {
            dtoModel.Images = dtoModel.Images?.Select(i => i.RemoveContentUrl()).ToList() ?? new List<string>();//remove content url
            var dbSubService = await AppDbContext.SubServices
                                                .FirstOrDefaultAsync(p => p.SubServicesId == dtoModel.Id && p.Service.MerchantId == CurrentMerchantId);

            //check if the returned object  is not null
            if (dbSubService == null)
                throw new ApplicationException(AppExceptions.SubServiceNotFound);

            dbSubService.Title = dtoModel.Title;
            dbSubService.SubTitle = dtoModel.SubTitle;
            dbSubService.Description = dtoModel.Description;
            //SubService.Color = service.Color;
            //SubService.Icon = service.Icon;
            dbSubService.IsFeatured = dtoModel.IsFeatured;
            dbSubService.IsActive = dtoModel.IsActive;
            var oldImagesJson = dbSubService.Images;
            dbSubService.Images = JsonConvert.SerializeObject(dtoModel.Images);
            dbSubService.ServiceId =await AppDbContext.Services.Where(x => x.MerchantId == CurrentMerchantId
                                                                 && x.Title == dtoModel.ServiceTitle).Select(e =>e.ServicesId).FirstOrDefaultAsync();

            //commit changes
            AppDbContext.SubServices.Update(dbSubService);
            await AppDbContext.SaveChangesAsync();


            //Delete old images
            var oldImages = JsonConvert.DeserializeObject<List<string>>(oldImagesJson ?? "[]");
            foreach (var image in oldImages.Where(oldImage => !dtoModel.Images.Any(newImage => newImage == oldImage)))
            {
                var fullImagePath = image?.WrapPhysicalPath();
                if (File.Exists(fullImagePath))
                    File.Delete(fullImagePath);
            }

        }
    }
}
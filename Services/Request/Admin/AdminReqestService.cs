using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Request.Admin
{
    public class AdminReqestService : BaseService, IAdminRequest
    {
        public AdminReqestService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
        }

        public async Task AddRequest(AddRequestDTO addRequestDTO)
        {
            var request = new MobRequest
            {
                Name = addRequestDTO.Name,
                Notes = addRequestDTO.Notes,
                PhoneNumber = addRequestDTO.PhoneNumber,
                //serviceId=addRequestDTO.ServiceID,
                subServiceId = addRequestDTO.SubServiceID,
                FilePath = addRequestDTO.FilePath
            };
            await AppDbContext.MobRequests.AddAsync(request);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteRequest(int id)
        {
            var toBeDeleted = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId).FirstOrDefaultAsync();
            if (toBeDeleted == null)
                throw new ApplicationException(AppExceptions.UnExpectedError);

            AppDbContext.MobRequests.Remove(toBeDeleted);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<AddRequestDTO> GetRequestDetailes(int? id)
        {
            var result = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId 
                                                              && x.Id == id).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            return new AddRequestDTO 
            {
                Name = result.Name,
                Notes = result.Notes,
                PhoneNumber = result.PhoneNumber,
                //ServiceID = result.serviceId,
                SubServiceID = result.subServiceId,
                FilePath = result.FilePath
            };
        }

        public async Task<List<AddRequestDTO>> GetRequests()
        {
            var result = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId).ToListAsync();

            return result?.ConvertAll(request => new AddRequestDTO
            {
                Name = request.Name,
                Notes = request.Notes,
                PhoneNumber = request.PhoneNumber,
                //ServiceID = request.serviceId,
                SubServiceID = request.subServiceId,
                FilePath = request.FilePath
            });
        }

        public async Task UpdateRequest(int id, AddRequestDTO addRequestDTO)
        {
            var toBeUpdated = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId
                                                              && x.Id == id).FirstOrDefaultAsync();
            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.UnExpectedError);
            }

            toBeUpdated.Name = addRequestDTO.Name;
            toBeUpdated.Notes = addRequestDTO.Notes;
            toBeUpdated.PhoneNumber = addRequestDTO.PhoneNumber;
            //toBeUpdated.serviceId = addRequestDTO.ServiceID;
            toBeUpdated.subServiceId = addRequestDTO.SubServiceID;
            toBeUpdated.FilePath = addRequestDTO.FilePath;

            AppDbContext.MobRequests.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}

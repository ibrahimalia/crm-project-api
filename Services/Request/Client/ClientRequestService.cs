using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Enums;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Request.Client
{
    public class ClientRequestService : BaseService, IClientRequest
    {
        public ClientRequestService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
        }


        public async Task AddRequest(long? clientId ,AddRequestDTO addRequestDTO)
        {
            var request = new MobRequest
            {
                Name = addRequestDTO.Name,
                Notes = addRequestDTO.Notes,
                PhoneNumber = addRequestDTO.PhoneNumber,
                //serviceId = addRequestDTO.ServiceID,
                subServiceId = addRequestDTO.SubServiceID,
                AccountsId = clientId,
                FilePath = addRequestDTO.FilePath,
                MerchantId = CurrentMerchantId,
                Email = addRequestDTO.Email,
                RequestedAt = DateTime.Now,
                Status = RequestStatus.Pending,
                Title = addRequestDTO.Title
                
            };
            await AppDbContext.MobRequests.AddAsync(request);
            await AppDbContext.SaveChangesAsync();
        }

        //public async Task DeleteRequest(int id)
        //{
        //    var toBeDeleted = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId).FirstOrDefaultAsync();
        //    if (toBeDeleted == null)
        //        throw new ApplicationException(AppExceptions.UnExpectedError);

        //    AppDbContext.MobRequests.Remove(toBeDeleted);
        //    await AppDbContext.SaveChangesAsync();
        //}

        public async Task<GetRequestDTO> GetRequestDetailes(long clientId ,int? id)
        {
            var result = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId
                                                              && x.Id == id
                                                              && x.AccountsId == clientId).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            return new GetRequestDTO
            {
             Id = result.Id,
                Notes = result.Notes,
               
           
                SubService = AppDbContext.SubServices.Where(x => x.SubServicesId == result.subServiceId).Select(c => c.Title).FirstOrDefault(),
              
                //FilePath = result.FilePath,
              
                Title= result.Title,
                RequestedTime = result.RequestedAt.GetDate(),
                State = EnumExtension.GetDisplayValue(result.Status),
               

            };
        }

        public async Task<List<GetRequestListDTO>> GetRequests(long clientId , PaginationFilterDTO filter)
        {
            var validFilter = new PaginationFilterDTO(filter.PageNumber, filter.PageSize);

            var result = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId && x.AccountsId == clientId)
                                                       .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                                       .Take(validFilter.PageSize)
                                                       .OrderByDescending(c => c.Id)
                                                       .ToListAsync();

            return result?.ConvertAll(request => new GetRequestListDTO
            {
                Id = request.Id,
                Title = request.Title,             
               State = EnumExtension.GetDisplayValue(request.Status),
                SubService =  AppDbContext.SubServices.Where(x => x.SubServicesId == request.subServiceId).Select( c=> c.Title).FirstOrDefault(),
              RequestedTime = request.RequestedAt.GetTime(),
                RequestedDate = request.RequestedAt.GetDate(),
                Notes = request.Notes
            });
        }

        public async Task UpdateRequest(long clientId ,int id, AddRequestDTO addRequestDTO)
        {
            var toBeUpdated = await AppDbContext.MobRequests.Where(x => x.MerchantId == CurrentMerchantId
                                                              && x.Id == id
                                                              && x.AccountsId == clientId).FirstOrDefaultAsync();
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

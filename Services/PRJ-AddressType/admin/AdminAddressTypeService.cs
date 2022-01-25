using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_AddressType;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_AddressType.admin
{
    public class AdminAddressTypeService : BaseService, IAdminAddressType
    {
        private readonly IWebHostEnvironment _env;

        public AdminAddressTypeService(MetaITechDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddAddressType(int clientID, AddAddressTypeDTO model)
        { 
            var newAddressType = new PRJAddressType
            {
                Value = model.Value,
                CreatedOn = DateTime.Now,
                CreatedBy = clientID,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = model.IsArchive,
                ArchiveDate = null,
                MobMerchantMerchantId = CurrentMerchantId
            };
            if (model.IsArchive == 1)
            {
                newAddressType.ArchiveDate = DateTime.Now;
            }
         

            await AppDbContext.PRJAddressType.AddAsync(newAddressType);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteAddressType(int id)
        {
            var toBeDeleted = await AppDbContext.PRJAddressType.Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)

                throw new ApplicationException(AppExceptions.DataNotFound);

            try
            {

                AppDbContext.PRJAddressType.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }

           
        }

        public async Task<List<GetAddressTypeDTO>> GetAddressTypes()
        {

            var result = await (from address in AppDbContext.PRJAddressType
                                      .Include(x => x.UpdatedByAccount)
                                      .Include(c => c.CreatedByAccount)
                                      where address.MobMerchantMerchantId == CurrentMerchantId
                                      && address.IsArchive == 0  select address).ToListAsync();


            return result.ConvertAll(address => new GetAddressTypeDTO
            {
                Id = address.Id,
                Value = address.Value,
                CreatedOn = address.CreatedOn,
                CreatedBy = address.CreatedByAccount.FirstName +" "+ address.CreatedByAccount.LastName,
                UpdatedOn = address.UpdatedOn,
                UpdatedBy = address.UpdatedBy != null ? address.UpdatedByAccount.FirstName + " " + address.UpdatedByAccount.LastName : "",
                IsArchive = address.IsArchive,
                ArchiveDate = address.ArchiveDate
            });
           
        }
        public async Task UpdateAddressType(int clientID, int id, AddAddressTypeDTO level)
        {
          
            var toBeUpdated = await AppDbContext.PRJAddressType
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            toBeUpdated.Value = level.Value;
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.CreatedOn = toBeUpdated.CreatedOn;
            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = clientID;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.IsArchive = level.IsArchive;
            if (level.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJAddressType.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}
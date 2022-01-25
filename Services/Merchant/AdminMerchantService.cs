using Meta.IntroApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Merchant
{
    public class AdminMerchantService : BaseService, IAdminMerchant
    {
        public AdminMerchantService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
        public async Task AddMerchant(string Name)
        {
            MobMerchant merchant = new MobMerchant
            {
                MerchantId = Guid.NewGuid() + "_" + Name + "_" + DateTime.Now.Ticks.ToString().Substring(0, 10),
                MerchantName = Name 
            };
            await AppDbContext.Merchants.AddAsync(merchant);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task<List<MerchantDTO>> GetMerchants()
        {
            List<MobMerchant> Merchants = await AppDbContext.Merchants.ToListAsync();

            return Merchants?.ConvertAll(one => new MerchantDTO
            {
                MerchantName = one.MerchantName,
                MerchantId = one.MerchantId
            });
        }
    }
}

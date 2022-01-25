using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.DTOs;

namespace Meta.IntroApp.Services.Merchant
{
  public interface IAdminMerchant
    {
        Task AddMerchant(string name);
        Task<List<MerchantDTO>> GetMerchants();
    }
}

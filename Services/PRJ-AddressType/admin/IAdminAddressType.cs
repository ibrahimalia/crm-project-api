using Meta.IntroApp.DTOs.PRJ_AddressType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.PRJ_AddressType.admin
{
    public interface IAdminAddressType
    {
        Task<List<GetAddressTypeDTO>> GetAddressTypes();

        Task AddAddressType(int clientID, AddAddressTypeDTO level);

        Task UpdateAddressType(int clientID, int id, AddAddressTypeDTO level);

        Task DeleteAddressType(int id);
    }
}

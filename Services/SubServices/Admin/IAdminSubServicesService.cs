using Meta.IntroApp.DTOs.SubService;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminSubServicesService
    {
        Task AddSubServiceAsync(int serviceId, SubServiceDTO Subservice);

        Task DeleteSubServiceAsync(int id);

        Task<UpdateSubServiceDTO> GetSubService(int? id);

        Task<List<UpdateSubServiceDTO>> GetSubServices(int serviceId);

        Task UpdateSubService(UpdateSubServiceDTO service);
    }
}
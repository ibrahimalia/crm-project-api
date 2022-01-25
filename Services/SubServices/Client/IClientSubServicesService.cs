using Meta.IntroApp.DTOs.SubService;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public interface IClientSubServicesService
    {
        Task<UpdateSubServiceDTO> GetSubService(int? id);

        Task<List<UpdateSubServiceDTO>> GetSubServices(int serviceId);

        Task<List<UpdateSubServiceDTO>> GetAllSubServices();
    }
}
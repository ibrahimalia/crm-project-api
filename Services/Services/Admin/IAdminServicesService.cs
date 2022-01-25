//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.service;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services.Admin
{
    public interface IAdminServicesService
    {
        Task<IEnumerable<ServiceDTO>> List();

        Task<ServiceDTO> Details(int? id);

        Task AddServiceAsync(AddServiceDTO service);

        Task UpdateService(int serviceID, EditServiceDTO dtoModel);

        Task DeleteServiceAsync(int id);
    }
}
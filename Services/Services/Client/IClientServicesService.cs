//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs.service;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Interfaces
{
    public interface IClientServicesService
    {
        Task<IEnumerable<ServiceDTO>> GetServices();

        Task<ServiceDTO> GetService(int? id);
    }
}
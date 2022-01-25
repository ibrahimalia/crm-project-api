//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.aboutUs;
using Meta.IntroApp.DTOs.employee;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public interface IClientAboutUsService
    {
        Task<GetAboutUsDTO> GetAboutUs();

        Task<List<EmployeeDTO>> GetEmployees();

        Task<List<GalleryImageDTO>> GetHomePageImages();
    }
}
//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.aboutUs;
using Meta.IntroApp.DTOs.employee;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public interface IAdminAboutUsService
    {
        Task AddAboutUsInfo(AddAboutUSDTO aboutUs);

        Task AddEmployee(List<AddEmployeeDTO> employee);

        Task AssignServiceToEmployee(int employeeId, int service);

        Task DeleteEmployee(int employeeId);

        Task<GetAboutUsDTO> GetAboutUs();

        Task<List<EmployeeDTO>> GetEmployees();

        Task<List<GalleryImageDTO>> GetHomePageImages();

        Task UpdateAboutUsInfo(AddAboutUSDTO modelDTO);

        Task UpdateEmployeeInfo(UpdateEmployeeDTO employee);
    }
}
//using Meta.IntroApp.Models;
using Meta.IntroApp.DTOs;
using Meta.IntroApp.DTOs.aboutUs;
using Meta.IntroApp.DTOs.employee;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Localizations.AppExceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class AdminAboutUsService : BaseService, IAdminAboutUsService
    {
        public AdminAboutUsService(MetaITechDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task AddAboutUsInfo(AddAboutUSDTO model)
        {
            var oldAboutUs = await AppDbContext.Abouts.FirstOrDefaultAsync(x => x.MerchantId == CurrentMerchantId);
            if (oldAboutUs != null)
            {
                AppDbContext.Abouts.Remove(oldAboutUs);

                //ToDo: Remove The Old Image which was edited
                var oldImages = JsonConvert.DeserializeObject<List<string>>(oldAboutUs.Images ?? "[]");
                foreach (var image in oldImages.Where(oldImage => !model.Images.Any(newImage => newImage == oldImage)))
                {
                    var fullImagePath = image?.WrapPhysicalPath();
                    if (File.Exists(fullImagePath))
                        File.Delete(fullImagePath);
                }
            }

            model.Images = model.Images?.Select(i => i.RemoveContentUrl()).ToList() ?? new List<string>();//remove content url
            var mob = new MobAbout
            {
                Address = model.Address,
                Description = model.Description,
                Title = model.Title,
                MerchantId = CurrentMerchantId,
                Images = JsonConvert.SerializeObject(model.Images ?? new List<string>())
            };

            await AppDbContext.Abouts.AddAsync(mob);
            await AppDbContext.SaveChangesAsync();


         
        }

        public async Task AddEmployee(List<AddEmployeeDTO> dtoModel)
        {
            var oldEmployees = AppDbContext.OurTeams.Where(c => c.MerchantId == CurrentMerchantId).ToList();
            if (oldEmployees != null)
            {
                AppDbContext.OurTeams.RemoveRange(oldEmployees);
            }
            var newEmployees = new List<MobOurTeam>();
            foreach (var item in dtoModel)
            {
                item.Images = item.Images?.Select(i => i.RemoveContentUrl()).ToList() ?? new List<string>();//remove content url
                 var newEmployee = new MobOurTeam {
                    BranchId = CurrentBranchId,
                    MerchantId = CurrentMerchantId,
                    FullName = item.FullName,
                    Position = item.Position,
                    Images = JsonConvert.SerializeObject(item.Images ?? new List<string>())
                };
                newEmployees.Add(newEmployee);
            }
            await AppDbContext.OurTeams.AddRangeAsync(newEmployees);
            await AppDbContext.SaveChangesAsync();
        }

        //ToDo: To be Moved To appointments
        public async Task AssignServiceToEmployee(int employeeId, int service)
        {
            MobStaffServiceAssign mob = new MobStaffServiceAssign()
            {
                StaffId = employeeId,
                SubServiceId = service
            };

            await AppDbContext.StaffServiceAssigns.AddAsync(mob);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var emp = await AppDbContext.OurTeams.Where(p => p.MerchantId == CurrentMerchantId
                                              && p.BranchId == CurrentBranchId
                                              && p.EmployeeId == employeeId)
                                 .FirstOrDefaultAsync();
            if (emp == null)
                throw new ApplicationException(AppExceptions.EmployeeNotFound);

            AppDbContext.OurTeams.Remove(emp);
            await AppDbContext.SaveChangesAsync();

        }

        public async Task<GetAboutUsDTO> GetAboutUs()
        {
            MobAbout aboutUs = await AppDbContext.Abouts.FirstOrDefaultAsync(x => x.MerchantId == CurrentMerchantId);
            if (aboutUs == null)
                return null;

            return new GetAboutUsDTO
            {
                Id = aboutUs.AboutUsId,
                Title = aboutUs.Title,
                Address = aboutUs.Address,
                Description = aboutUs.Description,
                Images = JsonConvert.DeserializeObject<List<string>>(aboutUs.Images ?? "[]").Select(x=> x.WrapContentUrl())
            };
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var employees = await AppDbContext.OurTeams.Where(x => x.BranchId == CurrentBranchId && x.MerchantId == CurrentMerchantId).ToListAsync();
            if (employees == null)
                return null;
            return employees.ConvertAll(emp => new EmployeeDTO
            {
                Id = emp.EmployeeId,
                FullName = emp.FullName,
                Position = emp.Position,
                Images = JsonConvert.DeserializeObject<List<string>>(emp.Images ?? "[]")?.Select(x => x.WrapContentUrl())
            });
        }

        public async Task<List<GalleryImageDTO>> GetHomePageImages()
        {
            var subGallery = await AppDbContext.Galleries.Where(x => x.MerchantId == CurrentMerchantId && x.IsFeatured == 1)
                                            .ToListAsync();

            return subGallery?.ConvertAll(sub => new GalleryImageDTO
            {
               
                URL = sub.Url?.WrapContentUrl(),
                IsFeatured = sub.IsFeatured
            });
        }

        public async Task UpdateAboutUsInfo(AddAboutUSDTO modelDTO)
        {
            var toBeUpdated = await AppDbContext.Abouts.FirstOrDefaultAsync(x => x.MerchantId == CurrentMerchantId);
            if (toBeUpdated == null)
                throw new ApplicationException(AppExceptions.UnExpectedError);

            //updating entries
            toBeUpdated.Title = modelDTO.Title;
            toBeUpdated.Description = modelDTO.Description;
            toBeUpdated.Address = modelDTO.Address;
            modelDTO.Images = modelDTO.Images?.Select(i => i.RemoveContentUrl()).ToList() ?? new List<string>();//remove content url
            var oldImages = JsonConvert.DeserializeObject<List<string>>(toBeUpdated.Images ?? "[]");
            toBeUpdated.Images = JsonConvert.SerializeObject(modelDTO.Images);

            //ToDo: we have to delete old images
            foreach (var image in oldImages.Where(oldImage => !modelDTO.Images.Any(newImage => newImage == oldImage)))
            {
                var fullImagePath = image?.WrapPhysicalPath();
                if (File.Exists(fullImagePath))
                    File.Delete(fullImagePath);
            }

            AppDbContext.Abouts.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeInfo(UpdateEmployeeDTO employee)
        {
            var mobEmployee = AppDbContext.OurTeams.Where(x => x.MerchantId == CurrentMerchantId
                                                                    &&
                                                                    (!CurrentBranchId.HasValue || x.BranchId == CurrentBranchId)
                                                                    &&
                                                                    x.EmployeeId == employee.Id)
                                          .FirstOrDefault();

            mobEmployee.FullName = employee.FullName;
            mobEmployee.Position = employee.Position;
            var oldImages = JsonConvert.DeserializeObject<List<string>>(mobEmployee.Images ?? "[]");
            employee.Images = employee.Images?.Select(i => i.RemoveContentUrl()).ToList() ?? new List<string>();
            mobEmployee.Images = JsonConvert.SerializeObject(employee.Images);

            AppDbContext.OurTeams.Update(mobEmployee);
            await AppDbContext.SaveChangesAsync();

            //ToDo: Remove The Old Image which was edited
            foreach (var image in oldImages.Where(oldImage=> !employee.Images.Any(newImage => newImage == oldImage)))
            {
                var fullImagePath = image?.WrapPhysicalPath();
                if (File.Exists(fullImagePath))
                    File.Delete(fullImagePath);
            }

        }
    }
}
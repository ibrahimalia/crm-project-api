using Meta.IntroApp.DbModels;
using Meta.IntroApp.DTOs.PRJ_Contacts;
using Meta.IntroApp.Extensions;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Localizations.AppExceptions;
using Meta.IntroApp.Services.PRJ_InvolvementLevel.admin;
using Meta.IntroApp.Services.PRJ_Project.admin;
using Meta.IntroApp.Services.PRJ_Role.admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.IntroApp.Enums;
using Meta.IntroApp.Services.PRJ_JobPosition.admin;
using Meta.IntroApp.Services.PRJ_AddressType.admin;

namespace Meta.IntroApp.Services.PRJ_Contacts.admin
{
    public class PRJAdminContactService : BaseService, PRJIAdminContact
    {
        private readonly IWebHostEnvironment _env;
        //private readonly IAdminProject _project;
        private readonly IAdminInvolvementLevel _level;
        private readonly IAdminProjectRole _role;
        private readonly IAdminJobPosition _position;
        private readonly IAdminAddressType _address;

        public PRJAdminContactService(MetaITechDbContext context,
                                      IWebHostEnvironment env,
                                      IHttpContextAccessor httpContextAccessor,
                                      //IAdminProject project,
                                      IAdminInvolvementLevel level,
                                      IAdminProjectRole role ,
                                      IAdminJobPosition jobPosition,
                                      IAdminAddressType address)
            : base(context, httpContextAccessor)
        {
            _env = env;
            _position = jobPosition;
            _level = level;
            _role = role;
            _address = address;
        }

        public async Task<List<PRJContactProjectManagerDTO>> GetDataPRojectManager()
        {
            var result = await (from contact in AppDbContext.PRJContacts
                                
                                .Include(x => x.JobPosition)
                                 where  contact.JobPosition.Value == "project_manager"

                                select new PRJContactProjectManagerDTO()
                                {    
                                    FullName = contact.FullName,
                                    Photo = JsonConvert.DeserializeObject<string>(contact.Photo).WrapContentUrl(),
                                   
                                }).ToListAsync();
                        return result; 
        }
        public async Task AddContact(int adminId, PRJAddContactsDTO model)
        {
           
            var newContact = new PRJContacts
            {
                AddressTypeId = model.AddressTypeId,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                FullName = model.FullName,
                PRJJobPositionId = model.JobPositionId,
                Mobile = model.Mobile,
                Notes = model.Notes,
                Street = model.Street,
                Code = model.Code,
                Phone = model.Phone,
                Street2 = model.Street2,
                Photo = JsonConvert.SerializeObject(model.Photo),
                PRJContactsId = model.PRJContactsId,
                Tags = model.Tags,
                CreatedOn = DateTime.Now,
                CreatedBy = adminId,
                UpdatedOn = null,
                UpdatedBy = null,
                IsArchive = model.IsArchive,
                ArchiveDate = null,
                Category = model.Category,
                MobMerchantMerchantId = CurrentMerchantId,
                UserId = null,
                Location = model.Location
                
            };
            if (model.IsArchive == 1)
            {
                newContact.ArchiveDate = DateTime.Now;
            }
            await AppDbContext.PRJContacts.AddAsync(newContact);
            await AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteContact(int id)
        {
            var toBeDeleted = await AppDbContext.PRJContacts                                                                                          
                                                .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id).FirstOrDefaultAsync();
            if (toBeDeleted == null)
            {
                throw new ApplicationException(AppExceptions.DataNotFound);
            }

            var checkExisting = await AppDbContext.PRJContacts
                                                .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.PRJContactsId == id).FirstOrDefaultAsync();
            if (checkExisting != null)
            {
                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }

            try
            {
                AppDbContext.PRJContacts.Remove(toBeDeleted);
                await AppDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new ApplicationException(AppExceptions.DataCannotBeRemoved);
            }
           

        }

        public async Task<PRJGetContactsDTO> GetContactDetailes(int id)
        {
            var result = await (from contact in AppDbContext.PRJContacts
                                .Include(x=>x.CreatedByAccount)
                                .Include(x=>x.UpdatedByAccount)
                                .Include(x=>x.Contacts)
                                .Include(x=>x.JobPosition)
                                .Include(x=>x.AddressType)
                                 where contact.MobMerchantMerchantId == CurrentMerchantId && contact.Id == id
                                 && contact.IsArchive == 0
                                // join Position in AppDbContext.PRJJobPosition on contact.PRJJobPositionId equals Position.Id into join1
                                // from x in join1.DefaultIfEmpty()
                                //join Address in AppDbContext.PRJAddressType on contact.AddressTypeId equals Address.Id 
                       
                               
                                 select new PRJGetContactsDTO
                                 {
                                     Id = contact.Id,
                                     Mobile = contact.Mobile,
                                     Email = contact.Email,
                                     Country = contact.Country,
                                     FullName = contact.FullName,
                                     City = contact.City,
                                     JobPosition = contact.JobPosition.Value,
                                     AddressType = contact.AddressType.Value,
                                     Code = contact.Code,
                                     Notes = contact.Notes,
                                     Phone = contact.Phone,
                                     Street = contact.Street,
                                     Street2 = contact.Street2,
                                     Location = contact.Location,
                                     PRJContactsName = AppDbContext.PRJContacts
                                             .Where(x => x.Id == contact.PRJContactsId).Select(c => c.FullName)
                                            .FirstOrDefault(),               
                                     Tags = contact.Tags,
                                     //Category = EnumExtension.GetDisplayValue(CategoryType.Individual),
                                     Photo = JsonConvert.DeserializeObject<string>(contact.Photo ?? "").WrapContentUrl(),
                                     CreatedOn = contact.CreatedOn,
                                     CreatedBy = contact.CreatedByAccount.FirstName + " "+contact.CreatedByAccount.LastName,
                                     UpdatedOn = contact.UpdatedOn,
                                     UpdatedBy = contact.UpdatedByAccount.FirstName +" "+ contact.UpdatedByAccount.LastName,
                                     IsArchive = contact.IsArchive,
                                     ArchiveDate = contact.ArchiveDate
                                 }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<PRJGetContactsDTO>> GetContacts()
        {
           
            var result = await (from contact in AppDbContext.PRJContacts
                                  .Include(x => x.CreatedByAccount)
                                .Include(x => x.UpdatedByAccount)
                                .Include(x => x.Contacts)
                                .Include(x => x.JobPosition)
                                .Include(x => x.AddressType)
                                where contact.MobMerchantMerchantId == CurrentMerchantId && contact.IsArchive == 0

                                select new PRJGetContactsDTO
                                {

                                    Id = contact.Id,
                                    Mobile = contact.Mobile,
                                    Email = contact.Email,
                                    Country = contact.Country,
                                    FullName = contact.FullName,
                                    City = contact.City,
                                    JobPosition = contact.JobPosition.Value,
                                    AddressType = contact.AddressType.Value,
                                    Code = contact.Code,
                                    Notes = contact.Notes,
                                    Phone = contact.Phone,
                                    Street = contact.Street,
                                    Street2 = contact.Street2,
                                    Location = contact.Location,
                                    PRJContactsName = AppDbContext.PRJContacts
                                                                 .Where(x => x.Id == contact.PRJContactsId).Select(c => c.FullName)
                                                                .FirstOrDefault()
                                   ,
                                    Tags = contact.Tags,
                                    // Category = EnumExtension.GetDisplayValue(contact.Category),

                                    Photo = JsonConvert.DeserializeObject<string>(contact.Photo).WrapContentUrl(),
                                    CreatedOn = contact.CreatedOn,
                                    CreatedBy = contact.CreatedByAccount.FirstName + " " + contact.CreatedByAccount.LastName,
                                    UpdatedOn = contact.UpdatedOn,
                                    UpdatedBy = contact.UpdatedByAccount.FirstName + " " + contact.UpdatedByAccount.LastName,
                                    IsArchive = contact.IsArchive,
                                    ArchiveDate = contact.ArchiveDate
                                }).ToListAsync();
            return result;

       
    }

        public async Task<DropdownsDataForAddcontact> GetDropdownsDataForAddcontact()
        {
            var JobPositions = await _position.GetJobPositions();
            var AddressTypes = await _address.GetAddressTypes();
            var ContactsParents = GetContacts();
            var result = new DropdownsDataForAddcontact
            {
                JobPositions = JobPositions.Select(x => x.Value).ToList(),
                AddressTypes = AddressTypes.Select(x => x.Value).ToList(),
                ContactsParents = ContactsParents.Result.Where(c => c.Category == EnumExtension.GetDisplayValue(CategoryType.Company)).Select(x=>x.FullName).ToList()
            };
            return result;
        }

        public async Task<DropdownsDataForAddcontactToProject> GetDropdownsDataForAddcontactToProject()
        {
            var roles =await _role.GetProjectRoles();
            var levels =await _level.GetLevels();
            var projects =await AppDbContext.PRJProject.Where(x=>x.MobMerchantMerchantId == CurrentMerchantId).Select(c=>c.Name).ToListAsync();

            var result = new DropdownsDataForAddcontactToProject
            {
                Levels = levels.Select(x => x.Value).ToList(),
                Projects = projects,
                Roles = roles.Select(x => x.Value).ToList()
            };
            return result;
        }

        public async Task UpdateContact(int adminId, int id, PRJAddContactsDTO model)
        {

            
            var toBeUpdated = await AppDbContext.PRJContacts
                              .Where(x => x.MobMerchantMerchantId == CurrentMerchantId && x.Id == id)
                              .FirstOrDefaultAsync();

            if (toBeUpdated == null)
            {
                throw new ApplicationException(AppExceptions.TheDataIsNotFound);
            }

            

            toBeUpdated.UpdatedOn = DateTime.Now;
            toBeUpdated.UpdatedBy = adminId;
            toBeUpdated.ArchiveDate = null;
            toBeUpdated.Mobile = model.Mobile;
            toBeUpdated.Notes = model.Notes;
            toBeUpdated.Email = model.Email;
            toBeUpdated.FullName = model.FullName;
            toBeUpdated.PRJJobPositionId = model.JobPositionId;
            toBeUpdated.Location = model.Location;
            toBeUpdated.City = model.City;
            toBeUpdated.Street = model.Street;
            toBeUpdated.Street2 = model.Street2;
            toBeUpdated.Code = model.Code;
            toBeUpdated.AddressTypeId = model.AddressTypeId;
            toBeUpdated.Country = model.Country;
            toBeUpdated.Location = model.Location;
            toBeUpdated.IsArchive = model.IsArchive;      
            toBeUpdated.CreatedBy = toBeUpdated.CreatedBy;
            toBeUpdated.Tags = model.Tags;         
            toBeUpdated.Photo = JsonConvert.SerializeObject(model.Photo);
            toBeUpdated.Category = model.Category;
            toBeUpdated.PRJContactsId = model.PRJContactsId;




            if (model.IsArchive == 1)
            {
                toBeUpdated.ArchiveDate = DateTime.Now;
            }


            AppDbContext.PRJContacts.Update(toBeUpdated);
            await AppDbContext.SaveChangesAsync();
        }
    }
}


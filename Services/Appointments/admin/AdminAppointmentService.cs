using Meta.IntroApp.DTOs.DTO_Appointments;
using Meta.IntroApp.DTOs.Pagination;
using Meta.IntroApp.Enums;
using Meta.IntroApp.Helpers;
using Meta.IntroApp.Interfaces;
using Meta.IntroApp.Localizations.AppExceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.Services
{
    public class AdminAppointmentService : BaseService, IAdminAppointmentService
    {
        private readonly IWebHostEnvironment _env;
        public AdminAppointmentService(MetaITechDbContext dbcontext, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
            : base(dbcontext, httpContextAccessor)
        {
            _env = env;
        }

        public async Task AddAppointment(long clientId, AddAppointmentDTO model)
        {
            int hour = Convert.ToDateTime(model.StartTime).Hour;
            int minute = Convert.ToDateTime(model.StartTime).Minute;

            var appointment = new MobAppointment
            {
                AppointmentDate = model.AppointmentDate,
                BookingDate = DateTime.Now,
                BranchId = CurrentBranchId,
                MerchantId = CurrentMerchantId,
                WorkPlanId = await AppDbContext.WorkPlans.Where(c => c.MerchantId == CurrentMerchantId).Select(x => x.Id).FirstOrDefaultAsync(),

                Status = AppointmentStatus.Pending,
                ClientId = clientId,
                MobAppointmentDetails = new List<MobAppointmentDetails>
                {
                    new MobAppointmentDetails
                    {
                    
                        //SubServiceId = model.SubServiceID,
                        //StaffId = model.StaffId,
                        FromTime = DateTime.Parse(model.StartTime), // model.AppointmentDate.AddHours(hour).AddMinutes(minute),
                                                                             //ToTime = model.AppointmentDate.AddHours(model.FinishHour).AddMinutes(model.FinishMinute),
                        Status = AppointmentStatus.Pending,
                        PhoneNumber = model.PhoneNumber,
                        Notes = model.Notes
                    }
                }
            };
            AppDbContext.Appointments.Add(appointment);
            await AppDbContext.SaveChangesAsync();

        }

        public async Task DeleteAppointment(int appointmentId)
        {
            var PendingAppontment = AppDbContext.Appointments.Where(p => p.Id == appointmentId
                                                                 && p.Status == AppointmentStatus.Pending).FirstOrDefault();

            if (PendingAppontment == null)
            {
                throw new ApplicationException(AppExceptions.UnExpectedError);
            }
            var toDeleteDetailes = await AppDbContext.AppointmentDetailes.Where(p => p.AppointmentId == appointmentId).ToListAsync();
            if (toDeleteDetailes == null)
            {
                throw new ApplicationException(AppExceptions.UnExpectedError);
            }
            for (int i = 0; i < toDeleteDetailes.Count; i++)
            {
                AppDbContext.AppointmentDetailes.Remove(toDeleteDetailes[i]);
                await AppDbContext.SaveChangesAsync();
            }

            MobAppointment toDeleteAppontment = AppDbContext.Appointments.Where(p => p.Id == appointmentId).FirstOrDefault();
            AppDbContext.Appointments.Remove(toDeleteAppontment);
            await AppDbContext.SaveChangesAsync();

        }

        public async Task<List<AppointmentDetailesDTO>> GetAppointmentDetailes(int? appointmentId)
        {
            var subResult = await AppDbContext
                               .AppointmentDetailes
                               .Where(x => x.AppointmentId == appointmentId)
                               .ToListAsync();

            return subResult?.ConvertAll(detailes => new AppointmentDetailesDTO
            {
                Id = detailes.Id,
                //StaffId = detailes.StaffId,
                FromTime = detailes.FromTime.GetTime(),
                //ToTime = detailes.ToTime.GetTime(),
                DetailesStatus = EnumExtension.GetDisplayValue(detailes.Status),
                //SubServiceId = detailes.SubServiceId,
                Notes = detailes.Notes,
                PhoneNumber = detailes.PhoneNumber
            });
            //}

        }

        public async Task<List<string>> GetAvailableTimes(DateTime date, bool checkAvailableTimes = false)
        {
            if (!checkAvailableTimes)
            {
                var times1 = new List<TimeSpan>();
                var times2 = new List<TimeSpan>();

                var currentPlan = await AppDbContext.WorkPlans.Where(x => x.MerchantId == CurrentMerchantId).FirstOrDefaultAsync();

                int interval = await AppDbContext.Merchants.Where(x => x.MerchantId == CurrentMerchantId).Select(y => y.Interval).FirstOrDefaultAsync();


                for (var i = currentPlan.FirstWorkTimeStart; i < currentPlan.FirstWorkTimeEnd; i = i.Value.AddMinutes(interval))
                {
                    times1.Add(i.Value.TimeOfDay);
                }
                for (var i = currentPlan.SecondWorkTimeStart; i < currentPlan.SecondWorkTimeEnd; i = i.Value.AddMinutes(interval))
                {
                    times2.Add(i.Value.TimeOfDay);
                }
                times1.AddRange(times2);

                var subResultDateTime = times1.ConvertAll(item => DateTime.Parse(item.ToString()));
                return subResultDateTime?.ConvertAll(item => item.ToString("hh:mm tt"));
            }
            else
            {
                var times1 = new List<TimeSpan>();
                var times2 = new List<TimeSpan>();

                var currentPlan = await AppDbContext.WorkPlans.Where(x => x.MerchantId == CurrentMerchantId).FirstOrDefaultAsync();
                if (currentPlan == null)
                {
                    throw new ApplicationException(AppExceptions.NoWorkPlanFound);
                }
                int interval = await AppDbContext.Merchants.Where(x => x.MerchantId == CurrentMerchantId).Select(y => y.Interval).FirstOrDefaultAsync();

                var blockedTimes = await AppDbContext.AppointmentDetailes.Where(x => x.Appointment.MerchantId == CurrentMerchantId
                                                                                && x.Appointment.AppointmentDate == date
                                                                                ).Select(x => x.FromTime.Value.TimeOfDay).ToListAsync();

                for (var i = currentPlan.FirstWorkTimeStart; i < currentPlan.FirstWorkTimeEnd; i = i.Value.AddMinutes(interval))
                {
                    times1.Add(i.Value.TimeOfDay);
                }
                for (var i = currentPlan.SecondWorkTimeStart; i < currentPlan.SecondWorkTimeEnd; i = i.Value.AddMinutes(interval))
                {
                    times2.Add(i.Value.TimeOfDay);
                }
                times1.AddRange(times2);

                var subResultTimeSpan = times1.Except(blockedTimes).ToList();

                var subResultDateTime = subResultTimeSpan.ConvertAll(item => DateTime.Parse(item.ToString()));
                return subResultDateTime?.ConvertAll(item => item.ToString("hh-mm tt"));
            }

            //}
        }

        public async Task<List<AppointmentDTO>> ListAppointments(long clientID, PaginationFilterDTO filter)
        {

            //if (_env.IsProduction())
            //{
            //    List<AppointmentDTO> result = new List<AppointmentDTO>{
            //    new AppointmentDTO
            //    {
            //        Id = 1,
            //        ClientId = clientID,
            //        BookingDate = DateTime.Now.ToString(),
            //        AppointmentDate = DateTime.Now.ToString(),
            //        PlanId = 1,
            //        StatusText = EnumExtension.GetDisplayValue(AppointmentStatus.Pending),
            //        Status = AppointmentStatus.Pending
            //    },
            //      new AppointmentDTO
            //    {
            //        Id = 2,
            //        ClientId = clientID,
            //        BookingDate = DateTime.Now.ToString(),
            //        AppointmentDate = DateTime.Now.ToString(),
            //        PlanId = 1,
            //        StatusText = EnumExtension.GetDisplayValue(AppointmentStatus.Pending),
            //        Status = AppointmentStatus.Pending
            //    },
            //       new AppointmentDTO
            //    {
            //        Id = 3,
            //        ClientId = clientID,
            //        BookingDate = DateTime.Now.ToString(),
            //        AppointmentDate = DateTime.Now.ToString(),
            //        PlanId = 1,
            //        StatusText = EnumExtension.GetDisplayValue(AppointmentStatus.Pending),
            //        Status = AppointmentStatus.Pending
            //    }};
            //    return result;

            //}
            //else 
            //{

            var validFilter = new PaginationFilterDTO(filter.PageNumber, filter.PageSize);

            var listDbModel = await AppDbContext.Appointments
                                         .Where(x => x.MerchantId == CurrentMerchantId && x.ClientId == clientID && x.BranchId == CurrentBranchId)
                                          .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                          .Take(validFilter.PageSize)
                                         .ToListAsync();

            return listDbModel.ConvertAll(appointment => new AppointmentDTO
            {
                Id = appointment.Id,
                //ClientId = appointment.ClientId,
                BookingDate = appointment.BookingDate.GetDate(),
                AppointmentDate = appointment.AppointmentDate.Value.ToString("yyyy-MM-dd"),

                //PlanId = appointment.WorkPlanId,
                StatusText = EnumExtension.GetDisplayValue(appointment.Status),
                Status = appointment.Status,
                AppointmentTime = AppDbContext.AppointmentDetailes
                                     .Where(x => x.AppointmentId == appointment.Id).Select(c => c.FromTime).FirstOrDefault().GetTime()

            });
            //}

        }

        public async Task UpdateAppointment(int appointmentId, AddAppointmentDTO model)
        {
            //if (_env.IsProduction())
            //{
            //    return;
            //}
            //else
            //{
            int hour = Convert.ToDateTime(model.StartTime).Hour;
            int minute = Convert.ToDateTime(model.StartTime).Minute;
            MobAppointment subResult1 = AppDbContext.Appointments.Where(x => x.MerchantId == CurrentMerchantId && x.BranchId == CurrentBranchId.Value &&
                                       x.Id == appointmentId).FirstOrDefault();
            MobAppointmentDetails subResult2 = AppDbContext.AppointmentDetailes.Where(x => x.AppointmentId == appointmentId).FirstOrDefault();
            if (subResult1 != null && subResult2 != null)
            {
                subResult1.AppointmentDate = model.AppointmentDate;
                // subResult1.Status = model.Status;

                //subResult2.StaffId = model.StaffId;
                subResult2.FromTime = model.AppointmentDate.AddHours(hour).AddMinutes(minute);
                // subResult2.ToTime = model.AppointmentDate.AddHours(model.FinishHour).AddMinutes(model.FinishMinute);
                //subResult2.SubServiceId = model.SubServiceID;
                //subResult2.Status = model.Status;

                AppDbContext.Appointments.Update(subResult1);
                await AppDbContext.SaveChangesAsync();

                AppDbContext.AppointmentDetailes.Update(subResult2);
                await AppDbContext.SaveChangesAsync();
            }

        }
    }
}
    

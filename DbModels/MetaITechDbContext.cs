using Meta.IntroApp.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Meta.IntroApp
{
    public class MetaITechDbContext : IdentityDbContext<Account, Role, long,
                                                        AccountClaim, AccountRole,
                                                        AccountLogin, RoleCalim,
                                                        AccountToken>
    {
        public MetaITechDbContext(DbContextOptions<MetaITechDbContext> options) : base(options)
        {
        }

        public MetaITechDbContext()
        {
        }

        public virtual DbSet<PRJTAG> PRJTAG { get; set; }
        public virtual DbSet<PRJTaskStatus> PRJTaskStatus { get; set; }
        public virtual DbSet<PRJAddressType> PRJAddressType { get; set; }
        public virtual DbSet<PRJJobPosition> PRJJobPosition { get; set; }
        public virtual DbSet<PRJInvolvementLevel> PRJInvolvementLevel { get; set; }
        public virtual DbSet<PRJProjectStatus> PRJProjectStatus { get; set; }
        public virtual DbSet<PRJProjectCategory> PRJProjectCategory { get; set; }
        public virtual DbSet<PRJProject> PRJProject { get; set; }
        public virtual DbSet<PRJProjectHistory> PRJProjectHistory { get; set; }
        public virtual DbSet<PRJContacts> PRJContacts { get; set; }
        public virtual DbSet<PRJTaskHistory> PRJTaskHistory { get; set; }
        public virtual DbSet<PRJTaskFollower> PRJTaskFollower { get; set; }
        public virtual DbSet<PRJTask> PRJTask { get; set; }
        public virtual DbSet<PRJProjectRole> PRJProjectRole { get; set; }
        public virtual DbSet<PRJProjectFollowers> PRJProjectFollowers { get; set; }
        public virtual DbSet<PRJAttachements> PRJAttachements { get; set; }
        public virtual DbSet<PRJTimeSheet> PRJTimeSheet { get; set; }




        public virtual DbSet<MobRequest> MobRequests { get; set; }
        public virtual DbSet<MobFeedBack> FeedBacks { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<MobAbout> Abouts { get; set; }
        public virtual DbSet<MobAppointment> Appointments { get; set; }
        public virtual DbSet<MobAppointmentDetails> AppointmentDetailes { get; set; }
        public virtual DbSet<MobBranch> Branches { get; set; }
        public virtual DbSet<MobContact> Contacts { get; set; }
        public virtual DbSet<MobGallery> Galleries { get; set; }
        public virtual DbSet<MobGlobalTheme> GlobalThemes { get; set; }
        public virtual DbSet<MobImage> Images { get; set; }
        public virtual DbSet<MobMerchant> Merchants { get; set; }
        public virtual DbSet<MobNews> News { get; set; }
        public virtual DbSet<MobOurTeam> OurTeams { get; set; }
        public virtual DbSet<MobProject> Projects { get; set; }
        public virtual DbSet<MobService> Services { get; set; }
        public virtual DbSet<MobSlider> Sliders { get; set; }
        public virtual DbSet<MobStaffServiceAssign> StaffServiceAssigns { get; set; }
        public virtual DbSet<MobSubService> SubServices { get; set; }
        public virtual DbSet<MobWorkPlan> WorkPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

       
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.Property(c => c.AccountType)
                    .HasDefaultValue(AccountType.Admin);

                entity.Property(c => c.FirstName)
                    .IsRequired(false)
                    .IsUnicode(true);

                entity.Property(c => c.LastName)
                    .IsRequired(false)
                    .IsUnicode(true);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.ToTable("AccountRoles");
            });

            modelBuilder.Entity<AccountLogin>(entity =>
            {
                entity.HasKey(c=> c.Id);

                entity.ToTable("AccountLogins");
            });

            modelBuilder.Entity<MobAbout>(entity =>
            {
                entity.HasKey(e => e.AboutUsId)
                    ;

                entity.ToTable("MOB_ABOUT");

                entity.HasIndex(e => e.MerchantId, "MERCHANT_FK");

                entity.Property(e => e.AboutUsId);

                entity.Property(e => e.Address)
                    
                    
                    
                    ;

                entity.Property(e => e.Description)
                    
                    ;

                entity.Property(e => e.Images)
                    
                    
                    ;

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobAbouts)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("MERCHANT_FK");
            });

            modelBuilder.Entity<MobAppointment>(entity =>
            {
                entity.ToTable("MOB_APPOINTMENT");

                entity.HasIndex(e => e.BranchId, "B_FK_idx");

                entity.HasIndex(e => e.ClientId, "CLIENT_APPOINTMENT_FK_idx");

                entity.HasIndex(e => e.MerchantId, "M_FK_idx");

                entity.HasIndex(e => e.WorkPlanId, "W_P_APPOINTMENT_idx");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.AppointmentDate)
                    
                    ;

                entity.Property(e => e.BookingDate)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.ClientId)
                    
                    
                    
                    ;

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Status)
                    
                    ;

                entity.Property(e => e.WorkPlanId)
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobAppointments)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("B_FK");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("CLIENT_APPOINTMENT_FK");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobAppointments)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("M_FK");

                entity.HasOne(d => d.WorkPlan)
                    .WithMany(p => p.MobAppointments)
                    .HasForeignKey(d => d.WorkPlanId)
                    .HasConstraintName("W_P_APPOINTMENT");
            });

            modelBuilder.Entity<MobAppointmentDetails>(entity =>
            {
                entity.ToTable("MOB_APPOINTMENT_DETAILES");

                entity.HasIndex(e => e.AppointmentId, "APPOINTMENT_FK_idx");

                entity.HasIndex(e => e.StaffId, "STAFF_FK_idx");

                entity.HasIndex(e => e.SubServiceId, "SU_SERVICE_FK_idx");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.AppointmentId)
                    
                    ;

                entity.Property(e => e.FromTime)
                    
                    ;

                entity.Property(e => e.Notes)
                    
                    
                    
                    ;

                entity.Property(e => e.StaffId)
                    
                    ;

                entity.Property(e => e.Status)
                    
                    ;

                entity.Property(e => e.SubServiceId)
                    
                    ;

                entity.Property(e => e.ToTime)
                    
                    ;

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MobAppointmentDetails)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("APPOINTMENT_FK");

                entity.HasOne(d => d.SubService)
                    .WithMany(p => p.MobAppointmentDetailes)
                    .HasForeignKey(d => d.SubServiceId)
                    .HasConstraintName("SU_SERVICE_FK");
            });

            modelBuilder.Entity<MobBranch>(entity =>
            {
                entity.HasKey(e => e.BranchesId)
                    ;

                entity.ToTable("MOB_BRANCH");

                entity.HasIndex(e => e.MerchantId, "USER_FK");

                entity.Property(e => e.BranchesId)
                    
                    ;

                entity.Property(e => e.Address)
                    
                    
                    
                    ;

                entity.Property(e => e.City)
                    
                    
                    
                    ;

                entity.Property(e => e.IsActive)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsMain)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Name)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobBranches)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("USER_FK");
            });

            modelBuilder.Entity<MobContact>(entity =>
            {
                entity.HasKey(e => e.ContactUsId)
                    ;

                entity.ToTable("MOB_CONTACT");

                entity.HasIndex(e => e.BranchId, "BRANCH_ID_CONTACT");

                entity.HasIndex(e => e.MerchantId, "USER_CONTACT_FK");

                entity.Property(e => e.ContactUsId)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.Channel)
                    
                    
                    
                    ;

                entity.Property(e => e.IsActive)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsSelected)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Value)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobContacts)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("BRANCH_ID_CONTACT");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobContacts)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("USER_CONTACT_FK");
            });

            modelBuilder.Entity<MobGallery>(entity =>
            {
                entity.ToTable("MOB_GALLERY");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.IsFeatured)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;
            });

            modelBuilder.Entity<MobGlobalTheme>(entity =>
            {
                entity.ToTable("MOB_GLOBAL_THEME");

                entity.HasIndex(e => e.BranchId, "BRANCH_THEME");

                entity.HasIndex(e => e.MerchantId, "USER_THEME_FK");

                entity.Property(e => e.MobGlobalThemeId)
                    
                    ;

                entity.Property(e => e.BackGroundColor)
                    
                    
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.FontColor)
                    
                    
                    
                    ;

                entity.Property(e => e.FontType)
                    
                    
                    
                    ;

                entity.Property(e => e.GlobalColor)
                    
                    
                    
                    ;

                //entity.Property(e => e.IsActive)
                    
                    
                //    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LayoutOrder)
                    
                    ;

                entity.Property(e => e.LogoImage)
                    
                    
                    
                    ;

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.NavBarColor)
                    
                    
                    
                    ;

                entity.Property(e => e.SideBarColor)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobGlobalThemes)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("BRANCH_THEME");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobGlobalThemes)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("USER_THEME_FK");
            });

            modelBuilder.Entity<MobImage>(entity =>
            {
                entity.HasKey(e => e.ImagesId)
                    ;

                entity.ToTable("MOB_IMAGE");

                entity.HasIndex(e => e.BranchesId, "BRANCH_FK");

                entity.HasIndex(e => e.NewsId, "NEWS_FK");

                entity.HasIndex(e => e.ProjectId, "PROJECT");

                entity.HasIndex(e => e.ServiceId, "SERVICE_FK");

                entity.HasIndex(e => e.SubServiceId, "SUB_SERVICE_FK");

                entity.Property(e => e.ImagesId)
                    
                    ;

                entity.Property(e => e.AboutUsId)
                    
                    ;

                entity.Property(e => e.BranchesId)
                    
                    ;

                entity.Property(e => e.ContactUsId)
                    
                    ;

                entity.Property(e => e.DataBase64)
                    
                    
                    
                    ;

                entity.Property(e => e.EmployeeId)
                    
                    ;

                entity.Property(e => e.IsCover)
                    
                    ;

                entity.Property(e => e.IsFeatured)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NewsId)
                    
                    ;

                entity.Property(e => e.ProjectId)
                    
                    ;

                entity.Property(e => e.ServiceId)
                    
                    ;

                entity.Property(e => e.SubServiceId)
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Branches)
                    .WithMany(p => p.MobImages)
                    .HasForeignKey(d => d.BranchesId)
                    .HasConstraintName("BRANCH_FK");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.MobImages)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("NEWS_FK");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.MobImages)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("PROJECT");

                //entity.HasOne(d => d.Service)
                //    .WithMany(p => p.MobImages)
                //    .HasForeignKey(d => d.ServiceId)
                //    .HasConstraintName("SERVICE_FK");

                entity.HasOne(d => d.SubService)
                    .WithMany(p => p.MobImages)
                    .HasForeignKey(d => d.SubServiceId)
                    .HasConstraintName("SUB_SERVICE_FK");
            });

            modelBuilder.Entity<MobMerchant>(entity =>
            {
                entity.HasKey(e => e.MerchantId)
                    ;

                entity.ToTable("MOB_MERCHANT");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.MerchantName)
                    
                    
                    
                    ;
            });

            modelBuilder.Entity<MobNews>(entity =>
            {
                entity.HasKey(e => e.NewsId)
                    ;

                entity.ToTable("MOB_NEWS");

                entity.HasIndex(e => e.BranchId, "BRANCH_ID_NEWS");

                entity.HasIndex(e => e.MerchantId, "USER_NEWS_FK");

                entity.Property(e => e.NewsId)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.Description)
                    
                    
                    
                    ;

                entity.Property(e => e.Images)
                    
                    
                    
                    ;

                entity.Property(e => e.IsActive)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsPublished)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.PublishingDate)
                    
                    ;

                entity.Property(e => e.SubTitle)
                    
                    
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobNews)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("BRANCH_ID_NEWS");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobNews)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("USER_NEWS_FK");
            });

            modelBuilder.Entity<MobOurTeam>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    ;

                entity.ToTable("MOB_OUR_TEAM");

                entity.HasIndex(e => e.BranchId, "BRANCH_ID_EMPLOYEE");

                entity.HasIndex(e => e.MerchantId, "MERCHANT_EMPLOYEE_FK");

                entity.Property(e => e.EmployeeId)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.FullName)
                    
                    
                    
                    ;

                entity.Property(e => e.Images)
                    
                    
                    
                    ;

                entity.Property(e => e.IsActive)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Position)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobOurTeams)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("BRANCH_ID_EMPLOYEE");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobOurTeams)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("MERCHANT_EMPLOYEE_FK");
            });

            modelBuilder.Entity<MobProject>(entity =>
            {
                entity.ToTable("MOB_PROJECT");

                entity.HasIndex(e => e.BranchId, "BRANCH_ID");

                entity.HasIndex(e => e.MerchantId, "PROJECT_MERCHANT_FK");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.ClientName)
                    
                    
                    
                    ;

                entity.Property(e => e.Description)
                    
                    
                    
                    ;

                entity.Property(e => e.EndDate)
                    
                    ;

                entity.Property(e => e.Images)
                    
                    
                    
                    ;

                entity.Property(e => e.IsActive)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Period)
                    
                    
                    
                    ;

                entity.Property(e => e.StartDate)
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobProjects)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("BRANCH_ID");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobProjects)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("PROJECT_MERCHANT_FK");
            });

            modelBuilder.Entity<MobService>(entity =>
            {
                entity.HasKey(e => e.ServicesId)
                    ;

                entity.ToTable("MOB_SERVICE");

                entity.HasIndex(e => e.BranchId, "BRANCH_ID_SERVICES");

                entity.HasIndex(e => e.MerchantId, "SERVICE_MERCHANT_FK");

                entity.Property(e => e.ServicesId)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.Color)
                    
                    
                    
                    ;

                entity.Property(e => e.Description)
                    
                    
                    
                    ;

                entity.Property(e => e.Icon)
                    
                    
                    
                    ;

                entity.Property(e => e.IconMobile)
                    
                    
                    
                    ;

                entity.Property(e => e.Image)
                    
                    
                    
                    ;

                entity.Property(e => e.IsActive)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobServices)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("BRANCH_ID_SERVICES");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobServices)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("SERVICE_MERCHANT_FK");
            });

            modelBuilder.Entity<MobSlider>(entity =>
            {
                entity.ToTable("MOB_SLIDERS");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.IsFeatured)
                    
                    ;

                entity.Property(e => e.Link)
                    
                    
                    
                    ;

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;
            });

            modelBuilder.Entity<MobStaffServiceAssign>(entity =>
            {
                entity.ToTable("MOB_STAFF_SERVICE_ASSIGN");

                entity.HasIndex(e => e.StaffId, "STAFF_FK_idx");

                entity.HasIndex(e => e.SubServiceId, "S_SERVICE_FK_idx");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.StaffId)
                    
                    ;

                entity.Property(e => e.SubServiceId)
                    
                    ;

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.MobStaffServiceAssigns)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("STAFF_FK");

                entity.HasOne(d => d.SubService)
                    .WithMany(p => p.MobStaffServiceAssigns)
                    .HasForeignKey(d => d.SubServiceId)
                    .HasConstraintName("S_SERVICE_FK");
            });

            modelBuilder.Entity<MobSubService>(entity =>
            {
                entity.HasKey(e => e.SubServicesId)
                    ;

                entity.ToTable("MOB_SUB_SERVICE");

                entity.HasIndex(e => e.ServiceId, "SERVICE_ID");

                entity.Property(e => e.SubServicesId)
                    
                    ;

                entity.Property(e => e.Color)
                    
                    
                    
                    ;

                entity.Property(e => e.Description)
                    
                    
                    
                    ;

                entity.Property(e => e.Icon)
                    
                    
                    
                    ;

                entity.Property(e => e.Images)
                    
                    
                    
                    ;

                entity.Property(e => e.IsActive)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsFeatured)
                    
                    
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ServiceId)
                    
                    ;

                entity.Property(e => e.Title)
                    
                    
                    
                    ;

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.MobSubServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("SERVICE_ID");
            });

            modelBuilder.Entity<MobWorkPlan>(entity =>
            {
                entity.ToTable("MOB_WORK_PLAN");

                entity.HasIndex(e => e.BranchId, "BRANCH_PLAN_FK_idx");

                entity.HasIndex(e => e.MerchantId, "MERCHANT_PLAN_FK_idx");

                entity.Property(e => e.Id)
                    
                    ;

                entity.Property(e => e.BranchId)
                    
                    ;

                entity.Property(e => e.FirstWorkTimeEnd)
                    
                    ;

                entity.Property(e => e.FirstWorkTimeStart)
                    
                    ;

                entity.Property(e => e.FromDay)
                    
                    ;

                entity.Property(e => e.MerchantId)
                    
                    
                    
                    ;

                entity.Property(e => e.Notes)
                    
                    
                    
                    ;

                entity.Property(e => e.PlanName)
                    
                    
                    
                    ;

                entity.Property(e => e.SecondWorkTimeEnd)
                    
                    ;

                entity.Property(e => e.SecondWorkTimeStart)
                    
                    ;

                entity.Property(e => e.ToDay)
                    
                    ;

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MobWorkPlans)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("BRANCH_PLAN_FK");

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.MobWorkPlans)
                    .HasForeignKey(d => d.MerchantId)
                    .HasConstraintName("MERCHANT_PLAN_FK");
            });

        }

    }
}
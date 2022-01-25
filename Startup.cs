using API.Extensions;

using Meta.IntroApp.Extensions;

//using Meta.IntroApp.Models;
using Meta.IntroApp.Interfaces;
using Meta.IntroApp.Services;
using Meta.IntroApp.Services.Admin;
using Meta.IntroApp.Services.Client;
using Meta.IntroApp.Services.FeedBack;
using Meta.IntroApp.Services.Merchant;
using Meta.IntroApp.Services.Notification;
using Meta.IntroApp.Services.PRJ_AddressType.admin;
using Meta.IntroApp.Services.PRJ_Attachement.admin;
using Meta.IntroApp.Services.PRJ_Attachement.client;
using Meta.IntroApp.Services.PRJ_Contacts.admin;
using Meta.IntroApp.Services.PRJ_InvolvementLevel.admin;
using Meta.IntroApp.Services.PRJ_JobPosition.admin;
using Meta.IntroApp.Services.PRJ_Project.admin;
using Meta.IntroApp.Services.PRJ_ProjectCategory.admin;
using Meta.IntroApp.Services.PRJ_ProjectFollower.Admin;
using Meta.IntroApp.Services.PRJ_ProjectHistory.admin;
using Meta.IntroApp.Services.PRJ_ProjectStatus.admin;
using Meta.IntroApp.Services.PRJ_Role.admin;
using Meta.IntroApp.Services.PRJ_Tag.admin;
using Meta.IntroApp.Services.PRJ_Task.admin;
using Meta.IntroApp.Services.PRJ_TaskFollower;
using Meta.IntroApp.Services.PRJ_TaskHistory;
using Meta.IntroApp.Services.PRJ_TaskStatus;
using Meta.IntroApp.Services.PRJ_TimeSheet.Admin;
using Meta.IntroApp.Services.Request.Admin;
using Meta.IntroApp.Services.Request.Client;
using Meta.IntroApp.Services.UploadFiles;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Meta.IntroApp
{
    public class Startup
    {
        private const string CorsPolicyName = "AllowOrigin";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _appConfiguration = configuration;
            _env = env.ContentRootPath;
        }

        public IConfiguration _appConfiguration { get; }

        public string _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MetaITechDbContext>(optionsBuilder => optionsBuilder
                                                               .UseSqlServer(_appConfiguration.GetConnectionString("AppDb"), providerOptions =>
                                                               {
                                                                   providerOptions.CommandTimeout(60);
                                                                   providerOptions.EnableRetryOnFailure(maxRetryCount:5);
                                                               })
                                                              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddIdentity<Account,Role >(cfg => { cfg.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<MetaITechDbContext>()
                .AddDefaultTokenProviders();
            
            
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
         

            services.AddControllers(options =>
            {
                options.Conventions.Add(new SwaggerAreaControllerConvention());//swagger area controlelrs convention
               
            })
            .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.RequireRole("admin"));
                options.AddPolicy("AcceptNameUserSpecific",policy => policy.Requirements.Add(new ValueToAcceptUser(1)));
            });
            services.AddSingleton<IAuthorizationHandler,ValueToAcceptUserHandler>();
            services.AddSingleton<INameUser, NameUser>();
            services.AddTransient<TestMiddleWareToWorkAsPolicy>();
            services.AddTransient<IHostedService, BackgroundServiceEmailProjectManager>();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                var titleBase = "Intro APP API";
                options.SwaggerDoc("Common", new OpenApiInfo
                {
                    Version = "Common",
                    Title = titleBase + " Common Space",
                });

                options.SwaggerDoc("Admin", new OpenApiInfo
                {
                    Version = "Admin",
                    Title = titleBase + " Admin Space",
                });

                
                options.SwaggerDoc("Client", new OpenApiInfo
                {
                    Version = "Client",
                    Title = titleBase + " Client Space",
                });

                //Adding API http header
                options.OperationFilter<SwaggerHttpHeaderFilter>();

                //Setting swagger authentications
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            services.AddLogging();

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName,
                                   builder => builder
                                   .AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod());
            });

            //register services
            RegisterCommonServices(services);
            RegisterClientServices(services);
            RegisterAdminServices(services);

            services.AddControllers().AddNewtonsoftJson();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                 .AddJwtBearer(options =>
                 {
                     options.SaveToken = true;
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = _appConfiguration["JWT:Issuer"],
                         ValidAudience = _appConfiguration["JWT:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfiguration["JWT:Key"]))
                     };
                     options.Events = new JwtBearerEvents
                     {
                         OnAuthenticationFailed = context =>
                         {
                             if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                             {
                                 context.Response.Headers.Add("Token-Expired", "true");
                             }
                             return Task.CompletedTask;
                         }
                     };
                 });

            // To avoid the BodyLength error when upload file
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(CorsPolicyName);

            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            // Extenstion method in class RouteMiddleWare
            app.adminMiddleWare();
           // 

        app.UseRequestLocalization(op =>
            {
                op.DefaultRequestCulture = new RequestCulture("ar-sy", "en");
                op.SupportedUICultures = new List<CultureInfo> { new CultureInfo("ar-sy"), new CultureInfo("en")/*, new CultureInfo("ku") */};
                op.DefaultRequestCulture.UICulture.DateTimeFormat = DateTimeFormatInfo.InvariantInfo;
                op.DefaultRequestCulture.Culture.DateTimeFormat = DateTimeFormatInfo.InvariantInfo;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
            ForwardedHeaders.XForwardedProto
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(_appConfiguration.GetValue<string>("HostingVirtualDirectory") + "/swagger/Common/swagger.json", "Common API");
                    options.SwaggerEndpoint(_appConfiguration.GetValue<string>("HostingVirtualDirectory") + "/swagger/Admin/swagger.json", "Admin API");
                    options.SwaggerEndpoint(_appConfiguration.GetValue<string>("HostingVirtualDirectory") + "/swagger/Client/swagger.json", "Client API");
                });
            }
            else
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(_appConfiguration.GetValue<string>("HostingVirtualDirectory") + "/swagger/Common/swagger.json", "Common API");
                    options.SwaggerEndpoint(_appConfiguration.GetValue<string>("HostingVirtualDirectory") + "/swagger/Admin/swagger.json", "Admin API");
                    options.SwaggerEndpoint(_appConfiguration.GetValue<string>("HostingVirtualDirectory") + "/swagger/Client/swagger.json", "Client API");
                });
            }
          
        }

        #region Registering Services

        private static void RegisterCommonServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUploadFileService, UploadFileServices>();
            
        }
        private static void RegisterClientServices(IServiceCollection services)
        {
            services.AddScoped<IClientAboutUsService, ClientAboutUsService>();
            services.AddScoped<IClientAppointmentService, ClientAppointmentService>();
            services.AddScoped<IClientBranches, ClientBranchService>();
            services.AddScoped<IAdminAboutUsService, AdminAboutUsService>();
            services.AddScoped<IClientContactUs, ClientContactUsService>();
            services.AddScoped<IClientNewsService, ClientNewsService>();
            services.AddScoped<IClientProjectService, ClientProjectService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IClientServicesService, ClientServicesService>();
            services.AddScoped<IClientSubServicesService, ClientSubServicesService>();
            services.AddScoped<IClientThemeExecution, ClientThemeExecution>();
            services.AddScoped<IClientFeedBackEmail, ClientFeedBackEmail>();
            services.AddScoped<IClientRequest, ClientRequestService>();
        }

        private static void RegisterAdminServices(IServiceCollection services)
        {
            services.AddScoped<IAdminAboutUsService, AdminAboutUsService>();
            services.AddScoped<IAdminSubServicesService, AdminSubServicesService>();
            services.AddScoped<IAdminAppointmentService, AdminAppointmentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAdminBranchesService, AdminBranchService>();
            services.AddScoped<IAdminContactUsService, AdminContactUsService>();
            services.AddScoped<IAdminNewsService, AdminNewsService>();
            services.AddScoped<IAdminProjectService, AdminProjectService>();
            services.AddScoped<IAdminServicesService, AdminServicesService>();
            services.AddScoped<IAdminSubServicesService, AdminSubServicesService>();
            services.AddScoped<IAdminThemeService, AdminThemeService>();
            services.AddScoped<IAdminWorkPlanService, AdminWorkPlanExecution>();
            services.AddScoped<IAdminMerchant, AdminMerchantService>();
            services.AddScoped<IAdminRequest, AdminReqestService>();
            services.AddScoped<ITagAdmin, AdminTagService>();
            services.AddScoped<IAdminJobPosition, AdminJobPositionService>();
            services.AddScoped<IAdminInvolvementLevel, AdminInvolvementLevelService>();
            services.AddScoped<IAdminProject, RRJAdminProjectService>();
            services.AddScoped<IAdminProjectCategory, AdminProjectCategoryService>();
            services.AddScoped<IAdminProjectRole, AdminProjectRoleService>();
            services.AddScoped<IAdminProjectFollower, AdminProjectFollowerService>();
            services.AddScoped<IAdminProjectStatus, AdminProjectStatusService>();
            services.AddScoped<IAdminTask, AdminTaskService>();
            services.AddScoped<IAdminTaskFollowers, AdminTaskFollowersService>();
            services.AddScoped<IAdminAddressType, AdminAddressTypeService>();
            services.AddScoped<IAdminTaskStatus, AdminTaskStatusService>();
            services.AddScoped<PRJIAdminContact, PRJAdminContactService>();
            services.AddScoped<IAdminProjectAttachements, AdminProjectAttachementsService>();
            services.AddScoped<IAdminProjectHistory, ProjectHistoryService>();
            services.AddScoped<IAdminTaskHistory, AdminTaskHistoryService>();
            services.AddScoped<IAdminTimesheet, AdminTimeSheetService>();
        }

        #endregion Registering Services
    }
}
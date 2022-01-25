using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MOB_GALLERY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_GALLERY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MOB_MERCHANT",
                columns: table => new
                {
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MerchantName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_MERCHANT", x => x.MerchantId);
                });

            migrationBuilder.CreateTable(
                name: "MOB_SLIDERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_SLIDERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_MOB_MERCHANT_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_ABOUT",
                columns: table => new
                {
                    AboutUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_ABOUT", x => x.AboutUsId);
                    table.ForeignKey(
                        name: "MERCHANT_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_BRANCH",
                columns: table => new
                {
                    BranchesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsMain = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_BRANCH", x => x.BranchesId);
                    table.ForeignKey(
                        name: "USER_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountLogins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountLogins_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AccountRoles_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MOB_CONTACT",
                columns: table => new
                {
                    ContactUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSelected = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_CONTACT", x => x.ContactUsId);
                    table.ForeignKey(
                        name: "BRANCH_ID_CONTACT",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "USER_CONTACT_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_GLOBAL_THEME",
                columns: table => new
                {
                    MobGlobalThemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FontColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlobalColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackGroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideBarColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavBarColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LayoutOrder = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_GLOBAL_THEME", x => x.MobGlobalThemeId);
                    table.ForeignKey(
                        name: "BRANCH_THEME",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "USER_THEME_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_NEWS",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublished = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_NEWS", x => x.NewsId);
                    table.ForeignKey(
                        name: "BRANCH_ID_NEWS",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "USER_NEWS_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_OUR_TEAM",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_OUR_TEAM", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "BRANCH_ID_EMPLOYEE",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MERCHANT_EMPLOYEE_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_PROJECT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_PROJECT", x => x.Id);
                    table.ForeignKey(
                        name: "BRANCH_ID",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PROJECT_MERCHANT_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_SERVICE",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "'1'"),
                    IconMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_SERVICE", x => x.ServicesId);
                    table.ForeignKey(
                        name: "BRANCH_ID_SERVICES",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SERVICE_MERCHANT_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_WORK_PLAN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstWorkTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstWorkTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondWorkTimeStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondWorkTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_WORK_PLAN", x => x.Id);
                    table.ForeignKey(
                        name: "BRANCH_PLAN_FK",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MERCHANT_PLAN_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_SUB_SERVICE",
                columns: table => new
                {
                    SubServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_SUB_SERVICE", x => x.SubServicesId);
                    table.ForeignKey(
                        name: "SERVICE_ID",
                        column: x => x.ServiceId,
                        principalTable: "MOB_SERVICE",
                        principalColumn: "ServicesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_APPOINTMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    WorkPlanId = table.Column<int>(type: "int", nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_APPOINTMENT", x => x.Id);
                    table.ForeignKey(
                        name: "B_FK",
                        column: x => x.BranchId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CLIENT_APPOINTMENT_FK",
                        column: x => x.ClientId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "M_FK",
                        column: x => x.MerchantId,
                        principalTable: "MOB_MERCHANT",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "W_P_APPOINTMENT",
                        column: x => x.WorkPlanId,
                        principalTable: "MOB_WORK_PLAN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_IMAGE",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'1'"),
                    DataBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsId = table.Column<int>(type: "int", nullable: true),
                    BranchesId = table.Column<int>(type: "int", nullable: true),
                    ContactUsId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    SubServiceId = table.Column<int>(type: "int", nullable: true),
                    IsCover = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_IMAGE", x => x.ImagesId);
                    table.ForeignKey(
                        name: "BRANCH_FK",
                        column: x => x.BranchesId,
                        principalTable: "MOB_BRANCH",
                        principalColumn: "BranchesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "NEWS_FK",
                        column: x => x.NewsId,
                        principalTable: "MOB_NEWS",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PROJECT",
                        column: x => x.ProjectId,
                        principalTable: "MOB_PROJECT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SERVICE_FK",
                        column: x => x.ServiceId,
                        principalTable: "MOB_SERVICE",
                        principalColumn: "ServicesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SUB_SERVICE_FK",
                        column: x => x.SubServiceId,
                        principalTable: "MOB_SUB_SERVICE",
                        principalColumn: "SubServicesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_STAFF_SERVICE_ASSIGN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    SubServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_STAFF_SERVICE_ASSIGN", x => x.Id);
                    table.ForeignKey(
                        name: "S_SERVICE_FK",
                        column: x => x.SubServiceId,
                        principalTable: "MOB_SUB_SERVICE",
                        principalColumn: "SubServicesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "STAFF_FK",
                        column: x => x.StaffId,
                        principalTable: "MOB_OUR_TEAM",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOB_APPOINTMENT_DETAILES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    SubServiceId = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOB_APPOINTMENT_DETAILES", x => x.Id);
                    table.ForeignKey(
                        name: "APPOINTMENT_FK",
                        column: x => x.AppointmentId,
                        principalTable: "MOB_APPOINTMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SU_SERVICE_FK",
                        column: x => x.SubServiceId,
                        principalTable: "MOB_SUB_SERVICE",
                        principalColumn: "SubServicesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountLogins_UserId",
                table: "AccountLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_RoleId",
                table: "AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Accounts",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MerchantId",
                table: "Accounts",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Accounts",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "MERCHANT_FK",
                table: "MOB_ABOUT",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "B_FK_idx",
                table: "MOB_APPOINTMENT",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "CLIENT_APPOINTMENT_FK_idx",
                table: "MOB_APPOINTMENT",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "M_FK_idx",
                table: "MOB_APPOINTMENT",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "W_P_APPOINTMENT_idx",
                table: "MOB_APPOINTMENT",
                column: "WorkPlanId");

            migrationBuilder.CreateIndex(
                name: "APPOINTMENT_FK_idx",
                table: "MOB_APPOINTMENT_DETAILES",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "STAFF_FK_idx",
                table: "MOB_APPOINTMENT_DETAILES",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "SU_SERVICE_FK_idx",
                table: "MOB_APPOINTMENT_DETAILES",
                column: "SubServiceId");

            migrationBuilder.CreateIndex(
                name: "USER_FK",
                table: "MOB_BRANCH",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_ID_CONTACT",
                table: "MOB_CONTACT",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "USER_CONTACT_FK",
                table: "MOB_CONTACT",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_THEME",
                table: "MOB_GLOBAL_THEME",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "USER_THEME_FK",
                table: "MOB_GLOBAL_THEME",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_FK",
                table: "MOB_IMAGE",
                column: "BranchesId");

            migrationBuilder.CreateIndex(
                name: "NEWS_FK",
                table: "MOB_IMAGE",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "PROJECT",
                table: "MOB_IMAGE",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "SERVICE_FK",
                table: "MOB_IMAGE",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "SUB_SERVICE_FK",
                table: "MOB_IMAGE",
                column: "SubServiceId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_ID_NEWS",
                table: "MOB_NEWS",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "USER_NEWS_FK",
                table: "MOB_NEWS",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_ID_EMPLOYEE",
                table: "MOB_OUR_TEAM",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "MERCHANT_EMPLOYEE_FK",
                table: "MOB_OUR_TEAM",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_ID",
                table: "MOB_PROJECT",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "PROJECT_MERCHANT_FK",
                table: "MOB_PROJECT",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_ID_SERVICES",
                table: "MOB_SERVICE",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "SERVICE_MERCHANT_FK",
                table: "MOB_SERVICE",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "S_SERVICE_FK_idx",
                table: "MOB_STAFF_SERVICE_ASSIGN",
                column: "SubServiceId");

            migrationBuilder.CreateIndex(
                name: "STAFF_FK_idx1",
                table: "MOB_STAFF_SERVICE_ASSIGN",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "SERVICE_ID",
                table: "MOB_SUB_SERVICE",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "BRANCH_PLAN_FK_idx",
                table: "MOB_WORK_PLAN",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "MERCHANT_PLAN_FK_idx",
                table: "MOB_WORK_PLAN",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLogins");

            migrationBuilder.DropTable(
                name: "AccountRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MOB_ABOUT");

            migrationBuilder.DropTable(
                name: "MOB_APPOINTMENT_DETAILES");

            migrationBuilder.DropTable(
                name: "MOB_CONTACT");

            migrationBuilder.DropTable(
                name: "MOB_GALLERY");

            migrationBuilder.DropTable(
                name: "MOB_GLOBAL_THEME");

            migrationBuilder.DropTable(
                name: "MOB_IMAGE");

            migrationBuilder.DropTable(
                name: "MOB_SLIDERS");

            migrationBuilder.DropTable(
                name: "MOB_STAFF_SERVICE_ASSIGN");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "MOB_APPOINTMENT");

            migrationBuilder.DropTable(
                name: "MOB_NEWS");

            migrationBuilder.DropTable(
                name: "MOB_PROJECT");

            migrationBuilder.DropTable(
                name: "MOB_SUB_SERVICE");

            migrationBuilder.DropTable(
                name: "MOB_OUR_TEAM");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "MOB_WORK_PLAN");

            migrationBuilder.DropTable(
                name: "MOB_SERVICE");

            migrationBuilder.DropTable(
                name: "MOB_BRANCH");

            migrationBuilder.DropTable(
                name: "MOB_MERCHANT");
        }
    }
}

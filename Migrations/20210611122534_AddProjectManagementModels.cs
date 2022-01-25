using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meta.IntroApp.Migrations
{
    public partial class AddProjectManagementModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRJAddressType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJAddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJInvolvementLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJInvolvementLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJJobPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJJobPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJProjectCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJProjectCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJProjectRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJProjectRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJProjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJTAG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJTAG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJTaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJTaskStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRJContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    //ParentContactId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressTypeId = table.Column<int>(type: "int", nullable: true),
                    //JobPositionId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PRJContactsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJContacts_PRJAddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "PRJAddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRJContacts_PRJContacts_PRJContactsId",
                        column: x => x.PRJContactsId,
                        principalTable: "PRJContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    //table.ForeignKey(
                    //    name: "FK_PRJContacts_PRJJobPosition_JobPositionId",
                    //    column: x => x.JobPositionId,
                    //    principalTable: "PRJJobPosition",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRJProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    //ParentProjectId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectStatusId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PRJProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJProject_PRJProject_PRJProjectId",
                        column: x => x.PRJProjectId,
                        principalTable: "PRJProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJProject_PRJProjectCategory_ProjectCategoryId",
                        column: x => x.ProjectCategoryId,
                        principalTable: "PRJProjectCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRJProject_PRJProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "PRJProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRJProjectFollowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    //ContactId = table.Column<int>(type: "int", nullable: false),
                    //ProjectRoleId = table.Column<int>(type: "int", nullable: false),
                    //InvolvementLevelId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactsId = table.Column<int>(type: "int", nullable: true),
                    ProjectLevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJProjectFollowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJProjectFollowers_PRJContacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "PRJContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJProjectFollowers_PRJInvolvementLevel_ProjectLevelId",
                        column: x => x.ProjectLevelId,
                        principalTable: "PRJInvolvementLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJProjectFollowers_PRJProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PRJProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRJTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    //ParentTaskId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualFinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AssignToProjectRoleId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    IsMajor = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PRJTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJTask_PRJProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PRJProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRJTask_PRJTask_PRJTaskId",
                        column: x => x.PRJTaskId,
                        principalTable: "PRJTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRJProjectHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    //UserId = table.Column<int>(type: "int", nullable: false),
                    HistoryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectFollowerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJProjectHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJProjectHistory_PRJProjectFollowers_ProjectFollowerId",
                        column: x => x.ProjectFollowerId,
                        principalTable: "PRJProjectFollowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRJAttachements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJAttachements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJAttachements_PRJProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PRJProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJAttachements_PRJTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "PRJTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRJTaskFollower",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    //TaskId = table.Column<int>(type: "int", nullable: false),
                    //ContactId = table.Column<int>(type: "int", nullable: false),
                    ProjectRoleId = table.Column<int>(type: "int", nullable: false),
                    //InvolvementLevelId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactsId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    TaskLevelId = table.Column<int>(type: "int", nullable: true),
                    PRJTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJTaskFollower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJTaskFollower_PRJContacts_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "PRJContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJTaskFollower_PRJInvolvementLevel_TaskLevelId",
                        column: x => x.TaskLevelId,
                        principalTable: "PRJInvolvementLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJTaskFollower_PRJProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "PRJProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJTaskFollower_PRJTask_PRJTaskId",
                        column: x => x.PRJTaskId,
                        principalTable: "PRJTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PRJTaskHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    //TaskId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    //TaskFollowerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsArchive = table.Column<int>(type: "int", nullable: true),
                    ArchiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PRJTaskFollowerId = table.Column<int>(type: "int", nullable: true),
                    PRJTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRJTaskHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRJTaskHistory_PRJTask_PRJTaskId",
                        column: x => x.PRJTaskId,
                        principalTable: "PRJTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRJTaskHistory_PRJTaskFollower_PRJTaskFollowerId",
                        column: x => x.PRJTaskFollowerId,
                        principalTable: "PRJTaskFollower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRJAttachements_ProjectId",
                table: "PRJAttachements",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJAttachements_TaskId",
                table: "PRJAttachements",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_AddressTypeId",
                table: "PRJContacts",
                column: "AddressTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PRJContacts_JobPositionId",
            //    table: "PRJContacts",
            //    column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJContacts_PRJContactsId",
                table: "PRJContacts",
                column: "PRJContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProject_PRJProjectId",
                table: "PRJProject",
                column: "PRJProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProject_ProjectCategoryId",
                table: "PRJProject",
                column: "ProjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProject_ProjectStatusId",
                table: "PRJProject",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_ContactsId",
                table: "PRJProjectFollowers",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_ProjectId",
                table: "PRJProjectFollowers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectFollowers_ProjectLevelId",
                table: "PRJProjectFollowers",
                column: "ProjectLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJProjectHistory_ProjectFollowerId",
                table: "PRJProjectHistory",
                column: "ProjectFollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_PRJTaskId",
                table: "PRJTask",
                column: "PRJTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTask_ProjectId",
                table: "PRJTask",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskFollower_ContactsId",
                table: "PRJTaskFollower",
                column: "ContactsId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskFollower_PRJTaskId",
                table: "PRJTaskFollower",
                column: "PRJTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskFollower_ProjectId",
                table: "PRJTaskFollower",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskFollower_TaskLevelId",
                table: "PRJTaskFollower",
                column: "TaskLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskHistory_PRJTaskFollowerId",
                table: "PRJTaskHistory",
                column: "PRJTaskFollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_PRJTaskHistory_PRJTaskId",
                table: "PRJTaskHistory",
                column: "PRJTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRJAttachements");

            migrationBuilder.DropTable(
                name: "PRJProjectHistory");

            migrationBuilder.DropTable(
                name: "PRJProjectRole");

            migrationBuilder.DropTable(
                name: "PRJTAG");

            migrationBuilder.DropTable(
                name: "PRJTaskHistory");

            migrationBuilder.DropTable(
                name: "PRJTaskStatus");

            migrationBuilder.DropTable(
                name: "PRJProjectFollowers");

            migrationBuilder.DropTable(
                name: "PRJTaskFollower");

            migrationBuilder.DropTable(
                name: "PRJContacts");

            migrationBuilder.DropTable(
                name: "PRJInvolvementLevel");

            migrationBuilder.DropTable(
                name: "PRJTask");

            migrationBuilder.DropTable(
                name: "PRJAddressType");

            migrationBuilder.DropTable(
                name: "PRJJobPosition");

            migrationBuilder.DropTable(
                name: "PRJProject");

            migrationBuilder.DropTable(
                name: "PRJProjectCategory");

            migrationBuilder.DropTable(
                name: "PRJProjectStatus");
        }
    }
}

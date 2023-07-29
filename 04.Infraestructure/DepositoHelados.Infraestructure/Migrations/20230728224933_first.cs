using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepositoHelados.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archive",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PathName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MdTypeArchiveId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Ruc = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FiscalAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArchiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Archive_ArchiveId",
                        column: x => x.ArchiveId,
                        principalTable: "Archive",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FiscalAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campus_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CategoryParentId = table.Column<int>(type: "int", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_CategoryParentId",
                        column: x => x.CategoryParentId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Category_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Master",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Master_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonRoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HashType = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AdditionalOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdditionalTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterDetail_Master_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuRole_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentityDocument = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MdIdentityDocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_MasterDetail_MdIdentityDocumentTypeId",
                        column: x => x.MdIdentityDocumentTypeId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MdBrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_MasterDetail_MdBrandId",
                        column: x => x.MdBrandId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    TokenExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RefreshTokenExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MdPostalCodeId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ReferenceAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAddress_MasterDetail_MdPostalCodeId",
                        column: x => x.MdPostalCodeId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAddress_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    UniqueCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRole_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonRole_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductArchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductArchive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductArchive_Archive_ArchiveId",
                        column: x => x.ArchiveId,
                        principalTable: "Archive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductArchive_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFlavor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MdFlavorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArchiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFlavor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFlavor_Archive_ArchiveId",
                        column: x => x.ArchiveId,
                        principalTable: "Archive",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductFlavor_MasterDetail_MdFlavorId",
                        column: x => x.MdFlavorId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductFlavor_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MdUnitMeasurementId = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: false),
                    SalePrice = table.Column<decimal>(type: "money", nullable: false),
                    PublicPrice = table.Column<decimal>(type: "money", nullable: false),
                    EmployeePrice = table.Column<decimal>(type: "money", nullable: false),
                    OtherPriceOne = table.Column<decimal>(type: "money", nullable: false),
                    OtherPriceTwo = table.Column<decimal>(type: "money", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrice_MasterDetail_MdUnitMeasurementId",
                        column: x => x.MdUnitMeasurementId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProductOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRoleId = table.Column<int>(type: "int", nullable: false),
                    DateProductOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProductOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProductOrder_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeProductOrder_PersonRole_PersonRoleId",
                        column: x => x.PersonRoleId,
                        principalTable: "PersonRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonRoleId = table.Column<int>(type: "int", nullable: false),
                    MdOrderTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MdStatusId = table.Column<int>(type: "int", nullable: false),
                    CampusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_MasterDetail_MdOrderTypeId",
                        column: x => x.MdOrderTypeId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_MasterDetail_MdStatusId",
                        column: x => x.MdStatusId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_PersonRole_PersonRoleId",
                        column: x => x.PersonRoleId,
                        principalTable: "PersonRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProductOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeProductOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MdUnitMeasurementId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "money", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProductOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProductOrderDetail_EmployeeProductOrder_EmployeeProductOrderId",
                        column: x => x.EmployeeProductOrderId,
                        principalTable: "EmployeeProductOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeProductOrderDetail_MasterDetail_MdUnitMeasurementId",
                        column: x => x.MdUnitMeasurementId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeProductOrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderAdvanceAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAdvanceAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAdvanceAmount_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MdUnitMeasurementId = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<decimal>(type: "money", nullable: false),
                    DevolutionQuantity = table.Column<decimal>(type: "money", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "money", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "system"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "system"),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_MasterDetail_MdUnitMeasurementId",
                        column: x => x.MdUnitMeasurementId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAmountAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRoleId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MdStatusId = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAmountAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAmountAccount_MasterDetail_MdStatusId",
                        column: x => x.MdStatusId,
                        principalTable: "MasterDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAmountAccount_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonAmountAccount_PersonRole_PersonRoleId",
                        column: x => x.PersonRoleId,
                        principalTable: "PersonRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archive_CompanyId",
                table: "Archive",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_MdTypeArchiveId",
                table: "Archive",
                column: "MdTypeArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_CompanyId",
                table: "Campus",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryParentId",
                table: "Category",
                column: "CategoryParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CompanyId",
                table: "Category",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ArchiveId",
                table: "Company",
                column: "ArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProductOrder_CampusId",
                table: "EmployeeProductOrder",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProductOrder_PersonRoleId",
                table: "EmployeeProductOrder",
                column: "PersonRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProductOrderDetail_EmployeeProductOrderId",
                table: "EmployeeProductOrderDetail",
                column: "EmployeeProductOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProductOrderDetail_MdUnitMeasurementId",
                table: "EmployeeProductOrderDetail",
                column: "MdUnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProductOrderDetail_ProductId",
                table: "EmployeeProductOrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Master_CompanyId",
                table: "Master",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDetail_MasterId",
                table: "MasterDetail",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_CompanyId",
                table: "Menu",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRole_MenuId",
                table: "MenuRole",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRole_RoleId",
                table: "MenuRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CampusId",
                table: "Order",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MdOrderTypeId",
                table: "Order",
                column: "MdOrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MdStatusId",
                table: "Order",
                column: "MdStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PersonRoleId",
                table: "Order",
                column: "PersonRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAdvanceAmount_OrderId",
                table: "OrderAdvanceAmount",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_MdUnitMeasurementId",
                table: "OrderDetail",
                column: "MdUnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CompanyId",
                table: "Person",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_MdIdentityDocumentTypeId",
                table: "Person",
                column: "MdIdentityDocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_MdPostalCodeId",
                table: "PersonAddress",
                column: "MdPostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddress_PersonId",
                table: "PersonAddress",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAmountAccount_MdStatusId",
                table: "PersonAmountAccount",
                column: "MdStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAmountAccount_OrderId",
                table: "PersonAmountAccount",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAmountAccount_PersonRoleId",
                table: "PersonAmountAccount",
                column: "PersonRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_CampusId",
                table: "PersonRole",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_PersonId",
                table: "PersonRole",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRole_RoleId",
                table: "PersonRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyId",
                table: "Product",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MdBrandId",
                table: "Product",
                column: "MdBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductArchive_ArchiveId",
                table: "ProductArchive",
                column: "ArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductArchive_ProductId",
                table: "ProductArchive",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFlavor_ArchiveId",
                table: "ProductFlavor",
                column: "ArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFlavor_MdFlavorId",
                table: "ProductFlavor",
                column: "MdFlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFlavor_ProductId",
                table: "ProductFlavor",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_MdUnitMeasurementId",
                table: "ProductPrice",
                column: "MdUnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CompanyId",
                table: "Role",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_CampusId",
                table: "UserRole",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserRoleId",
                table: "UserToken",
                column: "UserRoleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Archive_Company_CompanyId",
                table: "Archive",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Archive_MasterDetail_MdTypeArchiveId",
                table: "Archive",
                column: "MdTypeArchiveId",
                principalTable: "MasterDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archive_Company_CompanyId",
                table: "Archive");

            migrationBuilder.DropForeignKey(
                name: "FK_Master_Company_CompanyId",
                table: "Master");

            migrationBuilder.DropTable(
                name: "EmployeeProductOrderDetail");

            migrationBuilder.DropTable(
                name: "MenuRole");

            migrationBuilder.DropTable(
                name: "OrderAdvanceAmount");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropTable(
                name: "PersonAmountAccount");

            migrationBuilder.DropTable(
                name: "ProductArchive");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductFlavor");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "EmployeeProductOrder");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Archive");

            migrationBuilder.DropTable(
                name: "MasterDetail");

            migrationBuilder.DropTable(
                name: "Master");
        }
    }
}

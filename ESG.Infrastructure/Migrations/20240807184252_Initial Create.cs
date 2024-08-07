using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsoCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimentionTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsHeirarchialDimention = table.Column<bool>(type: "boolean", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimentionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimentionTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimentionTypes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationUsers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasureTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dimentions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    DimentionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsHeirarchialDimention = table.Column<bool>(type: "boolean", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dimentions_DimentionTypes_DimentionTypeId",
                        column: x => x.DimentionTypeId,
                        principalTable: "DimentionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dimentions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dimentions_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false),
                    SecurityStamp = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PasswordExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrganizationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_OrganizationUsers_OrganizationUserId",
                        column: x => x.OrganizationUserId,
                        principalTable: "OrganizationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfMeasureTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => new { x.Id, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_UnitOfMeasureTypes_UnitOfMeasureTypeId",
                        column: x => x.UnitOfMeasureTypeId,
                        principalTable: "UnitOfMeasureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPointTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    DimentionId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPointTypes_Dimentions_DimentionId",
                        column: x => x.DimentionId,
                        principalTable: "Dimentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointTypes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPointValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsUOM = table.Column<bool>(type: "boolean", nullable: false),
                    IsCurrency = table.Column<bool>(type: "boolean", nullable: false),
                    IsNarrative = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPointValues_DataPointTypes_DatapointTypeId",
                        column: x => x.DatapointTypeId,
                        principalTable: "DataPointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointValues_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointValues_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "CurrencyCode", "LongText", "Name", "ShortText" },
                values: new object[,]
                {
                    { 1L, "USD", "United States Dollar", "US Dollar", "USD" },
                    { 2L, "EUR", "Euro", "Euro", "EUR" },
                    { 3L, "INR", "Indian Rupee", "Indian Rupee", "INR" },
                    { 4L, "GBP", "British Pound Sterling", "British Pound", "GBP" },
                    { 5L, "CAD", "Canadian Dollar", "Canadian Dollar", "CAD" },
                    { 6L, "AUD", "Australian Dollar", "Australian Dollar", "AUD" },
                    { 7L, "JPY", "Japanese Yen", "Japanese Yen", "JPY" },
                    { 8L, "CHF", "Swiss Franc", "Swiss Franc", "CHF" },
                    { 9L, "CNY", "Chinese Yuan Renminbi", "Chinese Yuan", "CNY" },
                    { 10L, "RUB", "Russian Ruble", "Russian Ruble", "RUB" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsoCode", "Name" },
                values: new object[,]
                {
                    { 1L, "ru", "Russian" },
                    { 2L, "uk", "Ukrainian" },
                    { 3L, "be", "Belarusian" },
                    { 4L, "et", "Estonian" },
                    { 5L, "lv", "Latvian" },
                    { 6L, "lt", "Lithuanian" },
                    { 7L, "ka", "Georgian" },
                    { 8L, "hy", "Armenian" },
                    { 9L, "az", "Azerbaijani" },
                    { 10L, "kk", "Kazakh" },
                    { 11L, "uz", "Uzbek" },
                    { 12L, "tk", "Turkmen" },
                    { 13L, "tg", "Tajik" },
                    { 14L, "ky", "Kyrgyz" },
                    { 15L, "mo", "Moldovan" },
                    { 16L, "tt", "Tatar" },
                    { 17L, "ba", "Bashkir" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "AdminEE" },
                    { 2L, "ClientAdmin" },
                    { 3L, "User" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "ESG" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Active", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastLogin", "LastModifiedBy", "LastModifiedDate", "LastName", "LockoutEnabled", "OrganizationUserId", "Password", "PasswordExpiry", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[,]
                {
                    { 1L, 0, true, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5005), "user1@example.com", true, "John", false, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4991), null, null, "Doe", false, null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 49 }, new DateTime(2024, 11, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4992), "1234567890", true, new Guid("92c1058e-b417-4331-9914-74771c25905b") },
                    { 2L, 0, true, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5016), "user2@example.com", true, "Jane", false, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5013), null, null, "Smith", false, null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 50 }, new DateTime(2024, 11, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5014), "0987654321", true, new Guid("a8553d2b-c400-4501-b49c-b7049f4e4c52") },
                    { 3L, 0, true, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5023), "user3@example.com", true, "Alice", false, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5021), null, null, "Johnson", false, null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 51 }, new DateTime(2024, 11, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5022), "2345678901", true, new Guid("2d573e37-1902-4bfd-875f-20bedc609d55") }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name", "TenantId" },
                values: new object[] { 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "ESGOrganization", 1L });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5110), false, null, null, 1L, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5113), false, null, null, 2L, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5114), false, null, null, 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "DimentionTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "IsHeirarchialDimention", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4667), false, true, 1L, null, null, "Dimension Type 1", "DimensionType1", 1L, "DT1" },
                    { 2L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4670), false, false, 1L, null, null, "Dimension Type 2", "DimensionType2", 1L, "DT2" },
                    { 3L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4673), false, true, 1L, null, null, "Dimension Type 3", "DimensionType3", 1L, "DT3" },
                    { 4L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4675), false, true, 1L, null, null, "Dimension Type 4", "DimensionType4", 1L, "DT4" },
                    { 5L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4678), false, true, 1L, null, null, "Dimension Type 5", "DimensionType5", 1L, "DT5" },
                    { 6L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4680), false, false, 1L, null, null, "Dimension Type 6", "DimensionType6", 1L, "DT6" },
                    { 7L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4683), false, true, 1L, null, null, "Dimension Type 7", "DimensionType7", 1L, "DT7" },
                    { 8L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4685), false, false, 1L, null, null, "Dimension Type 8", "DimensionType8", 1L, "DT8" },
                    { 9L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4688), false, true, 1L, null, null, "Dimension Type 9", "DimensionType9", 1L, "DT9" },
                    { 10L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4690), false, false, 1L, null, null, "Dimension Type 10", "DimensionType10", 1L, "DT10" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5050), false, null, null, 1L, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5053), false, null, null, 1L, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(5054), false, null, null, 1L, 3L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4799), false, 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4800), "Kilogram", 1L },
                    { 2L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4813), false, 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4813), "Gram", 1L },
                    { 3L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4816), false, 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4817), "Liter", 1L }
                });

            migrationBuilder.InsertData(
                table: "Dimentions",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DimentionTypeId", "IsDeleted", "IsHeirarchialDimention", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4606), 1L, false, true, 1L, null, null, "Dimension 1", "Dimension1", 1L, "D1" },
                    { 2L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4609), 1L, false, true, 1L, null, null, "Dimension 2", "Dimension2", 1L, "D2" },
                    { 3L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4612), 2L, false, false, 1L, null, null, "Dimension 3", "Dimension3", 1L, "D3" },
                    { 4L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4614), 2L, false, false, 1L, null, null, "Dimension 4", "Dimension4", 1L, "D4" },
                    { 5L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4617), 2L, false, true, 1L, null, null, "Dimension 5", "Dimension5", 1L, "D5" },
                    { 6L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4620), 3L, false, true, 1L, null, null, "Dimension 6", "Dimension6", 1L, "D6" },
                    { 7L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4622), 3L, false, true, 1L, null, null, "Dimension 7", "Dimension7", 1L, "D7" },
                    { 8L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4625), 4L, false, true, 1L, null, null, "Dimension 8", "Dimension8", 1L, "D8" },
                    { 9L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4628), 4L, false, true, 1L, null, null, "Dimension 9", "Dimension9", 1L, "D9" },
                    { 10L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4630), 4L, false, true, 1L, null, null, "Dimension 10", "Dimension10", 1L, "D10" }
                });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DimentionId", "IsDeleted", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4437), 1L, false, 1L, null, null, "Type 1", "DatapointType1", 1L, "T1" },
                    { 2L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4441), 1L, false, 1L, null, null, "Type 2", "DatapointType2", 1L, "T2" },
                    { 3L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4444), 1L, false, 1L, null, null, "Type 3", "DatapointType3", 1L, "T3" },
                    { 5L, 0L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4447), 2L, false, 1L, null, null, "Type 5", "DatapointType5", 1L, "T5" },
                    { 6L, 0L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4475), 2L, false, 1L, null, null, "Type 6", "DatapointType6", 1L, "T6" },
                    { 7L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4479), 2L, false, 1L, null, null, "Type 7", "DatapointType7", 1L, "T7" },
                    { 8L, 0L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4482), 3L, false, 1L, null, null, "Type 8", "DatapointType8", 1L, "T8" },
                    { 9L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4484), 3L, false, 1L, null, null, "Type 9", "DatapointType9", 1L, "T9" },
                    { 10L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4487), 3L, false, 1L, null, null, "Type 10", "DatapointType10", 1L, "T10" }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DatapointTypeId", "IsCurrency", "IsDeleted", "IsNarrative", "IsUOM", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "OrganizationId", "Purpose", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4535), 1L, true, false, false, false, 1L, null, null, "DataPointValue1", 1L, "Purpose 1", "Value 1" },
                    { 2L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4540), 1L, false, false, false, true, 1L, null, null, "DataPointValue2", 1L, "Purpose 2", "Value 2" },
                    { 3L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4544), 1L, true, false, false, false, 1L, null, null, "DataPointValue3", 1L, "Purpose 3", "Value 3" },
                    { 4L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4547), 1L, false, false, true, false, 1L, null, null, "DataPointValue4", 1L, "Purpose 4", "Value 4" },
                    { 5L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4550), 1L, true, false, false, false, 1L, null, null, "DataPointValue5", 1L, "Purpose 5", "Value 5" },
                    { 6L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4553), 1L, false, false, false, true, 1L, null, null, "DataPointValue6", 1L, "Purpose 6", "Value 6" },
                    { 7L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4556), 1L, true, false, false, false, 2L, null, null, "DataPointValue7", 1L, "Purpose 7", "Value 7" },
                    { 8L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4559), 1L, false, false, true, false, 2L, null, null, "DataPointValue8", 1L, "Purpose 8", "Value 8" },
                    { 9L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4562), 1L, true, false, false, false, 2L, null, null, "DataPointValue9", 1L, "Purpose 9", "Value 9" },
                    { 10L, 1L, new DateTime(2024, 8, 7, 18, 42, 51, 886, DateTimeKind.Utc).AddTicks(4565), 1L, false, false, false, true, 2L, null, null, "DataPointValue10", 1L, "Purpose 10", "Value 10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_DimentionId",
                table: "DataPointTypes",
                column: "DimentionId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_LanguageId",
                table: "DataPointTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_OrganizationId",
                table: "DataPointTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_DatapointTypeId",
                table: "DataPointValues",
                column: "DatapointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_LanguageId",
                table: "DataPointValues",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_OrganizationId",
                table: "DataPointValues",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimentions_DimentionTypeId",
                table: "Dimentions",
                column: "DimentionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimentions_LanguageId",
                table: "Dimentions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimentions_OrganizationId",
                table: "Dimentions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DimentionTypes_LanguageId",
                table: "DimentionTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DimentionTypes_OrganizationId",
                table: "DimentionTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_TenantId",
                table: "Organizations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_OrganizationId",
                table: "OrganizationUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_LanguageId",
                table: "UnitOfMeasures",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_OrganizationId",
                table: "UnitOfMeasures",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_UnitOfMeasureTypeId",
                table: "UnitOfMeasures",
                column: "UnitOfMeasureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTypes_LanguageId",
                table: "UnitOfMeasureTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTypes_OrganizationId",
                table: "UnitOfMeasureTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationUserId",
                table: "Users",
                column: "OrganizationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DataPointValues");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "DataPointTypes");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dimentions");

            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "DimentionTypes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}

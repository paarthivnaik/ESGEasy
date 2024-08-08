using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IniialCode : Migration
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
                    RegistrationId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LatsName = table.Column<string>(type: "text", nullable: true),
                    StreetAddress = table.Column<string>(type: "text", nullable: true),
                    StreetNumber = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    TenantId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPointTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointTypes", x => new { x.Id, x.OrganizationId });
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
                name: "DimensionTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsHeirarchialDimention = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionTypes", x => new { x.Id, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_DimensionTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTypes_Organizations_OrganizationId",
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
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
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
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureTypes", x => new { x.Id, x.OrganizationId });
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
                name: "DataPointValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsUOM = table.Column<bool>(type: "boolean", nullable: false),
                    IsCurrency = table.Column<bool>(type: "boolean", nullable: false),
                    IsNarrative = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointValues", x => new { x.Id, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_DataPointValues_DataPointTypes_DatapointTypeId_Organization~",
                        columns: x => new { x.DatapointTypeId, x.OrganizationId },
                        principalTable: "DataPointTypes",
                        principalColumns: new[] { "Id", "OrganizationId" },
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

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsHeirarchialDimention = table.Column<bool>(type: "boolean", nullable: false),
                    DimentionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => new { x.Id, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_Dimensions_DimensionTypes_DimentionTypeId_OrganizationId",
                        columns: x => new { x.DimentionTypeId, x.OrganizationId },
                        principalTable: "DimensionTypes",
                        principalColumns: new[] { "Id", "OrganizationId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dimensions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dimensions_Organizations_OrganizationId",
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
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false),
                    SecurityStamp = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
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
                        name: "FK_UnitOfMeasures_UnitOfMeasureTypes_UnitOfMeasureTypeId_Organ~",
                        columns: x => new { x.UnitOfMeasureTypeId, x.OrganizationId },
                        principalTable: "UnitOfMeasureTypes",
                        principalColumns: new[] { "Id", "OrganizationId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatapointModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    DatapointId = table.Column<long>(type: "bigint", nullable: false),
                    DimentionsId = table.Column<long>(type: "bigint", nullable: false),
                    SortingType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatapointModel", x => new { x.Id, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_DatapointModel_DataPointTypes_DatapointId_OrganizationId",
                        columns: x => new { x.DatapointId, x.OrganizationId },
                        principalTable: "DataPointTypes",
                        principalColumns: new[] { "Id", "OrganizationId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointModel_Dimensions_DimentionsId_OrganizationId",
                        columns: x => new { x.DimentionsId, x.OrganizationId },
                        principalTable: "Dimensions",
                        principalColumns: new[] { "Id", "OrganizationId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointModel_Organizations_OrganizationId",
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
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
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
                table: "Organizations",
                columns: new[] { "Id", "Country", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LatsName", "LogoUrl", "Name", "PostalCode", "RegistrationId", "StreetAddress", "StreetNumber", "TenantId" },
                values: new object[] { 1L, "USA", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@org1.com", "John", false, 1L, null, null, "Doe", null, "ESG Organization", "12345", "REG-001", "123 Main St", "456", 1L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "OrganizationUserId", "Password", "PhoneNumber", "SecurityStamp" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8016), "user1@example.com", "John", false, 1L, null, null, "Doe", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 49 }, "1234567890", new Guid("a7cfc01e-48a0-4a4e-9ac4-da300f5a2e07") },
                    { 2L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8021), "user2@example.com", "Jane", false, 1L, null, null, "Smith", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 50 }, "0987654321", new Guid("9e53ac2d-d1e7-4671-a59c-25d60dbe415b") },
                    { 3L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8024), "user3@example.com", "Alice", false, 1L, null, null, "Johnson", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 51 }, "2345678901", new Guid("50d6182f-d882-4e0d-a3db-fb16f0cf8d3d") }
                });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "IsActive", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7709), false, 1L, null, null, "Type 1", "DatapointType1", "T1" },
                    { 2L, 1L, 2L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7712), false, 2L, null, null, "Type 2", "DatapointType2", "T2" },
                    { 3L, 1L, 3L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7714), false, 3L, null, null, "Type 3", "DatapointType3", "T3" },
                    { 5L, 1L, 0L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7715), false, 1L, null, null, "Type 5", "DatapointType5", "T5" },
                    { 6L, 1L, 0L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7717), false, 1L, null, null, "Type 6", "DatapointType6", "T6" },
                    { 7L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7719), false, 1L, null, null, "Type 7", "DatapointType7", "T7" },
                    { 8L, 1L, 0L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7720), false, 1L, null, null, "Type 8", "DatapointType8", "T8" },
                    { 9L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7722), false, 1L, null, null, "Type 9", "DatapointType9", "T9" },
                    { 10L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7723), false, 1L, null, null, "Type 10", "DatapointType10", "T10" }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "IsActive", "IsHeirarchialDimention", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[,]
                {
                    { 50L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7827), false, true, 1L, null, null, "Dimension Type 1", "DimensionType1", "DT1" },
                    { 51L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7830), false, false, 1L, null, null, "Dimension Type 2", "DimensionType2", "DT2" },
                    { 52L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7832), false, true, 1L, null, null, "Dimension Type 3", "DimensionType3", "DT3" },
                    { 53L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7834), false, true, 1L, null, null, "Dimension Type 4", "DimensionType4", "DT4" },
                    { 54L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7835), false, true, 1L, null, null, "Dimension Type 5", "DimensionType5", "DT5" },
                    { 55L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7837), false, false, 1L, null, null, "Dimension Type 6", "DimensionType6", "DT6" },
                    { 56L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7839), false, true, 1L, null, null, "Dimension Type 7", "DimensionType7", "DT7" },
                    { 57L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7840), false, false, 1L, null, null, "Dimension Type 8", "DimensionType8", "DT8" },
                    { 58L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7842), false, true, 1L, null, null, "Dimension Type 9", "DimensionType9", "DT9" },
                    { 59L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7844), false, false, 1L, null, null, "Dimension Type 10", "DimensionType10", "DT10" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8039), false, null, null, 1L, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8041), false, null, null, 1L, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8042), false, null, null, 1L, 3L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "IsActive", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7908), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7908), "Speed" },
                    { 2L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7917), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7917), "Weight" },
                    { 3L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7919), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7919), "Amount" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "LastModifiedBy", "LastModifiedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8109), false, null, null, 1L, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8110), false, null, null, 2L, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(8111), false, null, null, 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "DatapointTypeId", "IsActive", "IsCurrency", "IsNarrative", "IsUOM", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "Purpose", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7746), 1L, false, true, false, false, 1L, null, null, "DataPointValue1", "Purpose 1", "Value 1" },
                    { 2L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7749), 1L, false, false, false, true, 1L, null, null, "DataPointValue2", "Purpose 2", "Value 2" },
                    { 3L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7751), 1L, false, true, false, false, 1L, null, null, "DataPointValue3", "Purpose 3", "Value 3" },
                    { 4L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7753), 1L, false, false, true, false, 1L, null, null, "DataPointValue4", "Purpose 4", "Value 4" },
                    { 5L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7755), 1L, false, true, false, false, 1L, null, null, "DataPointValue5", "Purpose 5", "Value 5" },
                    { 6L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7757), 1L, false, false, false, true, 1L, null, null, "DataPointValue6", "Purpose 6", "Value 6" },
                    { 7L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7797), 1L, false, true, false, false, 2L, null, null, "DataPointValue7", "Purpose 7", "Value 7" },
                    { 8L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7799), 1L, false, false, true, false, 2L, null, null, "DataPointValue8", "Purpose 8", "Value 8" },
                    { 9L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7801), 1L, false, true, false, false, 2L, null, null, "DataPointValue9", "Purpose 9", "Value 9" },
                    { 10L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7803), 1L, false, false, false, true, 2L, null, null, "DataPointValue10", "Purpose 10", "Value 10" }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "DimentionTypeId", "IsActive", "IsHeirarchialDimention", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[,]
                {
                    { 100L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50L, false, true, 1L, null, null, "Long Description 1", "Dimension 1", "Short 1" },
                    { 101L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50L, false, true, 1L, null, null, "Long Description 2", "Dimension 2", "Short 2" },
                    { 102L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51L, false, true, 1L, null, null, "Long Description 3", "Dimension 3", "Short 3" }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "IsActive", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 4L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7935), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7936), "Kilogram", "kg", 2L },
                    { 5L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7938), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7939), "Gram", "gm", 2L },
                    { 6L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7940), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7941), "milliliter", "ml", 3L },
                    { 7L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7943), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7943), "meterpersecond", "m/s", 1L },
                    { 8L, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7945), false, 1L, 1L, new DateTime(2024, 8, 8, 10, 18, 7, 739, DateTimeKind.Utc).AddTicks(7945), "kmperhour", "kmph", 1L }
                });

            migrationBuilder.InsertData(
                table: "DatapointModel",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "DatapointId", "DimentionsId", "IsActive", "LastModifiedBy", "LastModifiedDate", "SortingType" },
                values: new object[,]
                {
                    { 10L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 100L, false, null, null, 0 },
                    { 11L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 101L, false, null, null, 1 },
                    { 12L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 102L, false, null, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatapointModel_DatapointId_OrganizationId",
                table: "DatapointModel",
                columns: new[] { "DatapointId", "OrganizationId" });

            migrationBuilder.CreateIndex(
                name: "IX_DatapointModel_DimentionsId_OrganizationId",
                table: "DatapointModel",
                columns: new[] { "DimentionsId", "OrganizationId" });

            migrationBuilder.CreateIndex(
                name: "IX_DatapointModel_OrganizationId",
                table: "DatapointModel",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_LanguageId",
                table: "DataPointTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_OrganizationId",
                table: "DataPointTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_DatapointTypeId_OrganizationId",
                table: "DataPointValues",
                columns: new[] { "DatapointTypeId", "OrganizationId" });

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_LanguageId",
                table: "DataPointValues",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_OrganizationId",
                table: "DataPointValues",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DimentionTypeId_OrganizationId",
                table: "Dimensions",
                columns: new[] { "DimentionTypeId", "OrganizationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_LanguageId",
                table: "Dimensions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_OrganizationId",
                table: "Dimensions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTypes_LanguageId",
                table: "DimensionTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTypes_OrganizationId",
                table: "DimensionTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_LanguageId",
                table: "Organizations",
                column: "LanguageId");

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
                name: "IX_UnitOfMeasures_UnitOfMeasureTypeId_OrganizationId",
                table: "UnitOfMeasures",
                columns: new[] { "UnitOfMeasureTypeId", "OrganizationId" });

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
                name: "IX_Users_LanguageId",
                table: "Users",
                column: "LanguageId");

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
                name: "DatapointModel");

            migrationBuilder.DropTable(
                name: "DataPointValues");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "DataPointTypes");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DimensionTypes");

            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}

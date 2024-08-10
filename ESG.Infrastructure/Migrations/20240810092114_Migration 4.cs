using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
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
                name: "UnitOfMeasureTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
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
                    State = table.Column<int>(type: "integer", nullable: false),
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
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    UnitOfMeasureTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => x.Id);
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
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsHeirarchialDimention = table.Column<bool>(type: "boolean", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
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
                    State = table.Column<int>(type: "integer", nullable: false),
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
                name: "UnitOfMeasureTranslations",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId1 = table.Column<long>(type: "bigint", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureTranslations", x => new { x.UnitOfMeasureId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTranslations_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPointValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsUOM = table.Column<bool>(type: "boolean", nullable: false),
                    IsCurrency = table.Column<bool>(type: "boolean", nullable: false),
                    IsNarrative = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsHeirarchialDimention = table.Column<bool>(type: "boolean", nullable: false),
                    DimentionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
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
                    State = table.Column<int>(type: "integer", nullable: false),
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
                name: "DatapointModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    DatapointId = table.Column<long>(type: "bigint", nullable: false),
                    DimentionsId = table.Column<long>(type: "bigint", nullable: false),
                    SortingType = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
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
                    State = table.Column<int>(type: "integer", nullable: false),
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
                columns: new[] { "Id", "Country", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LatsName", "LogoUrl", "Name", "PostalCode", "RegistrationId", "State", "StreetAddress", "StreetNumber", "TenantId" },
                values: new object[] { 1L, "USA", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@org1.com", "John", 1L, null, null, "Doe", null, "ESG Organization", "12345", "REG-001", 0, "123 Main St", "456", 1L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "OrganizationUserId", "Password", "PhoneNumber", "SecurityStamp", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2252), "user1@example.com", "John", 1L, null, null, "Doe", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 49 }, "1234567890", new Guid("266c086a-d0ab-4acf-ae42-09e865641e91"), 0 },
                    { 2L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2256), "user2@example.com", "Jane", 1L, null, null, "Smith", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 50 }, "0987654321", new Guid("f08496af-6d99-41ac-979a-d667ce8bb802"), 0 },
                    { 3L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2259), "user3@example.com", "Alice", 1L, null, null, "Johnson", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 51 }, "2345678901", new Guid("0b4ed653-c161-4d57-9aa4-b3e2df4f68b2"), 0 }
                });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2004), 1L, null, null, "Type 1", "DatapointType1", "T1", 0 },
                    { 2L, 1L, 2L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2006), 2L, null, null, "Type 2", "DatapointType2", "T2", 0 },
                    { 3L, 1L, 3L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2008), 3L, null, null, "Type 3", "DatapointType3", "T3", 0 },
                    { 5L, 1L, 0L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2009), 1L, null, null, "Type 5", "DatapointType5", "T5", 0 },
                    { 6L, 1L, 0L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2010), 1L, null, null, "Type 6", "DatapointType6", "T6", 0 },
                    { 7L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2012), 1L, null, null, "Type 7", "DatapointType7", "T7", 0 },
                    { 8L, 1L, 0L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2013), 1L, null, null, "Type 8", "DatapointType8", "T8", 0 },
                    { 9L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2014), 1L, null, null, "Type 9", "DatapointType9", "T9", 0 },
                    { 10L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2016), 1L, null, null, "Type 10", "DatapointType10", "T10", 0 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "IsHeirarchialDimention", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 50L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2077), true, 1L, null, null, "Dimension Type 1", "DimensionType1", "DT1", 0 },
                    { 51L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2079), false, 1L, null, null, "Dimension Type 2", "DimensionType2", "DT2", 0 },
                    { 52L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2080), true, 1L, null, null, "Dimension Type 3", "DimensionType3", "DT3", 0 },
                    { 53L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2082), true, 1L, null, null, "Dimension Type 4", "DimensionType4", "DT4", 0 },
                    { 54L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2083), true, 1L, null, null, "Dimension Type 5", "DimensionType5", "DT5", 0 },
                    { 55L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2085), false, 1L, null, null, "Dimension Type 6", "DimensionType6", "DT6", 0 },
                    { 56L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2086), true, 1L, null, null, "Dimension Type 7", "DimensionType7", "DT7", 0 },
                    { 57L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2088), false, 1L, null, null, "Dimension Type 8", "DimensionType8", "DT8", 0 },
                    { 58L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2089), true, 1L, null, null, "Dimension Type 9", "DimensionType9", "DT9", 0 },
                    { 59L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2090), false, 1L, null, null, "Dimension Type 10", "DimensionType10", "DT10", 0 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2271), null, null, 1L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2272), null, null, 1L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2273), null, null, 1L, 0, 3L }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2308), null, null, 1L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2309), null, null, 2L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2310), null, null, 3L, 0, 3L }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "DatapointTypeId", "IsCurrency", "IsNarrative", "IsUOM", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "Purpose", "State", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2038), 1L, true, false, false, 1L, null, null, "DataPointValue1", "Purpose 1", 0, "Value 1" },
                    { 2L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2041), 1L, false, false, true, 1L, null, null, "DataPointValue2", "Purpose 2", 0, "Value 2" },
                    { 3L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2043), 1L, true, false, false, 1L, null, null, "DataPointValue3", "Purpose 3", 0, "Value 3" },
                    { 4L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2045), 1L, false, true, false, 1L, null, null, "DataPointValue4", "Purpose 4", 0, "Value 4" },
                    { 5L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2047), 1L, true, false, false, 1L, null, null, "DataPointValue5", "Purpose 5", 0, "Value 5" },
                    { 6L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2048), 1L, false, false, true, 1L, null, null, "DataPointValue6", "Purpose 6", 0, "Value 6" },
                    { 7L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2050), 1L, true, false, false, 2L, null, null, "DataPointValue7", "Purpose 7", 0, "Value 7" },
                    { 8L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2052), 1L, false, true, false, 2L, null, null, "DataPointValue8", "Purpose 8", 0, "Value 8" },
                    { 9L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2053), 1L, true, false, false, 2L, null, null, "DataPointValue9", "Purpose 9", 0, "Value 9" },
                    { 10L, 1L, 1L, new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2055), 1L, false, false, true, 2L, null, null, "DataPointValue10", "Purpose 10", 0, "Value 10" }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "DimentionTypeId", "IsHeirarchialDimention", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 100L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50L, true, 1L, null, null, "Long Description 1", "Dimension 1", "Short 1", 0 },
                    { 101L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50L, true, 1L, null, null, "Long Description 2", "Dimension 2", "Short 2", 0 },
                    { 102L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51L, true, 1L, null, null, "Long Description 3", "Dimension 3", "Short 3", 0 }
                });

            migrationBuilder.InsertData(
                table: "DatapointModel",
                columns: new[] { "Id", "OrganizationId", "CreatedBy", "CreatedDate", "DatapointId", "DimentionsId", "LastModifiedBy", "LastModifiedDate", "SortingType", "State" },
                values: new object[,]
                {
                    { 10L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 100L, null, null, 0, 0 },
                    { 11L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 101L, null, null, 1, 0 },
                    { 12L, 1L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 102L, null, null, 2, 0 }
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
                name: "IX_UnitOfMeasures_UnitOfMeasureTypeId",
                table: "UnitOfMeasures",
                column: "UnitOfMeasureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTranslations_LanguageId",
                table: "UnitOfMeasureTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTranslations_LanguageId1",
                table: "UnitOfMeasureTranslations",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTypes_LanguageId",
                table: "UnitOfMeasureTypes",
                column: "LanguageId");

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
                name: "UnitOfMeasureTranslations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "DataPointTypes");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DimensionTypes");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypes");

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

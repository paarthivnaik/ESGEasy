using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OldValues = table.Column<string>(type: "text", nullable: true),
                    NewValues = table.Column<string>(type: "text", nullable: false),
                    AffectedColumns = table.Column<string>(type: "text", nullable: true),
                    PrimaryKey = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

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
                        name: "FK_Organizations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsoCode = table.Column<string>(type: "text", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
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
                name: "DataPointTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointTypes", x => x.Id);
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    isHierarchical = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionTypes", x => x.Id);
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
                name: "UnitOfMeasureTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypes_Organizations_OrganizationId",
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
                name: "DataPointValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    IsNarrative = table.Column<bool>(type: "boolean", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CurrencyId1 = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPointValues_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValues_Currency_CurrencyId1",
                        column: x => x.CurrencyId1,
                        principalTable: "Currency",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    isHierarchical = table.Column<bool>(type: "boolean", nullable: false),
                    DimensionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dimensions_DimensionTypes_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
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
                name: "DimensionTypeTranslations",
                columns: table => new
                {
                    DimensionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionTypeTranslations", x => new { x.DimensionTypeId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_DimensionTypeTranslations_DimensionTypes_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTypeTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
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
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "UnitOfMeasureTypeTranslations",
                columns: table => new
                {
                    UnitOfMeasureTypeId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureTypeTranslations", x => new { x.UnitOfMeasureTypeId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypeTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypeTranslations_UnitOfMeasureTypes_UnitOfMeas~",
                        column: x => x.UnitOfMeasureTypeId,
                        principalTable: "UnitOfMeasureTypes",
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

            migrationBuilder.CreateTable(
                name: "DatapointTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatapointTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatapointTypeTranslations_DataPointTypes_DatapointTypeId",
                        column: x => x.DatapointTypeId,
                        principalTable: "DataPointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointTypeTranslations_DataPointValues_DatapointTypeId",
                        column: x => x.DatapointTypeId,
                        principalTable: "DataPointValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointTypeTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatapointValueTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DatapointValueId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_DatapointValueTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatapointValueTranslations_DataPointValues_DatapointValueId",
                        column: x => x.DatapointValueId,
                        principalTable: "DataPointValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointValueTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatapointModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DatapointId = table.Column<long>(type: "bigint", nullable: false),
                    DimentionsId = table.Column<long>(type: "bigint", nullable: false),
                    SortingType = table.Column<int>(type: "integer", nullable: false),
                    DataPointTypesId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatapointModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatapointModel_DataPointTypes_DataPointTypesId",
                        column: x => x.DataPointTypesId,
                        principalTable: "DataPointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointModel_Dimensions_DimentionsId",
                        column: x => x.DimentionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DimensionTranslations",
                columns: table => new
                {
                    DimensionsId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionTranslations", x => new { x.DimensionsId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_DimensionTranslations_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NodeId = table.Column<long>(type: "bigint", nullable: true),
                    DimensionId = table.Column<long>(type: "bigint", nullable: true),
                    DataPointValuesId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchy_DataPointValues_DataPointValuesId",
                        column: x => x.DataPointValuesId,
                        principalTable: "DataPointValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hierarchy_Dimensions_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimensions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasureTranslations",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        name: "FK_UnitOfMeasureTranslations_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
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
                columns: new[] { "Id", "IsoCode", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1L, "en", "English", null },
                    { 2L, "fr", "French", null },
                    { 3L, "be", "Belarusian", null },
                    { 4L, "et", "Estonian", null },
                    { 5L, "lv", "Latvian", null },
                    { 6L, "lt", "Lithuanian", null },
                    { 7L, "ka", "Georgian", null },
                    { 8L, "hy", "Armenian", null },
                    { 9L, "az", "Azerbaijani", null },
                    { 10L, "kk", "Kazakh", null },
                    { 11L, "uz", "Uzbek", null },
                    { 12L, "tk", "Turkmen", null },
                    { 13L, "tg", "Tajik", null },
                    { 14L, "ky", "Kyrgyz", null },
                    { 15L, "mo", "Moldovan", null },
                    { 16L, "tt", "Tatar", null },
                    { 17L, "ba", "Bashkir", null }
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
                values: new object[] { 1L, "ESG Global" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Country", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LatsName", "LogoUrl", "Name", "PostalCode", "RegistrationId", "State", "StreetAddress", "StreetNumber", "TenantId" },
                values: new object[] { 1L, "USA", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@org1.com", "John", 1L, null, null, "Doe", null, "ESG Global", "12345", "REG-001", 1, "123 Main St", "456", 1L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "OrganizationUserId", "Password", "PhoneNumber", "SecurityStamp", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(1928), "user1@example.com", "John", 1L, null, null, "Doe", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 49 }, "1234567890", new Guid("26a697e1-99fc-4b7a-ab11-768d2a375917"), 1 },
                    { 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(1935), "user2@example.com", "Jane", 1L, null, null, "Smith", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 50 }, "0987654321", new Guid("71949c43-005a-4aa1-81fb-3f473a6a6484"), 1 },
                    { 3L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(1939), "user3@example.com", "Alice", 1L, null, null, "Johnson", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 51 }, "2345678901", new Guid("c81b46ff-eddd-40df-9f5a-e8146f4d03a1"), 1 }
                });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "text", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2835), 1L, null, null, "table", "Table", 1L, "table", 1 },
                    { 2L, "narrative", 2L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2837), 1L, null, null, "narrative", "Narrative", 1L, "narrative", 1 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "isHierarchical" },
                values: new object[,]
                {
                    { 1L, "esg_topic", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2485), 1L, null, null, "Dimension Type 1", "ESG Topic", 1L, "DimensionType topic", 1, true },
                    { 2L, "esg-standard", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2489), 1L, null, null, "Dimension Type 2", "ESG Standard", 1L, "dimensiontype standard", 1, true },
                    { 3L, "esg-dq", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2492), 1L, null, null, "Dimension Type 3", "ESG Disclosure Requirements", 1L, "dimensiontype disclosure requirement", 1, true }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(1989), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(1991), null, null, 1L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(1993), null, null, 1L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "acidbasecapacity", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2053), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2054), "", "Acid/Base capacity", 1L, "Acid/Base capacity", 1 },
                    { 2L, "area", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2063), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2064), "", "Area", 1L, "Area", 1 },
                    { 3L, "density", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2067), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2068), "", "Density", 1L, "Density", 1 },
                    { 4L, "time", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2070), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2071), "", "Time", 1L, "Time", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2020), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2022), null, null, 2L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2024), null, null, 3L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "CurrencyId", "CurrencyId1", "DatapointTypeId", "IsNarrative", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "OrganizationId", "Purpose", "State" },
                values: new object[,]
                {
                    { 100L, "SBM-1_07", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2863), null, null, 1L, false, 1L, null, null, "SBM-1_07", 1L, "Purpose 1", 1 },
                    { 101L, "MDR-A_08", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2866), null, null, 1L, false, 1L, null, null, "MDR-A_08", 1L, "Purpose 2", 1 },
                    { 102L, "E1-8_02", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2868), null, null, 2L, true, 1L, null, null, "E1-8_02", 1L, "Purpose 3", 1 },
                    { 103L, "E1-8_03", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2871), null, null, 2L, true, 1L, null, null, "E1-8_03", 1L, "Purpose 4", 1 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypeTranslations",
                columns: new[] { "DimensionTypeId", "LanguageId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2522), 1L, null, null, "Dimension Type 1", "ESG Topic", "DimensionType topic", 1 },
                    { 1L, 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2524), 2L, null, null, "Type de dimension 1", "Sujet ESG", "Sujet de type de dimension", 1 },
                    { 2L, 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2526), 3L, null, null, "Dimension Type 2", "ESG Standard", "DimensionType standard", 1 },
                    { 2L, 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2528), 4L, null, null, "Type de dimension 2", "Norme ESG", "Norme de type de dimension", 1 },
                    { 3L, 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2530), 5L, null, null, "Dimension Type 3", "ESG Disclosure Requirements", "DimensionType disclosure requirement", 1 },
                    { 3L, 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2532), 6L, null, null, "Type de dimension 3", "Exigences de divulgation ESG", "Exigences de divulgation de type de dimension", 1 }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DimensionTypeId", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "isHierarchical" },
                values: new object[,]
                {
                    { 100L, "general", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, null, null, "general", "general", 1L, "general", 1, true },
                    { 101L, "environment", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, null, null, "environment", "environment", 1L, "environment", 1, true },
                    { 102L, "social", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, null, null, "social", "social", 1L, "social", 1, true },
                    { 103L, "governance", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, null, null, "governance", "governance", 1L, "governance", 1, true },
                    { 104L, "ESRS2_GP", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "General principles", "ESRS2_GP", 1L, "General principles", 1, true },
                    { 105L, "ESRS2_MDR", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "General disclosures", "ESRS2_MDR", 1L, "General disclosures", 1, true },
                    { 106L, "E1", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Climate change", "E1", 1L, "Climate change", 1, true },
                    { 107L, "E2", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Pollution", "E2", 1L, "Pollution", 1, true },
                    { 108L, "E3", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Water & marine resources", "E3", 1L, "Water & marine resources", 1, true },
                    { 109L, "E4", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Biodiversity and eco systems", "E4", 1L, "Biodiversity and eco systems", 1, true },
                    { 110L, "E5", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Resourtce use and circular economy", "E5", 1L, "Resourtce use and circular economy", 1, true },
                    { 111L, "S1", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Own workforce", "s1", 1L, "Own workforce", 1, true },
                    { 112L, "S2", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Workers in value chain", "s2", 1L, "Workers in value chain", 1, true },
                    { 113L, "S3", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Affected communities", "s3", 1L, "Affected communities", 1, true },
                    { 114L, "S4", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Consumers and end-users", "s4", 1L, "Consumers and end-users", 1, true },
                    { 115L, "G1", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L, null, null, "Business Conduct", "G1", 1L, "Business Conduct", 1, true },
                    { 116L, "BP-1", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "General basis for preparation of sustainability statements", "BP-1", 1L, "General basis for preparation of sustainability statements", 1, false },
                    { 117L, "BP-2", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Disclosures in relation to specific circumstances", "BP-2", 1L, "Disclosures in relation to specific circumstances", 1, false },
                    { 118L, "GOV-1", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "The role of the administrative, management and supervisory bodies", "GOV-1", 1L, "The role of the administrative, management and supervisory bodies", 1, false },
                    { 119L, "GOV-2", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", "GOV-2", 1L, "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", 1, false },
                    { 120L, "GOV-3", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Integration of sustainability-related performance in incentive schemes", "GOV-3", 1L, "Integration of sustainability-related performance in incentive schemes", 1, false },
                    { 121L, "GOV-4", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Statement on due diligence", "GOV-4", 1L, "Statement on due diligence", 1, false },
                    { 122L, "GOV-5", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Risk management and internal controls over sustainability reporting", "GOV-5", 1L, "Risk management and internal controls over sustainability reporting", 1, false },
                    { 123L, "SBM-1", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Strategy, business model and value chain", "SBM-1", 1L, "Strategy, business model and value chain", 1, false },
                    { 124L, "SBM-2", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Interests and views of stakeholders", "SBM-2", 1L, "Interests and views of stakeholders", 1, false },
                    { 125L, "SBM-3", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Material impacts, risks and opportunities and their interaction with strategy and business model", "SBM-3", 1L, "Material impacts, risks and opportunities and their interaction with strategy and business model", 1, false },
                    { 126L, "IRO-1", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Description of the process to identify and assess material impacts, risks and opportunities", "IRO-1", 1L, "Description of the process to identify and assess material impacts, risks and opportunities", 1, false },
                    { 127L, "IRO-2", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", "IRO-2", 1L, "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", 1, false },
                    { 128L, "IRO-3", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Material impacts, risks and opportunities and their interaction with strategy and business model", "IRO-3", 1L, "Material impacts, risks and opportunities and their interaction with strategy and business model", 1, false },
                    { 129L, "IRO-4", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1L, null, null, "Material impacts, risks and opportunities in the undertaking’s own operations and value chain", "IRO-4", 1L, "Material impacts, risks and opportunities in the undertaking’s own operations and value chain", 1, false }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypeTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureTypeId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2445), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2446), "Acid/Base capacity", "Acid/Base capacity", "Acid/Base capacity", 1 },
                    { 1L, 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2449), 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2450), "Area", "Area", "Area", 1 },
                    { 1L, 3L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2453), 3L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2453), "Density", "Density", "Density", 1 },
                    { 1L, 4L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2456), 4L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2457), "Time", "Time", "Time", 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 101L, "hh", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2099), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2100), "Hour", "time", 1L, "Hr", 1, 4L },
                    { 102L, "mm", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2104), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2105), "Minute", "time", 1L, "Min", 1, 4L },
                    { 103L, "ss", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2107), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2108), "Second", "time", 1L, "Sec", 1, 4L },
                    { 104L, "d", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2111), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2111), "Day", "time", 1L, "Day", 1, 4L },
                    { 105L, "m", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2114), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2115), "Month", "time", 1L, "Month", 1, 4L },
                    { 106L, "q", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2117), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2118), "Quarter", "time", 1L, "Qrtr", 1, 4L },
                    { 107L, "y", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2120), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2121), "Year", "time", 1L, "Year", 1, 4L },
                    { 108L, "mMol/l", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2124), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2124), "Millimol per liter", "acidbasecapacity", 1L, "mMol/l", 1, 1L },
                    { 109L, "Mol/m3", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2127), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2127), "Mol per cubic meter", "acidbasecapacity", 1L, "Mol/m3", 1, 1L },
                    { 110L, "Mol/l", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2131), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2131), "Mol per liter", "acidbasecapacity", 1L, "Mol/l", 1, 1L },
                    { 111L, "acre", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2165), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2165), "Acre", "area", 1L, "Acre", 1, 2L },
                    { 112L, "ha", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2168), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2169), "Hectare", "area", 1L, "Ha", 1, 2L },
                    { 113L, "yd2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2171), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2172), "Square Yard", "area", 1L, "Yd2", 1, 2L },
                    { 114L, "cm2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2175), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2175), "Square centimeter", "area", 1L, "Cm2", 1, 2L },
                    { 115L, "ft2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2178), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2178), "Square foot", "area", 1L, "Ft2", 1, 2L },
                    { 116L, "Inch2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2181), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2181), "Square inch", "area", 1L, "Inch2", 1, 2L },
                    { 117L, "km2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2184), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2185), "Square kilometer", "area", 1L, "Km2", 1, 2L },
                    { 118L, "m2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2188), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2189), "Square meter", "area", 1L, "M2", 1, 2L },
                    { 119L, "Mile2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2191), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2192), "Square mile", "area", 1L, "Mile2", 1, 2L },
                    { 120L, "mm2", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2194), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2195), "Square millimeter", "area", 1L, "Mm2", 1, 2L },
                    { 121L, "g/m3", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2197), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2198), "Gram/Cubic meter", "density", 1L, "G/M3", 1, 3L },
                    { 122L, "g/cm3", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2200), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2201), "Gram/cubic centimeter", "density", 1L, "G/Cm3", 1, 3L },
                    { 123L, "g/l", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2204), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2204), "Gram/liter", "density", 1L, "G/L", 1, 3L },
                    { 124L, "kg/scf", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2207), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2207), "Kilogram/Standard Cubic Foot", "density", 1L, "Kg/Scf", 1, 3L },
                    { 125L, "kg/bbl", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2211), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2211), "Kilogram/US Barrel", "density", 1L, "Kg/Bbl", 1, 3L },
                    { 126L, "kg/dm3", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2214), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2214), "Kilogram/cubic decimeter", "density", 1L, "Kg/Dm3", 1, 3L },
                    { 127L, "kg/m3", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2217), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2217), "Kilogram/cubic meter", "density", 1L, "Kg/M3", 1, 3L },
                    { 128L, "µg/m3", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2220), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2221), "Microgram/cubic meter", "density", 1L, "µg/M3", 1, 3L },
                    { 129L, "µg/l", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2223), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2224), "Microgram/liter", "density", 1L, "µg/L", 1, 3L },
                    { 130L, "mg/m3", 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2226), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2227), "Milligram/cubic meter", "density", 1L, "Mg/M3", 1, 4L }
                });

            migrationBuilder.InsertData(
                table: "DimensionTranslations",
                columns: new[] { "DimensionsId", "LanguageId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 100L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, null, "General", "general", "General", 1 },
                    { 100L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, null, null, "Généralités", "general", "Généralités", 1 },
                    { 101L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, null, null, "Environment", "environment", "Environment", 1 },
                    { 101L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, null, null, "Environnement", "environment", "Environnement", 1 },
                    { 102L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, null, null, "Social", "social", "Social", 1 },
                    { 102L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7L, null, null, "Social", "social", "Social", 1 },
                    { 103L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, null, null, "Governance", "governance", "Governance", 1 },
                    { 103L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8L, null, null, "Gouvernance", "governance", "Gouvernance", 1 },
                    { 104L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9L, null, null, "General principles", "ESRS2_GP", "General principles", 1 },
                    { 104L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21L, null, null, "Principes généraux", "ESRS2_GP", "Principes généraux", 1 },
                    { 105L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10L, null, null, "General disclosures", "ESRS2_MDR", "General disclosures", 1 },
                    { 105L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22L, null, null, "Informations générales", "ESRS2_MDR", "Informations générales", 1 },
                    { 106L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11L, null, null, "Climate change", "E1", "Climate change", 1 },
                    { 106L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23L, null, null, "Changement climatique", "E1", "Changement climatique", 1 },
                    { 107L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, null, null, "Pollution", "E2", "Pollution", 1 },
                    { 107L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24L, null, null, "Pollution", "E2", "Pollution", 1 },
                    { 108L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13L, null, null, "Water & marine resources", "E3", "Water & marine resources", 1 },
                    { 108L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25L, null, null, "Ressources en eau et marines", "E3", "Ressources en eau et marines", 1 },
                    { 109L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, null, null, "Biodiversity and eco systems", "E4", "Biodiversity and eco systems", 1 },
                    { 109L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26L, null, null, "Biodiversité et écosystèmes", "E4", "Biodiversité et écosystèmes", 1 },
                    { 110L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, null, null, "Resource use and circular economy", "E5", "Resource use and circular economy", 1 },
                    { 110L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27L, null, null, "Utilisation des ressources et économie circulaire", "E5", "Utilisation des ressources et économie circulaire", 1 },
                    { 111L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16L, null, null, "Own workforce", "S1", "Own workforce", 1 },
                    { 111L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28L, null, null, "Main-d'œuvre propre", "S1", "Main-d'œuvre propre", 1 },
                    { 112L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17L, null, null, "Workers in value chain", "S2", "Workers in value chain", 1 },
                    { 112L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29L, null, null, "Travailleurs dans la chaîne de valeur", "S2", "Travailleurs dans la chaîne de valeur", 1 },
                    { 113L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18L, null, null, "Affected communities", "S3", "Affected communities", 1 },
                    { 113L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30L, null, null, "Communautés affectées", "S3", "Communautés affectées", 1 },
                    { 114L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19L, null, null, "Consumers and end-users", "S4", "Consumers and end-users", 1 },
                    { 114L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31L, null, null, "Consommateurs et utilisateurs finaux", "S4", "Consommateurs et utilisateurs finaux", 1 },
                    { 115L, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20L, null, null, "Business Conduct", "G1", "Business Conduct", 1 },
                    { 115L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32L, null, null, "Conduite des affaires", "G1", "Conduite des affaires", 1 },
                    { 116L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33L, null, null, "Base générale pour la préparation des déclarations de durabilité", "BP-1", "Base générale pour la préparation des déclarations de durabilité", 1 },
                    { 117L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34L, null, null, "Divulgations concernant des circonstances spécifiques", "BP-2", "Divulgations concernant des circonstances spécifiques", 1 },
                    { 118L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35L, null, null, "Le rôle des organes administratifs, de gestion et de surveillance", "GOV-1", "Le rôle des organes administratifs, de gestion et de surveillance", 1 },
                    { 119L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36L, null, null, "Informations fournies et questions de durabilité traitées par les organes administratifs, de gestion et de surveillance de l’entreprise", "GOV-2", "Informations fournies et questions de durabilité traitées par les organes administratifs, de gestion et de surveillance de l’entreprise", 1 },
                    { 120L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37L, null, null, "Intégration de la performance liée à la durabilité dans les systèmes de rémunération", "GOV-3", "Intégration de la performance liée à la durabilité dans les systèmes de rémunération", 1 },
                    { 121L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38L, null, null, "Déclaration sur la diligence raisonnable", "GOV-4", "Déclaration sur la diligence raisonnable", 1 },
                    { 122L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39L, null, null, "Gestion des risques et contrôles internes sur la déclaration de durabilité", "GOV-5", "Gestion des risques et contrôles internes sur la déclaration de durabilité", 1 },
                    { 123L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40L, null, null, "Stratégie, modèle économique et chaîne de valeur", "SBM-1", "Stratégie, modèle économique et chaîne de valeur", 1 },
                    { 124L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41L, null, null, "Intérêts et points de vue des parties prenantes", "SBM-2", "Intérêts et points de vue des parties prenantes", 1 },
                    { 125L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42L, null, null, "Impacts matériels, risques et opportunités et leur interaction avec la stratégie et le modèle économique", "SBM-3", "Impacts matériels, risques et opportunités et leur interaction avec la stratégie et le modèle économique", 1 },
                    { 126L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43L, null, null, "Description du processus pour identifier et évaluer les impacts matériels, risques et opportunités", "IRO-1", "Description du processus pour identifier et évaluer les impacts matériels, risques et opportunités", 1 },
                    { 127L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44L, null, null, "Exigences de divulgation dans les ESRS couvertes par la déclaration de durabilité de l’entreprise", "IRO-2", "Exigences de divulgation dans les ESRS couvertes par la déclaration de durabilité de l’entreprise", 1 },
                    { 128L, 2L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45L, null, null, "Impacts matériels, risques et opportunités et leur interaction avec la stratégie et le modèle économique", "IRO-3", "Impacts matériels, risques et opportunités et leur interaction avec la stratégie et le modèle économique", 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 101L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2270), 1L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2271), "Hour", "Hour", "Hr", 1 },
                    { 1L, 102L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2274), 2L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2275), "Minute", "Minute", "Min", 1 },
                    { 1L, 103L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2279), 3L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2280), "Second", "Second", "Sec", 1 },
                    { 1L, 104L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2283), 4L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2283), "Day", "Day", "Day", 1 },
                    { 1L, 105L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2286), 5L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2287), "Month", "Month", "Month", 1 },
                    { 1L, 106L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2289), 6L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2290), "Quarter", "Quarter", "Qrtr", 1 },
                    { 1L, 107L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2293), 7L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2293), "Year", "Year", "Year", 1 },
                    { 1L, 108L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2296), 8L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2297), "Millimol per liter", "Millimol per liter", "mMol/l", 1 },
                    { 1L, 109L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2299), 9L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2300), "Mol per cubic meter", "Mol per cubic meter", "Mol/m3", 1 },
                    { 1L, 110L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2302), 10L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2303), "Mol per liter", "Mol per liter", "Mol/l", 1 },
                    { 1L, 111L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2307), 11L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2307), "Acre", "Acre", "Acre", 1 },
                    { 1L, 112L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2310), 12L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2311), "Hectare", "Hectare", "Ha", 1 },
                    { 1L, 113L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2313), 13L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2314), "Square Yard", "Square Yard", "Yd2", 1 },
                    { 1L, 114L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2316), 14L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2317), "Square centimeter", "Square centimeter", "Cm2", 1 },
                    { 1L, 115L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2320), 15L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2320), "Square foot", "Square foot", "Ft2", 1 },
                    { 1L, 116L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2323), 16L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2323), "Square inch", "Square inch", "Inch2", 1 },
                    { 1L, 117L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2326), 17L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2327), "Square kilometer", "Square kilometer", "Km2", 1 },
                    { 1L, 118L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2329), 18L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2330), "Square meter", "Square meter", "M2", 1 },
                    { 1L, 119L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2332), 19L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2333), "Square mile", "Square mile", "Mile2", 1 },
                    { 1L, 120L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2336), 20L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2337), "Square millimeter", "Square millimeter", "Mm2", 1 },
                    { 1L, 121L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2339), 21L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2339), "Gram/Cubic meter", "Gram/Cubic meter", "G/M3", 1 },
                    { 1L, 122L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2342), 22L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2342), "Gram/cubic centimeter", "Gram/cubic centimeter", "G/Cm3", 1 },
                    { 1L, 123L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2345), 23L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2346), "Gram/liter", "Gram/liter", "G/L", 1 },
                    { 1L, 124L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2348), 24L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2349), "Kilogram/Standard Cubic Foot", "Kilogram/Standard Cubic Foot", "Kg/Scf", 1 },
                    { 1L, 125L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2351), 25L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2352), "Kilogram/US Barrel", "Kilogram/US Barrel", "Kg/Bbl", 1 },
                    { 1L, 126L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2384), 26L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2385), "Kilogram/cubic decimeter", "Kilogram/cubic decimeter", "Kg/Dm3", 1 },
                    { 1L, 127L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2388), 27L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2389), "Kilogram/cubic meter", "Kilogram/cubic meter", "Kg/M3", 1 },
                    { 1L, 128L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2392), 28L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2393), "Microgram/cubic meter", "Microgram/cubic meter", "µg/M3", 1 },
                    { 1L, 129L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2395), 29L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2396), "Microgram/liter", "Microgram/liter", "µg/L", 1 },
                    { 1L, 130L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2398), 30L, 1L, new DateTime(2024, 8, 21, 17, 31, 4, 693, DateTimeKind.Utc).AddTicks(2399), "Milligram/cubic meter", "Milligram/cubic meter", "Mg/M3", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatapointModel_DataPointTypesId",
                table: "DatapointModel",
                column: "DataPointTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DatapointModel_DimentionsId",
                table: "DatapointModel",
                column: "DimentionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_LanguageId",
                table: "DataPointTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_OrganizationId",
                table: "DataPointTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DatapointTypeTranslations_DatapointTypeId_LanguageId",
                table: "DatapointTypeTranslations",
                columns: new[] { "DatapointTypeId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatapointTypeTranslations_LanguageId",
                table: "DatapointTypeTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_CurrencyId",
                table: "DataPointValues",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_CurrencyId1",
                table: "DataPointValues",
                column: "CurrencyId1");

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
                name: "IX_DatapointValueTranslations_DatapointValueId_LanguageId",
                table: "DatapointValueTranslations",
                columns: new[] { "DatapointValueId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatapointValueTranslations_LanguageId",
                table: "DatapointValueTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_DimensionTypeId",
                table: "Dimensions",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_LanguageId",
                table: "Dimensions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_OrganizationId",
                table: "Dimensions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTranslations_LanguageId",
                table: "DimensionTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTypes_LanguageId",
                table: "DimensionTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTypes_OrganizationId",
                table: "DimensionTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTypeTranslations_LanguageId",
                table: "DimensionTypeTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_DataPointValuesId",
                table: "Hierarchy",
                column: "DataPointValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_DimensionId",
                table: "Hierarchy",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_OrganizationId",
                table: "Languages",
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
                name: "IX_UnitOfMeasureTranslations_LanguageId",
                table: "UnitOfMeasureTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTypes_LanguageId",
                table: "UnitOfMeasureTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTypes_OrganizationId",
                table: "UnitOfMeasureTypes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureTypeTranslations_LanguageId",
                table: "UnitOfMeasureTypeTranslations",
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
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "DatapointModel");

            migrationBuilder.DropTable(
                name: "DatapointTypeTranslations");

            migrationBuilder.DropTable(
                name: "DatapointValueTranslations");

            migrationBuilder.DropTable(
                name: "DimensionTranslations");

            migrationBuilder.DropTable(
                name: "DimensionTypeTranslations");

            migrationBuilder.DropTable(
                name: "Hierarchy");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTranslations");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypeTranslations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "DataPointValues");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DataPointTypes");

            migrationBuilder.DropTable(
                name: "DimensionTypes");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypes");

            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}

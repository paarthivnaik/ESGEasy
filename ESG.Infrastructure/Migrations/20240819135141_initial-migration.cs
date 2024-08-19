using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
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
                    IsHeirarchialDimension = table.Column<bool>(type: "boolean", nullable: false),
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IsUOM = table.Column<bool>(type: "boolean", nullable: false),
                    IsCurrency = table.Column<bool>(type: "boolean", nullable: false),
                    IsNarrative = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
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
                    IsHeirarchialDimension = table.Column<bool>(type: "boolean", nullable: false),
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
                    LanguageId1 = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_DimensionTypeTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id");
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
                    LanguageId1 = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_UnitOfMeasureTypeTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id");
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
                    DataPointValuesId = table.Column<long>(type: "bigint", nullable: true),
                    LanguageId1 = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_DatapointTypeTranslations_DataPointValues_DataPointValuesId",
                        column: x => x.DataPointValuesId,
                        principalTable: "DataPointValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DatapointTypeTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointTypeTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id");
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
                    LanguageId1 = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_DatapointValueTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id");
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
                    LanguageId1 = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_DimensionTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
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
                    { 1L, "ru", "Russian", null },
                    { 2L, "uk", "Ukrainian", null },
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
                    { 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(4984), "user1@example.com", "John", 1L, null, null, "Doe", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 49 }, "1234567890", new Guid("57652e87-15fb-425f-b490-3f7e8a9beca7"), 1 },
                    { 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(4992), "user2@example.com", "Jane", 1L, null, null, "Smith", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 50 }, "0987654321", new Guid("a554a0d5-fa1c-4ac8-9343-b887403bb846"), 1 },
                    { 3L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(4997), "user3@example.com", "Alice", 1L, null, null, "Johnson", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 51 }, "2345678901", new Guid("56e897c9-0dfd-48c3-ba01-2f1f644ff917"), 1 }
                });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 91L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5430), 1L, null, null, "Type 10", "DatapointType10", 1L, "T10", 1 },
                    { 92L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5427), 1L, null, null, "Type 9", "DatapointType9", 1L, "T9", 1 },
                    { 93L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5425), 1L, null, null, "Type 8", "DatapointType8", 1L, "T8", 1 },
                    { 94L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5423), 1L, null, null, "Type 7", "DatapointType7", 1L, "T7", 1 },
                    { 95L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5421), 1L, null, null, "Type 6", "DatapointType6", 1L, "T6", 1 },
                    { 96L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5418), 1L, null, null, "Type 5", "DatapointType5", 1L, "T5", 1 },
                    { 97L, 3L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5416), 1L, null, null, "Type 3", "DatapointType3", 1L, "T3", 1 },
                    { 98L, 2L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5414), 1L, null, null, "Type 2", "DatapointType2", 1L, "T2", 1 },
                    { 99L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5411), 1L, null, null, "Type 1", "DatapointType1", 1L, "T1", 1 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsHeirarchialDimension", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 50L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5708), true, 1L, null, null, "Dimension Type 1", "DimensionType1", 1L, "DT1", 1 },
                    { 51L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5712), false, 1L, null, null, "Dimension Type 2", "DimensionType2", 1L, "DT2", 1 },
                    { 52L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5715), true, 1L, null, null, "Dimension Type 3", "DimensionType3", 1L, "DT3", 1 },
                    { 53L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5718), true, 1L, null, null, "Dimension Type 4", "DimensionType4", 1L, "DT4", 1 },
                    { 54L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5721), true, 1L, null, null, "Dimension Type 5", "DimensionType5", 1L, "DT5", 1 },
                    { 55L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5723), false, 1L, null, null, "Dimension Type 6", "DimensionType6", 1L, "DT6", 1 },
                    { 56L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5726), true, 1L, null, null, "Dimension Type 7", "DimensionType7", 1L, "DT7", 1 },
                    { 57L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5729), false, 1L, null, null, "Dimension Type 8", "DimensionType8", 1L, "DT8", 1 },
                    { 58L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5731), true, 1L, null, null, "Dimension Type 9", "DimensionType9", 1L, "DT9", 1 },
                    { 59L, "code", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5735), false, 1L, null, null, "Dimension Type 10", "DimensionType10", 1L, "DT10", 1 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5053), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5055), null, null, 1L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5057), null, null, 1L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "speed", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5118), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5119), "Type 1", "Speed", 1L, "T1", 1 },
                    { 2L, "weight", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5128), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5129), "Type 2", "Weight", 1L, "T2", 1 },
                    { 3L, "amount", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5132), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5133), "Type 3", "Amount", 1L, "T3", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5085), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5087), null, null, 2L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5090), null, null, 3L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DatapointTypeId", "IsCurrency", "IsNarrative", "IsUOM", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "OrganizationId", "Purpose", "State", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5514), 99L, true, false, false, 1L, null, null, "DataPointValue1", 1L, "Purpose 1", 1, "Value 1" },
                    { 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5519), 99L, false, false, true, 1L, null, null, "DataPointValue2", 1L, "Purpose 2", 1, "Value 2" },
                    { 3L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5522), 99L, true, false, false, 1L, null, null, "DataPointValue3", 1L, "Purpose 3", 1, "Value 3" },
                    { 4L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5525), 98L, false, true, false, 1L, null, null, "DataPointValue4", 1L, "Purpose 4", 1, "Value 4" },
                    { 5L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5528), 98L, true, false, false, 1L, null, null, "DataPointValue5", 1L, "Purpose 5", 1, "Value 5" },
                    { 6L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5602), 97L, false, false, true, 1L, null, null, "DataPointValue6", 1L, "Purpose 6", 1, "Value 6" },
                    { 7L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5605), 97L, true, false, false, 1L, null, null, "DataPointValue7", 1L, "Purpose 7", 1, "Value 7" },
                    { 8L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5608), 97L, false, true, false, 1L, null, null, "DataPointValue8", 1L, "Purpose 8", 1, "Value 8" },
                    { 9L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5611), 95L, true, false, false, 1L, null, null, "DataPointValue9", 1L, "Purpose 9", 1, "Value 9" },
                    { 10L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5614), 95L, false, false, true, 1L, null, null, "DataPointValue10", 1L, "Purpose 10", 1, "Value 10" }
                });

            migrationBuilder.InsertData(
                table: "DatapointTypeTranslations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataPointValuesId", "DatapointTypeId", "LanguageId", "LanguageId1", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 101L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5464), null, 99L, 1L, null, null, null, "Type 1", "DatapointType1", "T1", 1 },
                    { 102L, 2L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5467), null, 99L, 2L, null, null, null, "Type 2", "DatapointType1", "T2", 1 },
                    { 103L, 3L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5469), null, 99L, 3L, null, null, null, "Type 3", "DatapointType2", "T3", 1 },
                    { 104L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5472), null, 98L, 1L, null, null, null, "Type 5", "DatapointType2", "T5", 1 },
                    { 105L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5474), null, 98L, 2L, null, null, null, "Type 6", "DatapointType3", "T6", 1 },
                    { 106L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5476), null, 97L, 1L, null, null, null, "Type 7", "DatapointType3", "T7", 1 },
                    { 107L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5478), null, 96L, 1L, null, null, null, "Type 8", "DatapointType5", "T8", 1 },
                    { 108L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5480), null, 96L, 2L, null, null, null, "Type 9", "DatapointType5", "T9", 1 }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DimensionTypeId", "IsHeirarchialDimension", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 100L, "code", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50L, true, 1L, null, null, "Long Description 1", "Dimension 1", 1L, "Short 1", 1 },
                    { 101L, "code", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50L, true, 1L, null, null, "Long Description 2", "Dimension 2", 1L, "Short 2", 1 },
                    { 102L, "code", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51L, true, 1L, null, null, "Long Description 3", "Dimension 3", 1L, "Short 3", 1 },
                    { 103L, "code", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51L, true, 1L, null, null, "Long Description 4", "Dimension 4", 1L, "Short 4", 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypeTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureTypeId", "CreatedBy", "CreatedDate", "Id", "LanguageId1", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5371), 13L, null, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5372), "meterpersecond", "speed", "m/s", 0 },
                    { 2L, 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5375), 14L, null, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5376), "kmperhour", "speed", "kmph", 0 },
                    { 1L, 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5359), 10L, null, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5360), "Kilogram", "weight", "kg", 0 },
                    { 2L, 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5364), 11L, null, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5365), "Gram", "weight", "gm", 0 },
                    { 1L, 3L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5367), 12L, null, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5368), "milliliter", "amount", "ml", 0 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 4L, "weight", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5252), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5253), "Kilogram", "weight", 1L, "kg", 1, 2L },
                    { 5L, "weight", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5257), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5258), "Gram", "weight", 1L, "gm", 1, 2L },
                    { 6L, "weight", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5261), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5262), "milliliter", "amount", 1L, "ml", 1, 3L },
                    { 7L, "weight", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5265), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5266), "meterpersecond", "speed", 1L, "m/s", 1, 1L },
                    { 8L, "weight", 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5271), 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5272), "kmperhour", "speed", 1L, "kmph", 1, 1L }
                });

            migrationBuilder.InsertData(
                table: "DatapointValueTranslations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DatapointValueId", "LanguageId", "LanguageId1", "LastModifiedBy", "LastModifiedDate", "Name", "Purpose", "State", "Value" },
                values: new object[,]
                {
                    { 101L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5652), 1L, 1L, null, null, null, "DataPointValue1", "--", 1, "10m" },
                    { 102L, 2L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5656), 1L, 2L, null, null, null, "DataPointValue1", "--", 1, "10" },
                    { 103L, 3L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5659), 2L, 1L, null, null, null, "DataPointValue2", "--", 1, "10" },
                    { 104L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5661), 2L, 2L, null, null, null, "DataPointValue2", "--", 1, "10" },
                    { 105L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5663), 3L, 1L, null, null, null, "DataPointValue3", "--", 1, "10" },
                    { 106L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5665), 3L, 2L, null, null, null, "DataPointValue3", "--", 1, "10" },
                    { 107L, 0L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5670), 5L, 1L, null, null, null, "DataPointValue5", "--", 1, "10" },
                    { 108L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5672), 5L, 2L, null, null, null, "DataPointValue5", "--", 1, "10" },
                    { 109L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5674), 5L, 3L, null, null, null, "DataPointValue5", "--", 1, "10" }
                });

            migrationBuilder.InsertData(
                table: "DimensionTranslations",
                columns: new[] { "DimensionsId", "LanguageId", "CreatedBy", "CreatedDate", "Id", "LanguageId1", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 100L, 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5808), 2L, null, null, null, "Dimension Type 3", "Dimension2", "DT3", 1 },
                    { 100L, 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5805), 1L, null, null, null, "Dimension Type 2", "Dimension2", "DT2", 1 },
                    { 101L, 1L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5810), 3L, null, null, null, "Dimension Type 4", "Dimension2", "DT4", 1 },
                    { 101L, 2L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5812), 4L, null, null, null, "Dimension Type 5", "Dimension2", "DT5", 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 4L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5309), 10L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5310), "Kilogram", "weight", "kg", 0 },
                    { 2L, 4L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5314), 11L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5315), "Gram", "weight", "gm", 0 },
                    { 1L, 6L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5318), 12L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5319), "milliliter", "amount", "ml", 0 },
                    { 1L, 7L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5322), 13L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5323), "meterpersecond", "speed", "m/s", 0 },
                    { 2L, 7L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5326), 14L, 1L, new DateTime(2024, 8, 19, 13, 51, 41, 156, DateTimeKind.Utc).AddTicks(5326), "kmperhour", "speed", "kmph", 0 }
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
                name: "IX_DatapointTypeTranslations_DataPointValuesId",
                table: "DatapointTypeTranslations",
                column: "DataPointValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_DatapointTypeTranslations_LanguageId",
                table: "DatapointTypeTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DatapointTypeTranslations_LanguageId1",
                table: "DatapointTypeTranslations",
                column: "LanguageId1");

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
                name: "IX_DatapointValueTranslations_LanguageId1",
                table: "DatapointValueTranslations",
                column: "LanguageId1");

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
                name: "IX_DimensionTranslations_LanguageId1",
                table: "DimensionTranslations",
                column: "LanguageId1");

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
                name: "IX_DimensionTypeTranslations_LanguageId1",
                table: "DimensionTypeTranslations",
                column: "LanguageId1");

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
                name: "IX_UnitOfMeasureTypeTranslations_LanguageId1",
                table: "UnitOfMeasureTypeTranslations",
                column: "LanguageId1");

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
                name: "Currency");

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

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
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
                name: "DataPointTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    table.PrimaryKey("PK_DataPointTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPointTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId",
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "DimensionsId",
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointValues_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId",
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
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTypes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "DimensionsId",
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
                        principalColumn: "DimensionsId",
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "DimensionsId",
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
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dimensions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dimensions_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "DimensionsId",
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
                    table.PrimaryKey("PK_DimensionTypeTranslations", x => new { x.DimensionTypeId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_DimensionTypeTranslations_DimensionTypes_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTypeTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTypeTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId");
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_OrganizationUsers_OrganizationUserId",
                        column: x => x.OrganizationUserId,
                        principalTable: "OrganizationUsers",
                        principalColumn: "DimensionsId");
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasures_UnitOfMeasureTypes_UnitOfMeasureTypeId",
                        column: x => x.UnitOfMeasureTypeId,
                        principalTable: "UnitOfMeasureTypes",
                        principalColumn: "DimensionsId",
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypeTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId");
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTypeTranslations_UnitOfMeasureTypes_UnitOfMeas~",
                        column: x => x.UnitOfMeasureTypeId,
                        principalTable: "UnitOfMeasureTypes",
                        principalColumn: "DimensionsId",
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
                        name: "FK_DatapointModel_DataPointTypes_DatapointId",
                        column: x => x.DatapointId,
                        principalTable: "DataPointTypes",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointModel_Dimensions_DimentionsId",
                        column: x => x.DimentionsId,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionsId",
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
                    table.PrimaryKey("PK_DimensionTranslations", x => new { x.DimensionsId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_DimensionTranslations_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DimensionTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId");
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
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
                    LanguageId1 = table.Column<long>(type: "bigint", nullable: true),
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
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "DimensionsId");
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureTranslations_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "DimensionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "DimensionsId", "CurrencyCode", "LongText", "Name", "ShortText" },
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
                columns: new[] { "DimensionsId", "IsoCode", "Name" },
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
                columns: new[] { "DimensionsId", "Name" },
                values: new object[,]
                {
                    { 1L, "AdminEE" },
                    { 2L, "ClientAdmin" },
                    { 3L, "User" }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "DimensionsId", "Name" },
                values: new object[] { 1L, "ESG Global" });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "DimensionsId", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7088), 1L, null, null, "Type 1", "DatapointType1", "T1", 1 },
                    { 2L, 2L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7089), 2L, null, null, "Type 2", "DatapointType2", "T2", 1 },
                    { 3L, 3L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7091), 3L, null, null, "Type 3", "DatapointType3", "T3", 1 },
                    { 5L, 0L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7092), 1L, null, null, "Type 5", "DatapointType5", "T5", 1 },
                    { 6L, 0L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7093), 1L, null, null, "Type 6", "DatapointType6", "T6", 1 },
                    { 7L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7095), 1L, null, null, "Type 7", "DatapointType7", "T7", 1 },
                    { 8L, 0L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7096), 1L, null, null, "Type 8", "DatapointType8", "T8", 1 },
                    { 9L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7097), 1L, null, null, "Type 9", "DatapointType9", "T9", 1 },
                    { 10L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7099), 1L, null, null, "Type 10", "DatapointType10", "T10", 1 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "DimensionsId", "Country", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LatsName", "LogoUrl", "Name", "PostalCode", "RegistrationId", "State", "StreetAddress", "StreetNumber", "TenantId" },
                values: new object[] { 1L, "USA", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@org1.com", "John", 1L, null, null, "Doe", null, "ESG Global", "12345", "REG-001", 1, "123 Main St", "456", 1L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "DimensionsId", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "OrganizationUserId", "Password", "PhoneNumber", "SecurityStamp", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6742), "user1@example.com", "John", 1L, null, null, "Doe", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 49 }, "1234567890", new Guid("f1894c1a-1b0b-42a3-b628-04b13f9d6a13"), 1 },
                    { 2L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6747), "user2@example.com", "Jane", 1L, null, null, "Smith", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 50 }, "0987654321", new Guid("0b99d4d3-2f96-42bf-bcb5-aec1642f9202"), 1 },
                    { 3L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6762), "user3@example.com", "Alice", 1L, null, null, "Johnson", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 51 }, "2345678901", new Guid("d7a73b29-7823-4a31-bfd0-780ee73abadc"), 1 }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "DimensionsId", "CreatedBy", "CreatedDate", "DatapointTypeId", "IsCurrency", "IsNarrative", "IsUOM", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "Purpose", "State", "Value" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7131), 1L, true, false, false, 1L, null, null, "DataPointValue1", "Purpose 1", 1, "Value 1" },
                    { 2L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7133), 1L, false, false, true, 1L, null, null, "DataPointValue2", "Purpose 2", 1, "Value 2" },
                    { 3L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7135), 1L, true, false, false, 1L, null, null, "DataPointValue3", "Purpose 3", 1, "Value 3" },
                    { 4L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7136), 1L, false, true, false, 1L, null, null, "DataPointValue4", "Purpose 4", 1, "Value 4" },
                    { 5L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7138), 1L, true, false, false, 1L, null, null, "DataPointValue5", "Purpose 5", 1, "Value 5" },
                    { 6L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7140), 1L, false, false, true, 1L, null, null, "DataPointValue6", "Purpose 6", 1, "Value 6" },
                    { 7L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7142), 1L, true, false, false, 2L, null, null, "DataPointValue7", "Purpose 7", 1, "Value 7" },
                    { 8L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7143), 1L, false, true, false, 2L, null, null, "DataPointValue8", "Purpose 8", 1, "Value 8" },
                    { 9L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7145), 1L, true, false, false, 2L, null, null, "DataPointValue9", "Purpose 9", 1, "Value 9" },
                    { 10L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(7146), 1L, false, false, true, 2L, null, null, "DataPointValue10", "Purpose 10", 1, "Value 10" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "DimensionsId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6801), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6802), null, null, 1L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6803), null, null, 1L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "DimensionsId", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "speed", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6847), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6848), "Type 1", "Speed", 1L, "T1", 1 },
                    { 2L, "weight", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6857), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6858), "Type 2", "Weight", 1L, "T2", 1 },
                    { 3L, "amount", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6860), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6860), "Type 3", "Amount", 1L, "T3", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "DimensionsId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6823), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6825), null, null, 2L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6826), null, null, 3L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypeTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureTypeId", "CreatedBy", "CreatedDate", "DimensionsId", "LanguageId1", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6952), 13L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6953), "meterpersecond", "speed", "m/s", 0 },
                    { 2L, 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6954), 14L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6955), "kmperhour", "speed", "kmph", 0 },
                    { 1L, 2L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6945), 10L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6946), "Kilogram", "weight", "kg", 0 },
                    { 2L, 2L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6948), 11L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6949), "Gram", "weight", "gm", 0 },
                    { 1L, 3L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6950), 12L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6951), "milliliter", "amount", "ml", 0 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "DimensionsId", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 4L, "weight", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6879), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6879), "Kilogram", "weight", 1L, "kg", 1, 2L },
                    { 5L, "weight", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6882), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6883), "Gram", "weight", 1L, "gm", 1, 2L },
                    { 6L, "weight", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6885), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6886), "milliliter", "amount", 1L, "ml", 1, 3L },
                    { 7L, "weight", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6888), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6888), "meterpersecond", "speed", 1L, "m/s", 1, 1L },
                    { 8L, "weight", 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6890), 1L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6890), "kmperhour", "speed", 1L, "kmph", 1, 1L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "DimensionsId", "LanguageId1", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 4L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6912), 10L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6912), "Kilogram", "weight", "kg", 0 },
                    { 2L, 4L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6915), 11L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6915), "Gram", "weight", "gm", 0 },
                    { 1L, 6L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6921), 12L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6921), "milliliter", "amount", "ml", 0 },
                    { 1L, 7L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6923), 13L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6923), "meterpersecond", "speed", "m/s", 0 },
                    { 2L, 7L, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6925), 14L, null, 1L, new DateTime(2024, 8, 13, 13, 40, 44, 633, DateTimeKind.Utc).AddTicks(6925), "kmperhour", "speed", "kmph", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatapointModel_DatapointId",
                table: "DatapointModel",
                column: "DatapointId");

            migrationBuilder.CreateIndex(
                name: "IX_DatapointModel_DimentionsId",
                table: "DatapointModel",
                column: "DimentionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_LanguageId",
                table: "DataPointTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_DatapointTypeId",
                table: "DataPointValues",
                column: "DatapointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_LanguageId",
                table: "DataPointValues",
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
                column: "OrganizationId",
                unique: true);

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
                column: "OrganizationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTypeTranslations_LanguageId",
                table: "DimensionTypeTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionTypeTranslations_LanguageId1",
                table: "DimensionTypeTranslations",
                column: "LanguageId1");

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
                name: "DataPointValues");

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
                name: "DataPointTypes");

            migrationBuilder.DropTable(
                name: "Dimensions");

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

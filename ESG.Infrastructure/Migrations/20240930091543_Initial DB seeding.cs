using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBseeding : Migration
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
                    NewValues = table.Column<string>(type: "text", nullable: true),
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
                name: "DataModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "text", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    IsDefaultModel = table.Column<bool>(type: "boolean", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataModels_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
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
                name: "OrganizationHeirarchies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HierarchyId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationHeirarchies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationHeirarchies_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelFilterCombinations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataModelId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelFilterCombinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataModel_DataModelId",
                        column: x => x.DataModelId,
                        principalTable: "DataModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataPointType",
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
                    table.PrimaryKey("PK_DataPointType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPointType_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointType_Organizations_OrganizationId",
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
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
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
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
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
                    Password = table.Column<string>(type: "text", nullable: false),
                    SecurityStamp = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "ModelConfiguration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataModelId = table.Column<long>(type: "bigint", nullable: false),
                    RowId = table.Column<long>(type: "bigint", nullable: false),
                    ColumnId = table.Column<long>(type: "bigint", nullable: true),
                    ViewType = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelConfiguration_DataModels_DataModelId",
                        column: x => x.DataModelId,
                        principalTable: "DataModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelConfiguration_DimensionTypes_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModelConfiguration_DimensionTypes_RowId",
                        column: x => x.RowId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelDimensionTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataModelId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDimensionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelDimensionTypes_DataModels_DataModelId",
                        column: x => x.DataModelId,
                        principalTable: "DataModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelDimensionTypes_DimensionType_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Standard",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    TopicId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standard_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Standard_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
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
                    table.ForeignKey(
                        name: "FK_OrganizationUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                name: "DimensionTranslations",
                columns: table => new
                {
                    DimensionsId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "DataModelFilters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelConfigurationId = table.Column<long>(type: "bigint", nullable: false),
                    FilterId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionTypeId = table.Column<long>(type: "bigint", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataModelFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataModelFilters_DimensionTypes_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataModelFilters_DimensionTypes_FilterId",
                        column: x => x.FilterId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataModelFilters_ModelConfiguration_ModelConfigurationId",
                        column: x => x.ModelConfigurationId,
                        principalTable: "ModelConfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelDimensionValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelDimensionTypesId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionsId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDimensionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelDimensionValues_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelDimensionValues_ModelDimensionTypes_ModelDimensionType~",
                        column: x => x.ModelDimensionTypesId,
                        principalTable: "ModelDimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisclosureRequirement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: false),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    StandardId = table.Column<long>(type: "bigint", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisclosureRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisclosureRequirement_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisclosureRequirement_Standard_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standard",
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

            migrationBuilder.CreateTable(
                name: "ModelFilterCombinationalValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataModelFiltersId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionsId = table.Column<long>(type: "bigint", nullable: false),
                    ModelFilterCombinationsId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionTypeId = table.Column<long>(type: "bigint", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelFilterCombinationalValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataModelFIlters_DatamodelFiltersID",
                        column: x => x.DataModelFiltersId,
                        principalTable: "DataModelFilters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DimensionType_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dimension_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModelFilterCombination_ModelFilterCombinationId",
                        column: x => x.ModelFilterCombinationsId,
                        principalTable: "ModelFilterCombinations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SampleModelFilterCombinationValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataModelFiltersId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionsId = table.Column<long>(type: "bigint", nullable: false),
                    ModelFilterCombinationsId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleModelFilterCombinationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataModelFilters_DatamodelFiltersId",
                        column: x => x.DataModelFiltersId,
                        principalTable: "DataModelFilters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModelFlterCombinations_ModelFIlterCombinationsId",
                        column: x => x.ModelFilterCombinationsId,
                        principalTable: "ModelFilterCombinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SampleModelFilterCombinationValues_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPointValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: true),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    IsNarrative = table.Column<bool>(type: "boolean", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    DisclosureRequirementId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModelFilterCombinationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPointValue_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValue_DataPointType_DatapointTypeId",
                        column: x => x.DatapointTypeId,
                        principalTable: "DataPointType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValue_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointValue_ModelFilterCombinations_ModelFilterCombinati~",
                        column: x => x.ModelFilterCombinationId,
                        principalTable: "ModelFilterCombinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValue_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPointValue_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValue_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValues_DisclosureRequirement_DisclosureRequirement~",
                        column: x => x.DisclosureRequirementId,
                        principalTable: "DisclosureRequirement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataModelValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RowId = table.Column<long>(type: "bigint", nullable: false),
                    ColumnId = table.Column<long>(type: "bigint", nullable: true),
                    CombinationId = table.Column<long>(type: "bigint", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: true),
                    ResponsibleUserId = table.Column<long>(type: "bigint", nullable: true),
                    AccountableUserId = table.Column<long>(type: "bigint", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataPointValuesId = table.Column<long>(type: "bigint", nullable: true),
                    DataModelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataModelValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataModelValues_DataModel_DataModelId",
                        column: x => x.DataModelId,
                        principalTable: "DataModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataModelValues_Dimensions_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Dimensions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataModelValues_Dimensions_RowId",
                        column: x => x.RowId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataModelValues_ModelFilterCombinations_CombinationId",
                        column: x => x.CombinationId,
                        principalTable: "ModelFilterCombinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataModelValues_Users_AccountableUserId",
                        column: x => x.AccountableUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataModelValues_Users_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValues_DatapointValuesId",
                        column: x => x.DataPointValuesId,
                        principalTable: "DataPointValue",
                        principalColumn: "Id");
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
                        name: "FK_DatapointTypeTranslations_DataPointType_DatapointTypeId",
                        column: x => x.DatapointTypeId,
                        principalTable: "DataPointType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatapointTypeTranslations_DataPointValue_DatapointTypeId",
                        column: x => x.DatapointTypeId,
                        principalTable: "DataPointValue",
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
                        name: "FK_DatapointValueTranslations_DataPointValue_DatapointValueId",
                        column: x => x.DatapointValueId,
                        principalTable: "DataPointValue",
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
                name: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HierarchyId = table.Column<long>(type: "bigint", nullable: false),
                    DataPointValuesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchy_DataPointValue_DataPointValuesId",
                        column: x => x.DataPointValuesId,
                        principalTable: "DataPointValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelDatapoints",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataModelId = table.Column<long>(type: "bigint", nullable: false),
                    DatapointValuesId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDatapoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelDatapoints_DataModels_DataModelId",
                        column: x => x.DataModelId,
                        principalTable: "DataModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelDatapoints_DataPointValue_DatapointValuesId",
                        column: x => x.DatapointValuesId,
                        principalTable: "DataPointValue",
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
                    { 3L, "JPY", "Japanese Yen", "Japanese Yen", "JPY" },
                    { 4L, "GBP", "British Pound Sterling", "British Pound", "GBP" },
                    { 5L, "AUD", "Australian Dollar", "Australian Dollar", "AUD" },
                    { 6L, "CAD", "Canadian Dollar", "Canadian Dollar", "CAD" },
                    { 7L, "CHF", "Swiss Franc", "Swiss Franc", "CHF" },
                    { 8L, "CNY", "Chinese Yuan Renminbi", "Chinese Yuan", "CNY" },
                    { 9L, "HKD", "Hong Kong Dollar", "Hong Kong Dollar", "HKD" },
                    { 10L, "NZD", "New Zealand Dollar", "New Zealand Dollar", "NZD" },
                    { 11L, "SEK", "Swedish Krona", "Swedish Krona", "SEK" },
                    { 12L, "KRW", "South Korean Won", "South Korean Won", "KRW" },
                    { 13L, "SGD", "Singapore Dollar", "Singapore Dollar", "SGD" },
                    { 14L, "NOK", "Norwegian Krone", "Norwegian Krone", "NOK" },
                    { 15L, "MXN", "Mexican Peso", "Mexican Peso", "MXN" },
                    { 16L, "INR", "Indian Rupee", "Indian Rupee", "INR" },
                    { 17L, "BRL", "Brazilian Real", "Brazilian Real", "BRL" },
                    { 18L, "ZAR", "South African Rand", "South African Rand", "ZAR" },
                    { 19L, "RUB", "Russian Ruble", "Russian Ruble", "RUB" },
                    { 20L, "TRY", "Turkish Lira", "Turkish Lira", "TRY" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsoCode", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1L, "en", "English", null },
                    { 2L, "fr", "French", null }
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
                values: new object[,]
                {
                    { 1L, "ESG Global1" },
                    { 2L, "ESG Global2" }
                });

            migrationBuilder.InsertData(
                table: "DisclosureRequirement",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "StandardId", "State" },
                values: new object[,]
                {
                    { 57L, "S1.SBM-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4200), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4201), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 },
                    { 76L, "S2.SBM-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4241), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4241), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 },
                    { 90L, "S4.SBM-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4273), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4274), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Country", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LatsName", "LogoUrl", "Name", "PostalCode", "RegistrationId", "State", "StreetAddress", "StreetNumber", "TenantId" },
                values: new object[,]
                {
                    { 1L, "USA", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@org1.com", "John", 1L, null, null, "Doe", null, "ESG Global", "12345", "REG-001", 0, "123 Main St", "456", 1L },
                    { 2L, "Canada", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@org2.com", "Jane", 1L, null, null, "Smith", null, "Green Future", "67890", "REG-002", 0, "456 Oak St", "789", 1L },
                    { 3L, "UK", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@org3.com", "Alice", 1L, null, null, "Johnson", null, "EcoTech", "11223", "REG-003", 0, "789 Pine St", "101", 1L },
                    { 4L, "Germany", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@org4.com", "Bob", 1L, null, null, "Brown", null, "Sustainable Solutions", "33445", "REG-004", 0, "101 Elm St", "202", 2L },
                    { 5L, "Australia", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis@org5.com", "Charlie", 1L, null, null, "Davis", null, "CarbonFree", "55667", "REG-005", 0, "202 Birch St", "303", 2L },
                    { 6L, "India", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.evans@org6.com", "David", 1L, null, null, "Evans", null, "CleanEnergy", "77889", "REG-006", 0, "303 Cedar St", "404", 2L }
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "general", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4558), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4559), "General", "General", 1 },
                    { 2L, "environment", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4561), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4562), "Environment", "Environment", 1 },
                    { 3L, "social", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4563), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4564), "Social", "Social", 1 },
                    { 4L, "governance", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4565), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4566), "Governance", "Governance", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "Password", "PhoneNumber", "SecurityStamp", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5684), "user1@example.com", "John", 1L, null, null, "Doe", "password1", "1234567890", new Guid("6455694b-01a6-4a4c-a92e-75f6bbdb316e"), 0 },
                    { 2L, 2L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5687), "user2@example.com", "Jane", 1L, null, null, "Smith", "password2", "0987654321", new Guid("ec0bbfea-eb05-4136-a3e0-890ebf6a6c4b"), 0 },
                    { 3L, 3L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5698), "user3@example.com", "Alice", 1L, null, null, "Johnson", "password3", "2345678901", new Guid("b3d51ed5-d7c1-4d6c-a919-573eb140d222"), 0 },
                    { 4L, 4L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5700), "user4@example.com", "Bob", 1L, null, null, "Brown", "password4", "3456789012", new Guid("1de1db94-4893-4b8d-85a3-dc66cb9f2052"), 0 },
                    { 5L, 5L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5704), "user5@example.com", "Charlie", 1L, null, null, "Davis", "password5", "4567890123", new Guid("8be902f1-d25b-4dc3-b758-825c74d82416"), 0 },
                    { 6L, 6L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5706), "user6@example.com", "David", 1L, null, null, "Evans", "password6", "5678901234", new Guid("ff081430-8cf4-4bee-a490-1ee7622fc450"), 0 },
                    { 7L, 7L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5713), "user7@example.com", "Eve", 1L, null, null, "Foster", "password7", "6789012345", new Guid("72562415-b5ff-4b0a-8f94-e95f7edb3791"), 0 },
                    { 8L, 8L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5716), "user8@example.com", "Frank", 1L, null, null, "Garcia", "password8", "7890123456", new Guid("4281fc2c-640a-405b-8bfe-2785fbcd7b1f"), 0 },
                    { 9L, 9L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5721), "user9@example.com", "Grace", 1L, null, null, "Harris", "password9", "8901234567", new Guid("5d245ebf-1f6d-4b3b-9fff-442983492c78"), 0 },
                    { 10L, 10L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5726), "user10@example.com", "Hank", 1L, null, null, "Ivy", "password10", "9012345678", new Guid("2408e1b9-7bd4-4b86-bce3-a3e2f93768dc"), 0 },
                    { 11L, 11L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5732), "user11@example.com", "Irene", 1L, null, null, "James", "password11", "0123456789", new Guid("de93fbfc-6812-4df0-9709-7bb8a64d3664"), 0 },
                    { 12L, 12L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5734), "user12@example.com", "Jack", 1L, null, null, "Kane", "password12", "1234509876", new Guid("024fafb4-7c06-4f0d-91ae-93cdb5291f79"), 0 },
                    { 13L, 13L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5736), "user13@example.com", "Laura", 1L, null, null, "Mills", "password13", "2345610987", new Guid("abef2399-ff41-49d8-8f2d-4c00fc8e3226"), 0 },
                    { 14L, 14L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5738), "user14@example.com", "Mike", 1L, null, null, "Nelson", "password14", "3456721098", new Guid("d6c3640a-d07e-4d27-a69d-04b5d71d2a83"), 0 },
                    { 15L, 15L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5740), "user15@example.com", "Nina", 1L, null, null, "Owen", "password15", "4567832109", new Guid("9a52bd3a-3e42-4760-864e-6b261599b89d"), 0 },
                    { 16L, 16L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5743), "user16@example.com", "Oliver", 1L, null, null, "Perez", "password16", "5678943210", new Guid("33448971-f005-44ac-90aa-f5bc94015d37"), 0 },
                    { 17L, 17L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5745), "user17@example.com", "Pam", 1L, null, null, "Quinn", "password17", "6789054321", new Guid("c87f5c0a-246b-47ea-8932-bd2845171aa2"), 0 },
                    { 18L, 18L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5751), "user18@example.com", "Quinn", 1L, null, null, "Reed", "password18", "7890165432", new Guid("af40e2d2-f71c-4cc9-b40f-e016c07bc4bc"), 0 },
                    { 101L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5678), "user101@example.com", "John", 1L, null, null, "Doe", "password101", "1234567890", new Guid("93aeb0dc-0455-4005-8c8f-46916a0df988"), 0 },
                    { 102L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5681), "user102@example.com", "John", 1L, null, null, "Doe", "password102", "1234567890", new Guid("05a1786b-f92f-42a9-8852-b95e92f0d500"), 0 }
                });

            migrationBuilder.InsertData(
                table: "DataModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDefaultModel", "LastModifiedBy", "LastModifiedDate", "ModelName", "OrganizationId", "Purpose", "State" },
                values: new object[] { 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5787), true, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5788), "Default Model", 1L, "This Model is default model", 1 });

            migrationBuilder.InsertData(
                table: "DataPointType",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "table", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(348), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(354), "Table", "Table", 1L, "Table", 1 },
                    { 2L, "narrative", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(358), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(359), "Narrative", "Narrative", 1L, "Narrative", 1 },
                    { 3L, "monetary", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(361), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(362), "Monetary", "Monetary", 1L, "Monetary", 1 },
                    { 4L, "quantity", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(363), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(364), "Quantity", "Quantity", 1L, "Quantity", 1 },
                    { 5L, "time", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(366), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(367), "Time", "Time", 1L, "Time", 1 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "yyyy", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3894), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3895), "Year", 1L, "Year", 1 },
                    { 2L, "m", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3898), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3899), "Month", 1L, "Month", 1 },
                    { 3L, "q", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3901), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3902), "Quarter", 1L, "Quarter", 1 },
                    { 4L, "d", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3904), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3904), "Day", 1L, "Day", 1 },
                    { 5L, "vatyp", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3906), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3907), "Value Type", 1L, "Value Type", 1 },
                    { 6L, "cntry", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3908), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3909), "Country", 1L, "Country", 1 },
                    { 7L, "city", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3912), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3912), "City", 1L, "City", 1 },
                    { 8L, "rgn", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3914), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3915), "Region", 1L, "Region", 1 },
                    { 9L, "sdg", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3923), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3923), "Sustainable Development", 1L, "SDG", 1 },
                    { 10L, "liro", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3925), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3926), "Line Of Reporting", 1L, "Line Of Reporting", 1 },
                    { 11L, "domn", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3928), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3928), "Domain", 1L, "Domain", 1 },
                    { 12L, "bsnss", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3930), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3931), "Business", 1L, "Business", 1 },
                    { 13L, "mrkt", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3933), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3933), "Market", 1L, "Market", 1 },
                    { 14L, "factory", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3935), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3935), "Factory", 1L, "Factory", 1 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationHeirarchies",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "HierarchyId", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State" },
                values: new object[] { 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5941), 2L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5942), 1L, 1 });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4427), null, null, 1L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4429), null, null, 1L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4430), null, null, 1L, 0, 3L },
                    { 4L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4432), null, null, 2L, 0, 4L },
                    { 5L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4433), null, null, 2L, 0, 5L },
                    { 6L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4434), null, null, 2L, 0, 6L },
                    { 7L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4435), null, null, 3L, 0, 7L },
                    { 8L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4436), null, null, 3L, 0, 8L },
                    { 9L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4437), null, null, 3L, 0, 9L },
                    { 10L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4438), null, null, 4L, 0, 10L },
                    { 11L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4439), null, null, 4L, 0, 11L },
                    { 12L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4440), null, null, 4L, 0, 12L },
                    { 13L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4441), null, null, 5L, 0, 13L },
                    { 14L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4441), null, null, 5L, 0, 14L },
                    { 15L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4442), null, null, 5L, 0, 15L },
                    { 16L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4443), null, null, 6L, 0, 16L },
                    { 17L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4444), null, null, 6L, 0, 17L },
                    { 18L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4445), null, null, 6L, 0, 18L },
                    { 19L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4431), null, null, 1L, 0, 101L },
                    { 20L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4431), null, null, 1L, 0, 102L }
                });

            migrationBuilder.InsertData(
                table: "Standard",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State", "TopicId" },
                values: new object[,]
                {
                    { 1L, "ESRS2_GP", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4489), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4490), "General principles", "General principles", 1, 1L },
                    { 2L, "ESRS2_MDR", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4492), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4493), "General disclosures", "General disclosures", 1, 1L },
                    { 3L, "E1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4495), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4495), "Climate change", "Climate change", 1, 2L },
                    { 4L, "E2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4497), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4498), "Pollution", "Pollution", 1, 2L },
                    { 5L, "E3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4499), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4500), "Water & marine resources", "Water & marine resources", 1, 2L },
                    { 6L, "E4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4505), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4506), "Biodiversity and eco systems", "Biodiversity and eco systems", 1, 2L },
                    { 7L, "E5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4507), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4508), "Resourtce use and circular economy", "Resourtce use and circular economy", 1, 2L },
                    { 8L, "S1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4509), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4510), "Own workforce", "Own workforce", 1, 3L },
                    { 9L, "S2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4511), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4512), "Workers in value chain", "Workers in value chain", 1, 3L },
                    { 10L, "S3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4513), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4514), "Affected communities", "Affected communities", 1, 3L },
                    { 11L, "S4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4515), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4516), "Consumers and end-users", "Consumers and end-users", 1, 3L },
                    { 12L, "G1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4517), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4518), "Business Conduct", "Business Conduct", 1, 4L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "acidbasecapacity", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4598), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4599), "Acid/Base capacity", "Acid/Base capacity", 1L, "Acid/Base capacity", 1 },
                    { 2L, "area", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4602), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4603), "Area", "Area", 1L, "Area", 1 },
                    { 3L, "density", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4604), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4605), "Density", "Density", 1L, "Density", 1 },
                    { 4L, "energy", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4606), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4607), "Energy", "Energy", 1L, "Energy", 1 },
                    { 5L, "force", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4608), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4609), "Force", "Force", 1L, "Force", 1 },
                    { 6L, "frequency", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4611), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4611), "Frequency", "Frequency", 1L, "Frequency", 1 },
                    { 7L, "heat_conductivity", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4613), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4613), "Heat Conductivity", "Heat Conductivity", 1L, "Heat Conductivity", 1 },
                    { 8L, "hydrolysis_rate", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4615), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4615), "Hydrolysis rate", "Hydrolysis rate", 1L, "Hydrolysis rate", 1 },
                    { 9L, "inverse_area", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4618), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4618), "Inverse area", "Inverse area", 1L, "Inverse area", 1 },
                    { 10L, "kinematic_viscosity", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4620), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4620), "Kinematic viscosity", "Kinematic viscosity", 1L, "Kinematic viscosity", 1 },
                    { 11L, "length", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4622), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4623), "Length", "Length", 1L, "Length", 1 },
                    { 12L, "luminous_intensity", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4624), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4625), "Luminous intensity", "Luminous intensity", 1L, "Luminous intensity", 1 },
                    { 13L, "magnet_field_dens", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4626), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4627), "Magnet. field dens.", "Magnet. field dens.", 1L, "Magnet. field dens.", 1 },
                    { 14L, "mass", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4628), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4629), "Mass", "Mass", 1L, "Mass", 1 },
                    { 15L, "mass_coverage", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4630), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4631), "Mass coverage", "Mass coverage", 1L, "Mass coverage", 1 },
                    { 16L, "mass_flow", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4632), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4633), "Mass flow", "Mass flow", 1L, "Mass flow", 1 },
                    { 17L, "mass_per_energy", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4637), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4637), "Mass per Energy", "Mass per Energy", 1L, "Mass per Energy", 1 },
                    { 18L, "mass_proportion", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4639), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4639), "Mass proportion", "Mass proportion", 1L, "Mass proportion", 1 },
                    { 19L, "proportion", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4641), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4641), "Proportion", "Proportion", 1L, "Proportion", 1 },
                    { 20L, "time", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4643), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4644), "Time", "Time", 1L, "Time", 1 },
                    { 21L, "vaporization_speed", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4645), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4646), "Vaporization Speed", "Vaporization Speed", 1L, "Vaporization Speed", 1 },
                    { 22L, "volume", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4651), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4652), "Volume", "Volume", 1L, "Volume", 1 },
                    { 23L, "volume_proportion", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4653), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4654), "Volume proportion", "Volume proportion", 1L, "Volume proportion", 1 },
                    { 24L, "volume_rate_of_flow", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4655), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4656), "Volume rate of flow", "Volume rate of flow", 1L, "Volume rate of flow", 1 },
                    { 121L, "monetary", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4658), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4659), "Monetary", "Monetary", 1L, "Monetary", 1 },
                    { 126L, "narrative", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4660), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4661), "Text", "Text", 1L, "Text", 1 },
                    { 131L, "number", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4662), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4663), "Number", "Number", 1L, "Number", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5594), null, null, 2L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5595), null, null, 3L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5597), null, null, 3L, 0, 3L },
                    { 4L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5599), null, null, 2L, 0, 4L },
                    { 5L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5600), null, null, 3L, 0, 5L },
                    { 6L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5602), null, null, 3L, 0, 6L },
                    { 7L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5603), null, null, 2L, 0, 7L },
                    { 8L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5604), null, null, 3L, 0, 8L },
                    { 9L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5605), null, null, 3L, 0, 9L },
                    { 10L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5606), null, null, 2L, 0, 10L },
                    { 11L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5611), null, null, 3L, 0, 11L },
                    { 12L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5612), null, null, 3L, 0, 12L },
                    { 13L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5613), null, null, 2L, 0, 13L },
                    { 14L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5614), null, null, 3L, 0, 14L },
                    { 15L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5615), null, null, 3L, 0, 15L },
                    { 16L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5617), null, null, 2L, 0, 16L },
                    { 17L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5618), null, null, 3L, 0, 17L },
                    { 18L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5619), null, null, 3L, 0, 18L },
                    { 19L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5620), null, null, 1L, 0, 101L },
                    { 20L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5621), null, null, 1L, 0, 102L }
                });

            migrationBuilder.InsertData(
                table: "DataPointValue",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "CurrencyId", "DatapointTypeId", "DisclosureRequirementId", "IsNarrative", "LanguageId", "LastModifiedBy", "LastModifiedDate", "ModelFilterCombinationId", "Name", "OrganizationId", "Purpose", "State", "UnitOfMeasureId", "UserId" },
                values: new object[,]
                {
                    { 10044L, "E1.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(531), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 10054L, "E1.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(558), null, 2L, null, null, 1L, null, null, null, "Disclosure to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 10217L, "BP-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(971), null, 3L, null, null, 1L, null, null, null, "Basis for preparation of sustainability statement", 1L, "", 0, null, null },
                    { 10363L, "MDR-P_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1353), null, 2L, null, true, 1L, null, null, null, "MDR-P_06", 1L, "", 0, null, null },
                    { 10405L, "E2.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1460), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 10411L, "E2.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1479), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 10424L, "E2.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1512), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 10484L, "E3.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1662), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 10489L, "E3.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1674), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 10501L, "E3.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1704), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 10581L, "E4.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1910), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 10599L, "E4.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1957), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 10611L, "E4.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1989), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 10652L, "E5.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2092), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 10664L, "E5.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2125), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 10679L, "E5.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2163), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 10712L, "S1.SBM-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2248), null, 2L, null, null, 1L, null, null, null, "All people in its own workforce who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 0, null, null },
                    { 10747L, "S1.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2336), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 10795L, "S1.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2467), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 10803L, "S1.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2485), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 10931L, "S2.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2813), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 10972L, "S2.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2919), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 10980L, "S2.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2937), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 10999L, "S3.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2982), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 11041L, "S3.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3087), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 11049L, "S3.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3110), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 11068L, "S4.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3158), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 11110L, "S4.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3266), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null },
                    { 11118L, "S4.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3290), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 0, null, null },
                    { 11137L, "G1.MDR-P_07-08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3337), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 0, null, null },
                    { 11168L, "G1.MDR-A_13-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3417), null, 2L, null, null, 1L, null, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DimensionTypeId", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1000L, "act", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3968), 5L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3969), "Actual", 1L, "Actual", 1 },
                    { 1001L, "base", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3972), 5L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3973), "Baseline", 1L, "Baseline", 1 },
                    { 1002L, "target", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3975), 5L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3976), "Target", 1L, "Target", 1 },
                    { 1003L, "de", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3978), 6L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3978), "Germany", 1L, "DE", 1 },
                    { 1004L, "nl", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3980), 6L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3981), "The Netherlands", 1L, "NL", 1 },
                    { 1005L, "dap", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3983), 12L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3983), "Domestic Appliances", 1L, "DAP", 1 },
                    { 1006L, "pms", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3986), 12L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3986), "Medical systems", 1L, "PMS", 1 },
                    { 1007L, "eur", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3988), 13L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3989), "Europe", 1L, "EUR", 1 },
                    { 1008L, "ame", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3991), 13L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3991), "Africa, Middle East", 1L, "AME", 1 },
                    { 1009L, "tern", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3993), 14L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3994), "Terneuzen", 1L, "Terneuzen", 1 },
                    { 1010L, "2023", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3995), 1L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3996), "2023", 1L, "2023", 1 },
                    { 1011L, "2024", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3998), 1L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3998), "2024", 1L, "2024", 1 },
                    { 1012L, "2025", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4000), 1L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4001), "2025", 1L, "2025", 1 }
                });

            migrationBuilder.InsertData(
                table: "DisclosureRequirement",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "StandardId", "State" },
                values: new object[,]
                {
                    { 1L, "BP-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4068), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4069), "General basis for preparation of sustainability statements", "General basis for preparation of sustainability statements", 1L, 1 },
                    { 2L, "BP-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4071), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4072), "Disclosures in relation to specific circumstances", "Disclosures in relation to specific circumstances", 1L, 1 },
                    { 3L, "GOV-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4074), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4075), "The role of the administrative, management and supervisory bodies", "The role of the administrative, management and supervisory bodies", 1L, 1 },
                    { 4L, "GOV-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4076), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4077), "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", 1L, 1 },
                    { 5L, "GOV-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4079), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4079), "Integration of sustainability-related performance in incentive schemes", "Integration of sustainability-related performance in incentive schemes", 1L, 1 },
                    { 6L, "GOV-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4082), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4083), "Statement on due diligence", "Statement on due diligence", 1L, 1 },
                    { 7L, "GOV-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4085), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4085), "Risk management and internal controls over sustainability reporting", "Risk management and internal controls over sustainability reporting", 1L, 1 },
                    { 8L, "SBM-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4087), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4088), "Strategy, business model and value chain", "Strategy, business model and value chain", 1L, 1 },
                    { 9L, "SBM-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4089), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4090), "Interests and views of stakeholders", "Interests and views of stakeholders", 1L, 1 },
                    { 10L, "SBM-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4092), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4092), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 1L, 1 },
                    { 11L, "IRO-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4094), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4095), "Description of the process to identify and assess material impacts, risks and opportunities", "Description of the process to identify and assess material impacts, risks and opportunities", 1L, 1 },
                    { 12L, "IRO-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4096), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4097), "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", 1L, 1 },
                    { 13L, "MDR-P", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4099), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4100), "Policies adopted to manage material sustainability matters", "Policies adopted to manage material sustainability matters", 2L, 1 },
                    { 14L, "MDR-A", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4102), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4102), "Actions and resources in relation to material sustainability matters", "Actions and resources in relation to material sustainability matters", 2L, 1 },
                    { 15L, "MDR-M", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4104), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4104), "Metrics in relation to material sustainability matters", "Metrics in relation to material sustainability matters", 2L, 1 },
                    { 16L, "MDR-T", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4106), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4106), "Tracking effectiveness of policies and actions through targets", "Tracking effectiveness of policies and actions through targets", 2L, 1 },
                    { 17L, "E1.GOV-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4108), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4109), "Integration of sustainability-related performance in incentive schemes", "Integration of sustainability-related performance in incentive schemes", 3L, 1 },
                    { 18L, "E1-1 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4110), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4111), "Transition plan for climate change mitigation", "Transition plan for climate change mitigation", 3L, 1 },
                    { 19L, "E1.SBM-3 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4112), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4113), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 3L, 1 },
                    { 20L, "E1.IRO-1 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4114), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4115), "Description of the processes to identify and assess material climate-related impacts, risks and opportunities", "Description of the processes to identify and assess material climate-related impacts, risks and opportunities", 3L, 1 },
                    { 21L, "E1-2 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4117), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4118), "Policies related to climate change mitigation and adaptation", "Policies related to climate change mitigation and adaptation", 3L, 1 },
                    { 22L, "E1-3 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4120), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4120), "Actions and resources in relation to climate change policies", "Actions and resources in relation to climate change policies", 3L, 1 },
                    { 23L, "E1-4 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4122), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4122), "Targets related to climate change mitigation and adaptation", "Targets related to climate change mitigation and adaptation", 3L, 1 },
                    { 24L, "E1-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4124), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4124), "Energy consumption and mix", "Energy consumption and mix", 3L, 1 },
                    { 25L, "E1-6", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4126), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4127), "Gross Scopes 1, 2, 3 and Total GHG emissions", "Gross Scopes 1, 2, 3 and Total GHG emissions", 3L, 1 },
                    { 26L, "E1-7 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4128), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4129), "GHG removals and GHG mitigation projects financed through carbon credits", "GHG removals and GHG mitigation projects financed through carbon credits", 3L, 1 },
                    { 27L, "E1-8 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4130), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4131), "Internal carbon pricing", "Internal carbon pricing", 3L, 1 },
                    { 28L, "E1-9 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4132), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4133), "Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", "Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", 3L, 1 },
                    { 29L, "E2.IRO-1 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4135), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4136), "Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", "Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 30L, "E2-1 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4137), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4138), "Policies related to pollution", "Policies related to pollution", 4L, 1 },
                    { 31L, "E2-2 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4139), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4140), "Actions and resources related to pollution", "Actions and resources related to pollution", 4L, 1 },
                    { 32L, "E2-3 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4141), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4142), "Targets related to pollution", "Targets related to pollution", 4L, 1 },
                    { 33L, "E2-4 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4144), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4144), "Pollution of air, water and soil", "Pollution of air, water and soil", 4L, 1 },
                    { 34L, "E2-5 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4146), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4146), "Substances of concern and substances of very high concern", "Substances of concern and substances of very high concern", 4L, 1 },
                    { 35L, "E2-6 ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4148), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4148), "Anticipated financial effects from pollution-related impacts, risks and opportunities", "Anticipated financial effects from pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 36L, "E3.IRO-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4151), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4151), "Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", "Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 37L, "E3-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4153), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4153), "Policies related to water and marine resources", "Policies related to water and marine resources", 5L, 1 },
                    { 38L, "E3-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4160), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4160), "Actions and resources related to water and marine resources", "Actions and resources related to water and marine resources", 5L, 1 },
                    { 39L, "E3-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4162), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4162), "Targets related to water and marine resources", "Targets related to water and marine resources", 5L, 1 },
                    { 40L, "E3-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4164), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4164), "Water consumption", "Water consumption", 5L, 1 },
                    { 41L, "E3-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4166), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4166), "Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", "Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 42L, "E4.SBM-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4168), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4168), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 6L, 1 },
                    { 43L, "E4.IRO-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4170), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4171), "Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", "Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", 6L, 1 },
                    { 44L, "E4-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4173), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4173), "Transition plan and consideration of biodiversity and ecosystems in strategy and business model", "Transition plan and consideration of biodiversity and ecosystems in strategy and business model", 6L, 1 },
                    { 45L, "E4-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4175), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4176), "Policies related to biodiversity and ecosystems", "Policies related to biodiversity and ecosystems", 6L, 1 },
                    { 46L, "E4-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4177), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4178), "Actions and resources related to biodiversity and ecosystems", "Actions and resources related to biodiversity and ecosystems", 6L, 1 },
                    { 47L, "E4-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4179), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4180), "Targets related to biodiversity and ecosystems", "Targets related to biodiversity and ecosystems", 6L, 1 },
                    { 48L, "E4-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4181), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4182), "Impact metrics related to biodiversity and ecosystems change", "Impact metrics related to biodiversity and ecosystems change", 6L, 1 },
                    { 49L, "E4-6", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4183), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4184), "Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", "Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", 6L, 1 },
                    { 50L, "E5.IRO-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4185), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4186), "Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", "Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 51L, "E5-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4188), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4189), "Policies related to resource use and circular economy", "Policies related to resource use and circular economy", 7L, 1 },
                    { 52L, "E5-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4190), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4191), "Actions and resources related to resource use and circular economy", "Actions and resources related to resource use and circular economy", 7L, 1 },
                    { 53L, "E5-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4192), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4193), "Targets related to resource use and circular economy", "Targets related to resource use and circular economy", 7L, 1 },
                    { 54L, "E5-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4194), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4195), "Resource inflows", "Resource inflows", 7L, 1 },
                    { 55L, "E5-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4196), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4197), "Resource outflows", "Resource outflows", 7L, 1 },
                    { 56L, "E5-6", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4198), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4199), "Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", "Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 58L, "S1.SBM-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4202), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4203), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 8L, 1 },
                    { 59L, "S1-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4205), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4206), "Policies related to own workforce", "Policies related to own workforce", 8L, 1 },
                    { 60L, "S1-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4207), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4208), "Processes for engaging with own workforce and workers’ representatives about impacts", "Processes for engaging with own workforce and workers’ representatives about impacts", 8L, 1 },
                    { 61L, "S1-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4209), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4210), "Processes to remediate negative impacts and channels for own workforce to raise concerns", "Processes to remediate negative impacts and channels for own workforce to raise concerns", 8L, 1 },
                    { 62L, "S1-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4211), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4212), "Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", "Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", 8L, 1 },
                    { 63L, "S1-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4213), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4214), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 8L, 1 },
                    { 64L, "S1-6", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4215), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4216), "Characteristics of the undertaking’s employees", "Characteristics of the undertaking’s employees", 8L, 1 },
                    { 65L, "S1-7", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4217), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4218), "Characteristics of non-employees in the undertaking’s own workforce", "Characteristics of non-employees in the undertaking’s own workforce", 8L, 1 },
                    { 66L, "S1-8", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4220), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4221), "Collective bargaining coverage and social dialogue", "Collective bargaining coverage and social dialogue", 8L, 1 },
                    { 67L, "S1-9", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4222), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4223), "Diversity metrics", "Diversity metrics", 8L, 1 },
                    { 68L, "S1-10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4224), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4225), "Adequate wages", "Adequate wages", 8L, 1 },
                    { 69L, "S1-11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4226), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4227), "Social protection", "Social protection", 8L, 1 },
                    { 70L, "S1-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4228), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4229), "Persons with disabilities", "Persons with disabilities", 8L, 1 },
                    { 71L, "S1-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4230), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4231), "Training and skills development metrics", "Training and skills development metrics", 8L, 1 },
                    { 72L, "S1-14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4232), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4233), "Health and safety metrics", "Health and safety metrics", 8L, 1 },
                    { 73L, "S1-15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4234), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4235), "Work-life balance metrics", "Work-life balance metrics", 8L, 1 },
                    { 74L, "S1-16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4237), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4237), "Remuneration metrics (pay gap and total remuneration)", "Remuneration metrics (pay gap and total remuneration)", 8L, 1 },
                    { 75L, "S1-17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4239), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4239), "Incidents, complaints and severe human rights impacts", "Incidents, complaints and severe human rights impacts", 8L, 1 },
                    { 77L, "S2.SBM-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4243), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4243), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 9L, 1 },
                    { 78L, "S2-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4245), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4245), "Policies related to value chain workers", "Policies related to value chain workers", 9L, 1 },
                    { 79L, "S2-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4247), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4248), "Processes for engaging with value chain workers about impacts", "Processes for engaging with value chain workers about impacts", 9L, 1 },
                    { 80L, "S2-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4249), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4250), "Processes to remediate negative impacts and channels for value chain workers to raise concerns", "Processes to remediate negative impacts and channels for value chain workers to raise concerns", 9L, 1 },
                    { 81L, "S2-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4251), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4252), "Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", "Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", 9L, 1 },
                    { 82L, "S2-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4254), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4254), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 9L, 1 },
                    { 84L, "S3.SBM-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4260), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4261), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 10L, 1 },
                    { 85L, "S3-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4262), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4263), "Policies related to affected communities", "Policies related to affected communities", 10L, 1 },
                    { 86L, "S3-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4264), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4265), "Processes for engaging with affected communities about impacts", "Processes for engaging with affected communities about impacts", 10L, 1 },
                    { 87L, "S3-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4266), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4267), "Processes to remediate negative impacts and channels for affected communities to raise concerns", "Processes to remediate negative impacts and channels for affected communities to raise concerns", 10L, 1 },
                    { 88L, "S3-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4269), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4269), "aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", "aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", 10L, 1 },
                    { 89L, "S3-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4271), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4271), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", 10L, 1 },
                    { 91L, "S4.SBM-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4275), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4276), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 11L, 1 },
                    { 92L, "S4-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4277), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4278), "Policies related to consumers and end-users", "Policies related to consumers and end-users", 11L, 1 },
                    { 93L, "S4-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4279), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4280), "Processes for engaging with consumers and end-users about impacts", "Processes for engaging with consumers and end-users about impacts", 11L, 1 },
                    { 94L, "S4-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4281), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4282), "Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", "Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", 11L, 1 },
                    { 95L, "S4-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4283), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4284), "Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", "Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", 11L, 1 },
                    { 96L, "S4-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4285), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4286), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 11L, 1 },
                    { 97L, "G1.GOV-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4287), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4288), "The role of the administrative, supervisory and management bodies", "The role of the administrative, supervisory and management bodies", 12L, 1 },
                    { 98L, "G1-1", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4289), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4290), "Business conduct policies and corporate culture", "Business conduct policies and corporate culture", 12L, 1 },
                    { 99L, "G1-2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4292), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4292), "Management of relationships with suppliers", "Management of relationships with suppliers", 12L, 1 },
                    { 100L, "G1-3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4294), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4294), "Prevention and detection of corruption and bribery", "Prevention and detection of corruption and bribery", 12L, 1 },
                    { 101L, "G1-4", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4296), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4296), "Incidents of corruption or bribery", "Incidents of corruption or bribery", 12L, 1 },
                    { 102L, "G1-5", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4298), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4298), "Political influence and lobbying activities", "Political influence and lobbying activities", 12L, 1 },
                    { 103L, "G1-6", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4300), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4300), "Payment practices", "Payment practices", 12L, 1 }
                });

            migrationBuilder.InsertData(
                table: "ModelConfiguration",
                columns: new[] { "Id", "ColumnId", "CreatedBy", "CreatedDate", "DataModelId", "LastModifiedBy", "LastModifiedDate", "RowId", "State", "ViewType" },
                values: new object[,]
                {
                    { 10000L, 5L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5863), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5864), 1L, 1, 1 },
                    { 10001L, null, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5866), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5867), 1L, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ModelDimensionTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataModelId", "DimensionTypeId", "LastModifiedBy", "LastModifiedDate", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5808), 1L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5810), 1 },
                    { 2L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5812), 1L, 5L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5813), 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypeTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureTypeId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5123), 1001L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5124), "Acid/Base capacity", "Acid/Base capacity", "Acid/Base capacity", 1 },
                    { 1L, 2L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5126), 1002L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5127), "Area", "Area", "Area", 1 },
                    { 1L, 3L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5129), 1003L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5129), "Density", "Density", "Density", 1 },
                    { 1L, 4L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5131), 1004L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5131), "Energy", "Energy", "Energy", 1 },
                    { 1L, 5L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5133), 1005L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5134), "Force", "Force", "Force", 1 },
                    { 1L, 6L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5135), 1006L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5136), "Frequency", "Frequency", "Frequency", 1 },
                    { 1L, 7L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5139), 1007L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5140), "Heat Conductivity", "Heat Conductivity", "Heat Conductivity", 1 },
                    { 1L, 8L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5142), 1008L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5142), "Hydrolysis rate", "Hydrolysis rate", "Hydrolysis rate", 1 },
                    { 1L, 9L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5144), 1009L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5144), "Inverse area", "Inverse area", "Inverse area", 1 },
                    { 1L, 10L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5146), 1010L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5146), "Kinematic viscosity", "Kinematic viscosity", "Kinematic viscosity", 1 },
                    { 1L, 11L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5148), 1011L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5149), "Length", "Length", "Length", 1 },
                    { 1L, 12L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5150), 1012L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5151), "Luminous intensity", "Luminous intensity", "Luminous intensity", 1 },
                    { 1L, 13L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5152), 1013L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5153), "Magnet. field dens.", "Magnet. field dens.", "Magnet. field dens.", 1 },
                    { 1L, 14L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5154), 1014L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5155), "Mass", "Mass", "Mass", 1 },
                    { 1L, 15L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5157), 1015L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5157), "Mass coverage", "Mass coverage", "Mass coverage", 1 },
                    { 1L, 16L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5159), 1016L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5159), "Mass flow", "Mass flow", "Mass flow", 1 },
                    { 1L, 17L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5161), 1017L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5161), "Mass per Energy", "Mass per Energy", "Mass per Energy", 1 },
                    { 1L, 18L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5163), 1018L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5163), "Mass proportion", "Mass proportion", "Mass proportion", 1 },
                    { 1L, 19L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5164), 1019L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5165), "Proportion", "Proportion", "Proportion", 1 },
                    { 1L, 20L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5166), 1020L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5167), "Time", "Time", "Time", 1 },
                    { 1L, 21L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5168), 1021L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5168), "Vaporization Speed", "Vaporization Speed", "Vaporization Speed", 1 },
                    { 1L, 22L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5170), 1022L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5170), "Volume", "Volume", "Volume", 1 },
                    { 1L, 23L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5172), 1023L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5173), "Volume proportion", "Volume proportion", "Volume proportion", 1 },
                    { 1L, 24L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5174), 1024L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5175), "Volume rate of flow", "Volume rate of flow", "Volume rate of flow", 1 },
                    { 1L, 121L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5176), 1121L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5177), "Monetary", "Monetary", "Monetary", 1 },
                    { 1L, 126L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5178), 1126L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5178), "Text", "Text", "Text", 1 },
                    { 1L, 131L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5180), 1131L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5180), "Number", "Number", "Number", 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 1L, "hh", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4693), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4693), "Hour", "Hour", 1L, "Hr", 1, 20L },
                    { 2L, "mm", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4696), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4697), "Minute", "Minute", 1L, "Min", 1, 20L },
                    { 3L, "ss", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4699), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4699), "Second", "Second", 1L, "Sec", 1, 20L },
                    { 4L, "d", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4701), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4701), "Day", "Day", 1L, "Day", 1, 20L },
                    { 5L, "m", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4703), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4704), "Month", "Month", 1L, "Month", 1, 20L },
                    { 6L, "q", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4706), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4706), "Quarter", "Quarter", 1L, "Qrtr", 1, 20L },
                    { 7L, "y", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4708), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4708), "Year", "Year", 1L, "Year", 1, 20L },
                    { 8L, "mMol/l", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4710), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4711), "Millimol per liter", "Millimol per liter", 1L, "mMol/l", 1, 1L },
                    { 9L, "Mol/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4712), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4713), "Mol per cubic meter", "Mol per cubic meter", 1L, "Mol/m3", 1, 1L },
                    { 10L, "Mol/l", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4715), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4715), "Mol per liter", "Mol per liter", 1L, "Mol/l", 1, 1L },
                    { 11L, "acre", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4717), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4717), "Acre", "Acre", 1L, "Acre", 1, 2L },
                    { 12L, "ha", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4719), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4720), "Hectare", "Hectare", 1L, "Ha", 1, 2L },
                    { 13L, "yd2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4722), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4723), "Square Yard", "Square Yard", 1L, "Yd2", 1, 2L },
                    { 14L, "cm2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4725), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4725), "Square centimeter", "Square centimeter", 1L, "Cm2", 1, 2L },
                    { 15L, "ft2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4727), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4727), "Square foot", "Square foot", 1L, "Ft2", 1, 2L },
                    { 16L, "Inch2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4729), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4730), "Square inch", "Square inch", 1L, "Inch2", 1, 2L },
                    { 17L, "km2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4731), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4732), "Square kilometer", "Square kilometer", 1L, "Km2", 1, 2L },
                    { 18L, "m2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4734), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4734), "Square meter", "Square meter", 1L, "M2", 1, 2L },
                    { 19L, "Mile2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4736), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4736), "Square mile", "Square mile", 1L, "Mile2", 1, 2L },
                    { 20L, "mm2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4738), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4739), "Square millimeter", "Square millimeter", 1L, "Mm2", 1, 2L },
                    { 21L, "g/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4741), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4741), "Gram/Cubic meter", "Gram/Cubic meter", 1L, "G/M3", 1, 3L },
                    { 22L, "g/cm3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4747), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4748), "Gram/cubic centimeter", "Gram/cubic centimeter", 1L, "G/Cm3", 1, 3L },
                    { 23L, "g/l", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4749), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4750), "Gram/liter", "Gram/liter", 1L, "G/L", 1, 3L },
                    { 24L, "kg/scf", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4751), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4752), "Kilogram/Standard Cubic Foot", "Kilogram/Standard Cubic Foot", 1L, "Kg/Scf", 1, 3L },
                    { 25L, "kg/bbl", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4754), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4754), "Kilogram/US Barrel", "Kilogram/US Barrel", 1L, "Kg/Bbl", 1, 3L },
                    { 26L, "kg/dm3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4756), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4756), "Kilogram/cubic decimeter", "Kilogram/cubic decimeter", 1L, "Kg/Dm3", 1, 3L },
                    { 27L, "kg/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4758), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4759), "Kilogram/cubic meter", "Kilogram/cubic meter", 1L, "Kg/M3", 1, 3L },
                    { 28L, "µg/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4761), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4762), "Microgram/cubic meter", "Microgram/cubic meter", 1L, "µg/M3", 1, 3L },
                    { 29L, "µg/l", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4764), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4764), "Microgram/liter", "Microgram/liter", 1L, "µg/L", 1, 3L },
                    { 30L, "mg/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4766), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4766), "Milligram/cubic meter", "Milligram/cubic meter", 1L, "Mg/M3", 1, 3L },
                    { 31L, "mg/l", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4768), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4769), "Milligram/liter", "Milligram/liter", 1L, "Mg/L", 1, 3L },
                    { 32L, "t/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4770), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4771), "Ton/Cubic meter", "Ton/Cubic meter", 1L, "T/M3", 1, 3L },
                    { 33L, "t/tm3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4772), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4773), "Tonne/1000 Cubic Meters", "Tonne/1000 Cubic Meters", 1L, "T/Tm3", 1, 3L },
                    { 34L, "t/bbl", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4775), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4775), "Tonne/US Barrel", "Tonne/US Barrel", 1L, "T/Bbl", 1, 3L },
                    { 35L, "lb/scf", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4777), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4777), "US Pound/Standard Cubic Foot", "US Pound/Standard Cubic Foot", 1L, "Lb/Scf", 1, 3L },
                    { 36L, "lb/gal", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4780), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4780), "US Pound/US Gallon", "US Pound/US Gallon", 1L, "Lb/Gal", 1, 3L },
                    { 37L, "ton/gl", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4782), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4783), "US Tonne/US Gallon", "US Tonne/US Gallon", 1L, "Ton/Gl", 1, 3L },
                    { 38L, "percent", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4784), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4785), "Percentage", "Percentage", 1L, "%", 1, 131L },
                    { 39L, "GJ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4786), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4787), "Gigajoule", "Gigajoule", 1L, "Gj", 1, 4L },
                    { 40L, "J", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4789), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4789), "Joule", "Joule", 1L, "J", 1, 4L },
                    { 41L, "kJ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4791), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4791), "Kilojoule", "Kilojoule", 1L, "Kj", 1, 4L },
                    { 42L, "kwh", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4793), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4793), "Kilowatt hours", "Kilowatt hours", 1L, "Kwh", 1, 4L },
                    { 43L, "MJ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4795), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4796), "Megajoule", "Megajoule", 1L, "Mj", 1, 4L },
                    { 44L, "MWh", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4798), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4799), "Megawatt hour", "Megawatt hour", 1L, "Mwh", 1, 4L },
                    { 45L, "mJ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4800), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4801), "Millijoule", "Millijoule", 1L, "Mj", 1, 4L },
                    { 46L, "KCAL", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4803), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4803), "kilocalories", "kilocalories", 1L, "Kcal", 1, 4L },
                    { 47L, "ND", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4805), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4805), "Kilonewton", "Kilonewton", 1L, "Nd", 1, 5L },
                    { 48L, "MN", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4807), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4808), "Meganewton", "Meganewton", 1L, "Mn", 1, 5L },
                    { 49L, "N", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4809), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4810), "Newton", "Newton", 1L, "N", 1, 5L },
                    { 50L, "1/min", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4811), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4812), "1/minute", "1/minute", 1L, "1/Min", 1, 6L },
                    { 51L, "BPM", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4814), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4814), "Bottles per minute", "Bottles per minute", 1L, "Bpm", 1, 6L },
                    { 52L, "1/second)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4817), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4817), "Hertz", "Hertz", 1L, "1/Second)", 1, 6L },
                    { 53L, "kHz", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4819), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4819), "Kilohertz", "Kilohertz", 1L, "Khz", 1, 6L },
                    { 54L, "MHz", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4821), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4821), "Megahertz", "Megahertz", 1L, "Mhz", 1, 6L },
                    { 55L, "RPM", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4823), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4823), "RPM", "RPM", 1L, "Rpm", 1, 6L },
                    { 56L, "W/mk", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4829), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4830), "Heat Conductivity", "Heat Conductivity", 1L, "W/Mk", 1, 7L },
                    { 57L, "l/m_.s", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4831), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4832), "Liter/Molsecond", "Liter/Molsecond", 1L, "L/M_.S", 1, 8L },
                    { 58L, "1/M2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4834), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4834), "1 / square meter", "1 / square meter", 1L, "1/M2", 1, 9L },
                    { 59L, "US)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4837), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4837), "Miles per gallon", "Miles per gallon", 1L, "Us)", 1, 2L },
                    { 60L, "m2/s", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4839), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4839), "Square meter/second", "Square meter/second", 1L, "M2/S", 1, 10L },
                    { 61L, "mm2/s", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4841), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4841), "Square millimeter/second", "Square millimeter/second", 1L, "Mm2/S", 1, 10L },
                    { 62L, "cm", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4843), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4844), "Centimeter", "Centimeter", 1L, "Cm", 1, 11L },
                    { 63L, "dm", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4845), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4846), "Decimeter", "Decimeter", 1L, "Dm", 1, 11L },
                    { 64L, "ft", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4847), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4848), "Foot", "Foot", 1L, "Foot", 1, 11L },
                    { 65L, "inch", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4850), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4850), "Inch", "Inch", 1L, "Inch", 1, 11L },
                    { 66L, "km", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4852), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4852), "Kilometer", "Kilometer", 1L, "Km", 1, 11L },
                    { 67L, "m", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4855), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4855), "Meter", "Meter", 1L, "M", 1, 11L },
                    { 68L, "µm", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4857), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4857), "Micrometer", "Micrometer", 1L, "µm", 1, 11L },
                    { 69L, "mile", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4859), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4860), "Mile", "Mile", 1L, "Mile", 1, 11L },
                    { 70L, "mm", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4861), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4862), "Millimeter", "Millimeter", 1L, "Mm", 1, 11L },
                    { 71L, "nm", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4864), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4864), "Nanometer", "Nanometer", 1L, "Nm", 1, 11L },
                    { 72L, "yd", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4866), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4866), "Yards", "Yards", 1L, "Yd", 1, 11L },
                    { 73L, "cd", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4868), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4868), "Candela", "Candela", 1L, "Cd", 1, 12L },
                    { 74L, "D", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4870), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4870), "Tesla", "Tesla", 1L, "D", 1, 13L },
                    { 75L, "g", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4873), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4873), "Gram", "Gram", 1L, "G", 1, 14L },
                    { 76L, "kt", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4875), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4876), "Kilotonne", "Kilotonne", 1L, "Kt", 1, 14L },
                    { 77L, "mg", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4877), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4878), "Milligram", "Milligram", 1L, "Mg", 1, 14L },
                    { 78L, "oz", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4879), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4880), "Ounce", "Ounce", 1L, "Oz", 1, 14L },
                    { 79L, "t", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4882), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4882), "Tonne", "Tonne", 1L, "T", 1, 14L },
                    { 80L, "lb", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4884), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4884), "US pound", "US pound", 1L, "Lb", 1, 14L },
                    { 81L, "ton", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4886), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4886), "US ton", "US ton", 1L, "Ton", 1, 14L },
                    { 82L, "kg", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4890), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4891), "Kilogram", "Kilogram", 1L, "Kg", 1, 14L },
                    { 83L, "g/m2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4892), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4893), "Gram/square meter", "Gram/square meter", 1L, "G/M2", 1, 15L },
                    { 84L, "kg/m2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4894), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4895), "Kilogram/Square meter", "Kilogram/Square meter", 1L, "Kg/M2", 1, 15L },
                    { 85L, "mg/cm2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4897), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4897), "Milligram/Square centimeter", "Milligram/Square centimeter", 1L, "Mg/Cm2", 1, 15L },
                    { 86L, "kg/s", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4899), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4899), "Kilogram/second", "Kilogram/second", 1L, "Kg/S", 1, 16L },
                    { 87L, "kg/J", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4901), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4901), "Kilogram/Joule", "Kilogram/Joule", 1L, "Kg/J", 1, 17L },
                    { 88L, "kg/MB", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4903), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4903), "Kilogram/Million BTU", "Kilogram/Million BTU", 1L, "Kg/Mb", 1, 17L },
                    { 89L, "t/Btu", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4905), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4905), "Tonne/British Thermal Unit", "Tonne/British Thermal Unit", 1L, "T/Btu", 1, 17L },
                    { 90L, "t/Joul", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4910), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4911), "Tonne/Joule", "Tonne/Joule", 1L, "T/Joul", 1, 17L },
                    { 91L, "t/TJ", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4913), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4913), "Tonne/Terajoule", "Tonne/Terajoule", 1L, "T/Tj", 1, 17L },
                    { 92L, "lb/Btu", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4915), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4915), "US Pound/British Thermal Unit", "US Pound/British Thermal Unit", 1L, "Lb/Btu", 1, 17L },
                    { 93L, "lb/MB", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4917), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4917), "US Pound/Million BTU", "US Pound/Million BTU", 1L, "Lb/Mb", 1, 17L },
                    { 94L, "g/hg", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4919), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4919), "Gram/hectogram", "Gram/hectogram", 1L, "G/Hg", 1, 18L },
                    { 95L, "g/kg", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4921), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4922), "Gram/kilogram", "Gram/kilogram", 1L, "G/Kg", 1, 18L },
                    { 96L, "kg/kg", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4923), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4924), "Kilogram/Kilogram", "Kilogram/Kilogram", 1L, "Kg/Kg", 1, 18L },
                    { 97L, "kg/ton", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4925), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4926), "Kilogram/US Tonne", "Kilogram/US Tonne", 1L, "Kg/Ton", 1, 18L },
                    { 98L, "ppb(m)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4928), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4929), "Mass parts per billion", "Mass parts per billion", 1L, "Ppb(M)", 1, 18L },
                    { 99L, "ppm(m)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4931), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4932), "Mass parts per million", "Mass parts per million", 1L, "Ppm(M)", 1, 18L },
                    { 100L, "ppt(m)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4934), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4934), "Mass parts per trillion", "Mass parts per trillion", 1L, "Ppt(M)", 1, 18L },
                    { 101L, "mg/g", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4936), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4937), "Milligram/gram", "Milligram/gram", 1L, "Mg/G", 1, 18L },
                    { 102L, "mg/kg", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4939), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4940), "Milligram/kilogram", "Milligram/kilogram", 1L, "Mg/Kg", 1, 18L },
                    { 103L, "%(m)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4941), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4942), "Percent mass", "Percent mass", 1L, "%(M)", 1, 18L },
                    { 104L, "%O(m)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4943), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4944), "Permille mass", "Permille mass", 1L, "%O(M)", 1, 18L },
                    { 105L, "t/t", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4946), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4947), "Tonne/Tonne", "Tonne/Tonne", 1L, "T/T", 1, 18L },
                    { 106L, "lb/ton", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4949), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4949), "US Pound/US Tonne", "US Pound/US Tonne", 1L, "Lb/Ton", 1, 18L },
                    { 107L, "µs", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4951), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4952), "Microsecond", "Microsecond", 1L, "µs", 1, 20L },
                    { 108L, "ms", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4953), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4954), "Millisecond", "Millisecond", 1L, "Ms", 1, 20L },
                    { 109L, "ns", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4955), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4956), "Nanosecond", "Nanosecond", 1L, "Ns", 1, 20L },
                    { 110L, "ps", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4957), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4958), "Picosecond", "Picosecond", 1L, "Ps", 1, 20L },
                    { 111L, "s", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4959), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4960), "Second", "Second", 1L, "S", 1, 20L },
                    { 112L, "w", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4962), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4962), "Week", "Week", 1L, "W", 1, 20L },
                    { 113L, "yr", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4965), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4965), "Years", "Years", 1L, "Yr", 1, 20L },
                    { 114L, "kg/sm2", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4967), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4967), "Vaporization Speed", "Vaporization Speed", 1L, "Kg/Sm2", 1, 21L },
                    { 115L, "Cl", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4969), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4970), "Centiliter", "Centiliter", 1L, "Cl", 1, 22L },
                    { 116L, "cm3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4971), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4972), "Cubic centimeter", "Cubic centimeter", 1L, "Cm3", 1, 22L },
                    { 117L, "dm3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4973), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4974), "Cubic decimeter", "Cubic decimeter", 1L, "Dm3", 1, 22L },
                    { 118L, "ft3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4975), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4976), "Cubic foot", "Cubic foot", 1L, "Ft3", 1, 22L },
                    { 119L, "Inch3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4978), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4978), "Cubic inch", "Cubic inch", 1L, "Inch3", 1, 22L },
                    { 120L, "m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4980), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4980), "Cubic meter", "Cubic meter", 1L, "M3", 1, 22L },
                    { 121L, "mm3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4983), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4983), "Cubic millimeter", "Cubic millimeter", 1L, "Mm3", 1, 22L },
                    { 122L, "yd3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4985), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4985), "Cubic yard", "Cubic yard", 1L, "Yd3", 1, 22L },
                    { 123L, "hl", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4987), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4987), "Hectoliter", "Hectoliter", 1L, "Hl", 1, 22L },
                    { 124L, "l", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4993), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4993), "Liter", "Liter", 1L, "L", 1, 22L },
                    { 125L, "µl", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4995), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4995), "Microliter", "Microliter", 1L, "µl", 1, 22L },
                    { 126L, "ml", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4997), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4997), "Milliliter", "Milliliter", 1L, "Ml", 1, 22L },
                    { 127L, "pt US", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4999), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(4999), "Pint, US liquid", "Pint, US liquid", 1L, "Pt Us", 1, 22L },
                    { 128L, "qt US", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5002), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5002), "Quart, US liquid", "Quart, US liquid", 1L, "Qt Us", 1, 22L },
                    { 129L, "gal US", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5004), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5005), "US gallon", "US gallon", 1L, "Gal Us", 1, 22L },
                    { 130L, "m3/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5006), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5007), "Cubic meter/Cubic meter", "Cubic meter/Cubic meter", 1L, "M3/M3", 1, 23L },
                    { 131L, "ml/m3", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5008), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5010), "Milliliter/cubic meter", "Milliliter/cubic meter", 1L, "Ml/M3", 1, 23L },
                    { 132L, "%(V)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5012), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5013), "Percent volume", "Percent volume", 1L, "%(V)", 1, 23L },
                    { 133L, "%O(V)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5014), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5015), "Permille volume", "Permille volume", 1L, "%O(V)", 1, 23L },
                    { 134L, "ppb(V)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5016), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5017), "Volume parts per billion", "Volume parts per billion", 1L, "Ppb(V)", 1, 23L },
                    { 135L, "ppm(V)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5019), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5019), "Volume parts per million", "Volume parts per million", 1L, "Ppm(V)", 1, 23L },
                    { 136L, "ppt(V)", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5022), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5022), "Volume parts per trillion", "Volume parts per trillion", 1L, "Ppt(V)", 1, 23L },
                    { 137L, "cm3/s", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5024), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5024), "Cubic centimeter/second", "Cubic centimeter/second", 1L, "Cm3/S", 1, 24L },
                    { 138L, "m3/h", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5026), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5027), "Cubic meter/Hour", "Cubic meter/Hour", 1L, "M3/H", 1, 24L },
                    { 139L, "m3/d", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5028), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5029), "Cubic meter/day", "Cubic meter/day", 1L, "M3/D", 1, 24L },
                    { 140L, "m3/s", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5030), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5031), "Cubic meter/second", "Cubic meter/second", 1L, "M3/S", 1, 24L },
                    { 141L, "L/hr", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5033), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5033), "Liter per hour", "Liter per hour", 1L, "L/Hr", 1, 24L },
                    { 142L, "l/min", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5035), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5035), "Liter/Minute", "Liter/Minute", 1L, "L/Min", 1, 24L },
                    { 709L, "int", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5037), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5037), "Integer", "Integer", 1L, "Integer", 1, 131L },
                    { 710L, "dec", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5040), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5041), "Decimal", "Decimal", 1L, "Decimal", 1, 131L },
                    { 717L, "narrative", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5043), 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5043), "Narrative", "Narrative", 1L, "Narrative", 1, 126L }
                });

            migrationBuilder.InsertData(
                table: "DataModelFilters",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DimensionTypeId", "FilterId", "LastModifiedBy", "LastModifiedDate", "ModelConfigurationId", "State" },
                values: new object[] { 1000L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5L, null, null, 10001L, 0 });

            migrationBuilder.InsertData(
                table: "DataPointValue",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "CurrencyId", "DatapointTypeId", "DisclosureRequirementId", "IsNarrative", "LanguageId", "LastModifiedBy", "LastModifiedDate", "ModelFilterCombinationId", "Name", "OrganizationId", "Purpose", "State", "UnitOfMeasureId", "UserId" },
                values: new object[,]
                {
                    { 10000L, "E1.GOV-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(411), null, null, 17L, true, 1L, null, null, null, "Disclosure of whether and how climate-related considerations are factored into remuneration of members of administrative, management and supervisory bodies", 1L, "", 0, null, null },
                    { 10001L, "E1.GOV-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(414), null, 2L, 17L, null, 1L, null, null, null, "Percentage of remuneration recognised that is linked to climate related considerations", 1L, "", 0, null, null },
                    { 10002L, "E1.GOV-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(417), null, null, 17L, true, 1L, null, null, null, "Explanation of climate-related considerations that are factored into remuneration of members of administrative, management and supervisory bodies ", 1L, "", 0, 38L, null },
                    { 10003L, "E1-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(420), null, 2L, 18L, true, 1L, null, null, null, "Disclosure of transition plan  for climate change mitigation", 1L, "", 0, null, null },
                    { 10004L, "E1-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(423), null, 2L, 18L, true, 1L, null, null, null, "Explanation of how targets are compatible with limiting of global warming to one and half degrees Celsius in line with Paris Agreement ", 1L, "", 0, null, null },
                    { 10005L, "E1-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(425), null, 2L, 18L, true, 1L, null, null, null, "Disclosure of decarbonisation levers and key action ", 1L, "", 0, null, null },
                    { 10006L, "E1-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(428), null, 2L, 18L, true, 1L, null, null, null, "Disclosure of significant operational expenditures (Opex) and (or) capital expenditures (Capex) required for implementation of action plan ", 1L, "", 0, null, null },
                    { 10007L, "E1-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(430), null, 2L, 18L, null, 1L, null, null, null, "Financial resources allocated to action plan (OpEx)", 1L, "", 0, null, null },
                    { 10008L, "E1-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(433), null, 3L, 18L, null, 1L, null, null, null, "Financial resources allocated to action plan (CapEx)", 1L, "", 0, null, null },
                    { 10009L, "E1-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(436), null, 3L, 18L, true, 1L, null, null, null, "Explanation of potential locked-in GHG emissions from key assets and products and of how locked-in GHG emissions may jeopardise achievement of GHG emission reduction targets and drive transition risk ", 1L, "", 0, null, null },
                    { 10010L, "E1-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(438), null, 2L, 18L, true, 1L, null, null, null, "Explanation of any objective or plans (CapEx, CapEx plans, OpEx) for aligning economic activities (revenues, CapEx, OpEx) with criteria established in Commission Delegated Regulation 2021/2139 ", 1L, "", 0, null, null },
                    { 10011L, "E1-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(441), null, 2L, 18L, null, 1L, null, null, null, "Significant CapEx for coal-related economic activities", 1L, "", 0, null, null },
                    { 10012L, "E1-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(443), null, 3L, 18L, null, 1L, null, null, null, "Significant CapEx for oil-related economic activities", 1L, "", 0, null, null },
                    { 10013L, "E1-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(446), null, 3L, 18L, null, 1L, null, null, null, "Significant CapEx for gas-related economic activities", 1L, "", 0, null, null },
                    { 10014L, "E1-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(448), null, 3L, 18L, null, 1L, null, null, null, "Undertaking is excluded from EU Paris-aligned Benchmarks", 1L, "", 0, null, null },
                    { 10015L, "E1-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(450), null, 2L, 18L, true, 1L, null, null, null, "Explanation of how transition plan is embedded in and aligned with overall business strategy and financial planning ", 1L, "", 0, null, null },
                    { 10016L, "E1-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(453), null, 2L, 18L, null, 1L, null, null, null, "Transition plan is approved by administrative, management and supervisory bodies", 1L, "", 0, null, null },
                    { 10017L, "E1-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(456), null, 2L, 18L, true, 1L, null, null, null, "Explanation of progress in implementing transition plan ", 1L, "", 0, null, null },
                    { 10018L, "E1-1_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(462), null, 2L, 18L, null, 1L, null, null, null, "Date of adoption of transition plan for undertakings not having adopted transition plan yet", 1L, "", 0, null, null },
                    { 10019L, "E1.SBM-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(464), null, null, 19L, null, 1L, null, null, null, "Type of climate-related risk", 1L, "", 0, 7L, null },
                    { 10020L, "E1.SBM-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(467), null, 2L, 19L, true, 1L, null, null, null, "Description of scope of resilience analysis ", 1L, "", 0, null, null },
                    { 10021L, "E1.SBM-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(469), null, 2L, 19L, true, 1L, null, null, null, "Disclosure of how resilience analysis has been conducted ", 1L, "", 0, null, null },
                    { 10022L, "E1.SBM-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(471), null, 2L, 19L, null, 1L, null, null, null, "Disclosure of how resilience analysis has been conducted ", 1L, "", 0, null, null },
                    { 10023L, "E1.SBM-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(475), null, null, 19L, null, 1L, null, null, null, "Time horizons applied for resilience analysis", 1L, "", 0, 7L, null },
                    { 10024L, "E1.SBM-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(477), null, 2L, 19L, true, 1L, null, null, null, "Description of results of resilience analysis ", 1L, "", 0, null, null },
                    { 10025L, "E1.SBM-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(480), null, 2L, 19L, true, 1L, null, null, null, "Description of ability to adjust or adapt strategy and business model to climate change ", 1L, "", 0, null, null },
                    { 10026L, "E1.IRO-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(482), null, 2L, 20L, true, 1L, null, null, null, "Description of process in relation to impacts on climate change ", 1L, "", 0, null, null },
                    { 10027L, "E1.IRO-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(484), null, 2L, 20L, true, 1L, null, null, null, "Description of process in relation to climate-related physical risks in own operations and along value chain ", 1L, "", 0, null, null },
                    { 10028L, "E1.IRO-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(487), null, 2L, 20L, null, 1L, null, null, null, "Climate-related hazards have been identified over short-, medium- and long-term time horizons", 1L, "", 0, null, null },
                    { 10029L, "E1.IRO-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(490), null, 2L, 20L, null, 1L, null, null, null, "Undertaking has screened whether assets and business activities may be exposed to climate-related hazards", 1L, "", 0, null, null },
                    { 10030L, "E1.IRO-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(492), null, 2L, 20L, null, 1L, null, null, null, "Short-, medium- and long-term time horizons have been defined", 1L, "", 0, null, null },
                    { 10031L, "E1.IRO-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(495), null, 2L, 20L, null, 1L, null, null, null, "Extent to which assets and business activities may be exposed and are sensitive to identified climate-related hazards has been assessed", 1L, "", 0, null, null },
                    { 10032L, "E1.IRO-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(497), null, 2L, 20L, false, 1L, null, null, null, "Identification of climate-related hazards and assessment of exposure and sensitivity are informed by high emissions climate scenarios", 1L, "", 0, 709L, null },
                    { 10033L, "E1.IRO-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(499), null, 2L, 20L, true, 1L, null, null, null, "Explanation of how climate-related scenario analysis has been used to inform identification and assessment of physical risks over short, medium and long-term ", 1L, "", 0, null, null },
                    { 10034L, "E1.IRO-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(502), null, 2L, 20L, true, 1L, null, null, null, "Description of process in relation to climate-related transition risks and opportunities in own operations and along value chain ", 1L, "", 0, null, null },
                    { 10035L, "E1.IRO-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(508), null, 2L, 20L, null, 1L, null, null, null, "Transition events have been identified over short-, medium- and long-term time horizons", 1L, "", 0, null, null },
                    { 10036L, "E1.IRO-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(512), null, 2L, 20L, null, 1L, null, null, null, "Undertaking has screened whether assets and business activities may be exposed to transition events", 1L, "", 0, null, null },
                    { 10037L, "E1.IRO-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(514), null, 2L, 20L, null, 1L, null, null, null, "Extent to which assets and business activities may be exposed and are sensitive to identified transition events has been assessed", 1L, "", 0, null, null },
                    { 10038L, "E1.IRO-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(517), null, 2L, 20L, null, 1L, null, null, null, "Identification of transition events and assessment of exposure has been informed by climate-related scenario analysis", 1L, "", 0, null, null },
                    { 10039L, "E1.IRO-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(519), null, 2L, 20L, null, 1L, null, null, null, "Assets and business activities that are incompatible with or need significant efforts to be compatible with transition to climate-neutral economy have been identified", 1L, "", 0, null, null },
                    { 10040L, "E1.IRO-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(521), null, 2L, 20L, true, 1L, null, null, null, "Explanation of how climate-related scenario analysis has been used to inform identification and assessment of transition risks and opportunities over short, medium and long-term ", 1L, "", 0, null, null },
                    { 10041L, "E1.IRO-1_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(524), null, 2L, 20L, true, 1L, null, null, null, "Explanation of how climate scenarios used are compatible with critical climate-related assumptions made in financial statements ", 1L, "", 0, null, null },
                    { 10042L, "E1.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(526), null, 2L, 21L, null, 1L, null, null, null, "Policies in place to manage its material impacts, risks and opportunities related to climate change mitigation and adaptation [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 10043L, "E1-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(529), null, 2L, 21L, null, 1L, null, null, null, "Sustainability matters addressed by policy for climate change", 1L, "", 0, null, null },
                    { 10045L, "E1.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(533), null, null, 22L, null, 1L, null, null, null, "Actions and Resources related to climate change mitigation and adaptation [see ESRS 2 MDR-A]", 1L, "", 0, null, null },
                    { 10046L, "E1-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(535), null, 2L, 22L, null, 1L, null, null, null, "Decarbonisation lever type", 1L, "", 0, null, null },
                    { 10047L, "E1-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(537), null, 2L, 22L, null, 1L, null, null, null, "Adaptation solution type", 1L, "", 0, null, null },
                    { 10048L, "E1-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(539), null, 2L, 22L, null, 1L, null, null, null, "Achieved GHG emission reductions", 1L, "", 0, null, null },
                    { 10049L, "E1-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(541), null, null, 22L, null, 1L, null, null, null, "Expected GHG emission reductions", 1L, "", 0, 79L, null },
                    { 10050L, "E1-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(545), null, null, 22L, true, 1L, null, null, null, "Explanation of extent to which ability to implement action depends on availability and allocation of resources ", 1L, "", 0, 79L, null },
                    { 10051L, "E1-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(547), null, 2L, 22L, null, 1L, null, null, null, "Explanation of relationship of significant CapEx and OpEx required to implement actions taken or planned to relevant line items or notes in financial statements ", 1L, "", 0, null, null },
                    { 10052L, "E1-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(549), null, 2L, 22L, true, 1L, null, null, null, "Explanation of relationship of significant CapEx and OpEx required to implement actions taken or planned to key performance indicators required under Commission Delegated Regulation (EU) 2021/2178 ", 1L, "", 0, null, null },
                    { 10053L, "E1-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(556), null, 2L, 22L, true, 1L, null, null, null, "Explanation of relationship of significant CapEx and OpEx required to implement actions taken or planned to CapEx plan required by Commission Delegated Regulation (EU) 2021/2178 ", 1L, "", 0, null, null },
                    { 10055L, "E1.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(560), null, null, 23L, null, 1L, null, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 0, null, null },
                    { 10056L, "E1-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(562), null, 2L, 23L, true, 1L, null, null, null, "Disclosure of whether and how GHG emissions reduction targets and (or) any other targets have been set to manage material climate-related impacts, risks and opportunities ", 1L, "", 0, null, null },
                    { 10057L, "E1-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(567), null, 2L, 23L, null, 1L, null, null, null, "Tables: Multiple Dimensions (baseline year and targets; GHG Types, Scope 3 Categories, Decarbonisation levers, entity-specific denominators for intensity value)", 1L, "", 0, null, null },
                    { 10058L, "E1-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(569), null, 1L, 23L, null, 1L, null, null, null, "Absolute value of total Greenhouse gas emissions reduction", 1L, "", 0, null, null },
                    { 10059L, "E1-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(571), null, null, 23L, null, 1L, null, null, null, "Percentage of total Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 0, 79L, null },
                    { 10060L, "E1-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(573), null, null, 23L, null, 1L, null, null, null, "Intensity value of total Greenhouse gas emissions reduction", 1L, "", 0, 38L, null },
                    { 10061L, "E1-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(575), null, null, 23L, null, 1L, null, null, null, "Absolute value of Scope 1 Greenhouse gas emissions reduction", 1L, "", 0, 710L, null },
                    { 10062L, "E1-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(578), null, null, 23L, null, 1L, null, null, null, "Percentage of Scope 1 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 0, 79L, null },
                    { 10063L, "E1-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(580), null, null, 23L, null, 1L, null, null, null, "Intensity value of Scope 1 Greenhouse gas emissions reduction", 1L, "", 0, 38L, null },
                    { 10064L, "E1-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(582), null, null, 23L, null, 1L, null, null, null, "Absolute value of location-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 0, 710L, null },
                    { 10065L, "E1-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(585), null, null, 23L, null, 1L, null, null, null, "Percentage of location-based Scope 2 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 0, 79L, null },
                    { 10066L, "E1-4_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(587), null, null, 23L, null, 1L, null, null, null, "Intensity value of location-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 0, 38L, null },
                    { 10067L, "E1-4_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(589), null, null, 23L, null, 1L, null, null, null, "Absolute value of market-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 0, 710L, null },
                    { 10068L, "E1-4_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(591), null, null, 23L, null, 1L, null, null, null, "Percentage of market-based Scope 2 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 0, 79L, null },
                    { 10069L, "E1-4_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(593), null, null, 23L, null, 1L, null, null, null, "Intensity value of market-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 0, 38L, null },
                    { 10070L, "E1-4_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(596), null, null, 23L, null, 1L, null, null, null, "Absolute value of Scope 3 Greenhouse gas emissions reduction", 1L, "", 0, 710L, null },
                    { 10071L, "E1-4_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(601), null, null, 23L, null, 1L, null, null, null, "Percentage of Scope 3 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 0, 79L, null },
                    { 10072L, "E1-4_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(604), null, null, 23L, null, 1L, null, null, null, "Intensity value of Scope 3 Greenhouse gas emissions reduction", 1L, "", 0, 38L, null },
                    { 10073L, "E1-4_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(607), null, null, 23L, true, 1L, null, null, null, "Explanation of how consistency of GHG emission reduction targets with GHG inventory boundaries has been ensured ", 1L, "", 0, 710L, null },
                    { 10074L, "E1-4_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(609), null, 2L, 23L, true, 1L, null, null, null, "Disclosure of past progress made in meeting target before current base year ", 1L, "", 0, null, null },
                    { 10075L, "E1-4_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(611), null, 2L, 23L, true, 1L, null, null, null, "Description of how it has been ensured that baseline value is representative in terms of activities covered and influences from external factors ", 1L, "", 0, null, null },
                    { 10076L, "E1-4_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(614), null, 2L, 23L, true, 1L, null, null, null, "Description of how new baseline value affects new target, its achievement and presentation of progress over time ", 1L, "", 0, null, null },
                    { 10077L, "E1-4_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(616), null, 2L, 23L, null, 1L, null, null, null, "GHG emission reduction target is science based and compatible with limiting global warming to one and half degrees Celsius", 1L, "", 0, null, null },
                    { 10078L, "E1-4_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(619), null, 2L, 23L, true, 1L, null, null, null, "Description of expected decarbonisation levers and their overall quantitative contributions to achieve GHG emission reduction target ", 1L, "", 0, null, null },
                    { 10079L, "E1-4_24", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(621), null, 2L, 23L, true, 1L, null, null, null, "Diverse range of climate scenarios have been considered to detect relevant environmental, societal, technology, market and policy-related developments and determine decarbonisation levers", 1L, "", 0, null, null },
                    { 10080L, "E1.MDR-T_14-19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(623), null, 2L, 23L, null, 1L, null, null, null, "Disclosure to be reported if the undertaking has not set any measurable outcome-oriented targets", 1L, "", 0, null, null },
                    { 10081L, "E1-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(625), null, null, 24L, null, 1L, null, null, null, "Total energy consumption related to own operations", 1L, "", 0, null, null },
                    { 10082L, "E1-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(628), null, null, 24L, null, 1L, null, null, null, "Total energy consumption from fossil sources", 1L, "", 0, 44L, null },
                    { 10083L, "E1-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(630), null, null, 24L, null, 1L, null, null, null, "Total energy consumption from nuclear sources", 1L, "", 0, 44L, null },
                    { 10084L, "E1-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(632), null, null, 24L, null, 1L, null, null, null, "Percentage of energy consumption from nuclear sources in total energy consumption", 1L, "", 0, 44L, null },
                    { 10085L, "E1-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(634), null, null, 24L, null, 1L, null, null, null, "Total energy consumption from renewable sources", 1L, "", 0, 38L, null },
                    { 10086L, "E1-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(637), null, null, 24L, null, 1L, null, null, null, "Fuel consumption from renewable sources", 1L, "", 0, 44L, null },
                    { 10087L, "E1-5_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(639), null, null, 24L, null, 1L, null, null, null, "Consumption of purchased or acquired electricity, heat, steam, and cooling from renewable sources", 1L, "", 0, 44L, null },
                    { 10088L, "E1-5_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(646), null, null, 24L, null, 1L, null, null, null, "Consumption of self-generated non-fuel renewable energy", 1L, "", 0, 44L, null },
                    { 10089L, "E1-5_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(648), null, null, 24L, null, 1L, null, null, null, "Percentage of renewable sources in total energy consumption", 1L, "", 0, 44L, null },
                    { 10090L, "E1-5_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(650), null, null, 24L, null, 1L, null, null, null, "Fuel consumption from coal and coal products", 1L, "", 0, 38L, null },
                    { 10091L, "E1-5_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(652), null, null, 24L, null, 1L, null, null, null, "Fuel consumption from crude oil and petroleum products", 1L, "", 0, 44L, null },
                    { 10092L, "E1-5_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(654), null, null, 24L, null, 1L, null, null, null, "Fuel consumption from natural gas", 1L, "", 0, 44L, null },
                    { 10093L, "E1-5_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(657), null, null, 24L, null, 1L, null, null, null, "Fuel consumption from other fossil sources", 1L, "", 0, 44L, null },
                    { 10094L, "E1-5_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(659), null, null, 24L, null, 1L, null, null, null, "Consumption of purchased or acquired electricity, heat, steam, or cooling from fossil sources", 1L, "", 0, 44L, null },
                    { 10095L, "E1-5_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(661), null, null, 24L, null, 1L, null, null, null, "Percentage of fossil sources in total energy consumption", 1L, "", 0, 44L, null },
                    { 10096L, "E1-5_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(663), null, null, 24L, null, 1L, null, null, null, "Non-renewable energy production", 1L, "", 0, 38L, null },
                    { 10097L, "E1-5_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(666), null, null, 24L, null, 1L, null, null, null, "Renewable energy production", 1L, "", 0, 44L, null },
                    { 10098L, "E1-5_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(668), null, null, 24L, null, 1L, null, null, null, "Energy intensity from activities in high climate impact sectors (total energy consumption per net revenue)", 1L, "", 0, 44L, null },
                    { 10099L, "E1-5_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(670), null, null, 24L, null, 1L, null, null, null, "Total energy consumption from activities in high climate impact sectors", 1L, "", 0, 38L, null },
                    { 10100L, "E1-5_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(673), null, null, 24L, null, 1L, null, null, null, "High climate impact sectors used to determine energy intensity", 1L, "", 0, 44L, null },
                    { 10101L, "E1-5_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(675), null, 2L, 24L, true, 1L, null, null, null, "Disclosure of reconciliation to relevant line item or notes in financial statements of net revenue from activities in high climate impact sectors ", 1L, "", 0, null, null },
                    { 10102L, "E1-5_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(677), null, 2L, 24L, null, 1L, null, null, null, "Net revenue from activities in high climate impact sectors", 1L, "", 0, null, null },
                    { 10103L, "E1-5_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(679), null, 3L, 24L, null, 1L, null, null, null, "Net revenue from activities other than in high climate impact sectors", 1L, "", 0, null, null },
                    { 10104L, "E1-6_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(681), null, 3L, 25L, null, 1L, null, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - GHG emissions per scope [table]", 1L, "", 0, null, null },
                    { 10105L, "E1-6_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(684), null, 1L, 25L, null, 1L, null, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - financial and operational control [table]", 1L, "", 0, 79L, null },
                    { 10106L, "E1-6_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(690), null, 1L, 25L, null, 1L, null, null, null, "Disaggregation of GHG emissions - by country, operating segments, economic activity, subsidiary, GHG category or source type", 1L, "", 0, 79L, null },
                    { 10107L, "E1-6_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(693), null, 1L, 25L, null, 1L, null, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - Scope 3 GHG emissions (GHG Protocol) [table]", 1L, "", 0, 79L, null },
                    { 10108L, "E1-6_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(695), null, 1L, 25L, null, 1L, null, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - Scope 3 GHG emissions (ISO 14064-1) [table]", 1L, "", 0, 79L, null },
                    { 10109L, "E1-6_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(698), null, 1L, 25L, null, 1L, null, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - total GHG emissions - value chain [table]", 1L, "", 0, 79L, null },
                    { 10110L, "E1-6_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(700), null, 1L, 25L, null, 1L, null, null, null, "Gross Scope 1 greenhouse gas emissions ", 1L, "", 0, 79L, null },
                    { 10111L, "E1-6_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(702), null, null, 25L, null, 1L, null, null, null, "Percentage of Scope 1 GHG emissions from regulated emission trading schemes", 1L, "", 0, 79L, null },
                    { 10112L, "E1-6_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(704), null, null, 25L, null, 1L, null, null, null, "Gross location-based Scope 2 greenhouse gas emissions", 1L, "", 0, 38L, null },
                    { 10113L, "E1-6_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(706), null, null, 25L, null, 1L, null, null, null, "Gross market-based Scope 2 greenhouse gas emissions", 1L, "", 0, 79L, null },
                    { 10114L, "E1-6_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(709), null, null, 25L, null, 1L, null, null, null, "Gross Scope 3 greenhouse gas emissions", 1L, "", 0, 79L, null },
                    { 10115L, "E1-6_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(711), null, null, 25L, null, 1L, null, null, null, "Total GHG emissions location based", 1L, "", 0, 79L, null },
                    { 10116L, "E1-6_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(713), null, null, 25L, null, 1L, null, null, null, "Total GHG emissions market based", 1L, "", 0, 79L, null },
                    { 10117L, "E1-6_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(716), null, null, 25L, true, 1L, null, null, null, "Disclosure of significant changes in definition of what constitutes reporting undertaking and its value chain and explanation of their effect on year-to-year comparability of reported GHG emissions", 1L, "", 0, 79L, null },
                    { 10118L, "E1-6_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(718), null, 2L, 25L, true, 1L, null, null, null, "Disclosure of methodologies, significant assumptions and emissions factors used to calculate or measure GHG emissions ", 1L, "", 0, null, null },
                    { 10119L, "E1-6_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(720), null, 2L, 25L, true, 1L, null, null, null, "Disclosure of the effects of significant events and changes in circumstances (relevant to its GHG emissions) that occur between the reporting dates of the entities in its value chain and the date of the undertaking’s general purpose financial statements", 1L, "", 0, null, null },
                    { 10120L, "E1-6_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(723), null, 2L, 25L, null, 1L, null, null, null, "biogenic emissions of CO2 from the combustion or bio-degradation of biomassnot included in Scope 1 GHG emissions", 1L, "", 0, null, null },
                    { 10121L, "E1-6_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(725), null, null, 25L, null, 1L, null, null, null, "Percentage of contractual instruments, Scope 2 GHG emissions", 1L, "", 0, 79L, null },
                    { 10122L, "E1-6_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(727), null, null, 25L, null, 1L, null, null, null, "Disclosure of types of contractual instruments, Scope 2 GHG emissions ", 1L, "", 0, 38L, null },
                    { 10123L, "E1-6_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(730), null, null, 25L, null, 1L, null, null, null, "Percentage of market-based Scope 2 GHG emissions linked to purchased electricity bundled with instruments", 1L, "", 0, 38L, null },
                    { 10124L, "E1-6_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(735), null, null, 25L, null, 1L, null, null, null, "Percentage of contractual instruments used for sale and purchase of energy bundled with attributes about energy generation in relation to Scope 2 GHG emissions", 1L, "", 0, 38L, null },
                    { 10125L, "E1-6_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(737), null, null, 25L, null, 1L, null, null, null, "Percentage of contractual instruments used for sale and purchase of unbundled energy attribute claims in relation to Scope 2 GHG emissions", 1L, "", 0, 38L, null },
                    { 10126L, "E1-6_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(740), null, null, 25L, true, 1L, null, null, null, "Disclosure of types of contractual instruments used for sale and purchase of energy bundled with attributes about energy generation or for unbundled energy attribute claims ", 1L, "", 0, 38L, null },
                    { 10127L, "E1-6_24", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(742), null, 2L, 25L, null, 1L, null, null, null, "Biogenic emissions of CO2 from combustion or bio-degradation of biomass not included in Scope 2 GHG emissions", 1L, "", 0, null, null },
                    { 10128L, "E1-6_25", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(744), null, null, 25L, null, 1L, null, null, null, "Percentage of GHG Scope 3 calculated using primary data ", 1L, "", 0, 79L, null },
                    { 10129L, "E1-6_26", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(746), null, null, 25L, true, 1L, null, null, null, "Disclosure of why Scope 3 GHG emissions category has been excluded ", 1L, "", 0, 38L, null },
                    { 10130L, "E1-6_27", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(748), null, 2L, 25L, null, 1L, null, null, null, "List of Scope 3 GHG emissions categories included in inventory", 1L, "", 0, null, null },
                    { 10131L, "E1-6_28", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(750), null, 2L, 25L, null, 1L, null, null, null, "Biogenic emissions of CO2 from combustion or bio-degradation of biomass that occur in value chain not included in Scope 3 GHG emissions", 1L, "", 0, null, null },
                    { 10132L, "E1-6_29", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(753), null, null, 25L, true, 1L, null, null, null, "Disclosure of reporting boundaries considered and calculation methods for estimating Scope 3 GHG emissions", 1L, "", 0, 79L, null },
                    { 10133L, "E1-6_30", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(755), null, 2L, 25L, null, 1L, null, null, null, "GHG emissions intensity, location-based (total GHG emissions per net revenue)", 1L, "", 0, null, null },
                    { 10134L, "E1-6_31", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(758), null, null, 25L, null, 1L, null, null, null, "GHG emissions intensity, market-based (total GHG emissions per net revenue)", 1L, "", 0, 79L, null },
                    { 10135L, "E1-6_32", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(760), null, null, 25L, true, 1L, null, null, null, "Disclosure of reconciliation to financial statements of net revenue used for calculation of GHG emissions intensity ", 1L, "", 0, 79L, null },
                    { 10136L, "E1-6_33", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(762), null, 2L, 25L, null, 1L, null, null, null, "Net revenue", 1L, "", 0, null, null },
                    { 10137L, "E1-6_34", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(764), null, 3L, 25L, null, 1L, null, null, null, "Net revenue used to calculate GHG intensity", 1L, "", 0, null, null },
                    { 10138L, "E1-6_35", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(766), null, 3L, 25L, null, 1L, null, null, null, "Net revenue other than used to calculate GHG intensity", 1L, "", 0, null, null },
                    { 10139L, "E1-7_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(768), null, 3L, 26L, true, 1L, null, null, null, "Disclosure of GHG removals and storage resulting from projects developed in own operations or contributed to in upstream and downstream value chain ", 1L, "", 0, null, null },
                    { 10140L, "E1-7_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(771), null, 2L, 26L, true, 1L, null, null, null, "Disclosure of GHG emission reductions or removals from climate change mitigation projects outside value chain financed or to be financed through any purchase of carbon credits ", 1L, "", 0, null, null },
                    { 10141L, "E1-7_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(779), null, 2L, 26L, null, 1L, null, null, null, "Removals and carbon credits are used", 1L, "", 0, null, null },
                    { 10142L, "E1-7_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(781), null, 2L, 26L, null, 1L, null, null, null, "GHG Removals and storage Activity by undertaking scope (breakdown by own operations and value chain) and by removal and storage activity", 1L, "", 0, null, null },
                    { 10143L, "E1-7_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(784), null, 1L, 26L, null, 1L, null, null, null, "Total GHG removals and storage", 1L, "", 0, null, null },
                    { 10144L, "E1-7_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(786), null, null, 26L, null, 1L, null, null, null, "GHG emissions associated with removal activity", 1L, "", 0, 79L, null },
                    { 10145L, "E1-7_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(788), null, null, 26L, null, 1L, null, null, null, "Reversals", 1L, "", 0, 79L, null },
                    { 10146L, "E1-7_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(790), null, null, 26L, true, 1L, null, null, null, "Disclosure of calculation assumptions, methodologies and frameworks applied (GHG removals and storage) ", 1L, "", 0, 79L, null },
                    { 10147L, "E1-7_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(793), null, 2L, 26L, null, 1L, null, null, null, "Removal activity has been converted into carbon credits and sold on to other parties on voluntary market", 1L, "", 0, null, null },
                    { 10148L, "E1-7_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(796), null, 2L, 26L, null, 1L, null, null, null, "Total amount of carbon credits outside value chain that are verified against recognised quality standards and cancelled", 1L, "", 0, null, null },
                    { 10149L, "E1-7_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(798), null, null, 26L, null, 1L, null, null, null, "Total amount of carbon credits outside value chain planned to be cancelled in future", 1L, "", 0, 79L, null },
                    { 10150L, "E1-7_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(800), null, null, 26L, true, 1L, null, null, null, "Disclosure of extent of use and quality criteria used for carbon credits ", 1L, "", 0, 79L, null },
                    { 10151L, "E1-7_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(802), null, 2L, 26L, null, 1L, null, null, null, "Percentage of reduction projects", 1L, "", 0, null, null },
                    { 10152L, "E1-7_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(804), null, null, 26L, null, 1L, null, null, null, "Percentage of removal projects", 1L, "", 0, 38L, null },
                    { 10153L, "E1-7_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(806), null, null, 26L, null, 1L, null, null, null, "Type of carbon credits from removal projects", 1L, "", 0, 38L, null },
                    { 10154L, "E1-7_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(808), null, 2L, 26L, null, 1L, null, null, null, "Percentage for recognised quality standard", 1L, "", 0, null, null },
                    { 10155L, "E1-7_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(811), null, null, 26L, null, 1L, null, null, null, "Percentage issued from projects in European Union", 1L, "", 0, 38L, null },
                    { 10156L, "E1-7_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(813), null, null, 26L, null, 1L, null, null, null, "Percentage that qualifies as corresponding adjustment", 1L, "", 0, 38L, null },
                    { 10157L, "E1-7_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(816), null, null, 26L, null, 1L, null, null, null, "Date when carbon credits outside value chain are planned to be cancelled", 1L, "", 0, 38L, null },
                    { 10158L, "E1-7_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(818), null, null, 26L, true, 1L, null, null, null, "Explanation of scope, methodologies and frameworks applied and how residual GHG emissions are intended to be neutralised ", 1L, "", 0, 7L, null },
                    { 10159L, "E1-7_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(825), null, 2L, 26L, null, 1L, null, null, null, "Public claims of GHG neutrality that involve use of carbon credits have been made", 1L, "", 0, null, null },
                    { 10160L, "E1-7_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(827), null, 2L, 26L, null, 1L, null, null, null, "Public claims of GHG neutrality that involve use of carbon credits are accompanied by GHG emission reduction targets", 1L, "", 0, null, null },
                    { 10161L, "E1-7_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(830), null, 2L, 26L, null, 1L, null, null, null, "Claims of GHG neutrality and reliance on carbon credits neither impede nor reduce achievement of GHG emission reduction targets or net zero target", 1L, "", 0, null, null },
                    { 10162L, "E1-7_24", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(833), null, 2L, 26L, true, 1L, null, null, null, "Explanation of whether and how public claims of GHG neutrality that involve use of carbon credits are accompanied by GHG emission reduction targets and how claims of GHG neutrality and reliance on carbon credits neither impede nor reduce achievement of GHG emission reduction targets or net zero target ", 1L, "", 0, null, null },
                    { 10163L, "E1-7_25", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(835), null, 2L, 26L, true, 1L, null, null, null, "Explanation of credibility and integrity of carbon credits used ", 1L, "", 0, null, null },
                    { 10164L, "E1-8_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(837), null, 2L, 27L, null, 1L, null, null, null, "Carbon pricing scheme by type", 1L, "", 0, null, null },
                    { 10165L, "E1-8_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(839), null, 1L, 27L, null, 1L, null, null, null, "Type of internal carbon pricing scheme", 1L, "", 0, null, null },
                    { 10166L, "E1-8_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(841), null, 2L, 27L, null, 1L, null, null, null, "Description of specific scope of application of carbon pricing scheme ", 1L, "", 0, null, null },
                    { 10167L, "E1-8_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(843), null, 2L, 27L, null, 1L, null, null, null, "Carbon price applied for each metric tonne of greenhouse gas emission", 1L, "", 0, null, null },
                    { 10168L, "E1-8_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(846), null, 3L, 27L, null, 1L, null, null, null, "Description of critical assumptions made to determine carbon price applied ", 1L, "", 0, null, null },
                    { 10169L, "E1-8_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(848), null, 2L, 27L, null, 1L, null, null, null, "Percentage of gross Scope 1 greenhouse gas emissions covered by internal carbon pricing scheme", 1L, "", 0, null, null },
                    { 10170L, "E1-8_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(851), null, null, 27L, null, 1L, null, null, null, "Percentage of gross Scope 2 greenhouse gas emissions covered by internal carbon pricing scheme", 1L, "", 0, 38L, null },
                    { 10171L, "E1-8_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(853), null, null, 27L, null, 1L, null, null, null, "Percentage of gross Scope 3 greenhouse gas emissions covered by internal carbon pricing scheme", 1L, "", 0, 38L, null },
                    { 10172L, "E1-8_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(855), null, null, 27L, null, 1L, null, null, null, "Disclosure of whether and how carbon price used in internal carbon pricing scheme is consistent with carbon price used in financial statements ", 1L, "", 0, 38L, null },
                    { 10173L, "E1-9_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(857), null, 2L, 28L, null, 1L, null, null, null, "Assets at material physical risk before considering climate change adaptation actions", 1L, "", 0, null, null },
                    { 10174L, "E1-9_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(859), null, 3L, 28L, null, 1L, null, null, null, "Assets at acute material physical risk before considering climate change adaptation actions", 1L, "", 0, null, null },
                    { 10175L, "E1-9_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(861), null, 3L, 28L, null, 1L, null, null, null, "Assets at chronic material physical risk before considering climate change adaptation actions", 1L, "", 0, null, null },
                    { 10176L, "E1-9_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(864), null, 3L, 28L, null, 1L, null, null, null, "Percentage of assets at material physical risk before considering climate change adaptation actions", 1L, "", 0, null, null },
                    { 10177L, "E1-9_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(870), null, null, 28L, true, 1L, null, null, null, "Disclosure of location of significant assets at material physical risk ", 1L, "", 0, 38L, null },
                    { 10178L, "E1-9_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(872), null, 2L, 28L, null, 1L, null, null, null, "Disclosure of location of its significant assets at material physical risk (disaggregated by NUTS codes)", 1L, "", 0, null, null },
                    { 10179L, "E1-9_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(875), null, 2L, 28L, null, 1L, null, null, null, "Percentage of assets at material physical risk addressed by climate change adaptation actions", 1L, "", 0, null, null },
                    { 10180L, "E1-9_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(877), null, null, 28L, null, 1L, null, null, null, "Net revenue from business activities at material physical risk", 1L, "", 0, 38L, null },
                    { 10181L, "E1-9_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(879), null, 3L, 28L, null, 1L, null, null, null, "Percentage of net revenue from business activities at material physical risk", 1L, "", 0, null, null },
                    { 10182L, "E1-9_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(881), null, null, 28L, true, 1L, null, null, null, "Disclosure of whether and how anticipated financial effects for assets and business activities at material physical risk have been assessed ", 1L, "", 0, 38L, null },
                    { 10183L, "E1-9_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(884), null, 2L, 28L, true, 1L, null, null, null, "Disclosure of whether and how assessment of assets and business activities considered to be at material physical risk relies on or is part of process to determine material physical risk and to determine climate scenarios ", 1L, "", 0, null, null },
                    { 10184L, "E1-9_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(887), null, 2L, 28L, true, 1L, null, null, null, "Disclosure of risk factors for net revenue from business activities at material physical risk ", 1L, "", 0, null, null },
                    { 10185L, "E1-9_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(889), null, 2L, 28L, true, 1L, null, null, null, "Disclosure of magnitude of anticipated financial effects in terms of margin erosion for business activities at material physical risk ", 1L, "", 0, null, null },
                    { 10186L, "E1-9_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(891), null, 2L, 28L, null, 1L, null, null, null, "Assets at material transition risk before considering climate mitigation actions", 1L, "", 0, null, null },
                    { 10187L, "E1-9_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(893), null, 3L, 28L, null, 1L, null, null, null, "Percentage of assets at material transition risk before considering climate mitigation actions", 1L, "", 0, null, null },
                    { 10188L, "E1-9_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(895), null, null, 28L, null, 1L, null, null, null, "Percentage of assets at material transition risk addressed by climate change mitigation actions", 1L, "", 0, 38L, null },
                    { 10189L, "E1-9_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(897), null, null, 28L, null, 1L, null, null, null, "Total carrying amount of real estate assets by energy efficiency classes", 1L, "", 0, 38L, null },
                    { 10190L, "E1-9_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(901), null, 3L, 28L, true, 1L, null, null, null, "Disclosure of whether and how potential effects on future financial performance and position for assets and business activities at material transition risk have been assessed ", 1L, "", 0, null, null },
                    { 10191L, "E1-9_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(903), null, 2L, 28L, true, 1L, null, null, null, "Disclosure of whether and how assessment of assets and business activities considered to be at material transition risk relies on or is part of process to determine material transition risks and to determine scenarios ", 1L, "", 0, null, null },
                    { 10192L, "E1-9_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(905), null, 2L, 28L, null, 1L, null, null, null, "Estimated amount of potentially stranded assets", 1L, "", 0, null, null },
                    { 10193L, "E1-9_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(907), null, 3L, 28L, null, 1L, null, null, null, "Percentage of estimated share of potentially stranded assets of total assets at material transition risk", 1L, "", 0, null, null },
                    { 10194L, "E1-9_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(914), null, null, 28L, null, 1L, null, null, null, "Total carrying amount of real estate assets for which energy consumption is based on internal estimates", 1L, "", 0, 38L, null },
                    { 10195L, "E1-9_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(916), null, 3L, 28L, null, 1L, null, null, null, "Liabilities from material transition risks that may have to be recognised in financial statements", 1L, "", 0, null, null },
                    { 10196L, "E1-9_24", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(919), null, 3L, 28L, null, 1L, null, null, null, "Number of Scope 1 GHG emission allowances within regulated emission trading schemes", 1L, "", 0, null, null },
                    { 10197L, "E1-9_25", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(921), null, null, 28L, null, 1L, null, null, null, "Number of emission allowances stored (from previous allowances) at beginning of reporting period", 1L, "", 0, 709L, null },
                    { 10198L, "E1-9_26", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(923), null, null, 28L, null, 1L, null, null, null, "Potential future liabilities, based on existing contractual agreements, associated with carbon credits planned to be cancelled in near future", 1L, "", 0, 709L, null },
                    { 10199L, "E1-9_27", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(926), null, 3L, 28L, null, 1L, null, null, null, "Monetised gross Scope 1 and 2 GHG emissions", 1L, "", 0, null, null },
                    { 10200L, "E1-9_28", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(928), null, 3L, 28L, null, 1L, null, null, null, "Monetised total GHG emissions", 1L, "", 0, null, null },
                    { 10201L, "E1-9_29", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(930), null, 3L, 28L, null, 1L, null, null, null, "Net revenue from business activities at material transition risk", 1L, "", 0, null, null },
                    { 10202L, "E1-9_30", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(932), null, 3L, 28L, null, 1L, null, null, null, "Net revenue from customers operating in coal-related activities", 1L, "", 0, null, null },
                    { 10203L, "E1-9_31", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(934), null, 3L, 28L, null, 1L, null, null, null, "Net revenue from customers operating in oil-related activities", 1L, "", 0, null, null },
                    { 10204L, "E1-9_32", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(936), null, 3L, 28L, null, 1L, null, null, null, "Net revenue from customers operating in gas-related activities", 1L, "", 0, null, null },
                    { 10205L, "E1-9_33", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(939), null, 3L, 28L, null, 1L, null, null, null, "Percentage of net revenue from customers operating in coal-related activities", 1L, "", 0, null, null },
                    { 10206L, "E1-9_34", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(941), null, null, 28L, null, 1L, null, null, null, "Percentage of net revenue from customers operating in oil-related activities", 1L, "", 0, 38L, null },
                    { 10207L, "E1-9_35", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(943), null, null, 28L, null, 1L, null, null, null, "Percentage of net revenue from customers operating in gas-related activities", 1L, "", 0, 38L, null },
                    { 10208L, "E1-9_36", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(945), null, null, 28L, null, 1L, null, null, null, "Percentage of net revenue from business activities at material transition risk", 1L, "", 0, 38L, null },
                    { 10209L, "E1-9_37", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(948), null, null, 28L, true, 1L, null, null, null, "Disclosure of risk factors for net revenue from business activities at material transition risk ", 1L, "", 0, 38L, null },
                    { 10210L, "E1-9_38", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(950), null, 2L, 28L, null, 1L, null, null, null, "Disclosure of anticipated financial effects in terms of margin erosion for business activities at material transition risk ", 1L, "", 0, null, null },
                    { 10211L, "E1-9_39", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(952), null, 2L, 28L, true, 1L, null, null, null, "Disclosure of reconciliations with financial statements of significant amounts of assets and net revenue at material physical risk ", 1L, "", 0, null, null },
                    { 10212L, "E1-9_40", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(960), null, 2L, 28L, true, 1L, null, null, null, "Disclosure of reconciliations with financial statements of significant amounts of assets, liabilities and net revenue at material transition risk ", 1L, "", 0, null, null },
                    { 10213L, "E1-9_41", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(962), null, 2L, 28L, null, 1L, null, null, null, "Expected cost savings from climate change mitigation actions", 1L, "", 0, null, null },
                    { 10214L, "E1-9_42", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(964), null, 3L, 28L, null, 1L, null, null, null, "Expected cost savings from climate change adaptation actions", 1L, "", 0, null, null },
                    { 10215L, "E1-9_43", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(967), null, 3L, 28L, null, 1L, null, null, null, "Potential market size of low-carbon products and services or adaptation solutions to which undertaking has or may have access", 1L, "", 0, null, null },
                    { 10216L, "E1-9_44", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(969), null, 3L, 28L, null, 1L, null, null, null, "Expected changes to net revenue from low-carbon products and services or adaptation solutions to which undertaking has or may have access", 1L, "", 0, null, null },
                    { 10218L, "BP-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(973), null, 2L, 1L, true, 1L, null, null, null, "Scope of consolidation of consolidated sustainability statement is same as for financial statements", 1L, "", 0, null, null },
                    { 10219L, "BP-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(976), null, 2L, 1L, true, 1L, null, null, null, "Indication of subsidiary undertakings included in consolidation that are exempted from individual or consolidated sustainability reporting ", 1L, "", 0, null, null },
                    { 10220L, "BP-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(978), null, 2L, 1L, true, 1L, null, null, null, "Disclosure of extent to which sustainability statement covers upstream and downstream value chain ", 1L, "", 0, null, null },
                    { 10221L, "BP-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(981), null, 2L, 1L, null, 1L, null, null, null, "Option to omit specific piece of information corresponding to intellectual property, know-how or results of innovation has been used", 1L, "", 0, null, null },
                    { 10222L, "BP-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(983), null, 2L, 1L, null, 1L, null, null, null, "Option allowed by Member State to omit disclosure of impending developments or matters in course of negotiation has been used", 1L, "", 0, null, null },
                    { 10223L, "BP-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(985), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of definitions of medium- or long-term time horizons ", 1L, "", 0, null, null },
                    { 10224L, "BP-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(987), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of reasons for applying different definitions of time horizons ", 1L, "", 0, null, null },
                    { 10225L, "BP-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(991), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of metrics that include value chain data estimated using indirect sources ", 1L, "", 0, null, null },
                    { 10226L, "BP-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(994), null, 2L, 2L, true, 1L, null, null, null, "Description of basis for preparation of metrics that include value chain data estimated using indirect sources ", 1L, "", 0, null, null },
                    { 10227L, "BP-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(996), null, 2L, 2L, true, 1L, null, null, null, "Description of resulting level of accuracy of metrics that include value chain data estimated using indirect sources ", 1L, "", 0, null, null },
                    { 10228L, "BP-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(998), null, 2L, 2L, true, 1L, null, null, null, "Description of planned actions to improve accuracy in future of metrics that include value chain data estimated using indirect sources ", 1L, "", 0, null, null },
                    { 10229L, "BP-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1000), null, 2L, 2L, null, 1L, null, null, null, "Disclosure of quantitative metrics and monetary amounts disclosed that are subject to high level of measurement uncertainty ", 1L, "", 0, null, null },
                    { 10230L, "BP-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1017), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of sources of measurement uncertainty ", 1L, "", 0, null, null },
                    { 10231L, "BP-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1020), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of assumptions, approximations and judgements made in measurement ", 1L, "", 0, null, null },
                    { 10232L, "BP-2_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1022), null, 2L, 2L, true, 1L, null, null, null, "Explanation of changes in preparation and presentation of sustainability information and reasons for them ", 1L, "", 0, null, null },
                    { 10233L, "BP-2_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1024), null, 2L, 2L, null, 1L, null, null, null, "Adjustment of comparative information for one or more prior periods is impracticable", 1L, "", 0, null, null },
                    { 10234L, "BP-2_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1027), null, 2L, 2L, null, 1L, null, null, null, "Disclosure of difference between figures disclosed in preceding period and revised comparative figures ", 1L, "", 0, null, null },
                    { 10235L, "BP-2_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1029), null, null, 2L, true, 1L, null, null, null, "Disclosure of nature of prior period material errors ", 1L, "", 0, 709L, null },
                    { 10236L, "BP-2_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1031), null, 2L, 2L, null, 1L, null, null, null, "Disclosure of corrections for prior periods included in sustainability statement ", 1L, "", 0, null, null },
                    { 10237L, "BP-2_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1033), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of why correction of prior period errors is not practicable ", 1L, "", 0, null, null },
                    { 10238L, "BP-2_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1036), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of other legislation or generally accepted sustainability reporting standards and frameworks based on which information has been included in sustainability statement ", 1L, "", 0, null, null },
                    { 10239L, "BP-2_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1039), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of reference to paragraphs of standard or framework applied ", 1L, "", 0, null, null },
                    { 10240L, "BP-2_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1041), null, 2L, 2L, null, 1L, null, null, null, "European standards approved by European Standardisation System (ISO/IEC or CEN/CENELEC standards) have been relied on", 1L, "", 0, null, null },
                    { 10241L, "BP-2_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1043), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of extent to which data and processes that are used for sustainability reporting purposes have been verified by external assurance provider and found to conform to corresponding ISO/IEC or CEN/CENELEC standard ", 1L, "", 0, null, null },
                    { 10242L, "BP-2_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1045), null, 2L, 2L, true, 1L, null, null, null, "List of DRs or DPs incorporated by reference", 1L, "", 0, null, null },
                    { 10243L, "BP-2_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1047), null, 2L, 2L, null, 1L, null, null, null, "Topics (E4, S1, S2, S3, S4) have been assessed to be material ", 1L, "", 0, null, null },
                    { 10244L, "BP-2_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1050), null, 2L, 2L, null, 1L, null, null, null, "List of sustainability matters assessed to be material (phase-in)", 1L, "", 0, null, null },
                    { 10245L, "BP-2_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1052), null, 2L, 2L, true, 1L, null, null, null, "Disclosure of how business model and strategy take account of impacts related to sustainability matters assessed to be material (phase-in) ", 1L, "", 0, null, null },
                    { 10246L, "BP-2_24", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1055), null, 2L, 2L, null, 1L, null, null, null, "Description of any time-bound targets set related to sustainability matters assessed to be material (phase-in) and progress made towards achieving those targets ", 1L, "", 0, null, null },
                    { 10247L, "BP-2_25", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1061), null, 2L, 2L, true, 1L, null, null, null, "Description of policies related to sustainability matters assessed to be material (phase-in) ", 1L, "", 0, null, null },
                    { 10248L, "BP-2_26", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1063), null, 2L, 2L, true, 1L, null, null, null, "Description of actions taken to identify, monitor, prevent, mitigate, remediate or bring end to actual or potential adverse impacts related to sustainability matters assessed to be material (phase-in) and result of such actions ", 1L, "", 0, null, null },
                    { 10249L, "BP-2_27", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1066), null, 2L, 2L, null, 1L, null, null, null, "Disclosure of metrics related to sustainability matters assessed to be material (phase-in) ", 1L, "", 0, null, null },
                    { 10250L, "GOV-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1068), null, 2L, 3L, null, 1L, null, null, null, "Number of executive members", 1L, "", 0, null, null },
                    { 10251L, "GOV-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1070), null, null, 3L, null, 1L, null, null, null, "Number of non-executive members", 1L, "", 0, 709L, null },
                    { 10252L, "GOV-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1072), null, null, 3L, true, 1L, null, null, null, "Information about representation of employees and other workers ", 1L, "", 0, 709L, null },
                    { 10253L, "GOV-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1075), null, 2L, 3L, true, 1L, null, null, null, "Information about member's experience relevant to sectors, products and geographic locations of undertaking ", 1L, "", 0, null, null },
                    { 10254L, "GOV-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1077), null, 2L, 3L, null, 1L, null, null, null, "Percentage of members of administrative, management and supervisory bodies by gender and other aspects of diversity", 1L, "", 0, null, null },
                    { 10255L, "GOV-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1079), null, null, 3L, null, 1L, null, null, null, "Board's gender diversity ratio", 1L, "", 0, 38L, null },
                    { 10256L, "GOV-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1082), null, null, 3L, null, 1L, null, null, null, "Percentage of independent board members", 1L, "", 0, 38L, null },
                    { 10257L, "GOV-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1084), null, null, 3L, true, 1L, null, null, null, "Information about identity of administrative, management and supervisory bodies or individual(s) within body responsible for oversight of impacts, risks and opportunities ", 1L, "", 0, 38L, null },
                    { 10258L, "GOV-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1086), null, 2L, 3L, true, 1L, null, null, null, "Disclosure of how body's or individuals within body responsibilities for impacts, risks and opportunities are reflected in undertaking's terms of reference, board mandates and other related policies ", 1L, "", 0, null, null },
                    { 10259L, "GOV-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1088), null, 2L, 3L, true, 1L, null, null, null, "Description of management's role in governance processes, controls and procedures used to monitor, manage and oversee impacts, risks and opportunities ", 1L, "", 0, null, null },
                    { 10260L, "GOV-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1091), null, 2L, 3L, true, 1L, null, null, null, "Description of how oversight is exercised over management-level position or committee to which management's role is delegated to ", 1L, "", 0, null, null },
                    { 10261L, "GOV-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1093), null, 2L, 3L, true, 1L, null, null, null, "Information about reporting lines to administrative, management and supervisory bodies ", 1L, "", 0, null, null },
                    { 10262L, "GOV-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1096), null, 2L, 3L, true, 1L, null, null, null, "Disclosure of how dedicated controls and procedures are integrated with other internal functions ", 1L, "", 0, null, null },
                    { 10263L, "GOV-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1098), null, 2L, 3L, true, 1L, null, null, null, "Disclosure of how administrative, management and supervisory bodies and senior executive management oversee setting of targets related to material impacts, risks and opportunities and how progress towards them is monitored ", 1L, "", 0, null, null },
                    { 10264L, "GOV-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1100), null, 2L, 3L, true, 1L, null, null, null, "Disclosure of how administrative, management and supervisory bodies determine whether appropriate skills and expertise are available or will be developed to oversee sustainability matters ", 1L, "", 0, null, null },
                    { 10265L, "GOV-1_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1107), null, 2L, 3L, true, 1L, null, null, null, "Information about sustainability-related expertise that bodies either directly possess or can leverage ", 1L, "", 0, null, null },
                    { 10266L, "GOV-1_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1110), null, 2L, 3L, true, 1L, null, null, null, "Disclosure of how sustainability-related skills and expertise relate to material impacts, risks and opportunities ", 1L, "", 0, null, null },
                    { 10267L, "GOV-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1113), null, 2L, 4L, true, 1L, null, null, null, "Disclosure of whether, by whom and how frequently administrative, management and supervisory bodies are informed about material impacts, risks and opportunities, implementation of due diligence, and results and effectiveness of policies, actions, metrics and targets adopted to address them ", 1L, "", 0, null, null },
                    { 10268L, "GOV-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1115), null, 2L, 4L, true, 1L, null, null, null, "Disclosure of how administrative, management and supervisory bodies consider impacts, risks and opportunities when overseeing strategy, decisions on major transactions and risk management process ", 1L, "", 0, null, null },
                    { 10269L, "GOV-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1117), null, 2L, 4L, true, 1L, null, null, null, "Disclosure of list of material impacts, risks and opportunities addressed by administrative, management and supervisory bodies or their relevant committees ", 1L, "", 0, null, null },
                    { 10270L, "GOV-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1119), null, 2L, 4L, true, 1L, null, null, null, "Disclosure of how governance bodies ensure that appropriate mechanism for performance monitoring is in place ", 1L, "", 0, null, null },
                    { 10271L, "GOV-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1122), null, 2L, 5L, null, 1L, null, null, null, "Incentive schemes and remuneration policies linked to sustainability matters for members of administrative, management and supervisory bodies exist", 1L, "", 0, null, null },
                    { 10272L, "GOV-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1124), null, 2L, 5L, true, 1L, null, null, null, "Description of key characteristics of incentive schemes ", 1L, "", 0, null, null },
                    { 10273L, "GOV-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1126), null, 2L, 5L, true, 1L, null, null, null, "Description of specific sustainability-related targets and (or) impacts used to assess performance of members of administrative, management and supervisory bodies ", 1L, "", 0, null, null },
                    { 10274L, "GOV-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1129), null, 2L, 5L, true, 1L, null, null, null, "Disclosure of how sustainability-related performance metrics are considered as performance benchmarks or included in remuneration policies ", 1L, "", 0, null, null },
                    { 10275L, "GOV-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1131), null, 2L, 5L, null, 1L, null, null, null, "Percentage of variable remuneration dependent on sustainability-related targets and (or) impacts", 1L, "", 0, null, null },
                    { 10276L, "GOV-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1133), null, null, 5L, true, 1L, null, null, null, "Description of level in undertaking at which terms of incentive schemes are approved and updated ", 1L, "", 0, 38L, null },
                    { 10277L, "GOV-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1135), null, 2L, 6L, true, 1L, null, null, null, "Disclosure of mapping of information provided in sustainability statement about due diligence process ", 1L, "", 0, null, null },
                    { 10278L, "GOV-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1138), null, 2L, 7L, true, 1L, null, null, null, "Description of scope, main features and components of risk management and internal control processes and systems in relation to sustainability reporting ", 1L, "", 0, null, null },
                    { 10279L, "GOV-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1140), null, 2L, 7L, true, 1L, null, null, null, "Description of risk assessment approach followed ", 1L, "", 0, null, null },
                    { 10280L, "GOV-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1142), null, 2L, 7L, true, 1L, null, null, null, "Description of main risks identified and their mitigation strategies ", 1L, "", 0, null, null },
                    { 10281L, "GOV-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1144), null, 2L, 7L, true, 1L, null, null, null, "Description of how findings of risk assessment and internal controls as regards sustainability reporting process have been integrated into relevant internal functions and processes ", 1L, "", 0, null, null },
                    { 10282L, "GOV-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1146), null, 2L, 7L, true, 1L, null, null, null, "Description of periodic reporting of findings of risk assessment and internal controls to administrative, management and supervisory bodies ", 1L, "", 0, null, null },
                    { 10283L, "SBM-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1152), null, 2L, 8L, true, 1L, null, null, null, "Description of significant groups of products and (or) services offered ", 1L, "", 0, null, null },
                    { 10284L, "SBM-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1154), null, 2L, 8L, true, 1L, null, null, null, "Description of significant markets and (or) customer groups served ", 1L, "", 0, null, null },
                    { 10285L, "SBM-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1156), null, 2L, 8L, null, 1L, null, null, null, "Total number of employees (head count)", 1L, "", 0, null, null },
                    { 10286L, "SBM-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1159), null, null, 8L, null, 1L, null, null, null, "Number of employees (head count)", 1L, "", 0, 709L, null },
                    { 10287L, "SBM-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1161), null, null, 8L, true, 1L, null, null, null, "Description of products and services that are banned in certain markets ", 1L, "", 0, 709L, null },
                    { 10288L, "SBM-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1163), null, 2L, 8L, null, 1L, null, null, null, "Total revenue ", 1L, "", 0, null, null },
                    { 10289L, "SBM-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1165), null, 3L, 8L, null, 1L, null, null, null, "Revenue by significant ESRS Sectors", 1L, "", 0, null, null },
                    { 10290L, "SBM-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1167), null, 3L, 8L, null, 1L, null, null, null, "List of additional significant ESRS sectors in which significant activities are developed or in which undertaking is or may be connected to material impacts", 1L, "", 0, null, null },
                    { 10291L, "SBM-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1169), null, 2L, 8L, null, 1L, null, null, null, "Undertaking is active in fossil fuel (coal, oil and gas) sector", 1L, "", 0, null, null },
                    { 10292L, "SBM-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1171), null, 2L, 8L, null, 1L, null, null, null, "Revenue from fossil fuel (coal, oil and gas) sector", 1L, "", 0, null, null },
                    { 10293L, "SBM-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1173), null, 3L, 8L, null, 1L, null, null, null, "Revenue from coal", 1L, "", 0, null, null },
                    { 10294L, "SBM-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1176), null, 3L, 8L, null, 1L, null, null, null, "Revenue from oil", 1L, "", 0, null, null },
                    { 10295L, "SBM-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1178), null, 3L, 8L, null, 1L, null, null, null, "Revenue from gas", 1L, "", 0, null, null },
                    { 10296L, "SBM-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1180), null, 3L, 8L, null, 1L, null, null, null, "Revenue from Taxonomy-aligned economic activities related to fossil gas", 1L, "", 0, null, null },
                    { 10297L, "SBM-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1182), null, 3L, 8L, null, 1L, null, null, null, "Undertaking is active in chemicals production", 1L, "", 0, null, null },
                    { 10298L, "SBM-1_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1184), null, 2L, 8L, null, 1L, null, null, null, "Revenue from chemicals production", 1L, "", 0, null, null },
                    { 10299L, "SBM-1_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1186), null, 3L, 8L, null, 1L, null, null, null, "Undertaking is active in controversial weapons", 1L, "", 0, null, null },
                    { 10300L, "SBM-1_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1192), null, 2L, 8L, null, 1L, null, null, null, "Revenue from controversial weapons", 1L, "", 0, null, null },
                    { 10301L, "SBM-1_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1196), null, 3L, 8L, null, 1L, null, null, null, "Undertaking is active in cultivation and production of tobacco", 1L, "", 0, null, null },
                    { 10302L, "SBM-1_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1198), null, 2L, 8L, null, 1L, null, null, null, "Revenue from cultivation and production of tobacco", 1L, "", 0, null, null },
                    { 10303L, "SBM-1_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1200), null, 3L, 8L, true, 1L, null, null, null, "Description of sustainability-related goals in terms of significant groups of products and services, customer categories, geographical areas and relationships with stakeholders ", 1L, "", 0, null, null },
                    { 10304L, "SBM-1_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1202), null, 2L, 8L, true, 1L, null, null, null, "Disclosure of assessment of current significant products and (or) services, and significant markets and customer groups, in relation to sustainability-related goals ", 1L, "", 0, null, null },
                    { 10305L, "SBM-1_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1205), null, 2L, 8L, true, 1L, null, null, null, "Disclosure of elements of strategy that relate to or impact sustainability matters ", 1L, "", 0, null, null },
                    { 10306L, "SBM-1_24", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1207), null, 2L, 8L, null, 1L, null, null, null, "List of ESRS sectors that are significant for undertaking", 1L, "", 0, null, null },
                    { 10307L, "SBM-1_25", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1209), null, 2L, 8L, true, 1L, null, null, null, "Description of business model and value chain ", 1L, "", 0, null, null },
                    { 10308L, "SBM-1_26", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1211), null, 2L, 8L, true, 1L, null, null, null, "Description of inputs and approach to gathering, developing and securing inputs ", 1L, "", 0, null, null },
                    { 10309L, "SBM-1_27", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1213), null, 2L, 8L, true, 1L, null, null, null, "Description of outputs and outcomes in terms of current and expected benefits for customers, investors and other stakeholders ", 1L, "", 0, null, null },
                    { 10310L, "SBM-1_28", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1216), null, 2L, 8L, true, 1L, null, null, null, "Description of main features of upstream and downstream value chain and undertakings position in value chain ", 1L, "", 0, null, null },
                    { 10311L, "SBM-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1218), null, 2L, 9L, true, 1L, null, null, null, "Description of stakeholder engagement ", 1L, "", 0, null, null },
                    { 10312L, "SBM-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1220), null, 2L, 9L, true, 1L, null, null, null, "Description of key stakeholders ", 1L, "", 0, null, null },
                    { 10313L, "SBM-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1222), null, 2L, 9L, true, 1L, null, null, null, "Description of categories of stakeholders for which engagement occurs ", 1L, "", 0, null, null },
                    { 10314L, "SBM-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1224), null, 2L, 9L, true, 1L, null, null, null, "Description of how stakeholder engagement is organised ", 1L, "", 0, null, null },
                    { 10315L, "SBM-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1227), null, 2L, 9L, true, 1L, null, null, null, "Description of purpose of stakeholder engagement ", 1L, "", 0, null, null },
                    { 10316L, "SBM-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1230), null, 2L, 9L, true, 1L, null, null, null, "Description of how outcome of stakeholder engagement is taken into account ", 1L, "", 0, null, null },
                    { 10317L, "SBM-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1232), null, 2L, 9L, true, 1L, null, null, null, "Description of understanding of interests and views of key stakeholders as they relate to undertaking's strategy and business model ", 1L, "", 0, null, null },
                    { 10318L, "SBM-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1240), null, 2L, 9L, true, 1L, null, null, null, "Description of amendments to strategy and (or) business model ", 1L, "", 0, null, null },
                    { 10319L, "SBM-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1242), null, 2L, 9L, true, 1L, null, null, null, "Description of how strategy and (or) business model have been amended or are expected to be amended to address interests and views of stakeholders ", 1L, "", 0, null, null },
                    { 10320L, "SBM-2_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1245), null, 2L, 9L, true, 1L, null, null, null, "Description of any further steps that are being planned and in what timeline ", 1L, "", 0, null, null },
                    { 10321L, "SBM-2_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1247), null, 2L, 9L, null, 1L, null, null, null, "Further steps that are being planned are likely to modify relationship with and views of stakeholders", 1L, "", 0, null, null },
                    { 10322L, "SBM-2_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1250), null, 2L, 9L, true, 1L, null, null, null, "Description of how administrative, management and supervisory bodies are informed about views and interests of affected stakeholders with regard to sustainability-related impacts ", 1L, "", 0, null, null },
                    { 10323L, "SBM-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1252), null, 2L, 10L, true, 1L, null, null, null, "Description of material impacts resulting from materiality assessment ", 1L, "", 0, null, null },
                    { 10324L, "SBM-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1254), null, 2L, 10L, true, 1L, null, null, null, "Description of material risks and opportunities resulting from materiality assessment ", 1L, "", 0, null, null },
                    { 10325L, "SBM-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1257), null, 2L, 10L, true, 1L, null, null, null, "Disclosure of current and anticipated effects of material impacts, risks and opportunities on business model, value chain, strategy and decision-making, and how undertaking has responded or plans to respond to these effects ", 1L, "", 0, null, null },
                    { 10326L, "SBM-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1259), null, 2L, 10L, true, 1L, null, null, null, "Disclosure of how material negative and positive impacts affect (or are likely to affect) people or environment ", 1L, "", 0, null, null },
                    { 10327L, "SBM-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1261), null, 2L, 10L, true, 1L, null, null, null, "Disclosure of whether and how material impacts originate from or are connected to strategy and business model ", 1L, "", 0, null, null },
                    { 10328L, "SBM-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1263), null, 2L, 10L, true, 1L, null, null, null, "Disclosure of reasonably expected time horizons of material impacts ", 1L, "", 0, null, null },
                    { 10329L, "SBM-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1266), null, 2L, 10L, true, 1L, null, null, null, "Description of nature of activities or business relationships through which undertaking is involved with material impacts ", 1L, "", 0, null, null },
                    { 10330L, "SBM-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1268), null, 2L, 10L, null, 1L, null, null, null, "Disclosure of current financial effects of material risks and opportunities on financial position, financial performance and cash flows and material risks and opportunities for which there is significant risk of material adjustment within next annual reporting period to carrying amounts of assets and liabilities reported in related financial statements ", 1L, "", 0, null, null },
                    { 10331L, "SBM-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1270), null, 2L, 10L, null, 1L, null, null, null, "Disclosure of anticipated financial effects of material risks and opportunities on financial position, financial performance and cash flows over short-, medium- and long-term ", 1L, "", 0, null, null },
                    { 10332L, "SBM-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1273), null, 2L, 10L, true, 1L, null, null, null, "Information about resilience of strategy and business model regarding capacity to address material impacts and risks and to take advantage of material opportunities ", 1L, "", 0, null, null },
                    { 10333L, "SBM-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1275), null, 2L, 10L, true, 1L, null, null, null, "Disclosure of changes to material impacts, risks and opportunities compared to previous reporting period ", 1L, "", 0, null, null },
                    { 10334L, "SBM-3_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1277), null, 2L, 10L, true, 1L, null, null, null, "Disclosure of specification of impacts, risks and opportunities that are covered by ESRS Disclosure Requirements as opposed to those covered by additional entity-specific disclosures ", 1L, "", 0, null, null },
                    { 10335L, "IRO-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1280), null, 2L, 11L, true, 1L, null, null, null, "Description of methodologies and assumptions applied in process to identify impacts, risks and opportunities ", 1L, "", 0, null, null },
                    { 10336L, "IRO-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1286), null, 2L, 11L, true, 1L, null, null, null, "Description of process to identify, assess, prioritise and monitor potential and actual impacts on people and environment, informed by due diligence process ", 1L, "", 0, null, null },
                    { 10337L, "IRO-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1289), null, 2L, 11L, true, 1L, null, null, null, "Description of how process focuses on specific activities, business relationships, geographies or other factors that give rise to heightened risk of adverse impacts ", 1L, "", 0, null, null },
                    { 10338L, "IRO-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1291), null, 2L, 11L, true, 1L, null, null, null, "Description of how process considers impacts with which undertaking is involved through own operations or as result of business relationships ", 1L, "", 0, null, null },
                    { 10339L, "IRO-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1293), null, 2L, 11L, true, 1L, null, null, null, "Description of how process includes consultation with affected stakeholders to understand how they may be impacted and with external experts ", 1L, "", 0, null, null },
                    { 10340L, "IRO-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1295), null, 2L, 11L, true, 1L, null, null, null, "Description of how process prioritises negative impacts based on their relative severity and likelihood and positive impacts based on their relative scale, scope and likelihood and determines which sustainability matters are material for reporting purposes ", 1L, "", 0, null, null },
                    { 10341L, "IRO-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1297), null, 2L, 11L, true, 1L, null, null, null, "Description of process used to identify, assess, prioritise and monitor risks and opportunities that have or may have financial effects ", 1L, "", 0, null, null },
                    { 10342L, "IRO-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1300), null, 2L, 11L, true, 1L, null, null, null, "Description of how connections of impacts and dependencies with risks and opportunities that may arise from those impacts and dependencies have been considered ", 1L, "", 0, null, null },
                    { 10343L, "IRO-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1303), null, 2L, 11L, true, 1L, null, null, null, "Description of how likelihood, magnitude, and nature of effects of identified risks and opportunities have been assessed ", 1L, "", 0, null, null },
                    { 10344L, "IRO-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1305), null, 2L, 11L, true, 1L, null, null, null, "Description of how sustainability-related risks relative to other types of risks have been prioritised ", 1L, "", 0, null, null },
                    { 10345L, "IRO-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1307), null, 2L, 11L, true, 1L, null, null, null, "Description of decision-making process and related internal control procedures ", 1L, "", 0, null, null },
                    { 10346L, "IRO-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1309), null, 2L, 11L, true, 1L, null, null, null, "Description of extent to which and how process to identify, assess and manage impacts and risks is integrated into overall risk management process and used to evaluate overall risk profile and risk management processes ", 1L, "", 0, null, null },
                    { 10347L, "IRO-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1312), null, 2L, 11L, true, 1L, null, null, null, "Description of extent to which and how process to identify, assess and manage opportunities is integrated into overall management process ", 1L, "", 0, null, null },
                    { 10348L, "IRO-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1314), null, 2L, 11L, null, 1L, null, null, null, "Description of input parameters used in process to identify, assess and manage material impacts, risks and opportunities ", 1L, "", 0, null, null },
                    { 10349L, "IRO-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1317), null, 2L, 11L, true, 1L, null, null, null, "Description of how process to identify, assess and manage impacts, risks and opportunities has changed compared to prior reporting period ", 1L, "", 0, null, null },
                    { 10350L, "IRO-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1319), null, 2L, 12L, null, 1L, null, null, null, "Disclosure of list of data points that derive from other EU legislation and information on their location in sustainability statement ", 1L, "", 0, null, null },
                    { 10351L, "IRO-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1321), null, 2L, 12L, null, 1L, null, null, null, "Disclosure of list of ESRS Disclosure Requirements complied with in preparing sustainability statement following outcome of materiality assessment ", 1L, "", 0, null, null },
                    { 10352L, "IRO-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1324), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS E1 Climate change ", 1L, "", 0, null, null },
                    { 10353L, "IRO-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1329), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS E2 Pollution ", 1L, "", 0, null, null },
                    { 10354L, "IRO-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1332), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS E3 Water and marine resources ", 1L, "", 0, null, null },
                    { 10355L, "IRO-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1334), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS E4 Biodiversity and ecosystems ", 1L, "", 0, null, null },
                    { 10356L, "IRO-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1337), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS E5 Circular economy ", 1L, "", 0, null, null },
                    { 10357L, "IRO-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1339), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS S1 Own workforce ", 1L, "", 0, null, null },
                    { 10358L, "IRO-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1341), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS S2 Workers in value chain ", 1L, "", 0, null, null },
                    { 10359L, "IRO-2_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1344), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS S3 Affected communities ", 1L, "", 0, null, null },
                    { 10360L, "IRO-2_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1346), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS S4 Consumers and end-users ", 1L, "", 0, null, null },
                    { 10361L, "IRO-2_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1348), null, 2L, 12L, true, 1L, null, null, null, "Explanation of negative materiality assessment for ESRS G1 Business conduct ", 1L, "", 0, null, null },
                    { 10362L, "IRO-2_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1350), null, 2L, 12L, true, 1L, null, null, null, "Explanation of how material information to be disclosed in relation to material impacts, risks and opportunities has been determined ", 1L, "", 0, null, null },
                    { 10364L, "MDR-P_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1356), null, 2L, 13L, true, 1L, null, null, null, "Description of scope of policy or of its exclusions ", 1L, "", 0, null, null },
                    { 10365L, "MDR-P_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1358), null, 2L, 13L, true, 1L, null, null, null, "Description of most senior level in organisation that is accountable for implementation of policy ", 1L, "", 0, null, null },
                    { 10366L, "MDR-P_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1360), null, 2L, 13L, true, 1L, null, null, null, "Disclosure of third-party standards or initiatives that are respected through implementation of policy ", 1L, "", 0, null, null },
                    { 10367L, "MDR-P_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1362), null, 2L, 13L, true, 1L, null, null, null, "Description of consideration given to interests of key stakeholders in setting policy ", 1L, "", 0, null, null },
                    { 10368L, "MDR-P_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1364), null, 2L, 13L, true, 1L, null, null, null, "Explanation of whether and how policy is made available to potentially affected stakeholders and stakeholders who need to help implement it ", 1L, "", 0, null, null },
                    { 10369L, "MDR-A_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1366), null, 2L, 14L, true, 1L, null, null, null, "Disclosure of key action ", 1L, "", 0, null, null },
                    { 10370L, "MDR-A_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1370), null, 2L, 14L, true, 1L, null, null, null, "Description of scope of key action ", 1L, "", 0, null, null },
                    { 10371L, "MDR-A_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1376), null, 2L, 14L, null, 1L, null, null, null, "Time horizon under which key action is to be completed", 1L, "", 0, null, null },
                    { 10372L, "MDR-A_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1379), null, 2L, 14L, true, 1L, null, null, null, "Description of key action taken, and its results, to provide for and cooperate in or support provision of remedy for those harmed by actual material impacts ", 1L, "", 0, null, null },
                    { 10373L, "MDR-A_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1381), null, 2L, 14L, true, 1L, null, null, null, "Disclosure of quantitative and qualitative information regarding progress of actions or action plans disclosed in prior periods ", 1L, "", 0, null, null },
                    { 10374L, "MDR-A_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1383), null, 2L, 14L, true, 1L, null, null, null, "Disclosure of the type of current and future financial and other resources allocated to the action plan (Capex and Opex)", 1L, "", 0, null, null },
                    { 10375L, "MDR-A_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1385), null, 2L, 14L, true, 1L, null, null, null, "Explanation of how current financial resources relate to most relevant amounts presented in financial statements", 1L, "", 0, null, null },
                    { 10376L, "MDR-A_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1389), null, 2L, 14L, null, 1L, null, null, null, "Current and future financial resources allocated to action plan, breakdown by time horizon and resources", 1L, "", 0, null, null },
                    { 10377L, "MDR-A_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1392), null, 3L, 14L, null, 1L, null, null, null, "Current financial resources allocated to action plan (Capex)", 1L, "", 0, null, null },
                    { 10378L, "MDR-A_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1394), null, 3L, 14L, null, 1L, null, null, null, "Current financial resources allocated to action plan (Opex)", 1L, "", 0, null, null },
                    { 10379L, "MDR-A_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1396), null, 3L, 14L, null, 1L, null, null, null, "Future financial resources allocated to action plan (Capex)", 1L, "", 0, null, null },
                    { 10380L, "MDR-A_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1398), null, 3L, 14L, null, 1L, null, null, null, "Future financial resources allocated to action plan (Opex)", 1L, "", 0, null, null },
                    { 10381L, "MDR-M_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1400), null, 3L, 15L, true, 1L, null, null, null, "Description of metric used to evaluate performance and effectiveness, in relation to material impact, risk or opportunity ", 1L, "", 0, null, null },
                    { 10382L, "MDR-M_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1402), null, 2L, 15L, true, 1L, null, null, null, "Disclosure of methodologies and significant assumptions behind metric ", 1L, "", 0, null, null },
                    { 10383L, "MDR-M_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1406), null, 2L, 15L, true, 1L, null, null, null, "Type of external body other than assurance provider that provides validation ", 1L, "", 0, null, null },
                    { 10384L, "MDR-T_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1408), null, 2L, 16L, true, 1L, null, null, null, "Relationship with policy objectives", 1L, "", 0, null, null },
                    { 10385L, "MDR-T_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1410), null, 2L, 16L, null, 1L, null, null, null, "Measurable target", 1L, "", 0, null, null },
                    { 10386L, "MDR-T_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1412), null, 2L, 16L, null, 1L, null, null, null, "Nature of target", 1L, "", 0, null, null },
                    { 10387L, "MDR-T_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1414), null, 2L, 16L, true, 1L, null, null, null, "Description of scope of target ", 1L, "", 0, null, null },
                    { 10388L, "MDR-T_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1416), null, 2L, 16L, null, 1L, null, null, null, "Baseline value ", 1L, "", 0, null, null },
                    { 10389L, "MDR-T_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1422), null, null, 16L, null, 1L, null, null, null, "Baseline year", 1L, "", 0, 709L, null },
                    { 10390L, "MDR-T_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1425), null, null, 16L, null, 1L, null, null, null, "Period to which target applies", 1L, "", 0, 709L, null },
                    { 10391L, "MDR-T_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1427), null, 2L, 16L, true, 1L, null, null, null, "Indication of milestones or interim targets ", 1L, "", 0, null, null },
                    { 10392L, "MDR-T_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1429), null, 2L, 16L, true, 1L, null, null, null, "Description of methodologies and significant assumptions used to define target ", 1L, "", 0, null, null },
                    { 10393L, "MDR-T_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1432), null, 2L, 16L, null, 1L, null, null, null, "Target related to environmental matters is based on conclusive scientific evidence", 1L, "", 0, null, null },
                    { 10394L, "MDR-T_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1434), null, 2L, 16L, true, 1L, null, null, null, "Disclosure of whether and how stakeholders have been involved in target setting ", 1L, "", 0, null, null },
                    { 10395L, "MDR-T_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1436), null, 2L, 16L, true, 1L, null, null, null, "Description of any changes in target and corresponding metrics or underlying measurement methodologies, significant assumptions, limitations, sources and adopted processes to collect data ", 1L, "", 0, null, null },
                    { 10396L, "MDR-T_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1438), null, 2L, 16L, true, 1L, null, null, null, "Description of performance against disclosed target ", 1L, "", 0, null, null },
                    { 10397L, "E2.IRO-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1441), null, 2L, 29L, true, 1L, null, null, null, "Information about the process to identify actual and potential pollution-related impacts, risks and opportuntities", 1L, "", 0, null, null },
                    { 10398L, "E2.IRO-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1444), null, 2L, 29L, true, 1L, null, null, null, "Disclosure of whether and how consultations have been conducted (pollution) ", 1L, "", 0, null, null },
                    { 10399L, "E2.IRO-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1446), null, 2L, 29L, true, 1L, null, null, null, "Disclosure of results of materiality assessment (pollution) ", 1L, "", 0, null, null },
                    { 10400L, "E2.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1448), null, 2L, 30L, null, 1L, null, null, null, "Policies to manage its material impacts, risks and opportunities related to pollution [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 10401L, "E2-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1450), null, 2L, 30L, true, 1L, null, null, null, "Disclosure of whether and how policy addresses mitigating negative impacts related to pollution of air, water and soil ", 1L, "", 0, null, null },
                    { 10402L, "E2-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1452), null, 2L, 30L, true, 1L, null, null, null, "Disclosure of  whether and how policy addresses substituting and minimising use of substances of concern and phasing out substances of very high concern ", 1L, "", 0, null, null },
                    { 10403L, "E2-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1455), null, 2L, 30L, true, 1L, null, null, null, "Disclosure of  whether and how policy addresses avoiding incidents and emergency situations, and if and when they occur, controlling and limiting their impact on people and environment ", 1L, "", 0, null, null },
                    { 10404L, "E2-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1458), null, 2L, 30L, true, 1L, null, null, null, "Disclosure of contextual information on relations between policies implemented and how policies contribute to EU Action Plan Towards Zero Pollution for Air, Water and Soil ", 1L, "", 0, null, null },
                    { 10406L, "E2.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1467), null, null, 31L, null, 1L, null, null, null, "Actions and resources in relation to pollution [see ESRS 2 MDR-A]", 1L, "", 0, null, null },
                    { 10407L, "E2-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1469), null, 2L, 31L, null, 1L, null, null, null, "Layer in mitigation hierarchy to which action can be allocated to (pollution)", 1L, "", 0, null, null },
                    { 10408L, "E2-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1472), null, 2L, 31L, null, 1L, null, null, null, "Action related to pollution extends to upstream/downstream value chain engagements", 1L, "", 0, null, null },
                    { 10409L, "E2-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1474), null, 2L, 31L, null, 1L, null, null, null, "Layer in mitigation hierarchy to which resources can be allocated to (pollution)", 1L, "", 0, null, null },
                    { 10410L, "E2-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1476), null, 2L, 31L, true, 1L, null, null, null, "Information about action plans that have been implemented at site-level (pollution) ", 1L, "", 0, null, null },
                    { 10412L, "E2.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1481), null, null, 32L, null, 1L, null, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 0, null, null },
                    { 10413L, "E2-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1483), null, 2L, 32L, true, 1L, null, null, null, "Disclosure of  whether and  how target relates to prevention and control of air pollutants and respective specific loads ", 1L, "", 0, null, null },
                    { 10414L, "E2-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1485), null, 2L, 32L, true, 1L, null, null, null, "Disclosure of  whether and how target relates to prevention and control of emissions to water and respective specific loads ", 1L, "", 0, null, null },
                    { 10415L, "E2-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1487), null, 2L, 32L, true, 1L, null, null, null, "Disclosure of  whether and how target relates to prevention and control of pollution to soil and respective specific loads ", 1L, "", 0, null, null },
                    { 10416L, "E2-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1489), null, 2L, 32L, true, 1L, null, null, null, "Disclosure of  whether and how target relates to prevention and control of  substances of concern and substances of very high concern", 1L, "", 0, null, null },
                    { 10417L, "E2-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1492), null, 2L, 32L, null, 1L, null, null, null, "Ecological thresholds and entity-specific allocations were taken into consideration when setting pollution-related target", 1L, "", 0, null, null },
                    { 10418L, "E2-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1495), null, 2L, 32L, true, 1L, null, null, null, "Disclosure of ecological thresholds identified and methodology used to identify ecological thresholds (pollution) ", 1L, "", 0, null, null },
                    { 10419L, "E2-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1497), null, 2L, 32L, true, 1L, null, null, null, "Disclosure of how ecological entity-specific thresholds were determined (pollution) ", 1L, "", 0, null, null },
                    { 10420L, "E2-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1499), null, 2L, 32L, true, 1L, null, null, null, "Disclosure of how responsibility for respecting identified ecological thresholds is allocated (pollution) ", 1L, "", 0, null, null },
                    { 10421L, "E2-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1501), null, 2L, 32L, null, 1L, null, null, null, "Pollution-related target is mandatory (required by legislation)/voluntary", 1L, "", 0, null, null },
                    { 10422L, "E2-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1504), null, 2L, 32L, null, 1L, null, null, null, "Pollution-related target addresses shortcomings related to Substantial Contribution criteria for Pollution Prevention and Control", 1L, "", 0, null, null },
                    { 10423L, "E2-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1506), null, 2L, 32L, true, 1L, null, null, null, "Information about targets that have been implemented at site-level (pollution) ", 1L, "", 0, null, null },
                    { 10425L, "E2-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1515), null, null, 33L, null, 1L, null, null, null, "Pollution of air, water and soil [multiple dimensions: at site level or  by type of source, by sector or by geographical area", 1L, "", 0, null, null },
                    { 10426L, "E2-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1517), null, 1L, 33L, null, 1L, null, null, null, "Emissions to air by pollutant ", 1L, "", 0, null, null },
                    { 10427L, "E2-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1519), null, null, 33L, null, 1L, null, null, null, "Emissions to water by pollutant  [+ by sectors/Geographical Area/Type of source/Site location]", 1L, "", 0, 79L, null },
                    { 10428L, "E2-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1521), null, null, 33L, null, 1L, null, null, null, "Emissions to soil by pollutant  [+ by sectors/Geographical Area/Type of source/Site location]", 1L, "", 0, 79L, null },
                    { 10429L, "E2-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1523), null, null, 33L, null, 1L, null, null, null, "Microplastics generated and used", 1L, "", 0, 79L, null },
                    { 10430L, "E2-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1525), null, null, 33L, null, 1L, null, null, null, "Microplastics generated", 1L, "", 0, 79L, null },
                    { 10431L, "E2-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1527), null, null, 33L, null, 1L, null, null, null, "Microplastics used", 1L, "", 0, 79L, null },
                    { 10432L, "E2-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1530), null, null, 33L, true, 1L, null, null, null, "Description of changes over time (pollution of air, water and soil) ", 1L, "", 0, 79L, null },
                    { 10433L, "E2-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1532), null, 2L, 33L, true, 1L, null, null, null, "Description of measurement methodologies (pollution of air, water and soil) ", 1L, "", 0, null, null },
                    { 10434L, "E2-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1535), null, 2L, 33L, true, 1L, null, null, null, "Description of process(es) to collect data for pollution-related accounting and reporting ", 1L, "", 0, null, null },
                    { 10435L, "E2-4_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1537), null, 2L, 33L, null, 1L, null, null, null, "Percentage of total emissions of pollutants to water occurring in areas at water risk", 1L, "", 0, null, null },
                    { 10436L, "E2-4_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1539), null, null, 33L, null, 1L, null, null, null, "Percentage of total emissions of pollutants to water occurring in areas of high-water stress", 1L, "", 0, 38L, null },
                    { 10437L, "E2-4_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1541), null, null, 33L, null, 1L, null, null, null, "Percentage of total emissions of pollutants to soil occurring in areas at water risk", 1L, "", 0, 38L, null },
                    { 10438L, "E2-4_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1543), null, null, 33L, null, 1L, null, null, null, "Percentage of total emissions of pollutants to soil occurring in areas of high-water stress", 1L, "", 0, 38L, null },
                    { 10439L, "E2-4_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1546), null, null, 33L, true, 1L, null, null, null, "Disclosure of reasons for choosing inferior methodology to quantify emissions ", 1L, "", 0, 38L, null },
                    { 10440L, "E2-4_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1548), null, 2L, 33L, true, 1L, null, null, null, "Disclosure of list of installations operated that fall under IED and EU BAT Conclusions ", 1L, "", 0, null, null },
                    { 10441L, "E2-4_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1551), null, 2L, 33L, true, 1L, null, null, null, "Disclosure of list of any non-compliance incidents or enforcement actions necessary to ensure compliance in case of breaches of permit conditions ", 1L, "", 0, null, null },
                    { 10442L, "E2-4_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1556), null, 2L, 33L, true, 1L, null, null, null, "Disclosure of actual performance and comparison of environmental performance against emission levels associated with best available techniques (BAT-AEL) as described in EU-BAT conclusions ", 1L, "", 0, null, null },
                    { 10443L, "E2-4_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1558), null, 2L, 33L, true, 1L, null, null, null, "Disclosure of actual performance against environmental performance levels associated with best available techniques (BAT-AEPLs) applicable to sector and installation ", 1L, "", 0, null, null },
                    { 10444L, "E2-4_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1560), null, 2L, 33L, true, 1L, null, null, null, "Disclosure of list of any compliance schedules or derogations granted by competent authorities according to Article 15(4) IED that are associated with implementation of BAT-AELs ", 1L, "", 0, null, null },
                    { 10445L, "E2-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1563), null, 2L, 34L, null, 1L, null, null, null, "Total amount of substances of concern that are generated or used during production or that are procured, breakdown by main hazard classes of substances of concern", 1L, "", 0, null, null },
                    { 10446L, "E2-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1566), null, 1L, 34L, null, 1L, null, null, null, "Total amount of substances of concern that are generated or used during production or that are procured", 1L, "", 0, 79L, null },
                    { 10447L, "E2-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1568), null, null, 34L, null, 1L, null, null, null, "Total amount of substances of concern that leave facilities as emissions, as products, or as part of products or services ", 1L, "", 0, 79L, null },
                    { 10448L, "E2-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1570), null, null, 34L, null, 1L, null, null, null, "Amount of substances of concern that leave facilities as emissions by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10449L, "E2-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1572), null, null, 34L, null, 1L, null, null, null, "Amount of substances of concern that leave facilities as products by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10450L, "E2-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1574), null, null, 34L, null, 1L, null, null, null, "Amount of substances of concern that leave facilities as part of products by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10451L, "E2-5_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1576), null, null, 34L, null, 1L, null, null, null, "Amount of substances of concern that leave facilities as services by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10452L, "E2-5_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1578), null, null, 34L, null, 1L, null, null, null, "Total amount of substances of very high concern that are generated or used during production or that are procured by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10453L, "E2-5_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1581), null, null, 34L, null, 1L, null, null, null, "Total amount of substances of very high concern that leave facilities as emissions, as products, or as part of products or services by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10454L, "E2-5_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1584), null, null, 34L, null, 1L, null, null, null, "Amount of substances of very high concern that leave facilities as emissions by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10455L, "E2-5_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1586), null, null, 34L, null, 1L, null, null, null, "Amount of substances of very high concern that leave facilities as products by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10456L, "E2-5_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1588), null, null, 34L, null, 1L, null, null, null, "Amount of substances of very high concern that leave facilities as part of products by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10457L, "E2-5_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1590), null, null, 34L, null, 1L, null, null, null, "Amount of substances of very high concern that leave facilities as services by main hazard classes of substances of concern", 1L, "", 0, 79L, null },
                    { 10458L, "E2-6_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1592), null, null, 35L, null, 1L, null, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from pollution-related impacts ", 1L, "", 0, 79L, null },
                    { 10459L, "E2-6_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1600), null, 3L, 35L, null, 1L, null, null, null, "Percentage of net revenue made with products and services that are or that contain substances of concern", 1L, "", 0, null, null },
                    { 10460L, "E2-6_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1603), null, null, 35L, null, 1L, null, null, null, "Percentage of net revenue made with products and services that are or that contain substances of very high concern", 1L, "", 0, 38L, null },
                    { 10461L, "E2-6_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1605), null, null, 35L, null, 1L, null, null, null, "Operating expenditures (OpEx) in conjunction with major incidents and deposits (pollution)", 1L, "", 0, 38L, null },
                    { 10462L, "E2-6_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1607), null, 3L, 35L, null, 1L, null, null, null, "Capital expenditures (CapEx) in conjunction with major incidents and deposits (pollution)", 1L, "", 0, null, null },
                    { 10463L, "E2-6_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1609), null, 3L, 35L, null, 1L, null, null, null, "Provisions for environmental protection and remediation costs (pollution)", 1L, "", 0, null, null },
                    { 10464L, "E2-6_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1611), null, 3L, 35L, true, 1L, null, null, null, "Disclosure of qualitative information about anticipated financial effects of material risks and opportunities arising from pollution-related impacts ", 1L, "", 0, null, null },
                    { 10465L, "E2-6_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1613), null, 2L, 35L, true, 1L, null, null, null, "Description of effects considered, related impacts and time horizons in which they are likely to materialise (pollution) ", 1L, "", 0, null, null },
                    { 10466L, "E2-6_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1616), null, 2L, 35L, true, 1L, null, null, null, "Disclosure of critical assumptions used to quantify anticipated financial effects, sources and level of uncertainty of assumptions (pollution) ", 1L, "", 0, null, null },
                    { 10467L, "E2-6_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1619), null, 2L, 35L, true, 1L, null, null, null, "Description of material incidents and deposits whereby pollution had negative impacts on environment and (or) is expected to have negative effects on financial cash flows, financial position and financial performance ", 1L, "", 0, null, null },
                    { 10468L, "E2-6_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1621), null, 2L, 35L, true, 1L, null, null, null, "Disclosure of assessment of related products and services at risk and explanation how time horizon is defined, financial amounts are estimated, and which critical assumptions are made (pollution) ", 1L, "", 0, null, null },
                    { 10469L, "E3.IRO-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1623), null, 2L, 36L, true, 1L, null, null, null, "Disclosure of whether and how assets and activities have been screened in order to identify actual and potential water and marine resources-related impacts, risks and opportunities in own operations and upstream and downstream value chain and methodologies, assumptions and tools used in screening [text block]", 1L, "", 0, null, null },
                    { 10470L, "E3.IRO-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1625), null, 2L, 36L, true, 1L, null, null, null, "Disclosure of how consultations have been conducted (water and marine resources) [text block]", 1L, "", 0, null, null },
                    { 10471L, "E3.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1627), null, 2L, 37L, null, 1L, null, null, null, "Policies to manage its material impacts, risks and opportunities related to water and marine resources [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 10472L, "E3-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1630), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of whether and how policy adresses water management ", 1L, "", 0, null, null },
                    { 10473L, "E3-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1632), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of whether and how policy adresses the use and sourcing of water and marine resources in own operations ", 1L, "", 0, null, null },
                    { 10474L, "E3-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1635), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of whether and  how policy adresses water treatment", 1L, "", 0, null, null },
                    { 10475L, "E3-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1637), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of whether and how policy adresses prevention and abatment of water pollution", 1L, "", 0, null, null },
                    { 10476L, "E3-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1639), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of whether and how policy adresses product and service design in view of addressing water-related issues and preservation of marine resources ", 1L, "", 0, null, null },
                    { 10477L, "E3-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1646), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of whether and how policy adresses commitment to reduce material water consumption in areas at water risk ", 1L, "", 0, null, null },
                    { 10478L, "E3-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1648), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of reasons for not having adopted policies in areas of high-water stress ", 1L, "", 0, null, null },
                    { 10479L, "E3-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1651), null, 2L, 37L, true, 1L, null, null, null, "Disclosure of timeframe in which policies in areas of high-water stress will be adopted ", 1L, "", 0, null, null },
                    { 10480L, "E3-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1653), null, 2L, 37L, null, 1L, null, null, null, "Policies or practices related to sustainable oceans and seas have been adopted", 1L, "", 0, null, null },
                    { 10481L, "E3-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1656), null, 2L, 37L, null, 1L, null, null, null, "The policly contributes to good ecological and chemical quality of surface water bodies and good chemical quality and quantity of groundwater bodies, in order to protect human health, water supply, natural ecosystems and biodiversity, the good environmental status of marine waters and the protection of the resource base upon which marine related activities depend;", 1L, "", 0, null, null },
                    { 10482L, "E3-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1658), null, 2L, 37L, null, 1L, null, null, null, "The policy minimise material impacts and risks and implement mitigation measures that aim to maintain the value and functionality of priority services and to increase resource efficiency on own operations", 1L, "", 0, null, null },
                    { 10483L, "E3-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1660), null, 2L, 37L, null, 1L, null, null, null, "The policy avoid impacts on affected communities.", 1L, "", 0, null, null },
                    { 10485L, "E3.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1664), null, null, 38L, null, 1L, null, null, null, "Actions and resources in relation to water and marine resources [see ESRS 2 MDR-A]", 1L, "", 0, null, null },
                    { 10486L, "E3-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1666), null, 2L, 38L, null, 1L, null, null, null, "Layer in mitigation hierarchy to which action and resources can be allocated to (water and marine resources)", 1L, "", 0, null, null },
                    { 10487L, "E3-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1669), null, 2L, 38L, true, 1L, null, null, null, "Information about specific collective action for water and marine resources ", 1L, "", 0, null, null },
                    { 10488L, "E3-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1672), null, 2L, 38L, true, 1L, null, null, null, "Disclosure of actions and resources  in relation to areas at water risk ", 1L, "", 0, null, null },
                    { 10490L, "E3.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1676), null, null, 39L, null, 1L, null, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 0, null, null },
                    { 10491L, "E3-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1678), null, 2L, 39L, true, 1L, null, null, null, "Disclosure of whether and  how target relates to management of material impacts, risks and opportunities related to areas at water risk ", 1L, "", 0, null, null },
                    { 10492L, "E3-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1680), null, 2L, 39L, true, 1L, null, null, null, "Disclosure of whether and  how target relates to responsible management of marine resources impacts, risks and opportunities ", 1L, "", 0, null, null },
                    { 10493L, "E3-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1682), null, 2L, 39L, true, 1L, null, null, null, "Disclosure of whether and how target relates to reduction of water consumption ", 1L, "", 0, null, null },
                    { 10494L, "E3-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1684), null, 2L, 39L, null, 1L, null, null, null, "(Local) ecological threshold and entity-specific allocation were taken into consideration when setting water and marine resources target", 1L, "", 0, null, null },
                    { 10495L, "E3-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1692), null, 2L, 39L, null, 1L, null, null, null, "Disclosure of ecological threshold identified and methodology used to identify ecological threshold (water and marine resources) ", 1L, "", 0, null, null },
                    { 10496L, "E3-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1694), null, 2L, 39L, null, 1L, null, null, null, "Disclosure of how ecological entity-specific threshold was determined (water and marine resources) ", 1L, "", 0, null, null },
                    { 10497L, "E3-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1696), null, 2L, 39L, true, 1L, null, null, null, "Disclosure of how responsibility for respecting identified ecological threshold is allocated (water and marine resources) ", 1L, "", 0, null, null },
                    { 10498L, "E3-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1698), null, 2L, 39L, null, 1L, null, null, null, "Adopted and presented water and marine resources-related target is mandatory (based on legislation)", 1L, "", 0, null, null },
                    { 10499L, "E3-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1700), null, 2L, 39L, null, 1L, null, null, null, "Target relates to reduction of water withdrawals", 1L, "", 0, null, null },
                    { 10500L, "E3-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1702), null, 2L, 39L, null, 1L, null, null, null, "Target relates to reduction of water discharges", 1L, "", 0, null, null },
                    { 10502L, "E3-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1708), null, null, 40L, null, 1L, null, null, null, "Total water consumption", 1L, "", 0, null, null },
                    { 10503L, "E3-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1710), null, null, 40L, null, 1L, null, null, null, "Total water consumption in areas at water risk, including areas of high-water stress", 1L, "", 0, 120L, null },
                    { 10504L, "E3-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1713), null, null, 40L, null, 1L, null, null, null, "Total water recycled and reused", 1L, "", 0, 120L, null },
                    { 10505L, "E3-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1715), null, null, 40L, null, 1L, null, null, null, "Total water stored", 1L, "", 0, 120L, null },
                    { 10506L, "E3-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1717), null, null, 40L, null, 1L, null, null, null, "Changes in water storage", 1L, "", 0, 120L, null },
                    { 10507L, "E3-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1719), null, null, 40L, true, 1L, null, null, null, "Disclosure of contextual information regarding warter consumption", 1L, "", 0, 120L, null },
                    { 10508L, "E3-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1721), null, 2L, 40L, null, 1L, null, null, null, "Share of the measure obtained from direct measurement, from sampling and extrapolation, or from best estimates", 1L, "", 0, null, null },
                    { 10509L, "E3-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1724), null, null, 40L, null, 1L, null, null, null, "Water intensity ratio", 1L, "", 0, 38L, null },
                    { 10510L, "E3-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1726), null, null, 40L, null, 1L, null, null, null, "Water consumption - sectors/SEGMENTS [table]", 1L, "", 0, 120L, null },
                    { 10511L, "E3-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1728), null, null, 40L, null, 1L, null, null, null, "Additional water intensity ratio", 1L, "", 0, 120L, null },
                    { 10512L, "E3-4_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1737), null, null, 40L, null, 1L, null, null, null, "Total water withdrawals", 1L, "", 0, 38L, null },
                    { 10513L, "E3-4_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1739), null, null, 40L, null, 1L, null, null, null, "Total water discharges", 1L, "", 0, 120L, null },
                    { 10514L, "E3-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1741), null, null, 41L, null, 1L, null, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from water and marine resources-related impacts ", 1L, "", 0, 120L, null },
                    { 10515L, "E3-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1743), null, 3L, 41L, true, 1L, null, null, null, "Disclosure of qualitative information of anticipated financial effects of material risks and opportunities arising from water and marine resources-related impacts ", 1L, "", 0, null, null },
                    { 10516L, "E3-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1746), null, 2L, 41L, true, 1L, null, null, null, "Description of effects considered and related impacts (water and marine resources) ", 1L, "", 0, null, null },
                    { 10517L, "E3-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1749), null, 2L, 41L, true, 1L, null, null, null, "Disclosure of critical assumptions used in estimates of financial effects of material risks and opportunities arising from water and marine resources-related impacts ", 1L, "", 0, null, null },
                    { 10518L, "E3-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1751), null, 2L, 41L, true, 1L, null, null, null, "Description of related products and services at risk (water and marine resources) ", 1L, "", 0, null, null },
                    { 10519L, "E3-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1753), null, 2L, 41L, true, 1L, null, null, null, "Explanation of how time horizons are defined, financial amounts are estimated and critical assumptions made (water and marine resources) ", 1L, "", 0, null, null },
                    { 10520L, "E4.SBM-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1755), null, 2L, 42L, true, 1L, null, null, null, "List of material sites in own operation", 1L, "", 0, null, null },
                    { 10521L, "E4.SBM-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1757), null, 2L, 42L, true, 1L, null, null, null, "Disclosure of activities negatively affecting biodiversity sensitive areeas", 1L, "", 0, null, null },
                    { 10522L, "E4.SBM-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1760), null, 2L, 42L, true, 1L, null, null, null, "Disclosure of list of material sites in own operations based on results of identification and assessment of actual and potential impacts on biodiversity and ecosystems", 1L, "", 0, null, null },
                    { 10523L, "E4.SBM-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1763), null, 2L, 42L, true, 1L, null, null, null, "Disclosure of biodiversity-sensitive areas impacted ", 1L, "", 0, null, null },
                    { 10524L, "E4.SBM-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1765), null, 2L, 42L, null, 1L, null, null, null, "Material negative impacts with regards to land degradation, desertification or soil sealing have been identified", 1L, "", 0, null, null },
                    { 10525L, "E4.SBM-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1767), null, 2L, 42L, null, 1L, null, null, null, "Own operations affect threatened species", 1L, "", 0, null, null },
                    { 10526L, "E4.IRO-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1769), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how actual and potential impacts on biodiversity and ecosystems at own site locations and in value chain have been identified and assessed ", 1L, "", 0, null, null },
                    { 10527L, "E4.IRO-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1771), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how dependencies on biodiversity and ecosystems and their services have been identified and assessed at own site locations and in value chain ", 1L, "", 0, null, null },
                    { 10528L, "E4.IRO-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1774), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how transition and physical risks and opportunities related to biodiversity and ecosystems have been identified and assessed ", 1L, "", 0, null, null },
                    { 10529L, "E4.IRO-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1777), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how systemic risks have been considered (biodiversity and ecosystems)", 1L, "", 0, null, null },
                    { 10530L, "E4.IRO-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1784), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how consultations with affected communities on sustainability assessments of shared biological resources and ecosystems have been conducted ", 1L, "", 0, null, null },
                    { 10531L, "E4.IRO-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1786), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how specific sites, raw materials production or sourcing with negative or potential negative impacts on affected communities ", 1L, "", 0, null, null },
                    { 10532L, "E4.IRO-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1789), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how communities were involved in materiality assessment ", 1L, "", 0, null, null },
                    { 10533L, "E4.IRO-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1791), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how negative impacts on priority ecosystem services of relevance to affected communities may be avoided ", 1L, "", 0, null, null },
                    { 10534L, "E4.IRO-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1793), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of plans to minimise unavoidable negative impacts and implement mitigation measures that aim to maintain value and functionality of priority services ", 1L, "", 0, null, null },
                    { 10535L, "E4.IRO-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1795), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of whether and how tthe business model(s) has been verified using range of biodiversity and ecosystems scenarios, or other scenarios with modelling of biodiversity and ecosystems related consequences, with different possible pathways", 1L, "", 0, null, null },
                    { 10536L, "E4.IRO-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1798), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of why considered scenarios were taken into consideration ", 1L, "", 0, null, null },
                    { 10537L, "E4.IRO-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1801), null, 2L, 43L, true, 1L, null, null, null, "Disclosure of how considered scenarios are updated according to evolving conditions and emerging trends ", 1L, "", 0, null, null },
                    { 10538L, "E4.IRO-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1803), null, 2L, 43L, null, 1L, null, null, null, "Scenarios are informed by expectations in authoritative intergovernmental instruments and by scientific consensus", 1L, "", 0, null, null },
                    { 10539L, "E4.IRO-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1805), null, 2L, 43L, null, 1L, null, null, null, "Undertaking has sites located in or near biodiversity-sensitive areas", 1L, "", 0, null, null },
                    { 10540L, "E4.IRO-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1807), null, 2L, 43L, null, 1L, null, null, null, "Activities related to sites located in or near biodiversity-sensitive areas negatively affect these areas by leading to deterioration of natural habitats and habitats of species and to disturbance of species for which protected area has been designated", 1L, "", 0, null, null },
                    { 10541L, "E4.IRO-1_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1809), null, 2L, 43L, null, 1L, null, null, null, "It has been concluded that it is necessary to implement biodiversity mitigation measures", 1L, "", 0, null, null },
                    { 10542L, "E4-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1811), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of resilience of current business model(s) and strategy to biodiversity and ecosystems-related physical, transition and systemic risks and opportunities ", 1L, "", 0, null, null },
                    { 10543L, "E4-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1814), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of scope of resilience analysis along own operations and related upstream and downstream value chain ", 1L, "", 0, null, null },
                    { 10544L, "E4-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1816), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of key assumptions made (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10545L, "E4-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1818), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of time horizons used for analysis (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10546L, "E4-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1821), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of results of resilience analysis (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10547L, "E4-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1823), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of involvement of stakeholders (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10548L, "E4-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1829), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of transition plan to improve and achieve alignment of its business model and strategy", 1L, "", 0, null, null },
                    { 10549L, "E4-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1831), null, 2L, 44L, true, 1L, null, null, null, "Explanation of how strategy and business model will be adjusted to improve and, ultimately, achieve alignment with relevant local, national and global public policy goals", 1L, "", 0, null, null },
                    { 10550L, "E4-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1835), null, 2L, 44L, true, 1L, null, null, null, "Include information about  its own operations and  explain how it is responding to material impacts in its related value chain", 1L, "", 0, null, null },
                    { 10551L, "E4-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1837), null, 2L, 44L, true, 1L, null, null, null, "Explanation of how b strategy interacts with  transition plan ", 1L, "", 0, null, null },
                    { 10552L, "E4-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1839), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of contribution to impact drivers and possible mitigation actions following mitigation hierarchy and main path-dependencies and locked-in assets and resources that are associated with biodiversity and ecosystems change ", 1L, "", 0, null, null },
                    { 10553L, "E4-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1841), null, 2L, 44L, true, 1L, null, null, null, "Explanation and quantification of investments and funding supporting the implementation of its transition plan", 1L, "", 0, null, null },
                    { 10554L, "E4-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1843), null, 2L, 44L, true, 1L, null, null, null, "Disclosure of objectives or plans for aligning economic activities (revenues, CapEx)", 1L, "", 0, null, null },
                    { 10555L, "E4-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1845), null, 2L, 44L, true, 1L, null, null, null, "Biodiversity offsets are part of transition plan", 1L, "", 0, null, null },
                    { 10556L, "E4-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1848), null, 2L, 44L, true, 1L, null, null, null, "Information about how process of implementing and updating transition plan is managed ", 1L, "", 0, null, null },
                    { 10557L, "E4-1_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1851), null, 2L, 44L, true, 1L, null, null, null, "Indication of metrics and related tools used to measure progress that are integrated in measurement approach (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10558L, "E4-1_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1853), null, 2L, 44L, true, 1L, null, null, null, "Administrative, management and supervisory bodies have approved transition plan", 1L, "", 0, null, null },
                    { 10559L, "E4-1_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1855), null, 2L, 44L, true, 1L, null, null, null, "Indication of current challenges and limitations to draft plan in relation to areas of significant impact and actions company is taking to address them (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10560L, "E4.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1857), null, 2L, 45L, null, 1L, null, null, null, "Policies to manage material impacts, risks, dependencies and opportunities related to biodiversity and ecosystems [see ESRS 2 - MDR-P]", 1L, "", 0, null, null },
                    { 10561L, "E4-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1860), null, 2L, 45L, true, 1L, null, null, null, "Disclosure on whether and how biodiversity and ecosystems-related policies relate to matters reported in E4 AR4", 1L, "", 0, null, null },
                    { 10562L, "E4-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1862), null, 2L, 45L, true, 1L, null, null, null, "Explanation of whether and  how biodiversity and ecosystems-related policy relates to material biodiversity and ecosystems-related impacts ", 1L, "", 0, null, null },
                    { 10563L, "E4-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1864), null, 2L, 45L, true, 1L, null, null, null, "Explanation of whether and  how biodiversity and ecosystems-related policy relates to material dependencies and material physical and transition risks and opportunities ", 1L, "", 0, null, null },
                    { 10564L, "E4-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1867), null, 2L, 45L, true, 1L, null, null, null, "Explanation of whether and how biodiversity and ecosystems-related policy supports traceability of products, components and raw materials with significant actual or potential impacts on biodiversity and ecosystems along value chain ", 1L, "", 0, null, null },
                    { 10565L, "E4-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1874), null, 2L, 45L, true, 1L, null, null, null, "Explanation of whether and how biodiversity and ecosystems-related policy addresses production, sourcing or consumption from ecosystems that are managed to maintain or enhance conditions for biodiversity ", 1L, "", 0, null, null },
                    { 10566L, "E4-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1876), null, 2L, 45L, true, 1L, null, null, null, "Explanation of whether and how biodiversity and ecosystems-related policy addresses social consequences of biodiversity and ecosystems-related impacts ", 1L, "", 0, null, null },
                    { 10567L, "E4-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1878), null, 2L, 45L, true, 1L, null, null, null, "Disclosure of how policy refers to production, sourcing or consumption of raw materials ", 1L, "", 0, null, null },
                    { 10568L, "E4-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1881), null, 2L, 45L, true, 1L, null, null, null, "Disclosure of how policy refers to policies limiting procurement from suppliers that cannot demonstrate that they are not contributing to significant conversion of protected areas or key biodiversity areas ", 1L, "", 0, null, null },
                    { 10569L, "E4-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1883), null, 2L, 45L, true, 1L, null, null, null, "Disclosure of how policy refers to recognised standards or third-party certifications overseen by regulators ", 1L, "", 0, null, null },
                    { 10570L, "E4-2_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1886), null, 2L, 45L, true, 1L, null, null, null, "Disclosure of how policy addresses raw materials originating from ecosystems that have been managed to maintain or enhance conditions for biodiversity, as demonstrated by regular monitoring and reporting of biodiversity status and gains or losses", 1L, "", 0, null, null },
                    { 10571L, "E4-2_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1888), null, 2L, 45L, true, 1L, null, null, null, "Disclosure of how the policy enables to a), b), c) and d)", 1L, "", 0, null, null },
                    { 10572L, "E4-2_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1890), null, 2L, 45L, null, 1L, null, null, null, "Third-party standard of conduct used in policy is objective and achievable based on scientific approach to identifying issues and realistic in assessing how these issues can be addressed under variety of practical circumstances", 1L, "", 0, null, null },
                    { 10573L, "E4-2_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1892), null, 2L, 45L, null, 1L, null, null, null, "Third-party standard of conduct used in policy is developed or maintained through process of ongoing consultation with relevant stakeholders with balanced input from all relevant stakeholder groups with no group holding undue authority or veto power over content", 1L, "", 0, null, null },
                    { 10574L, "E4-2_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1894), null, 2L, 45L, null, 1L, null, null, null, "Third-party standard of conduct used in policy encourages step-wise approach and continuous improvement in standard and its application of better management practices and requires establishment of meaningful targets and specific milestones to indicate progress against principles and criteria over time", 1L, "", 0, null, null },
                    { 10575L, "E4-2_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1897), null, 2L, 45L, null, 1L, null, null, null, "Third-party standard of conduct used in policy is verifiable through independent certifying or verifying bodies, which have defined and rigorous assessment procedures that avoid conflicts of interest and are compliant with ISO guidance on accreditation and verification procedures or Article 5(2) of Regulation (EC) No 765/2008", 1L, "", 0, null, null },
                    { 10576L, "E4-2_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1899), null, 2L, 45L, null, 1L, null, null, null, "Third-party standard of conduct used in policy conforms to ISEAL Code of Good Practice", 1L, "", 0, null, null },
                    { 10577L, "E4-2_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1902), null, 2L, 45L, null, 1L, null, null, null, "Biodiversity and ecosystem protection policy covering operational sites owned, leased, managed in or near protected area or biodiversity-sensitive area outside protected areas has been adopted", 1L, "", 0, null, null },
                    { 10578L, "E4-2_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1904), null, 2L, 45L, null, 1L, null, null, null, "Sustainable land or agriculture practices or policies have been adopted", 1L, "", 0, null, null },
                    { 10579L, "E4-2_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1906), null, 2L, 45L, null, 1L, null, null, null, "Sustainable oceans or seas practices or policies have been adopted", 1L, "", 0, null, null },
                    { 10580L, "E4-2_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1908), null, 2L, 45L, null, 1L, null, null, null, "Policies to address deforestation have been adopted", 1L, "", 0, null, null },
                    { 10582L, "E4.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1912), null, null, 46L, null, 1L, null, null, null, "Actions and resources in relation to biodiversity and ecosystems [see ESRS 2 - MDR-A]", 1L, "", 0, null, null },
                    { 10583L, "E4-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1919), null, 2L, 46L, true, 1L, null, null, null, "Disclosure on how the mitigation hierarchy has been applied with regard to biodiversity and ecosystem actions", 1L, "", 0, null, null },
                    { 10584L, "E4-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1922), null, 2L, 46L, null, 1L, null, null, null, "Biodiversity offsets were used in action plan", 1L, "", 0, null, null },
                    { 10585L, "E4-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1924), null, 2L, 46L, true, 1L, null, null, null, "Disclosure of aim of biodiversity offset and key performance indicators used ", 1L, "", 0, null, null },
                    { 10586L, "E4-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1926), null, 2L, 46L, null, 1L, null, null, null, "Financing effects (direct and indirect costs) of biodiversity offsets", 1L, "", 0, null, null },
                    { 10587L, "E4-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1928), null, 3L, 46L, true, 1L, null, null, null, "Explanation of rekationship of significant Capex and Opex required to impelement actions taken or planned to relevant line items or notes in the financial statements", 1L, "", 0, null, null },
                    { 10588L, "E4-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1930), null, 2L, 46L, true, 1L, null, null, null, "Explanation of rekationship of significant Capex and Opex required to impelement actions taken or planned to key  performance indicators required under Commission Delegated Regulation (EU) 2021/2178", 1L, "", 0, null, null },
                    { 10589L, "E4-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1933), null, 2L, 46L, true, 1L, null, null, null, "Explanation of rekationship of significant Capex and Opex required to impelement actions taken or planned to Capex plan required under Commission Delegated Regulation (EU) 2021/2178", 1L, "", 0, null, null },
                    { 10590L, "E4-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1935), null, 2L, 46L, true, 1L, null, null, null, "Description of biodiversity offsets ", 1L, "", 0, null, null },
                    { 10591L, "E4-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1939), null, 2L, 46L, true, 1L, null, null, null, "Description of whether and how local and indigenous knowledge and nature-based solutions have been incorporated into biodiversity and ecosystems-related action ", 1L, "", 0, null, null },
                    { 10592L, "E4-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1941), null, 2L, 46L, true, 1L, null, null, null, "Disclosure of key stakeholders involved and how they are involved, key stakeholders negatively or positively impacted by action and how they are impacted ", 1L, "", 0, null, null },
                    { 10593L, "E4-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1943), null, 2L, 46L, true, 1L, null, null, null, "Explanation of need for appropriate consultations and need to respect decisions of affected communities ", 1L, "", 0, null, null },
                    { 10594L, "E4-3_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1945), null, 2L, 46L, true, 1L, null, null, null, "Description of whether key action may induce significant negative sustainability impacts (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10595L, "E4-3_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1948), null, 2L, 46L, true, 1L, null, null, null, "Explanation of whether the key action is intended to be a one-time initiative or systematic practice", 1L, "", 0, null, null },
                    { 10596L, "E4-3_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1950), null, 2L, 46L, null, 1L, null, null, null, "Key action plan is carried out only by undertaking (individual action) using its resources (biodiversity and ecosystems)", 1L, "", 0, null, null },
                    { 10597L, "E4-3_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1952), null, 2L, 46L, null, 1L, null, null, null, "Key action plan is part of wider action plan (collective action), of which undertaking is member (biodiversity and ecosystems)", 1L, "", 0, null, null },
                    { 10598L, "E4-3_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1955), null, 2L, 46L, true, 1L, null, null, null, "Additional information about project, its sponsors and other participants (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10600L, "E4.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1959), null, null, 47L, null, 1L, null, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 0, null, null },
                    { 10601L, "E4-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1965), null, 2L, 47L, null, 1L, null, null, null, "Ecological threshold and allocation of impacts to undertaking were applied when setting target (biodiversity and ecosystems)", 1L, "", 0, null, null },
                    { 10602L, "E4-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1968), null, 2L, 47L, true, 1L, null, null, null, "Disclosure of ecological threshold identified and methodology used to identify threshold (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10603L, "E4-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1970), null, 2L, 47L, true, 1L, null, null, null, "Disclosure of how entity-specific threshold was determined (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10604L, "E4-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1972), null, 2L, 47L, true, 1L, null, null, null, "Disclosure of how responsibility for respecting identified ecological threshold is allocated (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10605L, "E4-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1976), null, 2L, 47L, null, 1L, null, null, null, "Target is informed by relevant aspect of EU Biodiversity Strategy for 2030", 1L, "", 0, null, null },
                    { 10606L, "E4-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1978), null, 2L, 47L, true, 1L, null, null, null, "Disclosure of how the targets relate to the biodiversity and ecosystem impacts, dependencies, risks and opportunities identified in relation to own operations and upstream and downstream value chain", 1L, "", 0, null, null },
                    { 10607L, "E4-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1980), null, 2L, 47L, true, 1L, null, null, null, "Disclosure of the geographical scope of the targets", 1L, "", 0, null, null },
                    { 10608L, "E4-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1982), null, 2L, 47L, null, 1L, null, null, null, "Biodiversity offsets were used in setting target", 1L, "", 0, null, null },
                    { 10609L, "E4-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1985), null, 2L, 47L, null, 1L, null, null, null, "Layer in mitigation hierarchy to which target can be allocated (biodiversity and ecosystems)", 1L, "", 0, null, null },
                    { 10610L, "E4-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1987), null, 2L, 47L, null, 1L, null, null, null, "The target addresses shortcomings related to the Substantial Contribution criteria ", 1L, "", 0, null, null },
                    { 10612L, "E4-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1992), null, null, 48L, null, 1L, null, null, null, "Number of sites owned, leased or managed in or near protected areas or key biodiversity areas that undertaking is negatively affecting", 1L, "", 0, null, null },
                    { 10613L, "E4-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1994), null, null, 48L, null, 1L, null, null, null, "Area of sites owned, leased or managed in or near protected areas or key biodiversity areas that undertaking is negatively affecting", 1L, "", 0, 709L, null },
                    { 10614L, "E4-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1996), null, null, 48L, true, 1L, null, null, null, "Disclosure of land-use based on Life Cycle Assessment ", 1L, "", 0, 12L, null },
                    { 10615L, "E4-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(1999), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of metrics considered relevant (land-use change, freshwater-use change and (or) sea-use change) ", 1L, "", 0, null, null },
                    { 10616L, "E4-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2001), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of conversion over time of land cover ", 1L, "", 0, null, null },
                    { 10617L, "E4-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2003), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of changes over time in management of ecosystem ", 1L, "", 0, null, null },
                    { 10618L, "E4-5_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2009), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of changes in spatial configuration of landscape ", 1L, "", 0, null, null },
                    { 10619L, "E4-5_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2014), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of changes in ecosystem structural connectivity ", 1L, "", 0, null, null },
                    { 10620L, "E4-5_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2016), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of functional connectivity ", 1L, "", 0, null, null },
                    { 10621L, "E4-5_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2018), null, 2L, 48L, null, 1L, null, null, null, "Total use of land area", 1L, "", 0, null, null },
                    { 10622L, "E4-5_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2020), null, null, 48L, null, 1L, null, null, null, "Total sealed area", 1L, "", 0, 12L, null },
                    { 10623L, "E4-5_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2022), null, null, 48L, null, 1L, null, null, null, "Nature-oriented area on site", 1L, "", 0, 12L, null },
                    { 10624L, "E4-5_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2024), null, null, 48L, null, 1L, null, null, null, "Nature-oriented area off site", 1L, "", 0, 12L, null },
                    { 10625L, "E4-5_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2027), null, null, 48L, true, 1L, null, null, null, "Disclosure of how pathways of introduction and spread of invasive alien species and risks posed by invasive alien species are managed ", 1L, "", 0, 12L, null },
                    { 10626L, "E4-5_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2030), null, 2L, 48L, null, 1L, null, null, null, "Number of invasive alien species", 1L, "", 0, null, null },
                    { 10627L, "E4-5_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2032), null, null, 48L, null, 1L, null, null, null, "Area covered by invasive alien species", 1L, "", 0, 709L, null },
                    { 10628L, "E4-5_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2034), null, null, 48L, true, 1L, null, null, null, "Disclosure of metrics considered relevant (state of species) ", 1L, "", 0, 12L, null },
                    { 10629L, "E4-5_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2036), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of paragraph in another environment-related standard in which metric is referred to ", 1L, "", 0, null, null },
                    { 10630L, "E4-5_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2038), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of population size, range within specific ecosystems and extinction risk ", 1L, "", 0, null, null },
                    { 10631L, "E4-5_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2041), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of changes in number of individuals of species within specific area ", 1L, "", 0, null, null },
                    { 10632L, "E4-5_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2043), null, 2L, 48L, true, 1L, null, null, null, "Information about species at global extinction risk ", 1L, "", 0, null, null },
                    { 10633L, "E4-5_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2046), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of threat status of species and how activities or pressures may affect threat status ", 1L, "", 0, null, null },
                    { 10634L, "E4-5_23", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2048), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of change in relevant habitat for threatened species as proxy for impact on local population's extinction risk ", 1L, "", 0, null, null },
                    { 10635L, "E4-5_24", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2050), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of ecosystem area coverage ", 1L, "", 0, null, null },
                    { 10636L, "E4-5_25", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2056), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of quality of ecosystems relative to pre-determined reference state ", 1L, "", 0, null, null },
                    { 10637L, "E4-5_26", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2059), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of multiple species within ecosystem ", 1L, "", 0, null, null },
                    { 10638L, "E4-5_27", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2061), null, 2L, 48L, true, 1L, null, null, null, "Disclosure of structural components of ecosystem condition ", 1L, "", 0, null, null },
                    { 10639L, "E4-6_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2063), null, 2L, 49L, null, 1L, null, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from biodiversity- and ecosystem-related impacts and dependencies ", 1L, "", 0, null, null },
                    { 10640L, "E4-6_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2066), null, 3L, 49L, true, 1L, null, null, null, "Disclosure of qualitative information about anticipated financial effects of material risks and opportunities arising from biodiversity- and ecosystem-related impacts and dependencies ", 1L, "", 0, null, null },
                    { 10641L, "E4-6_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2068), null, 2L, 49L, true, 1L, null, null, null, "Description of effects considered, related impacts and dependencies (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10642L, "E4-6_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2070), null, 2L, 49L, true, 1L, null, null, null, "Disclosure of critical assumptions used in estimates of financial effects of material risks and opportunities arising from biodiversity- and ecosystem-related impacts and dependencies ", 1L, "", 0, null, null },
                    { 10643L, "E4-6_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2072), null, 2L, 49L, true, 1L, null, null, null, "Description of related products and services at risk (biodiversity and ecosystems) over the short-, medium- and long-term", 1L, "", 0, null, null },
                    { 10644L, "E4-6_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2074), null, 2L, 49L, null, 1L, null, null, null, "Explanation of how financial amounts are estimated and critical assumptions made (biodiversity and ecosystems) ", 1L, "", 0, null, null },
                    { 10645L, "E5.IRO-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2077), null, 2L, 50L, true, 1L, null, null, null, "Disclosure of whether the undertaking has screened its assets and activities in order to identify actual and potential impacts, risks and opportunities in own operations and upstream and downstream value chain, and if so, methodologies, assumptions and tools used", 1L, "", 0, null, null },
                    { 10646L, "E5.IRO-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2080), null, 2L, 50L, true, 1L, null, null, null, "Disclosure of whether and how the undertaking has conducted consultations (resource and circular economy) ", 1L, "", 0, null, null },
                    { 10647L, "E5.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2082), null, 2L, 51L, null, 1L, null, null, null, "Policies to manage its material impacts, risks and opportunities related to resource use and circular economy [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 10648L, "E5-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2084), null, 2L, 51L, true, 1L, null, null, null, "Disclosure of whether and how policy addresses transitioning away from use of virgin resources, including relative increases in use of secondary (recycled) resources", 1L, "", 0, null, null },
                    { 10649L, "E5-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2086), null, 2L, 51L, true, 1L, null, null, null, "Disclosure of whether and how policy addresses sustainable sourcing and use of renewable resources", 1L, "", 0, null, null },
                    { 10650L, "E5-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2088), null, 2L, 51L, true, 1L, null, null, null, "Description of whether and how policy addresses waste hierarchy (prevention, preparing for re-use, recycling, other recovery, disposal) ", 1L, "", 0, null, null },
                    { 10651L, "E5-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2090), null, 2L, 51L, true, 1L, null, null, null, "Description of  whether and how policy addresses prioritisation of strategies to avoid or minimise waste over waste treatment strategies ", 1L, "", 0, null, null },
                    { 10653L, "E5.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2094), null, null, 52L, null, 1L, null, null, null, "Actions and resources in relation to resource use and circular economy [see ESRS 2 MDR-A]", 1L, "", 0, null, null },
                    { 10654L, "E5-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2102), null, 2L, 52L, true, 1L, null, null, null, "Description of higher levels of resource efficiency in use of technical and biological materials and water", 1L, "", 0, null, null },
                    { 10655L, "E5-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2104), null, 2L, 52L, true, 1L, null, null, null, "Description of higher rates of use of secondary raw materials", 1L, "", 0, null, null },
                    { 10656L, "E5-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2107), null, 2L, 52L, true, 1L, null, null, null, "Description of application of circular design", 1L, "", 0, null, null },
                    { 10657L, "E5-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2109), null, 2L, 52L, true, 1L, null, null, null, "Description of application of circular business practices", 1L, "", 0, null, null },
                    { 10658L, "E5-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2111), null, 2L, 52L, true, 1L, null, null, null, "Description of actions taken to prevent waste generation in the undertaking's upstream and downstram value chain", 1L, "", 0, null, null },
                    { 10659L, "E5-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2113), null, 2L, 52L, true, 1L, null, null, null, "Description of Optimistation of waste management", 1L, "", 0, null, null },
                    { 10660L, "E5-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2116), null, 2L, 52L, true, 1L, null, null, null, "Information about collective action on development of collaborations or initiatives increasing circularity of products and materials ", 1L, "", 0, null, null },
                    { 10661L, "E5-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2118), null, 2L, 52L, true, 1L, null, null, null, "Description of contribution to circular economy ", 1L, "", 0, null, null },
                    { 10662L, "E5-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2121), null, 2L, 52L, true, 1L, null, null, null, "Description of other stakeholders involved in collective action (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10663L, "E5-2_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2123), null, 2L, 52L, true, 1L, null, null, null, "Description of organisation of project (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10665L, "E5.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2127), null, null, 53L, null, 1L, null, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 0, null, null },
                    { 10666L, "E5-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2129), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how target relates to resources (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10667L, "E5-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2132), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how target relates to increase of circular design ", 1L, "", 0, null, null },
                    { 10668L, "E5-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2134), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how target relates to increase of circular material use rate ", 1L, "", 0, null, null },
                    { 10669L, "E5-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2137), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how target relates to minimisation of primary raw material ", 1L, "", 0, null, null },
                    { 10670L, "E5-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2139), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how target relates to reversal of depletion of stock of renewable resources ", 1L, "", 0, null, null },
                    { 10671L, "E5-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2145), null, 2L, 53L, null, 1L, null, null, null, "Target relates to waste management", 1L, "", 0, null, null },
                    { 10672L, "E5-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2147), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how target relates to waste management ", 1L, "", 0, null, null },
                    { 10673L, "E5-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2149), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how target relates to other matters related to resource use or circular economy", 1L, "", 0, null, null },
                    { 10674L, "E5-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2152), null, 2L, 53L, null, 1L, null, null, null, "Layer in waste hierarchy to which target relates", 1L, "", 0, null, null },
                    { 10675L, "E5-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2155), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of ecological threshold identified and methodology used to identify ecological threshold (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10676L, "E5-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2157), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how ecological entity-specific threshold was determined (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10677L, "E5-3_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2159), null, 2L, 53L, true, 1L, null, null, null, "Disclosure of how responsibility for respecting identified ecological threshold is allocated (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10678L, "E5-3_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2161), null, 2L, 53L, null, 1L, null, null, null, "The targets being  set and presented are mandatory (required by legislation)", 1L, "", 0, null, null },
                    { 10680L, "E5-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2165), null, null, 54L, true, 1L, null, null, null, "Disclosure of information on material resource inflows ", 1L, "", 0, null, null },
                    { 10681L, "E5-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2168), null, 2L, 54L, null, 1L, null, null, null, "Overall total weight of products and technical and biological materials used during the reporting period", 1L, "", 0, null, null },
                    { 10682L, "E5-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2170), null, null, 54L, null, 1L, null, null, null, "Percentage of biological materials (and biofuels used for non-energy purposes)", 1L, "", 0, 79L, null },
                    { 10683L, "E5-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2173), null, null, 54L, null, 1L, null, null, null, "The absolute weight of secondary reused or recycled components, secondary intermediary products and secondary materials used to manufacture the undertaking’s products and services (including packaging)", 1L, "", 0, 38L, null },
                    { 10684L, "E5-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2175), null, null, 54L, null, 1L, null, null, null, "Percentage of secondary reused or recycled components, secondary intermediary products and secondary materials", 1L, "", 0, 79L, null },
                    { 10685L, "E5-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2177), null, null, 54L, true, 1L, null, null, null, "Description of methodologies used to calculate data and key assumptions used", 1L, "", 0, 38L, null },
                    { 10686L, "E5-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2179), null, 2L, 54L, true, 1L, null, null, null, "Description of materials that are sourced from by-products or waste stream ", 1L, "", 0, null, null },
                    { 10687L, "E5-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2181), null, 2L, 54L, true, 1L, null, null, null, "Description of how double counting was avoided and of choices made ", 1L, "", 0, null, null },
                    { 10688L, "E5-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2185), null, 2L, 55L, true, 1L, null, null, null, "Description of the key products and materials that come out of the undertaking’s production process", 1L, "", 0, null, null },
                    { 10689L, "E5-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2191), null, 2L, 55L, null, 1L, null, null, null, "Disclosure of the expected durability of the products placed on the market, in relation to the industry average for each product group", 1L, "", 0, null, null },
                    { 10690L, "E5-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2193), null, null, 55L, true, 1L, null, null, null, "Disclosure of the reparability of products", 1L, "", 0, 38L, null },
                    { 10691L, "E5-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2195), null, 2L, 55L, null, 1L, null, null, null, "The rates of recyclable content in products", 1L, "", 0, null, null },
                    { 10692L, "E5-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2197), null, null, 55L, null, 1L, null, null, null, "The rates of recyclable content in products packaging", 1L, "", 0, 38L, null },
                    { 10693L, "E5-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2199), null, null, 55L, true, 1L, null, null, null, "Description of methodologies used to calculate data (resource outflows) ", 1L, "", 0, 38L, null },
                    { 10694L, "E5-5_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2202), null, 2L, 55L, null, 1L, null, null, null, "Total Waste generated", 1L, "", 0, null, null },
                    { 10695L, "E5-5_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2205), null, null, 55L, null, 1L, null, null, null, "Waste diverted from disposal, breakdown by hazardous and non-hazardous waste and treatment type", 1L, "", 0, 79L, null },
                    { 10696L, "E5-5_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2207), null, null, 55L, null, 1L, null, null, null, "Waste directed to disposal, breakdown by hazardous and non-hazardous waste and treatment type", 1L, "", 0, 79L, null },
                    { 10697L, "E5-5_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2209), null, null, 55L, null, 1L, null, null, null, "Non-recycled waste", 1L, "", 0, 79L, null },
                    { 10698L, "E5-5_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2211), null, null, 55L, null, 1L, null, null, null, "Percentage of non-recycled waste", 1L, "", 0, 79L, null },
                    { 10699L, "E5-5_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2213), null, null, 55L, true, 1L, null, null, null, "Disclosure of composition of waste ", 1L, "", 0, 38L, null },
                    { 10700L, "E5-5_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2215), null, 2L, 55L, true, 1L, null, null, null, "Disclosure of waste streams relevant to undertaking's sector or activities ", 1L, "", 0, null, null },
                    { 10701L, "E5-5_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2218), null, 2L, 55L, true, 1L, null, null, null, "Disclosure of materials that are present in waste ", 1L, "", 0, null, null },
                    { 10702L, "E5-5_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2221), null, 2L, 55L, null, 1L, null, null, null, "Total amount of hazardous waste", 1L, "", 0, null, null },
                    { 10703L, "E5-5_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2223), null, null, 55L, null, 1L, null, null, null, "Total amount of radioactive waste", 1L, "", 0, 79L, null },
                    { 10704L, "E5-5_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2225), null, null, 55L, true, 1L, null, null, null, "Description of methodologies used to calculate data (waste generated) ", 1L, "", 0, 79L, null },
                    { 10705L, "E5-5_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2228), null, 2L, 55L, true, 1L, null, null, null, "Disclosure of its engagement in product end-of-life waste management", 1L, "", 0, null, null },
                    { 10706L, "E5-6_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2230), null, 2L, 56L, null, 1L, null, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from resource use and circular economy-related impacts ", 1L, "", 0, null, null },
                    { 10707L, "E5-6_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2236), null, 3L, 56L, true, 1L, null, null, null, "Disclosure of qualitative information of anticipated financial effects of material risks and opportunities arising from resource use and circular economy-related impacts ", 1L, "", 0, null, null },
                    { 10708L, "E5-6_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2238), null, 2L, 56L, true, 1L, null, null, null, "Description of effects considered and related impacts (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10709L, "E5-6_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2241), null, 2L, 56L, true, 1L, null, null, null, "Disclosure of critical assumptions used in estimates of financial effects of material risks and opportunities arising from resource use and circular economy-related impacts ", 1L, "", 0, null, null },
                    { 10710L, "E5-6_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2243), null, 2L, 56L, true, 1L, null, null, null, "Description of related products and services at risk (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10711L, "E5-6_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2246), null, 2L, 56L, true, 1L, null, null, null, "Explanation of how time horizons are defined, financial amounts are estimated and of critical assumptions made (resource use and circular economy) ", 1L, "", 0, null, null },
                    { 10713L, "S1.SBM-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2250), null, 2L, 58L, true, 1L, null, null, null, "Description of types of employees and non-employees in its own workforce subject to material impacts ", 1L, "", 0, null, null },
                    { 10714L, "S1.SBM-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2252), null, 2L, 58L, null, 1L, null, null, null, "Material negative impacts occurrence (own workforce)", 1L, "", 0, null, null },
                    { 10715L, "S1.SBM-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2254), null, 2L, 58L, true, 1L, null, null, null, "Description of activities that result in positive impacts and types of employees and non-employees in its own workforce that are positively affected or could be positively affected ", 1L, "", 0, null, null },
                    { 10716L, "S1.SBM-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2257), null, 2L, 58L, true, 1L, null, null, null, "Description of material risks and opportunities arising from impacts and dependencies on own workforce  ", 1L, "", 0, null, null },
                    { 10717L, "S1.SBM-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2259), null, 2L, 58L, true, 1L, null, null, null, "Description of material impacts on workers that may arise from transition plans for reducing negative impacts on environment and achieving greener and climate-neutral operations ", 1L, "", 0, null, null },
                    { 10718L, "S1.SBM-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2262), null, 2L, 58L, true, 1L, null, null, null, "Information about type of operations at significant risk of incidents of forced labour or compulsory labour ", 1L, "", 0, null, null },
                    { 10719L, "S1.SBM-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2264), null, 2L, 58L, true, 1L, null, null, null, "Information about countries or geographic areas with operations considered at significant risk of incidents of forced labour or compulsory labour ", 1L, "", 0, null, null },
                    { 10720L, "S1.SBM-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2266), null, 2L, 58L, true, 1L, null, null, null, "Information about type of operations at significant risk of incidents of child labour ", 1L, "", 0, null, null },
                    { 10721L, "S1.SBM-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2268), null, 2L, 58L, true, 1L, null, null, null, "Information about countries or geographic areas with operations considered at significant risk of incidents of child labour ", 1L, "", 0, null, null },
                    { 10722L, "S1.SBM-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2271), null, 2L, 58L, true, 1L, null, null, null, "Disclosure of whether and how understanding of people in its own workforce with particular characteristics, working in particular contexts, or undertaking particular activities may be at greater risk of harm has been developed ", 1L, "", 0, null, null },
                    { 10723L, "S1.SBM-3_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2273), null, 2L, 58L, true, 1L, null, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on people in its own workforce  relate to specific groups of people", 1L, "", 0, null, null },
                    { 10724L, "S1.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2280), null, 2L, 59L, null, 1L, null, null, null, "Policies to manage material impacts, risks and opportunities related to its own workforce [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 10725L, "S1-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2283), null, 2L, 59L, null, 1L, null, null, null, "Policies to manage material impacts, risks and opportunities related to own workforce, including for specific groups within workforce or all own workforce", 1L, "", 0, null, null },
                    { 10726L, "S1-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2285), null, 2L, 59L, true, 1L, null, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 0, null, null },
                    { 10727L, "S1-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2287), null, 2L, 59L, true, 1L, null, null, null, "Description of relevant human rights policy commitments relevant to own workforce", 1L, "", 0, null, null },
                    { 10728L, "S1-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2289), null, 2L, 59L, true, 1L, null, null, null, "Disclosure of general approach in relation to respect for human rights including labour rights, of people in its own workforce", 1L, "", 0, null, null },
                    { 10729L, "S1-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2292), null, 2L, 59L, true, 1L, null, null, null, "Disclosure of general approach in relation to engagement with people in its own workforce", 1L, "", 0, null, null },
                    { 10730L, "S1-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2294), null, 2L, 59L, true, 1L, null, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 0, null, null },
                    { 10731L, "S1-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2296), null, 2L, 59L, true, 1L, null, null, null, "Disclosure of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 0, null, null },
                    { 10732L, "S1-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2299), null, 2L, 59L, null, 1L, null, null, null, "Policies explicitly address trafficking in human beings, forced labour or compulsory labour and child labour", 1L, "", 0, null, null },
                    { 10733L, "S1-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2301), null, 2L, 59L, null, 1L, null, null, null, "Workplace accident prevention policy or management system is in place", 1L, "", 0, null, null },
                    { 10734L, "S1-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2303), null, 2L, 59L, null, 1L, null, null, null, "Specific policies aimed at elimination of discrimination are in place", 1L, "", 0, null, null },
                    { 10735L, "S1-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2305), null, 2L, 59L, null, 1L, null, null, null, "Grounds for discrimination are specifically covered in policy", 1L, "", 0, null, null },
                    { 10736L, "S1-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2308), null, 2L, 59L, true, 1L, null, null, null, "Disclosure of specific policy commitments related to inclusion and (or) positive action for people from groups at particular risk of vulnerability in own workforce ", 1L, "", 0, null, null },
                    { 10737L, "S1-1_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2310), null, 2L, 59L, true, 1L, null, null, null, "Disclosure of whether and how policies are implemented through specific procedures to ensure discrimination is prevented, mitigated and acted upon once detected, as well as to advance diversity and inclusion ", 1L, "", 0, null, null },
                    { 10738L, "S1-1_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2312), null, 2L, 59L, true, 1L, null, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 0, null, null },
                    { 10739L, "S1-1_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2315), null, 2L, 59L, null, 1L, null, null, null, "Policies and procedures which make qualifications, skills and experience the basis for the recruitment, placement, training and advancement are in place", 1L, "", 0, null, null },
                    { 10740L, "S1-1_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2317), null, 2L, 59L, null, 1L, null, null, null, "Has assigned responsibility at top management level for equal treatment and opportunities in employment, issue clear company-wide policies and procedures to guide equal employment practices, and link advancement to desired performance in this area", 1L, "", 0, null, null },
                    { 10741L, "S1-1_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2319), null, 2L, 59L, null, 1L, null, null, null, "Staff training on non-discrimination policies and practices are in place", 1L, "", 0, null, null },
                    { 10742L, "S1-1_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2324), null, 2L, 59L, null, 1L, null, null, null, "Adjustments to the physical environment to ensure health and safety for workers, customers and other visitors with disabilities are in place", 1L, "", 0, null, null },
                    { 10743L, "S1-1_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2328), null, 2L, 59L, null, 1L, null, null, null, "Has evaluated whether a there is a risk that job requirements have been defined in a way that would systematically disadvantage certain groups", 1L, "", 0, null, null },
                    { 10744L, "S1-1_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2330), null, 2L, 59L, null, 1L, null, null, null, "Keeping an up-to-date records on recruitment, training and promotion that provide a transparent view of opportunities for employees and their progression", 1L, "", 0, null, null },
                    { 10745L, "S1-1_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2332), null, 2L, 59L, null, 1L, null, null, null, "Has put in place grievance procedures to address complaints, handle appeals and provide recourse for employees when discrimination is identified, and is alert to formal structures and informal cultural issues that can prevent employees from raising concerns and grievances", 1L, "", 0, null, null },
                    { 10746L, "S1-1_22", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2334), null, 2L, 59L, null, 1L, null, null, null, "Has programs to promote access to skills development. ", 1L, "", 0, null, null },
                    { 10748L, "S1-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2338), null, null, 60L, true, 1L, null, null, null, "Disclosure of whether and how perspectives of own workforce  inform decisions or activities aimed at managing actual and potential  impacts ", 1L, "", 0, null, null },
                    { 10749L, "S1-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2340), null, 2L, 60L, null, 1L, null, null, null, "Engagement occurs with own workforce  or their representatives", 1L, "", 0, null, null },
                    { 10750L, "S1-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2343), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 0, null, null },
                    { 10751L, "S1-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2345), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakingâ€™s approach ", 1L, "", 0, null, null },
                    { 10752L, "S1-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2348), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of Global Framework Agreement or other agreements related to respect of human rights of workers ", 1L, "", 0, null, null },
                    { 10753L, "S1-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2350), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of how effectiveness of engagement with its own workforce  is assessed ", 1L, "", 0, null, null },
                    { 10754L, "S1-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2352), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of steps taken to gain insight into perspectives of people in its own workforce that may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 0, null, null },
                    { 10755L, "S1-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2354), null, 2L, 60L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a general process to engage with its own workforce", 1L, "", 0, null, null },
                    { 10756L, "S1-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2356), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of timeframe for adoption of general process to engage with its own workforce in case the undertaking has not adopted a general process for engagement", 1L, "", 0, null, null },
                    { 10757L, "S1-2_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2360), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of how undertaking engages with at-risk or persons in vulnerable situations", 1L, "", 0, null, null },
                    { 10758L, "S1-2_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2362), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of how potential barriers to engagement with people in its workforce are taken into account ", 1L, "", 0, null, null },
                    { 10759L, "S1-2_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2364), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of how people in its workforce are provided with information that is understandable and accessible through appropriate communication channels ", 1L, "", 0, null, null },
                    { 10760L, "S1-2_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2370), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of any conflicting interests that have arisen among different workers and how these conflicting interests have been resolved ", 1L, "", 0, null, null },
                    { 10761L, "S1-2_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2372), null, 2L, 60L, true, 1L, null, null, null, "Disclosure of how undertaking seeks to respect human rights of all stakeholders engaged ", 1L, "", 0, null, null },
                    { 10762L, "S1-2_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2374), null, 2L, 60L, true, 1L, null, null, null, "Information about effectiveness of processes for engaging with its own workforce from previous reporting periods ", 1L, "", 0, null, null },
                    { 10763L, "S1-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2376), null, 2L, 61L, true, 1L, null, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has caused or contributed to a material negative impact on people in its own workforce  ", 1L, "", 0, null, null },
                    { 10764L, "S1-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2379), null, 2L, 61L, true, 1L, null, null, null, "Disclosure of specific channels in place for its own workforce to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 0, null, null },
                    { 10765L, "S1-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2381), null, 2L, 61L, null, 1L, null, null, null, "Third-party mechanisms are accessible to all own workforce", 1L, "", 0, null, null },
                    { 10766L, "S1-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2384), null, 2L, 61L, true, 1L, null, null, null, "Disclosure of whether and how own workforce and their workers' representatives are able to access channels at level of undertaking they are employed by or contracted to work for ", 1L, "", 0, null, null },
                    { 10767L, "S1-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2386), null, 2L, 61L, null, 1L, null, null, null, "Grievance or complaints handling mechanisms related to employee matters exist", 1L, "", 0, null, null },
                    { 10768L, "S1-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2388), null, 2L, 61L, true, 1L, null, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 0, null, null },
                    { 10769L, "S1-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2390), null, 2L, 61L, true, 1L, null, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 0, null, null },
                    { 10770L, "S1-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2392), null, 2L, 61L, true, 1L, null, null, null, "Disclosure of whether and how it is assessed that its own workforce is aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 0, null, null },
                    { 10771L, "S1-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2395), null, 2L, 61L, null, 1L, null, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 0, null, null },
                    { 10772L, "S1-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2398), null, 2L, 61L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a channel for raising concerns ", 1L, "", 0, null, null },
                    { 10773L, "S1-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2400), null, 2L, 61L, true, 1L, null, null, null, "Disclosure of timeframe for channel for raising concerns to be in place", 1L, "", 0, null, null },
                    { 10774L, "S1.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2402), null, 2L, 62L, null, 1L, null, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to its own workforce [see ESRS 2 - MDR-A]", 1L, "", 0, null, null },
                    { 10775L, "S1-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2405), null, 2L, 62L, true, 1L, null, null, null, "Description of action taken, planned or underway to prevent or mitigate negative impacts on own workforce  ", 1L, "", 0, null, null },
                    { 10776L, "S1-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2407), null, 2L, 62L, true, 1L, null, null, null, "Disclosure on whether and how action has been taken to provide or enable remedy in relation to actual material impact", 1L, "", 0, null, null },
                    { 10777L, "S1-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2412), null, 2L, 62L, true, 1L, null, null, null, "Description of additional initiatives or actions with primary purpose of delivering positive impacts for own workforce", 1L, "", 0, null, null },
                    { 10778L, "S1-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2416), null, 2L, 62L, true, 1L, null, null, null, "Description of how effectiveness of actions and initiatives in delivering outcomes for own workforce is tracked and assessed ", 1L, "", 0, null, null },
                    { 10779L, "S1-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2418), null, 2L, 62L, true, 1L, null, null, null, "Description of process through which it identifies what action is needed and appropriate in response to particular actual or potential negative impact on own workforce  ", 1L, "", 0, null, null },
                    { 10780L, "S1-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2421), null, 2L, 62L, true, 1L, null, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on own workforce  and how effectiveness is tracked ", 1L, "", 0, null, null },
                    { 10781L, "S1-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2423), null, 2L, 62L, true, 1L, null, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to own workforce  ", 1L, "", 0, null, null },
                    { 10782L, "S1-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2425), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on own workforce  ", 1L, "", 0, null, null },
                    { 10783L, "S1-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2427), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of resources are allocated to the management of material impacts", 1L, "", 0, null, null },
                    { 10784L, "S1-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2431), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of general and specific approaches to addressing material negative impacts ", 1L, "", 0, null, null },
                    { 10785L, "S1-4_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2433), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of initiatives aimed at contributing to additional material positive impacts ", 1L, "", 0, null, null },
                    { 10786L, "S1-4_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2435), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of how far undertaking has progressed in efforts during reporting period ", 1L, "", 0, null, null },
                    { 10787L, "S1-4_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2437), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of aims for continued improvement ", 1L, "", 0, null, null },
                    { 10788L, "S1-4_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2440), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting own workforce  ", 1L, "", 0, null, null },
                    { 10789L, "S1-4_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2442), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of how the initiative, and its own involvement, is aiming to address the material impact concerned", 1L, "", 0, null, null },
                    { 10790L, "S1-4_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2444), null, 2L, 62L, true, 1L, null, null, null, "Disclosure of whether and how workers and workers' representatives play role in decisions regarding design and implementation of programmes or processes whose primary aim is to deliver positive impacts for workers ", 1L, "", 0, null, null },
                    { 10791L, "S1-4_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2447), null, 2L, 62L, true, 1L, null, null, null, "Information about intended or achieved positive outcomes of programmes or processes for own workforce  ", 1L, "", 0, null, null },
                    { 10792L, "S1-4_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2449), null, 2L, 62L, null, 1L, null, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for own workforce  are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 0, null, null },
                    { 10793L, "S1-4_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2451), null, 2L, 62L, true, 1L, null, null, null, "Information about measures taken to mitigate negative impacts on workers that arise from transition to greener, climate-neutral economy ", 1L, "", 0, null, null },
                    { 10794L, "S1-4_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2454), null, 2L, 62L, true, 1L, null, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 0, null, null },
                    { 10796L, "S1.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2470), null, null, 63L, null, 1L, null, null, null, "Targets set to manage material impacts, risks and opportunities related to own workforce [see ESRS 2 - MDR-T]", 1L, "", 0, null, null },
                    { 10797L, "S1-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2472), null, 2L, 63L, true, 1L, null, null, null, "Disclosure of whether and how own workforce or workforce' representatives were engaged directly in setting targets ", 1L, "", 0, null, null },
                    { 10798L, "S1-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2474), null, 2L, 63L, true, 1L, null, null, null, "Disclosure of whether and how own workforce or workforce' representatives were engaged directly in tracking performance against targets ", 1L, "", 0, null, null },
                    { 10799L, "S1-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2477), null, 2L, 63L, true, 1L, null, null, null, "Disclosure of whether and how own workforce or workforce' representatives were engaged directly in identifying lessons or improvements as result of undertakings performance ", 1L, "", 0, null, null },
                    { 10800L, "S1-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2479), null, 2L, 63L, true, 1L, null, null, null, "Disclosure of intended outcomes to be achieved in lives of people in its own workforce  ", 1L, "", 0, null, null },
                    { 10801L, "S1-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2481), null, 2L, 63L, null, 1L, null, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 0, null, null },
                    { 10802L, "S1-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2483), null, 2L, 63L, true, 1L, null, null, null, "Disclosure of references to standards or commitments which targets are based on", 1L, "", 0, null, null },
                    { 10804L, "S1-6_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2487), null, null, 64L, null, 1L, null, null, null, "Characteristics of undertaking's employees - number of employees by gender [table]", 1L, "", 0, null, null },
                    { 10805L, "S1-6_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2490), null, 1L, 64L, null, 1L, null, null, null, "Number of employees (head count)", 1L, "", 0, null, null },
                    { 10806L, "S1-6_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2492), null, null, 64L, null, 1L, null, null, null, "Average number of employees (head count)", 1L, "", 0, 710L, null },
                    { 10807L, "S1-6_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2495), null, null, 64L, null, 1L, null, null, null, "Characteristics of undertaking's employees - number of employees in countries with 50 or more employees representing at least 10% of total number of employees [table]", 1L, "", 0, 710L, null },
                    { 10808L, "S1-6_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2497), null, 1L, 64L, null, 1L, null, null, null, "Number of employees in countries with 50 or more employees representing at least 10% of total number of employees", 1L, "", 0, null, null },
                    { 10809L, "S1-6_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2499), null, null, 64L, null, 1L, null, null, null, "Average number of employees in countries with 50 or more employees representing at least 10% of total number of employees", 1L, "", 0, 710L, null },
                    { 10810L, "S1-6_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2501), null, null, 64L, null, 1L, null, null, null, "Characteristics of undertaking's employees - information on employees by contract type and gender  [table]", 1L, "", 0, 710L, null },
                    { 10811L, "S1-6_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2503), null, 1L, 64L, null, 1L, null, null, null, "Characteristics of undertaking's employees - information on employees by region [table]", 1L, "", 0, null, null },
                    { 10812L, "S1-6_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2511), null, 1L, 64L, null, 1L, null, null, null, "Number of employees (head count or full-time equivalent)", 1L, "", 0, null, null },
                    { 10813L, "S1-6_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2513), null, null, 64L, null, 1L, null, null, null, "Average number of employees (head count or full-time equivalent)", 1L, "", 0, 710L, null },
                    { 10814L, "S1-6_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2515), null, null, 64L, null, 1L, null, null, null, "Number of employee who have left undertaking ", 1L, "", 0, 710L, null },
                    { 10815L, "S1-6_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2517), null, null, 64L, null, 1L, null, null, null, "Percentage of employee turnover", 1L, "", 0, 710L, null },
                    { 10816L, "S1-6_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2520), null, null, 64L, true, 1L, null, null, null, "Description of methodologies and assumptions used to compile data (employees) ", 1L, "", 0, 38L, null },
                    { 10817L, "S1-6_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2522), null, 2L, 64L, null, 1L, null, null, null, "Employees numbers are reported in head count or full-time equivalent", 1L, "", 0, null, null },
                    { 10818L, "S1-6_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2524), null, 2L, 64L, null, 1L, null, null, null, "Employees numbers are reported at end of reporting period/average/other methodology", 1L, "", 0, null, null },
                    { 10819L, "S1-6_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2528), null, 2L, 64L, true, 1L, null, null, null, "Disclosure of contextual information necessary to understand data (employees) ", 1L, "", 0, null, null },
                    { 10820L, "S1-6_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2530), null, 2L, 64L, true, 1L, null, null, null, "Disclosure of cross-reference of information reported under paragragph 50 (a) to most representative number in financial statements ", 1L, "", 0, null, null },
                    { 10821L, "S1-6_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2532), null, 2L, 64L, null, 1L, null, null, null, "Further detailed breakdown by gender and by region [table]", 1L, "", 0, null, null },
                    { 10822L, "S1-6_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2534), null, 1L, 64L, null, 1L, null, null, null, "Number of full-time employees by head count or full time equivalent", 1L, "", 0, null, null },
                    { 10823L, "S1-6_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2536), null, null, 64L, null, 1L, null, null, null, "Number of part-time employees by head count or full time equivalent", 1L, "", 0, 710L, null },
                    { 10824L, "S1-7_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2538), null, null, 65L, null, 1L, null, null, null, "Number of non-employees in own workforce", 1L, "", 0, 710L, null },
                    { 10825L, "S1-7_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2540), null, null, 65L, null, 1L, null, null, null, "Number of non-employees in own workforce - self-employed people", 1L, "", 0, 710L, null },
                    { 10826L, "S1-7_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2543), null, null, 65L, null, 1L, null, null, null, "Number of non-employees in own workforce - people provided by undertakings primarily engaged in employment activities", 1L, "", 0, 710L, null },
                    { 10827L, "S1-7_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2545), null, null, 65L, null, 1L, null, null, null, "Undertaking does not have non-employees in own workforce", 1L, "", 0, 710L, null },
                    { 10828L, "S1-7_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2547), null, 2L, 65L, true, 1L, null, null, null, "Disclosure of the most common types of non-employees (for example, self-employed people, people provided by undertakings primarily engaged in employment activities, and other types relevant to the undertaking), their relationship with the undertaking, and the type of work that they perform.", 1L, "", 0, null, null },
                    { 10829L, "S1-7_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2550), null, 2L, 65L, true, 1L, null, null, null, "Description of methodologies and assumptions used to compile data (non-employees) ", 1L, "", 0, null, null },
                    { 10830L, "S1-7_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2556), null, 2L, 65L, null, 1L, null, null, null, "Non-employees numbers are reported in head count/full time equivalent", 1L, "", 0, null, null },
                    { 10831L, "S1-7_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2558), null, 2L, 65L, null, 1L, null, null, null, "Non-employees numbers are reported at end of reporting period/average/other methodology", 1L, "", 0, null, null },
                    { 10832L, "S1-7_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2560), null, 2L, 65L, true, 1L, null, null, null, "Disclosure of contextual information necessary to understand data (non-employee workers) ", 1L, "", 0, null, null },
                    { 10833L, "S1-7_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2564), null, 2L, 65L, true, 1L, null, null, null, "Description of basis of preparation of non-employees estimated number ", 1L, "", 0, null, null },
                    { 10834L, "S1-8_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2566), null, 2L, 66L, null, 1L, null, null, null, "Percentage of total employees covered by collective bargaining agreements", 1L, "", 0, null, null },
                    { 10835L, "S1-8_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2568), null, null, 66L, null, 1L, null, null, null, "Percentage of own employees covered by collective bargaining agreements are within coverage rate by country with significant employment (in the EEA)", 1L, "", 0, 38L, null },
                    { 10836L, "S1-8_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2570), null, null, 66L, null, 1L, null, null, null, "Percentage of own employees covered by collective bargaining agreements (outside EEA) by region", 1L, "", 0, 38L, null },
                    { 10837L, "S1-8_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2572), null, null, 66L, null, 1L, null, null, null, "Working conditions and terms of employment for employees not covered by collective bargaining agreements are determined based on collective bargaining agreements that cover other employees or based on collective bargaining agreements from other undertakings", 1L, "", 0, 38L, null },
                    { 10838L, "S1-8_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2574), null, 2L, 66L, true, 1L, null, null, null, "Description of extent to which working conditions and terms of employment of non-employees in own workforce are determined or influenced by collective bargaining agreements ", 1L, "", 0, null, null },
                    { 10839L, "S1-8_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2576), null, 2L, 66L, null, 1L, null, null, null, "Percentage of employees in country country with significant employment (in the EEA) covered by workers' representatives", 1L, "", 0, null, null },
                    { 10840L, "S1-8_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2579), null, null, 66L, true, 1L, null, null, null, "Disclosure of existence of any agreement with employees for representation by European Works Council (EWC), Societas Europaea (SE) Works Council, or Societas Cooperativa Europaea (SCE) Works Council ", 1L, "", 0, 38L, null },
                    { 10841L, "S1-8_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2582), null, 2L, 66L, null, 1L, null, null, null, "Own workforce in region (non-EEA) covered by collective bargaining and social dialogue agreements by coverage rate and by region", 1L, "", 0, null, null },
                    { 10842L, "S1-9_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2584), null, 2L, 67L, null, 1L, null, null, null, "Gender distribution in number of employees (head count) at top management level", 1L, "", 0, null, null },
                    { 10843L, "S1-9_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2586), null, null, 67L, null, 1L, null, null, null, "Gender distribution in percentage of employees at top management level", 1L, "", 0, 709L, null },
                    { 10844L, "S1-9_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2588), null, null, 67L, null, 1L, null, null, null, "Distribution of employees (head count) under 30 years old", 1L, "", 0, 38L, null },
                    { 10845L, "S1-9_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2590), null, null, 67L, null, 1L, null, null, null, "Distribution of employees (head count) between 30 and 50 years old", 1L, "", 0, 38L, null },
                    { 10846L, "S1-9_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2592), null, null, 67L, null, 1L, null, null, null, "Distribution of employees (head count) over 50 years old", 1L, "", 0, 38L, null },
                    { 10847L, "S1-9_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2595), null, null, 67L, true, 1L, null, null, null, "Disclosure of own definition of top management used ", 1L, "", 0, 38L, null },
                    { 10848L, "S1-10_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2603), null, 2L, 68L, null, 1L, null, null, null, "All employees are paid adequate wage, in line with applicable benchmarks", 1L, "", 0, null, null },
                    { 10849L, "S1-10_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2605), null, 2L, 68L, null, 1L, null, null, null, "Countries where employees earn below the applicable adequate wage benchmark [table]", 1L, "", 0, null, null },
                    { 10850L, "S1-10_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2607), null, 1L, 68L, null, 1L, null, null, null, "Percentage of  employees paid below the applicable adequate wage benchmark", 1L, "", 0, null, null },
                    { 10851L, "S1-10_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2609), null, null, 68L, null, 1L, null, null, null, "Percentage of non-employees paid below adequate wage", 1L, "", 0, 38L, null },
                    { 10852L, "S1-11_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2611), null, null, 69L, null, 1L, null, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to sickness", 1L, "", 0, 38L, null },
                    { 10853L, "S1-11_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2614), null, 2L, 69L, null, 1L, null, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to unemployment starting from when own worker is working for undertaking", 1L, "", 0, null, null },
                    { 10854L, "S1-11_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2617), null, 2L, 69L, null, 1L, null, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to employment injury and acquired disability", 1L, "", 0, null, null },
                    { 10855L, "S1-11_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2619), null, 2L, 69L, null, 1L, null, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to parental leave", 1L, "", 0, null, null },
                    { 10856L, "S1-11_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2621), null, 2L, 69L, null, 1L, null, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to retirement", 1L, "", 0, null, null },
                    { 10857L, "S1-11_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2623), null, 2L, 69L, null, 1L, null, null, null, "Social protection employees by country [table] by types of events and type of employees [including non employees]", 1L, "", 0, null, null },
                    { 10858L, "S1-11_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2625), null, 1L, 69L, true, 1L, null, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to sickness ", 1L, "", 0, null, null },
                    { 10859L, "S1-11_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2628), null, 2L, 69L, true, 1L, null, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to unemployment starting from when own worker is working for undertaking ", 1L, "", 0, null, null },
                    { 10860L, "S1-11_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2630), null, 2L, 69L, true, 1L, null, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to employment injury and acquired disability ", 1L, "", 0, null, null },
                    { 10861L, "S1-11_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2633), null, 2L, 69L, true, 1L, null, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to maternity leave ", 1L, "", 0, null, null },
                    { 10862L, "S1-11_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2635), null, 2L, 69L, true, 1L, null, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to retirement ", 1L, "", 0, null, null },
                    { 10863L, "S1-12_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2637), null, 2L, 70L, null, 1L, null, null, null, "Percentage of persons with disabilities amongst employees, subject to legal restrictions on collection of data", 1L, "", 0, null, null },
                    { 10864L, "S1-12_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2639), null, null, 70L, null, 1L, null, null, null, "Percentage of employees with disabilities in own workforce breakdown by gender [table]", 1L, "", 0, 38L, null },
                    { 10865L, "S1-12_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2646), null, null, 70L, true, 1L, null, null, null, "Disclosure of contextual information necessary to understand data and how data has been compiled (persons with disabilities)) ", 1L, "", 0, 38L, null },
                    { 10866L, "S1-13_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2648), null, 2L, 71L, null, 1L, null, null, null, "Training and skills development indicators gender [table]", 1L, "", 0, null, null },
                    { 10867L, "S1-13_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2651), null, 1L, 71L, null, 1L, null, null, null, "Percentage of employees that participated in regular performance and career development reviews", 1L, "", 0, null, null },
                    { 10868L, "S1-13_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2653), null, null, 71L, null, 1L, null, null, null, "Average number of training hours  by gender [table]", 1L, "", 0, 38L, null },
                    { 10869L, "S1-13_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2656), null, 1L, 71L, null, 1L, null, null, null, "Average number of training hours per person for employees", 1L, "", 0, null, null },
                    { 10870L, "S1-13_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2658), null, null, 71L, null, 1L, null, null, null, "Percentage of employees that participated in regular performance and career development reviews by employee category [table]", 1L, "", 0, 710L, null },
                    { 10871L, "S1-13_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2660), null, null, 71L, null, 1L, null, null, null, "Average number of employees that participated in regular performance and career development reviews by employee category", 1L, "", 0, 38L, null },
                    { 10872L, "S1-13_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2662), null, null, 71L, null, 1L, null, null, null, "Percentage of non-employees that participated in regular performance and career development reviews", 1L, "", 0, 710L, null },
                    { 10873L, "S1-14_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2664), null, null, 72L, null, 1L, null, null, null, "Percentage of people in its own workforce who are covered by health and safety management system based on legal requirements and (or) recognised standards or guidelines", 1L, "", 0, 38L, null },
                    { 10874L, "S1-14_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2666), null, null, 72L, null, 1L, null, null, null, "Number of fatalities in own workforce as result of work-related injuries and work-related ill health", 1L, "", 0, 38L, null },
                    { 10875L, "S1-14_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2669), null, null, 72L, null, 1L, null, null, null, "Number of fatalities as result of work-related injuries and work-related ill health of other workers working on undertaking's sites", 1L, "", 0, 709L, null },
                    { 10876L, "S1-14_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2671), null, null, 72L, null, 1L, null, null, null, "Number of recordable work-related accidents for own workforce", 1L, "", 0, 709L, null },
                    { 10877L, "S1-14_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2673), null, null, 72L, null, 1L, null, null, null, "Rate of recordable work-related accidents for own workforce", 1L, "", 0, 709L, null },
                    { 10878L, "S1-14_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2675), null, null, 72L, null, 1L, null, null, null, "Number of cases of recordable work-related ill health of employees", 1L, "", 0, 38L, null },
                    { 10879L, "S1-14_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2677), null, null, 72L, null, 1L, null, null, null, "Number of days lost to work-related injuries and fatalities from work-related accidents, work-related ill health and fatalities from ill health related to employees", 1L, "", 0, 709L, null },
                    { 10880L, "S1-14_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2679), null, null, 72L, null, 1L, null, null, null, "Number of cases of recordable work-related ill health of non-employees", 1L, "", 0, 709L, null },
                    { 10881L, "S1-14_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2681), null, null, 72L, null, 1L, null, null, null, "Number of days lost to work-related injuries and fatalities from work-related accidents, work-related ill health and fatalities from ill health realted to non-employees", 1L, "", 0, 709L, null },
                    { 10882L, "S1-14_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2684), null, null, 72L, null, 1L, null, null, null, "Percentage of own workforce who are covered by health and safety management system based on legal requirements and (or) recognised standards or guidelines and which has been internally audited and (or) audited or certified by external party", 1L, "", 0, 709L, null },
                    { 10883L, "S1-14_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2693), null, null, 72L, true, 1L, null, null, null, "Description of underlying standards for internal audit or external certification of health and safety management system ", 1L, "", 0, 38L, null },
                    { 10884L, "S1-14_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2695), null, 2L, 72L, null, 1L, null, null, null, "Number of cases of recordable work-related ill health detected among former own workforce", 1L, "", 0, null, null },
                    { 10885L, "S1-15_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2697), null, null, 73L, null, 1L, null, null, null, "Percentage of employees entitled to take family-related leave", 1L, "", 0, 709L, null },
                    { 10886L, "S1-15_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2699), null, null, 73L, null, 1L, null, null, null, "Percentage of entitled employees that took family-related leave", 1L, "", 0, 38L, null },
                    { 10887L, "S1-15_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2701), null, null, 73L, null, 1L, null, null, null, "Percentage of entitled employees that took family-related leave by gender [table]", 1L, "", 0, 38L, null },
                    { 10888L, "S1-15_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2703), null, null, 73L, null, 1L, null, null, null, "All employees are entitled to family-related leaves through social policy and (or) collective bargaining agreements", 1L, "", 0, 38L, null },
                    { 10889L, "S1-16_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2706), null, 2L, 74L, null, 1L, null, null, null, "Gender pay gap", 1L, "", 0, null, null },
                    { 10890L, "S1-16_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2708), null, null, 74L, null, 1L, null, null, null, "Annual total remuneration ratio", 1L, "", 0, 38L, null },
                    { 10891L, "S1-16_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2710), null, null, 74L, true, 1L, null, null, null, "Disclosure of contextual information necessary to understand data, how data has been compiled and other changes to underlying data that are to be considered ", 1L, "", 0, 38L, null },
                    { 10892L, "S1-16_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2712), null, 2L, 74L, null, 1L, null, null, null, "Gender pay gap breakdown by employee category and/or country/segment [table]", 1L, "", 0, null, null },
                    { 10893L, "S1-16_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2715), null, null, 74L, null, 1L, null, null, null, "Gender pay gap breakdown by employee category and ordinary basic salary and complementary/variable components", 1L, "", 0, 38L, null },
                    { 10894L, "S1-16_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2717), null, null, 74L, null, 1L, null, null, null, "Remuneration ratio adjusted for purchasing power differences between countries", 1L, "", 0, 38L, null },
                    { 10895L, "S1-16_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2719), null, null, 74L, true, 1L, null, null, null, "Description of methodology used for calculation of remuneration ratio adjusted for purchasing power differences between countries ", 1L, "", 0, 38L, null },
                    { 10896L, "S1-17_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2722), null, 2L, 75L, null, 1L, null, null, null, "Number of incidents of discrimination [table]", 1L, "", 0, null, null },
                    { 10897L, "S1-17_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2724), null, 1L, 75L, null, 1L, null, null, null, "Number of incidents of discrimination", 1L, "", 0, null, null },
                    { 10898L, "S1-17_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2726), null, null, 75L, null, 1L, null, null, null, "Number of complaints filed through channels for people in own workforce to raise concerns", 1L, "", 0, 709L, null },
                    { 10899L, "S1-17_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2728), null, null, 75L, null, 1L, null, null, null, "Number of complaints filed to National Contact Points for OECD Multinational Enterprises", 1L, "", 0, 709L, null },
                    { 10900L, "S1-17_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2730), null, null, 75L, null, 1L, null, null, null, "Amount of fines, penalties, and compensation for damages as result of incidents of discrimination, including harassment and complaints filed", 1L, "", 0, 709L, null },
                    { 10901L, "S1-17_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2739), null, 3L, 75L, true, 1L, null, null, null, "Information about reconciliation of fines, penalties, and compensation for damages as result of violations regarding swork-related discrimination and harassment  with most relevant amount presented in financial statements ", 1L, "", 0, null, null },
                    { 10902L, "S1-17_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2741), null, 2L, 75L, true, 1L, null, null, null, "Disclosure of contextual information necessary to understand data and how data has been compiled (work-related grievances, incidents and complaints related to social and human rights matters) ", 1L, "", 0, null, null },
                    { 10903L, "S1-17_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2744), null, 2L, 75L, null, 1L, null, null, null, "Number of severe human rights issues and incidents connected to own workforce", 1L, "", 0, null, null },
                    { 10904L, "S1-17_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2746), null, null, 75L, null, 1L, null, null, null, "Number of severe human rights issues and incidents connected to own workforce that are cases of non respect of UN Guiding Principles and OECD Guidelines for Multinational Enterprises", 1L, "", 0, 709L, null },
                    { 10905L, "S1-17_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2748), null, null, 75L, null, 1L, null, null, null, "No severe human rights issues and incidents connected to own workforce have occurred", 1L, "", 0, 709L, null },
                    { 10906L, "S1-17_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2750), null, 2L, 75L, null, 1L, null, null, null, "Amount of fines, penalties, and compensation for severe human rights issues and incidents connected to own workforce", 1L, "", 0, null, null },
                    { 10907L, "S1-17_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2752), null, 3L, 75L, true, 1L, null, null, null, "Information about reconciliation of amount of fines, penalties, and compensation for severe human rights issues and incidents connected to own workforce with most relevant amount presented in financial statements ", 1L, "", 0, null, null },
                    { 10908L, "S1-17_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2754), null, 2L, 75L, true, 1L, null, null, null, "Disclosure of the status of incidents and/or complaints and actions taken", 1L, "", 0, null, null },
                    { 10909L, "S1-17_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2756), null, 2L, 75L, null, 1L, null, null, null, "Number of severe human rights cases where undertaking played role securing remedy for those affected", 1L, "", 0, null, null },
                    { 10910L, "S2.SBM-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2759), null, null, 77L, null, 1L, null, null, null, "All value chain workers  who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 0, 709L, null },
                    { 10911L, "S2.SBM-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2761), null, 2L, 77L, true, 1L, null, null, null, "Description of types of value chain workers subject to material impacts", 1L, "", 0, null, null },
                    { 10912L, "S2.SBM-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2763), null, 2L, 77L, null, 1L, null, null, null, "Type of value chain workers subject to material impacts by own operations or through value chain", 1L, "", 0, null, null },
                    { 10913L, "S2.SBM-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2765), null, 2L, 77L, true, 1L, null, null, null, "Disclosure of geographies or commodities for which there is significant risk of child labour, or of forced or compulsory labour, among workers in undertaking’s value chain ", 1L, "", 0, null, null },
                    { 10914L, "S2.SBM-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2768), null, 2L, 77L, null, 1L, null, null, null, "Material negative impacts occurrence (value chain workers)", 1L, "", 0, null, null },
                    { 10915L, "S2.SBM-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2770), null, 2L, 77L, true, 1L, null, null, null, "Description of activities that result in positive impacts and types of value chain workers  that are positively affected or could be positively affected ", 1L, "", 0, null, null },
                    { 10916L, "S2.SBM-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2772), null, 2L, 77L, true, 1L, null, null, null, "Description of material risks and opportunities arising from impacts and dependencies on  value chain workers  ", 1L, "", 0, null, null },
                    { 10917L, "S2.SBM-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2775), null, 2L, 77L, true, 1L, null, null, null, "Disclosure of whether and how the undertaking has developed an understanding of how workers with particular characteristics, those working in particular contexts, or those undertaking particular activities may be at greater risk of harm.", 1L, "", 0, null, null },
                    { 10918L, "S2.SBM-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2782), null, 2L, 77L, true, 1L, null, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on value chain workers  are impacts on specific groups ", 1L, "", 0, null, null },
                    { 10919L, "S2.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2785), null, 2L, 78L, null, 1L, null, null, null, "Policies to manage material impacts, risks and opportunities related to value chain workers [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 10920L, "S2-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2787), null, 2L, 78L, true, 1L, null, null, null, "Description of relevant human rights policy commitments relevant to value chain workers", 1L, "", 0, null, null },
                    { 10921L, "S2-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2789), null, 2L, 78L, true, 1L, null, null, null, "Disclosure of general approach in relation to respect for human rights relevant to value chain workers", 1L, "", 0, null, null },
                    { 10922L, "S2-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2791), null, 2L, 78L, true, 1L, null, null, null, "Disclosure of general approach in relation to engagement with value chain workers", 1L, "", 0, null, null },
                    { 10923L, "S2-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2794), null, 2L, 78L, true, 1L, null, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 0, null, null },
                    { 10924L, "S2-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2796), null, 2L, 78L, null, 1L, null, null, null, "Policies explicitly address trafficking in human beings, forced labour or compulsory labour and child labour", 1L, "", 0, null, null },
                    { 10925L, "S2-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2799), null, 2L, 78L, null, 1L, null, null, null, "Undertaking has supplier code of conduct", 1L, "", 0, null, null },
                    { 10926L, "S2-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2801), null, 2L, 78L, null, 1L, null, null, null, "Provisions in supplier codes of conudct are fully in line with applicable ILO standards", 1L, "", 0, null, null },
                    { 10927L, "S2-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2803), null, 2L, 78L, true, 1L, null, null, null, "Disclosure of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 0, null, null },
                    { 10928L, "S2-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2805), null, 2L, 78L, true, 1L, null, null, null, "Disclosure of extent and indication of nature of cases of non-respect of the UN Guiding Principles on Business and Human Rights, ILO Declaration on Fundamental Principles and Rights at Work or OECD Guidelines for Multinational Enterprises that involve value chain workers", 1L, "", 0, null, null },
                    { 10929L, "S2-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2807), null, 2L, 78L, true, 1L, null, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 0, null, null },
                    { 10930L, "S2-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2810), null, 2L, 78L, true, 1L, null, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 0, null, null },
                    { 10932L, "S2-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2815), null, null, 79L, true, 1L, null, null, null, "Disclosure of whether and how perspectives of value chain workers inform decisions or activities aimed at managing actual and potential  impacts ", 1L, "", 0, null, null },
                    { 10933L, "S2-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2817), null, 2L, 79L, null, 1L, null, null, null, "Engagement occurs with value chain workers or their legitimate representatives directly, or with credible proxies", 1L, "", 0, null, null },
                    { 10934L, "S2-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2819), null, 2L, 79L, true, 1L, null, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 0, null, null },
                    { 10935L, "S2-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2821), null, 2L, 79L, true, 1L, null, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakings approach ", 1L, "", 0, null, null },
                    { 10936L, "S2-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2828), null, 2L, 79L, true, 1L, null, null, null, "Disclosure of Global Framework Agreement or other agreements related to respect of human rights of workers ", 1L, "", 0, null, null },
                    { 10937L, "S2-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2830), null, 2L, 79L, true, 1L, null, null, null, "Disclosure of how effectiveness of engagement with value chain workers is assessed ", 1L, "", 0, null, null },
                    { 10938L, "S2-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2833), null, 2L, 79L, true, 1L, null, null, null, "Disclosure of steps taken to gain insight into perspectives of value chain workers that may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 0, null, null },
                    { 10939L, "S2-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2835), null, 2L, 79L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a general process to engage with value chain workers", 1L, "", 0, null, null },
                    { 10940L, "S2-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2837), null, 2L, 79L, true, 1L, null, null, null, "Disclosure of timeframe for adoption of general process to engage with  value chain workers  in case the undertaking has not adopted a general process for engagement", 1L, "", 0, null, null },
                    { 10941L, "S2-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2839), null, 2L, 80L, true, 1L, null, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has identified that it connected with a material negative impact on  value chain workers  ", 1L, "", 0, null, null },
                    { 10942L, "S2-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2841), null, 2L, 80L, true, 1L, null, null, null, "Disclosure of specific channels in place for value chain workers to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 0, null, null },
                    { 10943L, "S2-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2844), null, 2L, 80L, true, 1L, null, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 0, null, null },
                    { 10944L, "S2-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2846), null, 2L, 80L, true, 1L, null, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 0, null, null },
                    { 10945L, "S2-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2849), null, 2L, 80L, true, 1L, null, null, null, "Disclosure of whether and how it is assessed that value chain workers are aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 0, null, null },
                    { 10946L, "S2-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2851), null, 2L, 80L, null, 1L, null, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 0, null, null },
                    { 10947L, "S2-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2853), null, 2L, 80L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a channel for raising concerns ", 1L, "", 0, null, null },
                    { 10948L, "S2-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2856), null, 2L, 80L, true, 1L, null, null, null, "Disclosure of timeframe for channel for raising concerns to be in place", 1L, "", 0, null, null },
                    { 10949L, "S2-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2858), null, 2L, 80L, true, 1L, null, null, null, "Disclosure of whether and how value chain workers are able to access channels at level of undertaking they are employed by or contracted to work for ", 1L, "", 0, null, null },
                    { 10950L, "S2-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2860), null, 2L, 80L, null, 1L, null, null, null, "Third-party mechanisms are accessible to all workers", 1L, "", 0, null, null },
                    { 10951L, "S2-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2862), null, 2L, 80L, null, 1L, null, null, null, "Grievances are treated confidentially and with respect to rights of privacy and data protection", 1L, "", 0, null, null },
                    { 10952L, "S2-3_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2865), null, 2L, 80L, null, 1L, null, null, null, "Channels to raise concerns or needs allow for value chain workers to use them anonymously ", 1L, "", 0, null, null },
                    { 10953L, "S2.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2867), null, 2L, 81L, null, 1L, null, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to value chain workers [see ESRS 2 - MDR-A]", 1L, "", 0, null, null },
                    { 10954L, "S2-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2873), null, 2L, 81L, true, 1L, null, null, null, "Description of action planned or underway to prevent, mitigate or remediate material negative impacts on  value chain workers  ", 1L, "", 0, null, null },
                    { 10955L, "S2-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2875), null, 2L, 81L, true, 1L, null, null, null, "Description of whether and how action to provide or enable remedy in relation to an actual material impact", 1L, "", 0, null, null },
                    { 10956L, "S2-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2877), null, 2L, 81L, true, 1L, null, null, null, "Description of additional initiatives or processes with primary purpose of delivering positive impacts for value chain workers ", 1L, "", 0, null, null },
                    { 10957L, "S2-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2879), null, 2L, 81L, true, 1L, null, null, null, "Description of how effectiveness of actions or initiatives in delivering outcomes for value chain workersis tracked and assessed ", 1L, "", 0, null, null },
                    { 10958L, "S2-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2883), null, 2L, 81L, true, 1L, null, null, null, "Description of processes to identifying what action is needed and appropriate in response to particular actual or potential material negative impact on  value chain workers  ", 1L, "", 0, null, null },
                    { 10959L, "S2-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2885), null, 2L, 81L, true, 1L, null, null, null, "Description of approach to taking action in relation to specific material negative impacts on value chain workers  ", 1L, "", 0, null, null },
                    { 10960L, "S2-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2887), null, 2L, 81L, true, 1L, null, null, null, "Description of approach to ensuring that processes to provide or enable remedy in event of material negative impacts on  value chain workers  are available and effective in their implementation and outcomes ", 1L, "", 0, null, null },
                    { 10961L, "S2-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2889), null, 2L, 81L, true, 1L, null, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on  value chain workers  and how effectiveness is tracked ", 1L, "", 0, null, null },
                    { 10962L, "S2-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2891), null, 2L, 81L, true, 1L, null, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to  value chain workers  ", 1L, "", 0, null, null },
                    { 10963L, "S2-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2894), null, 2L, 81L, true, 1L, null, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on value chain workers  ", 1L, "", 0, null, null },
                    { 10964L, "S2-4_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2896), null, 2L, 81L, true, 1L, null, null, null, "Disclosure of severe human rights issues and incidents connected to upstream and downstream value chain ", 1L, "", 0, null, null },
                    { 10965L, "S2-4_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2899), null, 2L, 81L, true, 1L, null, null, null, "Disclosure of resources allocated to management of material impacts ", 1L, "", 0, null, null },
                    { 10966L, "S2-4_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2901), null, 2L, 81L, true, 1L, null, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting value chain workers  ", 1L, "", 0, null, null },
                    { 10967L, "S2-4_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2903), null, 2L, 81L, true, 1L, null, null, null, "Disclosure of how participation in industry or multi-stakeholder initiative and undertaking's own involvement is aiming to address material impacts ", 1L, "", 0, null, null },
                    { 10968L, "S2-4_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2906), null, 2L, 81L, true, 1L, null, null, null, "Disclosure of whether and how value chain workers and legitimate representatives or their credible proxies play role in decisions regarding design and implementation of programmes or processes ", 1L, "", 0, null, null },
                    { 10969L, "S2-4_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2908), null, 2L, 81L, true, 1L, null, null, null, "Information about intended or achieved positive outcomes of programmes or processes for  value chain workers  ", 1L, "", 0, null, null },
                    { 10970L, "S2-4_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2910), null, 2L, 81L, null, 1L, null, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for  value chain workers  are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 0, null, null },
                    { 10971L, "S2-4_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2916), null, 2L, 81L, true, 1L, null, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 0, null, null },
                    { 10973L, "S2.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2921), null, null, 82L, null, 1L, null, null, null, "Targets set to manage material impacts, risks and opportunities related to value chain workers [see ESRS 2 - MDR-T]", 1L, "", 0, null, null },
                    { 10974L, "S2-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2923), null, 2L, 82L, true, 1L, null, null, null, "Disclosure of whether and how value chain workers , their legitimate representatives or credible proxies were engaged directly in setting targets ", 1L, "", 0, null, null },
                    { 10975L, "S2-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2925), null, 2L, 82L, true, 1L, null, null, null, "Disclosure of whether and how value chain workers , their legitimate representatives or credible proxies were engaged directly in tracking performance against targets ", 1L, "", 0, null, null },
                    { 10976L, "S2-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2927), null, 2L, 82L, true, 1L, null, null, null, "Disclosure of whether and how value chain workers , their legitimate representatives or credible proxies were engaged directly in identifying lessons or improvements as result of undertaking’s performance ", 1L, "", 0, null, null },
                    { 10977L, "S2-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2930), null, 2L, 82L, true, 1L, null, null, null, "Disclosure of intended outcomes to be achieved in lives of  value chain workers  ", 1L, "", 0, null, null },
                    { 10978L, "S2-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2932), null, 2L, 82L, true, 1L, null, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 0, null, null },
                    { 10979L, "S2-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2935), null, 2L, 82L, true, 1L, null, null, null, "Disclosure of references to standards or commitments on which target is based ", 1L, "", 0, null, null },
                    { 10981L, "S3.SBM-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2939), null, null, 84L, null, 1L, null, null, null, "All  affected communities who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 0, null, null },
                    { 10982L, "S3.SBM-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2941), null, 2L, 84L, true, 1L, null, null, null, "Description of types of affected communities subject to material impacts", 1L, "", 0, null, null },
                    { 10983L, "S3.SBM-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2943), null, 2L, 84L, null, 1L, null, null, null, "Type of communities subject to material impacts by own operations or through value chain", 1L, "", 0, null, null },
                    { 10984L, "S3.SBM-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2945), null, 2L, 84L, null, 1L, null, null, null, "Material negative impacts occurrence (affected communities)", 1L, "", 0, null, null },
                    { 10985L, "S3.SBM-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2947), null, 2L, 84L, true, 1L, null, null, null, "Description of activities that result in positive impacts and types of affected communities that are positively affected or could be positively affected ", 1L, "", 0, null, null },
                    { 10986L, "S3.SBM-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2950), null, 2L, 84L, true, 1L, null, null, null, "Description of material risks and opportunities arising from impacts and dependencies on  affected communities   ", 1L, "", 0, null, null },
                    { 10987L, "S3.SBM-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2952), null, 2L, 84L, true, 1L, null, null, null, "Disclosure of whether and how the undertaking has developed an understanding of how affected communities with particular characteristics or those living in particular contexts, or those undertaking particular activities may be at greater risk of harm", 1L, "", 0, null, null },
                    { 10988L, "S3.SBM-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2954), null, 2L, 84L, true, 1L, null, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on affected communities are impacts on specific groups ", 1L, "", 0, null, null },
                    { 10989L, "S3.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2960), null, 2L, 85L, null, 1L, null, null, null, "Policies to manage material impacts, risks and opportunities related to affected communities [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 10990L, "S3-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2962), null, 2L, 85L, true, 1L, null, null, null, "Disclosure of any  any particular policy provisions for preventing and addressing impacts on indigenous peoples", 1L, "", 0, null, null },
                    { 10991L, "S3-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2964), null, 2L, 85L, true, 1L, null, null, null, "Description of relevant human rights policy commitments relevant to affected communities", 1L, "", 0, null, null },
                    { 10992L, "S3-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2967), null, 2L, 85L, true, 1L, null, null, null, "Disclosure of general approach in relation to respect for human rights of communities, and indigenous peoples specifically", 1L, "", 0, null, null },
                    { 10993L, "S3-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2969), null, 2L, 85L, true, 1L, null, null, null, "Disclosure of general approach in relation to engagement with affected communities", 1L, "", 0, null, null },
                    { 10994L, "S3-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2972), null, 2L, 85L, true, 1L, null, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 0, null, null },
                    { 10995L, "S3-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2974), null, 2L, 85L, true, 1L, null, null, null, "Disclosure of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 0, null, null },
                    { 10996L, "S3-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2976), null, 2L, 85L, true, 1L, null, null, null, "Disclosure of extent and indication of nature of cases of non-respect of the UN Guiding Principles on Business and Human Rights, ILO Declaration on Fundamental Principles and Rights at Work or OECD Guidelines for Multinational Enterprises that involve affected communities", 1L, "", 0, null, null },
                    { 10997L, "S3-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2978), null, 2L, 85L, true, 1L, null, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 0, null, null },
                    { 10998L, "S3-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2980), null, 2L, 85L, true, 1L, null, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 0, null, null },
                    { 11000L, "S3-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2986), null, null, 86L, true, 1L, null, null, null, "Disclosure of whether and how perspectives of affected communities inform decisions or activities aimed at managing actual and potential impacts ", 1L, "", 0, null, null },
                    { 11001L, "S3-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2988), null, 2L, 86L, null, 1L, null, null, null, "Engagement occurs with affected communities or their legitimate representatives directly, or with credible proxies", 1L, "", 0, null, null },
                    { 11002L, "S3-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2990), null, 2L, 86L, true, 1L, null, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 0, null, null },
                    { 11003L, "S3-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2992), null, 2L, 86L, true, 1L, null, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakings approach ", 1L, "", 0, null, null },
                    { 11004L, "S3-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2995), null, 2L, 86L, true, 1L, null, null, null, "Disclosure of how the undertaking assesses the effectiveness of its engagement with affected communities", 1L, "", 0, null, null },
                    { 11005L, "S3-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(2997), null, 2L, 86L, true, 1L, null, null, null, "Disclosure of steps taken to gain insight into perspectives of  affected communities hat may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 0, null, null },
                    { 11006L, "S3-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3000), null, 2L, 86L, true, 1L, null, null, null, "Disclosure of whether and how the undertaking takes into account and ensures respect of particular rights of indigenous peoples in its stakeholder engagement approach", 1L, "", 0, null, null },
                    { 11007L, "S3-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3006), null, 2L, 86L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a general process to engage with affected communities", 1L, "", 0, null, null },
                    { 11008L, "S3-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3008), null, 2L, 86L, true, 1L, null, null, null, "Disclosure of timeframe for adoption of general process to engage with affected communities in case the undertaking has not adopted a general process for engagement", 1L, "", 0, null, null },
                    { 11009L, "S3-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3010), null, 2L, 87L, true, 1L, null, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has identified that it connected with a material negative impact on affected communities   ", 1L, "", 0, null, null },
                    { 11010L, "S3-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3012), null, 2L, 87L, true, 1L, null, null, null, "Disclosure of specific channels in place for affected communities to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 0, null, null },
                    { 11011L, "S3-3_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3014), null, 2L, 87L, true, 1L, null, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 0, null, null },
                    { 11012L, "S3-3_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3016), null, 2L, 87L, true, 1L, null, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 0, null, null },
                    { 11013L, "S3-3_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3019), null, 2L, 87L, true, 1L, null, null, null, "Disclosure of whether and how it is assessed that affected communities are aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 0, null, null },
                    { 11014L, "S3-3_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3022), null, 2L, 87L, null, 1L, null, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 0, null, null },
                    { 11015L, "S3-3_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3024), null, 2L, 87L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a general process to engage with affected communities", 1L, "", 0, null, null },
                    { 11016L, "S3-3_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3026), null, 2L, 87L, true, 1L, null, null, null, "Disclosure of timeframe for channel or processes for raising concerns to be in place ", 1L, "", 0, null, null },
                    { 11017L, "S3-3_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3028), null, 2L, 87L, true, 1L, null, null, null, "Disclosure of whether and how affected communities are able to access channels at level of undertaking they are affected by", 1L, "", 0, null, null },
                    { 11018L, "S3-3_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3030), null, 2L, 87L, null, 1L, null, null, null, "Third-party mechanisms are accessible to all affected communities", 1L, "", 0, null, null },
                    { 11019L, "S3-3_20", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3032), null, 2L, 87L, null, 1L, null, null, null, "Grievances are treated confidentially and with respect to rights of privacy and data protection", 1L, "", 0, null, null },
                    { 11020L, "S3-3_21", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3035), null, 2L, 87L, null, 1L, null, null, null, "affected communities   are allowed to use anonymously channels to raise concerns or needs", 1L, "", 0, null, null },
                    { 11021L, "S3.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3037), null, 2L, 88L, null, 1L, null, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to affected communities [see ESRS 2 - MDR-A]", 1L, "", 0, null, null },
                    { 11022L, "S3-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3040), null, 2L, 88L, true, 1L, null, null, null, "Description of action taken, planned or underway to prevent, mitigate or remediate material negative impacts on affected communities   ", 1L, "", 0, null, null },
                    { 11023L, "S3-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3042), null, 2L, 88L, true, 1L, null, null, null, "Description of whether and how the undertaking has taken action to provide or enable remedy in relation to an actual material impact", 1L, "", 0, null, null },
                    { 11024L, "S3-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3048), null, 2L, 88L, true, 1L, null, null, null, "Description of additional initiatives or processes with primary purpose of delivering positive impacts for affected communities  ", 1L, "", 0, null, null },
                    { 11025L, "S3-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3050), null, 2L, 88L, true, 1L, null, null, null, "Description of how effectiveness of actions or initiatives in delivering outcomes for affected communities is tracked and assessed ", 1L, "", 0, null, null },
                    { 11026L, "S3-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3052), null, 2L, 88L, true, 1L, null, null, null, "Description of processes to identifying what action is needed and appropriate in response to particular actual or potential material negative impact on affected communities   ", 1L, "", 0, null, null },
                    { 11027L, "S3-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3055), null, 2L, 88L, true, 1L, null, null, null, "Description of approach to taking action in relation to specific material negative impacts on affected communities   ", 1L, "", 0, null, null },
                    { 11028L, "S3-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3057), null, 2L, 88L, true, 1L, null, null, null, "Description of approach to ensuring that processes to provide or enable remedy in event of material negative impacts on affected communities are available and effective in their implementation and outcomes ", 1L, "", 0, null, null },
                    { 11029L, "S3-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3059), null, 2L, 88L, true, 1L, null, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on affected communities and how effectiveness is tracked ", 1L, "", 0, null, null },
                    { 11030L, "S3-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3061), null, 2L, 88L, true, 1L, null, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to affected communities   ", 1L, "", 0, null, null },
                    { 11031L, "S3-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3064), null, 2L, 88L, true, 1L, null, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on affected communities   ", 1L, "", 0, null, null },
                    { 11032L, "S3-4_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3066), null, 2L, 88L, true, 1L, null, null, null, "Disclosure of severe human rights issues and incidents connected to affected communities ", 1L, "", 0, null, null },
                    { 11033L, "S3-4_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3068), null, 2L, 88L, true, 1L, null, null, null, "Disclosure of resources allocated to management of material impacts ", 1L, "", 0, null, null },
                    { 11034L, "S3-4_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3071), null, 2L, 88L, true, 1L, null, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting  affected communities   ", 1L, "", 0, null, null },
                    { 11035L, "S3-4_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3073), null, 2L, 88L, true, 1L, null, null, null, "Disclosure of how participation in industry or multi-stakeholder initiative and undertaking's own involvement is aiming to address material impacts ", 1L, "", 0, null, null },
                    { 11036L, "S3-4_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3075), null, 2L, 88L, true, 1L, null, null, null, "Disclosure of whether and how affected communities  play role in decisions regarding design and implementation of programmes or investments ", 1L, "", 0, null, null },
                    { 11037L, "S3-4_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3078), null, 2L, 88L, true, 1L, null, null, null, "Information about intended or achieved positive outcomes of programmes or investments for  affected communities   ", 1L, "", 0, null, null },
                    { 11038L, "S3-4_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3080), null, 2L, 88L, true, 1L, null, null, null, "Explanation of the approximate scope of affected communities covered by the described social investment or development programmes, and, where applicable, the rationale for why selected communities were chosen", 1L, "", 0, null, null },
                    { 11039L, "S3-4_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3082), null, 2L, 88L, null, 1L, null, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for affected communities are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 0, null, null },
                    { 11040L, "S3-4_19", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3084), null, 2L, 88L, true, 1L, null, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 0, null, null },
                    { 11042L, "S3.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3094), null, null, 89L, null, 1L, null, null, null, "Targets set to manage material impacts, risks and opportunities related to affected communities [see ESRS 2 - MDR-T]", 1L, "", 0, null, null },
                    { 11043L, "S3-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3096), null, 2L, 89L, true, 1L, null, null, null, "Disclosure of whether and how affected communities were engaged directly in setting targets", 1L, "", 0, null, null },
                    { 11044L, "S3-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3098), null, 2L, 89L, true, 1L, null, null, null, "Disclosure of whether and how affected communities  were engaged directly in tracking performance against targets", 1L, "", 0, null, null },
                    { 11045L, "S3-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3101), null, 2L, 89L, true, 1L, null, null, null, "Disclosure of whether and how affected communities  were engaged directly in identifying lessons or improvements as result of undertaking’s performance", 1L, "", 0, null, null },
                    { 11046L, "S3-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3103), null, 2L, 89L, true, 1L, null, null, null, "Disclosure of intended outcomes to be achieved in lives of  affected communities   ", 1L, "", 0, null, null },
                    { 11047L, "S3-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3105), null, 2L, 89L, true, 1L, null, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 0, null, null },
                    { 11048L, "S3-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3108), null, 2L, 89L, true, 1L, null, null, null, "Disclosure of references to standards or commitments on which target is based ", 1L, "", 0, null, null },
                    { 11050L, "S4.SBM-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3112), null, null, 91L, null, 1L, null, null, null, "All  consumers and end-users who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 0, null, null },
                    { 11051L, "S4.SBM-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3114), null, 2L, 91L, true, 1L, null, null, null, "Description of types of consumers and end-users subject to material impacts", 1L, "", 0, null, null },
                    { 11052L, "S4.SBM-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3116), null, 2L, 91L, null, 1L, null, null, null, "Type of consumers and end-users subject to material impacts by own operations or through value chain", 1L, "", 0, null, null },
                    { 11053L, "S4.SBM-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3118), null, 2L, 91L, null, 1L, null, null, null, "Material negative impacts occurrence (consumers and end-users)", 1L, "", 0, null, null },
                    { 11054L, "S4.SBM-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3120), null, 2L, 91L, true, 1L, null, null, null, "Description of activities that result in positive impacts and types of  consumers and end-users that are positively affected or could be positively affected ", 1L, "", 0, null, null },
                    { 11055L, "S4.SBM-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3123), null, 2L, 91L, true, 1L, null, null, null, "Description of material risks and opportunities arising from impacts and dependencies on  consumers and end-users   ", 1L, "", 0, null, null },
                    { 11056L, "S4.SBM-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3126), null, 2L, 91L, true, 1L, null, null, null, "Disclosure of whether and how understanding of how consumers and end-users with particular characteristics, working in particular contexts, or undertaking particular activities may be at greater risk of harm has been developed", 1L, "", 0, null, null },
                    { 11057L, "S4.SBM-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3128), null, 2L, 91L, true, 1L, null, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on consumers and end-users are impacts on specific groups ", 1L, "", 0, null, null },
                    { 11058L, "S4.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3130), null, 2L, 92L, null, 1L, null, null, null, "Policies to manage material impacts, risks and opportunities related to consumers and end-users [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 11059L, "S4-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3132), null, 2L, 92L, true, 1L, null, null, null, "Policies to manage material impacts, risks and opportunities related to affected consumers and end-users, including specific groups or all consumers / end-users", 1L, "", 0, null, null },
                    { 11060L, "S4-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3139), null, 2L, 92L, true, 1L, null, null, null, "Description of relevant human rights policy commitments relevant to consumers and/or end-users", 1L, "", 0, null, null },
                    { 11061L, "S4-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3142), null, 2L, 92L, true, 1L, null, null, null, "Disclosure of general approach in relation to respect for human rights of consumers and end-users", 1L, "", 0, null, null },
                    { 11062L, "S4-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3144), null, 2L, 92L, true, 1L, null, null, null, "Disclosure of general approach in relation to engagement with consumers and/or end-users", 1L, "", 0, null, null },
                    { 11063L, "S4-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3146), null, 2L, 92L, true, 1L, null, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 0, null, null },
                    { 11064L, "S4-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3149), null, 2L, 92L, true, 1L, null, null, null, "Description of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 0, null, null },
                    { 11065L, "S4-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3151), null, 2L, 92L, true, 1L, null, null, null, "Disclosure of extent and indication of nature of cases of non-respect of the UN Guiding Principles on Business and Human Rights, ILO Declaration on Fundamental Principles and Rights at Work or OECD Guidelines for Multinational Enterprises that involve consumers and/or end-users", 1L, "", 0, null, null },
                    { 11066L, "S4-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3153), null, 2L, 92L, true, 1L, null, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 0, null, null },
                    { 11067L, "S4-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3155), null, 2L, 92L, true, 1L, null, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 0, null, null },
                    { 11069L, "S4-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3160), null, null, 93L, true, 1L, null, null, null, "Disclosure of whether and how perspectives of consumers and end-users inform decisions or activities aimed at managing actual and potential impacts ", 1L, "", 0, null, null },
                    { 11070L, "S4-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3162), null, 2L, 93L, null, 1L, null, null, null, "Engagement occurs with consumers and end-users  or their legitimate representatives directly, or with credible proxies", 1L, "", 0, null, null },
                    { 11071L, "S4-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3164), null, 2L, 93L, true, 1L, null, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 0, null, null },
                    { 11072L, "S4-2_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3166), null, 2L, 93L, true, 1L, null, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakings approach ", 1L, "", 0, null, null },
                    { 11073L, "S4-2_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3169), null, 2L, 93L, true, 1L, null, null, null, "Disclosure of how effectiveness of engagement with  consumers and end-users   is assessed ", 1L, "", 0, null, null },
                    { 11074L, "S4-2_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3171), null, 2L, 93L, true, 1L, null, null, null, "Disclosure of steps taken to gain insight into perspectives of  consumers and end-users  / consumers and end-users that may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 0, null, null },
                    { 11075L, "S4-2_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3174), null, 2L, 93L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a general process to engage with consumers and/or end-users", 1L, "", 0, null, null },
                    { 11076L, "S4-2_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3176), null, 2L, 93L, true, 1L, null, null, null, "Disclosure of timeframe for adoption of general process to engage with  consumers and end-users   in case the undertaking has not adopted a general process for engageme", 1L, "", 0, null, null },
                    { 11077L, "S4-2_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3183), null, 2L, 93L, null, 1L, null, null, null, "Type of role or function handling with engagement", 1L, "", 0, null, null },
                    { 11078L, "S4-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3185), null, 2L, 94L, true, 1L, null, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has identified that it connected with a material negative impact on consumers and end-users   ", 1L, "", 0, null, null },
                    { 11079L, "S4-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3187), null, 2L, 94L, true, 1L, null, null, null, "Disclosure of specific channels in place for consumers and end-users to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 0, null, null },
                    { 11080L, "S4-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3189), null, 2L, 94L, true, 1L, null, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 0, null, null },
                    { 11081L, "S4-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3192), null, 2L, 94L, true, 1L, null, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 0, null, null },
                    { 11082L, "S4-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3195), null, 2L, 94L, true, 1L, null, null, null, "Disclosure of whether and how it is assessed that consumers and end-users are aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 0, null, null },
                    { 11083L, "S4-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3197), null, 2L, 94L, null, 1L, null, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 0, null, null },
                    { 11084L, "S4-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3199), null, 2L, 94L, true, 1L, null, null, null, "Statement in case the undertaking has not adopted a general process to engage with consumers and/or end-users", 1L, "", 0, null, null },
                    { 11085L, "S4-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3201), null, 2L, 94L, true, 1L, null, null, null, "Disclosure of timeframe for channel or processes for raising concerns to be in place ", 1L, "", 0, null, null },
                    { 11086L, "S4-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3203), null, 2L, 94L, true, 1L, null, null, null, "Disclosure of whether and how consumers and/or end-users are able to access channels at level of undertaking they are affected by", 1L, "", 0, null, null },
                    { 11087L, "S4-3_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3206), null, 2L, 94L, true, 1L, null, null, null, "Third-party mechanisms are accessible to all consumers and/or end-users", 1L, "", 0, null, null },
                    { 11088L, "S4-3_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3208), null, 2L, 94L, null, 1L, null, null, null, "Grievances are treated confidentially and with respect to rights of privacy and data protection", 1L, "", 0, null, null },
                    { 11089L, "S4-3_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3212), null, 2L, 94L, null, 1L, null, null, null, "consumers and end-users   are allowed to use anonymously channels to raise concerns or needs", 1L, "", 0, null, null },
                    { 11090L, "S4-3_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3214), null, 2L, 94L, null, 1L, null, null, null, "Number of complaints received from consumers and/or end users during the reporting period", 1L, "", 0, null, null },
                    { 11091L, "S4.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3216), null, null, 95L, null, 1L, null, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to consumers and end-users [see ESRS 2 - MDR-A]", 1L, "", 0, 709L, null },
                    { 11092L, "S4-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3218), null, 2L, 95L, true, 1L, null, null, null, "Description of action planned or underway to prevent, mitigate or remediate material negative impacts on consumers and end-users   ", 1L, "", 0, null, null },
                    { 11093L, "S4-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3220), null, 2L, 95L, true, 1L, null, null, null, "Description of whether and how action has been taken to provide or enable remedy in relation to an actual material impact", 1L, "", 0, null, null },
                    { 11094L, "S4-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3223), null, 2L, 95L, true, 1L, null, null, null, "Description of additional initiatives or processes with primary purpose of delivering positive impacts for consumers and end-users  ", 1L, "", 0, null, null },
                    { 11095L, "S4-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3229), null, 2L, 95L, true, 1L, null, null, null, "Description of how effectiveness of actions or initiatives in delivering outcomes for consumers and end-users is tracked and assessed ", 1L, "", 0, null, null },
                    { 11096L, "S4-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3233), null, 2L, 95L, true, 1L, null, null, null, "Description of approach to identifying what action is needed and appropriate in response to particular actual or potential material negative impact on  consumers and end-users   ", 1L, "", 0, null, null },
                    { 11097L, "S4-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3235), null, 2L, 95L, true, 1L, null, null, null, "Description of approach to taking action in relation to specific material impacts on consumers and end-users   ", 1L, "", 0, null, null },
                    { 11098L, "S4-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3237), null, 2L, 95L, true, 1L, null, null, null, "Description of approach to ensuring that processes to provide or enable remedy in event of material negative impacts on  consumers and end-users are available and effective in their implementation and outcomes ", 1L, "", 0, null, null },
                    { 11099L, "S4-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3240), null, 2L, 95L, true, 1L, null, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on consumers and end-users and how effectiveness is tracked ", 1L, "", 0, null, null },
                    { 11100L, "S4-4_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3242), null, 2L, 95L, true, 1L, null, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to consumers and end-users   ", 1L, "", 0, null, null },
                    { 11101L, "S4-4_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3244), null, 2L, 95L, true, 1L, null, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on consumers and end-users   ", 1L, "", 0, null, null },
                    { 11102L, "S4-4_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3246), null, 2L, 95L, true, 1L, null, null, null, "Disclosure of severe human rights issues and incidents connected to consumers and/or end-users", 1L, "", 0, null, null },
                    { 11103L, "S4-4_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3250), null, 2L, 95L, true, 1L, null, null, null, "Disclosure of resources allocated to management of material impacts ", 1L, "", 0, null, null },
                    { 11104L, "S4-4_13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3252), null, 2L, 95L, true, 1L, null, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting  consumers and end-users   ", 1L, "", 0, null, null },
                    { 11105L, "S4-4_14", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3254), null, 2L, 95L, true, 1L, null, null, null, "Disclosure of how participation in industry or multi-stakeholder initiative and undertaking's own involvement is aiming to address material impacts ", 1L, "", 0, null, null },
                    { 11106L, "S4-4_15", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3257), null, 2L, 95L, true, 1L, null, null, null, "Disclosure of how consumers and end-users play role in decisions regarding design and implementation of programmes or processes ", 1L, "", 0, null, null },
                    { 11107L, "S4-4_16", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3259), null, 2L, 95L, true, 1L, null, null, null, "Information about intended or achieved positive outcomes of programmes or processes for consumers and end-users   ", 1L, "", 0, null, null },
                    { 11108L, "S4-4_17", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3261), null, 2L, 95L, null, 1L, null, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for consumers and/or end-users are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 0, null, null },
                    { 11109L, "S4-4_18", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3264), null, 2L, 95L, true, 1L, null, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 0, null, null },
                    { 11111L, "S4.MDR-T_01-13", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3268), null, null, 96L, null, 1L, null, null, null, "Targets set to manage material impacts, risks and opportunities related to consumers and end-users [see ESRS 2 - MDR-T]", 1L, "", 0, null, null },
                    { 11112L, "S4-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3270), null, 2L, 96L, true, 1L, null, null, null, "Disclosure of whether and how consumers and end-users were engaged directly in setting targets", 1L, "", 0, null, null },
                    { 11113L, "S4-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3278), null, 2L, 96L, true, 1L, null, null, null, "Disclosure of whether and how consumers and end-users were engaged directly in tracking performance against targets", 1L, "", 0, null, null },
                    { 11114L, "S4-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3280), null, 2L, 96L, true, 1L, null, null, null, "Disclosure of whether and how consumers and end-users were engaged directly in identifying lessons or improvements as result of undertaking’s performance", 1L, "", 0, null, null },
                    { 11115L, "S4-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3282), null, 2L, 96L, true, 1L, null, null, null, "Disclosure of intended outcomes to be achieved in lives of consumers and end-users   ", 1L, "", 0, null, null },
                    { 11116L, "S4-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3286), null, 2L, 96L, true, 1L, null, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 0, null, null },
                    { 11117L, "S4-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3288), null, 2L, 96L, true, 1L, null, null, null, "Disclosure of references to standards or commitments on which target is based ", 1L, "", 0, null, null },
                    { 11119L, "G1.GOV-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3292), null, null, 97L, true, 1L, null, null, null, "Disclosure of role of administrative, management and supervisory bodies related to business conduct", 1L, "", 0, null, null },
                    { 11120L, "G1.GOV-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3294), null, 2L, 97L, true, 1L, null, null, null, "Disclosure of expertise of administrative, management and supervisory bodies on business conduct matters", 1L, "", 0, null, null },
                    { 11121L, "G1.MDR-P_01-06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3296), null, 2L, 98L, null, 1L, null, null, null, "Policies in place to manage its material impacts, risks and opportunities related to business conduct and corporate culture [see ESRS 2 MDR-P]", 1L, "", 0, null, null },
                    { 11122L, "G1-1_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3298), null, null, 98L, true, 1L, null, null, null, "Description of how the undertaking establishes, develops, promotes and evaluates its corporate culture", 1L, "", 0, null, null },
                    { 11123L, "G1-1_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3301), null, 2L, 98L, true, 1L, null, null, null, "Description of the mechanisms for identifying, reporting and investigating concerns about unlawful behaviour or behaviour in contradiction of its code of conduct or similar internal rules", 1L, "", 0, null, null },
                    { 11124L, "G1-1_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3303), null, 2L, 98L, null, 1L, null, null, null, "No policies on anti-corruption or anti-bribery consistent with United Nations Convention against Corruption are in place", 1L, "", 0, null, null },
                    { 11125L, "G1-1_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3305), null, 2L, 98L, true, 1L, null, null, null, "Timetable for implementation of policies on anti-corruption or anti-bribery consistent with United Nations Convention against Corruption", 1L, "", 0, null, null },
                    { 11126L, "G1-1_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3308), null, 2L, 98L, true, 1L, null, null, null, "Disclosure of safeguards for reporting irregularities including whistleblowing protection", 1L, "", 0, null, null },
                    { 11127L, "G1-1_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3310), null, 2L, 98L, null, 1L, null, null, null, "No policies on protection of whistle-blowers are in place", 1L, "", 0, null, null },
                    { 11128L, "G1-1_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3312), null, 2L, 98L, true, 1L, null, null, null, "Timetable for implementation of policies on protection of whistle-blowers", 1L, "", 0, null, null },
                    { 11129L, "G1-1_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3314), null, 2L, 98L, null, 1L, null, null, null, "Undertaking is committed to investigate business conduct incidents promptly, independently and objectively", 1L, "", 0, null, null },
                    { 11130L, "G1-1_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3321), null, 2L, 98L, null, 1L, null, null, null, "Policies with respect to animal welfare are in place", 1L, "", 0, null, null },
                    { 11131L, "G1-1_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3323), null, 2L, 98L, true, 1L, null, null, null, "Information about policy for training within organisation on business conduct", 1L, "", 0, null, null },
                    { 11132L, "G1-1_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3325), null, 2L, 98L, true, 1L, null, null, null, "Disclosure of the functions that are most at risk in respect of corruption and bribery", 1L, "", 0, null, null },
                    { 11133L, "G1-1_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3327), null, 2L, 98L, null, 1L, null, null, null, "Entity is subject to legal requirements with regard to protection of whistleblowers", 1L, "", 0, null, null },
                    { 11134L, "G1-2_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3330), null, 2L, 99L, true, 1L, null, null, null, "Description of policy to prevent late payments, especially to SMEs", 1L, "", 0, null, null },
                    { 11135L, "G1-2_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3332), null, 2L, 99L, true, 1L, null, null, null, "Description of approaches in regard to relationships with suppliers, taking account risks related to supply chain and impacts on sustainability matters", 1L, "", 0, null, null },
                    { 11136L, "G1-2_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3334), null, 2L, 99L, true, 1L, null, null, null, "Disclosure of whether and how social and environmental criteria are taken into account for selection of supply-side contractual partners", 1L, "", 0, null, null },
                    { 11138L, "G1-3_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3339), null, null, 100L, true, 1L, null, null, null, "Information about procedures in place to prevent, detect, and address allegations or incidents of corruption or bribery", 1L, "", 0, null, null },
                    { 11139L, "G1-3_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3342), null, 2L, 100L, null, 1L, null, null, null, "Investigators or investigating committee are separate from chain of management involved in prevention and detection of corruption or bribery", 1L, "", 0, null, null },
                    { 11140L, "G1-3_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3344), null, 2L, 100L, true, 1L, null, null, null, "Information about process to report outcomes to administrative, management and supervisory bodies", 1L, "", 0, null, null },
                    { 11141L, "G1-3_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3346), null, 2L, 100L, true, 1L, null, null, null, "Disclosure of plans to adopt procedures to prevent, detect, and address allegations or incidents of corruption or bribery in case of no procedure", 1L, "", 0, null, null },
                    { 11142L, "G1-3_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3348), null, 2L, 100L, true, 1L, null, null, null, "Information about how policies are communicated to those for whom they are relevant (prevention and detection of corruption or bribery)", 1L, "", 0, null, null },
                    { 11143L, "G1-3_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3350), null, 2L, 100L, true, 1L, null, null, null, "Information about nature, scope and depth of anti-corruption or anti-bribery training programmes offered or required", 1L, "", 0, null, null },
                    { 11144L, "G1-3_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3353), null, 2L, 100L, null, 1L, null, null, null, "Percentage of functions-at-risk covered by training programmes", 1L, "", 0, null, null },
                    { 11145L, "G1-3_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3355), null, null, 100L, true, 1L, null, null, null, "Information about members of administrative, supervisory and management bodies relating to anti-corruption or anti-bribery training", 1L, "", 0, 38L, null },
                    { 11146L, "G1-3_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3358), null, 2L, 100L, true, 1L, null, null, null, "Disclosure of an analysis of its training activities by, for example, region of training or category", 1L, "", 0, null, null },
                    { 11147L, "G1.MDR-A_01-12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3360), null, 2L, 101L, null, 1L, null, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to corruption and bribery [see ESRS 2 - MDR-A]", 1L, "", 0, null, null },
                    { 11148L, "G1-4_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3368), null, 2L, 101L, null, 1L, null, null, null, "Number of convictions for violation of anti-corruption and anti- bribery laws", 1L, "", 0, null, null },
                    { 11149L, "G1-4_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3370), null, null, 101L, null, 1L, null, null, null, "Amount of fines for violation of anti-corruption and anti- bribery laws", 1L, "", 0, 709L, null },
                    { 11150L, "G1-4_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3372), null, 3L, 101L, null, 1L, null, null, null, "Prevention and detection of corruption or bribery - anti-corruption and bribery training table", 1L, "", 0, null, null },
                    { 11151L, "G1-4_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3375), null, 1L, 101L, null, 1L, null, null, null, "Number of confirmed incidents of corruption or bribery", 1L, "", 0, null, null },
                    { 11152L, "G1-4_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3377), null, null, 101L, true, 1L, null, null, null, "Information about nature of confirmed incidents of corruption or bribery", 1L, "", 0, 709L, null },
                    { 11153L, "G1-4_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3379), null, 2L, 101L, null, 1L, null, null, null, "Number of confirmed incidents in which own workers were dismissed or disciplined for corruption or bribery-related incidents", 1L, "", 0, null, null },
                    { 11154L, "G1-4_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3381), null, null, 101L, null, 1L, null, null, null, "Number of confirmed incidents relating to contracts with business partners that were terminated or not renewed due to violations related to corruption or bribery", 1L, "", 0, 709L, null },
                    { 11155L, "G1-4_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3383), null, null, 101L, true, 1L, null, null, null, "Information about details of public legal cases regarding corruption or bribery brought against undertaking and own workers and about outcomes of such cases", 1L, "", 0, 709L, null },
                    { 11156L, "G1-5_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3385), null, 2L, 102L, true, 1L, null, null, null, "Information about representative(s) responsible in administrative, management and supervisory bodies for oversight of political influence and lobbying activities", 1L, "", 0, null, null },
                    { 11157L, "G1-5_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3388), null, 2L, 102L, true, 1L, null, null, null, "Information about financial or in-kind political contributions", 1L, "", 0, null, null },
                    { 11158L, "G1-5_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3391), null, 2L, 102L, null, 1L, null, null, null, "Financial political contributions made", 1L, "", 0, null, null },
                    { 11159L, "G1-5_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3393), null, 3L, 102L, null, 1L, null, null, null, "Amount of internal and external lobbying expenses", 1L, "", 0, null, null },
                    { 11160L, "G1-5_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3395), null, 3L, 102L, null, 1L, null, null, null, "Amount paid for membership to lobbying associations", 1L, "", 0, null, null },
                    { 11161L, "G1-5_06", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3397), null, 3L, 102L, null, 1L, null, null, null, "In-kind political contributions made", 1L, "", 0, null, null },
                    { 11162L, "G1-5_07", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3399), null, 3L, 102L, true, 1L, null, null, null, "Disclosure of how monetary value of in-kind contributions is estimated", 1L, "", 0, null, null },
                    { 11163L, "G1-5_08", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3401), null, 2L, 102L, null, 1L, null, null, null, "Financial and in-kind political contributions made [table]", 1L, "", 0, null, null },
                    { 11164L, "G1-5_09", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3403), null, 1L, 102L, true, 1L, null, null, null, "Disclosure of main topics covered by lobbying activities and undertaking's main positions on these topics", 1L, "", 0, null, null },
                    { 11165L, "G1-5_10", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3407), null, 2L, 102L, null, 1L, null, null, null, "Undertaking is registered in EU Transparency Register or in equivalent transparency register in Member State", 1L, "", 0, null, null },
                    { 11166L, "G1-5_11", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3413), null, 2L, 102L, true, 1L, null, null, null, "Information about appointment of any members of administrative, management and supervisory bodies who held comparable position in public administration in two years preceding such appointment", 1L, "", 0, null, null },
                    { 11167L, "G1-5_12", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3415), null, 2L, 102L, null, 1L, null, null, null, "The entity is legally obliged to be a member of a chamber of commerce or other organisation that represents its interests", 1L, "", 0, null, null },
                    { 11169L, "G1-6_01", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3419), null, null, 103L, null, 1L, null, null, null, "Average number of days to pay invoice from date when contractual or statutory term of payment starts to be calculated", 1L, "", 0, null, null },
                    { 11170L, "G1-6_02", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3421), null, null, 103L, true, 1L, null, null, null, "Description of undertakings standard payment terms in number of days by main category of suppliers", 1L, "", 0, 709L, null },
                    { 11171L, "G1-6_03", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3423), null, 2L, 103L, null, 1L, null, null, null, "Percentage of payments aligned with standard payment terms", 1L, "", 0, null, null },
                    { 11172L, "G1-6_04", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3425), null, null, 103L, null, 1L, null, null, null, "Number of outstanding legal proceedings for late payments", 1L, "", 0, 38L, null },
                    { 11173L, "G1-6_05", 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(3428), null, null, 103L, true, 1L, null, null, null, "Disclosure of contextual information regarding payment practices", 1L, "", 0, 709L, null }
                });

            migrationBuilder.InsertData(
                table: "ModelDimensionValues",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DimensionsId", "LastModifiedBy", "LastModifiedDate", "ModelDimensionTypesId", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5832), 1010L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5833), 1L, 1 },
                    { 2L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5835), 1011L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5836), 1L, 1 },
                    { 3L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5837), 1012L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5837), 1L, 1 },
                    { 4L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5838), 1000L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5839), 2L, 1 },
                    { 5L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5840), 1001L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5840), 2L, 1 },
                    { 6L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5842), 1002L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5842), 2L, 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5209), 1001L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5210), "Hour", "Hour", "Hr", 1 },
                    { 1L, 2L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5212), 1002L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5213), "Minute", "Minute", "Min", 1 },
                    { 1L, 3L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5214), 1003L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5215), "Second", "Second", "Sec", 1 },
                    { 1L, 4L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5216), 1004L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5217), "Day", "Day", "Day", 1 },
                    { 1L, 5L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5218), 1005L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5219), "Month", "Month", "Month", 1 },
                    { 1L, 6L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5220), 1006L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5221), "Quarter", "Quarter", "Qrtr", 1 },
                    { 1L, 7L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5227), 1007L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5227), "Year", "Year", "Year", 1 },
                    { 1L, 8L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5229), 1008L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5229), "Millimol per liter", "Millimol per liter", "mMol/l", 1 },
                    { 1L, 9L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5230), 1009L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5231), "Mol per cubic meter", "Mol per cubic meter", "Mol/m3", 1 },
                    { 1L, 10L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5232), 1010L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5233), "Mol per liter", "Mol per liter", "Mol/l", 1 },
                    { 1L, 11L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5234), 1011L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5235), "Acre", "Acre", "Acre", 1 },
                    { 1L, 12L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5236), 1012L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5237), "Hectare", "Hectare", "Ha", 1 },
                    { 1L, 13L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5240), 1013L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5240), "Square Yard", "Square Yard", "Yd2", 1 },
                    { 1L, 14L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5241), 1014L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5242), "Square centimeter", "Square centimeter", "Cm2", 1 },
                    { 1L, 15L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5243), 1015L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5244), "Square foot", "Square foot", "Ft2", 1 },
                    { 1L, 16L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5245), 1016L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5246), "Square inch", "Square inch", "Inch2", 1 },
                    { 1L, 17L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5247), 1017L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5248), "Square kilometer", "Square kilometer", "Km2", 1 },
                    { 1L, 18L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5249), 1018L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5250), "Square meter", "Square meter", "M2", 1 },
                    { 1L, 19L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5251), 1019L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5252), "Square mile", "Square mile", "Mile2", 1 },
                    { 1L, 20L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5253), 1020L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5254), "Square millimeter", "Square millimeter", "Mm2", 1 },
                    { 1L, 21L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5255), 1021L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5256), "Gram/Cubic meter", "Gram/Cubic meter", "G/M3", 1 },
                    { 1L, 22L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5258), 1022L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5258), "Gram/cubic centimeter", "Gram/cubic centimeter", "G/Cm3", 1 },
                    { 1L, 23L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5259), 1023L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5260), "Gram/liter", "Gram/liter", "G/L", 1 },
                    { 1L, 24L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5261), 1024L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5262), "Kilogram/Standard Cubic Foot", "Kilogram/Standard Cubic Foot", "Kg/Scf", 1 },
                    { 1L, 25L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5263), 1025L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5264), "Kilogram/US Barrel", "Kilogram/US Barrel", "Kg/Bbl", 1 },
                    { 1L, 26L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5265), 1026L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5266), "Kilogram/cubic decimeter", "Kilogram/cubic decimeter", "Kg/Dm3", 1 },
                    { 1L, 27L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5267), 1027L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5268), "Kilogram/cubic meter", "Kilogram/cubic meter", "Kg/M3", 1 },
                    { 1L, 28L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5269), 1028L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5270), "Microgram/cubic meter", "Microgram/cubic meter", "µg/M3", 1 },
                    { 1L, 29L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5271), 1029L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5271), "Microgram/liter", "Microgram/liter", "µg/L", 1 },
                    { 1L, 30L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5274), 1030L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5274), "Milligram/cubic meter", "Milligram/cubic meter", "Mg/M3", 1 },
                    { 1L, 31L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5276), 1031L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5276), "Milligram/liter", "Milligram/liter", "Mg/L", 1 },
                    { 1L, 32L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5277), 1032L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5278), "Ton/Cubic meter", "Ton/Cubic meter", "T/M3", 1 },
                    { 1L, 33L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5279), 1033L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5280), "Tonne/1000 Cubic Meters", "Tonne/1000 Cubic Meters", "T/Tm3", 1 },
                    { 1L, 34L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5281), 1034L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5282), "Tonne/US Barrel", "Tonne/US Barrel", "T/Bbl", 1 },
                    { 1L, 35L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5283), 1035L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5283), "US Pound/Standard Cubic Foot", "US Pound/Standard Cubic Foot", "Lb/Scf", 1 },
                    { 1L, 36L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5285), 1036L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5285), "US Pound/US Gallon", "US Pound/US Gallon", "Lb/Gal", 1 },
                    { 1L, 37L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5287), 1037L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5287), "US Tonne/US Gallon", "US Tonne/US Gallon", "Ton/Gl", 1 },
                    { 1L, 38L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5289), 1038L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5290), "Percentage", "Percentage", "%", 1 },
                    { 1L, 39L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5291), 1039L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5292), "Gigajoule", "Gigajoule", "Gj", 1 },
                    { 1L, 40L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5293), 1040L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5294), "Joule", "Joule", "J", 1 },
                    { 1L, 41L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5295), 1041L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5296), "Kilojoule", "Kilojoule", "Kj", 1 },
                    { 1L, 42L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5297), 1042L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5298), "Kilowatt hours", "Kilowatt hours", "Kwh", 1 },
                    { 1L, 43L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5299), 1043L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5299), "Megajoule", "Megajoule", "Mj", 1 },
                    { 1L, 44L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5301), 1044L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5301), "Megawatt hour", "Megawatt hour", "Mwh", 1 },
                    { 1L, 45L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5303), 1045L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5303), "Millijoule", "Millijoule", "Mj", 1 },
                    { 1L, 46L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5305), 1046L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5305), "kilocalories", "kilocalories", "Kcal", 1 },
                    { 1L, 47L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5307), 1047L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5308), "Kilonewton", "Kilonewton", "Nd", 1 },
                    { 1L, 48L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5309), 1048L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5310), "Meganewton", "Meganewton", "Mn", 1 },
                    { 1L, 49L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5311), 1049L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5312), "Newton", "Newton", "N", 1 },
                    { 1L, 50L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5313), 1050L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5314), "1/minute", "1/minute", "1/Min", 1 },
                    { 1L, 51L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5315), 1051L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5316), "Bottles per minute", "Bottles per minute", "Bpm", 1 },
                    { 1L, 52L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5317), 1052L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5317), "Hertz", "Hertz", "1/Second)", 1 },
                    { 1L, 53L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5319), 1053L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5319), "Kilohertz", "Kilohertz", "Khz", 1 },
                    { 1L, 54L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5321), 1054L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5321), "Megahertz", "Megahertz", "Mhz", 1 },
                    { 1L, 55L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5323), 1055L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5324), "RPM", "RPM", "Rpm", 1 },
                    { 1L, 56L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5325), 1056L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5326), "Heat Conductivity", "Heat Conductivity", "W/Mk", 1 },
                    { 1L, 57L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5327), 1057L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5328), "Liter/Molsecond", "Liter/Molsecond", "L/M_.S", 1 },
                    { 1L, 58L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5329), 1058L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5330), "1 / square meter", "1 / square meter", "1/M2", 1 },
                    { 1L, 59L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5331), 1059L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5332), "Miles per gallon", "Miles per gallon", "Us)", 1 },
                    { 1L, 60L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5333), 1060L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5333), "Square meter/second", "Square meter/second", "M2/S", 1 },
                    { 1L, 61L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5335), 1061L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5335), "Square millimeter/second", "Square millimeter/second", "Mm2/S", 1 },
                    { 1L, 62L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5337), 1062L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5337), "Centimeter", "Centimeter", "Cm", 1 },
                    { 1L, 63L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5339), 1063L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5339), "Decimeter", "Decimeter", "Dm", 1 },
                    { 1L, 64L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5343), 1064L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5343), "Foot", "Foot", "Foot", 1 },
                    { 1L, 65L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5344), 1065L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5345), "Inch", "Inch", "Inch", 1 },
                    { 1L, 66L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5346), 1066L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5347), "Kilometer", "Kilometer", "Km", 1 },
                    { 1L, 67L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5348), 1067L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5349), "Meter", "Meter", "M", 1 },
                    { 1L, 68L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5353), 1068L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5353), "Micrometer", "Micrometer", "µm", 1 },
                    { 1L, 69L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5355), 1069L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5356), "Mile", "Mile", "Mile", 1 },
                    { 1L, 70L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5357), 1070L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5357), "Millimeter", "Millimeter", "Mm", 1 },
                    { 1L, 71L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5359), 1071L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5359), "Nanometer", "Nanometer", "Nm", 1 },
                    { 1L, 72L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5361), 1072L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5362), "Yards", "Yards", "Yd", 1 },
                    { 1L, 73L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5363), 1073L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5364), "Candela", "Candela", "Cd", 1 },
                    { 1L, 74L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5365), 1074L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5366), "Tesla", "Tesla", "D", 1 },
                    { 1L, 75L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5367), 1075L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5368), "Gram", "Gram", "G", 1 },
                    { 1L, 76L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5369), 1076L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5370), "Kilotonne", "Kilotonne", "Kt", 1 },
                    { 1L, 77L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5371), 1077L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5371), "Milligram", "Milligram", "Mg", 1 },
                    { 1L, 78L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5373), 1078L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5373), "Ounce", "Ounce", "Oz", 1 },
                    { 1L, 79L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5374), 1079L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5375), "Tonne", "Tonne", "T", 1 },
                    { 1L, 80L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5377), 1080L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5377), "US pound", "US pound", "Lb", 1 },
                    { 1L, 81L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5379), 1081L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5380), "US ton", "US ton", "Ton", 1 },
                    { 1L, 82L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5381), 1082L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5382), "Kilogram", "Kilogram", "Kg", 1 },
                    { 1L, 83L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5383), 1083L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5383), "Gram/square meter", "Gram/square meter", "G/M2", 1 },
                    { 1L, 84L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5385), 1084L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5385), "Kilogram/Square meter", "Kilogram/Square meter", "Kg/M2", 1 },
                    { 1L, 85L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5387), 1085L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5387), "Milligram/Square centimeter", "Milligram/Square centimeter", "Mg/Cm2", 1 },
                    { 1L, 86L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5389), 1086L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5389), "Kilogram/second", "Kilogram/second", "Kg/S", 1 },
                    { 1L, 87L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5391), 1087L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5391), "Kilogram/Joule", "Kilogram/Joule", "Kg/J", 1 },
                    { 1L, 88L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5392), 1088L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5393), "Kilogram/Million BTU", "Kilogram/Million BTU", "Kg/Mb", 1 },
                    { 1L, 89L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5395), 1089L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5396), "Tonne/British Thermal Unit", "Tonne/British Thermal Unit", "T/Btu", 1 },
                    { 1L, 90L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5397), 1090L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5398), "Tonne/Joule", "Tonne/Joule", "T/Joul", 1 },
                    { 1L, 91L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5399), 1091L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5399), "Tonne/Terajoule", "Tonne/Terajoule", "T/Tj", 1 },
                    { 1L, 92L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5401), 1092L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5401), "US Pound/British Thermal Unit", "US Pound/British Thermal Unit", "Lb/Btu", 1 },
                    { 1L, 93L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5403), 1093L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5403), "US Pound/Million BTU", "US Pound/Million BTU", "Lb/Mb", 1 },
                    { 1L, 94L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5404), 1094L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5405), "Gram/hectogram", "Gram/hectogram", "G/Hg", 1 },
                    { 1L, 95L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5406), 1095L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5407), "Gram/kilogram", "Gram/kilogram", "G/Kg", 1 },
                    { 1L, 96L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5408), 1096L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5409), "Kilogram/Kilogram", "Kilogram/Kilogram", "Kg/Kg", 1 },
                    { 1L, 97L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5410), 1097L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5412), "Kilogram/US Tonne", "Kilogram/US Tonne", "Kg/Ton", 1 },
                    { 1L, 98L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5414), 1098L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5414), "Mass parts per billion", "Mass parts per billion", "Ppb(M)", 1 },
                    { 1L, 99L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5415), 1099L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5416), "Mass parts per million", "Mass parts per million", "Ppm(M)", 1 },
                    { 1L, 100L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5417), 1100L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5418), "Mass parts per trillion", "Mass parts per trillion", "Ppt(M)", 1 },
                    { 1L, 101L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5419), 1101L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5420), "Milligram/gram", "Milligram/gram", "Mg/G", 1 },
                    { 1L, 102L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5421), 1102L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5422), "Milligram/kilogram", "Milligram/kilogram", "Mg/Kg", 1 },
                    { 1L, 103L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5423), 1103L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5424), "Percent mass", "Percent mass", "%(M)", 1 },
                    { 1L, 104L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5425), 1104L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5425), "Permille mass", "Permille mass", "%O(M)", 1 },
                    { 1L, 105L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5427), 1105L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5427), "Tonne/Tonne", "Tonne/Tonne", "T/T", 1 },
                    { 1L, 106L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5430), 1106L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5430), "US Pound/US Tonne", "US Pound/US Tonne", "Lb/Ton", 1 },
                    { 1L, 107L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5432), 1107L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5432), "Microsecond", "Microsecond", "µs", 1 },
                    { 1L, 108L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5433), 1108L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5434), "Millisecond", "Millisecond", "Ms", 1 },
                    { 1L, 109L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5435), 1109L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5436), "Nanosecond", "Nanosecond", "Ns", 1 },
                    { 1L, 110L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5437), 1110L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5438), "Picosecond", "Picosecond", "Ps", 1 },
                    { 1L, 111L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5439), 1111L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5440), "Second", "Second", "S", 1 },
                    { 1L, 112L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5441), 1112L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5442), "Week", "Week", "W", 1 },
                    { 1L, 113L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5443), 1113L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5444), "Years", "Years", "Yr", 1 },
                    { 1L, 114L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5446), 1114L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5446), "Vaporization Speed", "Vaporization Speed", "Kg/Sm2", 1 },
                    { 1L, 115L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5448), 1115L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5448), "Centiliter", "Centiliter", "Cl", 1 },
                    { 1L, 116L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5449), 1116L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5450), "Cubic centimeter", "Cubic centimeter", "Cm3", 1 },
                    { 1L, 117L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5451), 1117L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5452), "Cubic decimeter", "Cubic decimeter", "Dm3", 1 },
                    { 1L, 118L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5453), 1118L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5454), "Cubic foot", "Cubic foot", "Ft3", 1 },
                    { 1L, 119L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5455), 1119L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5456), "Cubic inch", "Cubic inch", "Inch3", 1 },
                    { 1L, 120L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5457), 1120L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5458), "Cubic meter", "Cubic meter", "M3", 1 },
                    { 1L, 121L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5459), 1121L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5460), "Cubic millimeter", "Cubic millimeter", "Mm3", 1 },
                    { 1L, 122L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5461), 1122L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5462), "Cubic yard", "Cubic yard", "Yd3", 1 },
                    { 1L, 123L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5464), 1123L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5464), "Hectoliter", "Hectoliter", "Hl", 1 },
                    { 1L, 124L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5466), 1124L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5466), "Liter", "Liter", "L", 1 },
                    { 1L, 125L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5467), 1125L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5468), "Microliter", "Microliter", "µl", 1 },
                    { 1L, 126L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5469), 1126L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5470), "Milliliter", "Milliliter", "Ml", 1 },
                    { 1L, 127L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5471), 1127L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5472), "Pint, US liquid", "Pint, US liquid", "Pt Us", 1 },
                    { 1L, 128L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5479), 1128L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5479), "Quart, US liquid", "Quart, US liquid", "Qt Us", 1 },
                    { 1L, 129L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5480), 1129L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5481), "US gallon", "US gallon", "Gal Us", 1 },
                    { 1L, 130L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5482), 1130L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5483), "Cubic meter/Cubic meter", "Cubic meter/Cubic meter", "M3/M3", 1 },
                    { 1L, 131L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5485), 1131L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5486), "Milliliter/cubic meter", "Milliliter/cubic meter", "Ml/M3", 1 },
                    { 1L, 132L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5487), 1132L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5487), "Percent volume", "Percent volume", "%(V)", 1 },
                    { 1L, 133L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5490), 1133L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5491), "Permille volume", "Permille volume", "%O(V)", 1 },
                    { 1L, 134L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5494), 1134L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5495), "Volume parts per billion", "Volume parts per billion", "Ppb(V)", 1 },
                    { 1L, 135L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5496), 1135L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5496), "Volume parts per million", "Volume parts per million", "Ppm(V)", 1 },
                    { 1L, 136L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5498), 1136L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5499), "Volume parts per trillion", "Volume parts per trillion", "Ppt(V)", 1 },
                    { 1L, 137L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5500), 1137L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5501), "Cubic centimeter/second", "Cubic centimeter/second", "Cm3/S", 1 },
                    { 1L, 138L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5502), 1138L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5503), "Cubic meter/Hour", "Cubic meter/Hour", "M3/H", 1 },
                    { 1L, 139L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5504), 1139L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5505), "Cubic meter/day", "Cubic meter/day", "M3/D", 1 },
                    { 1L, 140L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5506), 1140L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5507), "Cubic meter/second", "Cubic meter/second", "M3/S", 1 },
                    { 1L, 141L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5508), 1141L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5508), "Liter per hour", "Liter per hour", "L/Hr", 1 },
                    { 1L, 142L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5511), 1142L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5511), "Liter/Minute", "Liter/Minute", "L/Min", 1 },
                    { 1L, 709L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5514), 1709L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5515), "Integer", "Integer", "Integer", 1 },
                    { 1L, 710L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5516), 1710L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5517), "Decimal", "Decimal", "Decimal", 1 },
                    { 1L, 717L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5518), 1717L, 1L, new DateTime(2024, 9, 30, 9, 15, 42, 709, DateTimeKind.Utc).AddTicks(5519), "Narrative", "Narrative", "Narrative", 1 }
                });

            migrationBuilder.InsertData(
                table: "Hierarchy",
                columns: new[] { "Id", "DataPointValuesId", "HierarchyId" },
                values: new object[,]
                {
                    { 1L, 10032L, 1L },
                    { 2L, 10033L, 1L },
                    { 3L, 10074L, 1L },
                    { 4L, 10075L, 1L },
                    { 5L, 10249L, 1L },
                    { 6L, 10250L, 1L },
                    { 7L, 10286L, 1L },
                    { 8L, 10287L, 1L },
                    { 9L, 10416L, 1L },
                    { 10L, 10417L, 1L },
                    { 11L, 10583L, 1L },
                    { 12L, 10584L, 1L },
                    { 13L, 10729L, 1L },
                    { 14L, 10730L, 1L },
                    { 15L, 10032L, 2L },
                    { 16L, 10033L, 2L },
                    { 17L, 10074L, 2L },
                    { 18L, 10075L, 2L },
                    { 19L, 10249L, 2L },
                    { 20L, 10250L, 2L },
                    { 21L, 10286L, 2L },
                    { 22L, 10287L, 2L },
                    { 23L, 10416L, 2L },
                    { 24L, 10417L, 2L },
                    { 25L, 10583L, 2L },
                    { 26L, 10584L, 2L },
                    { 27L, 10729L, 2L },
                    { 28L, 10730L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "idx_currency_id",
                table: "Currency",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "idx_datamodelfilters_id",
                table: "DataModelFilters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelFilters_DimensionTypeId",
                table: "DataModelFilters",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelFilters_FilterId",
                table: "DataModelFilters",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelFilters_ModelConfigurationId",
                table: "DataModelFilters",
                column: "ModelConfigurationId");

            migrationBuilder.CreateIndex(
                name: "idx_datamodels_id",
                table: "DataModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataModels_OrganizationId",
                table: "DataModels",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_DataModelValues_DataModel_DataModelId",
                table: "DataModelValues",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_DataPointValues_DatapointValuesId",
                table: "DataModelValues",
                column: "DataPointValuesId");

            migrationBuilder.CreateIndex(
                name: "idx_datamodelvalues_datamodel_datamodelid",
                table: "DataModelValues",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "idx_datamodelvalues_datapointvaluesid",
                table: "DataModelValues",
                column: "DataPointValuesId");

            migrationBuilder.CreateIndex(
                name: "idx_datamodelvalues_id",
                table: "DataModelValues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_AccountableUserId",
                table: "DataModelValues",
                column: "AccountableUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_ColumnId",
                table: "DataModelValues",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_CombinationId",
                table: "DataModelValues",
                column: "CombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_ResponsibleUserId",
                table: "DataModelValues",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_RowId",
                table: "DataModelValues",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "unq_contraint_oncombinational_datapoint",
                table: "DataModelValues",
                columns: new[] { "RowId", "ColumnId", "CombinationId", "DataPointValuesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_datapointtypes_id",
                table: "DataPointType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_LanguageId",
                table: "DataPointType",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointTypes_OrganizationId",
                table: "DataPointType",
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
                name: "idx_datapointvalues_id",
                table: "DataPointValue",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValue_ModelFilterCombinationId",
                table: "DataPointValue",
                column: "ModelFilterCombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_CurrencyId",
                table: "DataPointValue",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_DatapointTypeId",
                table: "DataPointValue",
                column: "DatapointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_DisclosureRequirementId",
                table: "DataPointValue",
                column: "DisclosureRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_LanguageId",
                table: "DataPointValue",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_OrganizationId",
                table: "DataPointValue",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_UnitOfMeasureId",
                table: "DataPointValue",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_UserId",
                table: "DataPointValue",
                column: "UserId");

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
                name: "idx_dimensions_id",
                table: "Dimensions",
                column: "Id");

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
                name: "idx_dimensiotypess_id",
                table: "DimensionTypes",
                column: "Id");

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
                name: "idx_disclosurerequirement_id",
                table: "DisclosureRequirement",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DisclosureRequirement_LanguageId",
                table: "DisclosureRequirement",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DisclosureRequirement_StandardId",
                table: "DisclosureRequirement",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "idx_hierarchy_id",
                table: "Hierarchy",
                column: "HierarchyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_DataPointValuesId",
                table: "Hierarchy",
                column: "DataPointValuesId");

            migrationBuilder.CreateIndex(
                name: "idx_languages_id",
                table: "Languages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_OrganizationId",
                table: "Languages",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "idx_modelconfiguration_id",
                table: "ModelConfiguration",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "idx_modelid_viewtype",
                table: "ModelConfiguration",
                columns: new[] { "DataModelId", "ViewType" });

            migrationBuilder.CreateIndex(
                name: "IX_ModelConfiguration_ColumnId",
                table: "ModelConfiguration",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelConfiguration_DataModelId",
                table: "ModelConfiguration",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelConfiguration_RowId",
                table: "ModelConfiguration",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "idx_modeldatapoints_id",
                table: "ModelDatapoints",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDatapoints_DataModelId",
                table: "ModelDatapoints",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDatapoints_DatapointValuesId",
                table: "ModelDatapoints",
                column: "DatapointValuesId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_ModelDimensionTypes_DimensionType_DimensionTypeId",
                table: "ModelDimensionTypes",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "idx_modeldimensiontypes_id",
                table: "ModelDimensionTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDimensionTypes_DataModelId",
                table: "ModelDimensionTypes",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "idx_modeldimensionvalues_id",
                table: "ModelDimensionValues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDimensionValues_DimensionsId",
                table: "ModelDimensionValues",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDimensionValues_ModelDimensionTypesId",
                table: "ModelDimensionValues",
                column: "ModelDimensionTypesId");

            migrationBuilder.CreateIndex(
                name: "idx_datamodelfilters_datamodelfiltersid",
                table: "ModelFilterCombinationalValues",
                column: "DataModelFiltersId");

            migrationBuilder.CreateIndex(
                name: "idx_dimensontype_dimesiontypeid",
                table: "ModelFilterCombinationalValues",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "idx_modelfiltercombination_modelfiltercombinationsid",
                table: "ModelFilterCombinationalValues",
                column: "ModelFilterCombinationsId");

            migrationBuilder.CreateIndex(
                name: "idx_modelfiltercombinationalvalues_id",
                table: "ModelFilterCombinationalValues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFilterCombinationalValues_DimensionsId",
                table: "ModelFilterCombinationalValues",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_DataModel_DataModelId",
                table: "ModelFilterCombinations",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "idx_modelfiltercombinations_id",
                table: "ModelFilterCombinations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationHeirarchies_OrganizationId",
                table: "OrganizationHeirarchies",
                column: "OrganizationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_TenantId",
                table: "Organizations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_OrganizationId",
                table: "OrganizationUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_UserId",
                table: "OrganizationUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_DataModelFilters_DatamodelFiltersId",
                table: "SampleModelFilterCombinationValues",
                column: "DataModelFiltersId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_ModelFlterCombinations_ModelFIlterCombinationsId",
                table: "SampleModelFilterCombinationValues",
                column: "ModelFilterCombinationsId");

            migrationBuilder.CreateIndex(
                name: "idx_sampledatamodelfiltercombinationalvalue_sid",
                table: "SampleModelFilterCombinationValues",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SampleModelFilterCombinationValues_DimensionsId",
                table: "SampleModelFilterCombinationValues",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "idx_standard_id",
                table: "Standard",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Standard_LanguageId",
                table: "Standard",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Standard_TopicId",
                table: "Standard",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "idx_tenant_id",
                table: "Tenants",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "idx_topic_id",
                table: "Topic",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LanguageId",
                table: "Topic",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "idx_unitofmeasure_id",
                table: "UnitOfMeasures",
                column: "Id");

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
                name: "idx_unitofmeasuretype_id",
                table: "UnitOfMeasureTypes",
                column: "Id");

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
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_users_id",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LanguageId",
                table: "Users",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "DataModelValues");

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
                name: "ModelDatapoints");

            migrationBuilder.DropTable(
                name: "ModelDimensionValues");

            migrationBuilder.DropTable(
                name: "ModelFilterCombinationalValues");

            migrationBuilder.DropTable(
                name: "OrganizationHeirarchies");

            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "SampleModelFilterCombinationValues");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTranslations");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypeTranslations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "DataPointValue");

            migrationBuilder.DropTable(
                name: "ModelDimensionTypes");

            migrationBuilder.DropTable(
                name: "DataModelFilters");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DataPointType");

            migrationBuilder.DropTable(
                name: "ModelFilterCombinations");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DisclosureRequirement");

            migrationBuilder.DropTable(
                name: "ModelConfiguration");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypes");

            migrationBuilder.DropTable(
                name: "Standard");

            migrationBuilder.DropTable(
                name: "DataModels");

            migrationBuilder.DropTable(
                name: "DimensionTypes");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}

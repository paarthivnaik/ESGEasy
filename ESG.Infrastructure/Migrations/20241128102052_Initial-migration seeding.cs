using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigrationseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "amendments_id_seq");

            migrationBuilder.CreateSequence(
                name: "UploadedFile_Id_seq");

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
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ViewType = table.Column<int>(type: "integer", nullable: true)
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
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    Code = table.Column<string>(type: "text", nullable: false),
                    UnitOfMeasureTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    DatapointTypeId = table.Column<long>(type: "bigint", nullable: true),
                    UnitOfMeasureId = table.Column<long>(type: "bigint", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    IsNarrative = table.Column<bool>(type: "boolean", nullable: true),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    DisclosureRequirementId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true)
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
                name: "Amendments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilterCombinationId = table.Column<long>(type: "bigint", nullable: true),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DatapointId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Amendments_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amendments1-FilterCombinationId",
                        column: x => x.FilterCombinationId,
                        principalTable: "ModelFilterCombinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Amendments_DataPointValuesId",
                        column: x => x.DatapointId,
                        principalTable: "DataPointValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Amendments_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
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
                    DataModelId = table.Column<long>(type: "bigint", nullable: true),
                    Consult = table.Column<long>(type: "bigint", nullable: true),
                    Inform = table.Column<long>(type: "bigint", nullable: true)
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
                        name: "FK_DataModelValues_Users_Consult",
                        column: x => x.Consult,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataModelValues_Users_Inform",
                        column: x => x.Inform,
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
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
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
                    DatapointValueId = table.Column<long>(type: "bigint", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: true),
                    ShortText = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "UploadedFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FileData = table.Column<byte[]>(type: "bytea", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    DataModelValueId = table.Column<long>(type: "bigint", nullable: true),
                    IsDefaultModel = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UploadedFile_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadFile_DefaultDataModelValues",
                        column: x => x.DataModelValueId,
                        principalTable: "DataModelValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadedFile_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    { 2L, "nl", "Duch", null }
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
                    { 57L, "S1.SBM-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5218), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5221), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 },
                    { 76L, "S2.SBM-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5431), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5432), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 },
                    { 90L, "S4.SBM-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5522), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5523), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 }
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
                    { 1L, "general", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6286), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6288), "General", "General", 1 },
                    { 2L, "environment", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6293), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6295), "E-Environment", "E-Environment", 1 },
                    { 3L, "social", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6336), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6337), "S-Social", "S-Social", 1 },
                    { 4L, "governance", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6341), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6342), "G-Governance", "G-Governance", 1 },
                    { 17L, "general", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6347), 2L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6349), "Algemeen", "Algemeen", 1 },
                    { 18L, "environment", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6353), 2L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6354), "M-Milieu", "M-Milieu", 1 },
                    { 19L, "social", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6358), 2L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6360), "S-Sociaal", "S-Sociaal", 1 },
                    { 20L, "governance", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6364), 2L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6365), "B-Bestuur", "B-Bestuur", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "Password", "PhoneNumber", "SecurityStamp", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6954), "user1@example.com", "John", 1L, null, null, "Doe", "password1", "1234567890", new Guid("2085fbc8-27ad-4bc2-ae2d-281039b6e6b6"), 0 },
                    { 2L, 2L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6960), "user2@example.com", "Jane", 1L, null, null, "Smith", "password2", "0987654321", new Guid("3551ba86-ff0d-4b56-b427-e107782d1996"), 0 },
                    { 3L, 3L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6966), "user3@example.com", "Alice", 1L, null, null, "Johnson", "password3", "2345678901", new Guid("639f2cb7-f334-42eb-af35-7e307be4bc9d"), 0 },
                    { 4L, 4L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6972), "user4@example.com", "Bob", 1L, null, null, "Brown", "password4", "3456789012", new Guid("b2dd24d6-6d7d-4e19-b5ab-1c1ebb663574"), 0 },
                    { 5L, 5L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6977), "user5@example.com", "Charlie", 1L, null, null, "Davis", "password5", "4567890123", new Guid("9455c0f0-9dea-475f-8da5-e7995824ce03"), 0 },
                    { 6L, 6L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6994), "user6@example.com", "David", 1L, null, null, "Evans", "password6", "5678901234", new Guid("f4af141f-b585-427f-bc17-8301123829b1"), 0 },
                    { 7L, 7L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7000), "user7@example.com", "Eve", 1L, null, null, "Foster", "password7", "6789012345", new Guid("27f607a3-3765-4c61-831c-4530bc98c9cd"), 0 },
                    { 8L, 8L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7006), "user8@example.com", "Frank", 1L, null, null, "Garcia", "password8", "7890123456", new Guid("f61a0391-e4c0-493a-861d-2cf9ab4b9e72"), 0 },
                    { 9L, 9L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7012), "user9@example.com", "Grace", 1L, null, null, "Harris", "password9", "8901234567", new Guid("5591873a-2764-40ef-b89e-f27ee2acff83"), 0 },
                    { 10L, 10L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7018), "user10@example.com", "Hank", 1L, null, null, "Ivy", "password10", "9012345678", new Guid("7eea8880-127b-4b3e-b03b-8314246db550"), 0 },
                    { 11L, 11L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7067), "user11@example.com", "Irene", 1L, null, null, "James", "password11", "0123456789", new Guid("cf512121-d102-4e0e-968b-a3b37c872eaf"), 0 },
                    { 12L, 12L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7072), "user12@example.com", "Jack", 1L, null, null, "Kane", "password12", "1234509876", new Guid("8bc1f164-a9bc-4c42-994c-d6b4db9193a9"), 0 },
                    { 13L, 13L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7078), "user13@example.com", "Laura", 1L, null, null, "Mills", "password13", "2345610987", new Guid("300c421b-aec5-45e0-a160-090fe5e5d077"), 0 },
                    { 14L, 14L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7087), "user14@example.com", "Mike", 1L, null, null, "Nelson", "password14", "3456721098", new Guid("c16ff075-58d1-4f5f-8772-ab7495fbee14"), 0 },
                    { 15L, 15L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7092), "user15@example.com", "Nina", 1L, null, null, "Owen", "password15", "4567832109", new Guid("1fb8453d-82ef-4573-ac60-1b8768398b70"), 0 },
                    { 16L, 16L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7098), "user16@example.com", "Oliver", 1L, null, null, "Perez", "password16", "5678943210", new Guid("6cbe6711-71c4-4f8e-b5dd-49bc55d94104"), 0 },
                    { 17L, 17L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7104), "user17@example.com", "Pam", 1L, null, null, "Quinn", "password17", "6789054321", new Guid("3e433375-4ad7-408a-b16b-8b134c7d3acb"), 0 },
                    { 18L, 18L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(7110), "user18@example.com", "Quinn", 1L, null, null, "Reed", "password18", "7890165432", new Guid("a2fcec94-1b4e-47d4-b86b-f8342705ac9d"), 0 },
                    { 101L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6939), "user101@example.com", "John", 1L, null, null, "Doe", "password101", "1234567890", new Guid("8b584911-ae1d-488f-9c60-10db58edfff8"), 0 },
                    { 102L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6947), "user102@example.com", "John", 1L, null, null, "Doe", "password102", "1234567890", new Guid("a6cccd51-d5be-4b8d-b834-673c5e8caf54"), 0 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "yyyy", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4316), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4328), "Year", 1L, "Year", 1 },
                    { 2L, "m", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4340), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4342), "Month", 1L, "Month", 1 },
                    { 3L, "q", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4348), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4350), "Quarter", 1L, "Quarter", 1 },
                    { 4L, "d", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4356), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4358), "Day", 1L, "Day", 1 },
                    { 5L, "vatyp", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4365), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4366), "Value Type", 1L, "Value Type", 1 },
                    { 6L, "cntry", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4372), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4373), "Country", 1L, "Country", 1 },
                    { 7L, "city", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4379), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4380), "City", 1L, "City", 1 },
                    { 8L, "rgn", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4386), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4387), "Region", 1L, "Region", 1 },
                    { 9L, "sdg", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4393), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4394), "Sustainable Development", 1L, "SDG", 1 },
                    { 10L, "liro", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4400), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4401), "Line Of Reporting", 1L, "Line Of Reporting", 1 },
                    { 11L, "domn", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4407), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4408), "Domain", 1L, "Domain", 1 },
                    { 12L, "bsnss", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4414), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4415), "Business", 1L, "Business", 1 },
                    { 13L, "mrkt", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4421), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4422), "Market", 1L, "Market", 1 },
                    { 14L, "factory", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4428), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4429), "Factory", 1L, "Factory", 1 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5962), null, null, 1L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5966), null, null, 1L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5968), null, null, 1L, 0, 3L },
                    { 4L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5974), null, null, 2L, 0, 4L },
                    { 5L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5976), null, null, 2L, 0, 5L },
                    { 6L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5978), null, null, 2L, 0, 6L },
                    { 7L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5980), null, null, 3L, 0, 7L },
                    { 8L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5982), null, null, 3L, 0, 8L },
                    { 9L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5984), null, null, 3L, 0, 9L },
                    { 10L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5986), null, null, 4L, 0, 10L },
                    { 11L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5988), null, null, 4L, 0, 11L },
                    { 12L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5990), null, null, 4L, 0, 12L },
                    { 13L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5992), null, null, 5L, 0, 13L },
                    { 14L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5994), null, null, 5L, 0, 14L },
                    { 15L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5996), null, null, 5L, 0, 15L },
                    { 16L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5998), null, null, 6L, 0, 16L },
                    { 17L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6000), null, null, 6L, 0, 17L },
                    { 18L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6001), null, null, 6L, 0, 18L },
                    { 19L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5970), null, null, 1L, 0, 101L },
                    { 20L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5972), null, null, 1L, 0, 102L }
                });

            migrationBuilder.InsertData(
                table: "Standard",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State", "TopicId" },
                values: new object[,]
                {
                    { 1L, "ESRS2_GP", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6108), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6111), "General principles", "General principles", 1, 1L },
                    { 2L, "ESRS2_MDR", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6117), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6118), "General disclosures", "General disclosures", 1, 1L },
                    { 3L, "E1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6123), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6124), "Climate change", "Climate change", 1, 2L },
                    { 4L, "E2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6128), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6129), "Pollution", "Pollution", 1, 2L },
                    { 5L, "E3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6133), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6135), "Water & marine resources", "Water & marine resources", 1, 2L },
                    { 6L, "E4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6138), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6140), "Biodiversity and eco systems", "Biodiversity and eco systems", 1, 2L },
                    { 7L, "E5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6144), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6145), "Resourtce use and circular economy", "Resourtce use and circular economy", 1, 2L },
                    { 8L, "S1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6149), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6150), "Own workforce", "Own workforce", 1, 3L },
                    { 9L, "S2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6154), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6155), "Workers in value chain", "Workers in value chain", 1, 3L },
                    { 10L, "S3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6159), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6160), "Affected communities", "Affected communities", 1, 3L },
                    { 11L, "S4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6164), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6165), "Consumers and end-users", "Consumers and end-users", 1, 3L },
                    { 12L, "G1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6169), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6170), "Business Conduct", "Business Conduct", 1, 4L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "acidbasecapacity", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6479), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6481), "Acid/Base capacity", 1L, "Acid/Base capacity", 1 },
                    { 2L, "area", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6487), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6488), "Area", 1L, "Area", 1 },
                    { 3L, "density", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6493), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6494), "Density", 1L, "Density", 1 },
                    { 4L, "energy", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6498), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6499), "Energy", 1L, "Energy", 1 },
                    { 5L, "force", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6503), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6505), "Force", 1L, "Force", 1 },
                    { 6L, "frequency", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6508), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6510), "Frequency", 1L, "Frequency", 1 },
                    { 7L, "heat_conductivity", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6513), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6514), "Heat Conductivity", 1L, "Heat Conductivity", 1 },
                    { 8L, "hydrolysis_rate", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6520), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6521), "Hydrolysis rate", 1L, "Hydrolysis rate", 1 },
                    { 9L, "inverse_area", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6525), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6526), "Inverse area", 1L, "Inverse area", 1 },
                    { 10L, "kinematic_viscosity", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6529), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6531), "Kinematic viscosity", 1L, "Kinematic viscosity", 1 },
                    { 11L, "length", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6534), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6536), "Length", 1L, "Length", 1 },
                    { 12L, "luminous_intensity", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6539), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6541), "Luminous intensity", 1L, "Luminous intensity", 1 },
                    { 13L, "magnet_field_dens", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6544), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6545), "Magnet. field dens.", 1L, "Magnet. field dens.", 1 },
                    { 14L, "mass", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6549), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6550), "Mass", 1L, "Mass", 1 },
                    { 15L, "mass_coverage", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6556), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6557), "Mass coverage", 1L, "Mass coverage", 1 },
                    { 16L, "mass_flow", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6560), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6562), "Mass flow", 1L, "Mass flow", 1 },
                    { 17L, "mass_per_energy", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6565), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6567), "Mass per Energy", 1L, "Mass per Energy", 1 },
                    { 18L, "mass_proportion", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6570), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6571), "Mass proportion", 1L, "Mass proportion", 1 },
                    { 19L, "proportion", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6575), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6576), "Proportion", 1L, "Proportion", 1 },
                    { 20L, "time", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6579), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6580), "Time", 1L, "Time", 1 },
                    { 21L, "vaporization_speed", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6584), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6585), "Vaporization Speed", 1L, "Vaporization Speed", 1 },
                    { 22L, "volume", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6589), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6590), "Volume", 1L, "Volume", 1 },
                    { 23L, "volume_proportion", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6593), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6594), "Volume proportion", 1L, "Volume proportion", 1 },
                    { 24L, "volume_rate_of_flow", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6598), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6599), "Volume rate of flow", 1L, "Volume rate of flow", 1 },
                    { 121L, "monetary", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6602), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6604), "Monetary", 1L, "Monetary", 1 },
                    { 126L, "narrative", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6607), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6608), "Text", 1L, "Text", 1 },
                    { 131L, "number", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6611), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6613), "Number", 1L, "Number", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6713), null, null, 2L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6716), null, null, 3L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6719), null, null, 3L, 0, 3L },
                    { 4L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6721), null, null, 2L, 0, 4L },
                    { 5L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6723), null, null, 3L, 0, 5L },
                    { 6L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6764), null, null, 3L, 0, 6L },
                    { 7L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6767), null, null, 2L, 0, 7L },
                    { 8L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6769), null, null, 3L, 0, 8L },
                    { 9L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6771), null, null, 3L, 0, 9L },
                    { 10L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6773), null, null, 2L, 0, 10L },
                    { 11L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6775), null, null, 3L, 0, 11L },
                    { 12L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6777), null, null, 3L, 0, 12L },
                    { 13L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6779), null, null, 2L, 0, 13L },
                    { 14L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6781), null, null, 3L, 0, 14L },
                    { 15L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6783), null, null, 3L, 0, 15L },
                    { 16L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6785), null, null, 2L, 0, 16L },
                    { 17L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6787), null, null, 3L, 0, 17L },
                    { 18L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6789), null, null, 3L, 0, 18L },
                    { 19L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6791), null, null, 1L, 0, 101L },
                    { 20L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(6793), null, null, 1L, 0, 102L }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DimensionTypeId", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1000L, "act", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4514), 5L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4522), "Actual", 1L, "Actual", 1 },
                    { 1001L, "base", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4528), 5L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4530), "Baseline", 1L, "Baseline", 1 },
                    { 1002L, "target", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4592), 5L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4594), "Target", 1L, "Target", 1 },
                    { 1003L, "de", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4599), 6L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4603), "Germany", 1L, "DE", 1 },
                    { 1004L, "nl", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4608), 6L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4609), "The Netherlands", 1L, "NL", 1 },
                    { 1005L, "dap", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4614), 12L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4615), "Domestic Appliances", 1L, "DAP", 1 },
                    { 1006L, "pms", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4620), 12L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4621), "Medical systems", 1L, "PMS", 1 },
                    { 1007L, "eur", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4626), 13L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4627), "Europe", 1L, "EUR", 1 },
                    { 1008L, "ame", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4631), 13L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4633), "Africa, Middle East", 1L, "AME", 1 },
                    { 1009L, "tern", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4637), 14L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4638), "Terneuzen", 1L, "Terneuzen", 1 },
                    { 1010L, "2023", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4642), 1L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4644), "2023", 1L, "2023", 1 },
                    { 1011L, "2024", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4651), 1L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4652), "2024", 1L, "2024", 1 },
                    { 1012L, "2025", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4656), 1L, 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4657), "2025", 1L, "2025", 1 }
                });

            migrationBuilder.InsertData(
                table: "DisclosureRequirement",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "StandardId", "State" },
                values: new object[,]
                {
                    { 1L, "BP-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4739), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4741), "General basis for preparation of sustainability statements", "General basis for preparation of sustainability statements", 1L, 1 },
                    { 2L, "BP-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4757), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4759), "Disclosures in relation to specific circumstances", "Disclosures in relation to specific circumstances", 1L, 1 },
                    { 3L, "GOV-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4764), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4766), "The role of the administrative, management and supervisory bodies", "The role of the administrative, management and supervisory bodies", 1L, 1 },
                    { 4L, "GOV-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4778), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4780), "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", 1L, 1 },
                    { 5L, "GOV-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4786), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4789), "Integration of sustainability-related performance in incentive schemes", "Integration of sustainability-related performance in incentive schemes", 1L, 1 },
                    { 6L, "GOV-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4799), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4801), "Statement on due diligence", "Statement on due diligence", 1L, 1 },
                    { 7L, "GOV-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4808), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4811), "Risk management and internal controls over sustainability reporting", "Risk management and internal controls over sustainability reporting", 1L, 1 },
                    { 8L, "SBM-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4815), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4818), "Strategy, business model and value chain", "Strategy, business model and value chain", 1L, 1 },
                    { 9L, "SBM-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4826), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4829), "Interests and views of stakeholders", "Interests and views of stakeholders", 1L, 1 },
                    { 10L, "SBM-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4835), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4836), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 1L, 1 },
                    { 11L, "IRO-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4840), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4842), "Description of the process to identify and assess material impacts, risks and opportunities", "Description of the process to identify and assess material impacts, risks and opportunities", 1L, 1 },
                    { 12L, "IRO-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4846), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4848), "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", 1L, 1 },
                    { 13L, "MDR-P", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4856), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4858), "Policies adopted to manage material sustainability matters", "Policies adopted to manage material sustainability matters", 2L, 1 },
                    { 14L, "MDR-A", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4942), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4943), "Actions and resources in relation to material sustainability matters", "Actions and resources in relation to material sustainability matters", 2L, 1 },
                    { 15L, "MDR-M", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4948), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4949), "Metrics in relation to material sustainability matters", "Metrics in relation to material sustainability matters", 2L, 1 },
                    { 16L, "MDR-T", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4953), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4954), "Tracking effectiveness of policies and actions through targets", "Tracking effectiveness of policies and actions through targets", 2L, 1 },
                    { 17L, "E1.GOV-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4958), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4960), "Integration of sustainability-related performance in incentive schemes", "Integration of sustainability-related performance in incentive schemes", 3L, 1 },
                    { 18L, "E1-1 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4964), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4967), "Transition plan for climate change mitigation", "Transition plan for climate change mitigation", 3L, 1 },
                    { 19L, "E1.SBM-3 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4971), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4973), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 3L, 1 },
                    { 20L, "E1.IRO-1 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4976), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4978), "Description of the processes to identify and assess material climate-related impacts, risks and opportunities", "Description of the processes to identify and assess material climate-related impacts, risks and opportunities", 3L, 1 },
                    { 21L, "E1-2 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4983), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4984), "Policies related to climate change mitigation and adaptation", "Policies related to climate change mitigation and adaptation", 3L, 1 },
                    { 22L, "E1-3 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4988), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4990), "Actions and resources in relation to climate change policies", "Actions and resources in relation to climate change policies", 3L, 1 },
                    { 23L, "E1-4 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4994), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4995), "Targets related to climate change mitigation and adaptation", "Targets related to climate change mitigation and adaptation", 3L, 1 },
                    { 24L, "E1-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(4999), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5002), "Energy consumption and mix", "Energy consumption and mix", 3L, 1 },
                    { 25L, "E1-6", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5009), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5010), "Gross Scopes 1, 2, 3 and Total GHG emissions", "Gross Scopes 1, 2, 3 and Total GHG emissions", 3L, 1 },
                    { 26L, "E1-7 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5014), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5015), "GHG removals and GHG mitigation projects financed through carbon credits", "GHG removals and GHG mitigation projects financed through carbon credits", 3L, 1 },
                    { 27L, "E1-8 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5019), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5022), "Internal carbon pricing", "Internal carbon pricing", 3L, 1 },
                    { 28L, "E1-9 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5027), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5028), "Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", "Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", 3L, 1 },
                    { 29L, "E2.IRO-1 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5032), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5033), "Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", "Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 30L, "E2-1 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5037), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5038), "Policies related to pollution", "Policies related to pollution", 4L, 1 },
                    { 31L, "E2-2 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5045), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5047), "Actions and resources related to pollution", "Actions and resources related to pollution", 4L, 1 },
                    { 32L, "E2-3 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5052), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5057), "Targets related to pollution", "Targets related to pollution", 4L, 1 },
                    { 33L, "E2-4 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5064), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5065), "Pollution of air, water and soil", "Pollution of air, water and soil", 4L, 1 },
                    { 34L, "E2-5 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5069), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5070), "Substances of concern and substances of very high concern", "Substances of concern and substances of very high concern", 4L, 1 },
                    { 35L, "E2-6 ", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5074), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5075), "Anticipated financial effects from pollution-related impacts, risks and opportunities", "Anticipated financial effects from pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 36L, "E3.IRO-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5078), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5080), "Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", "Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 37L, "E3-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5083), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5086), "Policies related to water and marine resources", "Policies related to water and marine resources", 5L, 1 },
                    { 38L, "E3-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5090), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5091), "Actions and resources related to water and marine resources", "Actions and resources related to water and marine resources", 5L, 1 },
                    { 39L, "E3-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5095), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5096), "Targets related to water and marine resources", "Targets related to water and marine resources", 5L, 1 },
                    { 40L, "E3-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5100), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5101), "Water consumption", "Water consumption", 5L, 1 },
                    { 41L, "E3-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5105), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5106), "Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", "Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 42L, "E4.SBM-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5109), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5111), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 6L, 1 },
                    { 43L, "E4.IRO-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5116), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5117), "Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", "Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", 6L, 1 },
                    { 44L, "E4-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5125), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5127), "Transition plan and consideration of biodiversity and ecosystems in strategy and business model", "Transition plan and consideration of biodiversity and ecosystems in strategy and business model", 6L, 1 },
                    { 45L, "E4-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5132), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5133), "Policies related to biodiversity and ecosystems", "Policies related to biodiversity and ecosystems", 6L, 1 },
                    { 46L, "E4-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5138), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5139), "Actions and resources related to biodiversity and ecosystems", "Actions and resources related to biodiversity and ecosystems", 6L, 1 },
                    { 47L, "E4-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5145), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5148), "Targets related to biodiversity and ecosystems", "Targets related to biodiversity and ecosystems", 6L, 1 },
                    { 48L, "E4-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5153), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5155), "Impact metrics related to biodiversity and ecosystems change", "Impact metrics related to biodiversity and ecosystems change", 6L, 1 },
                    { 49L, "E4-6", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5166), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5170), "Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", "Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", 6L, 1 },
                    { 50L, "E5.IRO-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5174), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5175), "Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", "Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 51L, "E5-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5185), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5187), "Policies related to resource use and circular economy", "Policies related to resource use and circular economy", 7L, 1 },
                    { 52L, "E5-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5191), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5192), "Actions and resources related to resource use and circular economy", "Actions and resources related to resource use and circular economy", 7L, 1 },
                    { 53L, "E5-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5196), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5197), "Targets related to resource use and circular economy", "Targets related to resource use and circular economy", 7L, 1 },
                    { 54L, "E5-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5200), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5202), "Resource inflows", "Resource inflows", 7L, 1 },
                    { 55L, "E5-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5205), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5206), "Resource outflows", "Resource outflows", 7L, 1 },
                    { 56L, "E5-6", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5210), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5212), "Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", "Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 58L, "S1.SBM-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5226), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5230), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 8L, 1 },
                    { 59L, "S1-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5292), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5296), "Policies related to own workforce", "Policies related to own workforce", 8L, 1 },
                    { 60L, "S1-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5307), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5310), "Processes for engaging with own workforce and workers’ representatives about impacts", "Processes for engaging with own workforce and workers’ representatives about impacts", 8L, 1 },
                    { 61L, "S1-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5320), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5324), "Processes to remediate negative impacts and channels for own workforce to raise concerns", "Processes to remediate negative impacts and channels for own workforce to raise concerns", 8L, 1 },
                    { 62L, "S1-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5330), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5332), "Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", "Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", 8L, 1 },
                    { 63L, "S1-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5336), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5337), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 8L, 1 },
                    { 64L, "S1-6", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5347), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5348), "Characteristics of the undertaking’s employees", "Characteristics of the undertaking’s employees", 8L, 1 },
                    { 65L, "S1-7", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5356), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5358), "Characteristics of non-employees in the undertaking’s own workforce", "Characteristics of non-employees in the undertaking’s own workforce", 8L, 1 },
                    { 66L, "S1-8", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5364), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5369), "Collective bargaining coverage and social dialogue", "Collective bargaining coverage and social dialogue", 8L, 1 },
                    { 67L, "S1-9", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5376), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5379), "Diversity metrics", "Diversity metrics", 8L, 1 },
                    { 68L, "S1-10", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5384), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5385), "Adequate wages", "Adequate wages", 8L, 1 },
                    { 69L, "S1-11", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5389), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5390), "Social protection", "Social protection", 8L, 1 },
                    { 70L, "S1-12", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5400), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5401), "Persons with disabilities", "Persons with disabilities", 8L, 1 },
                    { 71L, "S1-13", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5405), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5406), "Training and skills development metrics", "Training and skills development metrics", 8L, 1 },
                    { 72L, "S1-14", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5410), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5411), "Health and safety metrics", "Health and safety metrics", 8L, 1 },
                    { 73L, "S1-15", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5414), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5416), "Work-life balance metrics", "Work-life balance metrics", 8L, 1 },
                    { 74L, "S1-16", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5419), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5420), "Remuneration metrics (pay gap and total remuneration)", "Remuneration metrics (pay gap and total remuneration)", 8L, 1 },
                    { 75L, "S1-17", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5424), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5425), "Incidents, complaints and severe human rights impacts", "Incidents, complaints and severe human rights impacts", 8L, 1 },
                    { 77L, "S2.SBM-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5438), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5439), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 9L, 1 },
                    { 78L, "S2-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5444), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5445), "Policies related to value chain workers", "Policies related to value chain workers", 9L, 1 },
                    { 79L, "S2-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5448), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5450), "Processes for engaging with value chain workers about impacts", "Processes for engaging with value chain workers about impacts", 9L, 1 },
                    { 80L, "S2-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5453), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5454), "Processes to remediate negative impacts and channels for value chain workers to raise concerns", "Processes to remediate negative impacts and channels for value chain workers to raise concerns", 9L, 1 },
                    { 81L, "S2-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5458), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5461), "Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", "Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", 9L, 1 },
                    { 82L, "S2-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5469), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5471), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 9L, 1 },
                    { 84L, "S3.SBM-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5476), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5477), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 10L, 1 },
                    { 85L, "S3-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5483), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5485), "Policies related to affected communities", "Policies related to affected communities", 10L, 1 },
                    { 86L, "S3-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5492), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5494), "Processes for engaging with affected communities about impacts", "Processes for engaging with affected communities about impacts", 10L, 1 },
                    { 87L, "S3-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5501), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5503), "Processes to remediate negative impacts and channels for affected communities to raise concerns", "Processes to remediate negative impacts and channels for affected communities to raise concerns", 10L, 1 },
                    { 88L, "S3-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5507), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5508), "aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", "aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", 10L, 1 },
                    { 89L, "S3-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5516), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5517), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", 10L, 1 },
                    { 91L, "S4.SBM-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5529), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5530), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 11L, 1 },
                    { 92L, "S4-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5533), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5535), "Policies related to consumers and end-users", "Policies related to consumers and end-users", 11L, 1 },
                    { 93L, "S4-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5538), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5539), "Processes for engaging with consumers and end-users about impacts", "Processes for engaging with consumers and end-users about impacts", 11L, 1 },
                    { 94L, "S4-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5543), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5544), "Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", "Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", 11L, 1 },
                    { 95L, "S4-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5547), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5549), "Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", "Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", 11L, 1 },
                    { 96L, "S4-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5554), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5555), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 11L, 1 },
                    { 97L, "G1.GOV-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5562), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5566), "The role of the administrative, supervisory and management bodies", "The role of the administrative, supervisory and management bodies", 12L, 1 },
                    { 98L, "G1-1", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5570), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5572), "Business conduct policies and corporate culture", "Business conduct policies and corporate culture", 12L, 1 },
                    { 99L, "G1-2", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5575), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5576), "Management of relationships with suppliers", "Management of relationships with suppliers", 12L, 1 },
                    { 100L, "G1-3", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5580), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5581), "Prevention and detection of corruption and bribery", "Prevention and detection of corruption and bribery", 12L, 1 },
                    { 101L, "G1-4", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5584), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5585), "Incidents of corruption or bribery", "Incidents of corruption or bribery", 12L, 1 },
                    { 102L, "G1-5", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5589), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5590), "Political influence and lobbying activities", "Political influence and lobbying activities", 12L, 1 },
                    { 103L, "G1-6", 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5594), 1L, 1L, new DateTime(2024, 11, 28, 10, 20, 51, 416, DateTimeKind.Utc).AddTicks(5595), "Payment practices", "Payment practices", 12L, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "fki_FK_Amendments_DataPointValuesId",
                table: "Amendments",
                column: "DatapointId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_Amendments_Organization_OrganizationId",
                table: "Amendments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_Amendments1-FilterCombinationId",
                table: "Amendments",
                column: "FilterCombinationId");

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
                name: "fki_FK_DataModelValues_Users_Consult",
                table: "DataModelValues",
                column: "Consult");

            migrationBuilder.CreateIndex(
                name: "fki_FK_DataModelValues_Users_Inform",
                table: "DataModelValues",
                column: "Inform");

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
                name: "idx_datamodelvalues_modelid_userid",
                table: "DataModelValues",
                columns: new[] { "DataModelId", "ResponsibleUserId" });

            migrationBuilder.CreateIndex(
                name: "idx_datamodelvalues_modelid_userid_datapoint",
                table: "DataModelValues",
                columns: new[] { "DataModelId", "ResponsibleUserId", "DataPointValuesId" });

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
                name: "fki_FK_UploadedFile_User_UserId",
                table: "UploadedFile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "fki_FK_UploadFile_DefaultDataModelValues",
                table: "UploadedFile",
                column: "DataModelValueId");

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
                name: "Amendments");

            migrationBuilder.DropTable(
                name: "AuditLogs");

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
                name: "UploadedFile");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ModelDimensionTypes");

            migrationBuilder.DropTable(
                name: "DataModelFilters");

            migrationBuilder.DropTable(
                name: "DataModelValues");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ModelConfiguration");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "ModelFilterCombinations");

            migrationBuilder.DropTable(
                name: "DataPointValue");

            migrationBuilder.DropTable(
                name: "DimensionTypes");

            migrationBuilder.DropTable(
                name: "DataModels");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DataPointType");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DisclosureRequirement");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypes");

            migrationBuilder.DropTable(
                name: "Standard");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropSequence(
                name: "amendments_id_seq");

            migrationBuilder.DropSequence(
                name: "UploadedFile_Id_seq");
        }
    }
}

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
                    { 57L, "S1.SBM-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6343), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6344), "S1.SBM-2 - Interests and views of stakeholders", "S1.SBM-2 - Interests and views of stakeholders", null, 1 },
                    { 76L, "S2.SBM-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6382), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6383), "S2.SBM-2 - Interests and views of stakeholders", "S2.SBM-2 - Interests and views of stakeholders", null, 1 },
                    { 90L, "S4.SBM-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6409), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6410), "S4.SBM-2 - Interests and views of stakeholders", "S4.SBM-2 - Interests and views of stakeholders", null, 1 }
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
                    { 1L, "general", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6834), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6835), "General", "General", 1 },
                    { 2L, "environment", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6837), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6838), "E-Environment", "E-Environment", 1 },
                    { 3L, "social", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6839), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6840), "S-Social", "S-Social", 1 },
                    { 4L, "governance", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6842), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6842), "G-Governance", "G-Governance", 1 },
                    { 17L, "general", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6844), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6844), "Algemeen", "Algemeen", 1 },
                    { 18L, "environment", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6846), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6846), "M-Milieu", "M-Milieu", 1 },
                    { 19L, "social", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6848), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6848), "S-Sociaal", "S-Sociaal", 1 },
                    { 20L, "governance", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6849), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6850), "B-Bestuur", "B-Bestuur", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "Password", "PhoneNumber", "SecurityStamp", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7086), "user1@example.com", "John", 1L, null, null, "Doe", "password1", "1234567890", new Guid("8cf25639-53c5-47e3-a88e-46061b5e7d09"), 0 },
                    { 2L, 2L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7112), "user2@example.com", "Jane", 1L, null, null, "Smith", "password2", "0987654321", new Guid("0ccb8b58-4eab-4df1-a74d-b851344394e3"), 0 },
                    { 3L, 3L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7114), "user3@example.com", "Alice", 1L, null, null, "Johnson", "password3", "2345678901", new Guid("b200386c-f12b-4edc-afd8-2993ba53c5d9"), 0 },
                    { 4L, 4L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7116), "user4@example.com", "Bob", 1L, null, null, "Brown", "password4", "3456789012", new Guid("cf2ca896-6e2c-40ee-930c-c22514c427e3"), 0 },
                    { 5L, 5L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7119), "user5@example.com", "Charlie", 1L, null, null, "Davis", "password5", "4567890123", new Guid("83ecf660-a4b5-462c-aaff-013cc77b753d"), 0 },
                    { 6L, 6L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7127), "user6@example.com", "David", 1L, null, null, "Evans", "password6", "5678901234", new Guid("70565970-31b3-4d7b-8309-bf487b49cb95"), 0 },
                    { 7L, 7L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7130), "user7@example.com", "Eve", 1L, null, null, "Foster", "password7", "6789012345", new Guid("68ebabbd-83d5-401a-951f-150076e84f54"), 0 },
                    { 8L, 8L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7132), "user8@example.com", "Frank", 1L, null, null, "Garcia", "password8", "7890123456", new Guid("bda84007-6627-4171-8de4-b4334068405d"), 0 },
                    { 9L, 9L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7134), "user9@example.com", "Grace", 1L, null, null, "Harris", "password9", "8901234567", new Guid("cdc36e00-05ab-420e-bde5-24ba6bfcf141"), 0 },
                    { 10L, 10L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7136), "user10@example.com", "Hank", 1L, null, null, "Ivy", "password10", "9012345678", new Guid("7d3565d4-104c-41e6-ae29-8ed71556e903"), 0 },
                    { 11L, 11L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7139), "user11@example.com", "Irene", 1L, null, null, "James", "password11", "0123456789", new Guid("fa3e37fc-aa51-496c-8a1b-26647ee7c990"), 0 },
                    { 12L, 12L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7141), "user12@example.com", "Jack", 1L, null, null, "Kane", "password12", "1234509876", new Guid("c2f1a610-7133-43ae-bf27-10fd1002cbf2"), 0 },
                    { 13L, 13L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7143), "user13@example.com", "Laura", 1L, null, null, "Mills", "password13", "2345610987", new Guid("5e414e60-57ec-4be0-9677-c49fb25a0605"), 0 },
                    { 14L, 14L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7147), "user14@example.com", "Mike", 1L, null, null, "Nelson", "password14", "3456721098", new Guid("eb1eae97-9fe9-4ee4-8dc3-07213554cccd"), 0 },
                    { 15L, 15L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7149), "user15@example.com", "Nina", 1L, null, null, "Owen", "password15", "4567832109", new Guid("9639054b-7256-4758-b148-1689e068fe38"), 0 },
                    { 16L, 16L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7152), "user16@example.com", "Oliver", 1L, null, null, "Perez", "password16", "5678943210", new Guid("4a1cab9b-05f2-41e5-952b-3b1d8525e3fd"), 0 },
                    { 17L, 17L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7154), "user17@example.com", "Pam", 1L, null, null, "Quinn", "password17", "6789054321", new Guid("e4fb1112-c504-44ad-b63b-0a1e5c66fea3"), 0 },
                    { 18L, 18L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7156), "user18@example.com", "Quinn", 1L, null, null, "Reed", "password18", "7890165432", new Guid("c0dbbaeb-cb1a-49e1-ba68-76a1cb46f433"), 0 },
                    { 101L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7080), "user101@example.com", "John", 1L, null, null, "Doe", "password101", "1234567890", new Guid("0f0a2f58-915e-483a-bfd4-284bb0865f56"), 0 },
                    { 102L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7083), "user102@example.com", "John", 1L, null, null, "Doe", "password102", "1234567890", new Guid("a4e718e6-34b0-4737-98e2-b4e51584ee43"), 0 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "yyyy", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5795), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5798), "Year", 1L, "Year", 1 },
                    { 2L, "m", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5804), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5804), "Month", 1L, "Month", 1 },
                    { 3L, "q", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5806), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5807), "Quarter", 1L, "Quarter", 1 },
                    { 4L, "d", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5835), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5836), "Day", 1L, "Day", 1 },
                    { 5L, "vatyp", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5838), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5839), "Value Type", 1L, "Value Type", 1 },
                    { 6L, "cntry", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5841), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5841), "Country", 1L, "Country", 1 },
                    { 7L, "city", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5843), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5844), "City", 1L, "City", 1 },
                    { 8L, "rgn", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5847), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5847), "Region", 1L, "Region", 1 },
                    { 9L, "sdg", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5849), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5850), "Sustainable Development", 1L, "SDG", 1 },
                    { 10L, "liro", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5851), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5852), "Line Of Reporting", 1L, "Line Of Reporting", 1 },
                    { 11L, "domn", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5854), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5855), "Domain", 1L, "Domain", 1 },
                    { 12L, "bsnss", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5856), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5857), "Business", 1L, "Business", 1 },
                    { 13L, "mrkt", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5859), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5859), "Market", 1L, "Market", 1 },
                    { 14L, "factory", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5861), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5862), "Factory", 1L, "Factory", 1 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6633), null, null, 1L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6634), null, null, 1L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6636), null, null, 1L, 0, 3L },
                    { 4L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6638), null, null, 2L, 0, 4L },
                    { 5L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6639), null, null, 2L, 0, 5L },
                    { 6L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6640), null, null, 2L, 0, 6L },
                    { 7L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6641), null, null, 3L, 0, 7L },
                    { 8L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6642), null, null, 3L, 0, 8L },
                    { 9L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6643), null, null, 3L, 0, 9L },
                    { 10L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6644), null, null, 4L, 0, 10L },
                    { 11L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6645), null, null, 4L, 0, 11L },
                    { 12L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6646), null, null, 4L, 0, 12L },
                    { 13L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6647), null, null, 5L, 0, 13L },
                    { 14L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6648), null, null, 5L, 0, 14L },
                    { 15L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6648), null, null, 5L, 0, 15L },
                    { 16L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6649), null, null, 6L, 0, 16L },
                    { 17L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6650), null, null, 6L, 0, 17L },
                    { 18L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6651), null, null, 6L, 0, 18L },
                    { 19L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6637), null, null, 1L, 0, 101L },
                    { 20L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6638), null, null, 1L, 0, 102L }
                });

            migrationBuilder.InsertData(
                table: "Standard",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State", "TopicId" },
                values: new object[,]
                {
                    { 1L, "ESRS2_GP", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6704), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6704), "ESRS2_GP - General principles", "ESRS2_GP - General principles", 1, 1L },
                    { 2L, "ESRS2_MDR", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6707), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6708), "ESRS2_MDR - General disclosures", "ESRS2_MDR - General disclosures", 1, 1L },
                    { 3L, "E1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6709), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6710), "E1 - Climate change", "E1 - Climate change", 1, 2L },
                    { 4L, "E2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6712), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6712), "E2 - Pollution", "E2 - Pollution", 1, 2L },
                    { 5L, "E3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6714), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6714), "E3 - Water and marine resources", "E3 - Water and marine resources", 1, 2L },
                    { 6L, "E4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6716), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6717), "E4 - Biodiversity and ecosystems", "E4 - Biodiversity and ecosystems", 1, 2L },
                    { 7L, "E5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6718), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6719), "E5 - Resource use and circular economy", "E5 - Resource use and circular economy", 1, 2L },
                    { 8L, "S1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6720), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6721), "S1 - Own workforce", "S1 - Own workforce", 1, 3L },
                    { 9L, "S2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6722), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6723), "S2 - Workers in the value chain", "S2 - Workers in the value chain", 1, 3L },
                    { 10L, "S3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6724), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6725), "S3 - Affected communities", "S3 - Affected communities", 1, 3L },
                    { 11L, "S4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6726), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6727), "S4 - Consumers and end-users", "S4 - Consumers and end-users", 1, 3L },
                    { 12L, "G1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6728), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6729), "G1 - Governance, risk, and internal control", "G1 - Governance, risk, and internal control", 1, 4L },
                    { 13L, "ESRS2_GP", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6730), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6731), "ESRS2_GP - Principes généraux", "ESRS2_GP - Principes généraux", 1, 1L },
                    { 14L, "ESRS2_MDR", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6732), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6733), "ESRS2_MDR - Informations générales", "ESRS2_MDR - Informations générales", 1, 1L },
                    { 15L, "E1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6770), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6771), "E1 - Changement climatique", "E1 - Changement climatique", 1, 2L },
                    { 16L, "E2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6773), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6773), "E2 - Pollution", "E2 - Pollution", 1, 2L },
                    { 17L, "E3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6775), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6775), "E3 - Ressources marines et aquatiques", "E3 - Ressources marines et aquatiques", 1, 2L },
                    { 18L, "E4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6777), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6777), "E4 - Biodiversité et écosystèmes", "E4 - Biodiversité et écosystèmes", 1, 2L },
                    { 19L, "E5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6779), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6779), "E5 - Utilisation des ressources et économie circulaire", "E5 - Utilisation des ressources et économie circulaire", 1, 2L },
                    { 20L, "S1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6781), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6781), "S1 - Main-d'œuvre propre", "S1 - Main-d'œuvre propre", 1, 3L },
                    { 21L, "S2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6783), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6783), "S2 - Travailleurs de la chaîne de valeur", "S2 - Travailleurs de la chaîne de valeur", 1, 3L },
                    { 22L, "S3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6785), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6785), "S3 - Communautés affectées", "S3 - Communautés affectées", 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "acidbasecapacity", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6874), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6875), "Acid/Base capacity", 1L, "Acid/Base capacity", 1 },
                    { 2L, "area", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6877), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6878), "Area", 1L, "Area", 1 },
                    { 3L, "density", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6880), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6880), "Density", 1L, "Density", 1 },
                    { 4L, "energy", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6882), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6882), "Energy", 1L, "Energy", 1 },
                    { 5L, "force", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6884), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6885), "Force", 1L, "Force", 1 },
                    { 6L, "frequency", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6887), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6887), "Frequency", 1L, "Frequency", 1 },
                    { 7L, "heat_conductivity", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6889), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6889), "Heat Conductivity", 1L, "Heat Conductivity", 1 },
                    { 8L, "hydrolysis_rate", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6891), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6891), "Hydrolysis rate", 1L, "Hydrolysis rate", 1 },
                    { 9L, "inverse_area", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6893), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6893), "Inverse area", 1L, "Inverse area", 1 },
                    { 10L, "kinematic_viscosity", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6895), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6895), "Kinematic viscosity", 1L, "Kinematic viscosity", 1 },
                    { 11L, "length", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6897), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6897), "Length", 1L, "Length", 1 },
                    { 12L, "luminous_intensity", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6899), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6899), "Luminous intensity", 1L, "Luminous intensity", 1 },
                    { 13L, "magnet_field_dens", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6901), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6901), "Magnet. field dens.", 1L, "Magnet. field dens.", 1 },
                    { 14L, "mass", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6903), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6903), "Mass", 1L, "Mass", 1 },
                    { 15L, "mass_coverage", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6905), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6905), "Mass coverage", 1L, "Mass coverage", 1 },
                    { 16L, "mass_flow", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6907), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6907), "Mass flow", 1L, "Mass flow", 1 },
                    { 17L, "mass_per_energy", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6909), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6910), "Mass per Energy", 1L, "Mass per Energy", 1 },
                    { 18L, "mass_proportion", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6933), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6934), "Mass proportion", 1L, "Mass proportion", 1 },
                    { 19L, "proportion", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6935), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6936), "Proportion", 1L, "Proportion", 1 },
                    { 20L, "time", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6937), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6938), "Time", 1L, "Time", 1 },
                    { 21L, "vaporization_speed", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6939), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6940), "Vaporization Speed", 1L, "Vaporization Speed", 1 },
                    { 22L, "volume", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6941), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6942), "Volume", 1L, "Volume", 1 },
                    { 23L, "volume_proportion", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6943), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6944), "Volume proportion", 1L, "Volume proportion", 1 },
                    { 24L, "volume_rate_of_flow", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6945), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6946), "Volume rate of flow", 1L, "Volume rate of flow", 1 },
                    { 121L, "monetary", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6947), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6948), "Monetary", 1L, "Monetary", 1 },
                    { 126L, "narrative", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6949), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6950), "Text", 1L, "Text", 1 },
                    { 131L, "number", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6951), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6952), "Number", 1L, "Number", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7000), null, null, 2L, 0, 1L },
                    { 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7001), null, null, 3L, 0, 2L },
                    { 3L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7002), null, null, 3L, 0, 3L },
                    { 4L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7003), null, null, 2L, 0, 4L },
                    { 5L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7004), null, null, 3L, 0, 5L },
                    { 6L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7005), null, null, 3L, 0, 6L },
                    { 7L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7006), null, null, 2L, 0, 7L },
                    { 8L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7007), null, null, 3L, 0, 8L },
                    { 9L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7008), null, null, 3L, 0, 9L },
                    { 10L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7009), null, null, 2L, 0, 10L },
                    { 11L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7010), null, null, 3L, 0, 11L },
                    { 12L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7011), null, null, 3L, 0, 12L },
                    { 13L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7012), null, null, 2L, 0, 13L },
                    { 14L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7013), null, null, 3L, 0, 14L },
                    { 15L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7014), null, null, 3L, 0, 15L },
                    { 16L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7015), null, null, 2L, 0, 16L },
                    { 17L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7016), null, null, 3L, 0, 17L },
                    { 18L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7017), null, null, 3L, 0, 18L },
                    { 19L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7018), null, null, 1L, 0, 101L },
                    { 20L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(7019), null, null, 1L, 0, 102L }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypeTranslations",
                columns: new[] { "DimensionTypeId", "LanguageId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5891), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5892), "Jaar", "Jaar", 1 },
                    { 2L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5894), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5895), "Maand", "Maand", 1 },
                    { 3L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5896), 3L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5897), "Kwartaal", "Kwartaal", 1 },
                    { 4L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5898), 4L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5899), "Dag", "Dag", 1 },
                    { 5L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5901), 5L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5901), "Waardetype", "Waardetype", 1 },
                    { 6L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5902), 6L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5903), "Land", "Land", 1 },
                    { 7L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5904), 7L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5905), "Stad", "Stad", 1 },
                    { 8L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5906), 8L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5907), "Regio", "Regio", 1 },
                    { 9L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5908), 9L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5909), "Duurzame Ontwikkeling", "SDG", 1 },
                    { 10L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5910), 10L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5911), "Rapporteringslijn", "Rapporteringslijn", 1 },
                    { 11L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5912), 11L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5913), "Domein", "Domein", 1 },
                    { 12L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5914), 12L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5915), "Bedrijf", "Bedrijf", 1 },
                    { 13L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5916), 13L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5917), "Markt", "Markt", 1 },
                    { 14L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5918), 14L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5919), "Fabriek", "Fabriek", 1 }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DimensionTypeId", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1000L, "act", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5975), 5L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5976), "Actual", 1L, "Actual", 1 },
                    { 1001L, "base", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5979), 5L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5980), "Baseline", 1L, "Baseline", 1 },
                    { 1002L, "target", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5982), 5L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5982), "Target", 1L, "Target", 1 },
                    { 1003L, "de", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5985), 6L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5985), "Germany", 1L, "DE", 1 },
                    { 1004L, "nl", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5987), 6L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5988), "The Netherlands", 1L, "NL", 1 },
                    { 1005L, "dap", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5990), 12L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5990), "Domestic Appliances", 1L, "DAP", 1 },
                    { 1006L, "pms", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5993), 12L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5993), "Medical systems", 1L, "PMS", 1 },
                    { 1007L, "eur", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5995), 13L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5996), "Europe", 1L, "EUR", 1 },
                    { 1008L, "ame", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5998), 13L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(5998), "Africa, Middle East", 1L, "AME", 1 },
                    { 1009L, "tern", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6000), 14L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6001), "Terneuzen", 1L, "Terneuzen", 1 },
                    { 1010L, "2023", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6003), 1L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6003), "2023", 1L, "2023", 1 },
                    { 1011L, "2024", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6005), 1L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6005), "2024", 1L, "2024", 1 },
                    { 1012L, "2025", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6007), 1L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6008), "2025", 1L, "2025", 1 },
                    { 1013L, "Jan", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6010), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6010), "January", 1L, "January", 1 },
                    { 1014L, "Feb", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6012), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6013), "February", 1L, "February", 1 },
                    { 1015L, "Mar", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6015), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6015), "March", 1L, "March", 1 },
                    { 1016L, "Apr", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6019), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6020), "April", 1L, "April", 1 },
                    { 1017L, "May", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6023), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6023), "May", 1L, "May", 1 },
                    { 1018L, "Jun", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6025), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6026), "June", 1L, "June", 1 },
                    { 1019L, "Jul", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6028), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6028), "July", 1L, "July", 1 },
                    { 1020L, "Aug", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6030), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6031), "August", 1L, "August", 1 },
                    { 1021L, "Sep", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6054), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6054), "September", 1L, "September", 1 },
                    { 1022L, "Oct", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6056), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6057), "October", 1L, "October", 1 },
                    { 1023L, "Nov", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6059), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6059), "November", 1L, "November", 1 },
                    { 1024L, "Dec", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6061), 2L, 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6062), "December", 1L, "December", 1 }
                });

            migrationBuilder.InsertData(
                table: "DisclosureRequirement",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "StandardId", "State" },
                values: new object[,]
                {
                    { 1L, "BP-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6183), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6184), "BP-1 - General basis for preparation of sustainability statements", "BP-1 - General basis for preparation of sustainability statements", 1L, 1 },
                    { 2L, "BP-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6186), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6186), "BP-2 - Disclosures in relation to specific circumstances", "BP-2 - Disclosures in relation to specific circumstances", 1L, 1 },
                    { 3L, "GOV-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6188), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6189), "GOV-1 - The role of the administrative, management and supervisory bodies", "GOV-1 - The role of the administrative, management and supervisory bodies", 1L, 1 },
                    { 4L, "GOV-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6191), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6191), "GOV-2 - Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", "GOV-2 - Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", 1L, 1 },
                    { 5L, "GOV-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6193), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6193), "GOV-3 - Integration of sustainability-related performance in incentive schemes", "GOV-3 - Integration of sustainability-related performance in incentive schemes", 1L, 1 },
                    { 6L, "GOV-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6217), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6218), "GOV-4 - Statement on due diligence", "GOV-4 - Statement on due diligence", 1L, 1 },
                    { 7L, "GOV-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6220), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6220), "GOV-5 - Risk management and internal controls over sustainability reporting", "GOV-5 - Risk management and internal controls over sustainability reporting", 1L, 1 },
                    { 8L, "SBM-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6222), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6223), "SBM-1 - Strategy, business model and value chain", "SBM-1 - Strategy, business model and value chain", 1L, 1 },
                    { 9L, "SBM-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6224), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6225), "SBM-2 - Interests and views of stakeholders", "SBM-2 - Interests and views of stakeholders", 1L, 1 },
                    { 10L, "SBM-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6227), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6227), "SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", "SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", 1L, 1 },
                    { 11L, "IRO-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6229), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6231), "IRO-1 - Description of the process to identify and assess material impacts, risks and opportunities", "IRO-1 - Description of the process to identify and assess material impacts, risks and opportunities", 1L, 1 },
                    { 12L, "IRO-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6232), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6233), "IRO-2 - Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", "IRO-2 - Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", 1L, 1 },
                    { 13L, "MDR-P", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6234), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6235), "MDR-P - Policies adopted to manage material sustainability matters", "MDR-P - Policies adopted to manage material sustainability matters", 2L, 1 },
                    { 14L, "MDR-A", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6237), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6237), "MDR-A - Actions and resources in relation to material sustainability matters", "MDR-A - Actions and resources in relation to material sustainability matters", 2L, 1 },
                    { 15L, "MDR-M", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6239), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6240), "MDR-M - Metrics in relation to material sustainability matters", "MDR-M - Metrics in relation to material sustainability matters", 2L, 1 },
                    { 16L, "MDR-T", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6241), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6242), "MDR-T - Tracking effectiveness of policies and actions through targets", "MDR-T - Tracking effectiveness of policies and actions through targets", 2L, 1 },
                    { 17L, "E1.GOV-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6244), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6244), "E1.GOV-3 - Integration of sustainability-related performance in incentive schemes", "E1.GOV-3 - Integration of sustainability-related performance in incentive schemes", 3L, 1 },
                    { 18L, "E1-1 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6246), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6246), "E1-1  - Transition plan for climate change mitigation", "E1-1  - Transition plan for climate change mitigation", 3L, 1 },
                    { 19L, "E1.SBM-3 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6248), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6249), "E1.SBM-3  - Material impacts, risks and opportunities and their interaction with strategy and business model", "E1.SBM-3  - Material impacts, risks and opportunities and their interaction with strategy and business model", 3L, 1 },
                    { 20L, "E1.IRO-1 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6250), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6251), "E1.IRO-1  - Description of the processes to identify and assess material climate-related impacts, risks and opportunities", "E1.IRO-1  - Description of the processes to identify and assess material climate-related impacts, risks and opportunities", 3L, 1 },
                    { 21L, "E1-2 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6252), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6253), "E1-2  - Policies related to climate change mitigation and adaptation", "E1-2  - Policies related to climate change mitigation and adaptation", 3L, 1 },
                    { 22L, "E1-3 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6254), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6255), "E1-3  - Actions and resources in relation to climate change policies", "E1-3  - Actions and resources in relation to climate change policies", 3L, 1 },
                    { 23L, "E1-4 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6256), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6257), "E1-4  - Targets related to climate change mitigation and adaptation", "E1-4  - Targets related to climate change mitigation and adaptation", 3L, 1 },
                    { 24L, "E1-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6259), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6259), "E1-5 - Energy consumption and mix", "E1-5 - Energy consumption and mix", 3L, 1 },
                    { 25L, "E1-6", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6261), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6261), "E1-6 - Gross Scopes 1, 2, 3 and Total GHG emissions", "E1-6 - Gross Scopes 1, 2, 3 and Total GHG emissions", 3L, 1 },
                    { 26L, "E1-7 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6263), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6264), "E1-7  - GHG removals and GHG mitigation projects financed through carbon credits", "E1-7  - GHG removals and GHG mitigation projects financed through carbon credits", 3L, 1 },
                    { 27L, "E1-8 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6265), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6266), "E1-8  - Internal carbon pricing", "E1-8  - Internal carbon pricing", 3L, 1 },
                    { 28L, "E1-9 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6267), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6268), "E1-9  - Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", "E1-9  - Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", 3L, 1 },
                    { 29L, "E2.IRO-1 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6269), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6270), "E2.IRO-1  - Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", "E2.IRO-1  - Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 30L, "E2-1 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6271), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6272), "E2-1  - Policies related to pollution", "E2-1  - Policies related to pollution", 4L, 1 },
                    { 31L, "E2-2 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6274), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6274), "E2-2  - Actions and resources related to pollution", "E2-2  - Actions and resources related to pollution", 4L, 1 },
                    { 32L, "E2-3 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6276), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6276), "E2-3  - Targets related to pollution", "E2-3  - Targets related to pollution", 4L, 1 },
                    { 33L, "E2-4 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6278), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6278), "E2-4  - Pollution of air, water and soil", "E2-4  - Pollution of air, water and soil", 4L, 1 },
                    { 34L, "E2-5 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6280), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6280), "E2-5  - Substances of concern and substances of very high concern", "E2-5  - Substances of concern and substances of very high concern", 4L, 1 },
                    { 35L, "E2-6 ", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6282), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6282), "E2-6  - Anticipated financial effects from pollution-related impacts, risks and opportunities", "E2-6  - Anticipated financial effects from pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 36L, "E3.IRO-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6284), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6285), "E3.IRO-1 - Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", "E3.IRO-1 - Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 37L, "E3-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6286), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6287), "E3-1 - Policies related to water and marine resources", "E3-1 - Policies related to water and marine resources", 5L, 1 },
                    { 38L, "E3-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6288), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6289), "E3-2 - Actions and resources related to water and marine resources", "E3-2 - Actions and resources related to water and marine resources", 5L, 1 },
                    { 39L, "E3-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6290), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6291), "E3-3 - Targets related to water and marine resources", "E3-3 - Targets related to water and marine resources", 5L, 1 },
                    { 40L, "E3-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6292), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6293), "E3-4 - Water consumption", "E3-4 - Water consumption", 5L, 1 },
                    { 41L, "E3-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6294), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6295), "E3-5 - Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", "E3-5 - Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 42L, "E4.SBM-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6296), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6297), "E4.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", "E4.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", 6L, 1 },
                    { 43L, "E4.IRO-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6298), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6299), "E4.IRO-1 - Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", "E4.IRO-1 - Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", 6L, 1 },
                    { 44L, "E4-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6300), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6301), "E4-1 - Transition plan and consideration of biodiversity and ecosystems in strategy and business model", "E4-1 - Transition plan and consideration of biodiversity and ecosystems in strategy and business model", 6L, 1 },
                    { 45L, "E4-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6302), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6303), "E4-2 - Policies related to biodiversity and ecosystems", "E4-2 - Policies related to biodiversity and ecosystems", 6L, 1 },
                    { 46L, "E4-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6304), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6305), "E4-3 - Actions and resources related to biodiversity and ecosystems", "E4-3 - Actions and resources related to biodiversity and ecosystems", 6L, 1 },
                    { 47L, "E4-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6306), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6307), "E4-4 - Targets related to biodiversity and ecosystems", "E4-4 - Targets related to biodiversity and ecosystems", 6L, 1 },
                    { 48L, "E4-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6308), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6309), "E4-5 - Impact metrics related to biodiversity and ecosystems change", "E4-5 - Impact metrics related to biodiversity and ecosystems change", 6L, 1 },
                    { 49L, "E4-6", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6311), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6312), "E4-6 - Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", "E4-6 - Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", 6L, 1 },
                    { 50L, "E5.IRO-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6327), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6328), "E5.IRO-1 - Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", "E5.IRO-1 - Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 51L, "E5-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6329), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6330), "E5-1 - Policies related to resource use and circular economy", "E5-1 - Policies related to resource use and circular economy", 7L, 1 },
                    { 52L, "E5-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6332), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6332), "E5-2 - Actions and resources related to resource use and circular economy", "E5-2 - Actions and resources related to resource use and circular economy", 7L, 1 },
                    { 53L, "E5-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6334), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6334), "E5-3 - Targets related to resource use and circular economy", "E5-3 - Targets related to resource use and circular economy", 7L, 1 },
                    { 54L, "E5-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6336), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6336), "E5-4 - Resource inflows", "E5-4 - Resource inflows", 7L, 1 },
                    { 55L, "E5-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6338), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6338), "E5-5 - Resource outflows", "E5-5 - Resource outflows", 7L, 1 },
                    { 56L, "E5-6", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6340), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6340), "E5-6 - Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", "E5-6 - Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 58L, "S1.SBM-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6345), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6346), "S1.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", "S1.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", 8L, 1 },
                    { 59L, "S1-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6347), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6348), "S1-1 - Policies related to own workforce", "S1-1 - Policies related to own workforce", 8L, 1 },
                    { 60L, "S1-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6349), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6350), "S1-2 - Processes for engaging with own workforce and workers’ representatives about impacts", "S1-2 - Processes for engaging with own workforce and workers’ representatives about impacts", 8L, 1 },
                    { 61L, "S1-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6352), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6352), "S1-3 - Processes to remediate negative impacts and channels for own workforce to raise concerns", "S1-3 - Processes to remediate negative impacts and channels for own workforce to raise concerns", 8L, 1 },
                    { 62L, "S1-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6354), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6354), "S1-4 - Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", "S1-4 - Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", 8L, 1 },
                    { 63L, "S1-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6356), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6356), "S1-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "S1-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 8L, 1 },
                    { 64L, "S1-6", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6358), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6358), "S1-6 - Characteristics of the undertaking’s employees", "S1-6 - Characteristics of the undertaking’s employees", 8L, 1 },
                    { 65L, "S1-7", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6360), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6360), "S1-7 - Characteristics of non-employees in the undertaking’s own workforce", "S1-7 - Characteristics of non-employees in the undertaking’s own workforce", 8L, 1 },
                    { 66L, "S1-8", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6362), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6362), "S1-8 - Collective bargaining coverage and social dialogue", "S1-8 - Collective bargaining coverage and social dialogue", 8L, 1 },
                    { 67L, "S1-9", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6364), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6364), "S1-9 - Diversity metrics", "S1-9 - Diversity metrics", 8L, 1 },
                    { 68L, "S1-10", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6366), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6366), "S1-10 - Adequate wages", "S1-10 - Adequate wages", 8L, 1 },
                    { 69L, "S1-11", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6368), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6368), "S1-11 - Social protection", "S1-11 - Social protection", 8L, 1 },
                    { 70L, "S1-12", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6370), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6370), "S1-12 - Persons with disabilities", "S1-12 - Persons with disabilities", 8L, 1 },
                    { 71L, "S1-13", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6372), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6372), "S1-13 - Training and skills development metrics", "S1-13 - Training and skills development metrics", 8L, 1 },
                    { 72L, "S1-14", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6374), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6374), "S1-14 - Health and safety metrics", "S1-14 - Health and safety metrics", 8L, 1 },
                    { 73L, "S1-15", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6376), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6376), "S1-15 - Work-life balance metrics", "S1-15 - Work-life balance metrics", 8L, 1 },
                    { 74L, "S1-16", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6378), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6378), "S1-16 - Remuneration metrics (pay gap and total remuneration)", "S1-16 - Remuneration metrics (pay gap and total remuneration)", 8L, 1 },
                    { 75L, "S1-17", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6380), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6380), "S1-17 - Incidents, complaints and severe human rights impacts", "S1-17 - Incidents, complaints and severe human rights impacts", 8L, 1 },
                    { 77L, "S2.SBM-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6384), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6385), "S2.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", "S2.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", 9L, 1 },
                    { 78L, "S2-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6386), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6387), "S2-1 - Policies related to value chain workers", "S2-1 - Policies related to value chain workers", 9L, 1 },
                    { 79L, "S2-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6388), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6389), "S2-2 - Processes for engaging with value chain workers about impacts", "S2-2 - Processes for engaging with value chain workers about impacts", 9L, 1 },
                    { 80L, "S2-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6391), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6391), "S2-3 - Processes to remediate negative impacts and channels for value chain workers to raise concerns", "S2-3 - Processes to remediate negative impacts and channels for value chain workers to raise concerns", 9L, 1 },
                    { 81L, "S2-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6393), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6393), "S2-4 - Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", "S2-4 - Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", 9L, 1 },
                    { 82L, "S2-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6395), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6395), "S2-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "S2-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 9L, 1 },
                    { 84L, "S3.SBM-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6397), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6397), "S3.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", "S3.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", 10L, 1 },
                    { 85L, "S3-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6399), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6399), "S3-1 - Policies related to affected communities", "S3-1 - Policies related to affected communities", 10L, 1 },
                    { 86L, "S3-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6401), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6401), "S3-2 - Processes for engaging with affected communities about impacts", "S3-2 - Processes for engaging with affected communities about impacts", 10L, 1 },
                    { 87L, "S3-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6403), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6404), "S3-3 - Processes to remediate negative impacts and channels for affected communities to raise concerns", "S3-3 - Processes to remediate negative impacts and channels for affected communities to raise concerns", 10L, 1 },
                    { 88L, "S3-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6405), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6406), "S3-4 - aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", "S3-4 - aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", 10L, 1 },
                    { 89L, "S3-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6407), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6408), "S3-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", "S3-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", 10L, 1 },
                    { 91L, "S4.SBM-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6411), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6412), "S4.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", "S4.SBM-3 - Material impacts, risks and opportunities and their interaction with strategy and business model", 11L, 1 },
                    { 92L, "S4-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6413), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6414), "S4-1 - Policies related to consumers and end-users", "S4-1 - Policies related to consumers and end-users", 11L, 1 },
                    { 93L, "S4-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6415), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6416), "S4-2 - Processes for engaging with consumers and end-users about impacts", "S4-2 - Processes for engaging with consumers and end-users about impacts", 11L, 1 },
                    { 94L, "S4-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6449), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6450), "S4-3 - Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", "S4-3 - Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", 11L, 1 },
                    { 95L, "S4-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6451), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6452), "S4-4 - Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", "S4-4 - Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", 11L, 1 },
                    { 96L, "S4-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6453), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6454), "S4-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "S4-5 - Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 11L, 1 },
                    { 97L, "G1.GOV-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6456), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6456), "G1.GOV-1 - The role of the administrative, supervisory and management bodies", "G1.GOV-1 - The role of the administrative, supervisory and management bodies", 12L, 1 },
                    { 98L, "G1-1", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6458), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6458), "G1-1 - Business conduct policies and corporate culture", "G1-1 - Business conduct policies and corporate culture", 12L, 1 },
                    { 99L, "G1-2", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6460), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6461), "G1-2 - Management of relationships with suppliers", "G1-2 - Management of relationships with suppliers", 12L, 1 },
                    { 100L, "G1-3", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6462), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6463), "G1-3 - Prevention and detection of corruption and bribery", "G1-3 - Prevention and detection of corruption and bribery", 12L, 1 },
                    { 101L, "G1-4", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6464), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6465), "G1-4 - Incidents of corruption or bribery", "G1-4 - Incidents of corruption or bribery", 12L, 1 },
                    { 102L, "G1-5", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6466), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6467), "G1-5 - Political influence and lobbying activities", "G1-5 - Political influence and lobbying activities", 12L, 1 },
                    { 103L, "G1-6", 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6469), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6469), "G1-6 - Payment practices", "G1-6 - Payment practices", 12L, 1 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTranslations",
                columns: new[] { "DimensionsId", "LanguageId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State" },
                values: new object[,]
                {
                    { 1000L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6093), 1L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6094), "Aktuell", "Aktuell", 1 },
                    { 1001L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6096), 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6097), "Basislinie", "Basislinie", 1 },
                    { 1002L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6098), 3L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6099), "Ziel", "Ziel", 1 },
                    { 1003L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6100), 4L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6101), "Deutschland", "DE", 1 },
                    { 1004L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6102), 5L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6103), "Niederlande", "NL", 1 },
                    { 1005L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6104), 6L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6105), "Haushaltsgeräte", "DAP", 1 },
                    { 1006L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6106), 7L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6107), "Medizinische Systeme", "PMS", 1 },
                    { 1007L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6108), 8L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6109), "Europa", "EUR", 1 },
                    { 1008L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6110), 9L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6111), "Afrika, Naher Osten", "AME", 1 },
                    { 1009L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6113), 10L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6113), "Terneuzen", "Terneuzen", 1 },
                    { 1010L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6115), 11L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6115), "2023", "2023", 1 },
                    { 1011L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6117), 12L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6117), "2024", "2024", 1 },
                    { 1012L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6119), 13L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6119), "2025", "2025", 1 },
                    { 1013L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6121), 14L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6121), "Januar", "Januar", 1 },
                    { 1014L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6123), 15L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6123), "Februar", "Februar", 1 },
                    { 1015L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6124), 16L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6125), "März", "März", 1 },
                    { 1016L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6126), 17L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6127), "April", "April", 1 },
                    { 1017L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6128), 18L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6129), "Mai", "Mai", 1 },
                    { 1018L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6130), 19L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6130), "Juni", "Juni", 1 },
                    { 1019L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6132), 20L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6132), "Juli", "Juli", 1 },
                    { 1020L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6134), 21L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6134), "August", "August", 1 },
                    { 1021L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6135), 22L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6136), "September", "September", 1 },
                    { 1022L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6137), 23L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6138), "Oktober", "Oktober", 1 },
                    { 1023L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6139), 24L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6139), "November", "November", 1 },
                    { 1024L, 2L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6141), 25L, 1L, new DateTime(2024, 11, 29, 9, 51, 37, 666, DateTimeKind.Utc).AddTicks(6141), "Dezember", "Dezember", 1 }
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

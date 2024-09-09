using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialseeding : Migration
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
                name: "DataModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "text", nullable: true),
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
                        name: "FK_ModelFilterCombinations_DataModels_DataModelId",
                        column: x => x.DataModelId,
                        principalTable: "DataModels",
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
                    Code = table.Column<string>(type: "text", nullable: false),
                    ShortText = table.Column<string>(type: "text", nullable: true),
                    LongText = table.Column<string>(type: "text", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    IsType = table.Column<bool>(type: "boolean", nullable: false),
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
                    DimensionTypeId = table.Column<long>(type: "bigint", nullable: true),
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
                        name: "FK_ModelConfiguration_DimensionTypes_DimensionTypeId",
                        column: x => x.DimensionTypeId,
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
                        name: "FK_ModelDimensionTypes_DimensionTypes_DimensionTypeId",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ModelDimensionValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataModelId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_ModelDimensionValues_DataModels_DataModelId",
                        column: x => x.DataModelId,
                        principalTable: "DataModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelDimensionValues_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelFilterCombinationalValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelFilterCombinationsId = table.Column<long>(type: "bigint", nullable: false),
                    ModelFilterId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionsId = table.Column<long>(type: "bigint", nullable: false),
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
                        name: "FK_ModelFilterCombinationalValues_DimensionTypes_DimensionType~",
                        column: x => x.DimensionTypeId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModelFilterCombinationalValues_DimensionTypes_ModelFilterId",
                        column: x => x.ModelFilterId,
                        principalTable: "DimensionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelFilterCombinationalValues_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelFilterCombinationalValues_ModelFilterCombinations_Mode~",
                        column: x => x.ModelFilterCombinationsId,
                        principalTable: "ModelFilterCombinations",
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
                        name: "FK_DataModelFilters_ModelConfiguration_ModelConfigurationId",
                        column: x => x.ModelConfigurationId,
                        principalTable: "ModelConfiguration",
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
                name: "DataModelValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RowId = table.Column<long>(type: "bigint", nullable: false),
                    ColumnId = table.Column<long>(type: "bigint", nullable: false),
                    CombinationId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataModelValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataModelValues_Dimensions_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataModelValues_Dimensions_RowId",
                        column: x => x.RowId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataModelValues_ModelFilterCombinationalValues_CombinationId",
                        column: x => x.CombinationId,
                        principalTable: "ModelFilterCombinationalValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPointValues",
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataPointValues_DisclosureRequirement_DisclosureRequirement~",
                        column: x => x.DisclosureRequirementId,
                        principalTable: "DisclosureRequirement",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_DataPointValues_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
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
                        name: "FK_Hierarchy_DataPointValues_DataPointValuesId",
                        column: x => x.DataPointValuesId,
                        principalTable: "DataPointValues",
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
                        name: "FK_ModelDatapoints_DataPointValues_DatapointValuesId",
                        column: x => x.DatapointValuesId,
                        principalTable: "DataPointValues",
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
                values: new object[] { 1L, "ESG Global" });

            migrationBuilder.InsertData(
                table: "DisclosureRequirement",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "StandardId", "State" },
                values: new object[,]
                {
                    { 57L, "S1.SBM-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6859), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6860), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 },
                    { 76L, "S2.SBM-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6906), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6907), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 },
                    { 90L, "S4.SBM-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6935), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6935), "Interests and views of stakeholders", "Interests and views of stakeholders", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Country", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LatsName", "LogoUrl", "Name", "PostalCode", "RegistrationId", "State", "StreetAddress", "StreetNumber", "TenantId" },
                values: new object[] { 1L, "USA", 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@org1.com", "John", 1L, null, null, "Doe", null, "ESG Global", "12345", "REG-001", 1, "123 Main St", "456", 1L });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "general", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7169), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7170), "General", "General", 1 },
                    { 2L, "environment", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7172), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7172), "Environment", "Environment", 1 },
                    { 3L, "social", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7174), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7174), "Social", "Social", 1 },
                    { 4L, "governance", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7176), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7176), "Governance", "Governance", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LastName", "OrganizationUserId", "Password", "PhoneNumber", "SecurityStamp", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8291), "user1@example.com", "John", 1L, null, null, "Doe", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 49 }, "1234567890", new Guid("6ad64914-75cd-4bd2-bb9a-7367673ea596"), 1 },
                    { 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8294), "user2@example.com", "Jane", 1L, null, null, "Smith", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 50 }, "0987654321", new Guid("97dbd799-66b9-4017-8dba-00e50f4078fc"), 1 },
                    { 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8297), "user3@example.com", "Alice", 1L, null, null, "Johnson", null, new byte[] { 112, 97, 115, 115, 119, 111, 114, 100, 51 }, "2345678901", new Guid("4c6d5afc-85de-4072-ae13-ec258d716822"), 1 }
                });

            migrationBuilder.InsertData(
                table: "DataModels",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "ModelName", "OrganizationId", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8317), 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8318), "model 1", 1L, 1 },
                    { 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8319), 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8320), "model 2", 1L, 1 },
                    { 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8321), 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8321), "model 3", 1L, 1 },
                    { 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8323), 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8323), "model 4", 1L, 1 },
                    { 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8324), 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8325), "model 5", 1L, 1 },
                    { 6L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8326), 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8327), "model 6", 1L, 1 }
                });

            migrationBuilder.InsertData(
                table: "DataPointTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "table", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3380), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3383), "Table", "Table", 1L, "Table", 1 },
                    { 2L, "narrative", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3388), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3389), "Narrative", "Narrative", 1L, "Narrative", 1 },
                    { 3L, "monetary", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3391), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3392), "Monetary", "Monetary", 1L, "Monetary", 1 },
                    { 4L, "quantity", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3394), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3394), "Quantity", "Quantity", 1L, "Quantity", 1 },
                    { 5L, "time", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3396), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3397), "Time", "Time", 1L, "Time", 1 }
                });

            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsType", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "yyyy", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6610), true, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6611), "Year", 1L, "Year", 1 },
                    { 2L, "m", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6613), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6614), "Month", 1L, "Month", 1 },
                    { 3L, "q", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6616), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6616), "Quarter", 1L, "Quarter", 1 },
                    { 4L, "d", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6618), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6618), "Day", 1L, "Day", 1 },
                    { 5L, "vatyp", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6620), true, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6620), "Value Type", 1L, "Value Type", 1 },
                    { 6L, "cntry", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6622), true, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6623), "Country", 1L, "Country", 1 },
                    { 7L, "city", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6624), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6625), "City", 1L, "City", 1 },
                    { 8L, "rgn", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6626), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6627), "Region", 1L, "Region", 1 },
                    { 9L, "sdg", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6629), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6630), "Sustainable Development", 1L, "SDG", 1 },
                    { 10L, "liro", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6632), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6632), "Line Of Reporting", 1L, "Line Of Reporting", 1 },
                    { 11L, "domn", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6634), false, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6634), "Domain", 1L, "Domain", 1 },
                    { 12L, "bsnss", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6636), true, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6636), "Business", 1L, "Business", 1 },
                    { 13L, "mrkt", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6638), true, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6639), "Market", 1L, "Market", 1 },
                    { 14L, "factory", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6640), true, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6641), "Factory", 1L, "Factory", 1 }
                });

            migrationBuilder.InsertData(
                table: "OrganizationHeirarchies",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "HierarchyId", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State" },
                values: new object[] { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8563), 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8564), 1L, 1 });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrganizationId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7063), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7065), null, null, 1L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7066), null, null, 1L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "Standard",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "State", "TopicId" },
                values: new object[,]
                {
                    { 1L, "ESRS2_GP", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7105), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7105), "General principles", "General principles", 1, 1L },
                    { 2L, "ESRS2_MDR", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7107), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7108), "General disclosures", "General disclosures", 1, 1L },
                    { 3L, "E1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7109), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7110), "Climate change", "Climate change", 1, 2L },
                    { 4L, "E2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7111), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7112), "Pollution", "Pollution", 1, 2L },
                    { 5L, "E3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7114), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7114), "Water & marine resources", "Water & marine resources", 1, 2L },
                    { 6L, "E4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7116), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7116), "Biodiversity and eco systems", "Biodiversity and eco systems", 1, 2L },
                    { 7L, "E5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7118), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7118), "Resourtce use and circular economy", "Resourtce use and circular economy", 1, 2L },
                    { 8L, "S1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7120), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7120), "Own workforce", "Own workforce", 1, 3L },
                    { 9L, "S2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7122), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7122), "Workers in value chain", "Workers in value chain", 1, 3L },
                    { 10L, "S3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7124), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7124), "Affected communities", "Affected communities", 1, 3L },
                    { 11L, "S4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7126), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7126), "Consumers and end-users", "Consumers and end-users", 1, 3L },
                    { 12L, "G1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7128), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7129), "Business Conduct", "Business Conduct", 1, 4L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, "acidbasecapacity", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7206), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7207), "Acid/Base capacity", "Acid/Base capacity", 1L, "Acid/Base capacity", 1 },
                    { 2L, "area", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7209), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7210), "Area", "Area", 1L, "Area", 1 },
                    { 3L, "density", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7211), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7212), "Density", "Density", 1L, "Density", 1 },
                    { 4L, "energy", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7214), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7214), "Energy", "Energy", 1L, "Energy", 1 },
                    { 5L, "force", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7216), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7216), "Force", "Force", 1L, "Force", 1 },
                    { 6L, "frequency", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7218), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7218), "Frequency", "Frequency", 1L, "Frequency", 1 },
                    { 7L, "heat_conductivity", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7220), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7221), "Heat Conductivity", "Heat Conductivity", 1L, "Heat Conductivity", 1 },
                    { 8L, "hydrolysis_rate", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7222), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7224), "Hydrolysis rate", "Hydrolysis rate", 1L, "Hydrolysis rate", 1 },
                    { 9L, "inverse_area", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7225), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7226), "Inverse area", "Inverse area", 1L, "Inverse area", 1 },
                    { 10L, "kinematic_viscosity", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7227), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7228), "Kinematic viscosity", "Kinematic viscosity", 1L, "Kinematic viscosity", 1 },
                    { 11L, "length", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7229), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7230), "Length", "Length", 1L, "Length", 1 },
                    { 12L, "luminous_intensity", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7237), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7237), "Luminous intensity", "Luminous intensity", 1L, "Luminous intensity", 1 },
                    { 13L, "magnet_field_dens", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7239), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7239), "Magnet. field dens.", "Magnet. field dens.", 1L, "Magnet. field dens.", 1 },
                    { 14L, "mass", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7241), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7242), "Mass", "Mass", 1L, "Mass", 1 },
                    { 15L, "mass_coverage", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7243), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7244), "Mass coverage", "Mass coverage", 1L, "Mass coverage", 1 },
                    { 16L, "mass_flow", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7247), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7247), "Mass flow", "Mass flow", 1L, "Mass flow", 1 },
                    { 17L, "mass_per_energy", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7249), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7249), "Mass per Energy", "Mass per Energy", 1L, "Mass per Energy", 1 },
                    { 18L, "mass_proportion", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7251), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7251), "Mass proportion", "Mass proportion", 1L, "Mass proportion", 1 },
                    { 19L, "proportion", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7253), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7253), "Proportion", "Proportion", 1L, "Proportion", 1 },
                    { 20L, "time", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7255), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7256), "Time", "Time", 1L, "Time", 1 },
                    { 21L, "vaporization_speed", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7257), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7258), "Vaporization Speed", "Vaporization Speed", 1L, "Vaporization Speed", 1 },
                    { 22L, "volume", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7259), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7260), "Volume", "Volume", 1L, "Volume", 1 },
                    { 23L, "volume_proportion", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7261), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7262), "Volume proportion", "Volume proportion", 1L, "Volume proportion", 1 },
                    { 24L, "volume_rate_of_flow", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7265), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7265), "Volume rate of flow", "Volume rate of flow", 1L, "Volume rate of flow", 1 },
                    { 121L, "monetary", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7267), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7267), "Monetary", "Monetary", 1L, "Monetary", 1 },
                    { 126L, "narrative", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7269), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7269), "Text", "Text", 1L, "Text", 1 },
                    { 131L, "number", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7271), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7272), "Number", "Number", 1L, "Number", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "RoleId", "State", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8227), null, null, 1L, 1, 1L },
                    { 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8229), null, null, 2L, 1, 2L },
                    { 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8230), null, null, 3L, 1, 3L }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "CurrencyId", "CurrencyId1", "DatapointTypeId", "DisclosureRequirementId", "IsNarrative", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "OrganizationId", "Purpose", "State", "UnitOfMeasureId" },
                values: new object[,]
                {
                    { 10044L, "E1.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3537), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 10054L, "E1.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3560), null, null, 2L, null, null, 1L, null, null, "Disclosure to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 10217L, "BP-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3921), null, null, 3L, null, null, 1L, null, null, "Basis for preparation of sustainability statement", 1L, "", 1, null },
                    { 10363L, "MDR-P_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4254), null, null, 2L, null, true, 1L, null, null, "MDR-P_06", 1L, "", 1, null },
                    { 10405L, "E2.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4349), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 10411L, "E2.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4365), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 10424L, "E2.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4392), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 10484L, "E3.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4525), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 10489L, "E3.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4536), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 10501L, "E3.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4568), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 10581L, "E4.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4783), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 10599L, "E4.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4838), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 10611L, "E4.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4865), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 10652L, "E5.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4962), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 10664L, "E5.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4994), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 10679L, "E5.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5025), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 10712L, "S1.SBM-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5099), null, null, 2L, null, null, 1L, null, null, "All people in its own workforce who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 1, null },
                    { 10747L, "S1.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5177), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 10795L, "S1.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5291), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 10803L, "S1.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5309), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 10931L, "S2.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5589), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 10972L, "S2.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5682), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 10980L, "S2.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5701), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 10999L, "S3.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5743), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 11041L, "S3.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5837), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 11049L, "S3.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5859), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 11068L, "S4.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5903), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 11110L, "S4.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5997), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null },
                    { 11118L, "S4.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6018), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted targets", 1L, "", 1, null },
                    { 11137L, "G1.MDR-P_07-08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6058), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported in case the undertaking has not adopted policies", 1L, "", 1, null },
                    { 11168L, "G1.MDR-A_13-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6129), null, null, 2L, null, null, 1L, null, null, "Disclosures to be reported if the undertaking has not adopted actions", 1L, "", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DimensionTypeId", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "OrganizationId", "ShortText", "State" },
                values: new object[,]
                {
                    { 1000L, "act", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6668), 5L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6669), "Actual", 1L, "Actual", 1 },
                    { 1001L, "base", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6671), 5L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6672), "Baseline", 1L, "Baseline", 1 },
                    { 1002L, "target", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6673), 5L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6674), "Target", 1L, "Target", 1 },
                    { 1003L, "de", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6676), 6L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6676), "Germany", 1L, "DE", 1 },
                    { 1004L, "nl", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6678), 6L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6678), "The Netherlands", 1L, "NL", 1 },
                    { 1005L, "dap", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6680), 12L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6681), "Domestic Appliances", 1L, "DAP", 1 },
                    { 1006L, "pms", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6682), 12L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6683), "Medical systems", 1L, "PMS", 1 },
                    { 1007L, "eur", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6684), 13L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6685), "Europe", 1L, "EUR", 1 },
                    { 1008L, "ame", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6686), 13L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6687), "Africa, Middle East", 1L, "AME", 1 },
                    { 1009L, "tern", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6689), 14L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6689), "Terneuzen", 1L, "Terneuzen", 1 },
                    { 1010L, "2023", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6691), 1L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6691), "2023", 1L, "2023", 1 },
                    { 1011L, "2024", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6693), 1L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6694), "2024", 1L, "2024", 1 },
                    { 1012L, "2025", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6695), 1L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6696), "2025", 1L, "2025", 1 }
                });

            migrationBuilder.InsertData(
                table: "DisclosureRequirement",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "ShortText", "StandardId", "State" },
                values: new object[,]
                {
                    { 1L, "BP-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6730), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6730), "General basis for preparation of sustainability statements", "General basis for preparation of sustainability statements", 1L, 1 },
                    { 2L, "BP-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6733), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6733), "Disclosures in relation to specific circumstances", "Disclosures in relation to specific circumstances", 1L, 1 },
                    { 3L, "GOV-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6735), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6736), "The role of the administrative, management and supervisory bodies", "The role of the administrative, management and supervisory bodies", 1L, 1 },
                    { 4L, "GOV-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6737), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6738), "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", "Information provided to and sustainability matters addressed by the undertaking’s administrative, management and supervisory bodies", 1L, 1 },
                    { 5L, "GOV-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6740), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6740), "Integration of sustainability-related performance in incentive schemes", "Integration of sustainability-related performance in incentive schemes", 1L, 1 },
                    { 6L, "GOV-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6742), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6743), "Statement on due diligence", "Statement on due diligence", 1L, 1 },
                    { 7L, "GOV-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6744), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6745), "Risk management and internal controls over sustainability reporting", "Risk management and internal controls over sustainability reporting", 1L, 1 },
                    { 8L, "SBM-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6746), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6747), "Strategy, business model and value chain", "Strategy, business model and value chain", 1L, 1 },
                    { 9L, "SBM-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6754), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6755), "Interests and views of stakeholders", "Interests and views of stakeholders", 1L, 1 },
                    { 10L, "SBM-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6756), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6757), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 1L, 1 },
                    { 11L, "IRO-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6758), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6759), "Description of the process to identify and assess material impacts, risks and opportunities", "Description of the process to identify and assess material impacts, risks and opportunities", 1L, 1 },
                    { 12L, "IRO-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6761), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6761), "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", "Disclosure requirements in ESRS covered by the undertaking’s sustainability statement", 1L, 1 },
                    { 13L, "MDR-P", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6763), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6763), "Policies adopted to manage material sustainability matters", "Policies adopted to manage material sustainability matters", 2L, 1 },
                    { 14L, "MDR-A", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6765), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6765), "Actions and resources in relation to material sustainability matters", "Actions and resources in relation to material sustainability matters", 2L, 1 },
                    { 15L, "MDR-M", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6767), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6768), "Metrics in relation to material sustainability matters", "Metrics in relation to material sustainability matters", 2L, 1 },
                    { 16L, "MDR-T", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6769), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6770), "Tracking effectiveness of policies and actions through targets", "Tracking effectiveness of policies and actions through targets", 2L, 1 },
                    { 17L, "E1.GOV-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6771), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6772), "Integration of sustainability-related performance in incentive schemes", "Integration of sustainability-related performance in incentive schemes", 3L, 1 },
                    { 18L, "E1-1 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6774), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6775), "Transition plan for climate change mitigation", "Transition plan for climate change mitigation", 3L, 1 },
                    { 19L, "E1.SBM-3 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6776), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6777), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 3L, 1 },
                    { 20L, "E1.IRO-1 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6778), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6779), "Description of the processes to identify and assess material climate-related impacts, risks and opportunities", "Description of the processes to identify and assess material climate-related impacts, risks and opportunities", 3L, 1 },
                    { 21L, "E1-2 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6780), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6781), "Policies related to climate change mitigation and adaptation", "Policies related to climate change mitigation and adaptation", 3L, 1 },
                    { 22L, "E1-3 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6783), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6783), "Actions and resources in relation to climate change policies", "Actions and resources in relation to climate change policies", 3L, 1 },
                    { 23L, "E1-4 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6785), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6785), "Targets related to climate change mitigation and adaptation", "Targets related to climate change mitigation and adaptation", 3L, 1 },
                    { 24L, "E1-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6787), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6787), "Energy consumption and mix", "Energy consumption and mix", 3L, 1 },
                    { 25L, "E1-6", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6790), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6790), "Gross Scopes 1, 2, 3 and Total GHG emissions", "Gross Scopes 1, 2, 3 and Total GHG emissions", 3L, 1 },
                    { 26L, "E1-7 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6792), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6792), "GHG removals and GHG mitigation projects financed through carbon credits", "GHG removals and GHG mitigation projects financed through carbon credits", 3L, 1 },
                    { 27L, "E1-8 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6794), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6794), "Internal carbon pricing", "Internal carbon pricing", 3L, 1 },
                    { 28L, "E1-9 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6796), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6796), "Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", "Anticipated financial effects from material physical and transition risks and potential climate-related opportunities", 3L, 1 },
                    { 29L, "E2.IRO-1 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6798), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6799), "Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", "Description of the processes to identify and assess material pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 30L, "E2-1 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6800), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6801), "Policies related to pollution", "Policies related to pollution", 4L, 1 },
                    { 31L, "E2-2 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6802), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6803), "Actions and resources related to pollution", "Actions and resources related to pollution", 4L, 1 },
                    { 32L, "E2-3 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6804), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6806), "Targets related to pollution", "Targets related to pollution", 4L, 1 },
                    { 33L, "E2-4 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6807), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6808), "Pollution of air, water and soil", "Pollution of air, water and soil", 4L, 1 },
                    { 34L, "E2-5 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6809), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6810), "Substances of concern and substances of very high concern", "Substances of concern and substances of very high concern", 4L, 1 },
                    { 35L, "E2-6 ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6811), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6812), "Anticipated financial effects from pollution-related impacts, risks and opportunities", "Anticipated financial effects from pollution-related impacts, risks and opportunities", 4L, 1 },
                    { 36L, "E3.IRO-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6813), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6814), "Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", "Description of the processes to identify and assess material water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 37L, "E3-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6815), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6816), "Policies related to water and marine resources", "Policies related to water and marine resources", 5L, 1 },
                    { 38L, "E3-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6817), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6818), "Actions and resources related to water and marine resources", "Actions and resources related to water and marine resources", 5L, 1 },
                    { 39L, "E3-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6819), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6820), "Targets related to water and marine resources", "Targets related to water and marine resources", 5L, 1 },
                    { 40L, "E3-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6822), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6823), "Water consumption", "Water consumption", 5L, 1 },
                    { 41L, "E3-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6824), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6825), "Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", "Anticipated financial effects from water and marine resources-related impacts, risks and opportunities", 5L, 1 },
                    { 42L, "E4.SBM-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6827), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6827), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 6L, 1 },
                    { 43L, "E4.IRO-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6829), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6829), "Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", "Description of processes to identify and assess material biodiversity and ecosystem-related impacts, risks and opportunities", 6L, 1 },
                    { 44L, "E4-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6831), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6831), "Transition plan and consideration of biodiversity and ecosystems in strategy and business model", "Transition plan and consideration of biodiversity and ecosystems in strategy and business model", 6L, 1 },
                    { 45L, "E4-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6833), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6833), "Policies related to biodiversity and ecosystems", "Policies related to biodiversity and ecosystems", 6L, 1 },
                    { 46L, "E4-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6835), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6835), "Actions and resources related to biodiversity and ecosystems", "Actions and resources related to biodiversity and ecosystems", 6L, 1 },
                    { 47L, "E4-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6838), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6838), "Targets related to biodiversity and ecosystems", "Targets related to biodiversity and ecosystems", 6L, 1 },
                    { 48L, "E4-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6840), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6841), "Impact metrics related to biodiversity and ecosystems change", "Impact metrics related to biodiversity and ecosystems change", 6L, 1 },
                    { 49L, "E4-6", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6842), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6843), "Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", "Anticipated financial effects from biodiversity and ecosystem-related risks and opportunities", 6L, 1 },
                    { 50L, "E5.IRO-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6844), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6845), "Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", "Description of the processes to identify and assess material resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 51L, "E5-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6846), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6847), "Policies related to resource use and circular economy", "Policies related to resource use and circular economy", 7L, 1 },
                    { 52L, "E5-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6848), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6849), "Actions and resources related to resource use and circular economy", "Actions and resources related to resource use and circular economy", 7L, 1 },
                    { 53L, "E5-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6850), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6851), "Targets related to resource use and circular economy", "Targets related to resource use and circular economy", 7L, 1 },
                    { 54L, "E5-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6852), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6853), "Resource inflows", "Resource inflows", 7L, 1 },
                    { 55L, "E5-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6855), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6856), "Resource outflows", "Resource outflows", 7L, 1 },
                    { 56L, "E5-6", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6857), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6858), "Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", "Anticipated financial effects from resource use and circular economy-related impacts, risks and opportunities", 7L, 1 },
                    { 58L, "S1.SBM-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6862), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6862), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 8L, 1 },
                    { 59L, "S1-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6864), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6865), "Policies related to own workforce", "Policies related to own workforce", 8L, 1 },
                    { 60L, "S1-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6867), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6867), "Processes for engaging with own workforce and workers’ representatives about impacts", "Processes for engaging with own workforce and workers’ representatives about impacts", 8L, 1 },
                    { 61L, "S1-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6869), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6869), "Processes to remediate negative impacts and channels for own workforce to raise concerns", "Processes to remediate negative impacts and channels for own workforce to raise concerns", 8L, 1 },
                    { 62L, "S1-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6871), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6871), "Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", "Taking action on material impacts on own workforce, and approaches to managing material risks and pursuing material opportunities related to own workforce, and effectiveness of those actions", 8L, 1 },
                    { 63L, "S1-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6878), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6879), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 8L, 1 },
                    { 64L, "S1-6", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6881), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6881), "Characteristics of the undertaking’s employees", "Characteristics of the undertaking’s employees", 8L, 1 },
                    { 65L, "S1-7", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6883), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6883), "Characteristics of non-employees in the undertaking’s own workforce", "Characteristics of non-employees in the undertaking’s own workforce", 8L, 1 },
                    { 66L, "S1-8", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6885), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6885), "Collective bargaining coverage and social dialogue", "Collective bargaining coverage and social dialogue", 8L, 1 },
                    { 67L, "S1-9", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6887), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6887), "Diversity metrics", "Diversity metrics", 8L, 1 },
                    { 68L, "S1-10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6889), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6889), "Adequate wages", "Adequate wages", 8L, 1 },
                    { 69L, "S1-11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6891), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6892), "Social protection", "Social protection", 8L, 1 },
                    { 70L, "S1-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6894), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6894), "Persons with disabilities", "Persons with disabilities", 8L, 1 },
                    { 71L, "S1-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6896), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6896), "Training and skills development metrics", "Training and skills development metrics", 8L, 1 },
                    { 72L, "S1-14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6898), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6898), "Health and safety metrics", "Health and safety metrics", 8L, 1 },
                    { 73L, "S1-15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6900), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6901), "Work-life balance metrics", "Work-life balance metrics", 8L, 1 },
                    { 74L, "S1-16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6902), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6903), "Remuneration metrics (pay gap and total remuneration)", "Remuneration metrics (pay gap and total remuneration)", 8L, 1 },
                    { 75L, "S1-17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6904), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6905), "Incidents, complaints and severe human rights impacts", "Incidents, complaints and severe human rights impacts", 8L, 1 },
                    { 77L, "S2.SBM-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6909), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6910), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 9L, 1 },
                    { 78L, "S2-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6911), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6912), "Policies related to value chain workers", "Policies related to value chain workers", 9L, 1 },
                    { 79L, "S2-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6913), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6914), "Processes for engaging with value chain workers about impacts", "Processes for engaging with value chain workers about impacts", 9L, 1 },
                    { 80L, "S2-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6915), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6916), "Processes to remediate negative impacts and channels for value chain workers to raise concerns", "Processes to remediate negative impacts and channels for value chain workers to raise concerns", 9L, 1 },
                    { 81L, "S2-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6917), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6918), "Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", "Taking Action on material impacts on value chain workers, and approaches to managing material risks and pursuing material opportunities related to value chain workers, and effectiveness of those actions", 9L, 1 },
                    { 82L, "S2-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6920), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6920), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 9L, 1 },
                    { 84L, "S3.SBM-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6921), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6922), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 10L, 1 },
                    { 85L, "S3-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6925), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6925), "Policies related to affected communities", "Policies related to affected communities", 10L, 1 },
                    { 86L, "S3-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6927), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6927), "Processes for engaging with affected communities about impacts", "Processes for engaging with affected communities about impacts", 10L, 1 },
                    { 87L, "S3-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6929), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6929), "Processes to remediate negative impacts and channels for affected communities to raise concerns", "Processes to remediate negative impacts and channels for affected communities to raise concerns", 10L, 1 },
                    { 88L, "S3-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6931), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6931), "aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", "aking action on material impacts on affected communities, and approaches to managing material risks and pursuing material opportunities related to affected communities, and effectiveness of those actions", 10L, 1 },
                    { 89L, "S3-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6933), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6933), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunitie", 10L, 1 },
                    { 91L, "S4.SBM-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6937), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6937), "Material impacts, risks and opportunities and their interaction with strategy and business model", "Material impacts, risks and opportunities and their interaction with strategy and business model", 11L, 1 },
                    { 92L, "S4-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6939), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6939), "Policies related to consumers and end-users", "Policies related to consumers and end-users", 11L, 1 },
                    { 93L, "S4-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6942), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6942), "Processes for engaging with consumers and end-users about impacts", "Processes for engaging with consumers and end-users about impacts", 11L, 1 },
                    { 94L, "S4-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6944), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6944), "Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", "Processes to remediate negative impacts and channels for consumers and end-users to raise concerns", 11L, 1 },
                    { 95L, "S4-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6946), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6947), "Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", "Taking action on material impacts on consumers and end-users, and approaches to managing material risks and pursuing material opportunities related to consumers and end-users, and effectiveness of those actions", 11L, 1 },
                    { 96L, "S4-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6948), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6949), "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", "Targets related to managing material negative impacts, advancing positive impacts, and managing material risks and opportunities", 11L, 1 },
                    { 97L, "G1.GOV-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6950), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6951), "The role of the administrative, supervisory and management bodies", "The role of the administrative, supervisory and management bodies", 12L, 1 },
                    { 98L, "G1-1", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6952), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6953), "Business conduct policies and corporate culture", "Business conduct policies and corporate culture", 12L, 1 },
                    { 99L, "G1-2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6954), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6955), "Management of relationships with suppliers", "Management of relationships with suppliers", 12L, 1 },
                    { 100L, "G1-3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6956), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6957), "Prevention and detection of corruption and bribery", "Prevention and detection of corruption and bribery", 12L, 1 },
                    { 101L, "G1-4", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6958), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6959), "Incidents of corruption or bribery", "Incidents of corruption or bribery", 12L, 1 },
                    { 102L, "G1-5", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6960), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6961), "Political influence and lobbying activities", "Political influence and lobbying activities", 12L, 1 },
                    { 103L, "G1-6", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6962), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6963), "Payment practices", "Payment practices", 12L, 1 }
                });

            migrationBuilder.InsertData(
                table: "ModelConfiguration",
                columns: new[] { "Id", "ColumnId", "CreatedBy", "CreatedDate", "DataModelId", "DimensionTypeId", "LastModifiedBy", "LastModifiedDate", "RowId", "State", "ViewType" },
                values: new object[,]
                {
                    { 10000L, 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8468), 1L, null, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8469), 1L, 1, 1 },
                    { 10001L, null, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8470), 1L, null, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8471), 1L, 1, 2 },
                    { 10002L, 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8472), 2L, null, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8473), 1L, 1, 1 },
                    { 10003L, null, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8474), 2L, null, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8475), 1L, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ModelDimensionTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataModelId", "DimensionTypeId", "LastModifiedBy", "LastModifiedDate", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8378), 1L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8378), 1 },
                    { 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8380), 1L, 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8380), 1 },
                    { 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8382), 2L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8382), 1 },
                    { 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8383), 2L, 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8384), 1 },
                    { 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8385), 3L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8386), 1 },
                    { 6L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8387), 3L, 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8387), 1 },
                    { 7L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8388), 4L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8389), 1 },
                    { 8L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8390), 4L, 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8391), 1 },
                    { 9L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8392), 5L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8392), 1 },
                    { 10L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8394), 5L, 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8394), 1 },
                    { 11L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8395), 1L, 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8396), 1 },
                    { 12L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8397), 2L, 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8397), 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypeTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureTypeId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7736), 1001L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7737), "Acid/Base capacity", "Acid/Base capacity", "Acid/Base capacity", 1 },
                    { 1L, 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7739), 1002L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7739), "Area", "Area", "Area", 1 },
                    { 1L, 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7741), 1003L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7741), "Density", "Density", "Density", 1 },
                    { 1L, 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7743), 1004L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7743), "Energy", "Energy", "Energy", 1 },
                    { 1L, 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7745), 1005L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7745), "Force", "Force", "Force", 1 },
                    { 1L, 6L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7747), 1006L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7747), "Frequency", "Frequency", "Frequency", 1 },
                    { 1L, 7L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7749), 1007L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7749), "Heat Conductivity", "Heat Conductivity", "Heat Conductivity", 1 },
                    { 1L, 8L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7752), 1008L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7753), "Hydrolysis rate", "Hydrolysis rate", "Hydrolysis rate", 1 },
                    { 1L, 9L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7754), 1009L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7755), "Inverse area", "Inverse area", "Inverse area", 1 },
                    { 1L, 10L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7758), 1010L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7758), "Kinematic viscosity", "Kinematic viscosity", "Kinematic viscosity", 1 },
                    { 1L, 11L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7760), 1011L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7761), "Length", "Length", "Length", 1 },
                    { 1L, 12L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7762), 1012L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7762), "Luminous intensity", "Luminous intensity", "Luminous intensity", 1 },
                    { 1L, 13L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7764), 1013L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7765), "Magnet. field dens.", "Magnet. field dens.", "Magnet. field dens.", 1 },
                    { 1L, 14L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7767), 1014L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7768), "Mass", "Mass", "Mass", 1 },
                    { 1L, 15L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7769), 1015L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7770), "Mass coverage", "Mass coverage", "Mass coverage", 1 },
                    { 1L, 16L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7771), 1016L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7771), "Mass flow", "Mass flow", "Mass flow", 1 },
                    { 1L, 17L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7774), 1017L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7774), "Mass per Energy", "Mass per Energy", "Mass per Energy", 1 },
                    { 1L, 18L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7776), 1018L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7776), "Mass proportion", "Mass proportion", "Mass proportion", 1 },
                    { 1L, 19L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7778), 1019L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7778), "Proportion", "Proportion", "Proportion", 1 },
                    { 1L, 20L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7780), 1020L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7780), "Time", "Time", "Time", 1 },
                    { 1L, 21L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7783), 1021L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7783), "Vaporization Speed", "Vaporization Speed", "Vaporization Speed", 1 },
                    { 1L, 22L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7785), 1022L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7785), "Volume", "Volume", "Volume", 1 },
                    { 1L, 23L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7788), 1023L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7789), "Volume proportion", "Volume proportion", "Volume proportion", 1 },
                    { 1L, 24L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7791), 1024L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7792), "Volume rate of flow", "Volume rate of flow", "Volume rate of flow", 1 },
                    { 1L, 121L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7794), 1121L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7795), "Monetary", "Monetary", "Monetary", 1 },
                    { 1L, 126L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7796), 1126L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7797), "Text", "Text", "Text", 1 },
                    { 1L, 131L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7798), 1131L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7799), "Number", "Number", "Number", 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 1L, "hh", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7303), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7304), "Hour", "Hour", 1L, "Hr", 1, 20L },
                    { 2L, "mm", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7306), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7307), "Minute", "Minute", 1L, "Min", 1, 20L },
                    { 3L, "ss", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7308), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7309), "Second", "Second", 1L, "Sec", 1, 20L },
                    { 4L, "d", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7311), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7311), "Day", "Day", 1L, "Day", 1, 20L },
                    { 5L, "m", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7313), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7314), "Month", "Month", 1L, "Month", 1, 20L },
                    { 6L, "q", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7316), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7316), "Quarter", "Quarter", 1L, "Qrtr", 1, 20L },
                    { 7L, "y", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7318), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7318), "Year", "Year", 1L, "Year", 1, 20L },
                    { 8L, "mMol/l", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7320), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7321), "Millimol per liter", "Millimol per liter", 1L, "mMol/l", 1, 1L },
                    { 9L, "Mol/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7322), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7323), "Mol per cubic meter", "Mol per cubic meter", 1L, "Mol/m3", 1, 1L },
                    { 10L, "Mol/l", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7325), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7325), "Mol per liter", "Mol per liter", 1L, "Mol/l", 1, 1L },
                    { 11L, "acre", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7327), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7327), "Acre", "Acre", 1L, "Acre", 1, 2L },
                    { 12L, "ha", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7329), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7330), "Hectare", "Hectare", 1L, "Ha", 1, 2L },
                    { 13L, "yd2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7332), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7332), "Square Yard", "Square Yard", 1L, "Yd2", 1, 2L },
                    { 14L, "cm2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7334), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7334), "Square centimeter", "Square centimeter", 1L, "Cm2", 1, 2L },
                    { 15L, "ft2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7336), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7337), "Square foot", "Square foot", 1L, "Ft2", 1, 2L },
                    { 16L, "Inch2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7338), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7339), "Square inch", "Square inch", 1L, "Inch2", 1, 2L },
                    { 17L, "km2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7340), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7341), "Square kilometer", "Square kilometer", 1L, "Km2", 1, 2L },
                    { 18L, "m2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7343), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7343), "Square meter", "Square meter", 1L, "M2", 1, 2L },
                    { 19L, "Mile2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7345), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7346), "Square mile", "Square mile", 1L, "Mile2", 1, 2L },
                    { 20L, "mm2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7348), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7348), "Square millimeter", "Square millimeter", 1L, "Mm2", 1, 2L },
                    { 21L, "g/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7350), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7350), "Gram/Cubic meter", "Gram/Cubic meter", 1L, "G/M3", 1, 3L },
                    { 22L, "g/cm3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7357), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7357), "Gram/cubic centimeter", "Gram/cubic centimeter", 1L, "G/Cm3", 1, 3L },
                    { 23L, "g/l", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7359), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7359), "Gram/liter", "Gram/liter", 1L, "G/L", 1, 3L },
                    { 24L, "kg/scf", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7361), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7361), "Kilogram/Standard Cubic Foot", "Kilogram/Standard Cubic Foot", 1L, "Kg/Scf", 1, 3L },
                    { 25L, "kg/bbl", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7363), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7364), "Kilogram/US Barrel", "Kilogram/US Barrel", 1L, "Kg/Bbl", 1, 3L },
                    { 26L, "kg/dm3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7365), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7366), "Kilogram/cubic decimeter", "Kilogram/cubic decimeter", 1L, "Kg/Dm3", 1, 3L },
                    { 27L, "kg/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7368), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7369), "Kilogram/cubic meter", "Kilogram/cubic meter", 1L, "Kg/M3", 1, 3L },
                    { 28L, "µg/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7370), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7371), "Microgram/cubic meter", "Microgram/cubic meter", 1L, "µg/M3", 1, 3L },
                    { 29L, "µg/l", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7373), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7373), "Microgram/liter", "Microgram/liter", 1L, "µg/L", 1, 3L },
                    { 30L, "mg/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7375), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7375), "Milligram/cubic meter", "Milligram/cubic meter", 1L, "Mg/M3", 1, 3L },
                    { 31L, "mg/l", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7377), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7377), "Milligram/liter", "Milligram/liter", 1L, "Mg/L", 1, 3L },
                    { 32L, "t/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7379), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7380), "Ton/Cubic meter", "Ton/Cubic meter", 1L, "T/M3", 1, 3L },
                    { 33L, "t/tm3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7382), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7382), "Tonne/1000 Cubic Meters", "Tonne/1000 Cubic Meters", 1L, "T/Tm3", 1, 3L },
                    { 34L, "t/bbl", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7384), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7384), "Tonne/US Barrel", "Tonne/US Barrel", 1L, "T/Bbl", 1, 3L },
                    { 35L, "lb/scf", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7386), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7386), "US Pound/Standard Cubic Foot", "US Pound/Standard Cubic Foot", 1L, "Lb/Scf", 1, 3L },
                    { 36L, "lb/gal", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7388), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7388), "US Pound/US Gallon", "US Pound/US Gallon", 1L, "Lb/Gal", 1, 3L },
                    { 37L, "ton/gl", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7390), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7391), "US Tonne/US Gallon", "US Tonne/US Gallon", 1L, "Ton/Gl", 1, 3L },
                    { 38L, "percent", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7392), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7393), "Percentage", "Percentage", 1L, "%", 1, 131L },
                    { 39L, "GJ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7394), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7395), "Gigajoule", "Gigajoule", 1L, "Gj", 1, 4L },
                    { 40L, "J", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7397), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7397), "Joule", "Joule", 1L, "J", 1, 4L },
                    { 41L, "kJ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7399), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7399), "Kilojoule", "Kilojoule", 1L, "Kj", 1, 4L },
                    { 42L, "kwh", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7402), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7402), "Kilowatt hours", "Kilowatt hours", 1L, "Kwh", 1, 4L },
                    { 43L, "MJ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7404), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7405), "Megajoule", "Megajoule", 1L, "Mj", 1, 4L },
                    { 44L, "MWh", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7406), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7407), "Megawatt hour", "Megawatt hour", 1L, "Mwh", 1, 4L },
                    { 45L, "mJ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7408), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7409), "Millijoule", "Millijoule", 1L, "Mj", 1, 4L },
                    { 46L, "KCAL", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7411), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7411), "kilocalories", "kilocalories", 1L, "Kcal", 1, 4L },
                    { 47L, "ND", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7413), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7413), "Kilonewton", "Kilonewton", 1L, "Nd", 1, 5L },
                    { 48L, "MN", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7415), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7415), "Meganewton", "Meganewton", 1L, "Mn", 1, 5L },
                    { 49L, "N", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7419), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7420), "Newton", "Newton", 1L, "N", 1, 5L },
                    { 50L, "1/min", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7422), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7422), "1/minute", "1/minute", 1L, "1/Min", 1, 6L },
                    { 51L, "BPM", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7424), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7424), "Bottles per minute", "Bottles per minute", 1L, "Bpm", 1, 6L },
                    { 52L, "1/second)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7426), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7426), "Hertz", "Hertz", 1L, "1/Second)", 1, 6L },
                    { 53L, "kHz", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7428), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7429), "Kilohertz", "Kilohertz", 1L, "Khz", 1, 6L },
                    { 54L, "MHz", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7430), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7431), "Megahertz", "Megahertz", 1L, "Mhz", 1, 6L },
                    { 55L, "RPM", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7432), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7433), "RPM", "RPM", 1L, "Rpm", 1, 6L },
                    { 56L, "W/mk", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7435), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7436), "Heat Conductivity", "Heat Conductivity", 1L, "W/Mk", 1, 7L },
                    { 57L, "l/m_.s", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7438), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7438), "Liter/Molsecond", "Liter/Molsecond", 1L, "L/M_.S", 1, 8L },
                    { 58L, "1/M2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7440), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7440), "1 / square meter", "1 / square meter", 1L, "1/M2", 1, 9L },
                    { 59L, "US)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7442), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7442), "Miles per gallon", "Miles per gallon", 1L, "Us)", 1, 2L },
                    { 60L, "m2/s", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7444), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7445), "Square meter/second", "Square meter/second", 1L, "M2/S", 1, 10L },
                    { 61L, "mm2/s", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7446), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7447), "Square millimeter/second", "Square millimeter/second", 1L, "Mm2/S", 1, 10L },
                    { 62L, "cm", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7448), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7449), "Centimeter", "Centimeter", 1L, "Cm", 1, 11L },
                    { 63L, "dm", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7451), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7451), "Decimeter", "Decimeter", 1L, "Dm", 1, 11L },
                    { 64L, "ft", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7454), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7454), "Foot", "Foot", 1L, "Foot", 1, 11L },
                    { 65L, "inch", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7456), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7456), "Inch", "Inch", 1L, "Inch", 1, 11L },
                    { 66L, "km", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7458), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7458), "Kilometer", "Kilometer", 1L, "Km", 1, 11L },
                    { 67L, "m", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7460), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7461), "Meter", "Meter", 1L, "M", 1, 11L },
                    { 68L, "µm", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7462), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7463), "Micrometer", "Micrometer", 1L, "µm", 1, 11L },
                    { 69L, "mile", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7468), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7468), "Mile", "Mile", 1L, "Mile", 1, 11L },
                    { 70L, "mm", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7470), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7470), "Millimeter", "Millimeter", 1L, "Mm", 1, 11L },
                    { 71L, "nm", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7473), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7473), "Nanometer", "Nanometer", 1L, "Nm", 1, 11L },
                    { 72L, "yd", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7475), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7476), "Yards", "Yards", 1L, "Yd", 1, 11L },
                    { 73L, "cd", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7477), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7478), "Candela", "Candela", 1L, "Cd", 1, 12L },
                    { 74L, "D", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7479), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7480), "Tesla", "Tesla", 1L, "D", 1, 13L },
                    { 75L, "g", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7481), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7482), "Gram", "Gram", 1L, "G", 1, 14L },
                    { 76L, "kt", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7484), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7484), "Kilotonne", "Kilotonne", 1L, "Kt", 1, 14L },
                    { 77L, "mg", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7486), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7486), "Milligram", "Milligram", 1L, "Mg", 1, 14L },
                    { 78L, "oz", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7488), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7488), "Ounce", "Ounce", 1L, "Oz", 1, 14L },
                    { 79L, "t", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7491), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7491), "Tonne", "Tonne", 1L, "T", 1, 14L },
                    { 80L, "lb", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7493), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7493), "US pound", "US pound", 1L, "Lb", 1, 14L },
                    { 81L, "ton", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7495), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7496), "US ton", "US ton", 1L, "Ton", 1, 14L },
                    { 82L, "kg", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7497), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7498), "Kilogram", "Kilogram", 1L, "Kg", 1, 14L },
                    { 83L, "g/m2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7499), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7500), "Gram/square meter", "Gram/square meter", 1L, "G/M2", 1, 15L },
                    { 84L, "kg/m2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7501), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7502), "Kilogram/Square meter", "Kilogram/Square meter", 1L, "Kg/M2", 1, 15L },
                    { 85L, "mg/cm2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7503), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7504), "Milligram/Square centimeter", "Milligram/Square centimeter", 1L, "Mg/Cm2", 1, 15L },
                    { 86L, "kg/s", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7506), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7507), "Kilogram/second", "Kilogram/second", 1L, "Kg/S", 1, 16L },
                    { 87L, "kg/J", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7509), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7509), "Kilogram/Joule", "Kilogram/Joule", 1L, "Kg/J", 1, 17L },
                    { 88L, "kg/MB", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7511), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7511), "Kilogram/Million BTU", "Kilogram/Million BTU", 1L, "Kg/Mb", 1, 17L },
                    { 89L, "t/Btu", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7513), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7513), "Tonne/British Thermal Unit", "Tonne/British Thermal Unit", 1L, "T/Btu", 1, 17L },
                    { 90L, "t/Joul", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7516), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7519), "Tonne/Joule", "Tonne/Joule", 1L, "T/Joul", 1, 17L },
                    { 91L, "t/TJ", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7520), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7521), "Tonne/Terajoule", "Tonne/Terajoule", 1L, "T/Tj", 1, 17L },
                    { 92L, "lb/Btu", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7522), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7523), "US Pound/British Thermal Unit", "US Pound/British Thermal Unit", 1L, "Lb/Btu", 1, 17L },
                    { 93L, "lb/MB", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7524), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7525), "US Pound/Million BTU", "US Pound/Million BTU", 1L, "Lb/Mb", 1, 17L },
                    { 94L, "g/hg", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7527), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7528), "Gram/hectogram", "Gram/hectogram", 1L, "G/Hg", 1, 18L },
                    { 95L, "g/kg", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7531), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7532), "Gram/kilogram", "Gram/kilogram", 1L, "G/Kg", 1, 18L },
                    { 96L, "kg/kg", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7533), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7534), "Kilogram/Kilogram", "Kilogram/Kilogram", 1L, "Kg/Kg", 1, 18L },
                    { 97L, "kg/ton", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7536), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7536), "Kilogram/US Tonne", "Kilogram/US Tonne", 1L, "Kg/Ton", 1, 18L },
                    { 98L, "ppb(m)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7538), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7538), "Mass parts per billion", "Mass parts per billion", 1L, "Ppb(M)", 1, 18L },
                    { 99L, "ppm(m)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7540), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7540), "Mass parts per million", "Mass parts per million", 1L, "Ppm(M)", 1, 18L },
                    { 100L, "ppt(m)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7542), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7543), "Mass parts per trillion", "Mass parts per trillion", 1L, "Ppt(M)", 1, 18L },
                    { 101L, "mg/g", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7545), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7546), "Milligram/gram", "Milligram/gram", 1L, "Mg/G", 1, 18L },
                    { 102L, "mg/kg", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7547), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7548), "Milligram/kilogram", "Milligram/kilogram", 1L, "Mg/Kg", 1, 18L },
                    { 103L, "%(m)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7549), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7550), "Percent mass", "Percent mass", 1L, "%(M)", 1, 18L },
                    { 104L, "%O(m)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7552), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7552), "Permille mass", "Permille mass", 1L, "%O(M)", 1, 18L },
                    { 105L, "t/t", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7554), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7554), "Tonne/Tonne", "Tonne/Tonne", 1L, "T/T", 1, 18L },
                    { 106L, "lb/ton", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7556), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7556), "US Pound/US Tonne", "US Pound/US Tonne", 1L, "Lb/Ton", 1, 18L },
                    { 107L, "µs", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7558), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7558), "Microsecond", "Microsecond", 1L, "µs", 1, 20L },
                    { 108L, "ms", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7560), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7562), "Millisecond", "Millisecond", 1L, "Ms", 1, 20L },
                    { 109L, "ns", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7563), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7564), "Nanosecond", "Nanosecond", 1L, "Ns", 1, 20L },
                    { 110L, "ps", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7565), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7566), "Picosecond", "Picosecond", 1L, "Ps", 1, 20L },
                    { 111L, "s", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7568), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7568), "Second", "Second", 1L, "S", 1, 20L },
                    { 112L, "w", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7570), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7570), "Week", "Week", 1L, "W", 1, 20L },
                    { 113L, "yr", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7572), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7572), "Years", "Years", 1L, "Yr", 1, 20L },
                    { 114L, "kg/sm2", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7574), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7575), "Vaporization Speed", "Vaporization Speed", 1L, "Kg/Sm2", 1, 21L },
                    { 115L, "Cl", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7580), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7580), "Centiliter", "Centiliter", 1L, "Cl", 1, 22L },
                    { 116L, "cm3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7583), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7584), "Cubic centimeter", "Cubic centimeter", 1L, "Cm3", 1, 22L },
                    { 117L, "dm3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7585), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7586), "Cubic decimeter", "Cubic decimeter", 1L, "Dm3", 1, 22L },
                    { 118L, "ft3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7587), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7588), "Cubic foot", "Cubic foot", 1L, "Ft3", 1, 22L },
                    { 119L, "Inch3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7590), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7590), "Cubic inch", "Cubic inch", 1L, "Inch3", 1, 22L },
                    { 120L, "m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7592), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7593), "Cubic meter", "Cubic meter", 1L, "M3", 1, 22L },
                    { 121L, "mm3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7598), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7600), "Cubic millimeter", "Cubic millimeter", 1L, "Mm3", 1, 22L },
                    { 122L, "yd3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7603), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7604), "Cubic yard", "Cubic yard", 1L, "Yd3", 1, 22L },
                    { 123L, "hl", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7607), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7607), "Hectoliter", "Hectoliter", 1L, "Hl", 1, 22L },
                    { 124L, "l", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7609), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7610), "Liter", "Liter", 1L, "L", 1, 22L },
                    { 125L, "µl", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7611), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7612), "Microliter", "Microliter", 1L, "µl", 1, 22L },
                    { 126L, "ml", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7613), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7614), "Milliliter", "Milliliter", 1L, "Ml", 1, 22L },
                    { 127L, "pt US", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7615), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7616), "Pint, US liquid", "Pint, US liquid", 1L, "Pt Us", 1, 22L },
                    { 128L, "qt US", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7618), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7618), "Quart, US liquid", "Quart, US liquid", 1L, "Qt Us", 1, 22L },
                    { 129L, "gal US", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7620), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7620), "US gallon", "US gallon", 1L, "Gal Us", 1, 22L },
                    { 130L, "m3/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7623), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7624), "Cubic meter/Cubic meter", "Cubic meter/Cubic meter", 1L, "M3/M3", 1, 23L },
                    { 131L, "ml/m3", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7625), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7626), "Milliliter/cubic meter", "Milliliter/cubic meter", 1L, "Ml/M3", 1, 23L },
                    { 132L, "%(V)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7627), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7628), "Percent volume", "Percent volume", 1L, "%(V)", 1, 23L },
                    { 133L, "%O(V)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7630), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7632), "Permille volume", "Permille volume", 1L, "%O(V)", 1, 23L },
                    { 134L, "ppb(V)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7634), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7634), "Volume parts per billion", "Volume parts per billion", 1L, "Ppb(V)", 1, 23L },
                    { 135L, "ppm(V)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7636), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7636), "Volume parts per million", "Volume parts per million", 1L, "Ppm(V)", 1, 23L },
                    { 136L, "ppt(V)", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7638), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7639), "Volume parts per trillion", "Volume parts per trillion", 1L, "Ppt(V)", 1, 23L },
                    { 137L, "cm3/s", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7640), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7641), "Cubic centimeter/second", "Cubic centimeter/second", 1L, "Cm3/S", 1, 24L },
                    { 138L, "m3/h", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7643), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7644), "Cubic meter/Hour", "Cubic meter/Hour", 1L, "M3/H", 1, 24L },
                    { 139L, "m3/d", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7645), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7646), "Cubic meter/day", "Cubic meter/day", 1L, "M3/D", 1, 24L },
                    { 140L, "m3/s", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7647), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7648), "Cubic meter/second", "Cubic meter/second", 1L, "M3/S", 1, 24L },
                    { 141L, "L/hr", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7649), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7650), "Liter per hour", "Liter per hour", 1L, "L/Hr", 1, 24L },
                    { 142L, "l/min", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7652), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7652), "Liter/Minute", "Liter/Minute", 1L, "L/Min", 1, 24L },
                    { 709L, "int", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7654), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7654), "Integer", "Integer", 1L, "Integer", 1, 131L },
                    { 710L, "dec", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7656), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7656), "Decimal", "Decimal", 1L, "Decimal", 1, 131L },
                    { 717L, "narrative", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7658), 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7659), "Narrative", "Narrative", 1L, "Narrative", 1, 126L }
                });

            migrationBuilder.InsertData(
                table: "DataModelFilters",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FilterId", "LastModifiedBy", "LastModifiedDate", "ModelConfigurationId", "State" },
                values: new object[,]
                {
                    { 1000L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, null, null, 10000L, 1 },
                    { 1001L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, null, null, 10001L, 1 },
                    { 1002L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, null, null, 10002L, 1 },
                    { 1003L, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, null, null, 10003L, 1 }
                });

            migrationBuilder.InsertData(
                table: "DataPointValues",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "CurrencyId", "CurrencyId1", "DatapointTypeId", "DisclosureRequirementId", "IsNarrative", "LanguageId", "LastModifiedBy", "LastModifiedDate", "Name", "OrganizationId", "Purpose", "State", "UnitOfMeasureId" },
                values: new object[,]
                {
                    { 10000L, "E1.GOV-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3430), null, null, null, 17L, true, 1L, null, null, "Disclosure of whether and how climate-related considerations are factored into remuneration of members of administrative, management and supervisory bodies", 1L, "", 1, null },
                    { 10001L, "E1.GOV-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3433), null, null, 2L, 17L, null, 1L, null, null, "Percentage of remuneration recognised that is linked to climate related considerations", 1L, "", 1, null },
                    { 10002L, "E1.GOV-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3436), null, null, null, 17L, true, 1L, null, null, "Explanation of climate-related considerations that are factored into remuneration of members of administrative, management and supervisory bodies ", 1L, "", 1, 38L },
                    { 10003L, "E1-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3439), null, null, 2L, 18L, true, 1L, null, null, "Disclosure of transition plan  for climate change mitigation", 1L, "", 1, null },
                    { 10004L, "E1-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3441), null, null, 2L, 18L, true, 1L, null, null, "Explanation of how targets are compatible with limiting of global warming to one and half degrees Celsius in line with Paris Agreement ", 1L, "", 1, null },
                    { 10005L, "E1-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3443), null, null, 2L, 18L, true, 1L, null, null, "Disclosure of decarbonisation levers and key action ", 1L, "", 1, null },
                    { 10006L, "E1-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3446), null, null, 2L, 18L, true, 1L, null, null, "Disclosure of significant operational expenditures (Opex) and (or) capital expenditures (Capex) required for implementation of action plan ", 1L, "", 1, null },
                    { 10007L, "E1-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3448), null, null, 2L, 18L, null, 1L, null, null, "Financial resources allocated to action plan (OpEx)", 1L, "", 1, null },
                    { 10008L, "E1-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3451), null, null, 3L, 18L, null, 1L, null, null, "Financial resources allocated to action plan (CapEx)", 1L, "", 1, null },
                    { 10009L, "E1-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3453), null, null, 3L, 18L, true, 1L, null, null, "Explanation of potential locked-in GHG emissions from key assets and products and of how locked-in GHG emissions may jeopardise achievement of GHG emission reduction targets and drive transition risk ", 1L, "", 1, null },
                    { 10010L, "E1-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3456), null, null, 2L, 18L, true, 1L, null, null, "Explanation of any objective or plans (CapEx, CapEx plans, OpEx) for aligning economic activities (revenues, CapEx, OpEx) with criteria established in Commission Delegated Regulation 2021/2139 ", 1L, "", 1, null },
                    { 10011L, "E1-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3458), null, null, 2L, 18L, null, 1L, null, null, "Significant CapEx for coal-related economic activities", 1L, "", 1, null },
                    { 10012L, "E1-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3460), null, null, 3L, 18L, null, 1L, null, null, "Significant CapEx for oil-related economic activities", 1L, "", 1, null },
                    { 10013L, "E1-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3462), null, null, 3L, 18L, null, 1L, null, null, "Significant CapEx for gas-related economic activities", 1L, "", 1, null },
                    { 10014L, "E1-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3464), null, null, 3L, 18L, null, 1L, null, null, "Undertaking is excluded from EU Paris-aligned Benchmarks", 1L, "", 1, null },
                    { 10015L, "E1-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3468), null, null, 2L, 18L, true, 1L, null, null, "Explanation of how transition plan is embedded in and aligned with overall business strategy and financial planning ", 1L, "", 1, null },
                    { 10016L, "E1-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3470), null, null, 2L, 18L, null, 1L, null, null, "Transition plan is approved by administrative, management and supervisory bodies", 1L, "", 1, null },
                    { 10017L, "E1-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3472), null, null, 2L, 18L, true, 1L, null, null, "Explanation of progress in implementing transition plan ", 1L, "", 1, null },
                    { 10018L, "E1-1_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3474), null, null, 2L, 18L, null, 1L, null, null, "Date of adoption of transition plan for undertakings not having adopted transition plan yet", 1L, "", 1, null },
                    { 10019L, "E1.SBM-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3476), null, null, null, 19L, null, 1L, null, null, "Type of climate-related risk", 1L, "", 1, 7L },
                    { 10020L, "E1.SBM-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3478), null, null, 2L, 19L, true, 1L, null, null, "Description of scope of resilience analysis ", 1L, "", 1, null },
                    { 10021L, "E1.SBM-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3480), null, null, 2L, 19L, true, 1L, null, null, "Disclosure of how resilience analysis has been conducted ", 1L, "", 1, null },
                    { 10022L, "E1.SBM-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3489), null, null, 2L, 19L, null, 1L, null, null, "Disclosure of how resilience analysis has been conducted ", 1L, "", 1, null },
                    { 10023L, "E1.SBM-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3491), null, null, null, 19L, null, 1L, null, null, "Time horizons applied for resilience analysis", 1L, "", 1, 7L },
                    { 10024L, "E1.SBM-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3493), null, null, 2L, 19L, true, 1L, null, null, "Description of results of resilience analysis ", 1L, "", 1, null },
                    { 10025L, "E1.SBM-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3496), null, null, 2L, 19L, true, 1L, null, null, "Description of ability to adjust or adapt strategy and business model to climate change ", 1L, "", 1, null },
                    { 10026L, "E1.IRO-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3498), null, null, 2L, 20L, true, 1L, null, null, "Description of process in relation to impacts on climate change ", 1L, "", 1, null },
                    { 10027L, "E1.IRO-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3500), null, null, 2L, 20L, true, 1L, null, null, "Description of process in relation to climate-related physical risks in own operations and along value chain ", 1L, "", 1, null },
                    { 10028L, "E1.IRO-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3502), null, null, 2L, 20L, null, 1L, null, null, "Climate-related hazards have been identified over short-, medium- and long-term time horizons", 1L, "", 1, null },
                    { 10029L, "E1.IRO-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3505), null, null, 2L, 20L, null, 1L, null, null, "Undertaking has screened whether assets and business activities may be exposed to climate-related hazards", 1L, "", 1, null },
                    { 10030L, "E1.IRO-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3507), null, null, 2L, 20L, null, 1L, null, null, "Short-, medium- and long-term time horizons have been defined", 1L, "", 1, null },
                    { 10031L, "E1.IRO-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3509), null, null, 2L, 20L, null, 1L, null, null, "Extent to which assets and business activities may be exposed and are sensitive to identified climate-related hazards has been assessed", 1L, "", 1, null },
                    { 10032L, "E1.IRO-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3511), null, null, 2L, 20L, null, 1L, null, null, "Identification of climate-related hazards and assessment of exposure and sensitivity are informed by high emissions climate scenarios", 1L, "", 1, null },
                    { 10033L, "E1.IRO-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3513), null, null, 2L, 20L, true, 1L, null, null, "Explanation of how climate-related scenario analysis has been used to inform identification and assessment of physical risks over short, medium and long-term ", 1L, "", 1, null },
                    { 10034L, "E1.IRO-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3515), null, null, 2L, 20L, true, 1L, null, null, "Description of process in relation to climate-related transition risks and opportunities in own operations and along value chain ", 1L, "", 1, null },
                    { 10035L, "E1.IRO-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3517), null, null, 2L, 20L, null, 1L, null, null, "Transition events have been identified over short-, medium- and long-term time horizons", 1L, "", 1, null },
                    { 10036L, "E1.IRO-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3520), null, null, 2L, 20L, null, 1L, null, null, "Undertaking has screened whether assets and business activities may be exposed to transition events", 1L, "", 1, null },
                    { 10037L, "E1.IRO-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3522), null, null, 2L, 20L, null, 1L, null, null, "Extent to which assets and business activities may be exposed and are sensitive to identified transition events has been assessed", 1L, "", 1, null },
                    { 10038L, "E1.IRO-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3524), null, null, 2L, 20L, null, 1L, null, null, "Identification of transition events and assessment of exposure has been informed by climate-related scenario analysis", 1L, "", 1, null },
                    { 10039L, "E1.IRO-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3526), null, null, 2L, 20L, null, 1L, null, null, "Assets and business activities that are incompatible with or need significant efforts to be compatible with transition to climate-neutral economy have been identified", 1L, "", 1, null },
                    { 10040L, "E1.IRO-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3528), null, null, 2L, 20L, true, 1L, null, null, "Explanation of how climate-related scenario analysis has been used to inform identification and assessment of transition risks and opportunities over short, medium and long-term ", 1L, "", 1, null },
                    { 10041L, "E1.IRO-1_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3530), null, null, 2L, 20L, true, 1L, null, null, "Explanation of how climate scenarios used are compatible with critical climate-related assumptions made in financial statements ", 1L, "", 1, null },
                    { 10042L, "E1.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3533), null, null, 2L, 21L, null, 1L, null, null, "Policies in place to manage its material impacts, risks and opportunities related to climate change mitigation and adaptation [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 10043L, "E1-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3535), null, null, 2L, 21L, null, 1L, null, null, "Sustainability matters addressed by policy for climate change", 1L, "", 1, null },
                    { 10045L, "E1.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3539), null, null, null, 22L, null, 1L, null, null, "Actions and Resources related to climate change mitigation and adaptation [see ESRS 2 MDR-A]", 1L, "", 1, null },
                    { 10046L, "E1-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3541), null, null, 2L, 22L, null, 1L, null, null, "Decarbonisation lever type", 1L, "", 1, null },
                    { 10047L, "E1-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3543), null, null, 2L, 22L, null, 1L, null, null, "Adaptation solution type", 1L, "", 1, null },
                    { 10048L, "E1-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3545), null, null, 2L, 22L, null, 1L, null, null, "Achieved GHG emission reductions", 1L, "", 1, null },
                    { 10049L, "E1-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3547), null, null, null, 22L, null, 1L, null, null, "Expected GHG emission reductions", 1L, "", 1, 79L },
                    { 10050L, "E1-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3549), null, null, null, 22L, true, 1L, null, null, "Explanation of extent to which ability to implement action depends on availability and allocation of resources ", 1L, "", 1, 79L },
                    { 10051L, "E1-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3551), null, null, 2L, 22L, null, 1L, null, null, "Explanation of relationship of significant CapEx and OpEx required to implement actions taken or planned to relevant line items or notes in financial statements ", 1L, "", 1, null },
                    { 10052L, "E1-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3553), null, null, 2L, 22L, true, 1L, null, null, "Explanation of relationship of significant CapEx and OpEx required to implement actions taken or planned to key performance indicators required under Commission Delegated Regulation (EU) 2021/2178 ", 1L, "", 1, null },
                    { 10053L, "E1-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3555), null, null, 2L, 22L, true, 1L, null, null, "Explanation of relationship of significant CapEx and OpEx required to implement actions taken or planned to CapEx plan required by Commission Delegated Regulation (EU) 2021/2178 ", 1L, "", 1, null },
                    { 10055L, "E1.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3562), null, null, null, 23L, null, 1L, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 1, null },
                    { 10056L, "E1-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3565), null, null, 2L, 23L, true, 1L, null, null, "Disclosure of whether and how GHG emissions reduction targets and (or) any other targets have been set to manage material climate-related impacts, risks and opportunities ", 1L, "", 1, null },
                    { 10057L, "E1-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3567), null, null, 2L, 23L, null, 1L, null, null, "Tables: Multiple Dimensions (baseline year and targets; GHG Types, Scope 3 Categories, Decarbonisation levers, entity-specific denominators for intensity value)", 1L, "", 1, null },
                    { 10058L, "E1-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3569), null, null, 1L, 23L, null, 1L, null, null, "Absolute value of total Greenhouse gas emissions reduction", 1L, "", 1, null },
                    { 10059L, "E1-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3571), null, null, null, 23L, null, 1L, null, null, "Percentage of total Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 1, 79L },
                    { 10060L, "E1-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3573), null, null, null, 23L, null, 1L, null, null, "Intensity value of total Greenhouse gas emissions reduction", 1L, "", 1, 38L },
                    { 10061L, "E1-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3575), null, null, null, 23L, null, 1L, null, null, "Absolute value of Scope 1 Greenhouse gas emissions reduction", 1L, "", 1, 710L },
                    { 10062L, "E1-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3576), null, null, null, 23L, null, 1L, null, null, "Percentage of Scope 1 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 1, 79L },
                    { 10063L, "E1-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3579), null, null, null, 23L, null, 1L, null, null, "Intensity value of Scope 1 Greenhouse gas emissions reduction", 1L, "", 1, 38L },
                    { 10064L, "E1-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3581), null, null, null, 23L, null, 1L, null, null, "Absolute value of location-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 1, 710L },
                    { 10065L, "E1-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3583), null, null, null, 23L, null, 1L, null, null, "Percentage of location-based Scope 2 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 1, 79L },
                    { 10066L, "E1-4_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3585), null, null, null, 23L, null, 1L, null, null, "Intensity value of location-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 1, 38L },
                    { 10067L, "E1-4_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3587), null, null, null, 23L, null, 1L, null, null, "Absolute value of market-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 1, 710L },
                    { 10068L, "E1-4_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3589), null, null, null, 23L, null, 1L, null, null, "Percentage of market-based Scope 2 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 1, 79L },
                    { 10069L, "E1-4_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3591), null, null, null, 23L, null, 1L, null, null, "Intensity value of market-based Scope 2 Greenhouse gas emissions reduction", 1L, "", 1, 38L },
                    { 10070L, "E1-4_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3594), null, null, null, 23L, null, 1L, null, null, "Absolute value of Scope 3 Greenhouse gas emissions reduction", 1L, "", 1, 710L },
                    { 10071L, "E1-4_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3596), null, null, null, 23L, null, 1L, null, null, "Percentage of Scope 3 Greenhouse gas emissions reduction (as of emissions of base year)", 1L, "", 1, 79L },
                    { 10072L, "E1-4_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3598), null, null, null, 23L, null, 1L, null, null, "Intensity value of Scope 3 Greenhouse gas emissions reduction", 1L, "", 1, 38L },
                    { 10073L, "E1-4_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3600), null, null, null, 23L, true, 1L, null, null, "Explanation of how consistency of GHG emission reduction targets with GHG inventory boundaries has been ensured ", 1L, "", 1, 710L },
                    { 10074L, "E1-4_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3602), null, null, 2L, 23L, true, 1L, null, null, "Disclosure of past progress made in meeting target before current base year ", 1L, "", 1, null },
                    { 10075L, "E1-4_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3604), null, null, 2L, 23L, true, 1L, null, null, "Description of how it has been ensured that baseline value is representative in terms of activities covered and influences from external factors ", 1L, "", 1, null },
                    { 10076L, "E1-4_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3606), null, null, 2L, 23L, true, 1L, null, null, "Description of how new baseline value affects new target, its achievement and presentation of progress over time ", 1L, "", 1, null },
                    { 10077L, "E1-4_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3609), null, null, 2L, 23L, null, 1L, null, null, "GHG emission reduction target is science based and compatible with limiting global warming to one and half degrees Celsius", 1L, "", 1, null },
                    { 10078L, "E1-4_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3611), null, null, 2L, 23L, true, 1L, null, null, "Description of expected decarbonisation levers and their overall quantitative contributions to achieve GHG emission reduction target ", 1L, "", 1, null },
                    { 10079L, "E1-4_24", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3613), null, null, 2L, 23L, true, 1L, null, null, "Diverse range of climate scenarios have been considered to detect relevant environmental, societal, technology, market and policy-related developments and determine decarbonisation levers", 1L, "", 1, null },
                    { 10080L, "E1.MDR-T_14-19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3615), null, null, 2L, 23L, null, 1L, null, null, "Disclosure to be reported if the undertaking has not set any measurable outcome-oriented targets", 1L, "", 1, null },
                    { 10081L, "E1-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3617), null, null, null, 24L, null, 1L, null, null, "Total energy consumption related to own operations", 1L, "", 1, null },
                    { 10082L, "E1-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3619), null, null, null, 24L, null, 1L, null, null, "Total energy consumption from fossil sources", 1L, "", 1, 44L },
                    { 10083L, "E1-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3621), null, null, null, 24L, null, 1L, null, null, "Total energy consumption from nuclear sources", 1L, "", 1, 44L },
                    { 10084L, "E1-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3623), null, null, null, 24L, null, 1L, null, null, "Percentage of energy consumption from nuclear sources in total energy consumption", 1L, "", 1, 44L },
                    { 10085L, "E1-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3624), null, null, null, 24L, null, 1L, null, null, "Total energy consumption from renewable sources", 1L, "", 1, 38L },
                    { 10086L, "E1-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3631), null, null, null, 24L, null, 1L, null, null, "Fuel consumption from renewable sources", 1L, "", 1, 44L },
                    { 10087L, "E1-5_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3633), null, null, null, 24L, null, 1L, null, null, "Consumption of purchased or acquired electricity, heat, steam, and cooling from renewable sources", 1L, "", 1, 44L },
                    { 10088L, "E1-5_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3635), null, null, null, 24L, null, 1L, null, null, "Consumption of self-generated non-fuel renewable energy", 1L, "", 1, 44L },
                    { 10089L, "E1-5_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3636), null, null, null, 24L, null, 1L, null, null, "Percentage of renewable sources in total energy consumption", 1L, "", 1, 44L },
                    { 10090L, "E1-5_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3638), null, null, null, 24L, null, 1L, null, null, "Fuel consumption from coal and coal products", 1L, "", 1, 38L },
                    { 10091L, "E1-5_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3642), null, null, null, 24L, null, 1L, null, null, "Fuel consumption from crude oil and petroleum products", 1L, "", 1, 44L },
                    { 10092L, "E1-5_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3644), null, null, null, 24L, null, 1L, null, null, "Fuel consumption from natural gas", 1L, "", 1, 44L },
                    { 10093L, "E1-5_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3646), null, null, null, 24L, null, 1L, null, null, "Fuel consumption from other fossil sources", 1L, "", 1, 44L },
                    { 10094L, "E1-5_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3648), null, null, null, 24L, null, 1L, null, null, "Consumption of purchased or acquired electricity, heat, steam, or cooling from fossil sources", 1L, "", 1, 44L },
                    { 10095L, "E1-5_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3649), null, null, null, 24L, null, 1L, null, null, "Percentage of fossil sources in total energy consumption", 1L, "", 1, 44L },
                    { 10096L, "E1-5_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3651), null, null, null, 24L, null, 1L, null, null, "Non-renewable energy production", 1L, "", 1, 38L },
                    { 10097L, "E1-5_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3653), null, null, null, 24L, null, 1L, null, null, "Renewable energy production", 1L, "", 1, 44L },
                    { 10098L, "E1-5_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3656), null, null, null, 24L, null, 1L, null, null, "Energy intensity from activities in high climate impact sectors (total energy consumption per net revenue)", 1L, "", 1, 44L },
                    { 10099L, "E1-5_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3658), null, null, null, 24L, null, 1L, null, null, "Total energy consumption from activities in high climate impact sectors", 1L, "", 1, 38L },
                    { 10100L, "E1-5_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3660), null, null, null, 24L, null, 1L, null, null, "High climate impact sectors used to determine energy intensity", 1L, "", 1, 44L },
                    { 10101L, "E1-5_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3662), null, null, 2L, 24L, true, 1L, null, null, "Disclosure of reconciliation to relevant line item or notes in financial statements of net revenue from activities in high climate impact sectors ", 1L, "", 1, null },
                    { 10102L, "E1-5_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3664), null, null, 2L, 24L, null, 1L, null, null, "Net revenue from activities in high climate impact sectors", 1L, "", 1, null },
                    { 10103L, "E1-5_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3666), null, null, 3L, 24L, null, 1L, null, null, "Net revenue from activities other than in high climate impact sectors", 1L, "", 1, null },
                    { 10104L, "E1-6_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3668), null, null, 3L, 25L, null, 1L, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - GHG emissions per scope [table]", 1L, "", 1, null },
                    { 10105L, "E1-6_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3671), null, null, 1L, 25L, null, 1L, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - financial and operational control [table]", 1L, "", 1, 79L },
                    { 10106L, "E1-6_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3673), null, null, 1L, 25L, null, 1L, null, null, "Disaggregation of GHG emissions - by country, operating segments, economic activity, subsidiary, GHG category or source type", 1L, "", 1, 79L },
                    { 10107L, "E1-6_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3675), null, null, 1L, 25L, null, 1L, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - Scope 3 GHG emissions (GHG Protocol) [table]", 1L, "", 1, 79L },
                    { 10108L, "E1-6_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3677), null, null, 1L, 25L, null, 1L, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - Scope 3 GHG emissions (ISO 14064-1) [table]", 1L, "", 1, 79L },
                    { 10109L, "E1-6_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3679), null, null, 1L, 25L, null, 1L, null, null, "Gross Scopes 1, 2, 3 and Total GHG emissions - total GHG emissions - value chain [table]", 1L, "", 1, 79L },
                    { 10110L, "E1-6_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3681), null, null, 1L, 25L, null, 1L, null, null, "Gross Scope 1 greenhouse gas emissions ", 1L, "", 1, 79L },
                    { 10111L, "E1-6_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3684), null, null, null, 25L, null, 1L, null, null, "Percentage of Scope 1 GHG emissions from regulated emission trading schemes", 1L, "", 1, 79L },
                    { 10112L, "E1-6_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3686), null, null, null, 25L, null, 1L, null, null, "Gross location-based Scope 2 greenhouse gas emissions", 1L, "", 1, 38L },
                    { 10113L, "E1-6_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3688), null, null, null, 25L, null, 1L, null, null, "Gross market-based Scope 2 greenhouse gas emissions", 1L, "", 1, 79L },
                    { 10114L, "E1-6_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3690), null, null, null, 25L, null, 1L, null, null, "Gross Scope 3 greenhouse gas emissions", 1L, "", 1, 79L },
                    { 10115L, "E1-6_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3692), null, null, null, 25L, null, 1L, null, null, "Total GHG emissions location based", 1L, "", 1, 79L },
                    { 10116L, "E1-6_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3694), null, null, null, 25L, null, 1L, null, null, "Total GHG emissions market based", 1L, "", 1, 79L },
                    { 10117L, "E1-6_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3696), null, null, null, 25L, true, 1L, null, null, "Disclosure of significant changes in definition of what constitutes reporting undertaking and its value chain and explanation of their effect on year-to-year comparability of reported GHG emissions", 1L, "", 1, 79L },
                    { 10118L, "E1-6_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3703), null, null, 2L, 25L, true, 1L, null, null, "Disclosure of methodologies, significant assumptions and emissions factors used to calculate or measure GHG emissions ", 1L, "", 1, null },
                    { 10119L, "E1-6_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3705), null, null, 2L, 25L, true, 1L, null, null, "Disclosure of the effects of significant events and changes in circumstances (relevant to its GHG emissions) that occur between the reporting dates of the entities in its value chain and the date of the undertaking’s general purpose financial statements", 1L, "", 1, null },
                    { 10120L, "E1-6_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3707), null, null, 2L, 25L, null, 1L, null, null, "biogenic emissions of CO2 from the combustion or bio-degradation of biomassnot included in Scope 1 GHG emissions", 1L, "", 1, null },
                    { 10121L, "E1-6_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3709), null, null, null, 25L, null, 1L, null, null, "Percentage of contractual instruments, Scope 2 GHG emissions", 1L, "", 1, 79L },
                    { 10122L, "E1-6_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3711), null, null, null, 25L, null, 1L, null, null, "Disclosure of types of contractual instruments, Scope 2 GHG emissions ", 1L, "", 1, 38L },
                    { 10123L, "E1-6_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3713), null, null, null, 25L, null, 1L, null, null, "Percentage of market-based Scope 2 GHG emissions linked to purchased electricity bundled with instruments", 1L, "", 1, 38L },
                    { 10124L, "E1-6_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3715), null, null, null, 25L, null, 1L, null, null, "Percentage of contractual instruments used for sale and purchase of energy bundled with attributes about energy generation in relation to Scope 2 GHG emissions", 1L, "", 1, 38L },
                    { 10125L, "E1-6_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3718), null, null, null, 25L, null, 1L, null, null, "Percentage of contractual instruments used for sale and purchase of unbundled energy attribute claims in relation to Scope 2 GHG emissions", 1L, "", 1, 38L },
                    { 10126L, "E1-6_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3720), null, null, null, 25L, true, 1L, null, null, "Disclosure of types of contractual instruments used for sale and purchase of energy bundled with attributes about energy generation or for unbundled energy attribute claims ", 1L, "", 1, 38L },
                    { 10127L, "E1-6_24", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3722), null, null, 2L, 25L, null, 1L, null, null, "Biogenic emissions of CO2 from combustion or bio-degradation of biomass not included in Scope 2 GHG emissions", 1L, "", 1, null },
                    { 10128L, "E1-6_25", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3724), null, null, null, 25L, null, 1L, null, null, "Percentage of GHG Scope 3 calculated using primary data ", 1L, "", 1, 79L },
                    { 10129L, "E1-6_26", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3725), null, null, null, 25L, true, 1L, null, null, "Disclosure of why Scope 3 GHG emissions category has been excluded ", 1L, "", 1, 38L },
                    { 10130L, "E1-6_27", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3727), null, null, 2L, 25L, null, 1L, null, null, "List of Scope 3 GHG emissions categories included in inventory", 1L, "", 1, null },
                    { 10131L, "E1-6_28", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3729), null, null, 2L, 25L, null, 1L, null, null, "Biogenic emissions of CO2 from combustion or bio-degradation of biomass that occur in value chain not included in Scope 3 GHG emissions", 1L, "", 1, null },
                    { 10132L, "E1-6_29", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3732), null, null, null, 25L, true, 1L, null, null, "Disclosure of reporting boundaries considered and calculation methods for estimating Scope 3 GHG emissions", 1L, "", 1, 79L },
                    { 10133L, "E1-6_30", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3734), null, null, 2L, 25L, null, 1L, null, null, "GHG emissions intensity, location-based (total GHG emissions per net revenue)", 1L, "", 1, null },
                    { 10134L, "E1-6_31", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3736), null, null, null, 25L, null, 1L, null, null, "GHG emissions intensity, market-based (total GHG emissions per net revenue)", 1L, "", 1, 79L },
                    { 10135L, "E1-6_32", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3738), null, null, null, 25L, true, 1L, null, null, "Disclosure of reconciliation to financial statements of net revenue used for calculation of GHG emissions intensity ", 1L, "", 1, 79L },
                    { 10136L, "E1-6_33", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3740), null, null, 2L, 25L, null, 1L, null, null, "Net revenue", 1L, "", 1, null },
                    { 10137L, "E1-6_34", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3742), null, null, 3L, 25L, null, 1L, null, null, "Net revenue used to calculate GHG intensity", 1L, "", 1, null },
                    { 10138L, "E1-6_35", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3744), null, null, 3L, 25L, null, 1L, null, null, "Net revenue other than used to calculate GHG intensity", 1L, "", 1, null },
                    { 10139L, "E1-7_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3747), null, null, 3L, 26L, true, 1L, null, null, "Disclosure of GHG removals and storage resulting from projects developed in own operations or contributed to in upstream and downstream value chain ", 1L, "", 1, null },
                    { 10140L, "E1-7_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3749), null, null, 2L, 26L, true, 1L, null, null, "Disclosure of GHG emission reductions or removals from climate change mitigation projects outside value chain financed or to be financed through any purchase of carbon credits ", 1L, "", 1, null },
                    { 10141L, "E1-7_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3751), null, null, 2L, 26L, null, 1L, null, null, "Removals and carbon credits are used", 1L, "", 1, null },
                    { 10142L, "E1-7_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3753), null, null, 2L, 26L, null, 1L, null, null, "GHG Removals and storage Activity by undertaking scope (breakdown by own operations and value chain) and by removal and storage activity", 1L, "", 1, null },
                    { 10143L, "E1-7_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3755), null, null, 1L, 26L, null, 1L, null, null, "Total GHG removals and storage", 1L, "", 1, null },
                    { 10144L, "E1-7_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3757), null, null, null, 26L, null, 1L, null, null, "GHG emissions associated with removal activity", 1L, "", 1, 79L },
                    { 10145L, "E1-7_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3760), null, null, null, 26L, null, 1L, null, null, "Reversals", 1L, "", 1, 79L },
                    { 10146L, "E1-7_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3762), null, null, null, 26L, true, 1L, null, null, "Disclosure of calculation assumptions, methodologies and frameworks applied (GHG removals and storage) ", 1L, "", 1, 79L },
                    { 10147L, "E1-7_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3763), null, null, 2L, 26L, null, 1L, null, null, "Removal activity has been converted into carbon credits and sold on to other parties on voluntary market", 1L, "", 1, null },
                    { 10148L, "E1-7_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3765), null, null, 2L, 26L, null, 1L, null, null, "Total amount of carbon credits outside value chain that are verified against recognised quality standards and cancelled", 1L, "", 1, null },
                    { 10149L, "E1-7_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3767), null, null, null, 26L, null, 1L, null, null, "Total amount of carbon credits outside value chain planned to be cancelled in future", 1L, "", 1, 79L },
                    { 10150L, "E1-7_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3773), null, null, null, 26L, true, 1L, null, null, "Disclosure of extent of use and quality criteria used for carbon credits ", 1L, "", 1, 79L },
                    { 10151L, "E1-7_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3775), null, null, 2L, 26L, null, 1L, null, null, "Percentage of reduction projects", 1L, "", 1, null },
                    { 10152L, "E1-7_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3778), null, null, null, 26L, null, 1L, null, null, "Percentage of removal projects", 1L, "", 1, 38L },
                    { 10153L, "E1-7_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3780), null, null, null, 26L, null, 1L, null, null, "Type of carbon credits from removal projects", 1L, "", 1, 38L },
                    { 10154L, "E1-7_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3782), null, null, 2L, 26L, null, 1L, null, null, "Percentage for recognised quality standard", 1L, "", 1, null },
                    { 10155L, "E1-7_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3783), null, null, null, 26L, null, 1L, null, null, "Percentage issued from projects in European Union", 1L, "", 1, 38L },
                    { 10156L, "E1-7_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3785), null, null, null, 26L, null, 1L, null, null, "Percentage that qualifies as corresponding adjustment", 1L, "", 1, 38L },
                    { 10157L, "E1-7_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3787), null, null, null, 26L, null, 1L, null, null, "Date when carbon credits outside value chain are planned to be cancelled", 1L, "", 1, 38L },
                    { 10158L, "E1-7_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3789), null, null, null, 26L, true, 1L, null, null, "Explanation of scope, methodologies and frameworks applied and how residual GHG emissions are intended to be neutralised ", 1L, "", 1, 7L },
                    { 10159L, "E1-7_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3792), null, null, 2L, 26L, null, 1L, null, null, "Public claims of GHG neutrality that involve use of carbon credits have been made", 1L, "", 1, null },
                    { 10160L, "E1-7_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3794), null, null, 2L, 26L, null, 1L, null, null, "Public claims of GHG neutrality that involve use of carbon credits are accompanied by GHG emission reduction targets", 1L, "", 1, null },
                    { 10161L, "E1-7_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3796), null, null, 2L, 26L, null, 1L, null, null, "Claims of GHG neutrality and reliance on carbon credits neither impede nor reduce achievement of GHG emission reduction targets or net zero target", 1L, "", 1, null },
                    { 10162L, "E1-7_24", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3798), null, null, 2L, 26L, true, 1L, null, null, "Explanation of whether and how public claims of GHG neutrality that involve use of carbon credits are accompanied by GHG emission reduction targets and how claims of GHG neutrality and reliance on carbon credits neither impede nor reduce achievement of GHG emission reduction targets or net zero target ", 1L, "", 1, null },
                    { 10163L, "E1-7_25", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3800), null, null, 2L, 26L, true, 1L, null, null, "Explanation of credibility and integrity of carbon credits used ", 1L, "", 1, null },
                    { 10164L, "E1-8_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3802), null, null, 2L, 27L, null, 1L, null, null, "Carbon pricing scheme by type", 1L, "", 1, null },
                    { 10165L, "E1-8_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3804), null, null, 1L, 27L, null, 1L, null, null, "Type of internal carbon pricing scheme", 1L, "", 1, null },
                    { 10166L, "E1-8_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3807), null, null, 2L, 27L, null, 1L, null, null, "Description of specific scope of application of carbon pricing scheme ", 1L, "", 1, null },
                    { 10167L, "E1-8_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3809), null, null, 2L, 27L, null, 1L, null, null, "Carbon price applied for each metric tonne of greenhouse gas emission", 1L, "", 1, null },
                    { 10168L, "E1-8_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3811), null, null, 3L, 27L, null, 1L, null, null, "Description of critical assumptions made to determine carbon price applied ", 1L, "", 1, null },
                    { 10169L, "E1-8_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3813), null, null, 2L, 27L, null, 1L, null, null, "Percentage of gross Scope 1 greenhouse gas emissions covered by internal carbon pricing scheme", 1L, "", 1, null },
                    { 10170L, "E1-8_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3815), null, null, null, 27L, null, 1L, null, null, "Percentage of gross Scope 2 greenhouse gas emissions covered by internal carbon pricing scheme", 1L, "", 1, 38L },
                    { 10171L, "E1-8_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3817), null, null, null, 27L, null, 1L, null, null, "Percentage of gross Scope 3 greenhouse gas emissions covered by internal carbon pricing scheme", 1L, "", 1, 38L },
                    { 10172L, "E1-8_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3819), null, null, null, 27L, null, 1L, null, null, "Disclosure of whether and how carbon price used in internal carbon pricing scheme is consistent with carbon price used in financial statements ", 1L, "", 1, 38L },
                    { 10173L, "E1-9_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3822), null, null, 2L, 28L, null, 1L, null, null, "Assets at material physical risk before considering climate change adaptation actions", 1L, "", 1, null },
                    { 10174L, "E1-9_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3824), null, null, 3L, 28L, null, 1L, null, null, "Assets at acute material physical risk before considering climate change adaptation actions", 1L, "", 1, null },
                    { 10175L, "E1-9_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3826), null, null, 3L, 28L, null, 1L, null, null, "Assets at chronic material physical risk before considering climate change adaptation actions", 1L, "", 1, null },
                    { 10176L, "E1-9_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3828), null, null, 3L, 28L, null, 1L, null, null, "Percentage of assets at material physical risk before considering climate change adaptation actions", 1L, "", 1, null },
                    { 10177L, "E1-9_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3830), null, null, null, 28L, true, 1L, null, null, "Disclosure of location of significant assets at material physical risk ", 1L, "", 1, 38L },
                    { 10178L, "E1-9_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3832), null, null, 2L, 28L, null, 1L, null, null, "Disclosure of location of its significant assets at material physical risk (disaggregated by NUTS codes)", 1L, "", 1, null },
                    { 10179L, "E1-9_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3833), null, null, 2L, 28L, null, 1L, null, null, "Percentage of assets at material physical risk addressed by climate change adaptation actions", 1L, "", 1, null },
                    { 10180L, "E1-9_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3836), null, null, null, 28L, null, 1L, null, null, "Net revenue from business activities at material physical risk", 1L, "", 1, 38L },
                    { 10181L, "E1-9_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3838), null, null, 3L, 28L, null, 1L, null, null, "Percentage of net revenue from business activities at material physical risk", 1L, "", 1, null },
                    { 10182L, "E1-9_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3843), null, null, null, 28L, true, 1L, null, null, "Disclosure of whether and how anticipated financial effects for assets and business activities at material physical risk have been assessed ", 1L, "", 1, 38L },
                    { 10183L, "E1-9_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3845), null, null, 2L, 28L, true, 1L, null, null, "Disclosure of whether and how assessment of assets and business activities considered to be at material physical risk relies on or is part of process to determine material physical risk and to determine climate scenarios ", 1L, "", 1, null },
                    { 10184L, "E1-9_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3848), null, null, 2L, 28L, true, 1L, null, null, "Disclosure of risk factors for net revenue from business activities at material physical risk ", 1L, "", 1, null },
                    { 10185L, "E1-9_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3850), null, null, 2L, 28L, true, 1L, null, null, "Disclosure of magnitude of anticipated financial effects in terms of margin erosion for business activities at material physical risk ", 1L, "", 1, null },
                    { 10186L, "E1-9_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3852), null, null, 2L, 28L, null, 1L, null, null, "Assets at material transition risk before considering climate mitigation actions", 1L, "", 1, null },
                    { 10187L, "E1-9_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3855), null, null, 3L, 28L, null, 1L, null, null, "Percentage of assets at material transition risk before considering climate mitigation actions", 1L, "", 1, null },
                    { 10188L, "E1-9_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3856), null, null, null, 28L, null, 1L, null, null, "Percentage of assets at material transition risk addressed by climate change mitigation actions", 1L, "", 1, 38L },
                    { 10189L, "E1-9_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3858), null, null, null, 28L, null, 1L, null, null, "Total carrying amount of real estate assets by energy efficiency classes", 1L, "", 1, 38L },
                    { 10190L, "E1-9_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3861), null, null, 3L, 28L, true, 1L, null, null, "Disclosure of whether and how potential effects on future financial performance and position for assets and business activities at material transition risk have been assessed ", 1L, "", 1, null },
                    { 10191L, "E1-9_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3863), null, null, 2L, 28L, true, 1L, null, null, "Disclosure of whether and how assessment of assets and business activities considered to be at material transition risk relies on or is part of process to determine material transition risks and to determine scenarios ", 1L, "", 1, null },
                    { 10192L, "E1-9_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3865), null, null, 2L, 28L, null, 1L, null, null, "Estimated amount of potentially stranded assets", 1L, "", 1, null },
                    { 10193L, "E1-9_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3868), null, null, 3L, 28L, null, 1L, null, null, "Percentage of estimated share of potentially stranded assets of total assets at material transition risk", 1L, "", 1, null },
                    { 10194L, "E1-9_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3869), null, null, null, 28L, null, 1L, null, null, "Total carrying amount of real estate assets for which energy consumption is based on internal estimates", 1L, "", 1, 38L },
                    { 10195L, "E1-9_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3871), null, null, 3L, 28L, null, 1L, null, null, "Liabilities from material transition risks that may have to be recognised in financial statements", 1L, "", 1, null },
                    { 10196L, "E1-9_24", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3873), null, null, 3L, 28L, null, 1L, null, null, "Number of Scope 1 GHG emission allowances within regulated emission trading schemes", 1L, "", 1, null },
                    { 10197L, "E1-9_25", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3875), null, null, null, 28L, null, 1L, null, null, "Number of emission allowances stored (from previous allowances) at beginning of reporting period", 1L, "", 1, 709L },
                    { 10198L, "E1-9_26", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3877), null, null, null, 28L, null, 1L, null, null, "Potential future liabilities, based on existing contractual agreements, associated with carbon credits planned to be cancelled in near future", 1L, "", 1, 709L },
                    { 10199L, "E1-9_27", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3879), null, null, 3L, 28L, null, 1L, null, null, "Monetised gross Scope 1 and 2 GHG emissions", 1L, "", 1, null },
                    { 10200L, "E1-9_28", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3882), null, null, 3L, 28L, null, 1L, null, null, "Monetised total GHG emissions", 1L, "", 1, null },
                    { 10201L, "E1-9_29", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3884), null, null, 3L, 28L, null, 1L, null, null, "Net revenue from business activities at material transition risk", 1L, "", 1, null },
                    { 10202L, "E1-9_30", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3886), null, null, 3L, 28L, null, 1L, null, null, "Net revenue from customers operating in coal-related activities", 1L, "", 1, null },
                    { 10203L, "E1-9_31", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3888), null, null, 3L, 28L, null, 1L, null, null, "Net revenue from customers operating in oil-related activities", 1L, "", 1, null },
                    { 10204L, "E1-9_32", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3890), null, null, 3L, 28L, null, 1L, null, null, "Net revenue from customers operating in gas-related activities", 1L, "", 1, null },
                    { 10205L, "E1-9_33", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3892), null, null, 3L, 28L, null, 1L, null, null, "Percentage of net revenue from customers operating in coal-related activities", 1L, "", 1, null },
                    { 10206L, "E1-9_34", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3894), null, null, null, 28L, null, 1L, null, null, "Percentage of net revenue from customers operating in oil-related activities", 1L, "", 1, 38L },
                    { 10207L, "E1-9_35", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3897), null, null, null, 28L, null, 1L, null, null, "Percentage of net revenue from customers operating in gas-related activities", 1L, "", 1, 38L },
                    { 10208L, "E1-9_36", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3899), null, null, null, 28L, null, 1L, null, null, "Percentage of net revenue from business activities at material transition risk", 1L, "", 1, 38L },
                    { 10209L, "E1-9_37", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3901), null, null, null, 28L, true, 1L, null, null, "Disclosure of risk factors for net revenue from business activities at material transition risk ", 1L, "", 1, 38L },
                    { 10210L, "E1-9_38", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3903), null, null, 2L, 28L, null, 1L, null, null, "Disclosure of anticipated financial effects in terms of margin erosion for business activities at material transition risk ", 1L, "", 1, null },
                    { 10211L, "E1-9_39", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3905), null, null, 2L, 28L, true, 1L, null, null, "Disclosure of reconciliations with financial statements of significant amounts of assets and net revenue at material physical risk ", 1L, "", 1, null },
                    { 10212L, "E1-9_40", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3907), null, null, 2L, 28L, true, 1L, null, null, "Disclosure of reconciliations with financial statements of significant amounts of assets, liabilities and net revenue at material transition risk ", 1L, "", 1, null },
                    { 10213L, "E1-9_41", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3909), null, null, 2L, 28L, null, 1L, null, null, "Expected cost savings from climate change mitigation actions", 1L, "", 1, null },
                    { 10214L, "E1-9_42", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3915), null, null, 3L, 28L, null, 1L, null, null, "Expected cost savings from climate change adaptation actions", 1L, "", 1, null },
                    { 10215L, "E1-9_43", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3917), null, null, 3L, 28L, null, 1L, null, null, "Potential market size of low-carbon products and services or adaptation solutions to which undertaking has or may have access", 1L, "", 1, null },
                    { 10216L, "E1-9_44", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3919), null, null, 3L, 28L, null, 1L, null, null, "Expected changes to net revenue from low-carbon products and services or adaptation solutions to which undertaking has or may have access", 1L, "", 1, null },
                    { 10218L, "BP-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3923), null, null, 2L, 1L, true, 1L, null, null, "Scope of consolidation of consolidated sustainability statement is same as for financial statements", 1L, "", 1, null },
                    { 10219L, "BP-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3925), null, null, 2L, 1L, true, 1L, null, null, "Indication of subsidiary undertakings included in consolidation that are exempted from individual or consolidated sustainability reporting ", 1L, "", 1, null },
                    { 10220L, "BP-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3927), null, null, 2L, 1L, true, 1L, null, null, "Disclosure of extent to which sustainability statement covers upstream and downstream value chain ", 1L, "", 1, null },
                    { 10221L, "BP-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3930), null, null, 2L, 1L, null, 1L, null, null, "Option to omit specific piece of information corresponding to intellectual property, know-how or results of innovation has been used", 1L, "", 1, null },
                    { 10222L, "BP-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3932), null, null, 2L, 1L, null, 1L, null, null, "Option allowed by Member State to omit disclosure of impending developments or matters in course of negotiation has been used", 1L, "", 1, null },
                    { 10223L, "BP-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3934), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of definitions of medium- or long-term time horizons ", 1L, "", 1, null },
                    { 10224L, "BP-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3936), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of reasons for applying different definitions of time horizons ", 1L, "", 1, null },
                    { 10225L, "BP-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3938), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of metrics that include value chain data estimated using indirect sources ", 1L, "", 1, null },
                    { 10226L, "BP-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3940), null, null, 2L, 2L, true, 1L, null, null, "Description of basis for preparation of metrics that include value chain data estimated using indirect sources ", 1L, "", 1, null },
                    { 10227L, "BP-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3942), null, null, 2L, 2L, true, 1L, null, null, "Description of resulting level of accuracy of metrics that include value chain data estimated using indirect sources ", 1L, "", 1, null },
                    { 10228L, "BP-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3945), null, null, 2L, 2L, true, 1L, null, null, "Description of planned actions to improve accuracy in future of metrics that include value chain data estimated using indirect sources ", 1L, "", 1, null },
                    { 10229L, "BP-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3947), null, null, 2L, 2L, null, 1L, null, null, "Disclosure of quantitative metrics and monetary amounts disclosed that are subject to high level of measurement uncertainty ", 1L, "", 1, null },
                    { 10230L, "BP-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3949), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of sources of measurement uncertainty ", 1L, "", 1, null },
                    { 10231L, "BP-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3951), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of assumptions, approximations and judgements made in measurement ", 1L, "", 1, null },
                    { 10232L, "BP-2_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3953), null, null, 2L, 2L, true, 1L, null, null, "Explanation of changes in preparation and presentation of sustainability information and reasons for them ", 1L, "", 1, null },
                    { 10233L, "BP-2_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3955), null, null, 2L, 2L, null, 1L, null, null, "Adjustment of comparative information for one or more prior periods is impracticable", 1L, "", 1, null },
                    { 10234L, "BP-2_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3958), null, null, 2L, 2L, null, 1L, null, null, "Disclosure of difference between figures disclosed in preceding period and revised comparative figures ", 1L, "", 1, null },
                    { 10235L, "BP-2_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3961), null, null, null, 2L, true, 1L, null, null, "Disclosure of nature of prior period material errors ", 1L, "", 1, 709L },
                    { 10236L, "BP-2_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3963), null, null, 2L, 2L, null, 1L, null, null, "Disclosure of corrections for prior periods included in sustainability statement ", 1L, "", 1, null },
                    { 10237L, "BP-2_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3965), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of why correction of prior period errors is not practicable ", 1L, "", 1, null },
                    { 10238L, "BP-2_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3967), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of other legislation or generally accepted sustainability reporting standards and frameworks based on which information has been included in sustainability statement ", 1L, "", 1, null },
                    { 10239L, "BP-2_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3969), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of reference to paragraphs of standard or framework applied ", 1L, "", 1, null },
                    { 10240L, "BP-2_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3971), null, null, 2L, 2L, null, 1L, null, null, "European standards approved by European Standardisation System (ISO/IEC or CEN/CENELEC standards) have been relied on", 1L, "", 1, null },
                    { 10241L, "BP-2_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3974), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of extent to which data and processes that are used for sustainability reporting purposes have been verified by external assurance provider and found to conform to corresponding ISO/IEC or CEN/CENELEC standard ", 1L, "", 1, null },
                    { 10242L, "BP-2_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3976), null, null, 2L, 2L, true, 1L, null, null, "List of DRs or DPs incorporated by reference", 1L, "", 1, null },
                    { 10243L, "BP-2_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3978), null, null, 2L, 2L, null, 1L, null, null, "Topics (E4, S1, S2, S3, S4) have been assessed to be material ", 1L, "", 1, null },
                    { 10244L, "BP-2_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3980), null, null, 2L, 2L, null, 1L, null, null, "List of sustainability matters assessed to be material (phase-in)", 1L, "", 1, null },
                    { 10245L, "BP-2_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3982), null, null, 2L, 2L, true, 1L, null, null, "Disclosure of how business model and strategy take account of impacts related to sustainability matters assessed to be material (phase-in) ", 1L, "", 1, null },
                    { 10246L, "BP-2_24", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3987), null, null, 2L, 2L, null, 1L, null, null, "Description of any time-bound targets set related to sustainability matters assessed to be material (phase-in) and progress made towards achieving those targets ", 1L, "", 1, null },
                    { 10247L, "BP-2_25", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3989), null, null, 2L, 2L, true, 1L, null, null, "Description of policies related to sustainability matters assessed to be material (phase-in) ", 1L, "", 1, null },
                    { 10248L, "BP-2_26", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3992), null, null, 2L, 2L, true, 1L, null, null, "Description of actions taken to identify, monitor, prevent, mitigate, remediate or bring end to actual or potential adverse impacts related to sustainability matters assessed to be material (phase-in) and result of such actions ", 1L, "", 1, null },
                    { 10249L, "BP-2_27", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3994), null, null, 2L, 2L, null, 1L, null, null, "Disclosure of metrics related to sustainability matters assessed to be material (phase-in) ", 1L, "", 1, null },
                    { 10250L, "GOV-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3996), null, null, 2L, 3L, null, 1L, null, null, "Number of executive members", 1L, "", 1, null },
                    { 10251L, "GOV-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(3998), null, null, null, 3L, null, 1L, null, null, "Number of non-executive members", 1L, "", 1, 709L },
                    { 10252L, "GOV-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4000), null, null, null, 3L, true, 1L, null, null, "Information about representation of employees and other workers ", 1L, "", 1, 709L },
                    { 10253L, "GOV-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4002), null, null, 2L, 3L, true, 1L, null, null, "Information about member's experience relevant to sectors, products and geographic locations of undertaking ", 1L, "", 1, null },
                    { 10254L, "GOV-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4004), null, null, 2L, 3L, null, 1L, null, null, "Percentage of members of administrative, management and supervisory bodies by gender and other aspects of diversity", 1L, "", 1, null },
                    { 10255L, "GOV-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4006), null, null, null, 3L, null, 1L, null, null, "Board's gender diversity ratio", 1L, "", 1, 38L },
                    { 10256L, "GOV-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4008), null, null, null, 3L, null, 1L, null, null, "Percentage of independent board members", 1L, "", 1, 38L },
                    { 10257L, "GOV-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4010), null, null, null, 3L, true, 1L, null, null, "Information about identity of administrative, management and supervisory bodies or individual(s) within body responsible for oversight of impacts, risks and opportunities ", 1L, "", 1, 38L },
                    { 10258L, "GOV-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4012), null, null, 2L, 3L, true, 1L, null, null, "Disclosure of how body's or individuals within body responsibilities for impacts, risks and opportunities are reflected in undertaking's terms of reference, board mandates and other related policies ", 1L, "", 1, null },
                    { 10259L, "GOV-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4014), null, null, 2L, 3L, true, 1L, null, null, "Description of management's role in governance processes, controls and procedures used to monitor, manage and oversee impacts, risks and opportunities ", 1L, "", 1, null },
                    { 10260L, "GOV-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4016), null, null, 2L, 3L, true, 1L, null, null, "Description of how oversight is exercised over management-level position or committee to which management's role is delegated to ", 1L, "", 1, null },
                    { 10261L, "GOV-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4018), null, null, 2L, 3L, true, 1L, null, null, "Information about reporting lines to administrative, management and supervisory bodies ", 1L, "", 1, null },
                    { 10262L, "GOV-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4021), null, null, 2L, 3L, true, 1L, null, null, "Disclosure of how dedicated controls and procedures are integrated with other internal functions ", 1L, "", 1, null },
                    { 10263L, "GOV-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4023), null, null, 2L, 3L, true, 1L, null, null, "Disclosure of how administrative, management and supervisory bodies and senior executive management oversee setting of targets related to material impacts, risks and opportunities and how progress towards them is monitored ", 1L, "", 1, null },
                    { 10264L, "GOV-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4026), null, null, 2L, 3L, true, 1L, null, null, "Disclosure of how administrative, management and supervisory bodies determine whether appropriate skills and expertise are available or will be developed to oversee sustainability matters ", 1L, "", 1, null },
                    { 10265L, "GOV-1_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4027), null, null, 2L, 3L, true, 1L, null, null, "Information about sustainability-related expertise that bodies either directly possess or can leverage ", 1L, "", 1, null },
                    { 10266L, "GOV-1_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4029), null, null, 2L, 3L, true, 1L, null, null, "Disclosure of how sustainability-related skills and expertise relate to material impacts, risks and opportunities ", 1L, "", 1, null },
                    { 10267L, "GOV-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4031), null, null, 2L, 4L, true, 1L, null, null, "Disclosure of whether, by whom and how frequently administrative, management and supervisory bodies are informed about material impacts, risks and opportunities, implementation of due diligence, and results and effectiveness of policies, actions, metrics and targets adopted to address them ", 1L, "", 1, null },
                    { 10268L, "GOV-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4034), null, null, 2L, 4L, true, 1L, null, null, "Disclosure of how administrative, management and supervisory bodies consider impacts, risks and opportunities when overseeing strategy, decisions on major transactions and risk management process ", 1L, "", 1, null },
                    { 10269L, "GOV-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4036), null, null, 2L, 4L, true, 1L, null, null, "Disclosure of list of material impacts, risks and opportunities addressed by administrative, management and supervisory bodies or their relevant committees ", 1L, "", 1, null },
                    { 10270L, "GOV-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4038), null, null, 2L, 4L, true, 1L, null, null, "Disclosure of how governance bodies ensure that appropriate mechanism for performance monitoring is in place ", 1L, "", 1, null },
                    { 10271L, "GOV-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4040), null, null, 2L, 5L, null, 1L, null, null, "Incentive schemes and remuneration policies linked to sustainability matters for members of administrative, management and supervisory bodies exist", 1L, "", 1, null },
                    { 10272L, "GOV-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4042), null, null, 2L, 5L, true, 1L, null, null, "Description of key characteristics of incentive schemes ", 1L, "", 1, null },
                    { 10273L, "GOV-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4044), null, null, 2L, 5L, true, 1L, null, null, "Description of specific sustainability-related targets and (or) impacts used to assess performance of members of administrative, management and supervisory bodies ", 1L, "", 1, null },
                    { 10274L, "GOV-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4046), null, null, 2L, 5L, true, 1L, null, null, "Disclosure of how sustainability-related performance metrics are considered as performance benchmarks or included in remuneration policies ", 1L, "", 1, null },
                    { 10275L, "GOV-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4049), null, null, 2L, 5L, null, 1L, null, null, "Percentage of variable remuneration dependent on sustainability-related targets and (or) impacts", 1L, "", 1, null },
                    { 10276L, "GOV-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4051), null, null, null, 5L, true, 1L, null, null, "Description of level in undertaking at which terms of incentive schemes are approved and updated ", 1L, "", 1, 38L },
                    { 10277L, "GOV-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4053), null, null, 2L, 6L, true, 1L, null, null, "Disclosure of mapping of information provided in sustainability statement about due diligence process ", 1L, "", 1, null },
                    { 10278L, "GOV-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4059), null, null, 2L, 7L, true, 1L, null, null, "Description of scope, main features and components of risk management and internal control processes and systems in relation to sustainability reporting ", 1L, "", 1, null },
                    { 10279L, "GOV-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4061), null, null, 2L, 7L, true, 1L, null, null, "Description of risk assessment approach followed ", 1L, "", 1, null },
                    { 10280L, "GOV-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4063), null, null, 2L, 7L, true, 1L, null, null, "Description of main risks identified and their mitigation strategies ", 1L, "", 1, null },
                    { 10281L, "GOV-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4065), null, null, 2L, 7L, true, 1L, null, null, "Description of how findings of risk assessment and internal controls as regards sustainability reporting process have been integrated into relevant internal functions and processes ", 1L, "", 1, null },
                    { 10282L, "GOV-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4068), null, null, 2L, 7L, true, 1L, null, null, "Description of periodic reporting of findings of risk assessment and internal controls to administrative, management and supervisory bodies ", 1L, "", 1, null },
                    { 10283L, "SBM-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4070), null, null, 2L, 8L, true, 1L, null, null, "Description of significant groups of products and (or) services offered ", 1L, "", 1, null },
                    { 10284L, "SBM-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4072), null, null, 2L, 8L, true, 1L, null, null, "Description of significant markets and (or) customer groups served ", 1L, "", 1, null },
                    { 10285L, "SBM-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4074), null, null, 2L, 8L, null, 1L, null, null, "Total number of employees (head count)", 1L, "", 1, null },
                    { 10286L, "SBM-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4076), null, null, null, 8L, null, 1L, null, null, "Number of employees (head count)", 1L, "", 1, 709L },
                    { 10287L, "SBM-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4078), null, null, null, 8L, true, 1L, null, null, "Description of products and services that are banned in certain markets ", 1L, "", 1, 709L },
                    { 10288L, "SBM-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4081), null, null, 2L, 8L, null, 1L, null, null, "Total revenue ", 1L, "", 1, null },
                    { 10289L, "SBM-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4083), null, null, 3L, 8L, null, 1L, null, null, "Revenue by significant ESRS Sectors", 1L, "", 1, null },
                    { 10290L, "SBM-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4085), null, null, 3L, 8L, null, 1L, null, null, "List of additional significant ESRS sectors in which significant activities are developed or in which undertaking is or may be connected to material impacts", 1L, "", 1, null },
                    { 10291L, "SBM-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4087), null, null, 2L, 8L, null, 1L, null, null, "Undertaking is active in fossil fuel (coal, oil and gas) sector", 1L, "", 1, null },
                    { 10292L, "SBM-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4089), null, null, 2L, 8L, null, 1L, null, null, "Revenue from fossil fuel (coal, oil and gas) sector", 1L, "", 1, null },
                    { 10293L, "SBM-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4090), null, null, 3L, 8L, null, 1L, null, null, "Revenue from coal", 1L, "", 1, null },
                    { 10294L, "SBM-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4092), null, null, 3L, 8L, null, 1L, null, null, "Revenue from oil", 1L, "", 1, null },
                    { 10295L, "SBM-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4096), null, null, 3L, 8L, null, 1L, null, null, "Revenue from gas", 1L, "", 1, null },
                    { 10296L, "SBM-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4098), null, null, 3L, 8L, null, 1L, null, null, "Revenue from Taxonomy-aligned economic activities related to fossil gas", 1L, "", 1, null },
                    { 10297L, "SBM-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4100), null, null, 3L, 8L, null, 1L, null, null, "Undertaking is active in chemicals production", 1L, "", 1, null },
                    { 10298L, "SBM-1_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4102), null, null, 2L, 8L, null, 1L, null, null, "Revenue from chemicals production", 1L, "", 1, null },
                    { 10299L, "SBM-1_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4104), null, null, 3L, 8L, null, 1L, null, null, "Undertaking is active in controversial weapons", 1L, "", 1, null },
                    { 10300L, "SBM-1_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4105), null, null, 2L, 8L, null, 1L, null, null, "Revenue from controversial weapons", 1L, "", 1, null },
                    { 10301L, "SBM-1_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4107), null, null, 3L, 8L, null, 1L, null, null, "Undertaking is active in cultivation and production of tobacco", 1L, "", 1, null },
                    { 10302L, "SBM-1_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4110), null, null, 2L, 8L, null, 1L, null, null, "Revenue from cultivation and production of tobacco", 1L, "", 1, null },
                    { 10303L, "SBM-1_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4112), null, null, 3L, 8L, true, 1L, null, null, "Description of sustainability-related goals in terms of significant groups of products and services, customer categories, geographical areas and relationships with stakeholders ", 1L, "", 1, null },
                    { 10304L, "SBM-1_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4114), null, null, 2L, 8L, true, 1L, null, null, "Disclosure of assessment of current significant products and (or) services, and significant markets and customer groups, in relation to sustainability-related goals ", 1L, "", 1, null },
                    { 10305L, "SBM-1_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4116), null, null, 2L, 8L, true, 1L, null, null, "Disclosure of elements of strategy that relate to or impact sustainability matters ", 1L, "", 1, null },
                    { 10306L, "SBM-1_24", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4118), null, null, 2L, 8L, null, 1L, null, null, "List of ESRS sectors that are significant for undertaking", 1L, "", 1, null },
                    { 10307L, "SBM-1_25", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4120), null, null, 2L, 8L, true, 1L, null, null, "Description of business model and value chain ", 1L, "", 1, null },
                    { 10308L, "SBM-1_26", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4122), null, null, 2L, 8L, true, 1L, null, null, "Description of inputs and approach to gathering, developing and securing inputs ", 1L, "", 1, null },
                    { 10309L, "SBM-1_27", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4125), null, null, 2L, 8L, true, 1L, null, null, "Description of outputs and outcomes in terms of current and expected benefits for customers, investors and other stakeholders ", 1L, "", 1, null },
                    { 10310L, "SBM-1_28", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4131), null, null, 2L, 8L, true, 1L, null, null, "Description of main features of upstream and downstream value chain and undertakings position in value chain ", 1L, "", 1, null },
                    { 10311L, "SBM-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4133), null, null, 2L, 9L, true, 1L, null, null, "Description of stakeholder engagement ", 1L, "", 1, null },
                    { 10312L, "SBM-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4135), null, null, 2L, 9L, true, 1L, null, null, "Description of key stakeholders ", 1L, "", 1, null },
                    { 10313L, "SBM-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4137), null, null, 2L, 9L, true, 1L, null, null, "Description of categories of stakeholders for which engagement occurs ", 1L, "", 1, null },
                    { 10314L, "SBM-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4139), null, null, 2L, 9L, true, 1L, null, null, "Description of how stakeholder engagement is organised ", 1L, "", 1, null },
                    { 10315L, "SBM-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4141), null, null, 2L, 9L, true, 1L, null, null, "Description of purpose of stakeholder engagement ", 1L, "", 1, null },
                    { 10316L, "SBM-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4144), null, null, 2L, 9L, true, 1L, null, null, "Description of how outcome of stakeholder engagement is taken into account ", 1L, "", 1, null },
                    { 10317L, "SBM-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4146), null, null, 2L, 9L, true, 1L, null, null, "Description of understanding of interests and views of key stakeholders as they relate to undertaking's strategy and business model ", 1L, "", 1, null },
                    { 10318L, "SBM-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4148), null, null, 2L, 9L, true, 1L, null, null, "Description of amendments to strategy and (or) business model ", 1L, "", 1, null },
                    { 10319L, "SBM-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4150), null, null, 2L, 9L, true, 1L, null, null, "Description of how strategy and (or) business model have been amended or are expected to be amended to address interests and views of stakeholders ", 1L, "", 1, null },
                    { 10320L, "SBM-2_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4152), null, null, 2L, 9L, true, 1L, null, null, "Description of any further steps that are being planned and in what timeline ", 1L, "", 1, null },
                    { 10321L, "SBM-2_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4154), null, null, 2L, 9L, null, 1L, null, null, "Further steps that are being planned are likely to modify relationship with and views of stakeholders", 1L, "", 1, null },
                    { 10322L, "SBM-2_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4157), null, null, 2L, 9L, true, 1L, null, null, "Description of how administrative, management and supervisory bodies are informed about views and interests of affected stakeholders with regard to sustainability-related impacts ", 1L, "", 1, null },
                    { 10323L, "SBM-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4159), null, null, 2L, 10L, true, 1L, null, null, "Description of material impacts resulting from materiality assessment ", 1L, "", 1, null },
                    { 10324L, "SBM-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4161), null, null, 2L, 10L, true, 1L, null, null, "Description of material risks and opportunities resulting from materiality assessment ", 1L, "", 1, null },
                    { 10325L, "SBM-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4163), null, null, 2L, 10L, true, 1L, null, null, "Disclosure of current and anticipated effects of material impacts, risks and opportunities on business model, value chain, strategy and decision-making, and how undertaking has responded or plans to respond to these effects ", 1L, "", 1, null },
                    { 10326L, "SBM-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4166), null, null, 2L, 10L, true, 1L, null, null, "Disclosure of how material negative and positive impacts affect (or are likely to affect) people or environment ", 1L, "", 1, null },
                    { 10327L, "SBM-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4168), null, null, 2L, 10L, true, 1L, null, null, "Disclosure of whether and how material impacts originate from or are connected to strategy and business model ", 1L, "", 1, null },
                    { 10328L, "SBM-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4170), null, null, 2L, 10L, true, 1L, null, null, "Disclosure of reasonably expected time horizons of material impacts ", 1L, "", 1, null },
                    { 10329L, "SBM-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4174), null, null, 2L, 10L, true, 1L, null, null, "Description of nature of activities or business relationships through which undertaking is involved with material impacts ", 1L, "", 1, null },
                    { 10330L, "SBM-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4176), null, null, 2L, 10L, null, 1L, null, null, "Disclosure of current financial effects of material risks and opportunities on financial position, financial performance and cash flows and material risks and opportunities for which there is significant risk of material adjustment within next annual reporting period to carrying amounts of assets and liabilities reported in related financial statements ", 1L, "", 1, null },
                    { 10331L, "SBM-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4178), null, null, 2L, 10L, null, 1L, null, null, "Disclosure of anticipated financial effects of material risks and opportunities on financial position, financial performance and cash flows over short-, medium- and long-term ", 1L, "", 1, null },
                    { 10332L, "SBM-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4180), null, null, 2L, 10L, true, 1L, null, null, "Information about resilience of strategy and business model regarding capacity to address material impacts and risks and to take advantage of material opportunities ", 1L, "", 1, null },
                    { 10333L, "SBM-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4182), null, null, 2L, 10L, true, 1L, null, null, "Disclosure of changes to material impacts, risks and opportunities compared to previous reporting period ", 1L, "", 1, null },
                    { 10334L, "SBM-3_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4184), null, null, 2L, 10L, true, 1L, null, null, "Disclosure of specification of impacts, risks and opportunities that are covered by ESRS Disclosure Requirements as opposed to those covered by additional entity-specific disclosures ", 1L, "", 1, null },
                    { 10335L, "IRO-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4186), null, null, 2L, 11L, true, 1L, null, null, "Description of methodologies and assumptions applied in process to identify impacts, risks and opportunities ", 1L, "", 1, null },
                    { 10336L, "IRO-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4189), null, null, 2L, 11L, true, 1L, null, null, "Description of process to identify, assess, prioritise and monitor potential and actual impacts on people and environment, informed by due diligence process ", 1L, "", 1, null },
                    { 10337L, "IRO-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4191), null, null, 2L, 11L, true, 1L, null, null, "Description of how process focuses on specific activities, business relationships, geographies or other factors that give rise to heightened risk of adverse impacts ", 1L, "", 1, null },
                    { 10338L, "IRO-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4193), null, null, 2L, 11L, true, 1L, null, null, "Description of how process considers impacts with which undertaking is involved through own operations or as result of business relationships ", 1L, "", 1, null },
                    { 10339L, "IRO-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4195), null, null, 2L, 11L, true, 1L, null, null, "Description of how process includes consultation with affected stakeholders to understand how they may be impacted and with external experts ", 1L, "", 1, null },
                    { 10340L, "IRO-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4197), null, null, 2L, 11L, true, 1L, null, null, "Description of how process prioritises negative impacts based on their relative severity and likelihood and positive impacts based on their relative scale, scope and likelihood and determines which sustainability matters are material for reporting purposes ", 1L, "", 1, null },
                    { 10341L, "IRO-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4199), null, null, 2L, 11L, true, 1L, null, null, "Description of process used to identify, assess, prioritise and monitor risks and opportunities that have or may have financial effects ", 1L, "", 1, null },
                    { 10342L, "IRO-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4205), null, null, 2L, 11L, true, 1L, null, null, "Description of how connections of impacts and dependencies with risks and opportunities that may arise from those impacts and dependencies have been considered ", 1L, "", 1, null },
                    { 10343L, "IRO-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4207), null, null, 2L, 11L, true, 1L, null, null, "Description of how likelihood, magnitude, and nature of effects of identified risks and opportunities have been assessed ", 1L, "", 1, null },
                    { 10344L, "IRO-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4209), null, null, 2L, 11L, true, 1L, null, null, "Description of how sustainability-related risks relative to other types of risks have been prioritised ", 1L, "", 1, null },
                    { 10345L, "IRO-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4211), null, null, 2L, 11L, true, 1L, null, null, "Description of decision-making process and related internal control procedures ", 1L, "", 1, null },
                    { 10346L, "IRO-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4213), null, null, 2L, 11L, true, 1L, null, null, "Description of extent to which and how process to identify, assess and manage impacts and risks is integrated into overall risk management process and used to evaluate overall risk profile and risk management processes ", 1L, "", 1, null },
                    { 10347L, "IRO-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4215), null, null, 2L, 11L, true, 1L, null, null, "Description of extent to which and how process to identify, assess and manage opportunities is integrated into overall management process ", 1L, "", 1, null },
                    { 10348L, "IRO-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4217), null, null, 2L, 11L, null, 1L, null, null, "Description of input parameters used in process to identify, assess and manage material impacts, risks and opportunities ", 1L, "", 1, null },
                    { 10349L, "IRO-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4220), null, null, 2L, 11L, true, 1L, null, null, "Description of how process to identify, assess and manage impacts, risks and opportunities has changed compared to prior reporting period ", 1L, "", 1, null },
                    { 10350L, "IRO-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4222), null, null, 2L, 12L, null, 1L, null, null, "Disclosure of list of data points that derive from other EU legislation and information on their location in sustainability statement ", 1L, "", 1, null },
                    { 10351L, "IRO-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4224), null, null, 2L, 12L, null, 1L, null, null, "Disclosure of list of ESRS Disclosure Requirements complied with in preparing sustainability statement following outcome of materiality assessment ", 1L, "", 1, null },
                    { 10352L, "IRO-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4228), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS E1 Climate change ", 1L, "", 1, null },
                    { 10353L, "IRO-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4231), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS E2 Pollution ", 1L, "", 1, null },
                    { 10354L, "IRO-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4233), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS E3 Water and marine resources ", 1L, "", 1, null },
                    { 10355L, "IRO-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4235), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS E4 Biodiversity and ecosystems ", 1L, "", 1, null },
                    { 10356L, "IRO-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4237), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS E5 Circular economy ", 1L, "", 1, null },
                    { 10357L, "IRO-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4240), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS S1 Own workforce ", 1L, "", 1, null },
                    { 10358L, "IRO-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4242), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS S2 Workers in value chain ", 1L, "", 1, null },
                    { 10359L, "IRO-2_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4245), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS S3 Affected communities ", 1L, "", 1, null },
                    { 10360L, "IRO-2_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4247), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS S4 Consumers and end-users ", 1L, "", 1, null },
                    { 10361L, "IRO-2_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4249), null, null, 2L, 12L, true, 1L, null, null, "Explanation of negative materiality assessment for ESRS G1 Business conduct ", 1L, "", 1, null },
                    { 10362L, "IRO-2_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4252), null, null, 2L, 12L, true, 1L, null, null, "Explanation of how material information to be disclosed in relation to material impacts, risks and opportunities has been determined ", 1L, "", 1, null },
                    { 10364L, "MDR-P_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4256), null, null, 2L, 13L, true, 1L, null, null, "Description of scope of policy or of its exclusions ", 1L, "", 1, null },
                    { 10365L, "MDR-P_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4258), null, null, 2L, 13L, true, 1L, null, null, "Description of most senior level in organisation that is accountable for implementation of policy ", 1L, "", 1, null },
                    { 10366L, "MDR-P_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4260), null, null, 2L, 13L, true, 1L, null, null, "Disclosure of third-party standards or initiatives that are respected through implementation of policy ", 1L, "", 1, null },
                    { 10367L, "MDR-P_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4262), null, null, 2L, 13L, true, 1L, null, null, "Description of consideration given to interests of key stakeholders in setting policy ", 1L, "", 1, null },
                    { 10368L, "MDR-P_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4264), null, null, 2L, 13L, true, 1L, null, null, "Explanation of whether and how policy is made available to potentially affected stakeholders and stakeholders who need to help implement it ", 1L, "", 1, null },
                    { 10369L, "MDR-A_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4270), null, null, 2L, 14L, true, 1L, null, null, "Disclosure of key action ", 1L, "", 1, null },
                    { 10370L, "MDR-A_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4272), null, null, 2L, 14L, true, 1L, null, null, "Description of scope of key action ", 1L, "", 1, null },
                    { 10371L, "MDR-A_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4274), null, null, 2L, 14L, null, 1L, null, null, "Time horizon under which key action is to be completed", 1L, "", 1, null },
                    { 10372L, "MDR-A_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4276), null, null, 2L, 14L, true, 1L, null, null, "Description of key action taken, and its results, to provide for and cooperate in or support provision of remedy for those harmed by actual material impacts ", 1L, "", 1, null },
                    { 10373L, "MDR-A_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4278), null, null, 2L, 14L, true, 1L, null, null, "Disclosure of quantitative and qualitative information regarding progress of actions or action plans disclosed in prior periods ", 1L, "", 1, null },
                    { 10374L, "MDR-A_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4283), null, null, 2L, 14L, true, 1L, null, null, "Disclosure of the type of current and future financial and other resources allocated to the action plan (Capex and Opex)", 1L, "", 1, null },
                    { 10375L, "MDR-A_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4285), null, null, 2L, 14L, true, 1L, null, null, "Explanation of how current financial resources relate to most relevant amounts presented in financial statements", 1L, "", 1, null },
                    { 10376L, "MDR-A_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4288), null, null, 2L, 14L, null, 1L, null, null, "Current and future financial resources allocated to action plan, breakdown by time horizon and resources", 1L, "", 1, null },
                    { 10377L, "MDR-A_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4290), null, null, 3L, 14L, null, 1L, null, null, "Current financial resources allocated to action plan (Capex)", 1L, "", 1, null },
                    { 10378L, "MDR-A_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4292), null, null, 3L, 14L, null, 1L, null, null, "Current financial resources allocated to action plan (Opex)", 1L, "", 1, null },
                    { 10379L, "MDR-A_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4294), null, null, 3L, 14L, null, 1L, null, null, "Future financial resources allocated to action plan (Capex)", 1L, "", 1, null },
                    { 10380L, "MDR-A_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4296), null, null, 3L, 14L, null, 1L, null, null, "Future financial resources allocated to action plan (Opex)", 1L, "", 1, null },
                    { 10381L, "MDR-M_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4298), null, null, 3L, 15L, true, 1L, null, null, "Description of metric used to evaluate performance and effectiveness, in relation to material impact, risk or opportunity ", 1L, "", 1, null },
                    { 10382L, "MDR-M_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4300), null, null, 2L, 15L, true, 1L, null, null, "Disclosure of methodologies and significant assumptions behind metric ", 1L, "", 1, null },
                    { 10383L, "MDR-M_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4303), null, null, 2L, 15L, true, 1L, null, null, "Type of external body other than assurance provider that provides validation ", 1L, "", 1, null },
                    { 10384L, "MDR-T_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4304), null, null, 2L, 16L, true, 1L, null, null, "Relationship with policy objectives", 1L, "", 1, null },
                    { 10385L, "MDR-T_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4306), null, null, 2L, 16L, null, 1L, null, null, "Measurable target", 1L, "", 1, null },
                    { 10386L, "MDR-T_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4308), null, null, 2L, 16L, null, 1L, null, null, "Nature of target", 1L, "", 1, null },
                    { 10387L, "MDR-T_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4310), null, null, 2L, 16L, true, 1L, null, null, "Description of scope of target ", 1L, "", 1, null },
                    { 10388L, "MDR-T_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4312), null, null, 2L, 16L, null, 1L, null, null, "Baseline value ", 1L, "", 1, null },
                    { 10389L, "MDR-T_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4315), null, null, null, 16L, null, 1L, null, null, "Baseline year", 1L, "", 1, 709L },
                    { 10390L, "MDR-T_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4317), null, null, null, 16L, null, 1L, null, null, "Period to which target applies", 1L, "", 1, 709L },
                    { 10391L, "MDR-T_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4319), null, null, 2L, 16L, true, 1L, null, null, "Indication of milestones or interim targets ", 1L, "", 1, null },
                    { 10392L, "MDR-T_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4321), null, null, 2L, 16L, true, 1L, null, null, "Description of methodologies and significant assumptions used to define target ", 1L, "", 1, null },
                    { 10393L, "MDR-T_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4323), null, null, 2L, 16L, null, 1L, null, null, "Target related to environmental matters is based on conclusive scientific evidence", 1L, "", 1, null },
                    { 10394L, "MDR-T_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4325), null, null, 2L, 16L, true, 1L, null, null, "Disclosure of whether and how stakeholders have been involved in target setting ", 1L, "", 1, null },
                    { 10395L, "MDR-T_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4327), null, null, 2L, 16L, true, 1L, null, null, "Description of any changes in target and corresponding metrics or underlying measurement methodologies, significant assumptions, limitations, sources and adopted processes to collect data ", 1L, "", 1, null },
                    { 10396L, "MDR-T_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4330), null, null, 2L, 16L, true, 1L, null, null, "Description of performance against disclosed target ", 1L, "", 1, null },
                    { 10397L, "E2.IRO-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4332), null, null, 2L, 29L, true, 1L, null, null, "Information about the process to identify actual and potential pollution-related impacts, risks and opportuntities", 1L, "", 1, null },
                    { 10398L, "E2.IRO-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4334), null, null, 2L, 29L, true, 1L, null, null, "Disclosure of whether and how consultations have been conducted (pollution) ", 1L, "", 1, null },
                    { 10399L, "E2.IRO-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4336), null, null, 2L, 29L, true, 1L, null, null, "Disclosure of results of materiality assessment (pollution) ", 1L, "", 1, null },
                    { 10400L, "E2.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4338), null, null, 2L, 30L, null, 1L, null, null, "Policies to manage its material impacts, risks and opportunities related to pollution [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 10401L, "E2-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4340), null, null, 2L, 30L, true, 1L, null, null, "Disclosure of whether and how policy addresses mitigating negative impacts related to pollution of air, water and soil ", 1L, "", 1, null },
                    { 10402L, "E2-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4342), null, null, 2L, 30L, true, 1L, null, null, "Disclosure of  whether and how policy addresses substituting and minimising use of substances of concern and phasing out substances of very high concern ", 1L, "", 1, null },
                    { 10403L, "E2-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4345), null, null, 2L, 30L, true, 1L, null, null, "Disclosure of  whether and how policy addresses avoiding incidents and emergency situations, and if and when they occur, controlling and limiting their impact on people and environment ", 1L, "", 1, null },
                    { 10404L, "E2-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4347), null, null, 2L, 30L, true, 1L, null, null, "Disclosure of contextual information on relations between policies implemented and how policies contribute to EU Action Plan Towards Zero Pollution for Air, Water and Soil ", 1L, "", 1, null },
                    { 10406L, "E2.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4354), null, null, null, 31L, null, 1L, null, null, "Actions and resources in relation to pollution [see ESRS 2 MDR-A]", 1L, "", 1, null },
                    { 10407L, "E2-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4356), null, null, 2L, 31L, null, 1L, null, null, "Layer in mitigation hierarchy to which action can be allocated to (pollution)", 1L, "", 1, null },
                    { 10408L, "E2-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4358), null, null, 2L, 31L, null, 1L, null, null, "Action related to pollution extends to upstream/downstream value chain engagements", 1L, "", 1, null },
                    { 10409L, "E2-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4360), null, null, 2L, 31L, null, 1L, null, null, "Layer in mitigation hierarchy to which resources can be allocated to (pollution)", 1L, "", 1, null },
                    { 10410L, "E2-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4363), null, null, 2L, 31L, true, 1L, null, null, "Information about action plans that have been implemented at site-level (pollution) ", 1L, "", 1, null },
                    { 10412L, "E2.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4366), null, null, null, 32L, null, 1L, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 1, null },
                    { 10413L, "E2-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4369), null, null, 2L, 32L, true, 1L, null, null, "Disclosure of  whether and  how target relates to prevention and control of air pollutants and respective specific loads ", 1L, "", 1, null },
                    { 10414L, "E2-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4371), null, null, 2L, 32L, true, 1L, null, null, "Disclosure of  whether and how target relates to prevention and control of emissions to water and respective specific loads ", 1L, "", 1, null },
                    { 10415L, "E2-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4373), null, null, 2L, 32L, true, 1L, null, null, "Disclosure of  whether and how target relates to prevention and control of pollution to soil and respective specific loads ", 1L, "", 1, null },
                    { 10416L, "E2-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4376), null, null, 2L, 32L, true, 1L, null, null, "Disclosure of  whether and how target relates to prevention and control of  substances of concern and substances of very high concern", 1L, "", 1, null },
                    { 10417L, "E2-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4377), null, null, 2L, 32L, null, 1L, null, null, "Ecological thresholds and entity-specific allocations were taken into consideration when setting pollution-related target", 1L, "", 1, null },
                    { 10418L, "E2-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4380), null, null, 2L, 32L, true, 1L, null, null, "Disclosure of ecological thresholds identified and methodology used to identify ecological thresholds (pollution) ", 1L, "", 1, null },
                    { 10419L, "E2-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4382), null, null, 2L, 32L, true, 1L, null, null, "Disclosure of how ecological entity-specific thresholds were determined (pollution) ", 1L, "", 1, null },
                    { 10420L, "E2-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4384), null, null, 2L, 32L, true, 1L, null, null, "Disclosure of how responsibility for respecting identified ecological thresholds is allocated (pollution) ", 1L, "", 1, null },
                    { 10421L, "E2-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4386), null, null, 2L, 32L, null, 1L, null, null, "Pollution-related target is mandatory (required by legislation)/voluntary", 1L, "", 1, null },
                    { 10422L, "E2-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4388), null, null, 2L, 32L, null, 1L, null, null, "Pollution-related target addresses shortcomings related to Substantial Contribution criteria for Pollution Prevention and Control", 1L, "", 1, null },
                    { 10423L, "E2-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4390), null, null, 2L, 32L, true, 1L, null, null, "Information about targets that have been implemented at site-level (pollution) ", 1L, "", 1, null },
                    { 10425L, "E2-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4394), null, null, null, 33L, null, 1L, null, null, "Pollution of air, water and soil [multiple dimensions: at site level or  by type of source, by sector or by geographical area", 1L, "", 1, null },
                    { 10426L, "E2-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4396), null, null, 1L, 33L, null, 1L, null, null, "Emissions to air by pollutant ", 1L, "", 1, null },
                    { 10427L, "E2-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4398), null, null, null, 33L, null, 1L, null, null, "Emissions to water by pollutant  [+ by sectors/Geographical Area/Type of source/Site location]", 1L, "", 1, 79L },
                    { 10428L, "E2-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4400), null, null, null, 33L, null, 1L, null, null, "Emissions to soil by pollutant  [+ by sectors/Geographical Area/Type of source/Site location]", 1L, "", 1, 79L },
                    { 10429L, "E2-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4402), null, null, null, 33L, null, 1L, null, null, "Microplastics generated and used", 1L, "", 1, 79L },
                    { 10430L, "E2-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4404), null, null, null, 33L, null, 1L, null, null, "Microplastics generated", 1L, "", 1, 79L },
                    { 10431L, "E2-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4406), null, null, null, 33L, null, 1L, null, null, "Microplastics used", 1L, "", 1, 79L },
                    { 10432L, "E2-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4408), null, null, null, 33L, true, 1L, null, null, "Description of changes over time (pollution of air, water and soil) ", 1L, "", 1, 79L },
                    { 10433L, "E2-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4410), null, null, 2L, 33L, true, 1L, null, null, "Description of measurement methodologies (pollution of air, water and soil) ", 1L, "", 1, null },
                    { 10434L, "E2-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4412), null, null, 2L, 33L, true, 1L, null, null, "Description of process(es) to collect data for pollution-related accounting and reporting ", 1L, "", 1, null },
                    { 10435L, "E2-4_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4414), null, null, 2L, 33L, null, 1L, null, null, "Percentage of total emissions of pollutants to water occurring in areas at water risk", 1L, "", 1, null },
                    { 10436L, "E2-4_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4416), null, null, null, 33L, null, 1L, null, null, "Percentage of total emissions of pollutants to water occurring in areas of high-water stress", 1L, "", 1, 38L },
                    { 10437L, "E2-4_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4419), null, null, null, 33L, null, 1L, null, null, "Percentage of total emissions of pollutants to soil occurring in areas at water risk", 1L, "", 1, 38L },
                    { 10438L, "E2-4_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4424), null, null, null, 33L, null, 1L, null, null, "Percentage of total emissions of pollutants to soil occurring in areas of high-water stress", 1L, "", 1, 38L },
                    { 10439L, "E2-4_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4426), null, null, null, 33L, true, 1L, null, null, "Disclosure of reasons for choosing inferior methodology to quantify emissions ", 1L, "", 1, 38L },
                    { 10440L, "E2-4_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4428), null, null, 2L, 33L, true, 1L, null, null, "Disclosure of list of installations operated that fall under IED and EU BAT Conclusions ", 1L, "", 1, null },
                    { 10441L, "E2-4_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4430), null, null, 2L, 33L, true, 1L, null, null, "Disclosure of list of any non-compliance incidents or enforcement actions necessary to ensure compliance in case of breaches of permit conditions ", 1L, "", 1, null },
                    { 10442L, "E2-4_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4432), null, null, 2L, 33L, true, 1L, null, null, "Disclosure of actual performance and comparison of environmental performance against emission levels associated with best available techniques (BAT-AEL) as described in EU-BAT conclusions ", 1L, "", 1, null },
                    { 10443L, "E2-4_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4434), null, null, 2L, 33L, true, 1L, null, null, "Disclosure of actual performance against environmental performance levels associated with best available techniques (BAT-AEPLs) applicable to sector and installation ", 1L, "", 1, null },
                    { 10444L, "E2-4_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4437), null, null, 2L, 33L, true, 1L, null, null, "Disclosure of list of any compliance schedules or derogations granted by competent authorities according to Article 15(4) IED that are associated with implementation of BAT-AELs ", 1L, "", 1, null },
                    { 10445L, "E2-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4439), null, null, 2L, 34L, null, 1L, null, null, "Total amount of substances of concern that are generated or used during production or that are procured, breakdown by main hazard classes of substances of concern", 1L, "", 1, null },
                    { 10446L, "E2-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4441), null, null, 1L, 34L, null, 1L, null, null, "Total amount of substances of concern that are generated or used during production or that are procured", 1L, "", 1, 79L },
                    { 10447L, "E2-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4443), null, null, null, 34L, null, 1L, null, null, "Total amount of substances of concern that leave facilities as emissions, as products, or as part of products or services ", 1L, "", 1, 79L },
                    { 10448L, "E2-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4445), null, null, null, 34L, null, 1L, null, null, "Amount of substances of concern that leave facilities as emissions by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10449L, "E2-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4447), null, null, null, 34L, null, 1L, null, null, "Amount of substances of concern that leave facilities as products by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10450L, "E2-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4449), null, null, null, 34L, null, 1L, null, null, "Amount of substances of concern that leave facilities as part of products by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10451L, "E2-5_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4452), null, null, null, 34L, null, 1L, null, null, "Amount of substances of concern that leave facilities as services by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10452L, "E2-5_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4454), null, null, null, 34L, null, 1L, null, null, "Total amount of substances of very high concern that are generated or used during production or that are procured by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10453L, "E2-5_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4456), null, null, null, 34L, null, 1L, null, null, "Total amount of substances of very high concern that leave facilities as emissions, as products, or as part of products or services by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10454L, "E2-5_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4458), null, null, null, 34L, null, 1L, null, null, "Amount of substances of very high concern that leave facilities as emissions by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10455L, "E2-5_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4460), null, null, null, 34L, null, 1L, null, null, "Amount of substances of very high concern that leave facilities as products by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10456L, "E2-5_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4462), null, null, null, 34L, null, 1L, null, null, "Amount of substances of very high concern that leave facilities as part of products by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10457L, "E2-5_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4464), null, null, null, 34L, null, 1L, null, null, "Amount of substances of very high concern that leave facilities as services by main hazard classes of substances of concern", 1L, "", 1, 79L },
                    { 10458L, "E2-6_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4466), null, null, null, 35L, null, 1L, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from pollution-related impacts ", 1L, "", 1, 79L },
                    { 10459L, "E2-6_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4468), null, null, 3L, 35L, null, 1L, null, null, "Percentage of net revenue made with products and services that are or that contain substances of concern", 1L, "", 1, null },
                    { 10460L, "E2-6_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4470), null, null, null, 35L, null, 1L, null, null, "Percentage of net revenue made with products and services that are or that contain substances of very high concern", 1L, "", 1, 38L },
                    { 10461L, "E2-6_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4472), null, null, null, 35L, null, 1L, null, null, "Operating expenditures (OpEx) in conjunction with major incidents and deposits (pollution)", 1L, "", 1, 38L },
                    { 10462L, "E2-6_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4474), null, null, 3L, 35L, null, 1L, null, null, "Capital expenditures (CapEx) in conjunction with major incidents and deposits (pollution)", 1L, "", 1, null },
                    { 10463L, "E2-6_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4476), null, null, 3L, 35L, null, 1L, null, null, "Provisions for environmental protection and remediation costs (pollution)", 1L, "", 1, null },
                    { 10464L, "E2-6_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4478), null, null, 3L, 35L, true, 1L, null, null, "Disclosure of qualitative information about anticipated financial effects of material risks and opportunities arising from pollution-related impacts ", 1L, "", 1, null },
                    { 10465L, "E2-6_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4480), null, null, 2L, 35L, true, 1L, null, null, "Description of effects considered, related impacts and time horizons in which they are likely to materialise (pollution) ", 1L, "", 1, null },
                    { 10466L, "E2-6_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4482), null, null, 2L, 35L, true, 1L, null, null, "Disclosure of critical assumptions used to quantify anticipated financial effects, sources and level of uncertainty of assumptions (pollution) ", 1L, "", 1, null },
                    { 10467L, "E2-6_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4484), null, null, 2L, 35L, true, 1L, null, null, "Description of material incidents and deposits whereby pollution had negative impacts on environment and (or) is expected to have negative effects on financial cash flows, financial position and financial performance ", 1L, "", 1, null },
                    { 10468L, "E2-6_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4486), null, null, 2L, 35L, true, 1L, null, null, "Disclosure of assessment of related products and services at risk and explanation how time horizon is defined, financial amounts are estimated, and which critical assumptions are made (pollution) ", 1L, "", 1, null },
                    { 10469L, "E3.IRO-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4488), null, null, 2L, 36L, true, 1L, null, null, "Disclosure of whether and how assets and activities have been screened in order to identify actual and potential water and marine resources-related impacts, risks and opportunities in own operations and upstream and downstream value chain and methodologies, assumptions and tools used in screening [text block]", 1L, "", 1, null },
                    { 10470L, "E3.IRO-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4495), null, null, 2L, 36L, true, 1L, null, null, "Disclosure of how consultations have been conducted (water and marine resources) [text block]", 1L, "", 1, null },
                    { 10471L, "E3.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4497), null, null, 2L, 37L, null, 1L, null, null, "Policies to manage its material impacts, risks and opportunities related to water and marine resources [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 10472L, "E3-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4499), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of whether and how policy adresses water management ", 1L, "", 1, null },
                    { 10473L, "E3-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4501), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of whether and how policy adresses the use and sourcing of water and marine resources in own operations ", 1L, "", 1, null },
                    { 10474L, "E3-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4503), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of whether and  how policy adresses water treatment", 1L, "", 1, null },
                    { 10475L, "E3-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4505), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of whether and how policy adresses prevention and abatment of water pollution", 1L, "", 1, null },
                    { 10476L, "E3-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4507), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of whether and how policy adresses product and service design in view of addressing water-related issues and preservation of marine resources ", 1L, "", 1, null },
                    { 10477L, "E3-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4509), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of whether and how policy adresses commitment to reduce material water consumption in areas at water risk ", 1L, "", 1, null },
                    { 10478L, "E3-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4512), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of reasons for not having adopted policies in areas of high-water stress ", 1L, "", 1, null },
                    { 10479L, "E3-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4515), null, null, 2L, 37L, true, 1L, null, null, "Disclosure of timeframe in which policies in areas of high-water stress will be adopted ", 1L, "", 1, null },
                    { 10480L, "E3-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4517), null, null, 2L, 37L, null, 1L, null, null, "Policies or practices related to sustainable oceans and seas have been adopted", 1L, "", 1, null },
                    { 10481L, "E3-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4519), null, null, 2L, 37L, null, 1L, null, null, "The policly contributes to good ecological and chemical quality of surface water bodies and good chemical quality and quantity of groundwater bodies, in order to protect human health, water supply, natural ecosystems and biodiversity, the good environmental status of marine waters and the protection of the resource base upon which marine related activities depend;", 1L, "", 1, null },
                    { 10482L, "E3-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4521), null, null, 2L, 37L, null, 1L, null, null, "The policy minimise material impacts and risks and implement mitigation measures that aim to maintain the value and functionality of priority services and to increase resource efficiency on own operations", 1L, "", 1, null },
                    { 10483L, "E3-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4523), null, null, 2L, 37L, null, 1L, null, null, "The policy avoid impacts on affected communities.", 1L, "", 1, null },
                    { 10485L, "E3.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4528), null, null, null, 38L, null, 1L, null, null, "Actions and resources in relation to water and marine resources [see ESRS 2 MDR-A]", 1L, "", 1, null },
                    { 10486L, "E3-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4530), null, null, 2L, 38L, null, 1L, null, null, "Layer in mitigation hierarchy to which action and resources can be allocated to (water and marine resources)", 1L, "", 1, null },
                    { 10487L, "E3-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4532), null, null, 2L, 38L, true, 1L, null, null, "Information about specific collective action for water and marine resources ", 1L, "", 1, null },
                    { 10488L, "E3-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4534), null, null, 2L, 38L, true, 1L, null, null, "Disclosure of actions and resources  in relation to areas at water risk ", 1L, "", 1, null },
                    { 10490L, "E3.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4538), null, null, null, 39L, null, 1L, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 1, null },
                    { 10491L, "E3-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4540), null, null, 2L, 39L, true, 1L, null, null, "Disclosure of whether and  how target relates to management of material impacts, risks and opportunities related to areas at water risk ", 1L, "", 1, null },
                    { 10492L, "E3-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4543), null, null, 2L, 39L, true, 1L, null, null, "Disclosure of whether and  how target relates to responsible management of marine resources impacts, risks and opportunities ", 1L, "", 1, null },
                    { 10493L, "E3-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4545), null, null, 2L, 39L, true, 1L, null, null, "Disclosure of whether and how target relates to reduction of water consumption ", 1L, "", 1, null },
                    { 10494L, "E3-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4551), null, null, 2L, 39L, null, 1L, null, null, "(Local) ecological threshold and entity-specific allocation were taken into consideration when setting water and marine resources target", 1L, "", 1, null },
                    { 10495L, "E3-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4553), null, null, 2L, 39L, null, 1L, null, null, "Disclosure of ecological threshold identified and methodology used to identify ecological threshold (water and marine resources) ", 1L, "", 1, null },
                    { 10496L, "E3-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4555), null, null, 2L, 39L, null, 1L, null, null, "Disclosure of how ecological entity-specific threshold was determined (water and marine resources) ", 1L, "", 1, null },
                    { 10497L, "E3-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4557), null, null, 2L, 39L, true, 1L, null, null, "Disclosure of how responsibility for respecting identified ecological threshold is allocated (water and marine resources) ", 1L, "", 1, null },
                    { 10498L, "E3-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4560), null, null, 2L, 39L, null, 1L, null, null, "Adopted and presented water and marine resources-related target is mandatory (based on legislation)", 1L, "", 1, null },
                    { 10499L, "E3-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4562), null, null, 2L, 39L, null, 1L, null, null, "Target relates to reduction of water withdrawals", 1L, "", 1, null },
                    { 10500L, "E3-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4564), null, null, 2L, 39L, null, 1L, null, null, "Target relates to reduction of water discharges", 1L, "", 1, null },
                    { 10502L, "E3-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4574), null, null, null, 40L, null, 1L, null, null, "Total water consumption", 1L, "", 1, null },
                    { 10503L, "E3-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4576), null, null, null, 40L, null, 1L, null, null, "Total water consumption in areas at water risk, including areas of high-water stress", 1L, "", 1, 120L },
                    { 10504L, "E3-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4578), null, null, null, 40L, null, 1L, null, null, "Total water recycled and reused", 1L, "", 1, 120L },
                    { 10505L, "E3-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4581), null, null, null, 40L, null, 1L, null, null, "Total water stored", 1L, "", 1, 120L },
                    { 10506L, "E3-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4583), null, null, null, 40L, null, 1L, null, null, "Changes in water storage", 1L, "", 1, 120L },
                    { 10507L, "E3-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4585), null, null, null, 40L, true, 1L, null, null, "Disclosure of contextual information regarding warter consumption", 1L, "", 1, 120L },
                    { 10508L, "E3-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4588), null, null, 2L, 40L, null, 1L, null, null, "Share of the measure obtained from direct measurement, from sampling and extrapolation, or from best estimates", 1L, "", 1, null },
                    { 10509L, "E3-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4590), null, null, null, 40L, null, 1L, null, null, "Water intensity ratio", 1L, "", 1, 38L },
                    { 10510L, "E3-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4592), null, null, null, 40L, null, 1L, null, null, "Water consumption - sectors/SEGMENTS [table]", 1L, "", 1, 120L },
                    { 10511L, "E3-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4594), null, null, null, 40L, null, 1L, null, null, "Additional water intensity ratio", 1L, "", 1, 120L },
                    { 10512L, "E3-4_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4596), null, null, null, 40L, null, 1L, null, null, "Total water withdrawals", 1L, "", 1, 38L },
                    { 10513L, "E3-4_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4600), null, null, null, 40L, null, 1L, null, null, "Total water discharges", 1L, "", 1, 120L },
                    { 10514L, "E3-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4603), null, null, null, 41L, null, 1L, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from water and marine resources-related impacts ", 1L, "", 1, 120L },
                    { 10515L, "E3-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4605), null, null, 3L, 41L, true, 1L, null, null, "Disclosure of qualitative information of anticipated financial effects of material risks and opportunities arising from water and marine resources-related impacts ", 1L, "", 1, null },
                    { 10516L, "E3-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4607), null, null, 2L, 41L, true, 1L, null, null, "Description of effects considered and related impacts (water and marine resources) ", 1L, "", 1, null },
                    { 10517L, "E3-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4610), null, null, 2L, 41L, true, 1L, null, null, "Disclosure of critical assumptions used in estimates of financial effects of material risks and opportunities arising from water and marine resources-related impacts ", 1L, "", 1, null },
                    { 10518L, "E3-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4616), null, null, 2L, 41L, true, 1L, null, null, "Description of related products and services at risk (water and marine resources) ", 1L, "", 1, null },
                    { 10519L, "E3-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4619), null, null, 2L, 41L, true, 1L, null, null, "Explanation of how time horizons are defined, financial amounts are estimated and critical assumptions made (water and marine resources) ", 1L, "", 1, null },
                    { 10520L, "E4.SBM-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4621), null, null, 2L, 42L, true, 1L, null, null, "List of material sites in own operation", 1L, "", 1, null },
                    { 10521L, "E4.SBM-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4623), null, null, 2L, 42L, true, 1L, null, null, "Disclosure of activities negatively affecting biodiversity sensitive areeas", 1L, "", 1, null },
                    { 10522L, "E4.SBM-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4626), null, null, 2L, 42L, true, 1L, null, null, "Disclosure of list of material sites in own operations based on results of identification and assessment of actual and potential impacts on biodiversity and ecosystems", 1L, "", 1, null },
                    { 10523L, "E4.SBM-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4628), null, null, 2L, 42L, true, 1L, null, null, "Disclosure of biodiversity-sensitive areas impacted ", 1L, "", 1, null },
                    { 10524L, "E4.SBM-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4630), null, null, 2L, 42L, null, 1L, null, null, "Material negative impacts with regards to land degradation, desertification or soil sealing have been identified", 1L, "", 1, null },
                    { 10525L, "E4.SBM-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4634), null, null, 2L, 42L, null, 1L, null, null, "Own operations affect threatened species", 1L, "", 1, null },
                    { 10526L, "E4.IRO-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4637), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how actual and potential impacts on biodiversity and ecosystems at own site locations and in value chain have been identified and assessed ", 1L, "", 1, null },
                    { 10527L, "E4.IRO-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4642), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how dependencies on biodiversity and ecosystems and their services have been identified and assessed at own site locations and in value chain ", 1L, "", 1, null },
                    { 10528L, "E4.IRO-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4644), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how transition and physical risks and opportunities related to biodiversity and ecosystems have been identified and assessed ", 1L, "", 1, null },
                    { 10529L, "E4.IRO-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4647), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how systemic risks have been considered (biodiversity and ecosystems)", 1L, "", 1, null },
                    { 10530L, "E4.IRO-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4650), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how consultations with affected communities on sustainability assessments of shared biological resources and ecosystems have been conducted ", 1L, "", 1, null },
                    { 10531L, "E4.IRO-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4652), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how specific sites, raw materials production or sourcing with negative or potential negative impacts on affected communities ", 1L, "", 1, null },
                    { 10532L, "E4.IRO-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4655), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how communities were involved in materiality assessment ", 1L, "", 1, null },
                    { 10533L, "E4.IRO-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4658), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how negative impacts on priority ecosystem services of relevance to affected communities may be avoided ", 1L, "", 1, null },
                    { 10534L, "E4.IRO-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4665), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of plans to minimise unavoidable negative impacts and implement mitigation measures that aim to maintain value and functionality of priority services ", 1L, "", 1, null },
                    { 10535L, "E4.IRO-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4669), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of whether and how tthe business model(s) has been verified using range of biodiversity and ecosystems scenarios, or other scenarios with modelling of biodiversity and ecosystems related consequences, with different possible pathways", 1L, "", 1, null },
                    { 10536L, "E4.IRO-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4671), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of why considered scenarios were taken into consideration ", 1L, "", 1, null },
                    { 10537L, "E4.IRO-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4673), null, null, 2L, 43L, true, 1L, null, null, "Disclosure of how considered scenarios are updated according to evolving conditions and emerging trends ", 1L, "", 1, null },
                    { 10538L, "E4.IRO-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4675), null, null, 2L, 43L, null, 1L, null, null, "Scenarios are informed by expectations in authoritative intergovernmental instruments and by scientific consensus", 1L, "", 1, null },
                    { 10539L, "E4.IRO-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4678), null, null, 2L, 43L, null, 1L, null, null, "Undertaking has sites located in or near biodiversity-sensitive areas", 1L, "", 1, null },
                    { 10540L, "E4.IRO-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4680), null, null, 2L, 43L, null, 1L, null, null, "Activities related to sites located in or near biodiversity-sensitive areas negatively affect these areas by leading to deterioration of natural habitats and habitats of species and to disturbance of species for which protected area has been designated", 1L, "", 1, null },
                    { 10541L, "E4.IRO-1_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4682), null, null, 2L, 43L, null, 1L, null, null, "It has been concluded that it is necessary to implement biodiversity mitigation measures", 1L, "", 1, null },
                    { 10542L, "E4-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4684), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of resilience of current business model(s) and strategy to biodiversity and ecosystems-related physical, transition and systemic risks and opportunities ", 1L, "", 1, null },
                    { 10543L, "E4-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4690), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of scope of resilience analysis along own operations and related upstream and downstream value chain ", 1L, "", 1, null },
                    { 10544L, "E4-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4693), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of key assumptions made (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10545L, "E4-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4696), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of time horizons used for analysis (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10546L, "E4-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4698), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of results of resilience analysis (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10547L, "E4-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4701), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of involvement of stakeholders (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10548L, "E4-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4703), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of transition plan to improve and achieve alignment of its business model and strategy", 1L, "", 1, null },
                    { 10549L, "E4-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4705), null, null, 2L, 44L, true, 1L, null, null, "Explanation of how strategy and business model will be adjusted to improve and, ultimately, achieve alignment with relevant local, national and global public policy goals", 1L, "", 1, null },
                    { 10550L, "E4-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4707), null, null, 2L, 44L, true, 1L, null, null, "Include information about  its own operations and  explain how it is responding to material impacts in its related value chain", 1L, "", 1, null },
                    { 10551L, "E4-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4709), null, null, 2L, 44L, true, 1L, null, null, "Explanation of how b strategy interacts with  transition plan ", 1L, "", 1, null },
                    { 10552L, "E4-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4712), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of contribution to impact drivers and possible mitigation actions following mitigation hierarchy and main path-dependencies and locked-in assets and resources that are associated with biodiversity and ecosystems change ", 1L, "", 1, null },
                    { 10553L, "E4-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4714), null, null, 2L, 44L, true, 1L, null, null, "Explanation and quantification of investments and funding supporting the implementation of its transition plan", 1L, "", 1, null },
                    { 10554L, "E4-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4716), null, null, 2L, 44L, true, 1L, null, null, "Disclosure of objectives or plans for aligning economic activities (revenues, CapEx)", 1L, "", 1, null },
                    { 10555L, "E4-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4718), null, null, 2L, 44L, true, 1L, null, null, "Biodiversity offsets are part of transition plan", 1L, "", 1, null },
                    { 10556L, "E4-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4720), null, null, 2L, 44L, true, 1L, null, null, "Information about how process of implementing and updating transition plan is managed ", 1L, "", 1, null },
                    { 10557L, "E4-1_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4722), null, null, 2L, 44L, true, 1L, null, null, "Indication of metrics and related tools used to measure progress that are integrated in measurement approach (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10558L, "E4-1_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4724), null, null, 2L, 44L, true, 1L, null, null, "Administrative, management and supervisory bodies have approved transition plan", 1L, "", 1, null },
                    { 10559L, "E4-1_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4728), null, null, 2L, 44L, true, 1L, null, null, "Indication of current challenges and limitations to draft plan in relation to areas of significant impact and actions company is taking to address them (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10560L, "E4.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4730), null, null, 2L, 45L, null, 1L, null, null, "Policies to manage material impacts, risks, dependencies and opportunities related to biodiversity and ecosystems [see ESRS 2 - MDR-P]", 1L, "", 1, null },
                    { 10561L, "E4-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4733), null, null, 2L, 45L, true, 1L, null, null, "Disclosure on whether and how biodiversity and ecosystems-related policies relate to matters reported in E4 AR4", 1L, "", 1, null },
                    { 10562L, "E4-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4735), null, null, 2L, 45L, true, 1L, null, null, "Explanation of whether and  how biodiversity and ecosystems-related policy relates to material biodiversity and ecosystems-related impacts ", 1L, "", 1, null },
                    { 10563L, "E4-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4737), null, null, 2L, 45L, true, 1L, null, null, "Explanation of whether and  how biodiversity and ecosystems-related policy relates to material dependencies and material physical and transition risks and opportunities ", 1L, "", 1, null },
                    { 10564L, "E4-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4740), null, null, 2L, 45L, true, 1L, null, null, "Explanation of whether and how biodiversity and ecosystems-related policy supports traceability of products, components and raw materials with significant actual or potential impacts on biodiversity and ecosystems along value chain ", 1L, "", 1, null },
                    { 10565L, "E4-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4742), null, null, 2L, 45L, true, 1L, null, null, "Explanation of whether and how biodiversity and ecosystems-related policy addresses production, sourcing or consumption from ecosystems that are managed to maintain or enhance conditions for biodiversity ", 1L, "", 1, null },
                    { 10566L, "E4-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4749), null, null, 2L, 45L, true, 1L, null, null, "Explanation of whether and how biodiversity and ecosystems-related policy addresses social consequences of biodiversity and ecosystems-related impacts ", 1L, "", 1, null },
                    { 10567L, "E4-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4751), null, null, 2L, 45L, true, 1L, null, null, "Disclosure of how policy refers to production, sourcing or consumption of raw materials ", 1L, "", 1, null },
                    { 10568L, "E4-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4753), null, null, 2L, 45L, true, 1L, null, null, "Disclosure of how policy refers to policies limiting procurement from suppliers that cannot demonstrate that they are not contributing to significant conversion of protected areas or key biodiversity areas ", 1L, "", 1, null },
                    { 10569L, "E4-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4755), null, null, 2L, 45L, true, 1L, null, null, "Disclosure of how policy refers to recognised standards or third-party certifications overseen by regulators ", 1L, "", 1, null },
                    { 10570L, "E4-2_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4757), null, null, 2L, 45L, true, 1L, null, null, "Disclosure of how policy addresses raw materials originating from ecosystems that have been managed to maintain or enhance conditions for biodiversity, as demonstrated by regular monitoring and reporting of biodiversity status and gains or losses", 1L, "", 1, null },
                    { 10571L, "E4-2_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4760), null, null, 2L, 45L, true, 1L, null, null, "Disclosure of how the policy enables to a), b), c) and d)", 1L, "", 1, null },
                    { 10572L, "E4-2_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4764), null, null, 2L, 45L, null, 1L, null, null, "Third-party standard of conduct used in policy is objective and achievable based on scientific approach to identifying issues and realistic in assessing how these issues can be addressed under variety of practical circumstances", 1L, "", 1, null },
                    { 10573L, "E4-2_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4766), null, null, 2L, 45L, null, 1L, null, null, "Third-party standard of conduct used in policy is developed or maintained through process of ongoing consultation with relevant stakeholders with balanced input from all relevant stakeholder groups with no group holding undue authority or veto power over content", 1L, "", 1, null },
                    { 10574L, "E4-2_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4767), null, null, 2L, 45L, null, 1L, null, null, "Third-party standard of conduct used in policy encourages step-wise approach and continuous improvement in standard and its application of better management practices and requires establishment of meaningful targets and specific milestones to indicate progress against principles and criteria over time", 1L, "", 1, null },
                    { 10575L, "E4-2_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4769), null, null, 2L, 45L, null, 1L, null, null, "Third-party standard of conduct used in policy is verifiable through independent certifying or verifying bodies, which have defined and rigorous assessment procedures that avoid conflicts of interest and are compliant with ISO guidance on accreditation and verification procedures or Article 5(2) of Regulation (EC) No 765/2008", 1L, "", 1, null },
                    { 10576L, "E4-2_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4772), null, null, 2L, 45L, null, 1L, null, null, "Third-party standard of conduct used in policy conforms to ISEAL Code of Good Practice", 1L, "", 1, null },
                    { 10577L, "E4-2_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4774), null, null, 2L, 45L, null, 1L, null, null, "Biodiversity and ecosystem protection policy covering operational sites owned, leased, managed in or near protected area or biodiversity-sensitive area outside protected areas has been adopted", 1L, "", 1, null },
                    { 10578L, "E4-2_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4776), null, null, 2L, 45L, null, 1L, null, null, "Sustainable land or agriculture practices or policies have been adopted", 1L, "", 1, null },
                    { 10579L, "E4-2_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4779), null, null, 2L, 45L, null, 1L, null, null, "Sustainable oceans or seas practices or policies have been adopted", 1L, "", 1, null },
                    { 10580L, "E4-2_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4780), null, null, 2L, 45L, null, 1L, null, null, "Policies to address deforestation have been adopted", 1L, "", 1, null },
                    { 10582L, "E4.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4786), null, null, null, 46L, null, 1L, null, null, "Actions and resources in relation to biodiversity and ecosystems [see ESRS 2 - MDR-A]", 1L, "", 1, null },
                    { 10583L, "E4-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4788), null, null, 2L, 46L, true, 1L, null, null, "Disclosure on how the mitigation hierarchy has been applied with regard to biodiversity and ecosystem actions", 1L, "", 1, null },
                    { 10584L, "E4-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4789), null, null, 2L, 46L, null, 1L, null, null, "Biodiversity offsets were used in action plan", 1L, "", 1, null },
                    { 10585L, "E4-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4791), null, null, 2L, 46L, true, 1L, null, null, "Disclosure of aim of biodiversity offset and key performance indicators used ", 1L, "", 1, null },
                    { 10586L, "E4-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4796), null, null, 2L, 46L, null, 1L, null, null, "Financing effects (direct and indirect costs) of biodiversity offsets", 1L, "", 1, null },
                    { 10587L, "E4-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4801), null, null, 3L, 46L, true, 1L, null, null, "Explanation of rekationship of significant Capex and Opex required to impelement actions taken or planned to relevant line items or notes in the financial statements", 1L, "", 1, null },
                    { 10588L, "E4-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4803), null, null, 2L, 46L, true, 1L, null, null, "Explanation of rekationship of significant Capex and Opex required to impelement actions taken or planned to key  performance indicators required under Commission Delegated Regulation (EU) 2021/2178", 1L, "", 1, null },
                    { 10589L, "E4-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4805), null, null, 2L, 46L, true, 1L, null, null, "Explanation of rekationship of significant Capex and Opex required to impelement actions taken or planned to Capex plan required under Commission Delegated Regulation (EU) 2021/2178", 1L, "", 1, null },
                    { 10590L, "E4-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4808), null, null, 2L, 46L, true, 1L, null, null, "Description of biodiversity offsets ", 1L, "", 1, null },
                    { 10591L, "E4-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4811), null, null, 2L, 46L, true, 1L, null, null, "Description of whether and how local and indigenous knowledge and nature-based solutions have been incorporated into biodiversity and ecosystems-related action ", 1L, "", 1, null },
                    { 10592L, "E4-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4814), null, null, 2L, 46L, true, 1L, null, null, "Disclosure of key stakeholders involved and how they are involved, key stakeholders negatively or positively impacted by action and how they are impacted ", 1L, "", 1, null },
                    { 10593L, "E4-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4820), null, null, 2L, 46L, true, 1L, null, null, "Explanation of need for appropriate consultations and need to respect decisions of affected communities ", 1L, "", 1, null },
                    { 10594L, "E4-3_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4823), null, null, 2L, 46L, true, 1L, null, null, "Description of whether key action may induce significant negative sustainability impacts (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10595L, "E4-3_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4825), null, null, 2L, 46L, true, 1L, null, null, "Explanation of whether the key action is intended to be a one-time initiative or systematic practice", 1L, "", 1, null },
                    { 10596L, "E4-3_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4828), null, null, 2L, 46L, null, 1L, null, null, "Key action plan is carried out only by undertaking (individual action) using its resources (biodiversity and ecosystems)", 1L, "", 1, null },
                    { 10597L, "E4-3_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4830), null, null, 2L, 46L, null, 1L, null, null, "Key action plan is part of wider action plan (collective action), of which undertaking is member (biodiversity and ecosystems)", 1L, "", 1, null },
                    { 10598L, "E4-3_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4836), null, null, 2L, 46L, true, 1L, null, null, "Additional information about project, its sponsors and other participants (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10600L, "E4.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4840), null, null, null, 47L, null, 1L, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 1, null },
                    { 10601L, "E4-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4843), null, null, 2L, 47L, null, 1L, null, null, "Ecological threshold and allocation of impacts to undertaking were applied when setting target (biodiversity and ecosystems)", 1L, "", 1, null },
                    { 10602L, "E4-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4845), null, null, 2L, 47L, true, 1L, null, null, "Disclosure of ecological threshold identified and methodology used to identify threshold (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10603L, "E4-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4847), null, null, 2L, 47L, true, 1L, null, null, "Disclosure of how entity-specific threshold was determined (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10604L, "E4-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4849), null, null, 2L, 47L, true, 1L, null, null, "Disclosure of how responsibility for respecting identified ecological threshold is allocated (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10605L, "E4-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4851), null, null, 2L, 47L, null, 1L, null, null, "Target is informed by relevant aspect of EU Biodiversity Strategy for 2030", 1L, "", 1, null },
                    { 10606L, "E4-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4853), null, null, 2L, 47L, true, 1L, null, null, "Disclosure of how the targets relate to the biodiversity and ecosystem impacts, dependencies, risks and opportunities identified in relation to own operations and upstream and downstream value chain", 1L, "", 1, null },
                    { 10607L, "E4-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4856), null, null, 2L, 47L, true, 1L, null, null, "Disclosure of the geographical scope of the targets", 1L, "", 1, null },
                    { 10608L, "E4-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4858), null, null, 2L, 47L, null, 1L, null, null, "Biodiversity offsets were used in setting target", 1L, "", 1, null },
                    { 10609L, "E4-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4860), null, null, 2L, 47L, null, 1L, null, null, "Layer in mitigation hierarchy to which target can be allocated (biodiversity and ecosystems)", 1L, "", 1, null },
                    { 10610L, "E4-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4864), null, null, 2L, 47L, null, 1L, null, null, "The target addresses shortcomings related to the Substantial Contribution criteria ", 1L, "", 1, null },
                    { 10612L, "E4-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4868), null, null, null, 48L, null, 1L, null, null, "Number of sites owned, leased or managed in or near protected areas or key biodiversity areas that undertaking is negatively affecting", 1L, "", 1, null },
                    { 10613L, "E4-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4870), null, null, null, 48L, null, 1L, null, null, "Area of sites owned, leased or managed in or near protected areas or key biodiversity areas that undertaking is negatively affecting", 1L, "", 1, 709L },
                    { 10614L, "E4-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4872), null, null, null, 48L, true, 1L, null, null, "Disclosure of land-use based on Life Cycle Assessment ", 1L, "", 1, 12L },
                    { 10615L, "E4-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4874), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of metrics considered relevant (land-use change, freshwater-use change and (or) sea-use change) ", 1L, "", 1, null },
                    { 10616L, "E4-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4876), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of conversion over time of land cover ", 1L, "", 1, null },
                    { 10617L, "E4-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4878), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of changes over time in management of ecosystem ", 1L, "", 1, null },
                    { 10618L, "E4-5_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4880), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of changes in spatial configuration of landscape ", 1L, "", 1, null },
                    { 10619L, "E4-5_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4882), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of changes in ecosystem structural connectivity ", 1L, "", 1, null },
                    { 10620L, "E4-5_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4885), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of functional connectivity ", 1L, "", 1, null },
                    { 10621L, "E4-5_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4887), null, null, 2L, 48L, null, 1L, null, null, "Total use of land area", 1L, "", 1, null },
                    { 10622L, "E4-5_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4889), null, null, null, 48L, null, 1L, null, null, "Total sealed area", 1L, "", 1, 12L },
                    { 10623L, "E4-5_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4891), null, null, null, 48L, null, 1L, null, null, "Nature-oriented area on site", 1L, "", 1, 12L },
                    { 10624L, "E4-5_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4893), null, null, null, 48L, null, 1L, null, null, "Nature-oriented area off site", 1L, "", 1, 12L },
                    { 10625L, "E4-5_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4895), null, null, null, 48L, true, 1L, null, null, "Disclosure of how pathways of introduction and spread of invasive alien species and risks posed by invasive alien species are managed ", 1L, "", 1, 12L },
                    { 10626L, "E4-5_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4897), null, null, 2L, 48L, null, 1L, null, null, "Number of invasive alien species", 1L, "", 1, null },
                    { 10627L, "E4-5_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4899), null, null, null, 48L, null, 1L, null, null, "Area covered by invasive alien species", 1L, "", 1, 709L },
                    { 10628L, "E4-5_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4901), null, null, null, 48L, true, 1L, null, null, "Disclosure of metrics considered relevant (state of species) ", 1L, "", 1, 12L },
                    { 10629L, "E4-5_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4903), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of paragraph in another environment-related standard in which metric is referred to ", 1L, "", 1, null },
                    { 10630L, "E4-5_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4909), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of population size, range within specific ecosystems and extinction risk ", 1L, "", 1, null },
                    { 10631L, "E4-5_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4911), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of changes in number of individuals of species within specific area ", 1L, "", 1, null },
                    { 10632L, "E4-5_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4913), null, null, 2L, 48L, true, 1L, null, null, "Information about species at global extinction risk ", 1L, "", 1, null },
                    { 10633L, "E4-5_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4915), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of threat status of species and how activities or pressures may affect threat status ", 1L, "", 1, null },
                    { 10634L, "E4-5_23", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4918), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of change in relevant habitat for threatened species as proxy for impact on local population's extinction risk ", 1L, "", 1, null },
                    { 10635L, "E4-5_24", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4920), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of ecosystem area coverage ", 1L, "", 1, null },
                    { 10636L, "E4-5_25", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4922), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of quality of ecosystems relative to pre-determined reference state ", 1L, "", 1, null },
                    { 10637L, "E4-5_26", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4924), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of multiple species within ecosystem ", 1L, "", 1, null },
                    { 10638L, "E4-5_27", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4926), null, null, 2L, 48L, true, 1L, null, null, "Disclosure of structural components of ecosystem condition ", 1L, "", 1, null },
                    { 10639L, "E4-6_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4929), null, null, 2L, 49L, null, 1L, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from biodiversity- and ecosystem-related impacts and dependencies ", 1L, "", 1, null },
                    { 10640L, "E4-6_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4932), null, null, 3L, 49L, true, 1L, null, null, "Disclosure of qualitative information about anticipated financial effects of material risks and opportunities arising from biodiversity- and ecosystem-related impacts and dependencies ", 1L, "", 1, null },
                    { 10641L, "E4-6_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4934), null, null, 2L, 49L, true, 1L, null, null, "Description of effects considered, related impacts and dependencies (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10642L, "E4-6_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4936), null, null, 2L, 49L, true, 1L, null, null, "Disclosure of critical assumptions used in estimates of financial effects of material risks and opportunities arising from biodiversity- and ecosystem-related impacts and dependencies ", 1L, "", 1, null },
                    { 10643L, "E4-6_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4938), null, null, 2L, 49L, true, 1L, null, null, "Description of related products and services at risk (biodiversity and ecosystems) over the short-, medium- and long-term", 1L, "", 1, null },
                    { 10644L, "E4-6_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4940), null, null, 2L, 49L, null, 1L, null, null, "Explanation of how financial amounts are estimated and critical assumptions made (biodiversity and ecosystems) ", 1L, "", 1, null },
                    { 10645L, "E5.IRO-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4942), null, null, 2L, 50L, true, 1L, null, null, "Disclosure of whether the undertaking has screened its assets and activities in order to identify actual and potential impacts, risks and opportunities in own operations and upstream and downstream value chain, and if so, methodologies, assumptions and tools used", 1L, "", 1, null },
                    { 10646L, "E5.IRO-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4944), null, null, 2L, 50L, true, 1L, null, null, "Disclosure of whether and how the undertaking has conducted consultations (resource and circular economy) ", 1L, "", 1, null },
                    { 10647L, "E5.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4947), null, null, 2L, 51L, null, 1L, null, null, "Policies to manage its material impacts, risks and opportunities related to resource use and circular economy [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 10648L, "E5-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4950), null, null, 2L, 51L, true, 1L, null, null, "Disclosure of whether and how policy addresses transitioning away from use of virgin resources, including relative increases in use of secondary (recycled) resources", 1L, "", 1, null },
                    { 10649L, "E5-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4955), null, null, 2L, 51L, true, 1L, null, null, "Disclosure of whether and how policy addresses sustainable sourcing and use of renewable resources", 1L, "", 1, null },
                    { 10650L, "E5-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4958), null, null, 2L, 51L, true, 1L, null, null, "Description of whether and how policy addresses waste hierarchy (prevention, preparing for re-use, recycling, other recovery, disposal) ", 1L, "", 1, null },
                    { 10651L, "E5-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4960), null, null, 2L, 51L, true, 1L, null, null, "Description of  whether and how policy addresses prioritisation of strategies to avoid or minimise waste over waste treatment strategies ", 1L, "", 1, null },
                    { 10653L, "E5.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4965), null, null, null, 52L, null, 1L, null, null, "Actions and resources in relation to resource use and circular economy [see ESRS 2 MDR-A]", 1L, "", 1, null },
                    { 10654L, "E5-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4968), null, null, 2L, 52L, true, 1L, null, null, "Description of higher levels of resource efficiency in use of technical and biological materials and water", 1L, "", 1, null },
                    { 10655L, "E5-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4970), null, null, 2L, 52L, true, 1L, null, null, "Description of higher rates of use of secondary raw materials", 1L, "", 1, null },
                    { 10656L, "E5-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4972), null, null, 2L, 52L, true, 1L, null, null, "Description of application of circular design", 1L, "", 1, null },
                    { 10657L, "E5-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4975), null, null, 2L, 52L, true, 1L, null, null, "Description of application of circular business practices", 1L, "", 1, null },
                    { 10658L, "E5-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4977), null, null, 2L, 52L, true, 1L, null, null, "Description of actions taken to prevent waste generation in the undertaking's upstream and downstram value chain", 1L, "", 1, null },
                    { 10659L, "E5-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4979), null, null, 2L, 52L, true, 1L, null, null, "Description of Optimistation of waste management", 1L, "", 1, null },
                    { 10660L, "E5-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4981), null, null, 2L, 52L, true, 1L, null, null, "Information about collective action on development of collaborations or initiatives increasing circularity of products and materials ", 1L, "", 1, null },
                    { 10661L, "E5-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4984), null, null, 2L, 52L, true, 1L, null, null, "Description of contribution to circular economy ", 1L, "", 1, null },
                    { 10662L, "E5-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4990), null, null, 2L, 52L, true, 1L, null, null, "Description of other stakeholders involved in collective action (resource use and circular economy) ", 1L, "", 1, null },
                    { 10663L, "E5-2_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4992), null, null, 2L, 52L, true, 1L, null, null, "Description of organisation of project (resource use and circular economy) ", 1L, "", 1, null },
                    { 10665L, "E5.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4996), null, null, null, 53L, null, 1L, null, null, "Tracking effectiveness of policies and actions through targets [see ESRS 2 MDR-T ]", 1L, "", 1, null },
                    { 10666L, "E5-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(4998), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how target relates to resources (resource use and circular economy) ", 1L, "", 1, null },
                    { 10667L, "E5-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5000), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how target relates to increase of circular design ", 1L, "", 1, null },
                    { 10668L, "E5-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5002), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how target relates to increase of circular material use rate ", 1L, "", 1, null },
                    { 10669L, "E5-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5004), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how target relates to minimisation of primary raw material ", 1L, "", 1, null },
                    { 10670L, "E5-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5006), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how target relates to reversal of depletion of stock of renewable resources ", 1L, "", 1, null },
                    { 10671L, "E5-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5008), null, null, 2L, 53L, null, 1L, null, null, "Target relates to waste management", 1L, "", 1, null },
                    { 10672L, "E5-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5010), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how target relates to waste management ", 1L, "", 1, null },
                    { 10673L, "E5-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5012), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how target relates to other matters related to resource use or circular economy", 1L, "", 1, null },
                    { 10674L, "E5-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5015), null, null, 2L, 53L, null, 1L, null, null, "Layer in waste hierarchy to which target relates", 1L, "", 1, null },
                    { 10675L, "E5-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5017), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of ecological threshold identified and methodology used to identify ecological threshold (resource use and circular economy) ", 1L, "", 1, null },
                    { 10676L, "E5-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5019), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how ecological entity-specific threshold was determined (resource use and circular economy) ", 1L, "", 1, null },
                    { 10677L, "E5-3_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5021), null, null, 2L, 53L, true, 1L, null, null, "Disclosure of how responsibility for respecting identified ecological threshold is allocated (resource use and circular economy) ", 1L, "", 1, null },
                    { 10678L, "E5-3_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5023), null, null, 2L, 53L, null, 1L, null, null, "The targets being  set and presented are mandatory (required by legislation)", 1L, "", 1, null },
                    { 10680L, "E5-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5027), null, null, null, 54L, true, 1L, null, null, "Disclosure of information on material resource inflows ", 1L, "", 1, null },
                    { 10681L, "E5-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5029), null, null, 2L, 54L, null, 1L, null, null, "Overall total weight of products and technical and biological materials used during the reporting period", 1L, "", 1, null },
                    { 10682L, "E5-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5031), null, null, null, 54L, null, 1L, null, null, "Percentage of biological materials (and biofuels used for non-energy purposes)", 1L, "", 1, 79L },
                    { 10683L, "E5-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5033), null, null, null, 54L, null, 1L, null, null, "The absolute weight of secondary reused or recycled components, secondary intermediary products and secondary materials used to manufacture the undertaking’s products and services (including packaging)", 1L, "", 1, 38L },
                    { 10684L, "E5-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5035), null, null, null, 54L, null, 1L, null, null, "Percentage of secondary reused or recycled components, secondary intermediary products and secondary materials", 1L, "", 1, 79L },
                    { 10685L, "E5-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5037), null, null, null, 54L, true, 1L, null, null, "Description of methodologies used to calculate data and key assumptions used", 1L, "", 1, 38L },
                    { 10686L, "E5-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5039), null, null, 2L, 54L, true, 1L, null, null, "Description of materials that are sourced from by-products or waste stream ", 1L, "", 1, null },
                    { 10687L, "E5-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5041), null, null, 2L, 54L, true, 1L, null, null, "Description of how double counting was avoided and of choices made ", 1L, "", 1, null },
                    { 10688L, "E5-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5043), null, null, 2L, 55L, true, 1L, null, null, "Description of the key products and materials that come out of the undertaking’s production process", 1L, "", 1, null },
                    { 10689L, "E5-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5045), null, null, 2L, 55L, null, 1L, null, null, "Disclosure of the expected durability of the products placed on the market, in relation to the industry average for each product group", 1L, "", 1, null },
                    { 10690L, "E5-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5047), null, null, null, 55L, true, 1L, null, null, "Disclosure of the reparability of products", 1L, "", 1, 38L },
                    { 10691L, "E5-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5049), null, null, 2L, 55L, null, 1L, null, null, "The rates of recyclable content in products", 1L, "", 1, null },
                    { 10692L, "E5-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5051), null, null, null, 55L, null, 1L, null, null, "The rates of recyclable content in products packaging", 1L, "", 1, 38L },
                    { 10693L, "E5-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5053), null, null, null, 55L, true, 1L, null, null, "Description of methodologies used to calculate data (resource outflows) ", 1L, "", 1, 38L },
                    { 10694L, "E5-5_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5060), null, null, 2L, 55L, null, 1L, null, null, "Total Waste generated", 1L, "", 1, null },
                    { 10695L, "E5-5_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5062), null, null, null, 55L, null, 1L, null, null, "Waste diverted from disposal, breakdown by hazardous and non-hazardous waste and treatment type", 1L, "", 1, 79L },
                    { 10696L, "E5-5_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5064), null, null, null, 55L, null, 1L, null, null, "Waste directed to disposal, breakdown by hazardous and non-hazardous waste and treatment type", 1L, "", 1, 79L },
                    { 10697L, "E5-5_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5066), null, null, null, 55L, null, 1L, null, null, "Non-recycled waste", 1L, "", 1, 79L },
                    { 10698L, "E5-5_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5068), null, null, null, 55L, null, 1L, null, null, "Percentage of non-recycled waste", 1L, "", 1, 79L },
                    { 10699L, "E5-5_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5070), null, null, null, 55L, true, 1L, null, null, "Disclosure of composition of waste ", 1L, "", 1, 38L },
                    { 10700L, "E5-5_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5072), null, null, 2L, 55L, true, 1L, null, null, "Disclosure of waste streams relevant to undertaking's sector or activities ", 1L, "", 1, null },
                    { 10701L, "E5-5_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5074), null, null, 2L, 55L, true, 1L, null, null, "Disclosure of materials that are present in waste ", 1L, "", 1, null },
                    { 10702L, "E5-5_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5077), null, null, 2L, 55L, null, 1L, null, null, "Total amount of hazardous waste", 1L, "", 1, null },
                    { 10703L, "E5-5_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5080), null, null, null, 55L, null, 1L, null, null, "Total amount of radioactive waste", 1L, "", 1, 79L },
                    { 10704L, "E5-5_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5082), null, null, null, 55L, true, 1L, null, null, "Description of methodologies used to calculate data (waste generated) ", 1L, "", 1, 79L },
                    { 10705L, "E5-5_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5084), null, null, 2L, 55L, true, 1L, null, null, "Disclosure of its engagement in product end-of-life waste management", 1L, "", 1, null },
                    { 10706L, "E5-6_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5086), null, null, 2L, 56L, null, 1L, null, null, "Disclosure of quantitative information about anticipated financial effects of material risks and opportunities arising from resource use and circular economy-related impacts ", 1L, "", 1, null },
                    { 10707L, "E5-6_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5088), null, null, 3L, 56L, true, 1L, null, null, "Disclosure of qualitative information of anticipated financial effects of material risks and opportunities arising from resource use and circular economy-related impacts ", 1L, "", 1, null },
                    { 10708L, "E5-6_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5091), null, null, 2L, 56L, true, 1L, null, null, "Description of effects considered and related impacts (resource use and circular economy) ", 1L, "", 1, null },
                    { 10709L, "E5-6_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5093), null, null, 2L, 56L, true, 1L, null, null, "Disclosure of critical assumptions used in estimates of financial effects of material risks and opportunities arising from resource use and circular economy-related impacts ", 1L, "", 1, null },
                    { 10710L, "E5-6_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5095), null, null, 2L, 56L, true, 1L, null, null, "Description of related products and services at risk (resource use and circular economy) ", 1L, "", 1, null },
                    { 10711L, "E5-6_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5097), null, null, 2L, 56L, true, 1L, null, null, "Explanation of how time horizons are defined, financial amounts are estimated and of critical assumptions made (resource use and circular economy) ", 1L, "", 1, null },
                    { 10713L, "S1.SBM-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5101), null, null, 2L, 58L, true, 1L, null, null, "Description of types of employees and non-employees in its own workforce subject to material impacts ", 1L, "", 1, null },
                    { 10714L, "S1.SBM-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5104), null, null, 2L, 58L, null, 1L, null, null, "Material negative impacts occurrence (own workforce)", 1L, "", 1, null },
                    { 10715L, "S1.SBM-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5106), null, null, 2L, 58L, true, 1L, null, null, "Description of activities that result in positive impacts and types of employees and non-employees in its own workforce that are positively affected or could be positively affected ", 1L, "", 1, null },
                    { 10716L, "S1.SBM-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5109), null, null, 2L, 58L, true, 1L, null, null, "Description of material risks and opportunities arising from impacts and dependencies on own workforce  ", 1L, "", 1, null },
                    { 10717L, "S1.SBM-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5111), null, null, 2L, 58L, true, 1L, null, null, "Description of material impacts on workers that may arise from transition plans for reducing negative impacts on environment and achieving greener and climate-neutral operations ", 1L, "", 1, null },
                    { 10718L, "S1.SBM-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5113), null, null, 2L, 58L, true, 1L, null, null, "Information about type of operations at significant risk of incidents of forced labour or compulsory labour ", 1L, "", 1, null },
                    { 10719L, "S1.SBM-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5115), null, null, 2L, 58L, true, 1L, null, null, "Information about countries or geographic areas with operations considered at significant risk of incidents of forced labour or compulsory labour ", 1L, "", 1, null },
                    { 10720L, "S1.SBM-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5117), null, null, 2L, 58L, true, 1L, null, null, "Information about type of operations at significant risk of incidents of child labour ", 1L, "", 1, null },
                    { 10721L, "S1.SBM-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5120), null, null, 2L, 58L, true, 1L, null, null, "Information about countries or geographic areas with operations considered at significant risk of incidents of child labour ", 1L, "", 1, null },
                    { 10722L, "S1.SBM-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5122), null, null, 2L, 58L, true, 1L, null, null, "Disclosure of whether and how understanding of people in its own workforce with particular characteristics, working in particular contexts, or undertaking particular activities may be at greater risk of harm has been developed ", 1L, "", 1, null },
                    { 10723L, "S1.SBM-3_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5124), null, null, 2L, 58L, true, 1L, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on people in its own workforce  relate to specific groups of people", 1L, "", 1, null },
                    { 10724L, "S1.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5126), null, null, 2L, 59L, null, 1L, null, null, "Policies to manage material impacts, risks and opportunities related to its own workforce [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 10725L, "S1-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5128), null, null, 2L, 59L, null, 1L, null, null, "Policies to manage material impacts, risks and opportunities related to own workforce, including for specific groups within workforce or all own workforce", 1L, "", 1, null },
                    { 10726L, "S1-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5133), null, null, 2L, 59L, true, 1L, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 1, null },
                    { 10727L, "S1-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5135), null, null, 2L, 59L, true, 1L, null, null, "Description of relevant human rights policy commitments relevant to own workforce", 1L, "", 1, null },
                    { 10728L, "S1-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5138), null, null, 2L, 59L, true, 1L, null, null, "Disclosure of general approach in relation to respect for human rights including labour rights, of people in its own workforce", 1L, "", 1, null },
                    { 10729L, "S1-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5140), null, null, 2L, 59L, true, 1L, null, null, "Disclosure of general approach in relation to engagement with people in its own workforce", 1L, "", 1, null },
                    { 10730L, "S1-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5142), null, null, 2L, 59L, true, 1L, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 1, null },
                    { 10731L, "S1-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5144), null, null, 2L, 59L, true, 1L, null, null, "Disclosure of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 1, null },
                    { 10732L, "S1-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5146), null, null, 2L, 59L, null, 1L, null, null, "Policies explicitly address trafficking in human beings, forced labour or compulsory labour and child labour", 1L, "", 1, null },
                    { 10733L, "S1-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5148), null, null, 2L, 59L, null, 1L, null, null, "Workplace accident prevention policy or management system is in place", 1L, "", 1, null },
                    { 10734L, "S1-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5150), null, null, 2L, 59L, null, 1L, null, null, "Specific policies aimed at elimination of discrimination are in place", 1L, "", 1, null },
                    { 10735L, "S1-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5153), null, null, 2L, 59L, null, 1L, null, null, "Grounds for discrimination are specifically covered in policy", 1L, "", 1, null },
                    { 10736L, "S1-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5155), null, null, 2L, 59L, true, 1L, null, null, "Disclosure of specific policy commitments related to inclusion and (or) positive action for people from groups at particular risk of vulnerability in own workforce ", 1L, "", 1, null },
                    { 10737L, "S1-1_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5157), null, null, 2L, 59L, true, 1L, null, null, "Disclosure of whether and how policies are implemented through specific procedures to ensure discrimination is prevented, mitigated and acted upon once detected, as well as to advance diversity and inclusion ", 1L, "", 1, null },
                    { 10738L, "S1-1_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5159), null, null, 2L, 59L, true, 1L, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 1, null },
                    { 10739L, "S1-1_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5161), null, null, 2L, 59L, null, 1L, null, null, "Policies and procedures which make qualifications, skills and experience the basis for the recruitment, placement, training and advancement are in place", 1L, "", 1, null },
                    { 10740L, "S1-1_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5163), null, null, 2L, 59L, null, 1L, null, null, "Has assigned responsibility at top management level for equal treatment and opportunities in employment, issue clear company-wide policies and procedures to guide equal employment practices, and link advancement to desired performance in this area", 1L, "", 1, null },
                    { 10741L, "S1-1_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5165), null, null, 2L, 59L, null, 1L, null, null, "Staff training on non-discrimination policies and practices are in place", 1L, "", 1, null },
                    { 10742L, "S1-1_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5168), null, null, 2L, 59L, null, 1L, null, null, "Adjustments to the physical environment to ensure health and safety for workers, customers and other visitors with disabilities are in place", 1L, "", 1, null },
                    { 10743L, "S1-1_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5170), null, null, 2L, 59L, null, 1L, null, null, "Has evaluated whether a there is a risk that job requirements have been defined in a way that would systematically disadvantage certain groups", 1L, "", 1, null },
                    { 10744L, "S1-1_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5172), null, null, 2L, 59L, null, 1L, null, null, "Keeping an up-to-date records on recruitment, training and promotion that provide a transparent view of opportunities for employees and their progression", 1L, "", 1, null },
                    { 10745L, "S1-1_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5174), null, null, 2L, 59L, null, 1L, null, null, "Has put in place grievance procedures to address complaints, handle appeals and provide recourse for employees when discrimination is identified, and is alert to formal structures and informal cultural issues that can prevent employees from raising concerns and grievances", 1L, "", 1, null },
                    { 10746L, "S1-1_22", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5176), null, null, 2L, 59L, null, 1L, null, null, "Has programs to promote access to skills development. ", 1L, "", 1, null },
                    { 10748L, "S1-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5179), null, null, null, 60L, true, 1L, null, null, "Disclosure of whether and how perspectives of own workforce  inform decisions or activities aimed at managing actual and potential  impacts ", 1L, "", 1, null },
                    { 10749L, "S1-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5182), null, null, 2L, 60L, null, 1L, null, null, "Engagement occurs with own workforce  or their representatives", 1L, "", 1, null },
                    { 10750L, "S1-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5184), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 1, null },
                    { 10751L, "S1-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5186), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakingâ€™s approach ", 1L, "", 1, null },
                    { 10752L, "S1-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5188), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of Global Framework Agreement or other agreements related to respect of human rights of workers ", 1L, "", 1, null },
                    { 10753L, "S1-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5190), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of how effectiveness of engagement with its own workforce  is assessed ", 1L, "", 1, null },
                    { 10754L, "S1-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5192), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of steps taken to gain insight into perspectives of people in its own workforce that may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 1, null },
                    { 10755L, "S1-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5194), null, null, 2L, 60L, true, 1L, null, null, "Statement in case the undertaking has not adopted a general process to engage with its own workforce", 1L, "", 1, null },
                    { 10756L, "S1-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5199), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of timeframe for adoption of general process to engage with its own workforce in case the undertaking has not adopted a general process for engagement", 1L, "", 1, null },
                    { 10757L, "S1-2_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5201), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of how undertaking engages with at-risk or persons in vulnerable situations", 1L, "", 1, null },
                    { 10758L, "S1-2_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5206), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of how potential barriers to engagement with people in its workforce are taken into account ", 1L, "", 1, null },
                    { 10759L, "S1-2_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5208), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of how people in its workforce are provided with information that is understandable and accessible through appropriate communication channels ", 1L, "", 1, null },
                    { 10760L, "S1-2_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5210), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of any conflicting interests that have arisen among different workers and how these conflicting interests have been resolved ", 1L, "", 1, null },
                    { 10761L, "S1-2_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5212), null, null, 2L, 60L, true, 1L, null, null, "Disclosure of how undertaking seeks to respect human rights of all stakeholders engaged ", 1L, "", 1, null },
                    { 10762L, "S1-2_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5217), null, null, 2L, 60L, true, 1L, null, null, "Information about effectiveness of processes for engaging with its own workforce from previous reporting periods ", 1L, "", 1, null },
                    { 10763L, "S1-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5219), null, null, 2L, 61L, true, 1L, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has caused or contributed to a material negative impact on people in its own workforce  ", 1L, "", 1, null },
                    { 10764L, "S1-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5221), null, null, 2L, 61L, true, 1L, null, null, "Disclosure of specific channels in place for its own workforce to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 1, null },
                    { 10765L, "S1-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5223), null, null, 2L, 61L, null, 1L, null, null, "Third-party mechanisms are accessible to all own workforce", 1L, "", 1, null },
                    { 10766L, "S1-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5225), null, null, 2L, 61L, true, 1L, null, null, "Disclosure of whether and how own workforce and their workers' representatives are able to access channels at level of undertaking they are employed by or contracted to work for ", 1L, "", 1, null },
                    { 10767L, "S1-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5227), null, null, 2L, 61L, null, 1L, null, null, "Grievance or complaints handling mechanisms related to employee matters exist", 1L, "", 1, null },
                    { 10768L, "S1-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5229), null, null, 2L, 61L, true, 1L, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 1, null },
                    { 10769L, "S1-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5232), null, null, 2L, 61L, true, 1L, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 1, null },
                    { 10770L, "S1-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5234), null, null, 2L, 61L, true, 1L, null, null, "Disclosure of whether and how it is assessed that its own workforce is aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 1, null },
                    { 10771L, "S1-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5236), null, null, 2L, 61L, null, 1L, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 1, null },
                    { 10772L, "S1-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5238), null, null, 2L, 61L, true, 1L, null, null, "Statement in case the undertaking has not adopted a channel for raising concerns ", 1L, "", 1, null },
                    { 10773L, "S1-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5240), null, null, 2L, 61L, true, 1L, null, null, "Disclosure of timeframe for channel for raising concerns to be in place", 1L, "", 1, null },
                    { 10774L, "S1.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5242), null, null, 2L, 62L, null, 1L, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to its own workforce [see ESRS 2 - MDR-A]", 1L, "", 1, null },
                    { 10775L, "S1-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5244), null, null, 2L, 62L, true, 1L, null, null, "Description of action taken, planned or underway to prevent or mitigate negative impacts on own workforce  ", 1L, "", 1, null },
                    { 10776L, "S1-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5247), null, null, 2L, 62L, true, 1L, null, null, "Disclosure on whether and how action has been taken to provide or enable remedy in relation to actual material impact", 1L, "", 1, null },
                    { 10777L, "S1-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5249), null, null, 2L, 62L, true, 1L, null, null, "Description of additional initiatives or actions with primary purpose of delivering positive impacts for own workforce", 1L, "", 1, null },
                    { 10778L, "S1-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5251), null, null, 2L, 62L, true, 1L, null, null, "Description of how effectiveness of actions and initiatives in delivering outcomes for own workforce is tracked and assessed ", 1L, "", 1, null },
                    { 10779L, "S1-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5253), null, null, 2L, 62L, true, 1L, null, null, "Description of process through which it identifies what action is needed and appropriate in response to particular actual or potential negative impact on own workforce  ", 1L, "", 1, null },
                    { 10780L, "S1-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5255), null, null, 2L, 62L, true, 1L, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on own workforce  and how effectiveness is tracked ", 1L, "", 1, null },
                    { 10781L, "S1-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5257), null, null, 2L, 62L, true, 1L, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to own workforce  ", 1L, "", 1, null },
                    { 10782L, "S1-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5260), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on own workforce  ", 1L, "", 1, null },
                    { 10783L, "S1-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5262), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of resources are allocated to the management of material impacts", 1L, "", 1, null },
                    { 10784L, "S1-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5264), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of general and specific approaches to addressing material negative impacts ", 1L, "", 1, null },
                    { 10785L, "S1-4_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5266), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of initiatives aimed at contributing to additional material positive impacts ", 1L, "", 1, null },
                    { 10786L, "S1-4_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5268), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of how far undertaking has progressed in efforts during reporting period ", 1L, "", 1, null },
                    { 10787L, "S1-4_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5270), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of aims for continued improvement ", 1L, "", 1, null },
                    { 10788L, "S1-4_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5272), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting own workforce  ", 1L, "", 1, null },
                    { 10789L, "S1-4_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5275), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of how the initiative, and its own involvement, is aiming to address the material impact concerned", 1L, "", 1, null },
                    { 10790L, "S1-4_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5282), null, null, 2L, 62L, true, 1L, null, null, "Disclosure of whether and how workers and workers' representatives play role in decisions regarding design and implementation of programmes or processes whose primary aim is to deliver positive impacts for workers ", 1L, "", 1, null },
                    { 10791L, "S1-4_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5284), null, null, 2L, 62L, true, 1L, null, null, "Information about intended or achieved positive outcomes of programmes or processes for own workforce  ", 1L, "", 1, null },
                    { 10792L, "S1-4_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5285), null, null, 2L, 62L, null, 1L, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for own workforce  are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 1, null },
                    { 10793L, "S1-4_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5288), null, null, 2L, 62L, true, 1L, null, null, "Information about measures taken to mitigate negative impacts on workers that arise from transition to greener, climate-neutral economy ", 1L, "", 1, null },
                    { 10794L, "S1-4_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5289), null, null, 2L, 62L, true, 1L, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 1, null },
                    { 10796L, "S1.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5294), null, null, null, 63L, null, 1L, null, null, "Targets set to manage material impacts, risks and opportunities related to own workforce [see ESRS 2 - MDR-T]", 1L, "", 1, null },
                    { 10797L, "S1-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5296), null, null, 2L, 63L, true, 1L, null, null, "Disclosure of whether and how own workforce or workforce' representatives were engaged directly in setting targets ", 1L, "", 1, null },
                    { 10798L, "S1-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5298), null, null, 2L, 63L, true, 1L, null, null, "Disclosure of whether and how own workforce or workforce' representatives were engaged directly in tracking performance against targets ", 1L, "", 1, null },
                    { 10799L, "S1-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5300), null, null, 2L, 63L, true, 1L, null, null, "Disclosure of whether and how own workforce or workforce' representatives were engaged directly in identifying lessons or improvements as result of undertakings performance ", 1L, "", 1, null },
                    { 10800L, "S1-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5302), null, null, 2L, 63L, true, 1L, null, null, "Disclosure of intended outcomes to be achieved in lives of people in its own workforce  ", 1L, "", 1, null },
                    { 10801L, "S1-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5304), null, null, 2L, 63L, null, 1L, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 1, null },
                    { 10802L, "S1-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5306), null, null, 2L, 63L, true, 1L, null, null, "Disclosure of references to standards or commitments which targets are based on", 1L, "", 1, null },
                    { 10804L, "S1-6_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5310), null, null, null, 64L, null, 1L, null, null, "Characteristics of undertaking's employees - number of employees by gender [table]", 1L, "", 1, null },
                    { 10805L, "S1-6_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5312), null, null, 1L, 64L, null, 1L, null, null, "Number of employees (head count)", 1L, "", 1, null },
                    { 10806L, "S1-6_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5314), null, null, null, 64L, null, 1L, null, null, "Average number of employees (head count)", 1L, "", 1, 710L },
                    { 10807L, "S1-6_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5316), null, null, null, 64L, null, 1L, null, null, "Characteristics of undertaking's employees - number of employees in countries with 50 or more employees representing at least 10% of total number of employees [table]", 1L, "", 1, 710L },
                    { 10808L, "S1-6_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5318), null, null, 1L, 64L, null, 1L, null, null, "Number of employees in countries with 50 or more employees representing at least 10% of total number of employees", 1L, "", 1, null },
                    { 10809L, "S1-6_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5320), null, null, null, 64L, null, 1L, null, null, "Average number of employees in countries with 50 or more employees representing at least 10% of total number of employees", 1L, "", 1, 710L },
                    { 10810L, "S1-6_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5323), null, null, null, 64L, null, 1L, null, null, "Characteristics of undertaking's employees - information on employees by contract type and gender  [table]", 1L, "", 1, 710L },
                    { 10811L, "S1-6_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5325), null, null, 1L, 64L, null, 1L, null, null, "Characteristics of undertaking's employees - information on employees by region [table]", 1L, "", 1, null },
                    { 10812L, "S1-6_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5327), null, null, 1L, 64L, null, 1L, null, null, "Number of employees (head count or full-time equivalent)", 1L, "", 1, null },
                    { 10813L, "S1-6_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5329), null, null, null, 64L, null, 1L, null, null, "Average number of employees (head count or full-time equivalent)", 1L, "", 1, 710L },
                    { 10814L, "S1-6_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5331), null, null, null, 64L, null, 1L, null, null, "Number of employee who have left undertaking ", 1L, "", 1, 710L },
                    { 10815L, "S1-6_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5332), null, null, null, 64L, null, 1L, null, null, "Percentage of employee turnover", 1L, "", 1, 710L },
                    { 10816L, "S1-6_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5335), null, null, null, 64L, true, 1L, null, null, "Description of methodologies and assumptions used to compile data (employees) ", 1L, "", 1, 38L },
                    { 10817L, "S1-6_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5337), null, null, 2L, 64L, null, 1L, null, null, "Employees numbers are reported in head count or full-time equivalent", 1L, "", 1, null },
                    { 10818L, "S1-6_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5339), null, null, 2L, 64L, null, 1L, null, null, "Employees numbers are reported at end of reporting period/average/other methodology", 1L, "", 1, null },
                    { 10819L, "S1-6_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5341), null, null, 2L, 64L, true, 1L, null, null, "Disclosure of contextual information necessary to understand data (employees) ", 1L, "", 1, null },
                    { 10820L, "S1-6_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5343), null, null, 2L, 64L, true, 1L, null, null, "Disclosure of cross-reference of information reported under paragragph 50 (a) to most representative number in financial statements ", 1L, "", 1, null },
                    { 10821L, "S1-6_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5345), null, null, 2L, 64L, null, 1L, null, null, "Further detailed breakdown by gender and by region [table]", 1L, "", 1, null },
                    { 10822L, "S1-6_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5350), null, null, 1L, 64L, null, 1L, null, null, "Number of full-time employees by head count or full time equivalent", 1L, "", 1, null },
                    { 10823L, "S1-6_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5353), null, null, null, 64L, null, 1L, null, null, "Number of part-time employees by head count or full time equivalent", 1L, "", 1, 710L },
                    { 10824L, "S1-7_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5355), null, null, null, 65L, null, 1L, null, null, "Number of non-employees in own workforce", 1L, "", 1, 710L },
                    { 10825L, "S1-7_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5357), null, null, null, 65L, null, 1L, null, null, "Number of non-employees in own workforce - self-employed people", 1L, "", 1, 710L },
                    { 10826L, "S1-7_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5359), null, null, null, 65L, null, 1L, null, null, "Number of non-employees in own workforce - people provided by undertakings primarily engaged in employment activities", 1L, "", 1, 710L },
                    { 10827L, "S1-7_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5361), null, null, null, 65L, null, 1L, null, null, "Undertaking does not have non-employees in own workforce", 1L, "", 1, 710L },
                    { 10828L, "S1-7_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5363), null, null, 2L, 65L, true, 1L, null, null, "Disclosure of the most common types of non-employees (for example, self-employed people, people provided by undertakings primarily engaged in employment activities, and other types relevant to the undertaking), their relationship with the undertaking, and the type of work that they perform.", 1L, "", 1, null },
                    { 10829L, "S1-7_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5365), null, null, 2L, 65L, true, 1L, null, null, "Description of methodologies and assumptions used to compile data (non-employees) ", 1L, "", 1, null },
                    { 10830L, "S1-7_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5367), null, null, 2L, 65L, null, 1L, null, null, "Non-employees numbers are reported in head count/full time equivalent", 1L, "", 1, null },
                    { 10831L, "S1-7_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5369), null, null, 2L, 65L, null, 1L, null, null, "Non-employees numbers are reported at end of reporting period/average/other methodology", 1L, "", 1, null },
                    { 10832L, "S1-7_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5371), null, null, 2L, 65L, true, 1L, null, null, "Disclosure of contextual information necessary to understand data (non-employee workers) ", 1L, "", 1, null },
                    { 10833L, "S1-7_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5373), null, null, 2L, 65L, true, 1L, null, null, "Description of basis of preparation of non-employees estimated number ", 1L, "", 1, null },
                    { 10834L, "S1-8_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5375), null, null, 2L, 66L, null, 1L, null, null, "Percentage of total employees covered by collective bargaining agreements", 1L, "", 1, null },
                    { 10835L, "S1-8_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5377), null, null, null, 66L, null, 1L, null, null, "Percentage of own employees covered by collective bargaining agreements are within coverage rate by country with significant employment (in the EEA)", 1L, "", 1, 38L },
                    { 10836L, "S1-8_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5379), null, null, null, 66L, null, 1L, null, null, "Percentage of own employees covered by collective bargaining agreements (outside EEA) by region", 1L, "", 1, 38L },
                    { 10837L, "S1-8_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5382), null, null, null, 66L, null, 1L, null, null, "Working conditions and terms of employment for employees not covered by collective bargaining agreements are determined based on collective bargaining agreements that cover other employees or based on collective bargaining agreements from other undertakings", 1L, "", 1, 38L },
                    { 10838L, "S1-8_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5384), null, null, 2L, 66L, true, 1L, null, null, "Description of extent to which working conditions and terms of employment of non-employees in own workforce are determined or influenced by collective bargaining agreements ", 1L, "", 1, null },
                    { 10839L, "S1-8_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5386), null, null, 2L, 66L, null, 1L, null, null, "Percentage of employees in country country with significant employment (in the EEA) covered by workers' representatives", 1L, "", 1, null },
                    { 10840L, "S1-8_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5388), null, null, null, 66L, true, 1L, null, null, "Disclosure of existence of any agreement with employees for representation by European Works Council (EWC), Societas Europaea (SE) Works Council, or Societas Cooperativa Europaea (SCE) Works Council ", 1L, "", 1, 38L },
                    { 10841L, "S1-8_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5390), null, null, 2L, 66L, null, 1L, null, null, "Own workforce in region (non-EEA) covered by collective bargaining and social dialogue agreements by coverage rate and by region", 1L, "", 1, null },
                    { 10842L, "S1-9_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5392), null, null, 2L, 67L, null, 1L, null, null, "Gender distribution in number of employees (head count) at top management level", 1L, "", 1, null },
                    { 10843L, "S1-9_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5394), null, null, null, 67L, null, 1L, null, null, "Gender distribution in percentage of employees at top management level", 1L, "", 1, 709L },
                    { 10844L, "S1-9_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5396), null, null, null, 67L, null, 1L, null, null, "Distribution of employees (head count) under 30 years old", 1L, "", 1, 38L },
                    { 10845L, "S1-9_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5398), null, null, null, 67L, null, 1L, null, null, "Distribution of employees (head count) between 30 and 50 years old", 1L, "", 1, 38L },
                    { 10846L, "S1-9_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5400), null, null, null, 67L, null, 1L, null, null, "Distribution of employees (head count) over 50 years old", 1L, "", 1, 38L },
                    { 10847L, "S1-9_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5402), null, null, null, 67L, true, 1L, null, null, "Disclosure of own definition of top management used ", 1L, "", 1, 38L },
                    { 10848L, "S1-10_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5404), null, null, 2L, 68L, null, 1L, null, null, "All employees are paid adequate wage, in line with applicable benchmarks", 1L, "", 1, null },
                    { 10849L, "S1-10_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5406), null, null, 2L, 68L, null, 1L, null, null, "Countries where employees earn below the applicable adequate wage benchmark [table]", 1L, "", 1, null },
                    { 10850L, "S1-10_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5408), null, null, 1L, 68L, null, 1L, null, null, "Percentage of  employees paid below the applicable adequate wage benchmark", 1L, "", 1, null },
                    { 10851L, "S1-10_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5411), null, null, null, 68L, null, 1L, null, null, "Percentage of non-employees paid below adequate wage", 1L, "", 1, 38L },
                    { 10852L, "S1-11_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5413), null, null, null, 69L, null, 1L, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to sickness", 1L, "", 1, 38L },
                    { 10853L, "S1-11_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5414), null, null, 2L, 69L, null, 1L, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to unemployment starting from when own worker is working for undertaking", 1L, "", 1, null },
                    { 10854L, "S1-11_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5420), null, null, 2L, 69L, null, 1L, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to employment injury and acquired disability", 1L, "", 1, null },
                    { 10855L, "S1-11_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5421), null, null, 2L, 69L, null, 1L, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to parental leave", 1L, "", 1, null },
                    { 10856L, "S1-11_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5423), null, null, 2L, 69L, null, 1L, null, null, "All employees in own workforce are covered by social protection, through public programs or through benefits offered, against loss of income due to retirement", 1L, "", 1, null },
                    { 10857L, "S1-11_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5425), null, null, 2L, 69L, null, 1L, null, null, "Social protection employees by country [table] by types of events and type of employees [including non employees]", 1L, "", 1, null },
                    { 10858L, "S1-11_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5428), null, null, 1L, 69L, true, 1L, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to sickness ", 1L, "", 1, null },
                    { 10859L, "S1-11_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5430), null, null, 2L, 69L, true, 1L, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to unemployment starting from when own worker is working for undertaking ", 1L, "", 1, null },
                    { 10860L, "S1-11_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5432), null, null, 2L, 69L, true, 1L, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to employment injury and acquired disability ", 1L, "", 1, null },
                    { 10861L, "S1-11_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5434), null, null, 2L, 69L, true, 1L, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to maternity leave ", 1L, "", 1, null },
                    { 10862L, "S1-11_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5436), null, null, 2L, 69L, true, 1L, null, null, "Disclosure of types of employees who are not covered by social protection, through public programs or through benefits offered, against loss of income due to retirement ", 1L, "", 1, null },
                    { 10863L, "S1-12_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5438), null, null, 2L, 70L, null, 1L, null, null, "Percentage of persons with disabilities amongst employees, subject to legal restrictions on collection of data", 1L, "", 1, null },
                    { 10864L, "S1-12_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5442), null, null, null, 70L, null, 1L, null, null, "Percentage of employees with disabilities in own workforce breakdown by gender [table]", 1L, "", 1, 38L },
                    { 10865L, "S1-12_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5444), null, null, null, 70L, true, 1L, null, null, "Disclosure of contextual information necessary to understand data and how data has been compiled (persons with disabilities)) ", 1L, "", 1, 38L },
                    { 10866L, "S1-13_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5446), null, null, 2L, 71L, null, 1L, null, null, "Training and skills development indicators gender [table]", 1L, "", 1, null },
                    { 10867L, "S1-13_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5448), null, null, 1L, 71L, null, 1L, null, null, "Percentage of employees that participated in regular performance and career development reviews", 1L, "", 1, null },
                    { 10868L, "S1-13_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5450), null, null, null, 71L, null, 1L, null, null, "Average number of training hours  by gender [table]", 1L, "", 1, 38L },
                    { 10869L, "S1-13_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5452), null, null, 1L, 71L, null, 1L, null, null, "Average number of training hours per person for employees", 1L, "", 1, null },
                    { 10870L, "S1-13_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5454), null, null, null, 71L, null, 1L, null, null, "Percentage of employees that participated in regular performance and career development reviews by employee category [table]", 1L, "", 1, 710L },
                    { 10871L, "S1-13_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5457), null, null, null, 71L, null, 1L, null, null, "Average number of employees that participated in regular performance and career development reviews by employee category", 1L, "", 1, 38L },
                    { 10872L, "S1-13_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5459), null, null, null, 71L, null, 1L, null, null, "Percentage of non-employees that participated in regular performance and career development reviews", 1L, "", 1, 710L },
                    { 10873L, "S1-14_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5461), null, null, null, 72L, null, 1L, null, null, "Percentage of people in its own workforce who are covered by health and safety management system based on legal requirements and (or) recognised standards or guidelines", 1L, "", 1, 38L },
                    { 10874L, "S1-14_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5463), null, null, null, 72L, null, 1L, null, null, "Number of fatalities in own workforce as result of work-related injuries and work-related ill health", 1L, "", 1, 38L },
                    { 10875L, "S1-14_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5465), null, null, null, 72L, null, 1L, null, null, "Number of fatalities as result of work-related injuries and work-related ill health of other workers working on undertaking's sites", 1L, "", 1, 709L },
                    { 10876L, "S1-14_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5467), null, null, null, 72L, null, 1L, null, null, "Number of recordable work-related accidents for own workforce", 1L, "", 1, 709L },
                    { 10877L, "S1-14_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5469), null, null, null, 72L, null, 1L, null, null, "Rate of recordable work-related accidents for own workforce", 1L, "", 1, 709L },
                    { 10878L, "S1-14_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5471), null, null, null, 72L, null, 1L, null, null, "Number of cases of recordable work-related ill health of employees", 1L, "", 1, 38L },
                    { 10879L, "S1-14_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5473), null, null, null, 72L, null, 1L, null, null, "Number of days lost to work-related injuries and fatalities from work-related accidents, work-related ill health and fatalities from ill health related to employees", 1L, "", 1, 709L },
                    { 10880L, "S1-14_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5475), null, null, null, 72L, null, 1L, null, null, "Number of cases of recordable work-related ill health of non-employees", 1L, "", 1, 709L },
                    { 10881L, "S1-14_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5477), null, null, null, 72L, null, 1L, null, null, "Number of days lost to work-related injuries and fatalities from work-related accidents, work-related ill health and fatalities from ill health realted to non-employees", 1L, "", 1, 709L },
                    { 10882L, "S1-14_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5479), null, null, null, 72L, null, 1L, null, null, "Percentage of own workforce who are covered by health and safety management system based on legal requirements and (or) recognised standards or guidelines and which has been internally audited and (or) audited or certified by external party", 1L, "", 1, 709L },
                    { 10883L, "S1-14_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5481), null, null, null, 72L, true, 1L, null, null, "Description of underlying standards for internal audit or external certification of health and safety management system ", 1L, "", 1, 38L },
                    { 10884L, "S1-14_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5483), null, null, 2L, 72L, null, 1L, null, null, "Number of cases of recordable work-related ill health detected among former own workforce", 1L, "", 1, null },
                    { 10885L, "S1-15_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5485), null, null, null, 73L, null, 1L, null, null, "Percentage of employees entitled to take family-related leave", 1L, "", 1, 709L },
                    { 10886L, "S1-15_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5490), null, null, null, 73L, null, 1L, null, null, "Percentage of entitled employees that took family-related leave", 1L, "", 1, 38L },
                    { 10887L, "S1-15_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5492), null, null, null, 73L, null, 1L, null, null, "Percentage of entitled employees that took family-related leave by gender [table]", 1L, "", 1, 38L },
                    { 10888L, "S1-15_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5494), null, null, null, 73L, null, 1L, null, null, "All employees are entitled to family-related leaves through social policy and (or) collective bargaining agreements", 1L, "", 1, 38L },
                    { 10889L, "S1-16_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5496), null, null, 2L, 74L, null, 1L, null, null, "Gender pay gap", 1L, "", 1, null },
                    { 10890L, "S1-16_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5498), null, null, null, 74L, null, 1L, null, null, "Annual total remuneration ratio", 1L, "", 1, 38L },
                    { 10891L, "S1-16_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5500), null, null, null, 74L, true, 1L, null, null, "Disclosure of contextual information necessary to understand data, how data has been compiled and other changes to underlying data that are to be considered ", 1L, "", 1, 38L },
                    { 10892L, "S1-16_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5502), null, null, 2L, 74L, null, 1L, null, null, "Gender pay gap breakdown by employee category and/or country/segment [table]", 1L, "", 1, null },
                    { 10893L, "S1-16_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5504), null, null, null, 74L, null, 1L, null, null, "Gender pay gap breakdown by employee category and ordinary basic salary and complementary/variable components", 1L, "", 1, 38L },
                    { 10894L, "S1-16_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5506), null, null, null, 74L, null, 1L, null, null, "Remuneration ratio adjusted for purchasing power differences between countries", 1L, "", 1, 38L },
                    { 10895L, "S1-16_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5508), null, null, null, 74L, true, 1L, null, null, "Description of methodology used for calculation of remuneration ratio adjusted for purchasing power differences between countries ", 1L, "", 1, 38L },
                    { 10896L, "S1-17_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5510), null, null, 2L, 75L, null, 1L, null, null, "Number of incidents of discrimination [table]", 1L, "", 1, null },
                    { 10897L, "S1-17_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5512), null, null, 1L, 75L, null, 1L, null, null, "Number of incidents of discrimination", 1L, "", 1, null },
                    { 10898L, "S1-17_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5514), null, null, null, 75L, null, 1L, null, null, "Number of complaints filed through channels for people in own workforce to raise concerns", 1L, "", 1, 709L },
                    { 10899L, "S1-17_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5518), null, null, null, 75L, null, 1L, null, null, "Number of complaints filed to National Contact Points for OECD Multinational Enterprises", 1L, "", 1, 709L },
                    { 10900L, "S1-17_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5520), null, null, null, 75L, null, 1L, null, null, "Amount of fines, penalties, and compensation for damages as result of incidents of discrimination, including harassment and complaints filed", 1L, "", 1, 709L },
                    { 10901L, "S1-17_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5522), null, null, 3L, 75L, true, 1L, null, null, "Information about reconciliation of fines, penalties, and compensation for damages as result of violations regarding swork-related discrimination and harassment  with most relevant amount presented in financial statements ", 1L, "", 1, null },
                    { 10902L, "S1-17_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5524), null, null, 2L, 75L, true, 1L, null, null, "Disclosure of contextual information necessary to understand data and how data has been compiled (work-related grievances, incidents and complaints related to social and human rights matters) ", 1L, "", 1, null },
                    { 10903L, "S1-17_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5526), null, null, 2L, 75L, null, 1L, null, null, "Number of severe human rights issues and incidents connected to own workforce", 1L, "", 1, null },
                    { 10904L, "S1-17_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5527), null, null, null, 75L, null, 1L, null, null, "Number of severe human rights issues and incidents connected to own workforce that are cases of non respect of UN Guiding Principles and OECD Guidelines for Multinational Enterprises", 1L, "", 1, 709L },
                    { 10905L, "S1-17_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5529), null, null, null, 75L, null, 1L, null, null, "No severe human rights issues and incidents connected to own workforce have occurred", 1L, "", 1, 709L },
                    { 10906L, "S1-17_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5532), null, null, 2L, 75L, null, 1L, null, null, "Amount of fines, penalties, and compensation for severe human rights issues and incidents connected to own workforce", 1L, "", 1, null },
                    { 10907L, "S1-17_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5534), null, null, 3L, 75L, true, 1L, null, null, "Information about reconciliation of amount of fines, penalties, and compensation for severe human rights issues and incidents connected to own workforce with most relevant amount presented in financial statements ", 1L, "", 1, null },
                    { 10908L, "S1-17_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5536), null, null, 2L, 75L, true, 1L, null, null, "Disclosure of the status of incidents and/or complaints and actions taken", 1L, "", 1, null },
                    { 10909L, "S1-17_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5538), null, null, 2L, 75L, null, 1L, null, null, "Number of severe human rights cases where undertaking played role securing remedy for those affected", 1L, "", 1, null },
                    { 10910L, "S2.SBM-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5540), null, null, null, 77L, null, 1L, null, null, "All value chain workers  who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 1, 709L },
                    { 10911L, "S2.SBM-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5542), null, null, 2L, 77L, true, 1L, null, null, "Description of types of value chain workers subject to material impacts", 1L, "", 1, null },
                    { 10912L, "S2.SBM-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5544), null, null, 2L, 77L, null, 1L, null, null, "Type of value chain workers subject to material impacts by own operations or through value chain", 1L, "", 1, null },
                    { 10913L, "S2.SBM-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5547), null, null, 2L, 77L, true, 1L, null, null, "Disclosure of geographies or commodities for which there is significant risk of child labour, or of forced or compulsory labour, among workers in undertaking’s value chain ", 1L, "", 1, null },
                    { 10914L, "S2.SBM-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5549), null, null, 2L, 77L, null, 1L, null, null, "Material negative impacts occurrence (value chain workers)", 1L, "", 1, null },
                    { 10915L, "S2.SBM-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5551), null, null, 2L, 77L, true, 1L, null, null, "Description of activities that result in positive impacts and types of value chain workers  that are positively affected or could be positively affected ", 1L, "", 1, null },
                    { 10916L, "S2.SBM-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5553), null, null, 2L, 77L, true, 1L, null, null, "Description of material risks and opportunities arising from impacts and dependencies on  value chain workers  ", 1L, "", 1, null },
                    { 10917L, "S2.SBM-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5555), null, null, 2L, 77L, true, 1L, null, null, "Disclosure of whether and how the undertaking has developed an understanding of how workers with particular characteristics, those working in particular contexts, or those undertaking particular activities may be at greater risk of harm.", 1L, "", 1, null },
                    { 10918L, "S2.SBM-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5560), null, null, 2L, 77L, true, 1L, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on value chain workers  are impacts on specific groups ", 1L, "", 1, null },
                    { 10919L, "S2.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5564), null, null, 2L, 78L, null, 1L, null, null, "Policies to manage material impacts, risks and opportunities related to value chain workers [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 10920L, "S2-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5566), null, null, 2L, 78L, true, 1L, null, null, "Description of relevant human rights policy commitments relevant to value chain workers", 1L, "", 1, null },
                    { 10921L, "S2-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5568), null, null, 2L, 78L, true, 1L, null, null, "Disclosure of general approach in relation to respect for human rights relevant to value chain workers", 1L, "", 1, null },
                    { 10922L, "S2-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5570), null, null, 2L, 78L, true, 1L, null, null, "Disclosure of general approach in relation to engagement with value chain workers", 1L, "", 1, null },
                    { 10923L, "S2-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5572), null, null, 2L, 78L, true, 1L, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 1, null },
                    { 10924L, "S2-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5574), null, null, 2L, 78L, null, 1L, null, null, "Policies explicitly address trafficking in human beings, forced labour or compulsory labour and child labour", 1L, "", 1, null },
                    { 10925L, "S2-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5576), null, null, 2L, 78L, null, 1L, null, null, "Undertaking has supplier code of conduct", 1L, "", 1, null },
                    { 10926L, "S2-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5579), null, null, 2L, 78L, null, 1L, null, null, "Provisions in supplier codes of conudct are fully in line with applicable ILO standards", 1L, "", 1, null },
                    { 10927L, "S2-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5581), null, null, 2L, 78L, true, 1L, null, null, "Disclosure of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 1, null },
                    { 10928L, "S2-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5583), null, null, 2L, 78L, true, 1L, null, null, "Disclosure of extent and indication of nature of cases of non-respect of the UN Guiding Principles on Business and Human Rights, ILO Declaration on Fundamental Principles and Rights at Work or OECD Guidelines for Multinational Enterprises that involve value chain workers", 1L, "", 1, null },
                    { 10929L, "S2-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5585), null, null, 2L, 78L, true, 1L, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 1, null },
                    { 10930L, "S2-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5587), null, null, 2L, 78L, true, 1L, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 1, null },
                    { 10932L, "S2-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5591), null, null, null, 79L, true, 1L, null, null, "Disclosure of whether and how perspectives of value chain workers inform decisions or activities aimed at managing actual and potential  impacts ", 1L, "", 1, null },
                    { 10933L, "S2-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5594), null, null, 2L, 79L, null, 1L, null, null, "Engagement occurs with value chain workers or their legitimate representatives directly, or with credible proxies", 1L, "", 1, null },
                    { 10934L, "S2-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5596), null, null, 2L, 79L, true, 1L, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 1, null },
                    { 10935L, "S2-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5598), null, null, 2L, 79L, true, 1L, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakings approach ", 1L, "", 1, null },
                    { 10936L, "S2-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5600), null, null, 2L, 79L, true, 1L, null, null, "Disclosure of Global Framework Agreement or other agreements related to respect of human rights of workers ", 1L, "", 1, null },
                    { 10937L, "S2-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5602), null, null, 2L, 79L, true, 1L, null, null, "Disclosure of how effectiveness of engagement with value chain workers is assessed ", 1L, "", 1, null },
                    { 10938L, "S2-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5604), null, null, 2L, 79L, true, 1L, null, null, "Disclosure of steps taken to gain insight into perspectives of value chain workers that may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 1, null },
                    { 10939L, "S2-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5606), null, null, 2L, 79L, true, 1L, null, null, "Statement in case the undertaking has not adopted a general process to engage with value chain workers", 1L, "", 1, null },
                    { 10940L, "S2-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5609), null, null, 2L, 79L, true, 1L, null, null, "Disclosure of timeframe for adoption of general process to engage with  value chain workers  in case the undertaking has not adopted a general process for engagement", 1L, "", 1, null },
                    { 10941L, "S2-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5611), null, null, 2L, 80L, true, 1L, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has identified that it connected with a material negative impact on  value chain workers  ", 1L, "", 1, null },
                    { 10942L, "S2-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5613), null, null, 2L, 80L, true, 1L, null, null, "Disclosure of specific channels in place for value chain workers to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 1, null },
                    { 10943L, "S2-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5615), null, null, 2L, 80L, true, 1L, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 1, null },
                    { 10944L, "S2-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5617), null, null, 2L, 80L, true, 1L, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 1, null },
                    { 10945L, "S2-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5619), null, null, 2L, 80L, true, 1L, null, null, "Disclosure of whether and how it is assessed that value chain workers are aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 1, null },
                    { 10946L, "S2-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5622), null, null, 2L, 80L, null, 1L, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 1, null },
                    { 10947L, "S2-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5624), null, null, 2L, 80L, true, 1L, null, null, "Statement in case the undertaking has not adopted a channel for raising concerns ", 1L, "", 1, null },
                    { 10948L, "S2-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5626), null, null, 2L, 80L, true, 1L, null, null, "Disclosure of timeframe for channel for raising concerns to be in place", 1L, "", 1, null },
                    { 10949L, "S2-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5628), null, null, 2L, 80L, true, 1L, null, null, "Disclosure of whether and how value chain workers are able to access channels at level of undertaking they are employed by or contracted to work for ", 1L, "", 1, null },
                    { 10950L, "S2-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5635), null, null, 2L, 80L, null, 1L, null, null, "Third-party mechanisms are accessible to all workers", 1L, "", 1, null },
                    { 10951L, "S2-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5637), null, null, 2L, 80L, null, 1L, null, null, "Grievances are treated confidentially and with respect to rights of privacy and data protection", 1L, "", 1, null },
                    { 10952L, "S2-3_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5639), null, null, 2L, 80L, null, 1L, null, null, "Channels to raise concerns or needs allow for value chain workers to use them anonymously ", 1L, "", 1, null },
                    { 10953L, "S2.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5642), null, null, 2L, 81L, null, 1L, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to value chain workers [see ESRS 2 - MDR-A]", 1L, "", 1, null },
                    { 10954L, "S2-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5644), null, null, 2L, 81L, true, 1L, null, null, "Description of action planned or underway to prevent, mitigate or remediate material negative impacts on  value chain workers  ", 1L, "", 1, null },
                    { 10955L, "S2-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5646), null, null, 2L, 81L, true, 1L, null, null, "Description of whether and how action to provide or enable remedy in relation to an actual material impact", 1L, "", 1, null },
                    { 10956L, "S2-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5648), null, null, 2L, 81L, true, 1L, null, null, "Description of additional initiatives or processes with primary purpose of delivering positive impacts for value chain workers ", 1L, "", 1, null },
                    { 10957L, "S2-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5650), null, null, 2L, 81L, true, 1L, null, null, "Description of how effectiveness of actions or initiatives in delivering outcomes for value chain workersis tracked and assessed ", 1L, "", 1, null },
                    { 10958L, "S2-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5652), null, null, 2L, 81L, true, 1L, null, null, "Description of processes to identifying what action is needed and appropriate in response to particular actual or potential material negative impact on  value chain workers  ", 1L, "", 1, null },
                    { 10959L, "S2-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5655), null, null, 2L, 81L, true, 1L, null, null, "Description of approach to taking action in relation to specific material negative impacts on value chain workers  ", 1L, "", 1, null },
                    { 10960L, "S2-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5657), null, null, 2L, 81L, true, 1L, null, null, "Description of approach to ensuring that processes to provide or enable remedy in event of material negative impacts on  value chain workers  are available and effective in their implementation and outcomes ", 1L, "", 1, null },
                    { 10961L, "S2-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5659), null, null, 2L, 81L, true, 1L, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on  value chain workers  and how effectiveness is tracked ", 1L, "", 1, null },
                    { 10962L, "S2-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5661), null, null, 2L, 81L, true, 1L, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to  value chain workers  ", 1L, "", 1, null },
                    { 10963L, "S2-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5663), null, null, 2L, 81L, true, 1L, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on value chain workers  ", 1L, "", 1, null },
                    { 10964L, "S2-4_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5665), null, null, 2L, 81L, true, 1L, null, null, "Disclosure of severe human rights issues and incidents connected to upstream and downstream value chain ", 1L, "", 1, null },
                    { 10965L, "S2-4_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5667), null, null, 2L, 81L, true, 1L, null, null, "Disclosure of resources allocated to management of material impacts ", 1L, "", 1, null },
                    { 10966L, "S2-4_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5670), null, null, 2L, 81L, true, 1L, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting value chain workers  ", 1L, "", 1, null },
                    { 10967L, "S2-4_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5672), null, null, 2L, 81L, true, 1L, null, null, "Disclosure of how participation in industry or multi-stakeholder initiative and undertaking's own involvement is aiming to address material impacts ", 1L, "", 1, null },
                    { 10968L, "S2-4_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5674), null, null, 2L, 81L, true, 1L, null, null, "Disclosure of whether and how value chain workers and legitimate representatives or their credible proxies play role in decisions regarding design and implementation of programmes or processes ", 1L, "", 1, null },
                    { 10969L, "S2-4_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5676), null, null, 2L, 81L, true, 1L, null, null, "Information about intended or achieved positive outcomes of programmes or processes for  value chain workers  ", 1L, "", 1, null },
                    { 10970L, "S2-4_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5678), null, null, 2L, 81L, null, 1L, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for  value chain workers  are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 1, null },
                    { 10971L, "S2-4_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5680), null, null, 2L, 81L, true, 1L, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 1, null },
                    { 10973L, "S2.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5687), null, null, null, 82L, null, 1L, null, null, "Targets set to manage material impacts, risks and opportunities related to value chain workers [see ESRS 2 - MDR-T]", 1L, "", 1, null },
                    { 10974L, "S2-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5689), null, null, 2L, 82L, true, 1L, null, null, "Disclosure of whether and how value chain workers , their legitimate representatives or credible proxies were engaged directly in setting targets ", 1L, "", 1, null },
                    { 10975L, "S2-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5691), null, null, 2L, 82L, true, 1L, null, null, "Disclosure of whether and how value chain workers , their legitimate representatives or credible proxies were engaged directly in tracking performance against targets ", 1L, "", 1, null },
                    { 10976L, "S2-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5693), null, null, 2L, 82L, true, 1L, null, null, "Disclosure of whether and how value chain workers , their legitimate representatives or credible proxies were engaged directly in identifying lessons or improvements as result of undertaking’s performance ", 1L, "", 1, null },
                    { 10977L, "S2-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5695), null, null, 2L, 82L, true, 1L, null, null, "Disclosure of intended outcomes to be achieved in lives of  value chain workers  ", 1L, "", 1, null },
                    { 10978L, "S2-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5697), null, null, 2L, 82L, true, 1L, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 1, null },
                    { 10979L, "S2-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5699), null, null, 2L, 82L, true, 1L, null, null, "Disclosure of references to standards or commitments on which target is based ", 1L, "", 1, null },
                    { 10981L, "S3.SBM-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5703), null, null, null, 84L, null, 1L, null, null, "All  affected communities who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 1, null },
                    { 10982L, "S3.SBM-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5707), null, null, 2L, 84L, true, 1L, null, null, "Description of types of affected communities subject to material impacts", 1L, "", 1, null },
                    { 10983L, "S3.SBM-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5709), null, null, 2L, 84L, null, 1L, null, null, "Type of communities subject to material impacts by own operations or through value chain", 1L, "", 1, null },
                    { 10984L, "S3.SBM-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5711), null, null, 2L, 84L, null, 1L, null, null, "Material negative impacts occurrence (affected communities)", 1L, "", 1, null },
                    { 10985L, "S3.SBM-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5713), null, null, 2L, 84L, true, 1L, null, null, "Description of activities that result in positive impacts and types of affected communities that are positively affected or could be positively affected ", 1L, "", 1, null },
                    { 10986L, "S3.SBM-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5715), null, null, 2L, 84L, true, 1L, null, null, "Description of material risks and opportunities arising from impacts and dependencies on  affected communities   ", 1L, "", 1, null },
                    { 10987L, "S3.SBM-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5718), null, null, 2L, 84L, true, 1L, null, null, "Disclosure of whether and how the undertaking has developed an understanding of how affected communities with particular characteristics or those living in particular contexts, or those undertaking particular activities may be at greater risk of harm", 1L, "", 1, null },
                    { 10988L, "S3.SBM-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5720), null, null, 2L, 84L, true, 1L, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on affected communities are impacts on specific groups ", 1L, "", 1, null },
                    { 10989L, "S3.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5722), null, null, 2L, 85L, null, 1L, null, null, "Policies to manage material impacts, risks and opportunities related to affected communities [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 10990L, "S3-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5724), null, null, 2L, 85L, true, 1L, null, null, "Disclosure of any  any particular policy provisions for preventing and addressing impacts on indigenous peoples", 1L, "", 1, null },
                    { 10991L, "S3-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5726), null, null, 2L, 85L, true, 1L, null, null, "Description of relevant human rights policy commitments relevant to affected communities", 1L, "", 1, null },
                    { 10992L, "S3-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5728), null, null, 2L, 85L, true, 1L, null, null, "Disclosure of general approach in relation to respect for human rights of communities, and indigenous peoples specifically", 1L, "", 1, null },
                    { 10993L, "S3-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5731), null, null, 2L, 85L, true, 1L, null, null, "Disclosure of general approach in relation to engagement with affected communities", 1L, "", 1, null },
                    { 10994L, "S3-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5733), null, null, 2L, 85L, true, 1L, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 1, null },
                    { 10995L, "S3-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5735), null, null, 2L, 85L, true, 1L, null, null, "Disclosure of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 1, null },
                    { 10996L, "S3-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5737), null, null, 2L, 85L, true, 1L, null, null, "Disclosure of extent and indication of nature of cases of non-respect of the UN Guiding Principles on Business and Human Rights, ILO Declaration on Fundamental Principles and Rights at Work or OECD Guidelines for Multinational Enterprises that involve affected communities", 1L, "", 1, null },
                    { 10997L, "S3-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5739), null, null, 2L, 85L, true, 1L, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 1, null },
                    { 10998L, "S3-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5741), null, null, 2L, 85L, true, 1L, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 1, null },
                    { 11000L, "S3-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5746), null, null, null, 86L, true, 1L, null, null, "Disclosure of whether and how perspectives of affected communities inform decisions or activities aimed at managing actual and potential impacts ", 1L, "", 1, null },
                    { 11001L, "S3-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5748), null, null, 2L, 86L, null, 1L, null, null, "Engagement occurs with affected communities or their legitimate representatives directly, or with credible proxies", 1L, "", 1, null },
                    { 11002L, "S3-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5750), null, null, 2L, 86L, true, 1L, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 1, null },
                    { 11003L, "S3-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5752), null, null, 2L, 86L, true, 1L, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakings approach ", 1L, "", 1, null },
                    { 11004L, "S3-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5754), null, null, 2L, 86L, true, 1L, null, null, "Disclosure of how the undertaking assesses the effectiveness of its engagement with affected communities", 1L, "", 1, null },
                    { 11005L, "S3-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5756), null, null, 2L, 86L, true, 1L, null, null, "Disclosure of steps taken to gain insight into perspectives of  affected communities hat may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 1, null },
                    { 11006L, "S3-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5758), null, null, 2L, 86L, true, 1L, null, null, "Disclosure of whether and how the undertaking takes into account and ensures respect of particular rights of indigenous peoples in its stakeholder engagement approach", 1L, "", 1, null },
                    { 11007L, "S3-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5761), null, null, 2L, 86L, true, 1L, null, null, "Statement in case the undertaking has not adopted a general process to engage with affected communities", 1L, "", 1, null },
                    { 11008L, "S3-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5763), null, null, 2L, 86L, true, 1L, null, null, "Disclosure of timeframe for adoption of general process to engage with affected communities in case the undertaking has not adopted a general process for engagement", 1L, "", 1, null },
                    { 11009L, "S3-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5765), null, null, 2L, 87L, true, 1L, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has identified that it connected with a material negative impact on affected communities   ", 1L, "", 1, null },
                    { 11010L, "S3-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5767), null, null, 2L, 87L, true, 1L, null, null, "Disclosure of specific channels in place for affected communities to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 1, null },
                    { 11011L, "S3-3_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5769), null, null, 2L, 87L, true, 1L, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 1, null },
                    { 11012L, "S3-3_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5771), null, null, 2L, 87L, true, 1L, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 1, null },
                    { 11013L, "S3-3_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5774), null, null, 2L, 87L, true, 1L, null, null, "Disclosure of whether and how it is assessed that affected communities are aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 1, null },
                    { 11014L, "S3-3_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5776), null, null, 2L, 87L, null, 1L, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 1, null },
                    { 11015L, "S3-3_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5781), null, null, 2L, 87L, true, 1L, null, null, "Statement in case the undertaking has not adopted a general process to engage with affected communities", 1L, "", 1, null },
                    { 11016L, "S3-3_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5783), null, null, 2L, 87L, true, 1L, null, null, "Disclosure of timeframe for channel or processes for raising concerns to be in place ", 1L, "", 1, null },
                    { 11017L, "S3-3_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5785), null, null, 2L, 87L, true, 1L, null, null, "Disclosure of whether and how affected communities are able to access channels at level of undertaking they are affected by", 1L, "", 1, null },
                    { 11018L, "S3-3_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5787), null, null, 2L, 87L, null, 1L, null, null, "Third-party mechanisms are accessible to all affected communities", 1L, "", 1, null },
                    { 11019L, "S3-3_20", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5789), null, null, 2L, 87L, null, 1L, null, null, "Grievances are treated confidentially and with respect to rights of privacy and data protection", 1L, "", 1, null },
                    { 11020L, "S3-3_21", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5791), null, null, 2L, 87L, null, 1L, null, null, "affected communities   are allowed to use anonymously channels to raise concerns or needs", 1L, "", 1, null },
                    { 11021L, "S3.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5793), null, null, 2L, 88L, null, 1L, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to affected communities [see ESRS 2 - MDR-A]", 1L, "", 1, null },
                    { 11022L, "S3-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5795), null, null, 2L, 88L, true, 1L, null, null, "Description of action taken, planned or underway to prevent, mitigate or remediate material negative impacts on affected communities   ", 1L, "", 1, null },
                    { 11023L, "S3-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5797), null, null, 2L, 88L, true, 1L, null, null, "Description of whether and how the undertaking has taken action to provide or enable remedy in relation to an actual material impact", 1L, "", 1, null },
                    { 11024L, "S3-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5799), null, null, 2L, 88L, true, 1L, null, null, "Description of additional initiatives or processes with primary purpose of delivering positive impacts for affected communities  ", 1L, "", 1, null },
                    { 11025L, "S3-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5801), null, null, 2L, 88L, true, 1L, null, null, "Description of how effectiveness of actions or initiatives in delivering outcomes for affected communities is tracked and assessed ", 1L, "", 1, null },
                    { 11026L, "S3-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5803), null, null, 2L, 88L, true, 1L, null, null, "Description of processes to identifying what action is needed and appropriate in response to particular actual or potential material negative impact on affected communities   ", 1L, "", 1, null },
                    { 11027L, "S3-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5806), null, null, 2L, 88L, true, 1L, null, null, "Description of approach to taking action in relation to specific material negative impacts on affected communities   ", 1L, "", 1, null },
                    { 11028L, "S3-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5808), null, null, 2L, 88L, true, 1L, null, null, "Description of approach to ensuring that processes to provide or enable remedy in event of material negative impacts on affected communities are available and effective in their implementation and outcomes ", 1L, "", 1, null },
                    { 11029L, "S3-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5810), null, null, 2L, 88L, true, 1L, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on affected communities and how effectiveness is tracked ", 1L, "", 1, null },
                    { 11030L, "S3-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5812), null, null, 2L, 88L, true, 1L, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to affected communities   ", 1L, "", 1, null },
                    { 11031L, "S3-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5814), null, null, 2L, 88L, true, 1L, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on affected communities   ", 1L, "", 1, null },
                    { 11032L, "S3-4_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5816), null, null, 2L, 88L, true, 1L, null, null, "Disclosure of severe human rights issues and incidents connected to affected communities ", 1L, "", 1, null },
                    { 11033L, "S3-4_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5818), null, null, 2L, 88L, true, 1L, null, null, "Disclosure of resources allocated to management of material impacts ", 1L, "", 1, null },
                    { 11034L, "S3-4_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5822), null, null, 2L, 88L, true, 1L, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting  affected communities   ", 1L, "", 1, null },
                    { 11035L, "S3-4_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5824), null, null, 2L, 88L, true, 1L, null, null, "Disclosure of how participation in industry or multi-stakeholder initiative and undertaking's own involvement is aiming to address material impacts ", 1L, "", 1, null },
                    { 11036L, "S3-4_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5826), null, null, 2L, 88L, true, 1L, null, null, "Disclosure of whether and how affected communities  play role in decisions regarding design and implementation of programmes or investments ", 1L, "", 1, null },
                    { 11037L, "S3-4_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5828), null, null, 2L, 88L, true, 1L, null, null, "Information about intended or achieved positive outcomes of programmes or investments for  affected communities   ", 1L, "", 1, null },
                    { 11038L, "S3-4_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5830), null, null, 2L, 88L, true, 1L, null, null, "Explanation of the approximate scope of affected communities covered by the described social investment or development programmes, and, where applicable, the rationale for why selected communities were chosen", 1L, "", 1, null },
                    { 11039L, "S3-4_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5832), null, null, 2L, 88L, null, 1L, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for affected communities are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 1, null },
                    { 11040L, "S3-4_19", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5835), null, null, 2L, 88L, true, 1L, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 1, null },
                    { 11042L, "S3.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5840), null, null, null, 89L, null, 1L, null, null, "Targets set to manage material impacts, risks and opportunities related to affected communities [see ESRS 2 - MDR-T]", 1L, "", 1, null },
                    { 11043L, "S3-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5842), null, null, 2L, 89L, true, 1L, null, null, "Disclosure of whether and how affected communities were engaged directly in setting targets", 1L, "", 1, null },
                    { 11044L, "S3-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5844), null, null, 2L, 89L, true, 1L, null, null, "Disclosure of whether and how affected communities  were engaged directly in tracking performance against targets", 1L, "", 1, null },
                    { 11045L, "S3-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5846), null, null, 2L, 89L, true, 1L, null, null, "Disclosure of whether and how affected communities  were engaged directly in identifying lessons or improvements as result of undertaking’s performance", 1L, "", 1, null },
                    { 11046L, "S3-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5848), null, null, 2L, 89L, true, 1L, null, null, "Disclosure of intended outcomes to be achieved in lives of  affected communities   ", 1L, "", 1, null },
                    { 11047L, "S3-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5854), null, null, 2L, 89L, true, 1L, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 1, null },
                    { 11048L, "S3-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5856), null, null, 2L, 89L, true, 1L, null, null, "Disclosure of references to standards or commitments on which target is based ", 1L, "", 1, null },
                    { 11050L, "S4.SBM-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5862), null, null, null, 91L, null, 1L, null, null, "All  consumers and end-users who can be materially impacted by undertaking are included in scope of disclosure under ESRS 2", 1L, "", 1, null },
                    { 11051L, "S4.SBM-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5866), null, null, 2L, 91L, true, 1L, null, null, "Description of types of consumers and end-users subject to material impacts", 1L, "", 1, null },
                    { 11052L, "S4.SBM-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5867), null, null, 2L, 91L, null, 1L, null, null, "Type of consumers and end-users subject to material impacts by own operations or through value chain", 1L, "", 1, null },
                    { 11053L, "S4.SBM-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5869), null, null, 2L, 91L, null, 1L, null, null, "Material negative impacts occurrence (consumers and end-users)", 1L, "", 1, null },
                    { 11054L, "S4.SBM-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5872), null, null, 2L, 91L, true, 1L, null, null, "Description of activities that result in positive impacts and types of  consumers and end-users that are positively affected or could be positively affected ", 1L, "", 1, null },
                    { 11055L, "S4.SBM-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5874), null, null, 2L, 91L, true, 1L, null, null, "Description of material risks and opportunities arising from impacts and dependencies on  consumers and end-users   ", 1L, "", 1, null },
                    { 11056L, "S4.SBM-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5877), null, null, 2L, 91L, true, 1L, null, null, "Disclosure of whether and how understanding of how consumers and end-users with particular characteristics, working in particular contexts, or undertaking particular activities may be at greater risk of harm has been developed", 1L, "", 1, null },
                    { 11057L, "S4.SBM-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5878), null, null, 2L, 91L, true, 1L, null, null, "Disclosure of which of material risks and opportunities arising from impacts and dependencies on consumers and end-users are impacts on specific groups ", 1L, "", 1, null },
                    { 11058L, "S4.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5880), null, null, 2L, 92L, null, 1L, null, null, "Policies to manage material impacts, risks and opportunities related to consumers and end-users [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 11059L, "S4-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5882), null, null, 2L, 92L, true, 1L, null, null, "Policies to manage material impacts, risks and opportunities related to affected consumers and end-users, including specific groups or all consumers / end-users", 1L, "", 1, null },
                    { 11060L, "S4-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5884), null, null, 2L, 92L, true, 1L, null, null, "Description of relevant human rights policy commitments relevant to consumers and/or end-users", 1L, "", 1, null },
                    { 11061L, "S4-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5888), null, null, 2L, 92L, true, 1L, null, null, "Disclosure of general approach in relation to respect for human rights of consumers and end-users", 1L, "", 1, null },
                    { 11062L, "S4-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5890), null, null, 2L, 92L, true, 1L, null, null, "Disclosure of general approach in relation to engagement with consumers and/or end-users", 1L, "", 1, null },
                    { 11063L, "S4-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5892), null, null, 2L, 92L, true, 1L, null, null, "Disclosure of general approach in relation to measures to provide and (or) enable remedy for human rights impacts ", 1L, "", 1, null },
                    { 11064L, "S4-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5894), null, null, 2L, 92L, true, 1L, null, null, "Description of whether and how policies are aligned with relevant internationally recognised instruments ", 1L, "", 1, null },
                    { 11065L, "S4-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5896), null, null, 2L, 92L, true, 1L, null, null, "Disclosure of extent and indication of nature of cases of non-respect of the UN Guiding Principles on Business and Human Rights, ILO Declaration on Fundamental Principles and Rights at Work or OECD Guidelines for Multinational Enterprises that involve consumers and/or end-users", 1L, "", 1, null },
                    { 11066L, "S4-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5898), null, null, 2L, 92L, true, 1L, null, null, "Disclosure of explanations of significant changes to policies adopted during reporting year ", 1L, "", 1, null },
                    { 11067L, "S4-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5901), null, null, 2L, 92L, true, 1L, null, null, "Disclosure on an illustration of the types of communication of its policies to those individuals, group of individuals or entities for whom they are relevant", 1L, "", 1, null },
                    { 11069L, "S4-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5905), null, null, null, 93L, true, 1L, null, null, "Disclosure of whether and how perspectives of consumers and end-users inform decisions or activities aimed at managing actual and potential impacts ", 1L, "", 1, null },
                    { 11070L, "S4-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5907), null, null, 2L, 93L, null, 1L, null, null, "Engagement occurs with consumers and end-users  or their legitimate representatives directly, or with credible proxies", 1L, "", 1, null },
                    { 11071L, "S4-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5909), null, null, 2L, 93L, true, 1L, null, null, "Disclosure of stage at which engagement occurs, type of engagement and frequency of engagement ", 1L, "", 1, null },
                    { 11072L, "S4-2_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5911), null, null, 2L, 93L, true, 1L, null, null, "Disclosure of function and most senior role within undertaking that has operational responsibility for ensuring that engagement happens and that results inform undertakings approach ", 1L, "", 1, null },
                    { 11073L, "S4-2_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5913), null, null, 2L, 93L, true, 1L, null, null, "Disclosure of how effectiveness of engagement with  consumers and end-users   is assessed ", 1L, "", 1, null },
                    { 11074L, "S4-2_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5915), null, null, 2L, 93L, true, 1L, null, null, "Disclosure of steps taken to gain insight into perspectives of  consumers and end-users  / consumers and end-users that may be particularly vulnerable to impacts and (or) marginalised ", 1L, "", 1, null },
                    { 11075L, "S4-2_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5917), null, null, 2L, 93L, true, 1L, null, null, "Statement in case the undertaking has not adopted a general process to engage with consumers and/or end-users", 1L, "", 1, null },
                    { 11076L, "S4-2_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5919), null, null, 2L, 93L, true, 1L, null, null, "Disclosure of timeframe for adoption of general process to engage with  consumers and end-users   in case the undertaking has not adopted a general process for engageme", 1L, "", 1, null },
                    { 11077L, "S4-2_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5922), null, null, 2L, 93L, null, 1L, null, null, "Type of role or function handling with engagement", 1L, "", 1, null },
                    { 11078L, "S4-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5924), null, null, 2L, 94L, true, 1L, null, null, "Disclosure of general approach to and processes for providing or contributing to remedy where undertaking has identified that it connected with a material negative impact on consumers and end-users   ", 1L, "", 1, null },
                    { 11079L, "S4-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5929), null, null, 2L, 94L, true, 1L, null, null, "Disclosure of specific channels in place for consumers and end-users to raise concerns or needs directly with undertaking and have them addressed ", 1L, "", 1, null },
                    { 11080L, "S4-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5931), null, null, 2L, 94L, true, 1L, null, null, "Disclosure of processes through which undertaking supports or requires availability of channels ", 1L, "", 1, null },
                    { 11081L, "S4-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5934), null, null, 2L, 94L, true, 1L, null, null, "Disclosure of how issues raised and addressed are tracked and monitored and how effectiveness of channels is ensured ", 1L, "", 1, null },
                    { 11082L, "S4-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5936), null, null, 2L, 94L, true, 1L, null, null, "Disclosure of whether and how it is assessed that consumers and end-users are aware of and trust structures or processes as way to raise their concerns or needs and have them addressed ", 1L, "", 1, null },
                    { 11083L, "S4-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5938), null, null, 2L, 94L, null, 1L, null, null, "Policies regarding protection against retaliation for individuals that use channels to raise concerns or needs are in place", 1L, "", 1, null },
                    { 11084L, "S4-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5940), null, null, 2L, 94L, true, 1L, null, null, "Statement in case the undertaking has not adopted a general process to engage with consumers and/or end-users", 1L, "", 1, null },
                    { 11085L, "S4-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5942), null, null, 2L, 94L, true, 1L, null, null, "Disclosure of timeframe for channel or processes for raising concerns to be in place ", 1L, "", 1, null },
                    { 11086L, "S4-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5944), null, null, 2L, 94L, true, 1L, null, null, "Disclosure of whether and how consumers and/or end-users are able to access channels at level of undertaking they are affected by", 1L, "", 1, null },
                    { 11087L, "S4-3_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5946), null, null, 2L, 94L, true, 1L, null, null, "Third-party mechanisms are accessible to all consumers and/or end-users", 1L, "", 1, null },
                    { 11088L, "S4-3_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5949), null, null, 2L, 94L, null, 1L, null, null, "Grievances are treated confidentially and with respect to rights of privacy and data protection", 1L, "", 1, null },
                    { 11089L, "S4-3_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5951), null, null, 2L, 94L, null, 1L, null, null, "consumers and end-users   are allowed to use anonymously channels to raise concerns or needs", 1L, "", 1, null },
                    { 11090L, "S4-3_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5953), null, null, 2L, 94L, null, 1L, null, null, "Number of complaints received from consumers and/or end users during the reporting period", 1L, "", 1, null },
                    { 11091L, "S4.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5955), null, null, null, 95L, null, 1L, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to consumers and end-users [see ESRS 2 - MDR-A]", 1L, "", 1, 709L },
                    { 11092L, "S4-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5957), null, null, 2L, 95L, true, 1L, null, null, "Description of action planned or underway to prevent, mitigate or remediate material negative impacts on consumers and end-users   ", 1L, "", 1, null },
                    { 11093L, "S4-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5959), null, null, 2L, 95L, true, 1L, null, null, "Description of whether and how action has been taken to provide or enable remedy in relation to an actual material impact", 1L, "", 1, null },
                    { 11094L, "S4-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5963), null, null, 2L, 95L, true, 1L, null, null, "Description of additional initiatives or processes with primary purpose of delivering positive impacts for consumers and end-users  ", 1L, "", 1, null },
                    { 11095L, "S4-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5965), null, null, 2L, 95L, true, 1L, null, null, "Description of how effectiveness of actions or initiatives in delivering outcomes for consumers and end-users is tracked and assessed ", 1L, "", 1, null },
                    { 11096L, "S4-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5967), null, null, 2L, 95L, true, 1L, null, null, "Description of approach to identifying what action is needed and appropriate in response to particular actual or potential material negative impact on  consumers and end-users   ", 1L, "", 1, null },
                    { 11097L, "S4-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5969), null, null, 2L, 95L, true, 1L, null, null, "Description of approach to taking action in relation to specific material impacts on consumers and end-users   ", 1L, "", 1, null },
                    { 11098L, "S4-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5971), null, null, 2L, 95L, true, 1L, null, null, "Description of approach to ensuring that processes to provide or enable remedy in event of material negative impacts on  consumers and end-users are available and effective in their implementation and outcomes ", 1L, "", 1, null },
                    { 11099L, "S4-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5973), null, null, 2L, 95L, true, 1L, null, null, "Description of what action is planned or underway to mitigate material risks arising from impacts and dependencies on consumers and end-users and how effectiveness is tracked ", 1L, "", 1, null },
                    { 11100L, "S4-4_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5975), null, null, 2L, 95L, true, 1L, null, null, "Description of what action is planned or underway to pursue material opportunities in relation to consumers and end-users   ", 1L, "", 1, null },
                    { 11101L, "S4-4_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5978), null, null, 2L, 95L, true, 1L, null, null, "Disclosure of whether and how it is ensured that own practices do not cause or contribute to material negative impacts on consumers and end-users   ", 1L, "", 1, null },
                    { 11102L, "S4-4_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5980), null, null, 2L, 95L, true, 1L, null, null, "Disclosure of severe human rights issues and incidents connected to consumers and/or end-users", 1L, "", 1, null },
                    { 11103L, "S4-4_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5982), null, null, 2L, 95L, true, 1L, null, null, "Disclosure of resources allocated to management of material impacts ", 1L, "", 1, null },
                    { 11104L, "S4-4_13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5984), null, null, 2L, 95L, true, 1L, null, null, "Disclosure of whether and how undertaking seeks to use leverage with relevant business relationships to manage material negative impacts affecting  consumers and end-users   ", 1L, "", 1, null },
                    { 11105L, "S4-4_14", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5986), null, null, 2L, 95L, true, 1L, null, null, "Disclosure of how participation in industry or multi-stakeholder initiative and undertaking's own involvement is aiming to address material impacts ", 1L, "", 1, null },
                    { 11106L, "S4-4_15", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5988), null, null, 2L, 95L, true, 1L, null, null, "Disclosure of how consumers and end-users play role in decisions regarding design and implementation of programmes or processes ", 1L, "", 1, null },
                    { 11107L, "S4-4_16", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5990), null, null, 2L, 95L, true, 1L, null, null, "Information about intended or achieved positive outcomes of programmes or processes for consumers and end-users   ", 1L, "", 1, null },
                    { 11108L, "S4-4_17", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5993), null, null, 2L, 95L, null, 1L, null, null, "Initiatives or processes whose primary aim is to deliver positive impacts for consumers and/or end-users are designed also to support achievement of one or more of Sustainable Development Goals", 1L, "", 1, null },
                    { 11109L, "S4-4_18", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(5995), null, null, 2L, 95L, true, 1L, null, null, "Description of internal functions that are involved in managing impacts and types of action taken by internal functions to address negative and advance positive impacts ", 1L, "", 1, null },
                    { 11111L, "S4.MDR-T_01-13", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6002), null, null, null, 96L, null, 1L, null, null, "Targets set to manage material impacts, risks and opportunities related to consumers and end-users [see ESRS 2 - MDR-T]", 1L, "", 1, null },
                    { 11112L, "S4-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6004), null, null, 2L, 96L, true, 1L, null, null, "Disclosure of whether and how consumers and end-users were engaged directly in setting targets", 1L, "", 1, null },
                    { 11113L, "S4-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6006), null, null, 2L, 96L, true, 1L, null, null, "Disclosure of whether and how consumers and end-users were engaged directly in tracking performance against targets", 1L, "", 1, null },
                    { 11114L, "S4-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6008), null, null, 2L, 96L, true, 1L, null, null, "Disclosure of whether and how consumers and end-users were engaged directly in identifying lessons or improvements as result of undertaking’s performance", 1L, "", 1, null },
                    { 11115L, "S4-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6011), null, null, 2L, 96L, true, 1L, null, null, "Disclosure of intended outcomes to be achieved in lives of consumers and end-users   ", 1L, "", 1, null },
                    { 11116L, "S4-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6013), null, null, 2L, 96L, true, 1L, null, null, "Information about stability over time of target in terms of definitions and methodologies to enable comparability ", 1L, "", 1, null },
                    { 11117L, "S4-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6016), null, null, 2L, 96L, true, 1L, null, null, "Disclosure of references to standards or commitments on which target is based ", 1L, "", 1, null },
                    { 11119L, "G1.GOV-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6020), null, null, null, 97L, true, 1L, null, null, "Disclosure of role of administrative, management and supervisory bodies related to business conduct", 1L, "", 1, null },
                    { 11120L, "G1.GOV-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6022), null, null, 2L, 97L, true, 1L, null, null, "Disclosure of expertise of administrative, management and supervisory bodies on business conduct matters", 1L, "", 1, null },
                    { 11121L, "G1.MDR-P_01-06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6024), null, null, 2L, 98L, null, 1L, null, null, "Policies in place to manage its material impacts, risks and opportunities related to business conduct and corporate culture [see ESRS 2 MDR-P]", 1L, "", 1, null },
                    { 11122L, "G1-1_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6026), null, null, null, 98L, true, 1L, null, null, "Description of how the undertaking establishes, develops, promotes and evaluates its corporate culture", 1L, "", 1, null },
                    { 11123L, "G1-1_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6028), null, null, 2L, 98L, true, 1L, null, null, "Description of the mechanisms for identifying, reporting and investigating concerns about unlawful behaviour or behaviour in contradiction of its code of conduct or similar internal rules", 1L, "", 1, null },
                    { 11124L, "G1-1_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6031), null, null, 2L, 98L, null, 1L, null, null, "No policies on anti-corruption or anti-bribery consistent with United Nations Convention against Corruption are in place", 1L, "", 1, null },
                    { 11125L, "G1-1_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6033), null, null, 2L, 98L, true, 1L, null, null, "Timetable for implementation of policies on anti-corruption or anti-bribery consistent with United Nations Convention against Corruption", 1L, "", 1, null },
                    { 11126L, "G1-1_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6035), null, null, 2L, 98L, true, 1L, null, null, "Disclosure of safeguards for reporting irregularities including whistleblowing protection", 1L, "", 1, null },
                    { 11127L, "G1-1_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6037), null, null, 2L, 98L, null, 1L, null, null, "No policies on protection of whistle-blowers are in place", 1L, "", 1, null },
                    { 11128L, "G1-1_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6040), null, null, 2L, 98L, true, 1L, null, null, "Timetable for implementation of policies on protection of whistle-blowers", 1L, "", 1, null },
                    { 11129L, "G1-1_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6042), null, null, 2L, 98L, null, 1L, null, null, "Undertaking is committed to investigate business conduct incidents promptly, independently and objectively", 1L, "", 1, null },
                    { 11130L, "G1-1_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6044), null, null, 2L, 98L, null, 1L, null, null, "Policies with respect to animal welfare are in place", 1L, "", 1, null },
                    { 11131L, "G1-1_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6046), null, null, 2L, 98L, true, 1L, null, null, "Information about policy for training within organisation on business conduct", 1L, "", 1, null },
                    { 11132L, "G1-1_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6048), null, null, 2L, 98L, true, 1L, null, null, "Disclosure of the functions that are most at risk in respect of corruption and bribery", 1L, "", 1, null },
                    { 11133L, "G1-1_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6049), null, null, 2L, 98L, null, 1L, null, null, "Entity is subject to legal requirements with regard to protection of whistleblowers", 1L, "", 1, null },
                    { 11134L, "G1-2_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6051), null, null, 2L, 99L, true, 1L, null, null, "Description of policy to prevent late payments, especially to SMEs", 1L, "", 1, null },
                    { 11135L, "G1-2_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6054), null, null, 2L, 99L, true, 1L, null, null, "Description of approaches in regard to relationships with suppliers, taking account risks related to supply chain and impacts on sustainability matters", 1L, "", 1, null },
                    { 11136L, "G1-2_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6057), null, null, 2L, 99L, true, 1L, null, null, "Disclosure of whether and how social and environmental criteria are taken into account for selection of supply-side contractual partners", 1L, "", 1, null },
                    { 11138L, "G1-3_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6060), null, null, null, 100L, true, 1L, null, null, "Information about procedures in place to prevent, detect, and address allegations or incidents of corruption or bribery", 1L, "", 1, null },
                    { 11139L, "G1-3_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6062), null, null, 2L, 100L, null, 1L, null, null, "Investigators or investigating committee are separate from chain of management involved in prevention and detection of corruption or bribery", 1L, "", 1, null },
                    { 11140L, "G1-3_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6064), null, null, 2L, 100L, true, 1L, null, null, "Information about process to report outcomes to administrative, management and supervisory bodies", 1L, "", 1, null },
                    { 11141L, "G1-3_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6066), null, null, 2L, 100L, true, 1L, null, null, "Disclosure of plans to adopt procedures to prevent, detect, and address allegations or incidents of corruption or bribery in case of no procedure", 1L, "", 1, null },
                    { 11142L, "G1-3_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6069), null, null, 2L, 100L, true, 1L, null, null, "Information about how policies are communicated to those for whom they are relevant (prevention and detection of corruption or bribery)", 1L, "", 1, null },
                    { 11143L, "G1-3_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6076), null, null, 2L, 100L, true, 1L, null, null, "Information about nature, scope and depth of anti-corruption or anti-bribery training programmes offered or required", 1L, "", 1, null },
                    { 11144L, "G1-3_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6078), null, null, 2L, 100L, null, 1L, null, null, "Percentage of functions-at-risk covered by training programmes", 1L, "", 1, null },
                    { 11145L, "G1-3_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6080), null, null, null, 100L, true, 1L, null, null, "Information about members of administrative, supervisory and management bodies relating to anti-corruption or anti-bribery training", 1L, "", 1, 38L },
                    { 11146L, "G1-3_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6082), null, null, 2L, 100L, true, 1L, null, null, "Disclosure of an analysis of its training activities by, for example, region of training or category", 1L, "", 1, null },
                    { 11147L, "G1.MDR-A_01-12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6084), null, null, 2L, 101L, null, 1L, null, null, "Action plans and resources to manage its material impacts, risks, and opportunities related to corruption and bribery [see ESRS 2 - MDR-A]", 1L, "", 1, null },
                    { 11148L, "G1-4_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6087), null, null, 2L, 101L, null, 1L, null, null, "Number of convictions for violation of anti-corruption and anti- bribery laws", 1L, "", 1, null },
                    { 11149L, "G1-4_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6089), null, null, null, 101L, null, 1L, null, null, "Amount of fines for violation of anti-corruption and anti- bribery laws", 1L, "", 1, 709L },
                    { 11150L, "G1-4_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6091), null, null, 3L, 101L, null, 1L, null, null, "Prevention and detection of corruption or bribery - anti-corruption and bribery training table", 1L, "", 1, null },
                    { 11151L, "G1-4_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6093), null, null, 1L, 101L, null, 1L, null, null, "Number of confirmed incidents of corruption or bribery", 1L, "", 1, null },
                    { 11152L, "G1-4_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6095), null, null, null, 101L, true, 1L, null, null, "Information about nature of confirmed incidents of corruption or bribery", 1L, "", 1, 709L },
                    { 11153L, "G1-4_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6097), null, null, 2L, 101L, null, 1L, null, null, "Number of confirmed incidents in which own workers were dismissed or disciplined for corruption or bribery-related incidents", 1L, "", 1, null },
                    { 11154L, "G1-4_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6099), null, null, null, 101L, null, 1L, null, null, "Number of confirmed incidents relating to contracts with business partners that were terminated or not renewed due to violations related to corruption or bribery", 1L, "", 1, 709L },
                    { 11155L, "G1-4_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6102), null, null, null, 101L, true, 1L, null, null, "Information about details of public legal cases regarding corruption or bribery brought against undertaking and own workers and about outcomes of such cases", 1L, "", 1, 709L },
                    { 11156L, "G1-5_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6104), null, null, 2L, 102L, true, 1L, null, null, "Information about representative(s) responsible in administrative, management and supervisory bodies for oversight of political influence and lobbying activities", 1L, "", 1, null },
                    { 11157L, "G1-5_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6106), null, null, 2L, 102L, true, 1L, null, null, "Information about financial or in-kind political contributions", 1L, "", 1, null },
                    { 11158L, "G1-5_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6108), null, null, 2L, 102L, null, 1L, null, null, "Financial political contributions made", 1L, "", 1, null },
                    { 11159L, "G1-5_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6110), null, null, 3L, 102L, null, 1L, null, null, "Amount of internal and external lobbying expenses", 1L, "", 1, null },
                    { 11160L, "G1-5_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6112), null, null, 3L, 102L, null, 1L, null, null, "Amount paid for membership to lobbying associations", 1L, "", 1, null },
                    { 11161L, "G1-5_06", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6114), null, null, 3L, 102L, null, 1L, null, null, "In-kind political contributions made", 1L, "", 1, null },
                    { 11162L, "G1-5_07", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6117), null, null, 3L, 102L, true, 1L, null, null, "Disclosure of how monetary value of in-kind contributions is estimated", 1L, "", 1, null },
                    { 11163L, "G1-5_08", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6119), null, null, 2L, 102L, null, 1L, null, null, "Financial and in-kind political contributions made [table]", 1L, "", 1, null },
                    { 11164L, "G1-5_09", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6121), null, null, 1L, 102L, true, 1L, null, null, "Disclosure of main topics covered by lobbying activities and undertaking's main positions on these topics", 1L, "", 1, null },
                    { 11165L, "G1-5_10", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6123), null, null, 2L, 102L, null, 1L, null, null, "Undertaking is registered in EU Transparency Register or in equivalent transparency register in Member State", 1L, "", 1, null },
                    { 11166L, "G1-5_11", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6125), null, null, 2L, 102L, true, 1L, null, null, "Information about appointment of any members of administrative, management and supervisory bodies who held comparable position in public administration in two years preceding such appointment", 1L, "", 1, null },
                    { 11167L, "G1-5_12", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6126), null, null, 2L, 102L, null, 1L, null, null, "The entity is legally obliged to be a member of a chamber of commerce or other organisation that represents its interests", 1L, "", 1, null },
                    { 11169L, "G1-6_01", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6131), null, null, null, 103L, null, 1L, null, null, "Average number of days to pay invoice from date when contractual or statutory term of payment starts to be calculated", 1L, "", 1, null },
                    { 11170L, "G1-6_02", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6133), null, null, null, 103L, true, 1L, null, null, "Description of undertakings standard payment terms in number of days by main category of suppliers", 1L, "", 1, 709L },
                    { 11171L, "G1-6_03", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6135), null, null, 2L, 103L, null, 1L, null, null, "Percentage of payments aligned with standard payment terms", 1L, "", 1, null },
                    { 11172L, "G1-6_04", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6137), null, null, null, 103L, null, 1L, null, null, "Number of outstanding legal proceedings for late payments", 1L, "", 1, 38L },
                    { 11173L, "G1-6_05", 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(6139), null, null, null, 103L, true, 1L, null, null, "Disclosure of contextual information regarding payment practices", 1L, "", 1, 709L }
                });

            migrationBuilder.InsertData(
                table: "ModelDimensionValues",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataModelId", "DimensionsId", "LastModifiedBy", "LastModifiedDate", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8417), 1L, 1000L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8417), 1 },
                    { 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8419), 1L, 1001L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8419), 1 },
                    { 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8421), 1L, 1002L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8421), 1 },
                    { 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8423), 1L, 1010L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8423), 1 },
                    { 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8428), 1L, 1011L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8429), 1 },
                    { 6L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8430), 1L, 1012L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8431), 1 },
                    { 7L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8432), 2L, 1000L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8433), 1 },
                    { 8L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8434), 2L, 1001L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8434), 1 },
                    { 9L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8436), 2L, 1002L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8436), 1 },
                    { 10L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8437), 2L, 1010L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8438), 1 },
                    { 11L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8439), 2L, 1011L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8440), 1 },
                    { 12L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8441), 2L, 1012L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8441), 1 },
                    { 13L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8443), 1L, 1003L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8443), 1 },
                    { 14L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8444), 2L, 1003L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8445), 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7831), 1001L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7832), "Hour", "Hour", "Hr", 1 },
                    { 1L, 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7834), 1002L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7834), "Minute", "Minute", "Min", 1 },
                    { 1L, 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7839), 1003L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7840), "Second", "Second", "Sec", 1 },
                    { 1L, 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7842), 1004L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7842), "Day", "Day", "Day", 1 },
                    { 1L, 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7844), 1005L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7844), "Month", "Month", "Month", 1 },
                    { 1L, 6L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7847), 1006L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7847), "Quarter", "Quarter", "Qrtr", 1 },
                    { 1L, 7L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7849), 1007L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7850), "Year", "Year", "Year", 1 },
                    { 1L, 8L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7851), 1008L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7852), "Millimol per liter", "Millimol per liter", "mMol/l", 1 },
                    { 1L, 9L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7853), 1009L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7854), "Mol per cubic meter", "Mol per cubic meter", "Mol/m3", 1 },
                    { 1L, 10L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7855), 1010L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7856), "Mol per liter", "Mol per liter", "Mol/l", 1 },
                    { 1L, 11L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7857), 1011L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7858), "Acre", "Acre", "Acre", 1 },
                    { 1L, 12L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7859), 1012L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7860), "Hectare", "Hectare", "Ha", 1 },
                    { 1L, 13L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7861), 1013L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7862), "Square Yard", "Square Yard", "Yd2", 1 },
                    { 1L, 14L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7863), 1014L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7865), "Square centimeter", "Square centimeter", "Cm2", 1 },
                    { 1L, 15L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7866), 1015L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7867), "Square foot", "Square foot", "Ft2", 1 },
                    { 1L, 16L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7868), 1016L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7869), "Square inch", "Square inch", "Inch2", 1 },
                    { 1L, 17L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7870), 1017L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7871), "Square kilometer", "Square kilometer", "Km2", 1 },
                    { 1L, 18L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7872), 1018L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7873), "Square meter", "Square meter", "M2", 1 },
                    { 1L, 19L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7874), 1019L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7875), "Square mile", "Square mile", "Mile2", 1 },
                    { 1L, 20L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7876), 1020L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7877), "Square millimeter", "Square millimeter", "Mm2", 1 },
                    { 1L, 21L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7878), 1021L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7878), "Gram/Cubic meter", "Gram/Cubic meter", "G/M3", 1 },
                    { 1L, 22L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7880), 1022L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7881), "Gram/cubic centimeter", "Gram/cubic centimeter", "G/Cm3", 1 },
                    { 1L, 23L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7883), 1023L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7883), "Gram/liter", "Gram/liter", "G/L", 1 },
                    { 1L, 24L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7885), 1024L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7885), "Kilogram/Standard Cubic Foot", "Kilogram/Standard Cubic Foot", "Kg/Scf", 1 },
                    { 1L, 25L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7887), 1025L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7887), "Kilogram/US Barrel", "Kilogram/US Barrel", "Kg/Bbl", 1 },
                    { 1L, 26L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7889), 1026L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7889), "Kilogram/cubic decimeter", "Kilogram/cubic decimeter", "Kg/Dm3", 1 },
                    { 1L, 27L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7891), 1027L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7891), "Kilogram/cubic meter", "Kilogram/cubic meter", "Kg/M3", 1 },
                    { 1L, 28L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7893), 1028L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7893), "Microgram/cubic meter", "Microgram/cubic meter", "µg/M3", 1 },
                    { 1L, 29L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7895), 1029L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7895), "Microgram/liter", "Microgram/liter", "µg/L", 1 },
                    { 1L, 30L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7897), 1030L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7898), "Milligram/cubic meter", "Milligram/cubic meter", "Mg/M3", 1 },
                    { 1L, 31L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7899), 1031L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7900), "Milligram/liter", "Milligram/liter", "Mg/L", 1 },
                    { 1L, 32L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7901), 1032L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7902), "Ton/Cubic meter", "Ton/Cubic meter", "T/M3", 1 },
                    { 1L, 33L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7903), 1033L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7903), "Tonne/1000 Cubic Meters", "Tonne/1000 Cubic Meters", "T/Tm3", 1 },
                    { 1L, 34L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7905), 1034L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7905), "Tonne/US Barrel", "Tonne/US Barrel", "T/Bbl", 1 },
                    { 1L, 35L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7907), 1035L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7907), "US Pound/Standard Cubic Foot", "US Pound/Standard Cubic Foot", "Lb/Scf", 1 },
                    { 1L, 36L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7909), 1036L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7909), "US Pound/US Gallon", "US Pound/US Gallon", "Lb/Gal", 1 },
                    { 1L, 37L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7911), 1037L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7911), "US Tonne/US Gallon", "US Tonne/US Gallon", "Ton/Gl", 1 },
                    { 1L, 38L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7913), 1038L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7913), "Percentage", "Percentage", "%", 1 },
                    { 1L, 39L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7916), 1039L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7916), "Gigajoule", "Gigajoule", "Gj", 1 },
                    { 1L, 40L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7918), 1040L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7918), "Joule", "Joule", "J", 1 },
                    { 1L, 41L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7920), 1041L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7920), "Kilojoule", "Kilojoule", "Kj", 1 },
                    { 1L, 42L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7922), 1042L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7922), "Kilowatt hours", "Kilowatt hours", "Kwh", 1 },
                    { 1L, 43L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7923), 1043L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7924), "Megajoule", "Megajoule", "Mj", 1 },
                    { 1L, 44L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7925), 1044L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7926), "Megawatt hour", "Megawatt hour", "Mwh", 1 },
                    { 1L, 45L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7927), 1045L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7928), "Millijoule", "Millijoule", "Mj", 1 },
                    { 1L, 46L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7929), 1046L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7930), "kilocalories", "kilocalories", "Kcal", 1 },
                    { 1L, 47L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7931), 1047L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7932), "Kilonewton", "Kilonewton", "Nd", 1 },
                    { 1L, 48L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7934), 1048L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7935), "Meganewton", "Meganewton", "Mn", 1 },
                    { 1L, 49L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7936), 1049L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7936), "Newton", "Newton", "N", 1 },
                    { 1L, 50L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7938), 1050L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7938), "1/minute", "1/minute", "1/Min", 1 },
                    { 1L, 51L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7940), 1051L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7940), "Bottles per minute", "Bottles per minute", "Bpm", 1 },
                    { 1L, 52L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7942), 1052L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7942), "Hertz", "Hertz", "1/Second)", 1 },
                    { 1L, 53L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7944), 1053L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7944), "Kilohertz", "Kilohertz", "Khz", 1 },
                    { 1L, 54L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7946), 1054L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7946), "Megahertz", "Megahertz", "Mhz", 1 },
                    { 1L, 55L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7948), 1055L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7948), "RPM", "RPM", "Rpm", 1 },
                    { 1L, 56L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7956), 1056L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7956), "Heat Conductivity", "Heat Conductivity", "W/Mk", 1 },
                    { 1L, 57L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7958), 1057L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7958), "Liter/Molsecond", "Liter/Molsecond", "L/M_.S", 1 },
                    { 1L, 58L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7960), 1058L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7960), "1 / square meter", "1 / square meter", "1/M2", 1 },
                    { 1L, 59L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7962), 1059L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7962), "Miles per gallon", "Miles per gallon", "Us)", 1 },
                    { 1L, 60L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7963), 1060L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7964), "Square meter/second", "Square meter/second", "M2/S", 1 },
                    { 1L, 61L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7965), 1061L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7966), "Square millimeter/second", "Square millimeter/second", "Mm2/S", 1 },
                    { 1L, 62L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7967), 1062L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7968), "Centimeter", "Centimeter", "Cm", 1 },
                    { 1L, 63L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7969), 1063L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7970), "Decimeter", "Decimeter", "Dm", 1 },
                    { 1L, 64L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7972), 1064L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7973), "Foot", "Foot", "Foot", 1 },
                    { 1L, 65L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7974), 1065L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7975), "Inch", "Inch", "Inch", 1 },
                    { 1L, 66L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7976), 1066L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7977), "Kilometer", "Kilometer", "Km", 1 },
                    { 1L, 67L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7978), 1067L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7979), "Meter", "Meter", "M", 1 },
                    { 1L, 68L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7980), 1068L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7981), "Micrometer", "Micrometer", "µm", 1 },
                    { 1L, 69L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7982), 1069L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7983), "Mile", "Mile", "Mile", 1 },
                    { 1L, 70L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7984), 1070L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7985), "Millimeter", "Millimeter", "Mm", 1 },
                    { 1L, 71L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7986), 1071L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7987), "Nanometer", "Nanometer", "Nm", 1 },
                    { 1L, 72L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7988), 1072L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7990), "Yards", "Yards", "Yd", 1 },
                    { 1L, 73L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7991), 1073L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7992), "Candela", "Candela", "Cd", 1 },
                    { 1L, 74L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7993), 1074L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7994), "Tesla", "Tesla", "D", 1 },
                    { 1L, 75L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7995), 1075L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7996), "Gram", "Gram", "G", 1 },
                    { 1L, 76L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7997), 1076L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7998), "Kilotonne", "Kilotonne", "Kt", 1 },
                    { 1L, 77L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(7999), 1077L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8000), "Milligram", "Milligram", "Mg", 1 },
                    { 1L, 78L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8001), 1078L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8002), "Ounce", "Ounce", "Oz", 1 },
                    { 1L, 79L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8003), 1079L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8004), "Tonne", "Tonne", "T", 1 },
                    { 1L, 80L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8005), 1080L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8006), "US pound", "US pound", "Lb", 1 },
                    { 1L, 81L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8008), 1081L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8008), "US ton", "US ton", "Ton", 1 },
                    { 1L, 82L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8010), 1082L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8010), "Kilogram", "Kilogram", "Kg", 1 },
                    { 1L, 83L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8012), 1083L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8012), "Gram/square meter", "Gram/square meter", "G/M2", 1 },
                    { 1L, 84L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8014), 1084L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8014), "Kilogram/Square meter", "Kilogram/Square meter", "Kg/M2", 1 },
                    { 1L, 85L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8016), 1085L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8016), "Milligram/Square centimeter", "Milligram/Square centimeter", "Mg/Cm2", 1 },
                    { 1L, 86L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8018), 1086L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8018), "Kilogram/second", "Kilogram/second", "Kg/S", 1 },
                    { 1L, 87L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8020), 1087L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8020), "Kilogram/Joule", "Kilogram/Joule", "Kg/J", 1 },
                    { 1L, 88L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8022), 1088L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8022), "Kilogram/Million BTU", "Kilogram/Million BTU", "Kg/Mb", 1 },
                    { 1L, 89L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8025), 1089L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8025), "Tonne/British Thermal Unit", "Tonne/British Thermal Unit", "T/Btu", 1 },
                    { 1L, 90L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8027), 1090L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8027), "Tonne/Joule", "Tonne/Joule", "T/Joul", 1 },
                    { 1L, 91L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8029), 1091L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8029), "Tonne/Terajoule", "Tonne/Terajoule", "T/Tj", 1 },
                    { 1L, 92L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8031), 1092L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8031), "US Pound/British Thermal Unit", "US Pound/British Thermal Unit", "Lb/Btu", 1 },
                    { 1L, 93L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8033), 1093L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8033), "US Pound/Million BTU", "US Pound/Million BTU", "Lb/Mb", 1 },
                    { 1L, 94L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8035), 1094L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8035), "Gram/hectogram", "Gram/hectogram", "G/Hg", 1 },
                    { 1L, 95L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8037), 1095L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8037), "Gram/kilogram", "Gram/kilogram", "G/Kg", 1 },
                    { 1L, 96L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8039), 1096L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8039), "Kilogram/Kilogram", "Kilogram/Kilogram", "Kg/Kg", 1 },
                    { 1L, 97L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8040), 1097L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8042), "Kilogram/US Tonne", "Kilogram/US Tonne", "Kg/Ton", 1 },
                    { 1L, 98L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8043), 1098L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8044), "Mass parts per billion", "Mass parts per billion", "Ppb(M)", 1 },
                    { 1L, 99L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8045), 1099L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8046), "Mass parts per million", "Mass parts per million", "Ppm(M)", 1 },
                    { 1L, 100L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8047), 1100L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8048), "Mass parts per trillion", "Mass parts per trillion", "Ppt(M)", 1 },
                    { 1L, 101L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8049), 1101L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8050), "Milligram/gram", "Milligram/gram", "Mg/G", 1 },
                    { 1L, 102L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8051), 1102L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8052), "Milligram/kilogram", "Milligram/kilogram", "Mg/Kg", 1 },
                    { 1L, 103L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8053), 1103L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8054), "Percent mass", "Percent mass", "%(M)", 1 },
                    { 1L, 104L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8055), 1104L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8056), "Permille mass", "Permille mass", "%O(M)", 1 },
                    { 1L, 105L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8057), 1105L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8058), "Tonne/Tonne", "Tonne/Tonne", "T/T", 1 },
                    { 1L, 106L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8060), 1106L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8061), "US Pound/US Tonne", "US Pound/US Tonne", "Lb/Ton", 1 },
                    { 1L, 107L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8062), 1107L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8063), "Microsecond", "Microsecond", "µs", 1 },
                    { 1L, 108L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8064), 1108L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8064), "Millisecond", "Millisecond", "Ms", 1 },
                    { 1L, 109L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8066), 1109L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8067), "Nanosecond", "Nanosecond", "Ns", 1 },
                    { 1L, 110L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8073), 1110L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8074), "Picosecond", "Picosecond", "Ps", 1 },
                    { 1L, 111L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8075), 1111L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8076), "Second", "Second", "S", 1 },
                    { 1L, 112L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8077), 1112L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8078), "Week", "Week", "W", 1 },
                    { 1L, 113L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8079), 1113L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8080), "Years", "Years", "Yr", 1 },
                    { 1L, 114L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8082), 1114L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8083), "Vaporization Speed", "Vaporization Speed", "Kg/Sm2", 1 },
                    { 1L, 115L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8084), 1115L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8085), "Centiliter", "Centiliter", "Cl", 1 },
                    { 1L, 116L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8086), 1116L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8087), "Cubic centimeter", "Cubic centimeter", "Cm3", 1 },
                    { 1L, 117L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8088), 1117L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8089), "Cubic decimeter", "Cubic decimeter", "Dm3", 1 },
                    { 1L, 118L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8090), 1118L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8091), "Cubic foot", "Cubic foot", "Ft3", 1 },
                    { 1L, 119L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8092), 1119L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8093), "Cubic inch", "Cubic inch", "Inch3", 1 },
                    { 1L, 120L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8094), 1120L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8095), "Cubic meter", "Cubic meter", "M3", 1 },
                    { 1L, 121L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8096), 1121L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8097), "Cubic millimeter", "Cubic millimeter", "Mm3", 1 },
                    { 1L, 122L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8099), 1122L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8099), "Cubic yard", "Cubic yard", "Yd3", 1 },
                    { 1L, 123L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8101), 1123L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8101), "Hectoliter", "Hectoliter", "Hl", 1 },
                    { 1L, 124L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8103), 1124L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8103), "Liter", "Liter", "L", 1 },
                    { 1L, 125L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8105), 1125L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8105), "Microliter", "Microliter", "µl", 1 },
                    { 1L, 126L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8107), 1126L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8107), "Milliliter", "Milliliter", "Ml", 1 },
                    { 1L, 127L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8109), 1127L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8109), "Pint, US liquid", "Pint, US liquid", "Pt Us", 1 },
                    { 1L, 128L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8111), 1128L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8111), "Quart, US liquid", "Quart, US liquid", "Qt Us", 1 },
                    { 1L, 129L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8113), 1129L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8113), "US gallon", "US gallon", "Gal Us", 1 },
                    { 1L, 130L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8115), 1130L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8116), "Cubic meter/Cubic meter", "Cubic meter/Cubic meter", "M3/M3", 1 },
                    { 1L, 131L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8118), 1131L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8118), "Milliliter/cubic meter", "Milliliter/cubic meter", "Ml/M3", 1 },
                    { 1L, 132L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8120), 1132L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8120), "Percent volume", "Percent volume", "%(V)", 1 },
                    { 1L, 133L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8122), 1133L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8122), "Permille volume", "Permille volume", "%O(V)", 1 },
                    { 1L, 134L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8124), 1134L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8124), "Volume parts per billion", "Volume parts per billion", "Ppb(V)", 1 },
                    { 1L, 135L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8126), 1135L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8126), "Volume parts per million", "Volume parts per million", "Ppm(V)", 1 },
                    { 1L, 136L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8128), 1136L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8128), "Volume parts per trillion", "Volume parts per trillion", "Ppt(V)", 1 },
                    { 1L, 137L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8130), 1137L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8130), "Cubic centimeter/second", "Cubic centimeter/second", "Cm3/S", 1 },
                    { 1L, 138L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8132), 1138L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8132), "Cubic meter/Hour", "Cubic meter/Hour", "M3/H", 1 },
                    { 1L, 139L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8134), 1139L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8134), "Cubic meter/day", "Cubic meter/day", "M3/D", 1 },
                    { 1L, 140L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8136), 1140L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8136), "Cubic meter/second", "Cubic meter/second", "M3/S", 1 },
                    { 1L, 141L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8138), 1141L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8138), "Liter per hour", "Liter per hour", "L/Hr", 1 },
                    { 1L, 142L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8140), 1142L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8140), "Liter/Minute", "Liter/Minute", "L/Min", 1 },
                    { 1L, 709L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8142), 1709L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8142), "Integer", "Integer", "Integer", 1 },
                    { 1L, 710L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8144), 1710L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8144), "Decimal", "Decimal", "Decimal", 1 },
                    { 1L, 717L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8146), 1717L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8146), "Narrative", "Narrative", "Narrative", 1 }
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

            migrationBuilder.InsertData(
                table: "ModelDatapoints",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataModelId", "DatapointValuesId", "LastModifiedBy", "LastModifiedDate", "State" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8348), 1L, 10000L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8350), 1 },
                    { 2L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8351), 2L, 10049L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8352), 1 },
                    { 3L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8353), 3L, 10230L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8353), 1 },
                    { 4L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8355), 4L, 10286L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8355), 1 },
                    { 5L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8356), 5L, 10401L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8357), 1 },
                    { 6L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8358), 5L, 10402L, 1L, new DateTime(2024, 9, 9, 14, 14, 45, 943, DateTimeKind.Utc).AddTicks(8358), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataModelFilters_ModelConfigurationId",
                table: "DataModelFilters",
                column: "ModelConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModels_OrganizationId",
                table: "DataModels",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_ColumnId",
                table: "DataModelValues",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_CombinationId",
                table: "DataModelValues",
                column: "CombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataModelValues_RowId",
                table: "DataModelValues",
                column: "RowId");

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
                name: "IX_DataPointValues_DisclosureRequirementId",
                table: "DataPointValues",
                column: "DisclosureRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_LanguageId",
                table: "DataPointValues",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_OrganizationId",
                table: "DataPointValues",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPointValues_UnitOfMeasureId",
                table: "DataPointValues",
                column: "UnitOfMeasureId");

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
                name: "IX_DisclosureRequirement_LanguageId",
                table: "DisclosureRequirement",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DisclosureRequirement_StandardId",
                table: "DisclosureRequirement",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_DataPointValuesId",
                table: "Hierarchy",
                column: "DataPointValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_OrganizationId",
                table: "Languages",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelConfiguration_ColumnId",
                table: "ModelConfiguration",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelConfiguration_DataModelId",
                table: "ModelConfiguration",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelConfiguration_DimensionTypeId",
                table: "ModelConfiguration",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelConfiguration_RowId",
                table: "ModelConfiguration",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDatapoints_DataModelId",
                table: "ModelDatapoints",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDatapoints_DatapointValuesId",
                table: "ModelDatapoints",
                column: "DatapointValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDimensionTypes_DataModelId",
                table: "ModelDimensionTypes",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDimensionTypes_DimensionTypeId",
                table: "ModelDimensionTypes",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDimensionValues_DataModelId",
                table: "ModelDimensionValues",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDimensionValues_DimensionsId",
                table: "ModelDimensionValues",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFilterCombinationalValues_DimensionsId",
                table: "ModelFilterCombinationalValues",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFilterCombinationalValues_DimensionTypeId",
                table: "ModelFilterCombinationalValues",
                column: "DimensionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFilterCombinationalValues_ModelFilterCombinationsId",
                table: "ModelFilterCombinationalValues",
                column: "ModelFilterCombinationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFilterCombinationalValues_ModelFilterId",
                table: "ModelFilterCombinationalValues",
                column: "ModelFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelFilterCombinations_DataModelId",
                table: "ModelFilterCombinations",
                column: "DataModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationHeirarchies_OrganizationId",
                table: "OrganizationHeirarchies",
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
                name: "IX_Standard_LanguageId",
                table: "Standard",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Standard_TopicId",
                table: "Standard",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LanguageId",
                table: "Topic",
                column: "LanguageId");

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
                name: "DataModelFilters");

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
                name: "ModelDimensionTypes");

            migrationBuilder.DropTable(
                name: "ModelDimensionValues");

            migrationBuilder.DropTable(
                name: "OrganizationHeirarchies");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTranslations");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypeTranslations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ModelConfiguration");

            migrationBuilder.DropTable(
                name: "ModelFilterCombinationalValues");

            migrationBuilder.DropTable(
                name: "DataPointValues");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "ModelFilterCombinations");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DataPointTypes");

            migrationBuilder.DropTable(
                name: "DisclosureRequirement");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "DimensionTypes");

            migrationBuilder.DropTable(
                name: "DataModels");

            migrationBuilder.DropTable(
                name: "Standard");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureTypes");

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

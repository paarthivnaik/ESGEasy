using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededUOMsampledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 4L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 2L, 4L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 6L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 7L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 2L, 7L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.CreateTable(
                name: "Hierarchy",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NodeId = table.Column<long>(type: "bigint", nullable: false),
                    NodeType = table.Column<int>(type: "integer", nullable: false),
                    ChildId = table.Column<long>(type: "bigint", nullable: false),
                    DimensionId = table.Column<long>(type: "bigint", nullable: false),
                    DatapointId = table.Column<long>(type: "bigint", nullable: false),
                    DataPointTypesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hierarchy_DataPointTypes_DataPointTypesId",
                        column: x => x.DataPointTypesId,
                        principalTable: "DataPointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hierarchy_Dimensions_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 1L, 2L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 2L, 2L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 3L, 2L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedDate", "Id", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(895), 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(896), "Acid/Base capacity", "Acid/Base capacity", "Acid/Base capacity", 1 });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 2L },
                columns: new[] { "CreatedDate", "Id", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(898), 2L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(899), "Area", "Area", "Area", 1 });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 3L },
                columns: new[] { "CreatedDate", "Id", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(900), 3L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(901), "Density", "Density", "Density", 1 });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Code", "CreatedDate", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[] { "acidbasecapacity", new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(640), new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(641), "", "Acid/Base capacity", "Acid/Base capacity" });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Code", "CreatedDate", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[] { "area", new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(647), new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(648), "", "Area", "Area" });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Code", "CreatedDate", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[] { "density", new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(650), new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(651), "", "Density", "Density" });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State" },
                values: new object[] { 4L, "time", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(653), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(653), "", "Time", 1L, "Time", 1 });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 108L, "mMol/l", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(690), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(690), "Millimol per liter", "acidbasecapacity", 1L, "mMol/l", 1, 1L },
                    { 109L, "Mol/m3", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(693), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(693), "Mol per cubic meter", "acidbasecapacity", 1L, "Mol/m3", 1, 1L },
                    { 110L, "Mol/l", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(695), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(695), "Mol per liter", "acidbasecapacity", 1L, "Mol/l", 1, 1L },
                    { 111L, "acre", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(697), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(698), "Acre", "area", 1L, "Acre", 1, 2L },
                    { 112L, "ha", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(700), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(700), "Hectare", "area", 1L, "Ha", 1, 2L },
                    { 113L, "yd2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(702), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(702), "Square Yard", "area", 1L, "Yd2", 1, 2L },
                    { 114L, "cm2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(704), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(705), "Square centimeter", "area", 1L, "Cm2", 1, 2L },
                    { 115L, "ft2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(706), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(707), "Square foot", "area", 1L, "Ft2", 1, 2L },
                    { 116L, "Inch2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(708), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(709), "Square inch", "area", 1L, "Inch2", 1, 2L },
                    { 117L, "km2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(712), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(712), "Square kilometer", "area", 1L, "Km2", 1, 2L },
                    { 118L, "m2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(714), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(714), "Square meter", "area", 1L, "M2", 1, 2L },
                    { 119L, "Mile2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(716), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(716), "Square mile", "area", 1L, "Mile2", 1, 2L },
                    { 120L, "mm2", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(718), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(719), "Square millimeter", "area", 1L, "Mm2", 1, 2L },
                    { 121L, "g/m3", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(720), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(721), "Gram/Cubic meter", "density", 1L, "G/M3", 1, 3L },
                    { 122L, "g/cm3", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(722), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(723), "Gram/cubic centimeter", "density", 1L, "G/Cm3", 1, 3L },
                    { 123L, "g/l", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(725), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(725), "Gram/liter", "density", 1L, "G/L", 1, 3L },
                    { 124L, "kg/scf", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(728), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(728), "Kilogram/Standard Cubic Foot", "density", 1L, "Kg/Scf", 1, 3L },
                    { 125L, "kg/bbl", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(730), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(731), "Kilogram/US Barrel", "density", 1L, "Kg/Bbl", 1, 3L },
                    { 126L, "kg/dm3", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(732), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(733), "Kilogram/cubic decimeter", "density", 1L, "Kg/Dm3", 1, 3L },
                    { 127L, "kg/m3", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(734), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(735), "Kilogram/cubic meter", "density", 1L, "Kg/M3", 1, 3L },
                    { 128L, "µg/m3", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(737), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(737), "Microgram/cubic meter", "density", 1L, "µg/M3", 1, 3L },
                    { 129L, "µg/l", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(739), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(739), "Microgram/liter", "density", 1L, "µg/L", 1, 3L }
                });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(530), new Guid("045de448-b324-4125-8c1c-d4398f0184df") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(535), new Guid("132cb155-5352-4d46-a1d8-40eb8216db04") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(538), new Guid("c5d5a195-de1d-48f6-9c96-012137780ccd") });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 108L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(814), 8L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(815), "Millimol per liter", "Millimol per liter", "mMol/l", 1 },
                    { 1L, 109L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(816), 9L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(817), "Mol per cubic meter", "Mol per cubic meter", "Mol/m3", 1 },
                    { 1L, 110L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(819), 10L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(820), "Mol per liter", "Mol per liter", "Mol/l", 1 },
                    { 1L, 111L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(821), 11L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(822), "Acre", "Acre", "Acre", 1 },
                    { 1L, 112L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(824), 12L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(824), "Hectare", "Hectare", "Ha", 1 },
                    { 1L, 113L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(826), 13L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(826), "Square Yard", "Square Yard", "Yd2", 1 },
                    { 1L, 114L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(829), 14L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(830), "Square centimeter", "Square centimeter", "Cm2", 1 },
                    { 1L, 115L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(831), 15L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(832), "Square foot", "Square foot", "Ft2", 1 },
                    { 1L, 116L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(833), 16L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(834), "Square inch", "Square inch", "Inch2", 1 },
                    { 1L, 117L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(835), 17L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(836), "Square kilometer", "Square kilometer", "Km2", 1 },
                    { 1L, 118L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(837), 18L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(839), "Square meter", "Square meter", "M2", 1 },
                    { 1L, 119L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(840), 19L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(841), "Square mile", "Square mile", "Mile2", 1 },
                    { 1L, 120L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(842), 20L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(843), "Square millimeter", "Square millimeter", "Mm2", 1 },
                    { 1L, 121L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(844), 21L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(845), "Gram/Cubic meter", "Gram/Cubic meter", "G/M3", 1 },
                    { 1L, 122L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(846), 22L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(847), "Gram/cubic centimeter", "Gram/cubic centimeter", "G/Cm3", 1 },
                    { 1L, 123L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(848), 23L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(849), "Gram/liter", "Gram/liter", "G/L", 1 },
                    { 1L, 124L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(850), 24L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(851), "Kilogram/Standard Cubic Foot", "Kilogram/Standard Cubic Foot", "Kg/Scf", 1 },
                    { 1L, 125L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(852), 25L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(853), "Kilogram/US Barrel", "Kilogram/US Barrel", "Kg/Bbl", 1 },
                    { 1L, 126L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(854), 26L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(855), "Kilogram/cubic decimeter", "Kilogram/cubic decimeter", "Kg/Dm3", 1 },
                    { 1L, 127L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(858), 27L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(858), "Kilogram/cubic meter", "Kilogram/cubic meter", "Kg/M3", 1 },
                    { 1L, 128L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(860), 28L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(860), "Microgram/cubic meter", "Microgram/cubic meter", "µg/M3", 1 },
                    { 1L, 129L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(862), 29L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(862), "Microgram/liter", "Microgram/liter", "µg/L", 1 }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypeTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureTypeId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[] { 1L, 4L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(902), 4L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(903), "Time", "Time", "Time", 1 });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 101L, "hh", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(673), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(673), "Hour", "time", 1L, "Hr", 1, 4L },
                    { 102L, "mm", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(676), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(676), "Minute", "time", 1L, "Min", 1, 4L },
                    { 103L, "ss", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(678), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(679), "Second", "time", 1L, "Sec", 1, 4L },
                    { 104L, "d", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(680), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(681), "Day", "time", 1L, "Day", 1, 4L },
                    { 105L, "m", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(683), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(683), "Month", "time", 1L, "Month", 1, 4L },
                    { 106L, "q", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(685), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(686), "Quarter", "time", 1L, "Qrtr", 1, 4L },
                    { 107L, "y", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(687), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(688), "Year", "time", 1L, "Year", 1, 4L },
                    { 130L, "mg/m3", 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(766), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(767), "Milligram/cubic meter", "density", 1L, "Mg/M3", 1, 4L }
                });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 101L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(797), 1L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(798), "Hour", "Hour", "Hr", 1 },
                    { 1L, 102L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(801), 2L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(801), "Minute", "Minute", "Min", 1 },
                    { 1L, 103L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(803), 3L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(804), "Second", "Second", "Sec", 1 },
                    { 1L, 104L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(806), 4L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(806), "Day", "Day", "Day", 1 },
                    { 1L, 105L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(808), 5L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(808), "Month", "Month", "Month", 1 },
                    { 1L, 106L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(810), 6L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(810), "Quarter", "Quarter", "Qrtr", 1 },
                    { 1L, 107L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(812), 7L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(813), "Year", "Year", "Year", 1 },
                    { 1L, 130L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(864), 30L, 1L, new DateTime(2024, 8, 21, 5, 28, 12, 222, DateTimeKind.Utc).AddTicks(864), "Milligram/cubic meter", "Milligram/cubic meter", "Mg/M3", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_DataPointTypesId",
                table: "Hierarchy",
                column: "DataPointTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchy_DimensionId",
                table: "Hierarchy",
                column: "DimensionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hierarchy");

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 101L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 102L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 103L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 104L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 105L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 106L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 107L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 108L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 109L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 110L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 111L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 112L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 113L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 114L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 115L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 116L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 117L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 118L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 119L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 120L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 121L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 122L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 123L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 124L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 125L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 126L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 127L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 128L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 129L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 130L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 4L });

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 1L, 2L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 2L, 2L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "DimensionTypeTranslations",
                keyColumns: new[] { "DimensionTypeId", "LanguageId" },
                keyValues: new object[] { 3L, 2L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedDate", "Id", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3775), 13L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3776), "meterpersecond", "speed", "m/s", 0 });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 2L },
                columns: new[] { "CreatedDate", "Id", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3769), 10L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3769), "Kilogram", "weight", "kg", 0 });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 3L },
                columns: new[] { "CreatedDate", "Id", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3773), 12L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3774), "milliliter", "amount", "ml", 0 });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTypeTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureTypeId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 2L, 1L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3777), 14L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3778), "kmperhour", "speed", "kmph", 0 },
                    { 2L, 2L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3771), 11L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3772), "Gram", "weight", "gm", 0 }
                });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Code", "CreatedDate", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[] { "speed", new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3673), new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3673), "Type 1", "Speed", "T1" });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Code", "CreatedDate", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[] { "weight", new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3682), new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3682), "Type 2", "Weight", "T2" });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Code", "CreatedDate", "LastModifiedDate", "LongText", "Name", "ShortText" },
                values: new object[] { "amount", new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3684), new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3685), "Type 3", "Amount", "T3" });

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "UnitOfMeasureTypeId" },
                values: new object[,]
                {
                    { 4L, "weight", 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3703), 1L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3703), "Kilogram", "weight", 1L, "kg", 1, 2L },
                    { 5L, "weight", 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3706), 1L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3706), "Gram", "weight", 1L, "gm", 1, 2L },
                    { 6L, "weight", 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3708), 1L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3708), "milliliter", "amount", 1L, "ml", 1, 3L },
                    { 7L, "weight", 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3710), 1L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3711), "meterpersecond", "speed", 1L, "m/s", 1, 1L },
                    { 8L, "weight", 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3712), 1L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3713), "kmperhour", "speed", 1L, "kmph", 1, 1L }
                });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3586), new Guid("0d3fbc7f-83bc-421f-aea7-713add3b3672") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3590), new Guid("a486d702-142d-4a92-bc37-74fb8cdb7118") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3593), new Guid("9ab70e14-96a9-44e6-be09-77f2e1dbdd81") });

            migrationBuilder.InsertData(
                table: "UnitOfMeasureTranslations",
                columns: new[] { "LanguageId", "UnitOfMeasureId", "CreatedBy", "CreatedDate", "Id", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "ShortText", "State" },
                values: new object[,]
                {
                    { 1L, 4L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3736), 10L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3736), "Kilogram", "weight", "kg", 0 },
                    { 2L, 4L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3739), 11L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3739), "Gram", "weight", "gm", 0 },
                    { 1L, 6L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3743), 12L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3744), "milliliter", "amount", "ml", 0 },
                    { 1L, 7L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3745), 13L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3746), "meterpersecond", "speed", "m/s", 0 },
                    { 2L, 7L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3747), 14L, 1L, new DateTime(2024, 8, 20, 12, 48, 27, 419, DateTimeKind.Utc).AddTicks(3748), "kmperhour", "speed", "kmph", 0 }
                });
        }
    }
}

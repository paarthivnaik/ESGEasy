using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationupdated12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasureTranslations",
                table: "UnitOfMeasureTranslations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasureTranslations",
                table: "UnitOfMeasureTranslations",
                columns: new[] { "Id", "OrganizationId" });

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3900));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 50L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 51L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 52L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 53L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 54L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 55L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 56L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 57L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 58L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 59L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4116), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4127), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4130), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4154), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4157), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4160), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4161) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4163), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4164) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4166), new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4167) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4259), new Guid("59b9e271-84f7-4aa7-95f6-56d5681f8b59") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4264), new Guid("7b2ccab6-2173-4b16-b437-2fe2f3089f63") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 45, 41, 250, DateTimeKind.Utc).AddTicks(4268), new Guid("f9e64930-94ac-48f5-a4ce-b5aa6f1a562c") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasureTranslations",
                table: "UnitOfMeasureTranslations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasureTranslations",
                table: "UnitOfMeasureTranslations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 50L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 51L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 52L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 53L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 54L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 55L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 56L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 57L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 58L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 59L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8463), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8464) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8471), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8474), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8498), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8499) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8501), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8504), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8506), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8509), new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8637), new Guid("38e02f02-c711-401e-94fb-1dc382a8262a") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8642), new Guid("bc701b32-108e-47ba-92d5-5d3304b64741") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 11, 29, 20, 727, DateTimeKind.Utc).AddTicks(8647), new Guid("84dcef68-bca6-468f-bbf8-1dc6d42c4031") });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UnitOfMeasureTranslations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                table: "UnitOfMeasures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 50L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 51L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 52L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 53L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 54L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 55L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 56L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 57L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 58L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 59L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2689), new Guid("a9bd0e0a-ede7-4915-8a07-a45b0f177fa1") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2701), new Guid("29089658-d990-408d-bfe8-eac5ee5f854e") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 10, 10, 0, 39, 763, DateTimeKind.Utc).AddTicks(2705), new Guid("8252cedb-fb3f-4ae8-8c49-06e683ea5386") });

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_LanguageId",
                table: "UnitOfMeasures",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfMeasures_Languages_LanguageId",
                table: "UnitOfMeasures",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfMeasures_Languages_LanguageId",
                table: "UnitOfMeasures");

            migrationBuilder.DropIndex(
                name: "IX_UnitOfMeasures_LanguageId",
                table: "UnitOfMeasures");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UnitOfMeasureTranslations");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UnitOfMeasures");

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 50L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 51L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 52L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 53L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 54L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 55L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 56L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 57L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 58L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 59L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2252), new Guid("266c086a-d0ab-4acf-ae42-09e865641e91") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2256), new Guid("f08496af-6d99-41ac-979a-d667ce8bb802") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 10, 9, 21, 13, 909, DateTimeKind.Utc).AddTicks(2259), new Guid("0b4ed653-c161-4d57-9aa4-b3e2df4f68b2") });
        }
    }
}

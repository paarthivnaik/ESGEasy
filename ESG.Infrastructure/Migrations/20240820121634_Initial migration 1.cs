using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DimensionTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "LanguageId", "LastModifiedBy", "LastModifiedDate", "LongText", "Name", "OrganizationId", "ShortText", "State", "isHierarchical" },
                values: new object[,]
                {
                    { 1L, "esg_topic", 1L, new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1690), 1L, null, null, "Dimension Type 1", "ESG Topic", 1L, "DimensionType topic", 1, true },
                    { 2L, "esg-standard", 1L, new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1693), 1L, null, null, "Dimension Type 2", "ESG Standard", 1L, "dimensiontype standard", 1, true },
                    { 3L, "esg-dq", 1L, new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1695), 1L, null, null, "Dimension Type 3", "ESG Disclosure Requirements", 1L, "dimensiontype disclosure requirement", 1, true }
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "IsoCode", "Name" },
                values: new object[] { "en", "English" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 4L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1609), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 2L, 4L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1611), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1612) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 6L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1614), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 7L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1639), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1640) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 2L, 7L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1642), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1668), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1669) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 2L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1670), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1671) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 2L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1661), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1662) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 2L, 2L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1664), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 3L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1666), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1667) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1548), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1549) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1556), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1557) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1559), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1579), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1582), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1582) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1584), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1584) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1586), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1587) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1589), new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1589) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1530));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1464), new Guid("d14f8c4c-4c0a-4949-8312-ed11c98b7cdb") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1468), new Guid("c011e086-16ab-4df1-a239-6118c9082e48") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 12, 16, 34, 10, DateTimeKind.Utc).AddTicks(1471), new Guid("4ce48af1-c64f-42ec-8705-911a28da4556") });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Dimensions",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DimensionTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "IsoCode", "Name" },
                values: new object[] { "ru", "Russian" });

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 4L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7775), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7775) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 2L, 4L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7778), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7778) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 6L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7780), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 1L, 7L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7782), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureId" },
                keyValues: new object[] { 2L, 7L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7785), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7811), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7812) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 2L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7813), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 2L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7804), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 2L, 2L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7807), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypeTranslations",
                keyColumns: new[] { "LanguageId", "UnitOfMeasureTypeId" },
                keyValues: new object[] { 1L, 3L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7809), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7809) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7662), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7664) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7670), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7671) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7724), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7744), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7745) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7747), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7748) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7749), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7752), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7752) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7754), new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7574), new Guid("e6691f62-54d6-4b62-a465-7dd858878a2a") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7578), new Guid("a9b5fd74-5cd3-4e5c-b138-ecacdad28fb4") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 20, 11, 3, 3, 221, DateTimeKind.Utc).AddTicks(7581), new Guid("6a358f4e-e162-490d-9481-778150ffb519") });
        }
    }
}

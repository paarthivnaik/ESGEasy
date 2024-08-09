using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ESG.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationupdated1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UnitOfMeasureTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UnitOfMeasures",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DimensionTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Dimensions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DataPointValues",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DataPointTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DatapointModel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UnitOfMeasureTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UnitOfMeasures",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DimensionTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Dimensions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DataPointValues",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DataPointTypes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DatapointModel",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "DataPointTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(705));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 9L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "DataPointValues",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 10L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 50L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 51L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 52L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 53L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 54L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 55L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 56L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 57L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 58L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "DimensionTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 59L, 1L },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1081));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "OrganizationUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 1L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(852), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 2L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(905), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(906) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasureTypes",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 3L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(908), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(909) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 4L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(932), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(933) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 5L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(936), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(937) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 6L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(939), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 7L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(943), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumns: new[] { "Id", "OrganizationId" },
                keyValues: new object[] { 8L, 1L },
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(946), new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(946) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1037), new Guid("1900fd8f-8020-4720-93bc-7a1018193880") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1055), new Guid("4d0c0178-8d72-41b8-abf1-d3a993894fa0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedDate", "SecurityStamp" },
                values: new object[] { new DateTime(2024, 8, 9, 10, 48, 50, 762, DateTimeKind.Utc).AddTicks(1059), new Guid("ab3f72cd-f67a-4a1e-a98a-7e364a96fef4") });
        }
    }
}

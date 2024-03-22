using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class SeededMembershiptypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MmebershipTypes",
                table: "MmebershipTypes");

            migrationBuilder.RenameTable(
                name: "MmebershipTypes",
                newName: "MembershipTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "Id", "DiscountRate", "DurationInMonths", "SignUpFee" },
                values: new object[,]
                {
                    { 4, 0, 0, 0 },
                    { 5, 10, 1, 30 },
                    { 6, 15, 3, 90 },
                    { 7, 20, 12, 300 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes");

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.RenameTable(
                name: "MembershipTypes",
                newName: "MmebershipTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MmebershipTypes",
                table: "MmebershipTypes",
                column: "Id");
        }
    }
}

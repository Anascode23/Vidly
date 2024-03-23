using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class AddedNamePropertyToMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MembershipTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Pay as You Go");

            migrationBuilder.UpdateData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Monthly");

            migrationBuilder.UpdateData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Quarterly");

            migrationBuilder.UpdateData(
                table: "MembershipTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Annual");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MembershipTypes");
        }
    }
}

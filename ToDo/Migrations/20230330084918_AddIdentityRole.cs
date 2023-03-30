using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18cb5f73-1d02-4ebd-b881-e218d8bc9f9e", "89cc6255-45f0-431d-b71b-1bec5c4378ab", "administrator", "ADMINISTRATOR" },
                    { "85102140-8b20-4787-a2ac-f86918c23431", "e886d42c-e67d-4c86-b49d-422823e0fea7", "guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18cb5f73-1d02-4ebd-b881-e218d8bc9f9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85102140-8b20-4787-a2ac-f86918c23431");
        }
    }
}

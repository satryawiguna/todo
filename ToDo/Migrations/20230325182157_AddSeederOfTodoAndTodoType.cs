using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.Migrations
{
    /// <inheritdoc />
    public partial class AddSeederOfTodoAndTodoType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "School activity" },
                    { 2, "Work activity" },
                    { 3, "Home activity" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Description", "Title", "TodoTypeId" },
                values: new object[,]
                {
                    { 1, "Description of activity one", "Activity one", 1 },
                    { 2, "Description of activity two", "Activity two", 1 },
                    { 3, "Description of activity three", "Activity three", 2 },
                    { 4, "Description of activity four", "Activity four", 2 },
                    { 5, "Description of activity five", "Activity five", 3 },
                    { 6, "Description of activity six", "Activity six", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TodoTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

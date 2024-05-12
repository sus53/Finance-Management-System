using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11bc42df-40ef-43aa-883e-e9ee2b4dc6a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fb1d59c-44d7-4248-baba-cbab3d18729b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25d7084a-cb3d-4b9e-9819-cb907e6b52e6", null, "User", "USER" },
                    { "832b16cf-4dc9-41f6-9bf6-93085b3c4d77", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25d7084a-cb3d-4b9e-9819-cb907e6b52e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "832b16cf-4dc9-41f6-9bf6-93085b3c4d77");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11bc42df-40ef-43aa-883e-e9ee2b4dc6a0", null, "User", "USER" },
                    { "7fb1d59c-44d7-4248-baba-cbab3d18729b", null, "Admin", "ADMIN" }
                });
        }
    }
}

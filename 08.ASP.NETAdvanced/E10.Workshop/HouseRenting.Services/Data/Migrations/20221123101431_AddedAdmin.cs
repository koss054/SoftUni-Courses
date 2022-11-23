using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRenting.Services.Data.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3503ed12-9a4b-45eb-b9d7-7d24b1908b21", "AQAAAAEAACcQAAAAEL33qUS8WsIenKg9wpRUcpbKgfWOYNaCMVANQMRm6kPbi6SjELaMSUDETZImMv3w1w==", "7bc67c64-9f66-4c04-90bf-bb6eff4035d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83856395-8773-4361-9ca5-92987bac6240", "AQAAAAEAACcQAAAAENC1wuMqMg6KMiJNVxnp4YByBg1gwIxqKJ6SqO+fCDaZ+ws5afhdagcxyxvj4V5BkA==", "c11d2585-e3ce-402d-9c4a-8642e919c244" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "ec70b14c-31c2-467b-87da-6a1eb60bb76b", "admin@mail.bg", false, "Great", "Admin", false, null, "admin@mail.bg", "admin@mail.bg", "AQAAAAEAACcQAAAAEKHZTznn72/z4SjrlJIZn3G3UWSPdRXZ4r/UdSLEt927hB+C0FVgE+ggYUEbiskUrw==", null, false, "44f7fd55-a00f-46ff-be5c-b46abd40a055", false, "admin@mail.bg" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 999, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "385b021f-ede0-47e0-b14d-6f71b070a04e", "AQAAAAEAACcQAAAAEM2MyHrqqdvBnSlmEyouxT5XfSlZlVrtmB7+kDqTOopMdeJtdHrfqc+FSaSntu/pkA==", "7b0c7a20-1da7-4355-8762-4601e8f2e5eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2897763-f05e-4189-9a1b-69a000ee3765", "AQAAAAEAACcQAAAAECxIaakkar/9CENCo4eZ8GtiF5RI55XypecoOcBxQ1FF2O4WKosJzILmewBRkS+KPQ==", "0f600827-2184-4edd-ad95-6a7c7c63b75a" });
        }
    }
}

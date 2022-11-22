using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRenting.Data.Migrations
{
    public partial class AddedUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "385b021f-ede0-47e0-b14d-6f71b070a04e", "First Neim", "POslednoto!1", "AQAAAAEAACcQAAAAEM2MyHrqqdvBnSlmEyouxT5XfSlZlVrtmB7+kDqTOopMdeJtdHrfqc+FSaSntu/pkA==", "7b0c7a20-1da7-4355-8762-4601e8f2e5eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2897763-f05e-4189-9a1b-69a000ee3765", "Ivanskito", "Ime", "AQAAAAEAACcQAAAAECxIaakkar/9CENCo4eZ8GtiF5RI55XypecoOcBxQ1FF2O4WKosJzILmewBRkS+KPQ==", "0f600827-2184-4edd-ad95-6a7c7c63b75a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcd5a187-3821-4cde-bcff-bd593716fe59", "AQAAAAEAACcQAAAAEEOValLF5JRh13AoU1FKvKjkTVBMLl4KZ3LHaoH7z+LsXHigudcz6CfwzQSQD5Uo5A==", "fe9dc357-381e-492e-8622-4261458f76b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b5749be-4a84-46c1-bb48-cd3d3546f993", "AQAAAAEAACcQAAAAEP3W1CT9WNkiPB9lV/gx/JnE9qeCK/wx1aaMnMep8iIga1J6UuydrmQYMZMzxS079Q==", "62134e12-1d5c-4289-b169-7ea5656d3c98" });
        }
    }
}

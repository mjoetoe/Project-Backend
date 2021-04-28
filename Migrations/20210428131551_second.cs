using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Backend.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "ID",
                keyValue: new Guid("071e2e1a-f7f0-47dc-a653-3fe758724554"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "ID",
                keyValue: new Guid("4cb2fbc9-7a84-43ad-af49-a15dae7b4506"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: new Guid("3eae78a9-8d42-4d18-8074-46df1531c9c5"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: new Guid("f11bf32c-e978-4c39-a310-5d780505e791"));

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Directors",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "ID", "Age", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("f7ca1a6b-4cbd-483f-a030-09466dd69c8a"), 25, "Spielberg", "Steven" },
                    { new Guid("0b66e075-a4dd-49bc-b56f-a99578dbb8af"), 50, "Nolan", "Christopher" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "DirectorId", "Genre", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("68cb3319-3ce7-4c18-a3e2-b059a349e63c"), new Guid("00000000-0000-0000-0000-000000000000"), "Romance", "Titanic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2a54533d-1710-4546-932a-2133dad10f43"), new Guid("00000000-0000-0000-0000-000000000000"), "Sci-Fi", "The Martian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "ID",
                keyValue: new Guid("0b66e075-a4dd-49bc-b56f-a99578dbb8af"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "ID",
                keyValue: new Guid("f7ca1a6b-4cbd-483f-a030-09466dd69c8a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: new Guid("2a54533d-1710-4546-932a-2133dad10f43"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: new Guid("68cb3319-3ce7-4c18-a3e2-b059a349e63c"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Age",
                table: "Directors",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "ID", "Age", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("4cb2fbc9-7a84-43ad-af49-a15dae7b4506"), 25m, "Spielberg", "Steven" },
                    { new Guid("071e2e1a-f7f0-47dc-a653-3fe758724554"), 50m, "Nolan", "Christopher" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "DirectorId", "Genre", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("3eae78a9-8d42-4d18-8074-46df1531c9c5"), new Guid("00000000-0000-0000-0000-000000000000"), "Romance", "Titanic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f11bf32c-e978-4c39-a310-5d780505e791"), new Guid("00000000-0000-0000-0000-000000000000"), "Sci-Fi", "The Martian", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}

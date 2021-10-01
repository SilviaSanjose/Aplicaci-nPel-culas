using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Silvia" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Antonio" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "Id", "Age", "Character", "MovieId", "Name" },
                values: new object[] { 1, null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 1, "Silvia" });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "Id", "Age", "Character", "MovieId", "Name" },
                values: new object[] { 2, null, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 1, "Antonio" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

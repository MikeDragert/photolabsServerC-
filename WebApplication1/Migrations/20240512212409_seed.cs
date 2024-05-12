using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserAccounts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Topics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Photos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "City", "Country", "FullUrl", "RegularUrl", "TopicId", "UserAccountId" },
                values: new object[,]
                {
                    { 1, "Montreal", "Canada", "Image-1-Full.jpeg", "Image-1-Regular.jpeg", null, null },
                    { 11, "Toronto", "Canada", "people-1-full.jpg", "people-1-regular.jpg", null, null },
                    { 12, "Vancouver", "Canada", "people-2-full.jpg", "people-2-regular.jpg", null, null },
                    { 13, "Calgary", "Canada", "people-3-full.jpg", "people-3-regular.jpg", null, null },
                    { 14, "Victoria", "Canada", "people-4-full.jpg", "people-4-regular.jpg", null, null },
                    { 15, "Ottawa", "Canada", "people-5-full.jpg", "people-5-regular.jpg", null, null },
                    { 16, "Montreal", "Canada", "people-6-full.jpg", "people-6-regular.jpg", null, null },
                    { 17, "Toronto", "Canada", "people-7-full.jpg", "people-7-regular.jpg", null, null },
                    { 18, "Vancouver", "Canada", "people-8-full.jpg", "people-8-regular.jpg", null, null },
                    { 19, "Calgary", "Canada", "people-9-full.jpg", "people-9-regular.jpg", null, null },
                    { 21, "Toronto", "Canada", "nature-1-full.jpg", "nature-1-regular.jpg", null, null },
                    { 22, "Vancouver", "Canada", "nature-2-full.jpg", "nature-2-regular.jpg", null, null },
                    { 23, "Calgary", "Canada", "nature-3-full.jpg", "nature-3-regular.jpg", null, null },
                    { 24, "Victoria", "Canada", "nature-4-full.jpg", "nature-4-regular.jpg", null, null },
                    { 25, "Ottawa", "Canada", "nature-5-full.jpg", "nature-5-regular.jpg", null, null },
                    { 26, "Montreal", "Canada", "nature-6-full.jpg", "nature-6-regular.jpg", null, null },
                    { 27, "Toronto", "Canada", "nature-7-full.jpg", "nature-7-regular.jpg", null, null },
                    { 28, "Vancouver", "Canada", "nature-8-full.jpg", "nature-8-regular.jpg", null, null },
                    { 29, "Calgary", "Canada", "nature-9-full.jpg", "nature-9-regular.jpg", null, null },
                    { 31, "Toronto", "Canada", "travel-1-full.jpg", "travel-1-regular.jpg", null, null },
                    { 32, "Vancouver", "Canada", "travel-2-full.jpg", "travel-2-regular.jpg", null, null },
                    { 33, "Calgary", "Canada", "travel-3-full.jpg", "travel-3-regular.jpg", null, null },
                    { 34, "Victoria", "Canada", "travel-4-full.jpg", "travel-4-regular.jpg", null, null },
                    { 35, "Ottawa", "Canada", "travel-5-full.jpg", "travel-5-regular.jpg", null, null },
                    { 36, "Montreal", "Canada", "travel-6-full.jpg", "travel-6-regular.jpg", null, null },
                    { 37, "Toronto", "Canada", "travel-7-full.jpg", "travel-7-regular.jpg", null, null },
                    { 38, "Vancouver", "Canada", "travel-8-full.jpg", "travel-8-regular.jpg", null, null },
                    { 41, "Toronto", "Canada", "animals-1-full.jpg", "animals-1-regular.jpg", null, null },
                    { 42, "Vancouver", "Canada", "animals-2-full.jpg", "animals-2-regular.jpg", null, null },
                    { 43, "Calgary", "Canada", "animals-3-full.jpg", "animals-3-regular.jpg", null, null },
                    { 44, "Victoria", "Canada", "animals-4-full.jpg", "animals-4-regular.jpg", null, null },
                    { 45, "Ottawa", "Canada", "animals-5-full.jpg", "animals-5-regular.jpg", null, null },
                    { 46, "Montreal", "Canada", "animals-6-full.jpg", "animals-6-regular.jpg", null, null },
                    { 47, "Toronto", "Canada", "animals-7-full.jpg", "animals-7-regular.jpg", null, null },
                    { 48, "Vancouver", "Canada", "animals-8-full.jpg", "animals-8-regular.jpg", null, null },
                    { 49, "Calgary", "Canada", "animals-9-full.jpg", "animals-9-regular.jpg", null, null },
                    { 51, "Toronto", "Canada", "fashion-1-full.jpg", "fashion-1-regular.jpg", null, null },
                    { 52, "Vancouver", "Canada", "fashion-2-full.jpg", "fashion-2-regular.jpg", null, null },
                    { 53, "Calgary", "Canada", "fashion-3-full.jpg", "fashion-3-regular.jpg", null, null },
                    { 54, "Victoria", "Canada", "fashion-4-full.jpg", "fashion-4-regular.jpg", null, null },
                    { 55, "Ottawa", "Canada", "fashion-5-full.jpg", "fashion-5-regular.jpg", null, null },
                    { 56, "Montreal", "Canada", "fashion-6-full.jpg", "fashion-6-regular.jpg", null, null },
                    { 57, "Toronto", "Canada", "fashion-7-full.jpg", "fashion-7-regular.jpg", null, null },
                    { 58, "Vancouver", "Canada", "fashion-8-full.jpg", "fashion-8-regular.jpg", null, null },
                    { 59, "Calgary", "Canada", "fashion-9-full.jpg", "fashion-9-regular.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "people", "People" },
                    { 2, "nature", "Nature" },
                    { 3, "travel", "Travel" },
                    { 4, "animals", "Animals" },
                    { 5, "fashion", "Fashion" }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "FullName", "ProfileUrl", "Username" },
                values: new object[,]
                {
                    { 1, "John Doe", "profile-1.jpg", "jdoe" },
                    { 2, "Alice Wonderland", "profile-2.jpg", "awond" },
                    { 3, "Sita Dennis", "profile-3.jpg", "sitad" },
                    { 4, "Sasha Mateo", "profile-4.jpg", "matte" },
                    { 5, "Anita Austi", "profile-5.jpg", "anita" },
                    { 6, "Lukas Souza", "profile-6.jpg", "lsouza" },
                    { 7, "Jose Alejandro", "profile-7.jpg", "josea" },
                    { 8, "Dwayne Jacob", "profile-8.jpg", "jdwayne" },
                    { 9, "Allison Saeng", "profile-9.jpg", "saeng" },
                    { 10, "Adrea Santos", "profile-10.jpg", "santa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserAccounts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Topics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Photos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}

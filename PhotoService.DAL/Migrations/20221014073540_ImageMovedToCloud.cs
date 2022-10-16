using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhotoService.DAL.Migrations
{
    public partial class ImageMovedToCloud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownloadsCount",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageBase64",
                table: "Images",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Collections",
                newName: "CollectionAvatarUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Images",
                newName: "ImageBase64");

            migrationBuilder.RenameColumn(
                name: "CollectionAvatarUrl",
                table: "Collections",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<int>(
                name: "DownloadsCount",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

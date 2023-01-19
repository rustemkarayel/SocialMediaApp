using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedadminimgurlcloumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedCollections_Collections_CollectionId",
                table: "SavedCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedCollections_Saveds_SavedId",
                table: "SavedCollections");

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "Admins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedCollections_Collections_CollectionId",
                table: "SavedCollections",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedCollections_Saveds_SavedId",
                table: "SavedCollections",
                column: "SavedId",
                principalTable: "Saveds",
                principalColumn: "SavedId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedCollections_Collections_CollectionId",
                table: "SavedCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedCollections_Saveds_SavedId",
                table: "SavedCollections");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "Admins");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedCollections_Collections_CollectionId",
                table: "SavedCollections",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedCollections_Saveds_SavedId",
                table: "SavedCollections",
                column: "SavedId",
                principalTable: "Saveds",
                principalColumn: "SavedId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorksShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class newName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_participants_workShops_WorkShopId",
                table: "participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workShops",
                table: "workShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_participants",
                table: "participants");

            migrationBuilder.RenameTable(
                name: "workShops",
                newName: "WorkShops");

            migrationBuilder.RenameTable(
                name: "participants",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_participants_WorkShopId",
                table: "Participants",
                newName: "IX_Participants_WorkShopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShops",
                table: "WorkShops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_WorkShops_WorkShopId",
                table: "Participants",
                column: "WorkShopId",
                principalTable: "WorkShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_WorkShops_WorkShopId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShops",
                table: "WorkShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "WorkShops",
                newName: "workShops");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "participants");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_WorkShopId",
                table: "participants",
                newName: "IX_participants_WorkShopId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workShops",
                table: "workShops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_participants",
                table: "participants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_participants_workShops_WorkShopId",
                table: "participants",
                column: "WorkShopId",
                principalTable: "workShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

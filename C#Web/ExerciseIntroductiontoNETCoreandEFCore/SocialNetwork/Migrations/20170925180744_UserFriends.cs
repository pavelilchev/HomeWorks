using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Migrations
{
    public partial class UserFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFriend",
                columns: table => new
                {
                    UserFirstId = table.Column<int>(type: "int", nullable: false),
                    UserSecondId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriend", x => new { x.UserFirstId, x.UserSecondId });
                    table.ForeignKey(
                        name: "FK_UserFriend_Users_UserFirstId",
                        column: x => x.UserFirstId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriend_Users_UserSecondId",
                        column: x => x.UserSecondId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_UserSecondId",
                table: "UserFriend",
                column: "UserSecondId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFriend");
        }
    }
}

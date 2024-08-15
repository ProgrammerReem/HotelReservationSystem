using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_room_hotels_HotelId",
                table: "room");

            migrationBuilder.AddColumn<int>(
                name: "hotelId",
                table: "testimonials",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "roomId",
                table: "testimonials",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "testimonials",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "testimonials",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "room",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userTransactions_RoomId",
                table: "userTransactions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_userTransactions_UserID",
                table: "userTransactions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_hotelId",
                table: "testimonials",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_roomId",
                table: "testimonials",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_userId",
                table: "testimonials",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_residents_RoomId",
                table: "residents",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_residents_UserID",
                table: "residents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_RoomId",
                table: "reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_UserID",
                table: "reservations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_bankAccounts_UserId",
                table: "bankAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bankAccounts_users_UserId",
                table: "bankAccounts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_room_RoomId",
                table: "reservations",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_users_UserID",
                table: "reservations",
                column: "UserID",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_residents_room_RoomId",
                table: "residents",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_residents_users_UserID",
                table: "residents",
                column: "UserID",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_room_hotels_HotelId",
                table: "room",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_testimonials_hotels_hotelId",
                table: "testimonials",
                column: "hotelId",
                principalTable: "hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_testimonials_room_roomId",
                table: "testimonials",
                column: "roomId",
                principalTable: "room",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_testimonials_users_userId",
                table: "testimonials",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userTransactions_room_RoomId",
                table: "userTransactions",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userTransactions_users_UserID",
                table: "userTransactions",
                column: "UserID",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bankAccounts_users_UserId",
                table: "bankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_room_RoomId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_users_UserID",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_residents_room_RoomId",
                table: "residents");

            migrationBuilder.DropForeignKey(
                name: "FK_residents_users_UserID",
                table: "residents");

            migrationBuilder.DropForeignKey(
                name: "FK_room_hotels_HotelId",
                table: "room");

            migrationBuilder.DropForeignKey(
                name: "FK_testimonials_hotels_hotelId",
                table: "testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_testimonials_room_roomId",
                table: "testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_testimonials_users_userId",
                table: "testimonials");

            migrationBuilder.DropForeignKey(
                name: "FK_userTransactions_room_RoomId",
                table: "userTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_userTransactions_users_UserID",
                table: "userTransactions");

            migrationBuilder.DropIndex(
                name: "IX_userTransactions_RoomId",
                table: "userTransactions");

            migrationBuilder.DropIndex(
                name: "IX_userTransactions_UserID",
                table: "userTransactions");

            migrationBuilder.DropIndex(
                name: "IX_testimonials_hotelId",
                table: "testimonials");

            migrationBuilder.DropIndex(
                name: "IX_testimonials_roomId",
                table: "testimonials");

            migrationBuilder.DropIndex(
                name: "IX_testimonials_userId",
                table: "testimonials");

            migrationBuilder.DropIndex(
                name: "IX_residents_RoomId",
                table: "residents");

            migrationBuilder.DropIndex(
                name: "IX_residents_UserID",
                table: "residents");

            migrationBuilder.DropIndex(
                name: "IX_reservations_RoomId",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_UserID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_bankAccounts_UserId",
                table: "bankAccounts");

            migrationBuilder.DropColumn(
                name: "hotelId",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "roomId",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "text",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "testimonials");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "room",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_room_hotels_HotelId",
                table: "room",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "Id");
        }
    }
}

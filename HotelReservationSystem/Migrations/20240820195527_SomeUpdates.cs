using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class SomeUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_testimonials_hotels_hotelId",
                table: "testimonials");

            migrationBuilder.RenameColumn(
                name: "hotelId",
                table: "testimonials",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_testimonials_hotelId",
                table: "testimonials",
                newName: "IX_testimonials_HotelId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "userTransactions",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<int>(
                name: "CardCvv",
                table: "users",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "users",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "users",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "testimonials",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "testimonials",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "testimonials",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceByNight",
                table: "room",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "room",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "reservations",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "hotels",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "bankAccounts",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.CreateTable(
                name: "contactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Text = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactUs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_testimonials_hotels_HotelId",
                table: "testimonials",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_testimonials_hotels_HotelId",
                table: "testimonials");

            migrationBuilder.DropTable(
                name: "contactUs");

            migrationBuilder.DropColumn(
                name: "CardCvv",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "status",
                table: "testimonials");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "room");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "hotels");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "testimonials",
                newName: "hotelId");

            migrationBuilder.RenameIndex(
                name: "IX_testimonials_HotelId",
                table: "testimonials",
                newName: "IX_testimonials_hotelId");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "userTransactions",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "hotelId",
                table: "testimonials",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriceByNight",
                table: "room",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "reservations",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "bankAccounts",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddForeignKey(
                name: "FK_testimonials_hotels_hotelId",
                table: "testimonials",
                column: "hotelId",
                principalTable: "hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

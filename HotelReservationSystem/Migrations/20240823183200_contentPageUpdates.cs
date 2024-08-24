using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class contentPageUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "pageContent",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ConactUsPath",
                table: "pageContent",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "ConactUs",
                table: "pageContent",
                newName: "AboutUsTitle");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "userTransactions",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "balance",
                table: "users",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceByNight",
                table: "room",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsImagePath",
                table: "pageContent",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "bankAccounts",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUsImagePath",
                table: "pageContent");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "pageContent",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "pageContent",
                newName: "ConactUsPath");

            migrationBuilder.RenameColumn(
                name: "AboutUsTitle",
                table: "pageContent",
                newName: "ConactUs");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "userTransactions",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "balance",
                table: "users",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceByNight",
                table: "room",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "bankAccounts",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}

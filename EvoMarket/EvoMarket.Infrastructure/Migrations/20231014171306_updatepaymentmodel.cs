using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatepaymentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                schema: "payment",
                table: "transactions",
                newName: "amounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amounts",
                schema: "payment",
                table: "transactions",
                newName: "amount");
        }
    }
}

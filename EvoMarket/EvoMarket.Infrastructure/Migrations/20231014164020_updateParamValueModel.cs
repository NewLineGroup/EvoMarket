using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateParamValueModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParamValues",
                schema: "shop",
                table: "filter_params");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "ParamValues",
                schema: "shop",
                table: "filter_params",
                type: "text[]",
                nullable: false);
        }
    }
}

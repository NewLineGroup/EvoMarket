using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shop");

            migrationBuilder.CreateTable(
                name: "carts",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    total_emount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_count = table.Column<int>(type: "integer", nullable: false),
                    client_id = table.Column<long>(type: "bigint", nullable: false),
                    transaction_id = table.Column<long>(type: "bigint", nullable: false),
                    closed = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    profile_image = table.Column<string>(type: "text", nullable: true),
                    rate = table.Column<double>(type: "double precision", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "filter_params",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filter_params", x => x.id);
                    table.ForeignKey(
                        name: "FK_filter_params_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "shop",
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<float>(type: "real", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    thumb_image_url = table.Column<string>(type: "text", nullable: false),
                    rate = table.Column<float>(type: "real", nullable: false),
                    discount_price = table.Column<decimal>(type: "numeric", nullable: true),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    min_age = table.Column<int>(type: "integer", nullable: false),
                    CategoryId1 = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalSchema: "shop",
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "filter_param_values",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    filter_param_id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filter_param_values", x => x.id);
                    table.ForeignKey(
                        name: "FK_filter_param_values_filter_params_filter_param_id",
                        column: x => x.filter_param_id,
                        principalSchema: "shop",
                        principalTable: "filter_params",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_filter_param_values_filter_param_id",
                schema: "shop",
                table: "filter_param_values",
                column: "filter_param_id");

            migrationBuilder.CreateIndex(
                name: "IX_filter_params_CategoryId",
                schema: "shop",
                table: "filter_params",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId1",
                schema: "shop",
                table: "products",
                column: "CategoryId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "filter_param_values",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "products",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "filter_params",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "shop");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EvoMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shop");

            migrationBuilder.EnsureSchema(
                name: "payment");

            migrationBuilder.CreateTable(
                name: "client_notifications",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<long>(type: "bigint", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    received = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_notifications", x => x.id);
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
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ip = table.Column<string>(type: "text", nullable: false),
                    device_name = table.Column<string>(type: "text", nullable: false),
                    last_login_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    device_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_id", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash_string = table.Column<string>(type: "text", nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    otp = table.Column<string>(type: "text", nullable: true),
                    expire_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "client_account",
                schema: "payment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    is_freeze = table.Column<bool>(type: "boolean", nullable: false),
                    client_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_account", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_account_clients_client_id",
                        column: x => x.client_id,
                        principalSchema: "shop",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                schema: "payment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    success = table.Column<bool>(type: "boolean", nullable: false),
                    account_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_client_account_account_id",
                        column: x => x.account_id,
                        principalSchema: "payment",
                        principalTable: "client_account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    total_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_count = table.Column<int>(type: "integer", nullable: false),
                    client_id = table.Column<long>(type: "bigint", nullable: false),
                    transaction_id = table.Column<long>(type: "bigint", nullable: false),
                    closed = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_carts_clients_client_id",
                        column: x => x.client_id,
                        principalSchema: "shop",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carts_transactions_transaction_id",
                        column: x => x.transaction_id,
                        principalSchema: "payment",
                        principalTable: "transactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cart_items",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    cart_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_cart_items_carts_cart_id",
                        column: x => x.cart_id,
                        principalSchema: "shop",
                        principalTable: "carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    FilterParamValueId = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category_filters",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    filter_param_id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_filters", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_filters_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "shop",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "filter_params",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    param_name = table.Column<string>(type: "text", nullable: false),
                    ParamValues = table.Column<List<string>>(type: "text[]", nullable: false),
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
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    min_age = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "shop",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "filter_param_values",
                schema: "shop",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    filter_param_id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    CategoryFilterId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filter_param_values", x => x.id);
                    table.ForeignKey(
                        name: "FK_filter_param_values_category_filters_CategoryFilterId",
                        column: x => x.CategoryFilterId,
                        principalSchema: "shop",
                        principalTable: "category_filters",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_filter_param_values_filter_params_filter_param_id",
                        column: x => x.filter_param_id,
                        principalSchema: "shop",
                        principalTable: "filter_params",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_filter_param_values_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "shop",
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_cart_id",
                schema: "shop",
                table: "cart_items",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_items_product_id",
                schema: "shop",
                table: "cart_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_carts_client_id",
                schema: "shop",
                table: "carts",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_carts_transaction_id",
                schema: "shop",
                table: "carts",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_FilterParamValueId",
                schema: "shop",
                table: "categories",
                column: "FilterParamValueId");

            migrationBuilder.CreateIndex(
                name: "IX_category_filters_category_id",
                schema: "shop",
                table: "category_filters",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_account_client_id",
                schema: "payment",
                table: "client_account",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_notifications_received",
                table: "client_notifications",
                column: "received");

            migrationBuilder.CreateIndex(
                name: "IX_devices_device_id",
                table: "devices",
                column: "device_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_filter_param_values_CategoryFilterId",
                schema: "shop",
                table: "filter_param_values",
                column: "CategoryFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_filter_param_values_filter_param_id",
                schema: "shop",
                table: "filter_param_values",
                column: "filter_param_id");

            migrationBuilder.CreateIndex(
                name: "IX_filter_param_values_ProductId",
                schema: "shop",
                table: "filter_param_values",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_filter_params_CategoryId",
                schema: "shop",
                table: "filter_params",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "shop",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_account_id",
                schema: "payment",
                table: "transactions",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_user_id",
                table: "users",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_items_products_product_id",
                schema: "shop",
                table: "cart_items",
                column: "product_id",
                principalSchema: "shop",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categories_filter_param_values_FilterParamValueId",
                schema: "shop",
                table: "categories",
                column: "FilterParamValueId",
                principalSchema: "shop",
                principalTable: "filter_param_values",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_filter_param_values_products_ProductId",
                schema: "shop",
                table: "filter_param_values");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_filter_param_values_FilterParamValueId",
                schema: "shop",
                table: "categories");

            migrationBuilder.DropTable(
                name: "cart_items",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "client_notifications");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "carts",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "transactions",
                schema: "payment");

            migrationBuilder.DropTable(
                name: "client_account",
                schema: "payment");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "products",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "filter_param_values",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "category_filters",
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

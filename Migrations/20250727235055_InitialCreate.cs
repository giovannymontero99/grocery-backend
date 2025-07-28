using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroceryBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "products",
                schema: "public",
                columns: table => new
                {
                    product_product = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "text", nullable: false),
                    product_description = table.Column<string>(type: "text", nullable: true),
                    product_price = table.Column<double>(type: "double precision", nullable: false),
                    product_category = table.Column<string>(type: "text", nullable: false),
                    product_created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    product_is_active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_product);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    user_user = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_username = table.Column<string>(type: "text", nullable: false),
                    user_email = table.Column<string>(type: "text", nullable: true),
                    user_phone = table.Column<string>(type: "text", nullable: true),
                    user_password = table.Column<string>(type: "text", nullable: false),
                    user_fullname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_user);
                });

            migrationBuilder.CreateTable(
                name: "user_products",
                schema: "public",
                columns: table => new
                {
                    user_product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_user = table.Column<int>(type: "integer", nullable: false),
                    product_product = table.Column<int>(type: "integer", nullable: false),
                    user_product_quantity = table.Column<int>(type: "integer", nullable: false),
                    user_product_added_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    user_product_is_saved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_products", x => x.user_product_id);
                    table.ForeignKey(
                        name: "FK_user_products_products_product_product",
                        column: x => x.product_product,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_product",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_products_user_user_user",
                        column: x => x.user_user,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "user_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_products_product_product",
                schema: "public",
                table: "user_products",
                column: "product_product");

            migrationBuilder.CreateIndex(
                name: "IX_user_products_user_user",
                schema: "public",
                table: "user_products",
                column: "user_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");
        }
    }
}

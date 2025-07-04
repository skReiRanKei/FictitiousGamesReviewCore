using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FictitiousGamesReviewCore.Migrations
{
    /// <inheritdoc />
    public partial class AddAverageRatingToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }
    }
}

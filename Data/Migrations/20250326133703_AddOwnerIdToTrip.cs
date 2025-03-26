using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripOrganization.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerIdToTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Trip",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Trip");
        }
    }
}

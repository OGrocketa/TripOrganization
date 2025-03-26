using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripOrganization.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddJoined : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Joined",
                table: "Trip",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Joined",
                table: "Trip");
        }
    }
}

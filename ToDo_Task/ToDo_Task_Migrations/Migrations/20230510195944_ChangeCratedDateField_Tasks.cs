using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo_Task_Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCratedDateField_Tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Tasks",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Tasks",
                newName: "Created");
        }
    }
}

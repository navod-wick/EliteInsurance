using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EliteInsurance.Data.Migrations
{
    /// <inheritdoc />
    public partial class TableRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Companies_CompanyId",
                table: "Claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimTypes",
                table: "ClaimTypes");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "ClaimTypes",
                newName: "ClaimType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimType",
                table: "ClaimType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_ClaimType_ClaimTypeId",
                table: "Claims",
                column: "ClaimTypeId",
                principalTable: "ClaimType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Company_CompanyId",
                table: "Claims",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Claims_ClaimType_ClaimTypeId",
                table: "Claims");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Company_CompanyId",
                table: "Claims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClaimType",
                table: "ClaimType");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "ClaimType",
                newName: "ClaimTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClaimTypes",
                table: "ClaimTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_ClaimTypes_ClaimTypeId",
                table: "Claims",
                column: "ClaimTypeId",
                principalTable: "ClaimTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Companies_CompanyId",
                table: "Claims",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

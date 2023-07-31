using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionPos.Migrations
{
    /// <inheritdoc />
    public partial class MakeColumnsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "tbSalesInvoice",
            nullable: true, // or false depending on your requirements
            oldNullable: false); // old value of the nullable parameter

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "tbSalesInvoice",
                nullable: true, // or false depending on your requirements
                oldNullable: false); // old value of the nullable parameter

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "tbSalesInvoiceItems",
                nullable: true, // or false depending on your requirements
                oldNullable: false); // old value of the nullable parameter
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

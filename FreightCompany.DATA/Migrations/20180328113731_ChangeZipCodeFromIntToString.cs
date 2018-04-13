using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreightCompany.DATA.Migrations
{
    public partial class ChangeZipCodeFromIntToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Adresses",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Adresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

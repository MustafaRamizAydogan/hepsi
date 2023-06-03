using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarkodWeb.Data.Migrations
{
    public partial class repair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_LowerGroups_LowerGroupId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_MainGroups_MainGroupId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Shops_ShopId",
                table: "Stocks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MainGroupId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LowerGroupId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Adet",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fiyat",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Isim",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Islem",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Masraf",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Repairs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tel",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UrunTuru",
                table: "Repairs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bed9d96-a7dd-4ac6-9aa1-5a62aa289b16"),
                column: "ConcurrencyStamp",
                value: "e33f953f-810c-4c47-98c1-6afe3252002b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbefda7b-7761-42c4-aa47-40c7ed3d04a1"),
                column: "ConcurrencyStamp",
                value: "03177f72-1569-450d-bc19-2f9052e34cf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2c488b7-f933-45a1-b8c3-55ae4067879d"),
                column: "ConcurrencyStamp",
                value: "06a13dfa-6b73-4031-a13b-2cb1dd6b958c");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ShopId",
                table: "Repairs",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_LowerGroups_LowerGroupId",
                table: "Stocks",
                column: "LowerGroupId",
                principalTable: "LowerGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_MainGroups_MainGroupId",
                table: "Stocks",
                column: "MainGroupId",
                principalTable: "MainGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Shops_ShopId",
                table: "Stocks",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Shops_ShopId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_LowerGroups_LowerGroupId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_MainGroups_MainGroupId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Shops_ShopId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_ShopId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Adet",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Isim",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Islem",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Masraf",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "UrunTuru",
                table: "Repairs");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShopId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MainGroupId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LowerGroupId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bed9d96-a7dd-4ac6-9aa1-5a62aa289b16"),
                column: "ConcurrencyStamp",
                value: "9709111f-289f-4269-8972-a9851c27a8e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbefda7b-7761-42c4-aa47-40c7ed3d04a1"),
                column: "ConcurrencyStamp",
                value: "84a52e6a-888a-4841-bc8c-8fd0b95c1195");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2c488b7-f933-45a1-b8c3-55ae4067879d"),
                column: "ConcurrencyStamp",
                value: "3cb26ef9-eb7d-4299-96cc-dca7f5674a45");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_LowerGroups_LowerGroupId",
                table: "Stocks",
                column: "LowerGroupId",
                principalTable: "LowerGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_MainGroups_MainGroupId",
                table: "Stocks",
                column: "MainGroupId",
                principalTable: "MainGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Shops_ShopId",
                table: "Stocks",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");
        }
    }
}

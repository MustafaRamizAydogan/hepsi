﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarkodWeb.Data.Migrations
{
    public partial class ms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BossId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bed9d96-a7dd-4ac6-9aa1-5a62aa289b16"),
                column: "ConcurrencyStamp",
                value: "632fdb9e-ff67-497a-a2df-5f91343fd83c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbefda7b-7761-42c4-aa47-40c7ed3d04a1"),
                column: "ConcurrencyStamp",
                value: "7b33901a-c1c8-4bce-8f59-7b694c541806");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2c488b7-f933-45a1-b8c3-55ae4067879d"),
                column: "ConcurrencyStamp",
                value: "746e943a-c68e-41cf-ba9a-1a8f62caffd3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BossId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bed9d96-a7dd-4ac6-9aa1-5a62aa289b16"),
                column: "ConcurrencyStamp",
                value: "82d18f42-84e9-4abc-b568-7973e0a5fddf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbefda7b-7761-42c4-aa47-40c7ed3d04a1"),
                column: "ConcurrencyStamp",
                value: "ef68ec91-6837-4f39-90b2-deb772a4d095");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2c488b7-f933-45a1-b8c3-55ae4067879d"),
                column: "ConcurrencyStamp",
                value: "770ea1de-75c4-477f-bca2-0da9cfe059af");
        }
    }
}

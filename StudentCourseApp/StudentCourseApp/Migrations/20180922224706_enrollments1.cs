using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentCourseApp.Migrations
{
    public partial class enrollments1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FutureEnroll",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TId",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TopicArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AreaName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicArea", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_TId",
                table: "Course",
                column: "TId");

            migrationBuilder.AddForeignKey(
                name: "FK_TpcArea",
                table: "Course",
                column: "TId",
                principalTable: "TopicArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TpcArea",
                table: "Course");

            migrationBuilder.DropTable(
                name: "TopicArea");

            migrationBuilder.DropIndex(
                name: "IX_Course_TId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "FutureEnroll",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "TId",
                table: "Course");
        }
    }
}

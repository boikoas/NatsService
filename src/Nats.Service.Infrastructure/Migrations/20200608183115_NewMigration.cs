using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nats.Service.Infrastructure.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "messageForSave",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    TimeSend = table.Column<DateTime>(nullable: false),
                    HashCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageForSave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "messageForSend",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageForSend", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messageForSave");

            migrationBuilder.DropTable(
                name: "messageForSend");
        }
    }
}

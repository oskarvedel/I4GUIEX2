using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GUIEX2PROJECT.Data.Migrations
{
    public partial class anotherone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfChildren = table.Column<int>(nullable: false),
                    NumberOfAdults = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomNumber);
                });

            migrationBuilder.CreateTable(
                name: "BreakfastReservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    NumberOfChildReservations = table.Column<int>(nullable: false),
                    NumberOfAdultReservations = table.Column<int>(nullable: false),
                    NumberOfChildrenCheckedIn = table.Column<int>(nullable: false),
                    NumberOfAdultsCheckedIn = table.Column<int>(nullable: false),
                    roomNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastReservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_BreakfastReservations_Rooms_roomNumber",
                        column: x => x.roomNumber,
                        principalTable: "Rooms",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNumber", "NumberOfAdults", "NumberOfChildren" },
                values: new object[] { 101, 3, 4 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNumber", "NumberOfAdults", "NumberOfChildren" },
                values: new object[] { 202, 1, 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNumber", "NumberOfAdults", "NumberOfChildren" },
                values: new object[] { 303, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BreakfastReservations_roomNumber",
                table: "BreakfastReservations",
                column: "roomNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastReservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "AspNetUsers");
        }
    }
}

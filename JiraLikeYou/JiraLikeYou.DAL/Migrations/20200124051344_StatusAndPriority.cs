using Microsoft.EntityFrameworkCore.Migrations;

namespace JiraLikeYou.DAL.Migrations
{
    public partial class StatusAndPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Triggers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Triggers");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "DaysInStatus",
                table: "Triggers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CountTickets",
                table: "Triggers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Triggers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Triggers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_PriorityId",
                table: "Triggers",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_StatusId",
                table: "Triggers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Statuses_StatusId",
                table: "Tickets",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Triggers_Priorities_PriorityId",
                table: "Triggers",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Triggers_Statuses_StatusId",
                table: "Triggers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
              table: "Statuses",
              columns: new[] { "Id", "Name" },
              values: new object[] { 3, "В работе" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10013, "Код ревью" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10151, "Готово к тестированию" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10040, "Тестирование" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "ЕБАШЬТЕ В ПРОДАКШЕН" });



            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Открыт" });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Major" });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "НАС УВОЛЯТ" });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Minor" });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Trivial" });


            migrationBuilder.InsertData(
                table: "Triggers",
                columns: new[] { "Id", "OccasionTypeId", "StatusId", "PriorityId" },
                values: new object[] { 1, 1, 1, 1 });
            migrationBuilder.InsertData(
                table: "Triggers",
                columns: new[] { "Id", "OccasionTypeId", "StatusId" },
                values: new object[] { 2, 1, 3 });
            migrationBuilder.InsertData(
                table: "Triggers",
                columns: new[] { "Id", "OccasionTypeId", "StatusId" },
                values: new object[] { 3, 1, 10013 });
            migrationBuilder.InsertData(
                table: "Triggers",
                columns: new[] { "Id", "OccasionTypeId", "StatusId" },
                values: new object[] { 4, 1, 10151 });
            migrationBuilder.InsertData(
                table: "Triggers",
                columns: new[] { "Id", "OccasionTypeId", "StatusId" },
                values: new object[] { 5, 1, 10040 });
            migrationBuilder.InsertData(
                table: "Triggers",
                columns: new[] { "Id", "OccasionTypeId", "StatusId" },
                values: new object[] { 6, 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Statuses_StatusId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Triggers_Priorities_PriorityId",
                table: "Triggers");

            migrationBuilder.DropForeignKey(
                name: "FK_Triggers_Statuses_StatusId",
                table: "Triggers");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Triggers_PriorityId",
                table: "Triggers");

            migrationBuilder.DropIndex(
                name: "IX_Triggers_StatusId",
                table: "Triggers");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Triggers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Triggers");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "DaysInStatus",
                table: "Triggers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountTickets",
                table: "Triggers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Triggers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Triggers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Tickets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "TEXT",
                nullable: true);
        }
    }
}

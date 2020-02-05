using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JiraLikeYou.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OccasionTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccasionTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AvatarLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "PatternsForOccasion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OccasionTypeId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true),
                    SoundLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternsForOccasion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatternsForOccasion_OccasionTypes_OccasionTypeId",
                        column: x => x.OccasionTypeId,
                        principalTable: "OccasionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    PriorityId = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Triggers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OccasionTypeId = table.Column<long>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    PriorityId = table.Column<int>(nullable: true),
                    DaysInStatus = table.Column<int>(nullable: true),
                    CountTickets = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Triggers_OccasionTypes_OccasionTypeId",
                        column: x => x.OccasionTypeId,
                        principalTable: "OccasionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Triggers_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Triggers_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Occasions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TriggerId = table.Column<long>(nullable: false),
                    TicketId = table.Column<long>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    DaysInStatus = table.Column<int>(nullable: true),
                    CountTickets = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occasions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occasions_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Occasions_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatternsForTrigger",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TriggerId = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ImageLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternsForTrigger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatternsForTrigger_Triggers_TriggerId",
                        column: x => x.TriggerId,
                        principalTable: "Triggers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Occasions_TicketId",
                table: "Occasions",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Occasions_UserEmail",
                table: "Occasions",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_PatternsForOccasion_OccasionTypeId",
                table: "PatternsForOccasion",
                column: "OccasionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternsForTrigger_TriggerId",
                table: "PatternsForTrigger",
                column: "TriggerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PriorityId",
                table: "Tickets",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_OccasionTypeId",
                table: "Triggers",
                column: "OccasionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_PriorityId",
                table: "Triggers",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Triggers_StatusId",
                table: "Triggers",
                column: "StatusId");

            //priorities
            

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

            //Статусы
            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Открыт" });

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
                values: new object[] { 13547, "Готово к релизу" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10035, "Ожидание" });
            




            //Типы событий
            migrationBuilder.InsertData(
                table: "OccasionTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "ChangeStatus", "Изменение статуса" });
            migrationBuilder.InsertData(
                table: "OccasionTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 2, "TooManyTickets", "Слишком много тикетов" });
            migrationBuilder.InsertData(
                table: "OccasionTypes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 3, "TicketStuck", "Тикет застрял" });

            //паттерны на события
            migrationBuilder.InsertData(
                table: "PatternsForOccasion",
                columns: new[] { "Id", "OccasionTypeId", "Title", "Subtitle", "SoundLink" },
                values: new object[] { 1, 1, "{userName} перевел тикет {ticketKey} в {ticketStatus}", "{ticketName}", "https://zvukipro.com/index.php?do=download&id=4904" });

            //триггеры
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
                values: new object[] { 6, 1, 13547 });
            


            //паттерны для триггеров 
            migrationBuilder.InsertData(
              table: "PatternsForTrigger",
              columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
              values: new object[] { 1, 1, "ААА!!! Это же блокер!!!", "https://i.gifer.com/KoN.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 2, 1, "{userName}, что ты делаешь?!", "https://i.gifer.com/mLj.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 3, 2, "Молодец, {userName}, сделай его", "https://2x2tv.ru/upload/medialibrary/c5f/c5f88e9a557252626a7b8bb2ecdbddab.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 4, 2, "О! {userName} заняться нечем", "https://i.gifer.com/FMVu.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 5, 3, "{userName} накодил, гляньте", "https://media2.giphy.com/media/u0v3z2iQLxyHC/giphy.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 6, 3, "{userName} сделал тикет, е-ху!", "https://i.gifer.com/ho.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 7, 4, "Тестирование, налетай", "https://i.gifer.com/cZa.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 8, 4, "Мы точно будем это проверять?", "https://proxy10.online.ua/uol/r3-01605a97ac/59fda5b5f37a0.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 9, 5, "{userName} решила проверить это", "https://cs4.pikabu.ru/images/big_size_comm_an/2015-06_1/14335216655597.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 10, 5, "Посмотрим, посмотрим", "https://media.giphy.com/media/Zcy4gBZQftuJMzrEba/giphy.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 11, 6, "{userName} протестила, {userName} молодец", "https://cs4.pikabu.ru/post_img/2014/07/17/6/1405584435_1232133828.gif" });
            migrationBuilder.InsertData(
                table: "PatternsForTrigger",
                columns: new[] { "Id", "TriggerId", "Text", "ImageLink" },
                values: new object[] { 12, 6, "Тикет готов", "https://cs4.pikabu.ru/images/big_size_comm_an/2016-05_3/1463047313192629303.gif" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occasions");

            migrationBuilder.DropTable(
                name: "PatternsForOccasion");

            migrationBuilder.DropTable(
                name: "PatternsForTrigger");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Triggers");

            migrationBuilder.DropTable(
                name: "OccasionTypes");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}

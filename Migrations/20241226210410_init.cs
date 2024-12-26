using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicPay.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Cash = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    TranferId = table.Column<Guid>(type: "uuid", nullable: false),
                    SerderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.TranferId);
                    table.ForeignKey(
                        name: "FK_Transfer_Receive",
                        column: x => x.ReceiveId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfer_Sender",
                        column: x => x.SerderId,
                        principalTable: "Wallet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_ReceiveId",
                table: "Transfer",
                column: "ReceiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_SerderId",
                table: "Transfer",
                column: "SerderId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_Email_Cpf",
                table: "Wallet",
                columns: new[] { "Email", "Cpf" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "Wallet");
        }
    }
}

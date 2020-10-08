using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMvc.Migrations
{
    public partial class TiposContatosId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_TipoContato_TipoContatoId",
                table: "Contatos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoContatoId",
                table: "Contatos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_TipoContato_TipoContatoId",
                table: "Contatos",
                column: "TipoContatoId",
                principalTable: "TipoContato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_TipoContato_TipoContatoId",
                table: "Contatos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoContatoId",
                table: "Contatos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_TipoContato_TipoContatoId",
                table: "Contatos",
                column: "TipoContatoId",
                principalTable: "TipoContato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

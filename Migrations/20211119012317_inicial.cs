using Microsoft.EntityFrameworkCore.Migrations;

namespace Clase7.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    num_usr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    mail = table.Column<string>(type: "varchar(512)", nullable: true),
                    password = table.Column<string>(type: "varchar(50)", nullable: true),
                    segundo_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    esADM = table.Column<bool>(type: "bit", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.num_usr);
                });

            migrationBuilder.CreateTable(
                name: "dni",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<int>(type: "int", nullable: false),
                    tramite = table.Column<int>(type: "int", nullable: false),
                    num_usr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dni", x => x.id);
                    table.ForeignKey(
                        name: "FK_dni_Usuarios_num_usr",
                        column: x => x.num_usr,
                        principalTable: "Usuarios",
                        principalColumn: "num_usr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    altura = table.Column<int>(type: "int", nullable: false),
                    num_usr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Domicilios_Usuarios_num_usr",
                        column: x => x.num_usr,
                        principalTable: "Usuarios",
                        principalColumn: "num_usr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaisUsuario",
                columns: table => new
                {
                    Nacionalidadid = table.Column<int>(type: "int", nullable: false),
                    usersnum_usr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisUsuario", x => new { x.Nacionalidadid, x.usersnum_usr });
                    table.ForeignKey(
                        name: "FK_PaisUsuario_Paises_Nacionalidadid",
                        column: x => x.Nacionalidadid,
                        principalTable: "Paises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaisUsuario_Usuarios_usersnum_usr",
                        column: x => x.usersnum_usr,
                        principalTable: "Usuarios",
                        principalColumn: "num_usr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    num_usr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPais", x => new { x.num_usr, x.id });
                    table.ForeignKey(
                        name: "FK_UsuarioPais_Paises_id",
                        column: x => x.id,
                        principalTable: "Paises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPais_Usuarios_num_usr",
                        column: x => x.num_usr,
                        principalTable: "Usuarios",
                        principalColumn: "num_usr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Argentina" },
                    { 2, "Uruguay" },
                    { 3, "Chile" },
                    { 4, "Brasil" },
                    { 5, "Paraguay" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "num_usr", "bloqueado", "esADM", "mail", "nombre", "password", "segundo_nombre" },
                values: new object[,]
                {
                    { 1, false, true, "111@111", "111", "111", null },
                    { 2, true, true, "222@222", "222", "222", null },
                    { 3, true, false, "333@333", "333", "333", null },
                    { 4, false, false, "444@444", "444", "444", null },
                    { 5, false, true, "555@555", "555", "555", null }
                });

            migrationBuilder.InsertData(
                table: "Domicilios",
                columns: new[] { "id", "altura", "calle", "num_usr" },
                values: new object[,]
                {
                    { 1, 1, "9 de Julio", 1 },
                    { 2, 1, "Cerrito", 1 },
                    { 3, 1, "Santa Fe", 2 },
                    { 4, 1, "Florida", 2 },
                    { 5, 1, "Alcorta", 2 },
                    { 6, 1, "Las Heras", 3 },
                    { 7, 1, "Callao", 4 },
                    { 8, 1, "Rivadavia", 5 }
                });

            migrationBuilder.InsertData(
                table: "dni",
                columns: new[] { "id", "num_usr", "numero", "tramite" },
                values: new object[,]
                {
                    { 1, 1, 111, 111 },
                    { 2, 2, 222, 222 },
                    { 3, 3, 333, 333 },
                    { 4, 4, 444, 444 },
                    { 5, 5, 555, 555 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_dni_num_usr",
                table: "dni",
                column: "num_usr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_num_usr",
                table: "Domicilios",
                column: "num_usr");

            migrationBuilder.CreateIndex(
                name: "IX_PaisUsuario_usersnum_usr",
                table: "PaisUsuario",
                column: "usersnum_usr");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPais_id",
                table: "UsuarioPais",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dni");

            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "PaisUsuario");

            migrationBuilder.DropTable(
                name: "UsuarioPais");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

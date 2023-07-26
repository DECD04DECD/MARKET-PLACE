using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace MARKET_PLACE.Migrations
{
    public partial class Example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    PkGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreG = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.PkGenero);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    PkProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<double>(type: "double", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.PkProducto);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "GeneroProducto",
                columns: table => new
                {
                    GenerosPkGenero = table.Column<int>(type: "int", nullable: false),
                    ProductosPkProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroProducto", x => new { x.GenerosPkGenero, x.ProductosPkProducto });
                    table.ForeignKey(
                        name: "FK_GeneroProducto_Generos_GenerosPkGenero",
                        column: x => x.GenerosPkGenero,
                        principalTable: "Generos",
                        principalColumn: "PkGenero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroProducto_Productos_ProductosPkProducto",
                        column: x => x.ProductosPkProducto,
                        principalTable: "Productos",
                        principalColumn: "PkProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto_Descripcion",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto_Descripcion", x => new { x.ProductoId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_Producto_Descripcion_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "PkGenero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Descripcion_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "PkProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "PkGenero", "NombreG" },
                values: new object[,]
                {
                    { 1, "Electrónicos" },
                    { 2, "Moda" },
                    { 3, "Belleza y cuidado personal" },
                    { 4, "Deportes" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "PkProducto", "Cantidad", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 3, 20, "Maquillaje", 1850.0 },
                    { 2, 12, "Playera", 649.99000000000001 },
                    { 1, 5, "Telefono", 8999.9899999999998 },
                    { 4, 15, "Balon", 500.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Vendedor" },
                    { 3, "Comprador" }
                });

            migrationBuilder.InsertData(
                table: "Producto_Descripcion",
                columns: new[] { "GeneroId", "ProductoId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 2, 2 },
                    { 1, 1 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "PkUsuario", "FkRol", "Nombre", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, 1, "Diego", "1234", "Admin1" },
                    { 2, 2, "Maximiliano", "1212", "User1" },
                    { 3, 3, "Adamaris", "pato", "User2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroProducto_ProductosPkProducto",
                table: "GeneroProducto",
                column: "ProductosPkProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Descripcion_GeneroId",
                table: "Producto_Descripcion",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRol",
                table: "Usuarios",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroProducto");

            migrationBuilder.DropTable(
                name: "Producto_Descripcion");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

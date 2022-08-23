using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class recargadelibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeAlquileres",
                columns: table => new
                {
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeAlquileres", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Edicion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_cliente_Cliente",
                        column: x => x.Cliente,
                        principalTable: "cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_EstadoDeAlquileres_Estado",
                        column: x => x.Estado,
                        principalTable: "EstadoDeAlquileres",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquileres_Libros_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Libros",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoID", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Alquilado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "9781947783744", "Michael Crichton", "2018", "Debolsillo", "https://images.cdn3.buscalibre.com/fit-in/360x360/28/55/28553533d8503c62793e6519e92019d7.jpg", 20, "Jurassic Park" },
                    { "9788420684734", "Dashiell Hammett", "2014", "Alianza", "https://images.cdn1.buscalibre.com/fit-in/360x360/7e/d1/7ed1fbef6ff94ab7eb90c7900f269610.jpg", 1, "El Halcón Maltés" },
                    { "9789500515368", "Roberto Cossa", "2004", "Corregidor", "https://images.cdn2.buscalibre.com/fit-in/360x360/7b/47/7b477cabccfb6f728f8c773ea2cfea62.jpg", 30, "La Nona" },
                    { "9789563162486", "Edgar Allan Poe", "2016", "Origo Ediciones", "https://images.cdn2.buscalibre.com/fit-in/360x360/aa/66/aa66a5c34a918856ac3b1c9f7dc9184c.jpg", 2, "El Corazon Delator" },
                    { "9789872143145", "Orwell, George", "2012", "Arenal", "https://images.cdn2.buscalibre.com/fit-in/360x360/fd/44/fd44e3c32998c4d8ab38ff6c48caa1ba.jpg", 5, "1984" },
                    { "9789875040731", "Oscar Wilde", "2013", "Quipu", "https://images.cdn1.buscalibre.com/fit-in/360x360/4c/d6/4cd68a988e0c6b73a0cc9bbe5edf66a8.jpg", 5, "El Fantasma de Canterville" },
                    { "9789875507784", "Robert Louis Stevenson", "2008", "Longseller S.A.", "https://images.cdn1.buscalibre.com/fit-in/360x360/b8/35/b83536af56c934e91ff88bc24c4379c2.jpg", 1, "El Extrano Caso del dr. Jekyll y mr. Hyde" },
                    { "9789875661196", "Ray Bradbury", "2005", "Debolsillo", "https://images.cdn1.buscalibre.com/fit-in/360x360/b8/46/b8461454fb69c7ed1c89787e6a3343dd.jpg", 5, "Fahrenheit 451" },
                    { "9789875730021", "Huidobro Norma", "2005", "Sm", "https://images.cdn3.buscalibre.com/fit-in/360x360/69/eb/69ebd9fb55e07a519f8828eca41d7feb.jpg", 10, "Octubre, un Crimen" },
                    { "9789877802894", "Santiago Posteguillo", "2022", "Ediciones B", "https://images.cdn1.buscalibre.com/fit-in/360x360/4c/a1/4ca11d981c8758968afffbf52d28e540.jpg", 0, "Roma soy yo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Cliente",
                table: "Alquileres",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Estado",
                table: "Alquileres",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ISBN",
                table: "Alquileres",
                column: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}

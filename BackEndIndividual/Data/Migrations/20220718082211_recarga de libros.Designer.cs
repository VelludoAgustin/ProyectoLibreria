// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoSoftwareIndividual.Contexto;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ProyectoSoftwareLibreriaContext))]
    [Migration("20220718082211_recarga de libros")]
    partial class recargadelibros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Alquileres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("Cliente");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int")
                        .HasColumnName("Estado");

                    b.Property<DateTime?>("FechaAlquiler")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaReserva")
                        .HasColumnType("datetime2");

                    b.Property<string>("ISBNId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ISBN");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("ISBNId");

                    b.ToTable("Alquileres");
                });

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("ClienteID");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.EstadoDeAlquileres", b =>
                {
                    b.Property<int>("EstadoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoID"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("EstadoID");

                    b.ToTable("EstadoDeAlquileres");

                    b.HasData(
                        new
                        {
                            EstadoID = 1,
                            Descripcion = "Reservado"
                        },
                        new
                        {
                            EstadoID = 2,
                            Descripcion = "Alquilado"
                        },
                        new
                        {
                            EstadoID = 3,
                            Descripcion = "Cancelado"
                        });
                });

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Libros", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Edicion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Editorial")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("ISBN");

                    b.ToTable("Libros");

                    b.HasData(
                        new
                        {
                            ISBN = "9781947783744",
                            Autor = "Michael Crichton",
                            Edicion = "2018",
                            Editorial = "Debolsillo",
                            Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/28/55/28553533d8503c62793e6519e92019d7.jpg",
                            Stock = 20,
                            Titulo = "Jurassic Park"
                        },
                        new
                        {
                            ISBN = "9789877802894",
                            Autor = "Santiago Posteguillo",
                            Edicion = "2022",
                            Editorial = "Ediciones B",
                            Imagen = "https://images.cdn1.buscalibre.com/fit-in/360x360/4c/a1/4ca11d981c8758968afffbf52d28e540.jpg",
                            Stock = 0,
                            Titulo = "Roma soy yo"
                        },
                        new
                        {
                            ISBN = "9788420684734",
                            Autor = "Dashiell Hammett",
                            Edicion = "2014",
                            Editorial = "Alianza",
                            Imagen = "https://images.cdn1.buscalibre.com/fit-in/360x360/7e/d1/7ed1fbef6ff94ab7eb90c7900f269610.jpg",
                            Stock = 1,
                            Titulo = "El Halcón Maltés"
                        },
                        new
                        {
                            ISBN = "9789872143145",
                            Autor = "Orwell, George",
                            Edicion = "2012",
                            Editorial = "Arenal",
                            Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/fd/44/fd44e3c32998c4d8ab38ff6c48caa1ba.jpg",
                            Stock = 5,
                            Titulo = "1984"
                        },
                        new
                        {
                            ISBN = "9789875661196",
                            Autor = "Ray Bradbury",
                            Edicion = "2005",
                            Editorial = "Debolsillo",
                            Imagen = "https://images.cdn1.buscalibre.com/fit-in/360x360/b8/46/b8461454fb69c7ed1c89787e6a3343dd.jpg",
                            Stock = 5,
                            Titulo = "Fahrenheit 451"
                        },
                        new
                        {
                            ISBN = "9789875730021",
                            Autor = "Huidobro Norma",
                            Edicion = "2005",
                            Editorial = "Sm",
                            Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/69/eb/69ebd9fb55e07a519f8828eca41d7feb.jpg",
                            Stock = 10,
                            Titulo = "Octubre, un Crimen"
                        },
                        new
                        {
                            ISBN = "9789875040731",
                            Autor = "Oscar Wilde",
                            Edicion = "2013",
                            Editorial = "Quipu",
                            Imagen = "https://images.cdn1.buscalibre.com/fit-in/360x360/4c/d6/4cd68a988e0c6b73a0cc9bbe5edf66a8.jpg",
                            Stock = 5,
                            Titulo = "El Fantasma de Canterville"
                        },
                        new
                        {
                            ISBN = "9789875507784",
                            Autor = "Robert Louis Stevenson",
                            Edicion = "2008",
                            Editorial = "Longseller S.A.",
                            Imagen = "https://images.cdn1.buscalibre.com/fit-in/360x360/b8/35/b83536af56c934e91ff88bc24c4379c2.jpg",
                            Stock = 1,
                            Titulo = "El Extrano Caso del dr. Jekyll y mr. Hyde"
                        },
                        new
                        {
                            ISBN = "9789500515368",
                            Autor = "Roberto Cossa",
                            Edicion = "2004",
                            Editorial = "Corregidor",
                            Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/7b/47/7b477cabccfb6f728f8c773ea2cfea62.jpg",
                            Stock = 30,
                            Titulo = "La Nona"
                        },
                        new
                        {
                            ISBN = "9789563162486",
                            Autor = "Edgar Allan Poe",
                            Edicion = "2016",
                            Editorial = "Origo Ediciones",
                            Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/aa/66/aa66a5c34a918856ac3b1c9f7dc9184c.jpg",
                            Stock = 2,
                            Titulo = "El Corazon Delator"
                        });
                });

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Alquileres", b =>
                {
                    b.HasOne("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Cliente", "Cliente")
                        .WithMany("Alquileres")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.EstadoDeAlquileres", "Estado")
                        .WithMany("Alquileres")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Libros", "ISBN")
                        .WithMany("Alquileres")
                        .HasForeignKey("ISBNId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Estado");

                    b.Navigation("ISBN");
                });

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Cliente", b =>
                {
                    b.Navigation("Alquileres");
                });

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.EstadoDeAlquileres", b =>
                {
                    b.Navigation("Alquileres");
                });

            modelBuilder.Entity("TrabajoPracticoIndividualProyectoSoftware.CrearTablas.Libros", b =>
                {
                    b.Navigation("Alquileres");
                });
#pragma warning restore 612, 618
        }
    }
}

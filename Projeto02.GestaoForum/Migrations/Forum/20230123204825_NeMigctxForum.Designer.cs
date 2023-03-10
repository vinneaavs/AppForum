// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto02.GestaoForum.Models;

#nullable disable

namespace Projeto02.GestaoForum.Migrations.Forum
{
    [DbContext(typeof(ForumContext))]
    [Migration("20230123204825_NeMigctxForum")]
    partial class NeMigctxForum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Projeto02.GestaoForum.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ComentarioInfo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COMENTARIO");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ForumId")
                        .HasColumnType("int")
                        .HasColumnName("IDFORUM");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("IDUSUARIO");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("COMENTARIOS", (string)null);
                });

            modelBuilder.Entity("Projeto02.GestaoForum.Models.Forum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FORUM", (string)null);
                });

            modelBuilder.Entity("Projeto02.GestaoForum.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("Projeto02.GestaoForum.Models.Comentario", b =>
                {
                    b.HasOne("Projeto02.GestaoForum.Models.Forum", "Forum")
                        .WithMany("Comentarios")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto02.GestaoForum.Models.Usuario", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Forum");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto02.GestaoForum.Models.Forum", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("Projeto02.GestaoForum.Models.Usuario", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}

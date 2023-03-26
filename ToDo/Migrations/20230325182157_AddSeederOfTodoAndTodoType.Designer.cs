﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo.Datas;

#nullable disable

namespace ToDo.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20230325182157_AddSeederOfTodoAndTodoType")]
    partial class AddSeederOfTodoAndTodoType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ToDo.Datas.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TodoTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TodoTypeId");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description of activity one",
                            Title = "Activity one",
                            TodoTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description of activity two",
                            Title = "Activity two",
                            TodoTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description of activity three",
                            Title = "Activity three",
                            TodoTypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description of activity four",
                            Title = "Activity four",
                            TodoTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description of activity five",
                            Title = "Activity five",
                            TodoTypeId = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "Description of activity six",
                            Title = "Activity six",
                            TodoTypeId = 3
                        });
                });

            modelBuilder.Entity("ToDo.Datas.TodoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TodoTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "School activity"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Work activity"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Home activity"
                        });
                });

            modelBuilder.Entity("ToDo.Datas.Todo", b =>
                {
                    b.HasOne("ToDo.Datas.TodoType", "TodoType")
                        .WithMany("Todos")
                        .HasForeignKey("TodoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoType");
                });

            modelBuilder.Entity("ToDo.Datas.TodoType", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}

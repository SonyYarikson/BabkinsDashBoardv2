﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models.DataContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Models.Migrations
{
    [DbContext(typeof(DashBoardDataContext))]
    partial class DashBoardDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Board", b =>
                {
                    b.Property<Guid>("BoardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BoardName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Privacy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("BoardID");

                    b.HasIndex("UserID");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.Property<Guid>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BoardID")
                        .HasColumnType("uuid");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RowID")
                        .HasColumnType("uuid");

                    b.HasKey("CardID");

                    b.HasIndex("BoardID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Models.Row", b =>
                {
                    b.Property<Guid>("RowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("RowContent")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("RowType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RowID");

                    b.HasIndex("CardId");

                    b.ToTable("Rows");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uuid");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.UserRole", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Models.Board", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("Board")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.HasOne("Models.Board", "Board")
                        .WithMany("Cards")
                        .HasForeignKey("BoardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Models.Row", b =>
                {
                    b.HasOne("Models.Card", "Card")
                        .WithMany("Rows")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.HasOne("Models.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Models.Board", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("Models.Card", b =>
                {
                    b.Navigation("Rows");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Board");
                });

            modelBuilder.Entity("Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

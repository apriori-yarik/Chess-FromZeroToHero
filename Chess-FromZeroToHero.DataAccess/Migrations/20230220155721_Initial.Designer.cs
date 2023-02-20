﻿// <auto-generated />
using System;
using Chess_FromZeroToHero.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChessFromZeroToHero.DataAccess.Migrations
{
    [DbContext(typeof(ChessDbContext))]
    [Migration("20230220155721_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRated")
                        .HasColumnType("bit");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<int>("TimeControl")
                        .HasColumnType("int");

                    b.Property<int>("TimeIncrement")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BlackTimeLeft")
                        .HasColumnType("int");

                    b.Property<string>("FEN")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("GameId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PuzzleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Turn")
                        .HasColumnType("bit");

                    b.Property<int?>("WhiteTimeLeft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Puzzle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Likes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("PositionId")
                        .IsUnique();

                    b.ToTable("Puzzle");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1200);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.UserGame", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGame");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.UserPuzzle", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PuzzleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "PuzzleId");

                    b.HasIndex("PuzzleId");

                    b.ToTable("UserPuzzle");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Position", b =>
                {
                    b.HasOne("Chess_FromZeroToHero.DataAccess.Entities.Game", "Game")
                        .WithMany("Positions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Puzzle", b =>
                {
                    b.HasOne("Chess_FromZeroToHero.DataAccess.Entities.Position", "Position")
                        .WithOne("Puzzle")
                        .HasForeignKey("Chess_FromZeroToHero.DataAccess.Entities.Puzzle", "PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.UserGame", b =>
                {
                    b.HasOne("Chess_FromZeroToHero.DataAccess.Entities.Game", "Game")
                        .WithMany("UserGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chess_FromZeroToHero.DataAccess.Entities.User", "User")
                        .WithMany("UserGames")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.UserPuzzle", b =>
                {
                    b.HasOne("Chess_FromZeroToHero.DataAccess.Entities.Puzzle", "Puzzle")
                        .WithMany("UserPuzzles")
                        .HasForeignKey("PuzzleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chess_FromZeroToHero.DataAccess.Entities.User", "User")
                        .WithMany("UserPuzzles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Puzzle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Game", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("UserGames");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Position", b =>
                {
                    b.Navigation("Puzzle")
                        .IsRequired();
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.Puzzle", b =>
                {
                    b.Navigation("UserPuzzles");
                });

            modelBuilder.Entity("Chess_FromZeroToHero.DataAccess.Entities.User", b =>
                {
                    b.Navigation("UserGames");

                    b.Navigation("UserPuzzles");
                });
#pragma warning restore 612, 618
        }
    }
}

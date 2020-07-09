﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesReservation.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoviesReservation.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20200708082731_newNameUserId")]
    partial class newNameUserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MoviesReservation.Models.Movie", b =>
                {
                    b.Property<long>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("integer");

                    b.Property<string>("ImageFile")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesReservation.Models.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("SeanceId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SeatsToReserveId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SeanceId");

                    b.HasIndex("SeatsToReserveId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("MoviesReservation.Models.Seance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndOfSeance")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartOfSeance")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("MoviesReservation.Models.Seat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsReserved")
                        .HasColumnType("boolean");

                    b.Property<long?>("SeanceId")
                        .HasColumnType("bigint");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SeanceId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("MoviesReservation.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoviesReservation.Models.Reservation", b =>
                {
                    b.HasOne("MoviesReservation.Models.Seance", "Seance")
                        .WithMany("Reservations")
                        .HasForeignKey("SeanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesReservation.Models.Seat", "SeatsToReserve")
                        .WithMany()
                        .HasForeignKey("SeatsToReserveId");

                    b.HasOne("MoviesReservation.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesReservation.Models.Seance", b =>
                {
                    b.HasOne("MoviesReservation.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesReservation.Models.Seat", b =>
                {
                    b.HasOne("MoviesReservation.Models.Seance", null)
                        .WithMany("Seats")
                        .HasForeignKey("SeanceId");
                });
#pragma warning restore 612, 618
        }
    }
}

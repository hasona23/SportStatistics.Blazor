﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportStats.Data;

#nullable disable

namespace SportStats.Migrations
{
    [DbContext(typeof(StatsContext))]
    [Migration("20240528194208_modelupdate4")]
    partial class modelupdate4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SportStats.Models.BaseStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BelongsToId")
                        .HasColumnType("int");

                    b.Property<int>("InGameId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stat")
                        .HasColumnType("int");

                    b.Property<string>("StatType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.HasIndex("BelongsToId");

                    b.HasIndex("InGameId");

                    b.ToTable("Stats");

                    b.HasDiscriminator<string>("StatType").HasValue("BaseStat");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SportStats.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlayedAgainst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("SportStats.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInTeam")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberOfId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberOfId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SportStats.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SportStats.Models.Block", b =>
                {
                    b.HasBaseType("SportStats.Models.BaseStat");

                    b.HasDiscriminator().HasValue("Block");
                });

            modelBuilder.Entity("SportStats.Models.Interception", b =>
                {
                    b.HasBaseType("SportStats.Models.BaseStat");

                    b.HasDiscriminator().HasValue("Interception");
                });

            modelBuilder.Entity("SportStats.Models.Pass", b =>
                {
                    b.HasBaseType("SportStats.Models.BaseStat");

                    b.HasDiscriminator().HasValue("Pass");
                });

            modelBuilder.Entity("SportStats.Models.Rebound", b =>
                {
                    b.HasBaseType("SportStats.Models.BaseStat");

                    b.HasDiscriminator().HasValue("Rebound");
                });

            modelBuilder.Entity("SportStats.Models.Shot", b =>
                {
                    b.HasBaseType("SportStats.Models.BaseStat");

                    b.HasDiscriminator().HasValue("Shot");
                });

            modelBuilder.Entity("SportStats.Models.BaseStat", b =>
                {
                    b.HasOne("SportStats.Models.Player", "BelongsTo")
                        .WithMany("Stats")
                        .HasForeignKey("BelongsToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportStats.Models.Game", "InGame")
                        .WithMany("StatsInGame")
                        .HasForeignKey("InGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BelongsTo");

                    b.Navigation("InGame");
                });

            modelBuilder.Entity("SportStats.Models.Player", b =>
                {
                    b.HasOne("SportStats.Models.Team", "MemberOf")
                        .WithMany("Players")
                        .HasForeignKey("MemberOfId");

                    b.Navigation("MemberOf");
                });

            modelBuilder.Entity("SportStats.Models.Game", b =>
                {
                    b.Navigation("StatsInGame");
                });

            modelBuilder.Entity("SportStats.Models.Player", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("SportStats.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}

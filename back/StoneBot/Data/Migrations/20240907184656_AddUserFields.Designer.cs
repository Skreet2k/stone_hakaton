﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoneBot.Data;

#nullable disable

namespace StoneBot.Data.Migrations
{
    [DbContext(typeof(StoneBotDbContext))]
    [Migration("20240907184656_AddUserFields")]
    partial class AddUserFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("StoneBot.Domain.Background", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Backgrounds");
                });

            modelBuilder.Entity("StoneBot.Domain.Booster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoinsCountPerClick")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Boosters");
                });

            modelBuilder.Entity("StoneBot.Domain.Miner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoinsCountPerTimeSpan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("TimeSpan")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Miners");
                });

            modelBuilder.Entity("StoneBot.Domain.Score", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TodayScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalScore")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("StoneBot.Domain.Skin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skins");
                });

            modelBuilder.Entity("StoneBot.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StoneBot.Domain.UserBackground", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("BackgroundId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "BackgroundId");

                    b.HasIndex("BackgroundId");

                    b.ToTable("UserBackgrounds");
                });

            modelBuilder.Entity("StoneBot.Domain.UserBooster", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("BoosterId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "BoosterId");

                    b.HasIndex("BoosterId");

                    b.ToTable("UserBoosters");
                });

            modelBuilder.Entity("StoneBot.Domain.UserMiner", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MinerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "MinerId");

                    b.HasIndex("MinerId");

                    b.ToTable("UserMiners");
                });

            modelBuilder.Entity("StoneBot.Domain.UserSkin", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SkinId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "SkinId");

                    b.HasIndex("SkinId");

                    b.ToTable("UserSkins");
                });

            modelBuilder.Entity("StoneBot.Domain.Score", b =>
                {
                    b.HasOne("StoneBot.Domain.User", "User")
                        .WithOne("Score")
                        .HasForeignKey("StoneBot.Domain.Score", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StoneBot.Domain.UserBackground", b =>
                {
                    b.HasOne("StoneBot.Domain.Background", "Background")
                        .WithMany()
                        .HasForeignKey("BackgroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoneBot.Domain.User", "User")
                        .WithMany("Backgrounds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Background");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StoneBot.Domain.UserBooster", b =>
                {
                    b.HasOne("StoneBot.Domain.Booster", "Booster")
                        .WithMany()
                        .HasForeignKey("BoosterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoneBot.Domain.User", "User")
                        .WithMany("Boosters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booster");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StoneBot.Domain.UserMiner", b =>
                {
                    b.HasOne("StoneBot.Domain.Miner", "Miner")
                        .WithMany()
                        .HasForeignKey("MinerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoneBot.Domain.User", "User")
                        .WithMany("Miners")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miner");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StoneBot.Domain.UserSkin", b =>
                {
                    b.HasOne("StoneBot.Domain.Skin", "Skin")
                        .WithMany()
                        .HasForeignKey("SkinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoneBot.Domain.User", "User")
                        .WithMany("Skins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StoneBot.Domain.User", b =>
                {
                    b.Navigation("Backgrounds");

                    b.Navigation("Boosters");

                    b.Navigation("Miners");

                    b.Navigation("Score")
                        .IsRequired();

                    b.Navigation("Skins");
                });
#pragma warning restore 612, 618
        }
    }
}

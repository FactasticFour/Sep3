﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersistenceServer.Data;

namespace PersistenceServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210518131339_AccountTransaction")]
    partial class AccountTransaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AccountAccount", b =>
                {
                    b.Property<int>("ReceiverAccountId")
                        .HasColumnType("integer");

                    b.Property<int>("SenderAccountId")
                        .HasColumnType("integer");

                    b.HasKey("ReceiverAccountId", "SenderAccountId");

                    b.HasIndex("SenderAccountId");

                    b.ToTable("AccountAccount");
                });

            modelBuilder.Entity("PersistenceServer.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationPassword")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Balance")
                        .HasColumnType("integer");

                    b.Property<int>("viaId")
                        .HasColumnType("integer");

                    b.HasKey("AccountId");

                    b.HasIndex("viaId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PersistenceServer.Models.Campus", b =>
                {
                    b.Property<string>("City")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Street")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PostCode")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("postcode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("City", "Street", "PostCode");

                    b.ToTable("Campuses");
                });

            modelBuilder.Entity("PersistenceServer.Models.CreditCard", b =>
                {
                    b.Property<string>("CreditCardNumber")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<int>("AmountOfMoney")
                        .HasColumnType("integer");

                    b.Property<string>("ExpirationMonth")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("ExpirationYear")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("fname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("lname");

                    b.Property<int>("SecurityCode")
                        .HasColumnType("integer");

                    b.Property<int?>("accountId")
                        .HasColumnType("integer");

                    b.HasKey("CreditCardNumber");

                    b.HasIndex("accountId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("PersistenceServer.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RoleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("accountId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId");

                    b.HasIndex("accountId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PersistenceServer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PersistenceServer.Models.ViaEntity", b =>
                {
                    b.Property<int>("ViaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("ViaId");

                    b.ToTable("ViaEntity");
                });

            modelBuilder.Entity("PersistenceServer.Models.Facility", b =>
                {
                    b.HasBaseType("PersistenceServer.Models.ViaEntity");

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("CampusCity")
                        .HasColumnType("character varying(256)");

                    b.Property<string>("CampusPostCode")
                        .HasColumnType("character varying(4)");

                    b.Property<string>("CampusStreet")
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasIndex("AccountId");

                    b.HasIndex("CampusCity", "CampusStreet", "CampusPostCode");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("PersistenceServer.Models.Member", b =>
                {
                    b.HasBaseType("PersistenceServer.Models.ViaEntity");

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer");

                    b.Property<long>("Cpr")
                        .HasMaxLength(10)
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("fname");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("lname");

                    b.HasIndex("AccountId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("AccountAccount", b =>
                {
                    b.HasOne("PersistenceServer.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("ReceiverAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersistenceServer.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("SenderAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersistenceServer.Models.Account", b =>
                {
                    b.HasOne("PersistenceServer.Models.ViaEntity", "ViaEntity")
                        .WithMany()
                        .HasForeignKey("viaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ViaEntity");
                });

            modelBuilder.Entity("PersistenceServer.Models.CreditCard", b =>
                {
                    b.HasOne("PersistenceServer.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("accountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("PersistenceServer.Models.Role", b =>
                {
                    b.HasOne("PersistenceServer.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("accountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("PersistenceServer.Models.Facility", b =>
                {
                    b.HasOne("PersistenceServer.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("PersistenceServer.Models.ViaEntity", null)
                        .WithOne()
                        .HasForeignKey("PersistenceServer.Models.Facility", "ViaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersistenceServer.Models.Campus", "Campus")
                        .WithMany()
                        .HasForeignKey("CampusCity", "CampusStreet", "CampusPostCode");

                    b.Navigation("Account");

                    b.Navigation("Campus");
                });

            modelBuilder.Entity("PersistenceServer.Models.Member", b =>
                {
                    b.HasOne("PersistenceServer.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("PersistenceServer.Models.ViaEntity", null)
                        .WithOne()
                        .HasForeignKey("PersistenceServer.Models.Member", "ViaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
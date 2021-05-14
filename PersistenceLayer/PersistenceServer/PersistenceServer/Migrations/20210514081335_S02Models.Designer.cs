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
    [Migration("20210514081335_S02Models")]
    partial class S02Models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PersistenceServer.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApplicationPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Balance")
                        .HasColumnType("integer");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("character varying(16)");

                    b.Property<int>("viaId")
                        .HasColumnType("integer");

                    b.HasKey("AccountId");

                    b.HasIndex("CreditCardNumber");

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

                    b.HasKey("CreditCardNumber");

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

            modelBuilder.Entity("PersistenceServer.Models.Transfer", b =>
                {
                    b.Property<int>("ReceiverViaId")
                        .HasColumnType("integer");

                    b.Property<int>("SenderViaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("transferAmount")
                        .HasColumnType("integer");

                    b.HasKey("ReceiverViaId", "SenderViaId");

                    b.ToTable("Transfers");
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ViaId");

                    b.ToTable("ViaEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ViaEntity");
                });

            modelBuilder.Entity("PersistenceServer.Models.Facility", b =>
                {
                    b.HasBaseType("PersistenceServer.Models.ViaEntity");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Facility_Password");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("postcode");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasDiscriminator().HasValue("Facility");
                });

            modelBuilder.Entity("PersistenceServer.Models.Member", b =>
                {
                    b.HasBaseType("PersistenceServer.Models.ViaEntity");

                    b.Property<int>("Cpr")
                        .HasMaxLength(10)
                        .HasColumnType("integer");

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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("PersistenceServer.Models.Account", b =>
                {
                    b.HasOne("PersistenceServer.Models.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardNumber");

                    b.HasOne("PersistenceServer.Models.ViaEntity", "ViaEntity")
                        .WithMany()
                        .HasForeignKey("viaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditCard");

                    b.Navigation("ViaEntity");
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
#pragma warning restore 612, 618
        }
    }
}
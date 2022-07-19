﻿// <auto-generated />
using System;
using KG_CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KGCleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220719011226_InitialCreatMigration")]
    partial class InitialCreatMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KG_CleanArchitecture.Core.PhonebookAggregate.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhonebookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhonebookId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("KG_CleanArchitecture.Core.PhonebookAggregate.Phonebook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Phonebooks");
                });

            modelBuilder.Entity("KG_CleanArchitecture.Core.PhonebookAggregate.Entry", b =>
                {
                    b.HasOne("KG_CleanArchitecture.Core.PhonebookAggregate.Phonebook", null)
                        .WithMany("Entries")
                        .HasForeignKey("PhonebookId");
                });

            modelBuilder.Entity("KG_CleanArchitecture.Core.PhonebookAggregate.Phonebook", b =>
                {
                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}

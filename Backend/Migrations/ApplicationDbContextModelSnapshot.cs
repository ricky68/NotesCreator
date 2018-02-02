﻿// <auto-generated />
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Models.Notes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActionDate");

                    b.Property<string>("ActionNote");

                    b.Property<bool>("Callback");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Note")
                        .IsRequired();

                    b.Property<bool>("Urgent");

                    b.HasKey("ID");

                    b.ToTable("Note");
                });
#pragma warning restore 612, 618
        }
    }
}
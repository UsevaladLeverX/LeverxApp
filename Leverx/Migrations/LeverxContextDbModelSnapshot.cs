﻿// <auto-generated />
using System;
using Leverx.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leverx.Migrations
{
    [DbContext(typeof(LeverxContextDb))]
    partial class LeverxContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Leverx.Models.Level", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LevelId");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("Leverx.Models.Mentee", b =>
                {
                    b.Property<int>("MenteeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("MenteeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenteeId");

                    b.HasIndex("LevelId");

                    b.ToTable("Mentee");
                });

            modelBuilder.Entity("Leverx.Models.Mentee", b =>
                {
                    b.HasOne("Leverx.Models.Level", "Level")
                        .WithMany("Mentees")
                        .HasForeignKey("LevelId");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("Leverx.Models.Level", b =>
                {
                    b.Navigation("Mentees");
                });
#pragma warning restore 612, 618
        }
    }
}

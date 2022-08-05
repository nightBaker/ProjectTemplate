﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectTemplate.PERSISTENCE;

namespace ProjectTemplate.PERSISTENCE.Migrations
{
    [DbContext(typeof(ProjectTemplateDbContext))]
    [Migration("20200802093234_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate.Some", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("SomeEnum")
                        .HasColumnType("integer");

                    b.Property<string>("SomeValue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Somes");
                });
#pragma warning restore 612, 618
        }
    }
}

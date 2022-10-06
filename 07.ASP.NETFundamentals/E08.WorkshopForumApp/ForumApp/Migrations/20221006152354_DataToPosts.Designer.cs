﻿// <auto-generated />
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Migrations
{
    [DbContext(typeof(ForumAppDbContext))]
    [Migration("20221006152354_DataToPosts")]
    partial class DataToPosts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumApp.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Content for the first post. Very interesting and informative, for sure.",
                            Title = "First Post"
                        },
                        new
                        {
                            Id = 2,
                            Content = "An age old question. How do you do it? Some say watch cookings shows. But it's most effective to just do it. Sponsored by Nike.",
                            Title = "How to Cook Better"
                        },
                        new
                        {
                            Id = 3,
                            Content = "How is this possible? Incredible! A third post on this formum.",
                            Title = "A Third Post??"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

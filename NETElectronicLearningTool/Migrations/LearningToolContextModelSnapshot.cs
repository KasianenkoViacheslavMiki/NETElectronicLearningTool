﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETElectronicLearningTool.EF;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    [DbContext(typeof(LearningToolContext))]
    partial class LearningToolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("TitleArticle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.ArticlePage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("IdArticle")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("NumberPage")
                        .HasColumnType("bigint");

                    b.Property<string>("TextArticlePage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdArticle");

                    b.ToTable("ArticlePages");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.MethodDiscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("DiscriptionFunction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFunction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DictionaryOfFunctions");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.QuestionAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TestQuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("TrueOrFalse")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TestQuestionId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.TestQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TestQuestion");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.ArticlePage", b =>
                {
                    b.HasOne("NETElectronicLearningTool.EF.Model.Article", "Article")
                        .WithMany("ArticlePage")
                        .HasForeignKey("IdArticle");

                    b.Navigation("Article");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.QuestionAnswer", b =>
                {
                    b.HasOne("NETElectronicLearningTool.EF.Model.TestQuestion", "TestQuestion")
                        .WithMany()
                        .HasForeignKey("TestQuestionId");

                    b.Navigation("TestQuestion");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.TestQuestion", b =>
                {
                    b.HasOne("NETElectronicLearningTool.EF.Model.Test", "Test")
                        .WithMany("TestQuestions")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.Article", b =>
                {
                    b.Navigation("ArticlePage");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.Test", b =>
                {
                    b.Navigation("TestQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}

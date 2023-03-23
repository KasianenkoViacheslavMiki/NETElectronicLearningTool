﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETElectronicLearningTool.EF;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    [DbContext(typeof(LearningToolContext))]
    [Migration("20230323170644_DeleteNewId")]
    partial class DeleteNewId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int?>("CountQuestionForExamMany")
                        .HasColumnType("int");

                    b.Property<int?>("CountQuestionForExamSingle")
                        .HasColumnType("int");

                    b.Property<int?>("CountQuestionForExamText")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.TestQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("IdTest")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTest");

                    b.ToTable("TestQuestions");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.UserAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("IdQuestionAnswer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUserAnswerTest")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TextAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdQuestionAnswer");

                    b.HasIndex("IdUserAnswerTest");

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.UserAnswerTest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdTest")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.HasIndex("TestId");

                    b.ToTable("UserAnswerTests");
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
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("TestQuestionId");

                    b.Navigation("TestQuestion");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.TestQuestion", b =>
                {
                    b.HasOne("NETElectronicLearningTool.EF.Model.Test", "Test")
                        .WithMany("TestQuestions")
                        .HasForeignKey("IdTest");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.UserAnswer", b =>
                {
                    b.HasOne("NETElectronicLearningTool.EF.Model.QuestionAnswer", "QuestionAnswer")
                        .WithMany("UserAnswer")
                        .HasForeignKey("IdQuestionAnswer");

                    b.HasOne("NETElectronicLearningTool.EF.Model.UserAnswerTest", "UserAnswerTest")
                        .WithMany("UserAnswers")
                        .HasForeignKey("IdUserAnswerTest");

                    b.Navigation("QuestionAnswer");

                    b.Navigation("UserAnswerTest");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.UserAnswerTest", b =>
                {
                    b.HasOne("NETElectronicLearningTool.EF.Model.User", "User")
                        .WithMany("UserAnswerTests")
                        .HasForeignKey("IdUser");

                    b.HasOne("NETElectronicLearningTool.EF.Model.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId");

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.Article", b =>
                {
                    b.Navigation("ArticlePage");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.QuestionAnswer", b =>
                {
                    b.Navigation("UserAnswer");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.Test", b =>
                {
                    b.Navigation("TestQuestions");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.TestQuestion", b =>
                {
                    b.Navigation("QuestionAnswers");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.User", b =>
                {
                    b.Navigation("UserAnswerTests");
                });

            modelBuilder.Entity("NETElectronicLearningTool.EF.Model.UserAnswerTest", b =>
                {
                    b.Navigation("UserAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using NETElectronicLearningTool.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETElectronicLearningTool.EF
{
    public class LearningToolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HOME-PC\SQLEXPRESS01;Database=LearningTool;TrustServerCertificate=True; Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Article>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ArticlePage>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<MethodDiscription>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Test>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<TestQuestion>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
           
            modelBuilder.Entity<QuestionAnswer>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<UserAnswer>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ElementLearning>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<LevelKnowledge>()
                .Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<ElementLearning>()
                .HasMany<LevelKnowledge>(x => x.LevelKnowledges)
                .WithOne(x => x.ElementLearning)
                .HasForeignKey(x => x.IdElementLearning);

            modelBuilder.Entity<ElementLearning>()
                .HasMany<TestQuestion>(x => x.TestQuestions)
                .WithOne(x => x.ElementLearning)
                .HasForeignKey(x => x.IdElementLearning);

            modelBuilder.Entity<Test>()
                .HasMany<TestQuestion>(x => x.TestQuestions)
                .WithOne(x => x.Test)
                .HasForeignKey(x => x.IdTest);

            modelBuilder.Entity<Test>()
                .HasMany<TestQuestion>(x => x.TestQuestions)
                .WithOne(x => x.Test)
                .HasForeignKey(x => x.IdTest);

            modelBuilder.Entity<Article>()
                .HasMany<ArticlePage>(x => x.ArticlePage)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.IdArticle);

            modelBuilder.Entity<User>()
                .HasMany<UserAnswerTest>(x => x.UserAnswerTests)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.IdUser);
            modelBuilder.Entity<User>()
                .HasMany<LevelKnowledge>(x => x.LevelKnowledges)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.IdUser);

            modelBuilder.Entity<UserAnswerTest>()
                .HasMany<UserAnswer>(x => x.UserAnswers)
                .WithOne(x => x.UserAnswerTest)
                .HasForeignKey(x => x.IdUserAnswerTest);

            modelBuilder.Entity<QuestionAnswer>()
                .HasMany<UserAnswer>(x=>x.UserAnswer)
                .WithOne(x => x.QuestionAnswer)
                .HasForeignKey(x => x.IdQuestionAnswer);
        }
        public DbSet<Article> Articles { get; set; }   
        public DbSet<ArticlePage> ArticlePages { get; set; }
        public DbSet<MethodDiscription> DictionaryOfFunctions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserAnswerTest> UserAnswerTests { get; set; }
        public DbSet<ElementLearning> ElementLearning { get; set; }
        public DbSet<LevelKnowledge> LevelKnowledge { get; set; }
    }
}

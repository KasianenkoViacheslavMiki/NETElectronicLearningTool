using Microsoft.EntityFrameworkCore;
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
                .HasMany<ArticlePage>(x => x.ArticlePage)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.IdArticle);
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
                .HasMany<TestQuestion>(x => x.TestQuestions)
                .WithOne(x => x.Test)
                .HasForeignKey(x => x.Id);

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
        }
        public DbSet<Article> Articles { get; set; }   
        public DbSet<ArticlePage> ArticlePages { get; set; }
        public DbSet<MethodDiscription> DictionaryOfFunctions { get; set; }
    }
}

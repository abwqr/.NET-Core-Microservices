using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace chatbotapi.Models;

public partial class ChatbotContext : DbContext
{
    public ChatbotContext()
    {
    }

    public ChatbotContext(DbContextOptions<ChatbotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Query> Queries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        // => optionsBuilder.UseMySql("server=localhost;user=root;password=abdullah;database=chatbot", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Query>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("query");

            entity.Property(e => e.Answer)
                .HasMaxLength(400)
                .HasColumnName("answer");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Question)
                .HasMaxLength(200)
                .HasColumnName("question");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OAuth2._0.Repositories.Models
{
    public partial class oauth2Context : DbContext
    {
        public oauth2Context()
        {
        }

        public oauth2Context(DbContextOptions<oauth2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Token> Tokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>(entity =>
            {
                entity.ToTable("Token");

                entity.Property(e => e.AccessToken).HasMaxLength(500);

                entity.Property(e => e.ProfileInfo).HasMaxLength(500);

                entity.Property(e => e.RefreshToken).HasMaxLength(500);

                entity.Property(e => e.Resource).HasMaxLength(50);

                entity.Property(e => e.Scope).HasMaxLength(500);

                entity.Property(e => e.Source).HasMaxLength(25);

                entity.Property(e => e.TokenType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

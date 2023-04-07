using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Team121GBCapstoneProject.Models;

public partial class GPDbContext : DbContext
{
    public GPDbContext()
    {
    }

    public GPDbContext(DbContextOptions<GPDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Esrbrating> Esrbratings { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameGenre> GameGenres { get; set; }

    public virtual DbSet<GamePlatform> GamePlatforms { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<ListKind> ListKinds { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonGame> PersonGames { get; set; }

    public virtual DbSet<PersonList> PersonLists { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=GPConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Esrbrating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESRBRati__3214EC279B070A58");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC2733F95029");

            entity.HasOne(d => d.Esrbrating).WithMany(p => p.Games).HasConstraintName("FK_ESRBRatingID");
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameGenr__3214EC272D774E19");

            entity.HasOne(d => d.Game).WithMany(p => p.GameGenres).HasConstraintName("FK_GameGenreID");

            entity.HasOne(d => d.Genre).WithMany(p => p.GameGenres).HasConstraintName("FK_GenreID");
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GamePlat__3214EC279185EF0A");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePlatforms).HasConstraintName("FK_GamePlatformID");

            entity.HasOne(d => d.Platform).WithMany(p => p.GamePlatforms).HasConstraintName("FK_PlatformID");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC27AD3DA011");
        });

        modelBuilder.Entity<ListKind>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ListKind__3214EC274F460891");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC2743128994");
        });

        modelBuilder.Entity<PersonGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonGa__3214EC275A7EC48E");

            entity.HasOne(d => d.Game).WithMany(p => p.PersonGames)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameID");

            entity.HasOne(d => d.PersonList).WithMany(p => p.PersonGames)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonListID");
        });

        modelBuilder.Entity<PersonList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonLi__3214EC27860E802F");

            entity.HasOne(d => d.ListKindNavigation).WithMany(p => p.PersonLists).HasConstraintName("FK_ListKindID");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonID");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Platform__3214EC27BA90CBA6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

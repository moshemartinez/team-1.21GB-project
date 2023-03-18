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
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC27AEFF766A");
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameGenr__3214EC2764D57436");

            entity.HasOne(d => d.Game).WithMany(p => p.GameGenres).HasConstraintName("FK_GameGenreID");

            entity.HasOne(d => d.Genre).WithMany(p => p.GameGenres).HasConstraintName("FK_GenreID");
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GamePlat__3214EC27A7D41CB6");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePlatforms).HasConstraintName("FK_GamePlatformID");

            entity.HasOne(d => d.Platform).WithMany(p => p.GamePlatforms).HasConstraintName("FK_PlatformID");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC27F0231A27");
        });

        modelBuilder.Entity<ListKind>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ListKind__3214EC27F29E0521");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC27FC9AF289");
        });

        modelBuilder.Entity<PersonGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonGa__3214EC271451D71C");

            entity.HasOne(d => d.Game).WithMany(p => p.PersonGames)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameID");

            entity.HasOne(d => d.PersonList).WithMany(p => p.PersonGames)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonListID");
        });

        modelBuilder.Entity<PersonList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonLi__3214EC27C168E3E9");

            entity.HasOne(d => d.ListKindNavigation).WithMany(p => p.PersonLists).HasConstraintName("FK_ListKindID");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonID");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Platform__3214EC2762555B0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

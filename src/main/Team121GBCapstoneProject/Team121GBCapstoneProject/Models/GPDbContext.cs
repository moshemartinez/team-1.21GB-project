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

    public virtual DbSet<GamePlayListType> GamePlayListTypes { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonGameList> PersonGameLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=GPConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC2723551AB4");
        });

        modelBuilder.Entity<GamePlayListType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GamePlay__3214EC275084E0F3");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC27982EC9F5");
        });

        modelBuilder.Entity<PersonGameList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonGa__3214EC27D9F7C843");

            entity.HasOne(d => d.Game).WithMany(p => p.PersonGameLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameID");

            entity.HasOne(d => d.ListKind).WithMany(p => p.PersonGameLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListKindID");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonGameLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

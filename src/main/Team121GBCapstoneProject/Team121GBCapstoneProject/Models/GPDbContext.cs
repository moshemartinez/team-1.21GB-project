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

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=GPConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC27B62621B2");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__List__3214EC27373DC757");

            entity.HasOne(d => d.Person).WithMany(p => p.Lists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameList_Person");

            entity.HasMany(d => d.Games).WithMany(p => p.Lists)
                .UsingEntity<Dictionary<string, object>>(
                    "GameList",
                    r => r.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GameList_Game"),
                    l => l.HasOne<List>().WithMany()
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GameList_List"),
                    j =>
                    {
                        j.HasKey("ListId", "GameId");
                        j.ToTable("GameList");
                    });
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC278D204904");

            entity.HasOne(d => d.CompletedList).WithMany(p => p.PersonCompletedLists).HasConstraintName("FK_CompletedList");

            entity.HasOne(d => d.CurrentlyPlayingList).WithMany(p => p.PersonCurrentlyPlayingLists).HasConstraintName("FK_CurrentlyPlayingList");

            entity.HasOne(d => d.WantToPlayList).WithMany(p => p.PersonWantToPlayLists).HasConstraintName("FK_WantToPlayList");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

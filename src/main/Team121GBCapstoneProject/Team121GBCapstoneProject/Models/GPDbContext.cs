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

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<UserList> UserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=GPConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC271C82E495");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC27D8837B33");

            entity.HasOne(d => d.CompletedList).WithMany(p => p.PersonCompletedLists).HasConstraintName("FK_CompletedList");

            entity.HasOne(d => d.CurrentlyPlayingList).WithMany(p => p.PersonCurrentlyPlayingLists).HasConstraintName("FK_CurrentlyPlayingList");

            entity.HasOne(d => d.WantToPlayList).WithMany(p => p.PersonWantToPlayLists).HasConstraintName("FK_WantToPlayList");
        });

        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserList__3214EC2702D99F1E");

            entity.HasOne(d => d.Person).WithMany(p => p.UserLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GameList_Person");

            entity.HasMany(d => d.Games).WithMany(p => p.UserLists)
                .UsingEntity<Dictionary<string, object>>(
                    "GameList",
                    r => r.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GameList_Game"),
                    l => l.HasOne<UserList>().WithMany()
                        .HasForeignKey("UserListId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GameList_List"),
                    j =>
                    {
                        j.HasKey("UserListId", "GameId");
                        j.ToTable("GameList");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

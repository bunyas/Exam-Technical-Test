using System;
using System.Collections.Generic;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace exam.context;

public partial class EXAMContext : DbContext
{
    public EXAMContext()
    {
    }

    public EXAMContext(DbContextOptions<EXAMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventSeat> EventSeats { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViewListOfSpeaker> ViewListOfSpeakers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Exam;User Id=sa;password=root85;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C810386BD4BE");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(500);
            entity.Property(e => e.RegistrationEndTime).HasColumnType("datetime");
            entity.Property(e => e.RegistrationStartTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<EventSeat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__EventSea__311713F332189D93");

            entity.Property(e => e.IsAllocated).HasDefaultValue(false);

            entity.HasOne(d => d.AllocatedToUser).WithMany(p => p.EventSeats)
                .HasForeignKey(d => d.AllocatedToUserId)
                .HasConstraintName("FK__EventSeat__Alloc__4AB81AF0");

            entity.HasOne(d => d.Event).WithMany(p => p.EventSeats)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventSeat__Event__49C3F6B7");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__Registra__6EF58810042BC29C");

            entity.Property(e => e.RegistrationTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Event).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registrat__Event__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Registrat__UserI__45F365D3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C26C8EA95");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534D1F30C3B").IsUnique();

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ViewListOfSpeaker>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_list_of_speakers");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EventName).HasMaxLength(500);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.RegistrationTime).HasColumnType("datetime");
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

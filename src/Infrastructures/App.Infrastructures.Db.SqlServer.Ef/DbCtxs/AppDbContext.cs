using System;
using System.Collections.Generic;
using App.Core.Domain.Entities;
using App.Infrastructures.Db.SqlServer.Ef.EntitiesConfigs;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Db.SqlServer.Ef.DbCtxs;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    #region DbSets
    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<TicketHistory> TicketHistories { get; set; }

    public virtual DbSet<TicketPriority> TicketPriorities { get; set; }

    public virtual DbSet<TicketStatus> TicketStatuses { get; set; }
    #endregion



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        
        
        modelBuilder.ApplyConfiguration(new TicketConfigs());

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<TicketHistory>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Comment).HasMaxLength(1000);

            entity.HasOne(d => d.Status).WithMany(p => p.TicketHistories)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketHistories_TicketStatuses");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketHistories)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketHistories_Tickets");
        });

        modelBuilder.Entity<TicketPriority>(entity =>
        {
            entity.Property(e => e.Color).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<TicketStatus>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

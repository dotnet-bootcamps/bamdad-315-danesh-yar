using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using App.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructures.Db.SqlServer.Ef.EntitiesConfigs
{
    internal class TicketConfigs : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Subject).HasMaxLength(250);

            builder.HasOne(d => d.Category).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_TicketCategories");

            builder.HasOne(d => d.CurrentStatus).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CurrentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_TicketStatuses");

            builder.HasOne(d => d.Priority).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_TicketPriorities");

        }
    }
}

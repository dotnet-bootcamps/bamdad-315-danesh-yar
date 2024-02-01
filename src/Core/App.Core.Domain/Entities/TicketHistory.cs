namespace App.Core.Domain.Entities;

public partial class TicketHistory
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public byte StatusId { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public virtual TicketStatus Status { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}

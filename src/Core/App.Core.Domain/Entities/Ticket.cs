namespace App.Core.Domain.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public string Subject { get; set; } = null!;

    public byte CategoryId { get; set; }

    public byte PriorityId { get; set; }

    public byte CurrentStatusId { get; set; }

    public string Description { get; set; } = null!;

    public int SubmitedBy { get; set; }

    public DateTime SubmittedAt { get; set; }

    public virtual TicketCategory Category { get; set; } = null!;

    public virtual TicketStatus CurrentStatus { get; set; } = null!;

    public virtual TicketPriority Priority { get; set; } = null!;

    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
}

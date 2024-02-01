namespace App.Core.Domain.Entities;

public partial class TicketStatus
{
    public byte Id { get; set; }

    public string Title { get; set; } = null!;

    public byte? MaxWaitingHours { get; set; }

    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

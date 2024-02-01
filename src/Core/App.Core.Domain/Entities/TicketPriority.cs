namespace App.Core.Domain.Entities;

public partial class TicketPriority
{
    public byte Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

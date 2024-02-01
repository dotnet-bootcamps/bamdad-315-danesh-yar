namespace App.Core.Domain.Entities;

public partial class TicketCategory
{
    public byte Id { get; set; }

    public byte? ParentId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

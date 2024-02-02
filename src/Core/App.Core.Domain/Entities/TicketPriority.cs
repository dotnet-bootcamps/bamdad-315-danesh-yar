using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities;

public partial class TicketPriority
{

    [Display(Name = "شناسه")]
    public byte Id { get; set; }


    [Display(Name = "عنوان")]
    public string Title { get; set; } = null!;


    [Display(Name = "رنگ نمایشی")]
    public string? Color { get; set; }

    
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

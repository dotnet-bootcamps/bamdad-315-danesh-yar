using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities;

public partial class TicketCategory
{

    [Display(Name = "شناسه")]
    public byte Id { get; set; }


    [Display(Name = "شناسه والد")]
    public byte? ParentId { get; set; }


    [Display(Name = "عنوان")]
    public string Title { get; set; } = null!;
    
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

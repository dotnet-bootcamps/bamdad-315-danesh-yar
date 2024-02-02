using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities;

public partial class TicketStatus
{

    [Display(Name = "شناسه")]
    public byte Id { get; set; }


    [Display(Name = "عنوان")]
    public string Title { get; set; } = null!;


    [Display(Name = "مدت زمان انتظار در این وضعیت")]
    public byte? MaxWaitingHours { get; set; }

    
    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}

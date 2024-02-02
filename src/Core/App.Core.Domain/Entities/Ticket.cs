using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities;

public partial class Ticket
{
    [Display(Name = "شناسه")]
    public int Id { get; set; }


    [Display(Name = "")]
    public string Subject { get; set; } = null!;


    [Display(Name = "")]
    public byte CategoryId { get; set; }


    [Display(Name = "")]
    public byte PriorityId { get; set; }


    [Display(Name = "")]
    public byte CurrentStatusId { get; set; }


    [Display(Name = "")]
    public string Description { get; set; } = null!;


    [Display(Name = "")]
    public int SubmitedBy { get; set; }


    [Display(Name = "")]
    public DateTime SubmittedAt { get; set; }


    [Display(Name = "")]
    public virtual TicketCategory Category { get; set; } = null!;


    [Display(Name = "")]
    public virtual TicketStatus CurrentStatus { get; set; } = null!;


    [Display(Name = "")]
    public virtual TicketPriority Priority { get; set; } = null!;


    [Display(Name = "")]
    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
}

using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities;

public partial class Ticket
{
    [Display(Name = "شناسه")]
    public int Id { get; set; }


    [Display(Name = "موضوع درخواست")]
    public string Subject { get; set; } = null!;


    [Display(Name = "شناسه دسته بندی")]
    public byte CategoryId { get; set; }


    [Display(Name = "شناسه الویت")]
    public byte PriorityId { get; set; }


    [Display(Name = "شناسه وضعیت")]
    public byte CurrentStatusId { get; set; }


    [Display(Name = "توضیخات درخواست")]
    public string Description { get; set; } = null!;


    [Display(Name = "شناسه درخواست کننده")]
    public int SubmitedBy { get; set; }


    [Display(Name = "تارخ ثبت درخواست")]
    public DateTime SubmittedAt { get; set; }


    [Display(Name = "دسته بندی")]
    public virtual TicketCategory Category { get; set; } = null!;


    [Display(Name = "وضعیت درخواست")]
    public virtual TicketStatus CurrentStatus { get; set; } = null!;


    [Display(Name = "الویت درخواست")]
    public virtual TicketPriority Priority { get; set; } = null!;


    [Display(Name = "تاریحچه درخواست")]
    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
}

using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities;

public partial class Ticket
{
    [Display(Name = "شناسه")]
    public int Id { get; set; }


    [Display(Name = "موضوع")]
    public string Subject { get; set; } = null!;


    [Display(Name = "شناسه دسته بندی")]
    public byte CategoryId { get; set; }


    [Display(Name = "شناسه اولویت")]
    public byte PriorityId { get; set; }


    [Display(Name = "شناسه وضعیت")]
    public byte CurrentStatusId { get; set; }


    [Display(Name = "توضیحات")]
    public string Description { get; set; } = null!;


    [Display(Name = "نام درخواست کننده")]
    public int SubmitedBy { get; set; }


    [Display(Name = "زمان ثبت")]
    public DateTime SubmittedAt { get; set; }


    [Display(Name = "دسته بندی")]
    public virtual TicketCategory Category { get; set; } = null!;


    [Display(Name = "وضعیت")]
    public virtual TicketStatus CurrentStatus { get; set; } = null!;


    [Display(Name = "اولویت")]
    public virtual TicketPriority Priority { get; set; } = null!;


    [Display(Name = "تاریخچه")]
    public virtual ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
}

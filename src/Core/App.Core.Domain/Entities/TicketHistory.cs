using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities;

public partial class TicketHistory
{

    [Display(Name = "شناسه")]
    public int Id { get; set; }


    [Display(Name = "شناسه درخواست")]
    public int TicketId { get; set; }


    [Display(Name = "شناسه وضعیت")]
    public byte StatusId { get; set; }


    [Display(Name = "پاسخ / یادداشت")]
    public string Comment { get; set; } = null!;


    [Display(Name = "زمان ثبت")]
    public DateTime CreatedAt { get; set; }


    [Display(Name = "شناسه نویسنده")]
    public int CreatedBy { get; set; }
    
    public virtual TicketStatus Status { get; set; } = null!;
    public virtual Ticket Ticket { get; set; } = null!;
}

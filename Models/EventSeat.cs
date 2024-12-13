using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class EventSeat
{
    public int SeatId { get; set; }

    public int EventId { get; set; }

    public int SeatNumber { get; set; }

    public bool? IsAllocated { get; set; }

    public int? AllocatedToUserId { get; set; }

    public virtual User? AllocatedToUser { get; set; }

    public virtual Event Event { get; set; } = null!;
}

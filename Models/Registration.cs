using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class Registration
{
    public int RegistrationId { get; set; }

    public int EventId { get; set; }

    public int UserId { get; set; }

    public int? SeatNumber { get; set; }

    public DateTime? RegistrationTime { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

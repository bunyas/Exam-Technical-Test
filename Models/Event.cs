using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public int TotalSeats { get; set; }

    public DateTime RegistrationStartTime { get; set; }

    public DateTime RegistrationEndTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<EventSeat> EventSeats { get; set; } = new List<EventSeat>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}

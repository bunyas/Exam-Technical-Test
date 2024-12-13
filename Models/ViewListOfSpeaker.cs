using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class ViewListOfSpeaker
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? RegistrationTime { get; set; }

    public int? SeatNumber { get; set; }
}

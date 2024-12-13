using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string? City { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<EventSeat> EventSeats { get; set; } = new List<EventSeat>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}

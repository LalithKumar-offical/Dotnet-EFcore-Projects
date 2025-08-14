using System;
using System.Collections.Generic;

namespace WebApplication4.Models;

public partial class Passenger
{
    public string PassId { get; set; } = null!;

    public string? PassName { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Address { get; set; }

    public long? PhoneNo { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

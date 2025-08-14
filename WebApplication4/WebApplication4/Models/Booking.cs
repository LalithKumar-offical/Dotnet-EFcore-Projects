using System;
using System.Collections.Generic;

namespace WebApplication4.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public string? FlightId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public int? Amount { get; set; }

    public virtual FlightDetail? Flight { get; set; }

    public virtual ICollection<Passenger> Passes { get; set; } = new List<Passenger>();
}

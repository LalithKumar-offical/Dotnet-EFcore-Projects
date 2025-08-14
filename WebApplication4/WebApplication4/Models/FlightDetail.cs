using System;
using System.Collections.Generic;

namespace WebApplication4.Models;

public partial class FlightDetail
{
    public string FlightId { get; set; } = null!;

    public string? FlightName { get; set; }

    public string? FlightSource { get; set; }

    public string? FlightDestination { get; set; }

    public DateOnly? FlightDate { get; set; }

    public int? FlightSeat { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

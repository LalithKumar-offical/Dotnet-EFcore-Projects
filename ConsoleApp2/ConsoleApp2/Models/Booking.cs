using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public string? FlightId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public int? Amount { get; set; }
}

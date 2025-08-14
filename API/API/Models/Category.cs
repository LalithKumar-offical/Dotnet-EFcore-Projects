using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }
    public virtual ICollection<Booking>? Bookings { get; set; }

}

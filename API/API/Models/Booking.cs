using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Booking
{
    public int Bookid { get; set; }

    public string Bookname { get; set; } = null!;

    public decimal Bookprice { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; } = null!;
}

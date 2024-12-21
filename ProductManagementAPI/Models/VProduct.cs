using System;
using System.Collections.Generic;

namespace ProductManagementAPI.Models;

public partial class VProduct
{
    public string Productname { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}

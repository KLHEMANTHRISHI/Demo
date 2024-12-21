using System;
using System.Collections.Generic;

namespace ProductManagementAPI.Models;

public partial class ProductsPrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}

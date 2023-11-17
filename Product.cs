using System;
using System.Collections.Generic;

namespace WpfApp10_Shop;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Color { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Qty { get; set; }
}

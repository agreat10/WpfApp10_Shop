using System;
using System.Collections.Generic;

namespace WpfApp10_Shop;

public partial class Order
{
    public int Id { get; set; }

    public int? Idcustomer { get; set; }

    public int? Idemployee { get; set; }

    public DateTime? OrderDate { get; set; }

    public int IdProduct { get; set; }

    public int Qty { get; set; }
}

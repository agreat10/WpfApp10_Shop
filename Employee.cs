using System;
using System.Collections.Generic;

namespace WpfApp10_Shop;

public partial class Employee
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string? Mname { get; set; }

    public string Lname { get; set; } = null!;

    public string Post { get; set; } = null!;

    public decimal Salary { get; set; }

    public decimal? PriorSalary { get; set; }

    public string Phone { get; set; } = null!;

    public int IdProduct { get; set; }
}

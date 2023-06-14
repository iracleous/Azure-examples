using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace az204_blob.Models;

public class Customer
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }
    public int Income { get; set; }
    public int TaxUdf { get; set; }
    public List<string> Emails { get; set; } = new List<string>();
}
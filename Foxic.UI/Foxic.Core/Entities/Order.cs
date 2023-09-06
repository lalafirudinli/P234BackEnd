using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Core.Entities;

public class Order : BaseEntity
{
    public double TotalPrice { get; set; }
    public DateTime CreatedTime { get; set; }
    public string? Description { get; set; }

	public ICollection<OrderItem> Products { get; set; }
}

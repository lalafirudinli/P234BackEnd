using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Core.Entities;

public class Order : BaseEntity
{
    public int Id { get; set; } 
    public int TotalPrice { get; set; }
    public int CreatedTime { get; set; }
    public int Description { get; set; }

	public ICollection<OrderItem> Products { get; set; }
}

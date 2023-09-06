using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Core.Entities;

public class OrderItem : BaseEntity
{
    public int Count { get; set; }
    public int Price { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
	public int OrderId { get; set; }
	public Order Orders { get; set; }
    public int ProductId { get; set; }
	public  Product Product { get; set; }   

}

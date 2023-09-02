using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Core.Entities
{
    public class ProductSize : BaseEntity
	{
        
        public Product Product { get; set; }   
        public Size Size { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; } 
    }
}

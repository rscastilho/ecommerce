using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm.Domain.Models
{
    internal class ProductModel : BaseModel
    {
        public string description { get; set; } = string.Empty;
        public int quantity { get; set; }
        public double price { get; set; }
        public string image { get; set; } = string.Empty;
        public virtual CategoryModel Category { get; set; }
        public virtual SupplierModel Supplier { get; set; }

    }
}

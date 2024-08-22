using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Data.Models
{
    public class Order:BaseModel
    {
      
        public DateTime OrderDate { get; set; }
        public DateTime? DeleverDate { get; set; }
        public string Adress { get; set; }
        public string PaymentType { get; set; }

        public ICollection<OrderItem> Items { get; set; }


    }
}

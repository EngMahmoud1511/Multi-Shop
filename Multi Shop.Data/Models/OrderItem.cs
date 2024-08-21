using Microsoft.EntityFrameworkCore;

namespace Multi_Shop.Data.Models
{
    [PrimaryKey(nameof(OrderId), nameof(ItemId))]
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId  { get; set; } 

    }
}
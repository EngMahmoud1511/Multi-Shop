using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Data.DTO
{
    public class ItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = null;



    }
}

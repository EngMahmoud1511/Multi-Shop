﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Data.Models
{
    public class Item:BaseModel
    {
       
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; } = null;
        public int CategoryiId { get; set; }
       
        public Category? Category { get; set; }
        public ICollection<OrderItem>? Orders { get; set; }

    }
}

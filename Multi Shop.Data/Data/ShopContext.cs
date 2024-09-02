using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Multi_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Data.Data
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Cstomers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }


    }
}

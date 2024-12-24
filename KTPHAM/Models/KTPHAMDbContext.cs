using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace KTPHAM.Models
{
    public class KTPHAMDbContext : DbContext
    {
        public KTPHAMDbContext() : base("KTPHAMDbContext") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<KitchenNotification> KitchenNotifications { get; set; }
        public DbSet<MenuStatistic> MenuStatistics { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
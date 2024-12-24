using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class MenuStatistic
    {
        [Key] // Chỉ định đây là khóa chính
        public int StatisticID { get; set; }
        public int MenuItemID { get; set; }
        public int TotalOrders { get; set; }
        public DateTime? LastOrdered { get; set; }

        // Navigation property
        public virtual MenuItem MenuItem { get; set; }
    }
}
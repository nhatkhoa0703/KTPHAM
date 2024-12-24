using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class KitchenNotification
    {
        [Key] // Chỉ định đây là khóa chính
        public int NotificationID { get; set; }
        public int OrderID { get; set; }
        public DateTime NotificationTime { get; set; }
        public string Status { get; set; }

        // Navigation property
        public virtual Order Order { get; set; }
    }
}
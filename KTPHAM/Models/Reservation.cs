using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; } // Mã định danh đặt bàn
        public int CustomerID { get; set; } // Liên kết với khách hàng
        public int TableID { get; set; } // Liên kết với bàn
        public DateTime ReservationTime { get; set; } // Thời gian đặt bàn
        public string Status { get; set; } // Trạng thái: Pending, Confirmed, Cancelled

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Table Table { get; set; }
    }
}
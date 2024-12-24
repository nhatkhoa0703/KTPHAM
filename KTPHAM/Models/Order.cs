using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KTPHAM.Models
{
    public class Order
    {
        public int OrderID { get; set; } // Mã định danh đơn hàng
        public int TableID { get; set; } // Liên kết với bàn
        public int? CustomerID { get; set; } // Liên kết với khách hàng (có thể null nếu khách vãng lai)
        public DateTime OrderTime { get; set; } // Thời gian đặt món
        public string Status { get; set; } // Trạng thái: Pending, In Progress, Completed, Cancelled

        // Navigation properties
        public virtual Table Table { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // Chi tiết đơn hàng
    }

}
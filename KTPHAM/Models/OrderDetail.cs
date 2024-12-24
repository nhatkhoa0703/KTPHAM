using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; } // Mã định danh chi tiết đơn hàng
        public int OrderID { get; set; } // Liên kết với đơn hàng
        public int MenuItemID { get; set; } // Liên kết với món ăn
        public int Quantity { get; set; } // Số lượng món
        public decimal Price { get; set; } // Giá tại thời điểm đặt món

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
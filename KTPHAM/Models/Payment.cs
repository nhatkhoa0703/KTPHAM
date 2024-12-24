using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class Payment
    {
        public int PaymentID { get; set; } // Mã định danh thanh toán
        public int OrderID { get; set; } // Liên kết với đơn hàng
        public string PaymentMethod { get; set; } // Phương thức thanh toán: Cash, Credit Card, Online
        public decimal AmountPaid { get; set; } // Số tiền đã thanh toán
        public DateTime PaymentTime { get; set; } // Thời gian thanh toán

        // Navigation property
        public virtual Order Order { get; set; }
    }
}
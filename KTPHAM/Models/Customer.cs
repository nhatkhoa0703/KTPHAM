using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class Customer
    {
        public int CustomerID { get; set; } // Mã định danh khách hàng
        public string FullName { get; set; } // Họ tên khách hàng
        public string PhoneNumber { get; set; } // Số điện thoại
        public string Email { get; set; } // Email khách hàng
        public DateTime CreatedAt { get; set; } // Ngày tạo thông tin
    }
}
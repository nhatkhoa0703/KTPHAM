    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class User
    {
        public int UserID { get; set; } // Mã người dùng
        public string Username { get; set; } // Tên đăng nhập
        public string PasswordHash { get; set; } // Mật khẩu (đã mã hoá)
        public string Role { get; set; } // Vai trò: Admin, Staff
    }
}
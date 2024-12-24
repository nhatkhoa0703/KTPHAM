using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class MenuItem
    {
        public int MenuItemID { get; set; } // Mã định danh món ăn
        public string Name { get; set; } // Tên món ăn
        public string Description { get; set; } // Mô tả món ăn
        public decimal Price { get; set; } // Giá món ăn
        public bool IsAvailable { get; set; } // Trạng thái có sẵn (true/false)
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; }
    }
}
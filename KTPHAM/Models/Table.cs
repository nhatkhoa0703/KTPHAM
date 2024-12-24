using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTPHAM.Models
{
    public class Table
    {
        public int TableID { get; set; } // Mã định danh bàn
        public int TableNumber { get; set; } // Số bàn
        public int Capacity { get; set; } // Sức chứa của bàn
        public bool IsAvailable { get; set; } // Trạng thái có sẵn (true: có sẵn, false: không có sẵn)
    }
}
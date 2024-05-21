using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanSua.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailsId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? OrderNumber { get; set; }
        public int? Quantity { get; set; }
        public int? Discount { get; set; }
        public int? Total { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? Amount { get; set; }
        public double? TotalMoney { get; set; }
        public int? Price { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

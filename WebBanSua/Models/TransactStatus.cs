using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanSua.Models
{
    public partial class TransactStatus
    {
        public TransactStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int TransactStatusId { get; set; }
        public string Status { get; set; }
        public string Des { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

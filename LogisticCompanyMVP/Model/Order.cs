using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompanyMVP.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Recipient { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ArriveDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edTech.DomainModels.Models
{
    public class RazorePayOrderModel
    {
        public decimal GrandTotal { get; set; }
        public string Currency { get; set; }
        public string Receipt { get; set; }
    }
}

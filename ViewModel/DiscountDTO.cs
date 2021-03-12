using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.ViewModel
{
    public class DiscountDTO
    {
        public Guid? CustomerTypeId { get; set; }
        public string Key { get; set; }
        public decimal Value { get; set; }
        public bool PercentOrFixed { get; set; }
        public string Description { get; set; }
        public bool CustomerorBIllType { get; set; }
    }
}

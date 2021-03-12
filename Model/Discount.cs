using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Model
{
    public class Discount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { set; get; }
        public Guid? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }

        public string Key { get; set; }
        public decimal Value { get; set; }
        public bool PercentOrFixed { get; set; }
        public string Description { get; set; }
        public bool CustomerorBIllType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

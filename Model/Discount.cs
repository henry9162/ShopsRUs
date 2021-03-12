using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Model
{
    public class Discount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { set; get; }

        [Required(ErrorMessage = "CustomerTypeId is required")]
        public Guid? CustomerTypeId { get; set; }

        [ForeignKey("CustomerTypeId")]
        public CustomerType CustomerType { get; set; }

        [Required(ErrorMessage = "Key is required")]
        public string Key { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "PercentOrFixed is required")]
        public bool PercentOrFixed { get; set; }

        public string Description { get; set; }

        [Required]
        public bool CustomerorBIllType { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

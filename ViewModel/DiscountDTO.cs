using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.ViewModel
{
    public class DiscountDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required(ErrorMessage = "CustomerTypeId is required")]
        public Guid CustomerTypeId { get; set; }

        [Required(ErrorMessage = "Key is required")]
        public string Key { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "IsPercent is required")]
        public bool IsPercent { get; set; }

        [Required(ErrorMessage = "IsFixed is required")]
        public bool IsFixed { get; set; }
        public string Description { get; set; }
    }
}

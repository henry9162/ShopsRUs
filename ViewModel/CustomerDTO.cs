using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.ViewModel
{
    public class CustomerDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { set; get; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "CustomerTypeId is required")]
        public Guid CUstomerTypeID { get; set; }
    }
}

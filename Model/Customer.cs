using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Model
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { set; get; }

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
        public Guid CUstomerTypeID { get; set; }
        public CustomerType CustomerType { get; set; }

        public DateTime DateCreated { get; set; }

    }
}

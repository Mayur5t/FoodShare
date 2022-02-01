using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Food_Center.Model
{
    public class Store_SignUpModel
    {
        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password required")]
        [Compare("Password")]
        public string Confirm_Password { get; set; }

        [Required(ErrorMessage = "Shop Name is required")]
        public string Shop_Name { get; set; }
    
        public string Address { get; set; }

        [Required(ErrorMessage = "Shop EmailId is required")]
        [EmailAddress]
        public string Shop_Emailid { get; set; }

        [Required(ErrorMessage = "Shop Phone Number is required")]
        public ulong Shop_Number { get; set; }
        public ulong Alternate_Number { get; set; }

        [Range(1,10)]
        public int Delivery_Radius { get; set; }

        public string Shop_logo { get; set; }
    }
}

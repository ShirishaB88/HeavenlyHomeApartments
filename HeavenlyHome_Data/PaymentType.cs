using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeID { get; set; }

        [Required]
        [Display(Name = "Payment method")]
        public string PaymentTypeName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

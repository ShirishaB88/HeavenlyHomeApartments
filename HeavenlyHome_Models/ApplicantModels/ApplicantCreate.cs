using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.ApplicantModels
{
    public class ApplicantCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }     
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime MoveInDate { get; set; }
        public string Requirements { get; set; }
    }
}

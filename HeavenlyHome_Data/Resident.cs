using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public class Resident
    {
        [Key]
        public int ResidentID { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressID { get; set; }

        public Address Address { get; set; }

        public string FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}

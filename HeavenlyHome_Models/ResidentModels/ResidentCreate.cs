using HeavenlyHome_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.ResidentModels
{
    public class ResidentCreate
    {
        public int AddressID { get; set; }

        public Address Address { get; set; }

        public string FullName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string EmailAddress { get; set; }
    }
}

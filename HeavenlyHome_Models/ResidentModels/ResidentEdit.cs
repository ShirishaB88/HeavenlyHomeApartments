using HeavenlyHome_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.ResidentModels
{
    public class ResidentEdit
    {
        public int ResidentID { get; set; }
      
        public int AddressID { get; set; }

        public Address Address { get; set; }

        public string FullName { get; set; }
       
        public int PhoneNumber { get; set; }
   
        public string EmailAddress { get; set; }
    }
}

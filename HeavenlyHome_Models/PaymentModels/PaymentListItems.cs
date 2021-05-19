using HeavenlyHome_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.PaymentModels
{
    public class PaymentListItems
    {
        public int ResidentID { get; set; }
        public Resident Resident { get; set; }
        public int MyProperty { get; set; }
    }
}

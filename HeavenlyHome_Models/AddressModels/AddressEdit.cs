using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.AddressModels
{
    public class AddressEdit
    {
        public int AddressID { get; set; }

        public int FloorPlanID { get; set; }

        public string FullAddress { get; set; }

        public bool IsAvailable { get; set; }
    }
}

using HeavenlyHome_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.MaintenanceRequestModels
{
    public class MaintenanceRequestListItems
    {
        public int RequestID { get; set; }

        public int ResidentID { get; set; }
        public Resident Resident { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }
        public string Location { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public bool AccessPermission { get; set; }
        public DateTimeOffset RequestDate { get; set; }
    }
}

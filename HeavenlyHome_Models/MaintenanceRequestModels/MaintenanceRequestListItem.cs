using HeavenlyHome_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.MaintenanceRequestModels
{
    public class MaintenanceRequestListItem
    {
        public int RequestID { get; set; }

        public int ResidentID { get; set; }
        public Resident Resident { get; set; }

        public Category Category { get; set; }

        public List<string> SubCategory { get; set; }
        public Location Location { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public bool AccessPermission { get; set; }
        public DateTimeOffset RequestDate { get; set; }
    }
}

using HeavenlyHome_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.MaintenanceRequestModels
{
    public class MaintenanceRequestCreate
    {
        public int ResidentID { get; set; }
        public Resident Resident { get; set; }

        [EnumDataType(typeof(Category))]
        public Category Category  { get; set; }
        public List<string> SubCategory { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool AccessPermission { get; set; }
        public DateTimeOffset RequestDate { get; set; }
    }
}

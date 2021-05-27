using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.FloorPlanModels
{
    public class FloorPlanListItem
    {
        public int FloorPlanID { get; set; }
        public string FloorPlanName { get; set; }
        public int NoOfBeds { get; set; }
        public int NoOfBaths { get; set; }
        public int AreaInSqFt { get; set; }
        public double Price { get; set; }
        public int NoOfGarageSpaces { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }      
        public DateTimeOffset CreatedDate { get; set; }
    }
}

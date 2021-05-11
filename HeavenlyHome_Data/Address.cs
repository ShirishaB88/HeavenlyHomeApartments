using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [ForeignKey(nameof(FloorPlan))]
        public int FloorPlanID { get; set; }

        public FloorPlan FloorPlan { get; set; }

        [Required]
        [MaxLength(1000)]
        public string FullAddress { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}

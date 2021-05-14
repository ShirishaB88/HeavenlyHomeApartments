using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public class FloorPlan
    {
        [Key]
        public int FloorPlanID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string FloorPlanName { get; set; }

        [Required]
        public int NoOfBeds { get; set; }

        [Required]
        public int NoOfBaths { get; set; }

        [Required]
        public int AreaInSqFt { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int NoOfGarageSpaces { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

    }
}

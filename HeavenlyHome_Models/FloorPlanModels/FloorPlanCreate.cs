using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Models.FloorPlanModels
{
    public class FloorPlanCreate
    {
        [Required]
        public string FloorPlanName { get; set; }

        [Required]
        public int NoOfBeds { get; set; }

        [Required]
        [Range(1,2)]
        public int NoOfBaths { get; set; }

        [Required]
        public int AreaInSqFt { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Range(0,2)]
        public int NoOfGarageSpaces { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }
    }
}

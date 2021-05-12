using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public class LeasingInfo
    {    
        [Key]
        public int LeasingID { get; set; }

        [ForeignKey(nameof(Resident))]
        public int ResidentID { get; set; }

        public Resident Resident { get; set; }

        [Required]
        public int LeaseTerm { get; set; }

        [Required]
        public int NoOfOccupants { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsPetIncluded { get; set; }

        [Required]
        public string OccupantsDetails { get; set; }

        [Required]
        public DateTime LeaseStartDate { get; set; }

        [Required]
        public DateTime LeaseEndDate { get; set; }
    }
}

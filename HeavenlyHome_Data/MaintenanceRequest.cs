using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public class MaintenanceListItems
    {
        [Key]
        public int RequestID { get; set; }

        public Guid UserID { get; set; }

        [ForeignKey(nameof(Resident))]
        public int ResidentID { get; set; }
        public Resident Resident { get; set; }

        [Required]
        public string Category { get; set; }

        public string SubCategory { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [MaxLength(3000)]
        public string Description { get; set; }
       
        public string Status { get; set; }

        public bool AccessPermission { get; set; }
        public DateTimeOffset RequestDate { get; set; }
       
    }
}

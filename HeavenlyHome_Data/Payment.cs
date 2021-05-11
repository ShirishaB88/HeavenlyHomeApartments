using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey(nameof(Resident))]
        public int ResidentID { get; set; }

        public Resident Resident { get; set; }

        [ForeignKey(nameof(PaymentType))]
        public int PaymentTypeID { get; set; }

        public PaymentType PaymentType { get; set; }

        public double Rent { get; set; }

        public double TrashPickUp { get { return 35; } }

        public double UtilityAmount { get; set; }

        public double TotalPayment { get { double totalAmount = Rent + TrashPickUp + UtilityAmount; return totalAmount; } }

        [Display(Name = "Payment Due On")]
        public DateTime PaymentDueDate { get; set; }

        public DateTimeOffset PaymentDate { get; set; }
    }
}

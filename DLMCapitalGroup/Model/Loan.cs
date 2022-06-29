using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLMCapitalGroup.Model
{
    public class Loan
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal MonthlyRepayment { get; set; }
        public int DurationInMonths { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string AccountId { get; set; }
        public decimal RequestedAmount { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; } 
        public  Customer Customer { get; set; }
    }
}

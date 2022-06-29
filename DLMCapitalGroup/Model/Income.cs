using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLMCapitalGroup.Model
{
    public class Income
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal MonthlyIncome { get; set; }
        public decimal AverageMonthlyIncome { get; set; }
        public decimal YearlyIncome { get; set; }
        public int IncomeSources { get; set; }


        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

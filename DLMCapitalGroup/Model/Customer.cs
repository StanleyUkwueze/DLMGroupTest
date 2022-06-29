using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DLMCapitalGroup.Model
{
    public class Customer : IdentityUser
    {
        public decimal MonthlyIncome { get; set; }
        public decimal AverageMonthlyIncome { get; set; }
        public decimal YearlyIncome { get; set; }
        public int IncomeSources { get; set; }
        public string Password { get; set; }
        public decimal RequestedAmount { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public List<Income> Income { get; set; }
        
        [ForeignKey("Loan")]
        public string LoanId { get; set; } 
        public Loan Loan { get; set; }

        public Customer()
        {
            Income = new List<Income>();
        }
    }
}
